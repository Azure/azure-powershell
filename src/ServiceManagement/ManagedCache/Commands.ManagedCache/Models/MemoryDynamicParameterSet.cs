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

namespace Microsoft.Azure.Commands.ManagedCache.Models
{
    using System.Management.Automation;
    using Microsoft.Azure.Management.ManagedCache.Models;

    class MemoryDynamicParameterSet
    {
        private readonly RuntimeDefinedParameterDictionary _parameters = new RuntimeDefinedParameterDictionary();
        private const string MemoryParameterName = "Memory";

        public object GetDynamicParameters(CacheServiceSkuType sku)
        {
            RuntimeDefinedParameter memoryParameter = CreateCacheMemoryDynamicParameter(sku);
            _parameters[MemoryParameterName] = memoryParameter;
            return _parameters;
        }

        public string GetMemoryValue(CacheServiceSkuType sku)
        {
            RuntimeDefinedParameter memoryParameter;
            string memory = string.Empty;
            if (_parameters.TryGetValue(MemoryParameterName, out memoryParameter))
            {
                if (memoryParameter != null && memoryParameter.Value != null)
                {
                    memory = memoryParameter.Value.ToString();
                }
            }

            if (string.IsNullOrEmpty(memory))
            {
                memory = new CacheSkuCountConvert(sku).ToMemorySize(1);
            }
            return memory;
        }

        private RuntimeDefinedParameter CreateCacheMemoryDynamicParameter(CacheServiceSkuType sku)
        {
            var parameter = new RuntimeDefinedParameter
            {
                Name = MemoryParameterName,
                ParameterType = typeof(string),
            };

            // add the [parameter] attribute  
            var parameterAttribute = new ParameterAttribute
            {
                Mandatory = false,
            };

            parameter.Attributes.Add(parameterAttribute);

            string[] values = (new CacheSkuCountConvert(sku)).GetValueList();
            parameter.Attributes.Add(new ValidateSetAttribute(values)
            {
                IgnoreCase = true
            });

            return parameter;
        }

    }
}