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
    public class PSTagAttribute
    {
        public PSTagAttribute()
        {
        }

        public PSTagAttribute(string registry = default(string), string imageName = default(string), PSTagAttributeBase attributes = default(PSTagAttributeBase))
        {
            Registry = registry;
            ImageName = imageName;
            Attributes = attributes;
        }

        public PSTagAttribute(TagAttributes attribute)
        {
            Registry = attribute?.Registry;
            ImageName = attribute?.ImageName;
            if (attribute != null)
            {
                Attributes = new PSTagAttributeBase(attribute.Attributes);
            }
        }

        public TagAttributes GetAttribute()
        {
            return new TagAttributes
            {
                Registry = this.Registry,
                ImageName = this.ImageName,
                Attributes = this.Attributes.GetAttribute()
            };
        }

        public string Registry { get; set; }

        public string ImageName { get; set; }

        public PSTagAttributeBase Attributes { get; set; }
    }
}