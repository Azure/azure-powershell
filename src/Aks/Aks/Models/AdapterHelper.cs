// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Reflection;
using System.Globalization;
using System.Collections;

namespace Microsoft.Azure.Commands.Aks.Models
{
    class AdapterHelper<Source, Target>
    {
        public static Target Adapt(Source source)
        {
            if (typeof(Target).Equals(typeof(Source)))
            {
                return (Target)Convert.ChangeType(source, typeof(Target));
            }

            Target targetItem = (Target)FormatterServices.GetUninitializedObject(typeof(Target));
            var sourceProps = typeof(Source).GetProperties();
            var targetProps = typeof(Target).GetProperties();
            foreach (var sourceProp in sourceProps)
            {
                var sourceType = sourceProp.GetType();
                foreach (var targetProp in targetProps)
                {

                    if (sourceProp.Name.ToLower() == targetProp.Name.ToLower())
                    {
                        object result;
                        result = sourceProp.GetValue(source);
                        if (targetProp.PropertyType != sourceProp.PropertyType && sourceProp.GetValue(source) != null)
                        {
                            Type type = typeof(AdapterHelper<,>).MakeGenericType(sourceProp.PropertyType, targetProp.PropertyType);
                            var adapter = Activator.CreateInstance(type, null);

                            MethodInfo method;

                            if (sourceProp.GetValue(source) is IList)
                                method = type.GetMethod("AdaptList");
                            else if (sourceProp.GetValue(source) is IDictionary)
                                method = type.GetMethod("AdaptDict");
                            else if (sourceProp.GetValue(source).GetType().IsEnum)
                                method = type.GetMethod("AdaptEnum");
                            else
                                method = type.GetMethod("Adapt");

                            result = method.Invoke(adapter,
                                BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                                new PSBinder(),
                                new object[] { sourceProp.GetValue(source) },
                                CultureInfo.CurrentCulture);
                        }
                        if (targetProp.CanWrite)
                        {
                            targetProp.SetValue(targetItem, result);
                        }
                        else
                        {
                            Type TargetType = targetItem.GetType();

                            do
                            {
                                if (TargetType.GetProperty(targetProp.Name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).GetSetMethod(true) != null)
                                {
                                    TargetType.InvokeMember(targetProp.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance, null, targetItem, new object[] { result });
                                    break;
                                }
                                else
                                {
                                    TargetType = TargetType.BaseType;
                                }
                            } while (!(TargetType.BaseType is null));
                        }
                    }
                }
            }
            return targetItem;
        }
        public static Target AdaptList(Source source)
        {
            // Convert source to List for further iteration 
            IList sourceList = (IList)source;
            if (sourceList.Count == 0)
            {
                return default(Target);
            }
            Type nestedSourceType = typeof(Source).GetProperty("Item").PropertyType;

            Type nestedTargetType = typeof(Target).GetProperty("Item").PropertyType;
            Type nestedTargetTypeList = typeof(List<>).MakeGenericType(nestedTargetType);
            var targetListInstance = Activator.CreateInstance(nestedTargetTypeList);
            MethodInfo madd = nestedTargetTypeList.GetMethod("Add");

            Type adaptListType = typeof(AdapterHelper<,>).MakeGenericType(nestedSourceType, nestedTargetType);
            var adaptList = Activator.CreateInstance(adaptListType, null);
            foreach (var ind in sourceList)
            {
                MethodInfo method = adaptListType.GetMethod("Adapt");
                var tind = method.Invoke(adaptList, BindingFlags.Static, new PSBinder(), new object[] { ind }, CultureInfo.CurrentCulture);
                madd.Invoke(targetListInstance, new object[] { tind });
            }
            return (Target)targetListInstance;
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
                MethodInfo keyMethod = keyAdpaterType.GetMethod("Adapt");
                MethodInfo valueMethod = valueAdpaterType.GetMethod("Adapt");
                
                var tKey = keyMethod.Invoke(keyAdapter, BindingFlags.Static, new PSBinder(), new object[] { key }, CultureInfo.CurrentCulture);
                var tValue = valueMethod.Invoke(valueAdapter, BindingFlags.Static, new PSBinder(), new object[] { value }, CultureInfo.CurrentCulture);
                
                madd.Invoke(m, new object[] { tKey, tValue });
            }
            return (Target)m;
        }
        public static Target AdaptEnum(Source source)
        {
            Target targetEnum = (Target)FormatterServices.GetUninitializedObject(typeof(Target));
            foreach (var ind in Enum.GetValues(targetEnum.GetType()))
            {
                if (ind.ToString() == Convert.ToString(source))
                {
                    targetEnum = (Target)ind;
                    break;
                }
            }
            return targetEnum;
        }
    }
}
