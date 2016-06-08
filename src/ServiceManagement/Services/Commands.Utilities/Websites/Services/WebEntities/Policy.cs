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
    /// Class that represents a Web Plan's policy.
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class Policy
    {
        /// <summary>
        /// Name for the plan
        /// </summary>
        [DataMember(Order = 0)]
        public string PlanName { get; set; }

        [DataMember(Order = 1)]
        public ComputeModeOptions ComputeMode { get; set; }

        [DataMember(Order = 2)]
        public string SiteMode { get; set; }

        [DataMember(Order = 3)]
        public SiteProcessSettings SiteProcessSettings { get; set; }

        [DataMember(Order = 4)]
        public Features Features { get; set; }
    }

    /// <summary>
    /// Collection of policies
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class Policies : List<Policy>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public Policies() { }

        /// <summary>
        /// Initialize from list
        /// </summary>
        /// <param name="plans"></param>
        public Policies(List<Policy> policies) : base(policies) { }
    }


    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class Features
    {
        [DataMember]
        public bool CustomDomainsEnabled { get; set; }

        [DataMember]
        public bool SniBasedSslEnabled { get; set; }

        [DataMember]
        public bool IpBasedSslEnabled { get; set; }
    }

    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class SiteProcessSettings
    {
        [DataMember]
        public double CpuLimitPercentage { get; set; }

        [DataMember]
        public int CpuLimitPeriodInMinutes { get; set; }

        [DataMember]
        public int CpuLimitAction { get; set; }

        [DataMember]
        public int MemoryLimitInMB { get; set; }

        [DataMember]
        public int MemoryLimitWorkingSetInMB { get; set; }

        [DataMember]
        public int FailProtectionLimit { get; set; }

        [DataMember]
        public int FailProtectionPeriodInSeconds { get; set; }

        [DataMember]
        public int FailProtectionPenaltyPeriodInSeconds { get; set; }

        [DataMember]
        public int IdleTimeoutInMinutes { get; set; }

        [DataMember]
        public int IdlePriority { get; set; }

        [DataMember]
        public int WorkerProcessLimit { get; set; }

        [DataMember]
        public int FastCgiProcessLimit { get; set; }

        [DataMember]
        public int HttpQueueLength { get; set; }
    }
}
