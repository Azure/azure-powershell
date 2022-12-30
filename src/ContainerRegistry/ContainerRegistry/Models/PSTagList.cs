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

using Azure.Containers.ContainerRegistry;
using Azure;
using Microsoft.Azure.ContainerRegistry.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Common.Compute.Version2016_04_preview.Models;
using System.Collections;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class PSTagList
    {
        public PSTagList()
        {
        }

        public  PSTagList(Pageable<ArtifactManifestProperties> properties)
        {
            this.Tags = new List<PSTagAttributeBase>();
            foreach (ArtifactManifestProperties property in properties)
            {
                foreach (string tag in property.Tags)
                {
                    PSTagAttributeBase newTag = new PSTagAttributeBase(tag, property.Digest, property.CreatedOn.ToString(), property.LastUpdatedOn.ToString(),null ,new ChangeableAttributes(property.CanDelete, property.CanWrite, property.CanList, property.CanRead));
                    Tags.Add(newTag);
                }
                this.ImageName = property.RepositoryName;
                this.Registry = property.RegistryLoginServer;
            }
        }
        public PSTagList(string registry = default(string), string imageName = default(string), IList<PSTagAttributeBase> tags = default(IList<PSTagAttributeBase>))
        {
            Registry = registry;
            ImageName = imageName;
            Tags = tags;
        }

        public PSTagList(TagList tag)
        {
            Registry = tag?.Registry;
            ImageName = tag?.ImageName;
            if (tag != null && tag.Tags != null)
            {
                Tags = tag.Tags.Select(x => new PSTagAttributeBase(x)).ToList();
            }
        }

        public TagList GetAttribute()
        {
            return new TagList
            {
                Registry = this.Registry,
                ImageName = this.ImageName,
                Tags = this.Tags.Select(x => x.GetAttribute()).ToList()
            };
        }

        public string Registry { get; set; }

        public string ImageName { get; set; }

        public IList<PSTagAttributeBase> Tags { get; set; }

    }
}
