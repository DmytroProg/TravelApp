namespace TravelApp.Tests;

public static class TestHelper
{
    public static void AssertIfNullFail(object? obj, string message)
    {
        if (obj == null)
        {
            Assert.Fail($"{message} does not exist");
        }
    }

    public static object? GetCustomType(string assembly, string name)
    {
        var type = Type.GetType($"{assembly}.{name}, {assembly}");
        AssertIfNullFail(type, name);
        return Activator.CreateInstance(type);
    }
}
