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
using System.Xml.Serialization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.GeoEntities
{
    [DataContract]
    [XmlRoot("GeoRegion", Namespace = UriElements.ServiceNamespace)]
    public class GeoRegion
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int? SortOrder { get; set; }
    }

    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    [XmlRoot("GeoRegions", Namespace = UriElements.ServiceNamespace)]
    public class GeoRegions : List<GeoRegion>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public GeoRegions() { }

        /// <summary>
        /// Initialize from list
        /// </summary>
        /// <param name="regions"></param>
        public GeoRegions(List<GeoRegion> regions) : base(regions) { }
    }
}
