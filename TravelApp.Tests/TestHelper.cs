namespace TravelApp.Tests;

public static class TestHelper
{
    public static void AssertFailIfNull(object? obj, string message)
    {
        if (obj == null)
        {
            Assert.Fail($"{message} does not exist");
        }
    }

    public static object? GetCustomType(string assembly, string name, params object[] parameters)
    {
        var type = Type.GetType($"{assembly}.{name}, {assembly}");
        AssertFailIfNull(type, name);
        var types = parameters.Select(p => p.GetType()).ToArray();
        var constructor = type.GetConstructor(types);
        AssertFailIfNull(constructor, $"Constructor in class '{name}'");
        return Activator.CreateInstance(type, parameters);
    }

    public static object? GetCustomType(string assembly, string name)
    {
        var type = Type.GetType($"{assembly}.{name}, {assembly}");
        AssertFailIfNull(type, name);
        return Activator.CreateInstance(type);
    }
}
