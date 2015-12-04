using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Microsoft.CLU
{
    /// <summary>
    /// Extension methods for System.Type class.
    /// </summary>
    internal static class TypeExtensions
    {
        /// <summary>
        /// Gets the underlying type of type. For example underlying
        /// type of Nullable<decimal> is decimal
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type UnderlyingType(this Type type)
        {
            if (type.IsNullable())
            {
                var utype = Nullable.GetUnderlyingType(type);
                if (utype != null)
                {
                    return utype;
                }
            }

            return type;
        }

        /// <summary>
        /// Return true if the given type is primitive and set primitive type code to
        /// 'primitiveType' out parameter, else return false and set primitive type 
        /// code to none.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="primitiveType"></param>
        /// <returns></returns>
        public static bool IsPrimitive(this Type type, out PrimitiveTypeCode primitiveType)
        {
            primitiveType = PrimitiveTypeCode.None;
            Type underlyingType = type.UnderlyingType();

            if (underlyingType == typeof(char))
            {
                primitiveType = PrimitiveTypeCode.Char;
            }
            else if (underlyingType == typeof(Int16))
            {
                primitiveType = PrimitiveTypeCode.Int16;
            }
            else if (underlyingType == typeof(UInt16))
            {
                primitiveType = PrimitiveTypeCode.UInt16;
            }
            else if (underlyingType == typeof(Int32))
            {
                primitiveType = PrimitiveTypeCode.Int32;
            }
            else if (underlyingType == typeof(UInt32))
            {
                primitiveType = PrimitiveTypeCode.UInt32;
            }
            else if (underlyingType == typeof(Int64))
            {
                primitiveType = PrimitiveTypeCode.Int64;
            }
            else if (underlyingType == typeof(UInt64))
            {
                primitiveType = PrimitiveTypeCode.UInt64;
            }
            else if (underlyingType == typeof(Single))
            {
                primitiveType = PrimitiveTypeCode.Single;
            }
            else if (underlyingType == typeof(decimal))
            {
                primitiveType = PrimitiveTypeCode.Decimal;
            }
            else if (underlyingType == typeof(string))
            {
                primitiveType = PrimitiveTypeCode.String;
            }
            else if (underlyingType == typeof(DateTimeOffset))
            {
                primitiveType = PrimitiveTypeCode.DateTimeOffset;
            }
            else if (underlyingType == typeof(DateTime))
            {
                primitiveType = PrimitiveTypeCode.DateTime;
            }
            else if (underlyingType == typeof(Uri))
            {
                primitiveType = PrimitiveTypeCode.Uri;
            }
            else if (underlyingType == typeof(FileInfo))
            {
                primitiveType = PrimitiveTypeCode.FileInfo;
            }
            else if (underlyingType == typeof(DirectoryInfo))
            {
                primitiveType = PrimitiveTypeCode.DirectoryInfo;
            }
            else if (typeof(JContainer).IsAssignableFrom(underlyingType))
            {
                primitiveType = PrimitiveTypeCode.JSON;
            }

            return (primitiveType != PrimitiveTypeCode.None);
        }

        /// <summary>
        /// Checks the type is nullable
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullable(this Type type)
        {
            var typeInfo = type.GetTypeInfo();
            if (typeInfo.IsValueType)
            {
                // all value types are non-nullable expect the type represented using Nullable<T>
                return typeInfo.IsGenericType && typeof(Nullable<>) == type.GetGenericTypeDefinition();
            }

            return true;
        }

        /// <summary>
        /// Checks the type represents a collection (including array)
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsCollection(this Type type)
        {
            return typeof(IEnumerable<>).IsAssignableFrom(type);
        }

        /// <summary>
        /// Checks the type is an array type with a specific element type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="elementType"></param>
        /// <returns></returns>
        public static bool IsArrayOfElementType(this Type type, Type elementType)
        {
            return type.IsArray && (type.GetElementType() == elementType);
        }

        /// <summary>
        /// Checks the given type has default constructor
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool hasDefaultConstructor(this Type type)
        {
            var constructor = type.GetConstructor(Type.EmptyTypes);
            return constructor != null;
        }

        /// <summary>
        /// Checks whether a type has a constructor taking a single argument of a specific type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parameterType"></param>
        /// <returns></returns>
        public static bool hasConstructorWithSingleParameterOfType(this Type type, Type parameterType)
        {
            var constructor = type.GetConstructor(new Type[] { parameterType });
            return constructor != null;
        }
    }
}
