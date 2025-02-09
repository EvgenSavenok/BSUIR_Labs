using System.Reflection;
using Faker.Contracts;
using Faker.CustomGenerators;

namespace Faker;

public class Faker
{
    private readonly List<IValueGenerator> _generators =
    [
        new IntGenerator(),
        new LongGenerator(),
        new DoubleGenerator(),
        new FloatGenerator(),
        new StringGenerator(),
        new ListGenerator(),
        new ArrayGenerator(),
        new DateTimeGenerator()
    ];
    
    private readonly Random _random = new();
    
    private readonly ThreadLocal<HashSet<Type>> _typesInProcess;

    
    private readonly Dictionary<(Type ObjectType, MemberInfo Member), IValueGenerator> _customGenerators = new();
    
    public Faker()
    {
        _typesInProcess = new ThreadLocal<HashSet<Type>>(() => new());
    }

    private IValueGenerator? GetGenerator(Type objectType, MemberInfo member)
    {
        return _customGenerators.GetValueOrDefault((objectType, member));
    }

    public T Create<T>()
    {
        return (T)Create(typeof(T));
    }
    
    private static object GetDefaultValue(Type t)
    {
        return (t.IsValueType ? Activator.CreateInstance(t) : null)!;
    }
    
    public object Create(Type type)
    {
        if (!_typesInProcess.Value!.Add(type))
        {
            return GetDefaultValue(type);
        }

        try
        {
            var generator = _generators.FirstOrDefault(g => g.CanGenerate(type));
            if (generator != null)
                return generator.Generate(type, new(_random, this));

            return CreateComplexObject(type);
        }
        finally
        {
            _typesInProcess.Value.Remove(type);
        }
    }

    private object CreateComplexObject(Type type)
    {
        var constructors = type.GetConstructors(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance)
            .OrderByDescending(c => c.GetParameters().Length) 
            .ToList();
        
        foreach (var constructor in constructors)
        {
            try
            {
                var parameters = constructor.GetParameters();
                var parameterValues = parameters
                    .Select(p => GenerateParameterValue(type, p)).ToArray();
                var instance = constructor.Invoke(parameterValues);
                InitializePropertiesAndFields(instance, parameters);
                return instance;
            }
            catch
            {
                // Cause need to continue working 
            }
        }
        
        return GetDefaultValue(type);
    }
    
    private Type GetMemberType(MemberInfo member)
    {
        if (member is PropertyInfo property)
            return property.PropertyType;

        if (member is FieldInfo field)
            return field.FieldType;

        throw new InvalidOperationException("Member is not a property or field.");
    }
    
    private MemberInfo? FindMemberForParameter(Type objectType, ParameterInfo parameter)
    {
        var paramName = parameter.Name;
        var paramType = parameter.ParameterType;

        return objectType.GetMembers(BindingFlags.Public | BindingFlags.Instance)
            .Where(m => m is PropertyInfo or FieldInfo)
            .FirstOrDefault(m =>
                              string.Equals(m.Name, paramName, StringComparison.OrdinalIgnoreCase) &&
                              GetMemberType(m) == paramType);
    }
    
    private object GenerateParameterValue(Type objectType, ParameterInfo parameter)
    {
        var member = FindMemberForParameter(objectType, parameter) ??
                     objectType.GetMembers(BindingFlags.Public | BindingFlags.Instance)
                         .Where(m => m is PropertyInfo or FieldInfo)
                         .FirstOrDefault(m => GetMemberType(m) == parameter.ParameterType);

        var generator = member != null ? GetGenerator(objectType, member) : null;

        return generator != null && generator.CanGenerate(parameter.ParameterType)
            ? generator.Generate(parameter.ParameterType, new GeneratorContext(_random, this))
            : Create(parameter.ParameterType);
    }
    
    private void InitializeMember(Type type, MemberInfo member, Type memberType, Action<object?> setValue)
    {
        var generator = GetGenerator(type, member);
        var value = generator != null && generator.CanGenerate(memberType)
            ? generator.Generate(memberType, new (_random, this))
            : Create(memberType);
        setValue(value);
    }
    
    private void InitializePropertiesAndFields(object instance, ParameterInfo[] constructorParameters)
    {
        var type = instance.GetType();
        var parameterNames = constructorParameters
            .Select(p => p.Name!)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                     .Where(p => p.CanWrite && p.SetMethod!.IsPublic && !parameterNames.Contains(p.Name)))
        {
            InitializeMember(type, prop, prop.PropertyType, v => prop.SetValue(instance, v));
        }

        foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Instance)
                     .Where(f => !f.IsInitOnly && !parameterNames.Contains(f.Name)))
        {
            InitializeMember(type, field, field.FieldType, v => field.SetValue(instance, v));
        }
    }
}