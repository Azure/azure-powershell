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

using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Azure.Commands.Compute
{
    public abstract class VirtualMachineBaseCmdlet : ComputeClientBaseCmdlet
    {
        protected const InstanceViewTypes InstanceViewExpand = InstanceViewTypes.InstanceView;

        public IVirtualMachinesOperations VirtualMachineClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.VirtualMachines;
            }
        }

        public static string FormatObject(Object obj)
        {
            var objType = obj.GetType();

            System.Reflection.PropertyInfo[] pros = objType.GetProperties();
            bool expand = true;
            foreach (var p in pros)
            {
                if (p.Name.Equals("DisplayHint"))
                {
                    if (p.GetValue(obj, null).Equals(DisplayHintType.Compact))
                    {
                        expand = false;
                    }
                }
            }

            string result = "\n";
            var resultTuples = new List<Tuple<string, string, int>>();
            var totalTab = GetTabLength(obj, 0, 0, resultTuples, expand) + 1;
            foreach (var t in resultTuples)
            {
                string preTab = new string(' ', t.Item3 * 2);
                string postTab = new string(' ', totalTab - t.Item3 * 2 - t.Item1.Length);

                result += preTab + t.Item1 + postTab + ": " + t.Item2 + "\n";
            }
            return result;
        }

        private static int GetTabLength(Object obj, int max, int depth, List<Tuple<string, string, int>> tupleList, bool expand = true)
        {
            var objType = obj.GetType();
            var propertySet = new List<PropertyInfo>();
            if (objType.BaseType != null)
            {
                foreach (var property in objType.BaseType.GetProperties())
                {
                    if (!property.Name.Equals("RequestId") && !property.Name.Equals("StatusCode") && !property.Name.Equals("DisplayHint"))
                    {
                        propertySet.Add(property);
                    }
                }
            }
            foreach (var property in objType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public))
            {
                if (!property.Name.Equals("DisplayHint"))
                {
                    propertySet.Add(property);
                }
            }

            foreach (var property in propertySet)
            {
                Object childObject = property.GetValue(obj, null);

                var isJObject = childObject as JObject;
                if (isJObject != null)
                {
                    var objStringValue = JsonConvert.SerializeObject(childObject);

                    int i = objStringValue.IndexOf("xmlCfg");
                    if (i >= 0)
                    {
                        var xmlCfgString = objStringValue.Substring(i + 7);
                        int start = xmlCfgString.IndexOf('"');
                        int end = xmlCfgString.IndexOf('"', start + 1);
                        xmlCfgString = xmlCfgString.Substring(start + 1, end - start - 1);
                        objStringValue = objStringValue.Replace(xmlCfgString, "...");
                    }

                    tupleList.Add(MakeTuple(property.Name, objStringValue, depth));
                    max = Math.Max(max, depth * 2 + property.Name.Length);
                }
                else
                {
                    var elem = childObject as IList;
                    if (elem != null)
                    {
                        if (elem.Count != 0)
                        {
                            max = expand
                                ? Math.Max(max, depth * 2 + property.Name.Length + 4)
                                : Math.Max(max, depth * 2 + property.Name.Length);

                            var elementName = new List<string>();

                            for (int i = 0; i < elem.Count; i++)
                            {
                                Type propType = elem[i].GetType();

                                if (propType.IsSerializable)
                                {
                                    if (expand)
                                    {
                                        tupleList.Add(MakeTuple(property.Name + "[" + i + "]", elem[i].ToString(), depth));
                                    }
                                    else
                                    {
                                        elementName.Add(elem[i].ToString());
                                    }
                                }
                                else
                                {
                                    if (expand)
                                    {
                                        tupleList.Add(MakeTuple(property.Name + "[" + i + "]", "", depth));
                                        max = Math.Max(max, GetTabLength((Object)elem[i], max, depth + 1, tupleList));
                                    }
                                    else
                                    {
                                        elementName.Add(GetChildProperties((Object)elem[i], true));
                                    }
                                }
                            }

                            if (!expand)
                            {
                                tupleList.Add(MakeTuple(property.Name, "{" + string.Join(", ", elementName) + "}", depth));
                            }
                        }
                    }
                    else
                    {
                        if (property.PropertyType.IsSerializable)
                        {
                            if (childObject != null)
                            {
                                tupleList.Add(MakeTuple(property.Name, childObject.ToString(), depth));
                                max = Math.Max(max, depth * 2 + property.Name.Length);
                            }
                        }
                        else
                        {
                            var isDictionary = childObject as IDictionary;
                            if (isDictionary != null)
                            {
                                tupleList.Add(MakeTuple(property.Name, JsonConvert.SerializeObject(childObject), depth));
                                max = Math.Max(max, depth * 2 + property.Name.Length);
                            }
                            else if (childObject != null)
                            {
                                if (expand)
                                {
                                    tupleList.Add(MakeTuple(property.Name, "", depth));
                                    max = Math.Max(max, GetTabLength(childObject, max, depth + 1, tupleList));
                                }
                                else
                                {
                                    tupleList.Add(MakeTuple(property.Name, GetChildProperties(childObject), depth));
                                    max = Math.Max(max, property.Name.Length);
                                }
                            }
                        }
                    }
                }
            }
            return max;
        }

        private static string GetChildProperties(Object obj, bool getOnlyName = false)
        {
            var objType = obj.GetType();
            var propertySet = new List<PropertyInfo>();

            if (objType.BaseType != null)
            {
                foreach (var property in objType.BaseType.GetProperties())
                {
                    propertySet.Add(property);
                }
            }
            foreach (var property in objType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public))
            {
                propertySet.Add(property);
            }

            var propertyList = new List<string>();
            foreach (var property in propertySet)
            {
                Object childObject = property.GetValue(obj, null);

                if (childObject != null)
                {
                    if (getOnlyName)
                    {
                        if (property.Name.Equals("Name"))
                        {
                            return childObject.ToString();
                        }
                    }
                    else
                    {
                        propertyList.Add(property.Name);
                    }
                }
            }

            return (getOnlyName)
                ? " "
                : "{" + string.Join(", ", propertyList) + "}";
        }

        private static Tuple<string, string, int> MakeTuple(string key, string value, int depth)
        {
            return new Tuple<string, string, int>(key, value, depth);
        }

    }
}
