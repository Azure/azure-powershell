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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class PSManifestAttributeBase
    {
        public PSManifestAttributeBase(string digest = default(string), long? imageSize = default(long?), string createdTime = default(string), string lastUpdateTime = default(string), string architecture = default(string), string os = default(string), string mediaType = default(string), string configMediaType = default(string), IList<string> tags = default(IList<string>), PSChangeableAttribute changeableAttributes = default(PSChangeableAttribute))
        {
            Digest = digest;
            ImageSize = imageSize;
            CreatedTime = createdTime;
            LastUpdateTime = lastUpdateTime;
            Architecture = architecture;
            Os = os;
            MediaType = mediaType;
            ConfigMediaType = configMediaType;
            Tags = tags;
            ChangeableAttributes = changeableAttributes;
        }

        public PSManifestAttributeBase(ManifestAttributesBase attribute)
        {
            Digest = attribute?.Digest;
            ImageSize = attribute?.ImageSize;
            CreatedTime = attribute?.CreatedTime;
            LastUpdateTime = attribute?.LastUpdateTime;
            Architecture = attribute?.Architecture;
            Os = attribute?.Os;
            MediaType = attribute?.MediaType;
            ConfigMediaType = attribute?.ConfigMediaType;
            Tags = attribute?.Tags;
            if (attribute != null)
            {
                ChangeableAttributes = new PSChangeableAttribute(attribute.ChangeableAttributes);
            }
        }

        public ManifestAttributesBase GetAttribute()
        {
            return new ManifestAttributesBase
            {
                Digest = this.Digest,
                ImageSize = this.ImageSize,
                CreatedTime = this.CreatedTime,
                LastUpdateTime = this.LastUpdateTime,
                Architecture = this.Architecture,
                Os = this.Os,
                MediaType = this.MediaType,
                ConfigMediaType = this.ConfigMediaType,
                Tags = this.Tags,
                ChangeableAttributes = this.ChangeableAttributes.GetAttribute()
            };
        }
        
        public string Digest { get; set; }

        public long? ImageSize { get; set; }

        public string CreatedTime { get; set; }

        public string LastUpdateTime { get; set; }

        public string Architecture { get; set; }

        public string Os { get; set; }

        public string MediaType { get; set; }

        public string ConfigMediaType { get; set; }

        public IList<string> Tags { get; set; }

        public PSChangeableAttribute ChangeableAttributes { get; set; }
    }
}
