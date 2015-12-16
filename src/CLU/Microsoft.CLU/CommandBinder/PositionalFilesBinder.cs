using Microsoft.CLU.Common.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Management.Automation;

namespace Microsoft.CLU.CommandBinder
{
     /// <summary>
     /// Binder to bind parameters from positional files.
     /// </summary>
    internal class PositionalFilesBinder
    {
        /// <summary>
        /// Binds the parameters from positional file arguments.
        /// </summary>
        /// <param name="cmdletInstance">The cmdlet instance</param>
        /// <param name="dynamicParameterInstance">The dynamic parameter instance</param>
        /// <param name="staticBindState">The state of cmdlet parameter bind</param>
        /// <param name="dynamicBindState">The state of dynamic parameter bind</param>
        public static void Bind(Cmdlet cmdletInstance, object dynamicParameterInstance, ParameterBindState staticBindState, ParameterBindState dynamicBindState)
        {
            Debug.Assert(cmdletInstance != null);
            Debug.Assert(staticBindState != null);
            Debug.Assert(dynamicBindState != null);
            var positionalFilePaths = staticBindState.ReadFromPositionalFilesValues;
            if (positionalFilePaths.Count() == 0)
            {
                return;
            }

            foreach (var filePath in positionalFilePaths)
            {
                using (var reader = System.IO.File.OpenText(filePath))
                {
                    var jsonDocument = reader.ReadToEnd();
                    var jsonObject = JsonConvert.DeserializeObject(jsonDocument) as JObject;
                    // For invalid json objects such as e.g. primitive types, json records this deserialization will fail.
                    if (jsonObject == null)
                    {
                        // e.g. file contains array [] which is not an object from which we can take value using property name.
                        throw new ArgumentException(string.Format(Strings.PositionalFilesBinder_Bind_ParseFileAsJObjectFailed, filePath));
                    }

                    BindFromJObject(jsonObject, cmdletInstance, staticBindState.UnboundParameters, staticBindState.BoundParameterNames);
                    BindFromJObject(jsonObject, dynamicParameterInstance, dynamicBindState.UnboundParameters, dynamicBindState.BoundParameterNames);
                }
            }
        }

        /// <summary>
        /// Bind collection of parameters exists in the given instance from the JObject.
        /// Note: Similar to BindHandler, this method update ParameterBindState::BoundParameterNames
        /// with the name of parameters bounded successfully.
        /// </summary>
        /// <param name="jObject">The jObject with parameter values</param>
        /// <param name="instance">The instance in which parameters exists</param>
        /// <param name="parameters">The parameters to be bound (this will be the unbounded parameters in the instance)</param>
        /// <param name="boundParameterNames">The set to be updated with the names of parameters that this method bound</param>
        private static void BindFromJObject(JObject jObject, object instance, IEnumerable<ParameterMetadata> parameters, HashSet<string> boundParameterNames)
        {
            foreach (var parameter in parameters)
            {
                JToken jtoken;
                if (jObject.TryGetValue(parameter.Name, StringComparison.OrdinalIgnoreCase, out jtoken))
                {
                    boundParameterNames.Add(parameter.Name);
                    if (parameter.ParameterType.Equals(typeof(string)) || parameter.ParameterType.GetTypeInfo().IsEnum)
                    {
                        parameter.InterpretAndSetValue(instance, (string)jtoken);
                    }
                    else
                    {
                        parameter.InterpretAndSetValue(instance, jtoken.ToString(Formatting.None));
                    }
                }
            }
        }
    }
}
