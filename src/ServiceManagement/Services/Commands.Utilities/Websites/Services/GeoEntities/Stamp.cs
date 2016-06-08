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
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.GeoEntities
{
    [DataContract(Name = "StampState", Namespace = UriElements.ServiceNamespace)]
    public enum StampState
    {
        [EnumMember]
        Online = 0,
        [EnumMember]
        Full = 1,
        [EnumMember]
        Unhealthy = 2,
        [EnumMember]
        Preparing = 3,
    }

    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class Stamp
    {

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string GeoLocation { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ServiceAddress { get; set; }

        [DataMember]
        public StampState State { get; set; }

        [DataMember]
        public StampCapacities Capacities { get; set; }
    }

    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class Stamps : List<Stamp>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public Stamps() { }

        /// <summary>
        /// Initialize from list
        /// </summary>
        /// <param name="stamps"></param>
        public Stamps(List<Stamp> stamps) : base(stamps) { }
    }
}

