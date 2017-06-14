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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Json
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Overrides the default CamelCase resolver to respect property name set in the <c>JsonPropertyAttribute</c>.
    /// </summary>
    internal class CamelCasePropertyNamesWithOverridesContractResolver : CamelCasePropertyNamesContractResolver
    {
        /// <summary>
        /// Creates <c>JSON</c> property for the class member.
        /// </summary>
        /// <param name="member">The member to serialize.</param>
        /// <param name="memberSerialization">The type of member serialization.</param>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var result = base.CreateProperty(member, memberSerialization);

            var attributes = member.GetCustomAttributes(attributeType: typeof(JsonPropertyAttribute), inherit: true);
            if (attributes.Any())
            {
                var propertyName = attributes.Cast<JsonPropertyAttribute>().Single().PropertyName;
                if (!string.IsNullOrEmpty(propertyName))
                {
                    result.PropertyName = propertyName;
                }
            }

            return result;
        }

        /// <summary>
        /// Creates dictionary contract
        /// </summary>
        /// <param name="objectType">The object type.</param>
        protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
        {
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
