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

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities
{
    /// <summary>
    /// Class that represents a hosting Plan.
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class Plan
    {
        /// <summary>
        /// Name for the plan
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The description for the plan
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Is the plan active
        /// </summary>
        [DataMember]
        public bool? Active { get; set; }
    }

    /// <summary>
    /// Collection of plans
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class Plans : List<Plan>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public Plans() { }

        /// <summary>
        /// Initialize from list
        /// </summary>
        /// <param name="plans"></param>
        public Plans(List<Plan> plans) : base(plans) { }
    }
}
