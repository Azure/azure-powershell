/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.PowerShell
{
    internal static class PsExtensions
    {
        public static PSObject AddMultipleTypeNameIntoPSObject(this object obj, string multipleTag = "#Multiple")
        {
            var psObj = new PSObject(obj);
            psObj.TypeNames.Insert(0, $"{psObj.TypeNames[0]}{multipleTag}");
            return psObj;
        }

        // https://stackoverflow.com/a/863944/294804
        // https://stackoverflow.com/a/4452598/294804
        // https://stackoverflow.com/a/28701974/294804
        // Note: This will unwrap nested collections, but we don't generate nested collections.
        public static Type Unwrap(this Type type)
        {
            if (type.IsArray)
            {
                return type.GetElementType().Unwrap();
            }

            var typeInfo = type.GetTypeInfo();
            if (typeInfo.IsGenericType
                && (typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>) || typeof(IEnumerable<>).IsAssignableFrom(type)))
            {
                return typeInfo.GetGenericArguments().First().Unwrap();
            }

            return type;
        }

        // https://stackoverflow.com/a/863944/294804
        private static bool IsSimple(this Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return typeInfo.IsPrimitive
                   || typeInfo.IsEnum
                   || type == typeof(string)
                   || type == typeof(decimal);
        }

        // https://stackoverflow.com/a/32025393/294804
        private static bool HasImplicitConversion(this Type baseType, Type targetType) =>
            baseType.GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(mi => mi.Name == "op_Implicit" && mi.ReturnType == targetType)
                .Any(mi => mi.GetParameters().FirstOrDefault()?.ParameterType == baseType);

        public static bool IsPsSimple(this Type type)
        {
            var unwrappedType = type.Unwrap();
            return unwrappedType.IsSimple()
                   || unwrappedType == typeof(SwitchParameter)
                   || unwrappedType == typeof(Hashtable)
                   || unwrappedType == typeof(PSCredential)
                   || unwrappedType == typeof(ScriptBlock)
                   || unwrappedType == typeof(DateTime)
                   || unwrappedType == typeof(Uri)
                   || unwrappedType.HasImplicitConversion(typeof(string));
        }

        public static string ToPsList(this IEnumerable<string> items) => String.Join(", ", items.Select(i => $"'{i}'"));

        public static IEnumerable<string> ToAliasNames(this IEnumerable<Attribute> attributes) => attributes.OfType<AliasAttribute>().SelectMany(aa => aa.AliasNames).Distinct();

        public static bool IsArrayAndElementTypeIsT<T>(this object item)
        {
            var itemType = item.GetType();
            var tType = typeof(T);
            return itemType.IsArray && !tType.IsArray && tType.IsAssignableFrom(itemType.GetElementType());
        }

        public static bool IsTArrayAndElementTypeIsItem<T>(this object item)
        {
            var itemType = item.GetType();
            var tType = typeof(T);
            return !itemType.IsArray && tType.IsArray && (tType.GetElementType()?.IsAssignableFrom(itemType) ?? false);
        }

        public static bool IsTypeOrArrayOfType<T>(this object item) => item is T || item.IsArrayAndElementTypeIsT<T>() || item.IsTArrayAndElementTypeIsItem<T>();

        public static T NormalizeArrayType<T>(this object item)
        {
            if (item is T result)
            {
                return result;
            }

            if (item.IsArrayAndElementTypeIsT<T>())
            {
                var array = (T[])Convert.ChangeType(item, typeof(T[]));
                return array.FirstOrDefault();
            }

            if (item.IsTArrayAndElementTypeIsItem<T>())
            {
                var tType = typeof(T);
                var array = Array.CreateInstance(tType.GetElementType(), 1);
                array.SetValue(item, 0);
                return (T)Convert.ChangeType(array, tType);
            }

            return default(T);
        }

        public static T GetNestedProperty<T>(this PSObject psObject, params string[] names) => psObject.Properties.GetNestedProperty<T>(names);

        public static T GetNestedProperty<T>(this PSMemberInfoCollection<PSPropertyInfo> properties, params string[] names)
        {
            var lastName = names.Last();
            var nestedProperties = names.Take(names.Length - 1).Aggregate(properties, (p, n) => p?.GetProperty<PSObject>(n)?.Properties);
            return nestedProperties != null ? nestedProperties.GetProperty<T>(lastName) : default(T);
        }

        public static T GetProperty<T>(this PSObject psObject, string name) => psObject.Properties.GetProperty<T>(name);

        public static T GetProperty<T>(this PSMemberInfoCollection<PSPropertyInfo> properties, string name)
        {
            switch (properties[name]?.Value)
            {
                case PSObject psObject when psObject.BaseObject is PSCustomObject && psObject.ImmediateBaseObject.IsTypeOrArrayOfType<T>():
                    return psObject.ImmediateBaseObject.NormalizeArrayType<T>();
                case PSObject psObject when psObject.BaseObject.IsTypeOrArrayOfType<T>():
                    return psObject.BaseObject.NormalizeArrayType<T>();
                case object value when value.IsTypeOrArrayOfType<T>():
                    return value.NormalizeArrayType<T>();
                default:
                    return default(T);
            }
        }

        public static IEnumerable<T> RunScript<T>(this PSCmdlet cmdlet, string script)
            => PsHelpers.RunScript<T>(cmdlet.InvokeCommand, script);

        public static void RunScript(this PSCmdlet cmdlet, string script)
            => cmdlet.RunScript<PSObject>(script);

        public static IEnumerable<T> RunScript<T>(this EngineIntrinsics engineIntrinsics, string script)
            => PsHelpers.RunScript<T>(engineIntrinsics.InvokeCommand, script);

        public static void RunScript(this EngineIntrinsics engineIntrinsics, string script)
            => engineIntrinsics.RunScript<PSObject>(script);

        public static IEnumerable<T> RunScript<T>(this PSCmdlet cmdlet, ScriptBlock block)
            => PsHelpers.RunScript<T>(cmdlet.InvokeCommand, block.ToString());

        public static void RunScript(this PSCmdlet cmdlet, ScriptBlock block)
            => cmdlet.RunScript<PSObject>(block.ToString());

        public static IEnumerable<T> RunScript<T>(this EngineIntrinsics engineIntrinsics, ScriptBlock block)
            => PsHelpers.RunScript<T>(engineIntrinsics.InvokeCommand, block.ToString());

        public static void RunScript(this EngineIntrinsics engineIntrinsics, ScriptBlock block)
            => engineIntrinsics.RunScript<PSObject>(block.ToString());

        /// <summary>
        /// Returns if a parameter should be hidden by checking for <see cref="DoNotExportAttribute" />.
        /// </summary>
        /// <param name="parameter">A PowerShell parameter.</param>
        public static bool IsHidden(this Parameter parameter)
        {
            return parameter.Attributes.Any(attr => attr is DoNotExportAttribute);
        }
    }
}
