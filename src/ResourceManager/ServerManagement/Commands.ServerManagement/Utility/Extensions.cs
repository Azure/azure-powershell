using System;
using System.Globalization;
using System.Reflection;

namespace Microsoft.Azure.Commands.ServerManagement.Utility
{
    internal static class Extensions
    {

        internal static T Safe<T>(Func<T> expression)
        {
            try
            {
                return expression();
            }
            catch
            {
            }
            return default(T);
        }

        private static void SetMember<T>(this T target, string memberName, object value)
        {
            var dField = typeof(T).GetField(memberName, BindingFlags.NonPublic | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (dField != null)
            {
                try
                {
                    dField.SetValue(target, value);
                    return;
                }
                catch
                {
                    // skip it
                }
                
            }
            try
            {
                var dProp = typeof(T).GetProperty(memberName,
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase );
                if (dProp != null)
                {
                    if (dProp.DeclaringType != null)
                    {
                        dProp = dProp.DeclaringType.GetProperty(memberName,
                            BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance |
                            BindingFlags.IgnoreCase) ?? dProp;
                    }

                    dProp.GetSetMethod(true).Invoke(target, new object[] { value });
                }
            }
            catch
            {

            }
        }

        internal static string FromResourceId(this string resourceId, string prefix)
        {
            try
            {
                return System.Text.RegularExpressions.Regex.Match(resourceId+"/", $"/{prefix}/(.*?)/").Groups[1].Value;
            }
            catch
            {
                
            }

            return null;
        }

        internal static TDest CloneInto<TSrc, TDest>(this TSrc source, TDest destination )
        {
            // run thru public properties
            foreach (var property in typeof(TSrc).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                destination.SetMember(property.Name, property.GetValue(source));
            }

            // run thru public fields
            foreach ( var field in typeof(TSrc).GetFields(BindingFlags.Instance | BindingFlags.Public))
            {
                destination.SetMember(field.Name, field.GetValue(source));
            }
            return destination;
        }
    }
}