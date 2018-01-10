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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies.Templates
{
    public static class TemplateExtensions
    {
        /// <summary>
        /// Create a template from the given resource dependency DAG.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="config">Resource configuration.</param>
        /// <param name="client">Generic REST API client.</param>
        /// <param name="target">Target models.</param>
        /// <param name="subscriptionId">subscription id</param>
        /// <returns></returns>
        public static Template CreateTemplate<TModel>(
            this ResourceConfig<TModel> config,
            IClient client,
            IState target,
            string subscriptionId)
            where TModel : class
        {
            var context = new Context(client, target, subscriptionId);
            context.CreateResource(config);
            return new Template
            {
                contentVersion = "1.0.0.0",
                resources = context.Map.Values.ToArray()
            };
        }

        sealed class Context
        {
            public IClient Client { get; }

            public IState Target { get; }

            public string SubscriptionId { get; }

            public ConcurrentDictionary<string, Resource> Map { get; }
                = new ConcurrentDictionary<string, Resource>();

            public Context(IClient client, IState target, string subscriptionId)
            {
                Client = client;
                Target = target;
                SubscriptionId = subscriptionId;
            }

            public void CreateResource<TModel>(ResourceConfig<TModel> config)
                where TModel : class
            {
                // ignore a resource group
                if (config.ResourceGroup != null)
                {
                    Map.GetOrAdd(
                        config.DefaultIdStr(),
                        _ =>
                        {
                            var dependencies = config.GetTargetDependencies(Target);
                            foreach (var d in dependencies)
                            {
                                d.Accept(new CreateResourceVisitor(), this);
                            }
                            var model = Target.Get(config);
                            var jsonModel = ObjectToWire(model);
                            return new Resource
                            {
                                name = config.Name,
                                type = config.Strategy.GetResourceType(),
                                apiVersion = config.Strategy.GetApiVersion(Client),
                                location = config.Strategy.GetLocation(model),
                                properties = jsonModel.GetOrNull(Properties)
                                    as Dictionary<string, object>,
                                dependsOn = dependencies
                                    .Where(d => d.ResourceGroup != null)
                                    .Select(d => d.GetIdStr())
                                    .ToArray()
                            };
                        });
                }
            }
        }

        const string Properties = "properties";

        const string PropertiesDot = Properties + ".";

        sealed class CreateResourceVisitor : IResourceConfigVisitor<Context, Void>
        {
            public Void Visit<TModel>(ResourceConfig<TModel> config, Context context)
                where TModel : class
            {
                context.CreateResource(config);
                return new Void();
            }
        }

        static object ToWire(object value)
        {
            if (value == null)
            {
                return null;
            }
            var type = value.GetType();
            if (type.IsPrimitive || type == typeof(string))
            {
                return value;
            }
            var dictionary = value as IDictionary;
            if (dictionary != null)
            {
                var result = new Dictionary<string, object>();
                foreach (DictionaryEntry p in dictionary)
                {
                    result[p.Key.ToString()] = ToWire(p.Value);
                }
                return result;
            }
            var array = value as IEnumerable;
            if (array != null)
            {
                var result = new List<object>();
                foreach (var x in array)
                {
                    result.Add(ToWire(x));
                }
                return result;
            }
            return ObjectToWire(value);
        }

        static Dictionary<string, object> ObjectToWire(object value)
        {
            var result = new Dictionary<string, object>();
            var properties = new Dictionary<string, object>();
            foreach (var p in value.GetType().GetProperties())
            {
                var pValue = ToWire(p.GetValue(value));
                if (pValue != null)
                {
                    var a = p
                        .GetCustomAttributes(typeof(JsonPropertyAttribute), true)
                        .OfType<JsonPropertyAttribute>()
                        .FirstOrDefault();
                    if (a != null)
                    {
                        var aName = a.PropertyName;
                        if (aName.StartsWith(PropertiesDot))
                        {
                            properties[aName.Substring(PropertiesDot.Length)] = pValue;
                        }
                        else
                        {
                            result[aName] = pValue;
                        }
                    }
                    else
                    {
                        result[p.Name] = pValue;
                    }
                }
            }
            if (properties.Count > 0)
            {
                result[Properties] = properties;
            }
            return result;
        }

        static object FromWire(Type type, JToken value)
        {
            if (value == null)
            {
                return null;
            }
            if (type.IsEnum)
            {   
                return Enum.Parse(type, value.Value<string>().Replace("_", string.Empty));
            }
            if (type.IsGenericType)
            {
                var genericType = type.GetGenericTypeDefinition();
                var genericArgument = type.GetGenericArguments()[0];
                if (genericType == typeof(Nullable<>))
                {
                    var x = FromWire(genericArgument, value);
                    return Activator.CreateInstance(type, x);
                }
                if (genericType == typeof(IList<>))
                {
                    var listType = typeof(List<>).MakeGenericType(genericArgument);
                    var result = Activator.CreateInstance(listType) as IList;
                    var array = value as JArray;
                    foreach (var item in array)
                    {
                        result.Add(FromWire(genericArgument, item));
                    }
                    return result;
                }
            }
            if (type == typeof(string))
            {
                return value.Value<string>();
            }
            if (type.IsPrimitive)
            {
                object vv = null;
                switch (value.Type)
                {
                    case JTokenType.Boolean:
                        vv = value.Value<bool>();
                        break;
                    case JTokenType.Float:
                        vv = value.Value<double>();
                        break;
                    default:
                        vv = value.Value<string>();
                        break;
                }
                if (vv == null)
                {
                    return null;
                }
                return vv.GetType() == type ? vv : Convert.ChangeType(vv, type);
            }
            return FromWireObject(type, value as JObject);
        }

        public static object FromWireObject(Type type, JObject wire)
        {
            if (wire == null)
            {
                return null;
            }
            var result = Activator.CreateInstance(type);
            var properties = wire[Properties] as JObject;
            foreach (var p in type.GetProperties())
            {
                var a = p
                    .GetCustomAttributes(typeof(JsonPropertyAttribute), true)
                    .OfType<JsonPropertyAttribute>()
                    .FirstOrDefault();
                JToken jResult = null;
                if (a != null)
                {
                    var aName = a.PropertyName;
                    if (aName.StartsWith(PropertiesDot))
                    {
                        var ppName = aName.Substring(PropertiesDot.Length);
                        if (properties != null)
                        {
                            jResult = properties[ppName];
                        }
                    }
                    else
                    {
                        jResult = wire[aName];
                    }
                }
                else
                {
                    jResult = wire[p.Name];
                }
                var pResult = FromWire(p.PropertyType, jResult);
                if (pResult != null)
                {
                    p.SetValue(result, pResult);
                }
            }
            return result;
        }

        public static T FromWireObject<T>(this JObject wire)
            where T : class, new()
            => FromWireObject(typeof(T), wire) as T;
    }
}
