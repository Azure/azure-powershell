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

using Microsoft.Azure.ContainerRegistry.Models;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class PSTagAttributeBase
    {
        public PSTagAttributeBase()
        {
        }

        public PSTagAttributeBase(string name = default(string), string digest = default(string), string createdTime = default(string), string lastUpdateTime = default(string), bool? signed = default(bool?), ChangeableAttributes changeableAttributes = default(ChangeableAttributes))
        {
            Name = name;
            Digest = digest;
            CreatedTime = createdTime;
            LastUpdateTime = lastUpdateTime;
            Signed = signed;
            ChangeableAttributes = new PSChangeableAttribute(changeableAttributes);
        }

        public PSTagAttributeBase(TagAttributesBase attribute)
        {
            Name = attribute?.Name;
            Digest = attribute?.Digest;
            CreatedTime = attribute?.CreatedTime;
            LastUpdateTime = attribute?.LastUpdateTime;
            Signed = attribute?.Signed;
            if (attribute != null)
            {
                ChangeableAttributes = new PSChangeableAttribute(attribute.ChangeableAttributes);
            }
        }

        public TagAttributesBase GetAttribute()
        {
            return new TagAttributesBase
            {
                Name = this.Name,
                Digest = this.Digest,
                CreatedTime = this.CreatedTime,
                LastUpdateTime = this.LastUpdateTime,
                Signed = this.Signed,
                ChangeableAttributes = this.ChangeableAttributes.GetAttribute()
            };
        }

        public string Name { get; set; }

        public string Digest { get; set; }

        public string CreatedTime { get; set; }

        public string LastUpdateTime { get; set; }

        public bool? Signed { get; set; }

        public PSChangeableAttribute ChangeableAttributes { get; set; }
    }
}
