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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public abstract class PSSynapseTrackedResource : PSSynapseResource
    {
        public PSSynapseTrackedResource(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>))
            : base(id, name, type)
        {
            Tags = TagsConversionHelper.CreateTagHashtable(tags);
            Location = location;
        }

        /// <summary>
        /// Gets or sets resource tags.
        /// </summary>
        public Hashtable Tags { get; set; }

        public string TagsTable => ResourcesExtensions.ConstructTagsTable(Tags);

        /// <summary>
        /// Gets or sets the geo-location where the resource lives
        /// </summary>
        public string Location { get; set; }
    }
}
