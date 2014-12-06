using System;
using System.Reflection;

namespace Microsoft.SqlServer.Management.Relational.Domain.UnitTest
{
    /// <summary>
    /// Class that extends ICustomAttributeProvider
    /// to allow for type-safe access to custom attributes.
    /// </summary>
    internal static class CustomAttributeProviderExtensions
    {
        /// <summary>
        /// Retrieves a list of custom attributes of given type.
        /// </summary>
        /// <typeparam name="T">Type of attribute to retrieve.</typeparam>
        /// <param name="provider">Object from which to request the custom attributes.</param>
        /// <returns>Array of attributes</returns>
        public static T[] GetCustomAttributes<T>(this ICustomAttributeProvider provider) where T : Attribute
        {
            return GetCustomAttributes<T>(provider, false);
        }

        /// <summary>
        /// Retrieves a list of custom attributes of given type.
        /// </summary>
        /// <typeparam name="T">Type of attribute to retrieve.</typeparam>
        /// <param name="provider">Object from which to request the custom attributes.</param>
        /// <param name="inherit">Specifies wheather the attributes can be inherited from parent object</param>
        /// <returns>Array of attributes</returns>
        public static T[] GetCustomAttributes<T>(this ICustomAttributeProvider provider, bool inherit) where T : Attribute
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            T[] attributes = provider.GetCustomAttributes(typeof(T), inherit) as T[];
            if (attributes == null)
            {
                return new T[0];
            }

            return attributes;
        }

        /// <summary>
        /// Retrieves a single custom attribute of given type.
        /// </summary>
        /// <typeparam name="T">Type of attribute to retrieve.</typeparam>
        /// <param name="provider">Object from which to request the custom attributes.</param>
        /// <returns>An attribute obtained or null.</returns>
        public static T GetCustomAttribute<T>(this ICustomAttributeProvider provider) where T : Attribute
        {
            return GetCustomAttribute<T>(provider, false);
        }

        /// <summary>
        /// Retrieves a single custom attribute of given type.
        /// </summary>
        /// <typeparam name="T">Type of attribute to retrieve.</typeparam>
        /// <param name="provider">Object from which to request the custom attributes.</param>
        /// <param name="inherit">Specifies wheather the attributes can be inherited from parent object</param>
        /// <returns>An attribute obtained or null.</returns>
        public static T GetCustomAttribute<T>(this ICustomAttributeProvider provider, bool inherit) where T : Attribute
        {
            T[] attributes = GetCustomAttributes<T>(provider, inherit);

            if (attributes.Length > 1)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "Domain element is expected to contain 1 attribute(s) of type [{1}], but it contains {0} attribute(s).",
                        attributes.Length, 
                        typeof(T).Name));
            }

            if (attributes.Length == 1)
            {
                return attributes[0];
            }
            else
            {
                return null;
            }
        }
    }
}