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
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public enum TimeUnits
    {
        [EnumMember]
        Days = 0,
        [EnumMember]
        Minutes = 1,
        [EnumMember]
        Hours = 2,
        [EnumMember]
        Months = 3
    }

    [DataContract(Namespace = UriElements.ServiceNamespace, Name = "ExceededAction")]
    public enum ExceededAction
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        Stop = 1,
        [EnumMember]
        RunLimited = 2,
        [EnumMember]
        Redirect = 3
    }

    [DataContract(Namespace = UriElements.ServiceNamespace, Name = "EnforcementScope")]
    public enum EnforcementScope
    {
        [EnumMember]
        WebSpace = 0,
        [EnumMember]
        Site = 1
    }

    /// <summary>
    /// Class that represents a Web Quota.
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class WebQuota
    {
        [DataMember(IsRequired = false)]
        public string WebPlan { get; set; }

        [DataMember(IsRequired = false)]
        public ComputeModeOptions ComputeMode { get; set; }

        [DataMember(IsRequired = false)]
        public string QuotaName { get; set; }

        [DataMember(IsRequired = false)]
        public string ResourceName { get; set; }

        [DataMember(IsRequired = false)]
        public long? Limit { get; set; }

        [DataMember(IsRequired = false)]
        public TimeUnits? Unit { get; set; }

        [DataMember(IsRequired = false)]
        public int? Period { get; set; }

        [DataMember(IsRequired = false)]
        public ExceededAction? ExceededAction { get; set; }

        [DataMember(IsRequired = false)]
        public string CustomActionName { get; set; }

        [DataMember(IsRequired = false)]
        public string SiteMode { get; set; }

        [DataMember(IsRequired = false)]
        public EnforcementScope EnforcementScope { get; set; }
    }


    /// <summary>
    /// Collection of webquotas
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class WebQuotas : List<WebQuota>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public WebQuotas() { }

        /// <summary>
        /// Initialize collection
        /// </summary>
        /// <param name="sites"></param>
        public WebQuotas(List<WebQuota> webquotas) : base(webquotas) { }
    }
}
