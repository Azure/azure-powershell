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
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class PSRepositoryAttribute
    {
        public PSRepositoryAttribute(string registry = default(string), string imageName = default(string), string createdTime = default(string), string lastUpdateTime = default(string), int? manifestCount = default(int?), int? tagCount = default(int?), PSChangeableAttribute changeableAttributes = default(PSChangeableAttribute))
        {
            Registry = registry;
            ImageName = imageName;
            CreatedTime = createdTime;
            LastUpdateTime = lastUpdateTime;
            ManifestCount = manifestCount;
            TagCount = tagCount;
            ChangeableAttributes = changeableAttributes;
        }

        public PSRepositoryAttribute(RepositoryAttributes attribute)
        {
            Registry = attribute?.Registry;
            ImageName = attribute?.ImageName;
            CreatedTime = attribute?.CreatedTime;
            LastUpdateTime = attribute?.LastUpdateTime;
            ManifestCount = attribute?.ManifestCount;
            TagCount = attribute?.TagCount;
            ChangeableAttributes = new PSChangeableAttribute(attribute?.ChangeableAttributes);
        }

        public string Registry { get; set; }

        public string ImageName { get; set; }

        public string CreatedTime { get; set; }

        public string LastUpdateTime { get; set; }

        public int? ManifestCount { get; set; }

        public int? TagCount { get; set; }

        public PSChangeableAttribute ChangeableAttributes { get; set; }
    }
}
