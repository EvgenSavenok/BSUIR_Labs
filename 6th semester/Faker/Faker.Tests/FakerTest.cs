using Faker.Contracts;

namespace Faker.Tests;

public class FakerTest
{
    private readonly Faker _faker = new();
    [Fact]
    public void Create_PrimitiveTypeInt_ReturnsNonDefaultValue()
    {
        var result = _faker.Create<int>();
        Assert.NotEqual(default, result);
    }
    
    [Fact]
    public void Create_LongType_ReturnsValidLong()
    {
        var result = _faker.Create<long>();
        Assert.InRange(result, long.MinValue, long.MaxValue);
    }

    [Fact]
    public void Create_DoubleType_ReturnsValidDouble()
    {
        var result = _faker.Create<double>();
        Assert.InRange(result, double.MinValue, double.MaxValue);
    }

    [Fact]
    public void Create_FloatType_ReturnsValidFloat()
    {
        var result = _faker.Create<float>();
        Assert.InRange(result, float.MinValue, float.MaxValue);
    }
    
    [Fact]
    public void Create_StringType_ReturnsNonEmptyString()
    {
        var result = _faker.Create<string>();
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public void Create_ArrayType_ReturnsNonEmptyArray()
    {
        var array = _faker.Create<int[]>();
        
        Assert.NotNull(array);
        Assert.NotEmpty(array);
        Assert.All(array, x => Assert.NotEqual(default, x));
    }
    
    [Fact] 
    public void Create_TypeWithCyclicDependency_BreaksCycleByNull()
    {
        var a = _faker.Create<A>();

        Assert.NotNull(a.B);
        Assert.NotNull(a.B.C);
        Assert.Null(a.B.C.A);
    }
    
    [Fact]
    public void Create_Dictionary_ShouldBeNull()
    {
        var dictionary = _faker.Create<Dictionary<string, int>>();
        Assert.Null(dictionary);
    }
    
    [Fact]
    public void Create_StructWithConstructor_InitializesCorrectly()
    {
        var result = _faker.Create<TestStruct>();
        Assert.NotEqual(default(TestStruct), result);
        Assert.True(result.Value > 0);
    }
    
    
    // Custom types
    
    
    public class A
    {
        public B B { get; set; }
    }

    public class B
    {
        public C C { get; set; }
    }

    public class C
    {
        public A A { get; set; }
    }

    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    public class ImmutableUser
    {
        public string Name { get; }

        public ImmutableUser(string nameParam)
        {
            Name = nameParam;
        }
    }
    
    public struct TestStruct
    {
        public int Value { get; }

        public TestStruct(int value)
        {
            Value = value;
        }
    }
}