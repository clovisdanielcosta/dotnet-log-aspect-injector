using AspectInjector.Broker;
using System.Diagnostics;
using System.Reflection;
using Scope = AspectInjector.Broker.Scope;

namespace LogAspectInjector;

[Aspect(Scope.Global)]
[Injection(typeof(LogCall))]
public class LogCall : Attribute
{
    private static Stopwatch _watch = new ();

    [Advice(Kind.Before)]
    public void LogBefore([Argument(Source.Name)] string name, [Argument(Source.Metadata)] MethodBase method)
    {
        if (name.Equals(".ctor")) return;

        var className = method.DeclaringType.Name;

        if (method.IsPublic) _watch.Start();
    }

    [Advice(Kind.After)]
    public void LogAfter([Argument(Source.Name)] string name, [Argument(Source.Metadata)] MethodBase method) 
    {
        if (name.Equals(".ctor")) return;

        var className = method.DeclaringType.Name;

        if (method.IsPublic)
        {
            _watch.Stop();
            Console.WriteLine($"Classe: {className, -20} | Método: {name, -20} | ElapsedTime: {_watch.Elapsed}");
            _watch.Reset();
        }
    }
}
