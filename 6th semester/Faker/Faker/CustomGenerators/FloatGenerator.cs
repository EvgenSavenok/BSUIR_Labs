using Faker.Contracts;

namespace Faker.CustomGenerators;

public class FloatGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, GeneratorContext context)
    {
        return context.Random.NextSingle() * float.MaxValue;
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(float);
    }
}