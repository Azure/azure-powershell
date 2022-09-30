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
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Reflection;

namespace VersionController.Models
{
    class VersionMetadataContractResolver : DefaultContractResolver
    {
        public static readonly VersionMetadataContractResolver Instance = new VersionMetadataContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (property.PropertyType.GetInterface(nameof(ICollection)) != null)
            {
                property.ShouldSerialize =
                instance =>
                {
                    var obj = instance?.GetType().GetProperty(property.PropertyName).GetValue(instance) as ICollection;
                    return obj.Count > 0;
                };
            }
            return property;
        }
    }
}
