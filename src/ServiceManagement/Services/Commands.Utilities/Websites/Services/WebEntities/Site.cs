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
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.WindowsAzure.Management.WebSites.Models;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities
{
    [DataContract(Name = "UsageState", Namespace = UriElements.ServiceNamespace)]
    public enum UsageState
    {
        [EnumMember]
        Normal = 0,
        [EnumMember]
        Exceeded = 1,
    }

    [DataContract(Name = "SiteAvailabilityState", Namespace = UriElements.ServiceNamespace)]
    public enum SiteAvailabilityState
    {
        [EnumMember]
        Normal = 0,
        [EnumMember]
        Limited = 1,
    }

    public interface ISite
    {
        string Name { get; set; }
        string State { get; set; }
        string[] HostNames { get; set; }
        string WebSpace { get; set; }
        Uri SelfLink { get; set; }
        string RepositorySiteName { get; set; }
        UsageState UsageState { get; set; }
        bool? Enabled { get; set; }
        bool? AdminEnabled { get; set; }
        string[] EnabledHostNames { get; set; }
        SiteProperties SiteProperties { get; set; }
        SiteAvailabilityState AvailabilityState { get; set; }
        HostNameSslStates HostNameSslStates { get; set; }
        SkuOptions? Sku { get; set; }
    }

    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class Site : ISite
    {
        [DataMember(IsRequired = false)]
        public string Name { get; set; }

        [DataMember(IsRequired = false)]
        public string State { get; set; }

        [DataMember(IsRequired = false)]
        public string[] HostNames { get; set; }

        [DataMember(IsRequired = false)]
        public string WebSpace { get; set; }

        [DataMember(IsRequired = false)]
        public Uri SelfLink { get; set; }

        [DataMember(IsRequired = false)]
        public string RepositorySiteName { get; set; }

        [DataMember(IsRequired = false)]
        public string Owner { get; set; }

        [DataMember(IsRequired = false)]
        public UsageState UsageState { get; set; }

        [DataMember(IsRequired = false)]
        public bool? Enabled { get; set; }

        [DataMember(IsRequired = false)]
        public bool? AdminEnabled { get; set; }

        [DataMember(IsRequired = false)]
        public string[] EnabledHostNames { get; set; }

        [DataMember(IsRequired = false)]
        public SiteProperties SiteProperties { get; set; }

        [DataMember(IsRequired = false)]
        public SiteAvailabilityState AvailabilityState { get; set; }

        [DataMember(IsRequired = false)]
        public Certificate[] SSLCertificates { get; set; }

        [DataMember(IsRequired = false)]
        public HostNameSslStates HostNameSslStates { get; set; }

        [DataMember(IsRequired = false)]
        public SkuOptions? Sku { get; set; }

        internal string GetProperty(string property)
        {
            if (SiteProperties.Properties.Any(kvp => kvp.Name.Equals(property, StringComparison.InvariantCultureIgnoreCase)))
            {
                return SiteProperties.Properties.First(kvp => kvp.Name.Equals(property, StringComparison.InvariantCultureIgnoreCase)).Value;
            }

            return null;
        }
    }

    [DataContract(Namespace = UriElements.ServiceNamespace, Name = "Site")]
    public class SiteWithWebSpace : Site
    {
        [DataMember(IsRequired = false)]
        public WebSpace WebSpaceToCreate { get; set; }

        [DataMember(IsRequired = false)]
        public bool DisableClone { get; set; }
    }

    [DataContract(Namespace = UriElements.ServiceNamespace, Name = "Site")]
    public class SiteWithDetails : Site
    {
        [DataMember(IsRequired = false)]
        public string UNCPath { get; set; }

        [DataMember(IsRequired = false)]
        public int? NumberOfWorkers { get; set; }

        [DataMember(IsRequired = false)]
        public Servers RunningWorkers { get; set; }

        [DataMember(IsRequired = false)]
        public string Subscription { get; set; }
    }

    /// <summary>
    /// Collection of sites
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class Sites : List<Site>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public Sites() { }

        /// <summary>
        /// Initialize collection
        /// </summary>
        /// <param name="sites"></param>
        public Sites(List<Site> sites) : base(sites) { }
    }

    /// <summary>
    /// Paged collection of sites
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class PagedSites : PagedSet<SiteWithDetails>
    {
    }
}