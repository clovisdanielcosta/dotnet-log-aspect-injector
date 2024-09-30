// See https://aka.ms/new-console-template for more information


using LogAspectInjector;

TesteLogWithAspectInjector.Test1();
TesteLogWithAspectInjector.Test2();



Console.WriteLine("Hello, World!");



[LogCall]
public static class TesteLogWithAspectInjector
{
    public static void Test1()
    {
        
    }

    public static void Test2()
    {
        
    }
}
