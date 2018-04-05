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

using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies.Templates
{
    /// <summary>
    /// Template resource (JSON object).
    /// https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-manager-templates-resources
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// API version for creating the resource
        /// </summary>
        public string apiVersion { get; set; }

        /// <summary>
        /// Resource type. For example 'Microsot.Storage/storageAccounts'
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Name of resource.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Resource location.
        /// </summary>
        public string location { get; set; }

        public Dictionary<string, object> sku { get; set; }

        /// <summary>
        /// Resource properties.
        /// </summary>
        public JObject properties { get; set; }

        /// <summary>
        /// A list of resource which has to be created first.
        /// </summary>
        public string[] dependsOn { get; set; }
    }
}
