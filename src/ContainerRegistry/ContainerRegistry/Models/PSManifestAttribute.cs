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
    public class PSManifestAttribute
    {
        public PSManifestAttribute(string registry = default(string), string imageName = default(string), PSManifestAttributeBase attributes = default(PSManifestAttributeBase))
        {
            Registry = registry;
            ImageName = imageName;
            Attributes = attributes;
        }

        public PSManifestAttribute(ManifestAttributes manifest)
        {
            Registry = manifest?.Registry;
            ImageName = manifest?.ImageName;
            if (manifest != null)
            {
                Attributes = new PSManifestAttributeBase(manifest.Attributes);
            }
        }

        public ManifestAttributes GetAttribute()
        {
            return new ManifestAttributes
            {
                Registry = this.Registry,
                ImageName = this.ImageName,
                Attributes = this.Attributes.GetAttribute()
            };
        }

        public string Registry { get; set; }

        public string ImageName { get; set; }

        public PSManifestAttributeBase Attributes { get; set; }
    }
}
