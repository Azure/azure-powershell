using Microsoft.Azure.Management.WebSites.Version2016_09_01.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Reflection;
using System.Globalization;
using System.Collections;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
using YamlDotNet.Core.Tokens;
using System.Management.Automation;
using AutoMapper.Configuration.Conventions;
// using YamlDotNet.Core.Tokens;

namespace Microsoft.Azure.Commands.Aks.Models
{
    class AdapterHelper<Source, Target>
    {
        public static Target AdaptList(Source source)
        {
            IList list = (IList)source;
            //value = list[0];
            //List<myChangeType.GetProperties()[2].PropertyType.GetGenericArguments()[0])> a;
            Type t = typeof(Target).GetProperties()[0].PropertyType;
            var tList = typeof(List<>).MakeGenericType(t);
            var m = Activator.CreateInstance(tList);
            var madd = tList.GetMethod("Add");
            var typeInner = typeof(AdapterHelper<,>).MakeGenericType(list.GetType().GetProperties()[2].PropertyType, t);
            var a = Activator.CreateInstance(typeInner, null);
            foreach (var ind in list)
            {
                var method = typeInner.GetMethod("Adapt");
                var tind = method.Invoke(a, BindingFlags.Static, new MyBinder(), new object[] { ind }, CultureInfo.CurrentCulture);
                madd.Invoke(m, new object[] { tind });
                //var tind = a.Adapt(ind);
            }
            return (Target)m;
        }
        public static Target AdaptDict(Source source)
        {
            IDictionary list = (IDictionary)source;
            if (list.Count == 0)
            {
                return default(Target);
            }
            // Target Types
            Type targetKeyType = typeof(Target).GetProperty("Keys").PropertyType.GetGenericArguments()[0];
            Type targetValueType = typeof(Target).GetProperty("Values").PropertyType.GetGenericArguments()[0];
            var tList = typeof(Dictionary<,>).MakeGenericType(targetKeyType, targetValueType);

            // Source Types
            Type sourceKeyType = typeof(Source).GetProperty("Keys").PropertyType.GetGenericArguments()[0];
            Type sourceValueType = typeof(Source).GetProperty("Values").PropertyType.GetGenericArguments()[0];


            object m = Activator.CreateInstance(tList);
            MethodInfo madd = tList.GetMethod("Add");
            Type keyAdpaterType = typeof(AdapterHelper<,>).MakeGenericType(sourceKeyType, targetKeyType);
            Type valueAdpaterType = typeof(AdapterHelper<,>).MakeGenericType(sourceValueType, targetValueType);
            var keyAdapter = Activator.CreateInstance(keyAdpaterType, null);
            var valueAdapter = Activator.CreateInstance(valueAdpaterType, null);
            foreach (var key in list.Keys)
            {
                var value = list[key];
                var keyMethod = keyAdpaterType.GetMethod("Adapt");
                var valueMethod = valueAdpaterType.GetMethod("Adapt");
                
                var tKey = keyMethod.Invoke(keyAdapter, BindingFlags.Static, new MyBinder(), new object[] { key }, CultureInfo.CurrentCulture);
                var tValue = valueMethod.Invoke(valueAdapter, BindingFlags.Static, new MyBinder(), new object[] { value }, CultureInfo.CurrentCulture);
                
                madd.Invoke(m, new object[] { tKey, tValue });
                //var tind = a.Adapt(ind);
            }
            return (Target)m;
        }
        public static Target Adapt(Source source)
        {
            /*
            if(source is IList)
            {
                foreach(var s in source)
                {

                }
            }*/
            if (typeof(Target).Equals(typeof(Source)))
            { 
                return (Target)Convert.ChangeType(source, typeof(Target));
            }
            
            Target targetItem = (Target)FormatterServices.GetUninitializedObject(typeof(Target));
            // Target targetItem = Activator.CreateInstance<Target>();
            var sourceProps = typeof(Source).GetProperties();
            var targetProps = typeof(Target).GetProperties();
            foreach (var sourceProp in sourceProps)
            {
                var sourceType = sourceProp.GetType();
                foreach (var targetProp in targetProps)
                {
                    //var targetType = targetProp.GetType();
                    
                    if (sourceProp.Name == targetProp.Name)
                    {
                        if (targetProp.PropertyType != sourceProp.PropertyType && sourceProp.GetValue(source) != null)
                        {
                            var fix = targetProp;
                            var type = typeof(AdapterHelper<,>).MakeGenericType(sourceProp.PropertyType, targetProp.PropertyType);
                            var a = Activator.CreateInstance(type, null);
                            //var sourceProp2 = a.Ada
                            MethodInfo method;
                            /*
                            Type t = dict.GetType();
                            bool isDict = t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>);
                             */
                            if (sourceProp.GetValue(source) is IList)
                            {

                                method = type.GetMethod("AdaptList");
                                // var obj2 = method.Invoke(a, BindingFlags.Static, new MyBinder(), new object[] { sourceProp.GetValue(source) }, CultureInfo.CurrentCulture);
                            }
                            else if (sourceProp.GetValue(source) is IDictionary)
                            {
                                method = type.GetMethod("AdaptDict");
                            }
                            else
                            {
                                method = type.GetMethod("Adapt");
                            }
                            
                            var obj = method.Invoke(a, BindingFlags.Static| BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, new MyBinder(), new object[] { sourceProp.GetValue(source) }, CultureInfo.CurrentCulture);
                            //fix = Convert.ChangeType(fix, obj); 
                            // MakeGenericMethod(sourceProp.PropertyType).
                            // var sourceProp2 = a.Adapt(sourceProp);
                            if (targetProp.CanWrite)
                            {
                                fix.SetValue(targetItem, obj);//sourceProp.GetValue(source));
                            }
                            else
                            {
                                try
                                {
                                    targetItem.GetType().InvokeMember(fix.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance, null, targetItem, new object[] { obj });
                                }
                                catch(Exception)
                                {
                                    targetItem.GetType().BaseType.InvokeMember(fix.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance, null, targetItem, new object[] { obj });
                                }
                                
                            }
                            // targetProp.SetValue(targetItem, sourceProp2);
                        }
                        else
                        {
                            //targetProp.SetValue(targetItem, sourceProp);
                            //targetProp.SetValue(targetItem, sourceProp.GetValue(source));
                            
                            if (targetProp.CanWrite)
                            {
                                targetProp.SetValue(targetItem, sourceProp.GetValue(source));//.GetValue(source));
                            }
                            else
                            {
                                targetItem.GetType().BaseType.InvokeMember(targetProp.Name, BindingFlags.Public| BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance, null, targetItem, new object[] { sourceProp.GetValue(source) });
                            }
                            

                        } 
                    }
                }
            }
            return targetItem;
        }
    }
    public class MyBinder : Binder
    {
        public MyBinder() : base()
        {
        }
        private class BinderState
        {
            public object[] args;
        }
        public override FieldInfo BindToField(
            BindingFlags bindingAttr,
            FieldInfo[] match,
            object value,
            CultureInfo culture
            )
        {
            if (match == null)
                throw new ArgumentNullException("match");
            // Get a field for which the value parameter can be converted to the specified field type.
            for (int i = 0; i < match.Length; i++)
                if (ChangeType(value, match[i].FieldType, culture) != null)
                    return match[i];
            return null;
        }
        public override MethodBase BindToMethod(
            BindingFlags bindingAttr,
            MethodBase[] match,
            ref object[] args,
            ParameterModifier[] modifiers,
            CultureInfo culture,
            string[] names,
            out object state
            )
        {
            // Store the arguments to the method in a state object.
            BinderState myBinderState = new BinderState();
            object[] arguments = new Object[args.Length];
            args.CopyTo(arguments, 0);
            myBinderState.args = arguments;
            state = myBinderState;
            if (match == null)
                throw new ArgumentNullException();
            // Find a method that has the same parameters as those of the args parameter.
            for (int i = 0; i < match.Length; i++)
            {
                // Count the number of parameters that match.
                int count = 0;
                ParameterInfo[] parameters = match[i].GetParameters();
                // Go on to the next method if the number of parameters do not match.
                if (args.Length != parameters.Length)
                    continue;
                // Match each of the parameters that the user expects the method to have.
                for (int j = 0; j < args.Length; j++)
                {
                    // If the names parameter is not null, then reorder args.
                    if (names != null)
                    {
                        if (names.Length != args.Length)
                            throw new ArgumentException("names and args must have the same number of elements.");
                        for (int k = 0; k < names.Length; k++)
                            if (String.Compare(parameters[j].Name, names[k].ToString()) == 0)
                                args[j] = myBinderState.args[k];
                    }
                    // Determine whether the types specified by the user can be converted to the parameter type.
                    if (ChangeType(args[j], parameters[j].ParameterType, culture) != null)
                        count += 1;
                    else
                        break;
                }
                // Determine whether the method has been found.
                if (count == args.Length)
                    return match[i];
            }
            return null;
        }
        public override object ChangeType(
            dynamic value,
            Type myChangeType,
            CultureInfo culture
            )
        {
            
            if(value.GetType().GetGenericTypeDefinition() == typeof(List<>))
            {
                IList list = (IList)value;
                //value = list[0];
                //List<myChangeType.GetProperties()[2].PropertyType.GetGenericArguments()[0])> a;
                Type t = myChangeType.GetProperties()[2].PropertyType.GetGenericArguments()[0];
                var myList = typeof(IList<>).MakeGenericType(t);
                var m = Activator.CreateInstance(myList, null);
                foreach (var ind in list)
                {
                    var addMethod = myList.GetMethod("Add");
                    if (CanConvertFrom(ind.GetType(), myChangeType.GetProperties()[2].PropertyType.GetGenericArguments()[0]))
                    {
                        addMethod.Invoke(m, new object[] { ind });
                    }
                }
                return (IList)m;
            }
            // Determine whether the value parameter can be converted to a value of type myType.
            if (CanConvertFrom(value.GetType(), myChangeType))
                // Return the converted object.
                return Convert.ChangeType(value, myChangeType);
            else
                // Return null.
                return null;
        }
        public override void ReorderArgumentArray(
            ref object[] args,
            object state
            )
        {
            // Return the args that had been reordered by BindToMethod.
            ((BinderState)state).args.CopyTo(args, 0);
        }
        public override MethodBase SelectMethod(
            BindingFlags bindingAttr,
            MethodBase[] match,
            Type[] types,
            ParameterModifier[] modifiers
            )
        {
            if (match == null)
                throw new ArgumentNullException("match");
            for (int i = 0; i < match.Length; i++)
            {
                // Count the number of parameters that match.
                int count = 0;
                ParameterInfo[] parameters = match[i].GetParameters();
                // Go on to the next method if the number of parameters do not match.
                if (types.Length != parameters.Length)
                    continue;
                // Match each of the parameters that the user expects the method to have.
                for (int j = 0; j < types.Length; j++)
                    // Determine whether the types specified by the user can be converted to parameter type.
                    if (CanConvertFrom(types[j], parameters[j].ParameterType))
                        count += 1;
                    else
                        break;
                // Determine whether the method has been found.
                if (count == types.Length)
                    return match[i];
            }
            return null;
        }
        public override PropertyInfo SelectProperty(
            BindingFlags bindingAttr,
            PropertyInfo[] match,
            Type returnType,
            Type[] indexes,
            ParameterModifier[] modifiers
            )
        {
            if (match == null)
                throw new ArgumentNullException("match");
            for (int i = 0; i < match.Length; i++)
            {
                // Count the number of indexes that match.
                int count = 0;
                ParameterInfo[] parameters = match[i].GetIndexParameters();
                // Go on to the next property if the number of indexes do not match.
                if (indexes.Length != parameters.Length)
                    continue;
                // Match each of the indexes that the user expects the property to have.
                for (int j = 0; j < indexes.Length; j++)
                    // Determine whether the types specified by the user can be converted to index type.
                    if (CanConvertFrom(indexes[j], parameters[j].ParameterType))
                        count += 1;
                    else
                        break;
                // Determine whether the property has been found.
                if (count == indexes.Length)
                    // Determine whether the return type can be converted to the properties type.
                    if (CanConvertFrom(returnType, match[i].PropertyType))
                        return match[i];
                    else
                        continue;
            }
            return null;
        }
        // Determines whether type1 can be converted to type2. Check only for primitive types.
        private bool CanConvertFrom(Type type1, Type type2)
        {
            if (true)//type1.IsPrimitive && type2.IsPrimitive)
            {
                TypeCode typeCode1 = Type.GetTypeCode(type1);
                TypeCode typeCode2 = Type.GetTypeCode(type2);
                // If both type1 and type2 have the same type, return true.
                if (typeCode1 == typeCode2)
                    return true;
                // Possible conversions from Char follow.
                if (typeCode1 == TypeCode.Char)
                    switch (typeCode2)
                    {
                        case TypeCode.UInt16: return true;
                        case TypeCode.UInt32: return true;
                        case TypeCode.Int32: return true;
                        case TypeCode.UInt64: return true;
                        case TypeCode.Int64: return true;
                        case TypeCode.Single: return true;
                        case TypeCode.Double: return true;
                        default: return false;
                    }
                // Possible conversions from Byte follow.
                if (typeCode1 == TypeCode.Byte)
                    switch (typeCode2)
                    {
                        case TypeCode.Char: return true;
                        case TypeCode.UInt16: return true;
                        case TypeCode.Int16: return true;
                        case TypeCode.UInt32: return true;
                        case TypeCode.Int32: return true;
                        case TypeCode.UInt64: return true;
                        case TypeCode.Int64: return true;
                        case TypeCode.Single: return true;
                        case TypeCode.Double: return true;
                        default: return false;
                    }
                // Possible conversions from SByte follow.
                if (typeCode1 == TypeCode.SByte)
                    switch (typeCode2)
                    {
                        case TypeCode.Int16: return true;
                        case TypeCode.Int32: return true;
                        case TypeCode.Int64: return true;
                        case TypeCode.Single: return true;
                        case TypeCode.Double: return true;
                        default: return false;
                    }
                // Possible conversions from UInt16 follow.
                if (typeCode1 == TypeCode.UInt16)
                    switch (typeCode2)
                    {
                        case TypeCode.UInt32: return true;
                        case TypeCode.Int32: return true;
                        case TypeCode.UInt64: return true;
                        case TypeCode.Int64: return true;
                        case TypeCode.Single: return true;
                        case TypeCode.Double: return true;
                        default: return false;
                    }
                // Possible conversions from Int16 follow.
                if (typeCode1 == TypeCode.Int16)
                    switch (typeCode2)
                    {
                        case TypeCode.Int32: return true;
                        case TypeCode.Int64: return true;
                        case TypeCode.Single: return true;
                        case TypeCode.Double: return true;
                        default: return false;
                    }
                // Possible conversions from UInt32 follow.
                if (typeCode1 == TypeCode.UInt32)
                    switch (typeCode2)
                    {
                        case TypeCode.UInt64: return true;
                        case TypeCode.Int64: return true;
                        case TypeCode.Single: return true;
                        case TypeCode.Double: return true;
                        default: return false;
                    }
                // Possible conversions from Int32 follow.
                if (typeCode1 == TypeCode.Int32)
                    switch (typeCode2)
                    {
                        case TypeCode.Int64: return true;
                        case TypeCode.Single: return true;
                        case TypeCode.Double: return true;
                        default: return false;
                    }
                // Possible conversions from UInt64 follow.
                if (typeCode1 == TypeCode.UInt64)
                    switch (typeCode2)
                    {
                        case TypeCode.Single: return true;
                        case TypeCode.Double: return true;
                        default: return false;
                    }
                // Possible conversions from Int64 follow.
                if (typeCode1 == TypeCode.Int64)
                    switch (typeCode2)
                    {
                        case TypeCode.Single: return true;
                        case TypeCode.Double: return true;
                        default: return false;
                    }
                // Possible conversions from Single follow.
                if (typeCode1 == TypeCode.Single)
                    switch (typeCode2)
                    {
                        case TypeCode.Double: return true;
                        default: return false;
                    }
            }
            return false;
        }
    }
}
