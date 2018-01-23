//// ----------------------------------------------------------------------------------
////
//// Copyright Microsoft Corporation
//// Licensed under the Apache License, Version 2.0 (the "License");
//// you may not use this file except in compliance with the License.
//// You may obtain a copy of the License at
//// http://www.apache.org/licenses/LICENSE-2.0
//// Unless required by applicable law or agreed to in writing, software
//// distributed under the License is distributed on an "AS IS" BASIS,
//// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//// See the License for the specific language governing permissions and
//// limitations under the License.
//// ----------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.Azure.Portal.RecoveryServices.Models.Common
{
    [DataContract]
    public class ASRVaultDetails
    {
        /// <summary>
        /// Gets or sets the values for SubscriptionId.
        /// </summary>
        [DataMember(Order = 0)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the values for ResourceGroup.
        /// </summary>
        [DataMember(Order = 1)]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the values for ResourceName.
        /// </summary>
        [DataMember(Order = 2)]
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the values for ResourceId.
        /// </summary>
        [DataMember(Order = 3)]
        public long ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the values for Location.
        /// </summary>
        [DataMember(Order = 4)]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the values for ResourceType.
        /// </summary>
        [DataMember(Order = 5)]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the values for ProviderNamespace.
        /// </summary>
        [DataMember(Order = 6)]
        public string ProviderNamespace { get; set; }

    }

    [DataContract]
    public class ASRVaultAadDetails
    {
        /// <summary>
        /// Gets or sets the values for AadAuthority.
        /// </summary>
        [DataMember(Order = 0)]
        public string AadAuthority { get; set; }

        /// <summary>
        /// Gets or sets the values for AadTenantId.
        /// </summary>
        [DataMember(Order = 1)]
        public string AadTenantId { get; set; }

        /// <summary>
        /// Gets or sets the values for ServicePrincipalClientId.
        /// </summary>
        [DataMember(Order = 2)]
        public string ServicePrincipalClientId { get; set; }

        /// <summary>
        /// Gets or sets the values for AadVaultAudience.
        /// </summary>
        [DataMember(Order = 3)]
        public string AadVaultAudience { get; set; }

        /// <summary>
        /// Gets or sets the values for ArmManagementEndpoint.
        /// </summary>
        [DataMember(Order = 4)]
        public string ArmManagementEndpoint { get; set; }

    }

    [DataContract]
    public class RSVaultAsrCreds
    {
        /// <summary>
        /// Gets or sets the values for VaultDetails.
        /// </summary>
        [DataMember(Order = 0)]
        public ASRVaultDetails VaultDetails { get; set; }

        /// <summary>
        /// Gets or sets the subscription ID entry.
        /// </summary>
        [DataMember(Order = 1)]
        public string ManagementCert { get; set; }

        /// <summary>
        /// Gets or sets the Version.
        /// </summary>
        [DataMember(Order = 2)]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the AadDetails.
        /// </summary>
        [DataMember(Order = 3)]
        public ASRVaultAadDetails AadDetails { get; set; }

        /// <summary>
        /// Gets or sets the ChannelIntegrityKey.
        /// </summary>
        [DataMember(Order = 4)]
        public string ChannelIntegrityKey { get; set; }

        /// <summary>
        /// Gets or sets the SiteId.
        /// </summary>
        [DataMember(Order = 5)]
        public string SiteId { get; set; }

        /// <summary>
        /// Gets or sets the Resource Group.
        /// </summary>
        [DataMember(Order = 6)]
        public string SiteName { get; set; }
    }
}
