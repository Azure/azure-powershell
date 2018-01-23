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

namespace Microsoft.AzureStack.Commands.Common
{
    using System;
    using System.Linq;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Overrides the default CamelCase resolver to respect property name set in the <c>JsonPropertyAttribute</c>.
    /// </summary>
    internal class CamelCasePropertyNamesWithOverridesContractResolver : CamelCasePropertyNamesContractResolver
    {
        /// <summary>
        /// Creates dictionary contract
        /// </summary>
        /// <param name="objectType">The object type.</param>
        protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
        {
            ArgumentValidator.ValidateNotNull("objectType", objectType);

            var contract = base.CreateDictionaryContract(objectType);

            var attributes = objectType.GetCustomAttributes(attributeType: typeof(JsonPreserveCaseDictionaryAttribute), inherit: true);
            if (attributes.Any())
            {
                contract.PropertyNameResolver = propertyName => propertyName;
            }

            return contract;
        }
    }
}
