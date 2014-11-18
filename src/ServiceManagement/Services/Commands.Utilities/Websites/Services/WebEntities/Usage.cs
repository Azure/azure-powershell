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

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities
{
    /// <summary>
    /// Class that represents usage of the quota resource.
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class Usage
    {
        /// <summary>
        /// Name of the quota 
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Name of the quota resource
        /// </summary>
        [DataMember]
        public string ResourceName { get; set; }

        /// <summary>
        /// Units of measurement for the quota resource
        /// </summary>
        [DataMember]
        public string Unit { get; set; }

        /// <summary>
        /// The current value of the resource counter
        /// </summary>
        [DataMember]
        public long CurrentValue { get; set; }

        /// <summary>
        /// The resource limit
        /// </summary>
        [DataMember]
        public long Limit { get; set; }

        /// <summary>
        /// Next reset time for the resource counter
        /// </summary>
        [DataMember]
        public DateTime NextResetTime { get; set; }

        /// <summary>
        /// ComputeMode used for this usage
        /// </summary>
        [DataMember]
        public ComputeModeOptions? ComputeMode { get; set; }

        /// <summary>
        /// SiteMode used for this usage
        /// </summary>
        [DataMember]
        public string SiteMode { get; set; }

    }

    /// <summary>
    /// Collection of usage
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class Usages : List<Usage>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public Usages() { }

        /// <summary>
        /// Initialize from list
        /// </summary>
        /// <param name="plans"></param>
        public Usages(List<Usage> usages) : base(usages) { }
    }
}
