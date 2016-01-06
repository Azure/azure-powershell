using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Threading.Tasks;

namespace FormatParser
{
    public static class ReflectionExtensions
    {
        public static T GetAttribute<T>(this Type decoratedType) where T : Attribute
        {
            return decoratedType.GetTypeInfo().GetCustomAttribute(typeof(T), true) as T;
        }

        public static IEnumerable<T> GetAttributes<T>(this Type decoratedType) where T : Attribute
        {
            return decoratedType.GetTypeInfo().GetCustomAttributes(typeof(T), false).Select(a => a as T);
        }

        public static bool HasAttribute<T>(this Type decoratedType) where T : Attribute
        {
            return decoratedType.GetTypeInfo().CustomAttributes.Any(d => d.AttributeType == typeof (T));

        }
    }
}
