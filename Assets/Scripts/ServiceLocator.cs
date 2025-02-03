using System.Collections.Generic;
using System;

public class ServiceLocator
{
    private static readonly Dictionary<Type, object> _services = new();

    public static void RegisterService<T>(T service)
    {
        _services[typeof(T)] = service;
    }
    public static T GetService<T>()
    {
        return (T)_services[typeof(T)];
    }
}
