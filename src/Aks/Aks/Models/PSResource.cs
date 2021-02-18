<<<<<<< HEAD
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Aks.Models
{
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;
=======
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

namespace Microsoft.Azure.Commands.Aks.Models
{
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    using System.Collections.Generic;

    /// <summary>
    /// The Resource model definition.
    /// </summary>
    public partial class PSResource
    {
        /// <summary>
        /// Initializes a new instance of the Resource class.
        /// </summary>
        public PSResource(){}

        /// <summary>
        /// Initializes a new instance of the Resource class.
        /// </summary>
        /// <param name="location">Resource location</param>
        /// <param name="id">Resource Id</param>
        /// <param name="name">Resource name</param>
        /// <param name="type">Resource type</param>
        /// <param name="tags">Resource tags</param>
        public PSResource(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>))
        {
            Id = id;
            Name = name;
            Type = type;
            Location = location;
            Tags = tags;
        }

        /// <summary>
        /// Gets resource Id
        /// </summary>
<<<<<<< HEAD
        [JsonProperty(PropertyName = "id")]
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public string Id { get; private set; }

        /// <summary>
        /// Gets resource name
        /// </summary>
<<<<<<< HEAD
        [JsonProperty(PropertyName = "name")]
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public string Name { get; private set; }

        /// <summary>
        /// Gets resource type
        /// </summary>
<<<<<<< HEAD
        [JsonProperty(PropertyName = "type")]
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public string Type { get; private set; }

        /// <summary>
        /// Gets or sets resource location
        /// </summary>
<<<<<<< HEAD
        [JsonProperty(PropertyName = "location")]
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets resource tags
        /// </summary>
<<<<<<< HEAD
        [JsonProperty(PropertyName = "tags")]
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public IDictionary<string, string> Tags { get; set; }
    }
}