using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]

namespace AzDev.Services
{
    internal static class AzDevModule
    {
        private static readonly IDictionary<string, object> Components;

        static AzDevModule()
        {
            Components = new Dictionary<string, object>();
        }

        public static T GetComponent<T>(string key)
        {
            if (Components[key] is T t)
            {
                return t;
            }
            else
            {
                throw new ArgumentException($"Mismatching type. Expect [{typeof(T)}]. Got [{Components[key].GetType()}].");
            }
        }

        public static void SetComponent<T>(string key, T value)
        {
            Components[key] = value;
        }
    }
}
