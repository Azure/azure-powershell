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
    public class RSBackupVaultAADCreds
    {
        /// <summary>
        /// Gets or sets the values for the version of the credentials.
        /// </summary>
        [DataMember(Order = 0)]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the subscription ID entry.
        /// </summary>
        [DataMember(Order = 1)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the resource type.
        /// </summary>
        [DataMember(Order = 2)]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the resource name entry.
        /// </summary>
        [DataMember(Order = 3)]
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the management certificate.
        /// </summary>
        [DataMember(Order = 4)]
        public string ManagementCert { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the vault.
        /// </summary>
        [DataMember(Order = 5)]
        public long ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the Resource Group.
        /// </summary>
        [DataMember(Order = 6)]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the Location.
        /// </summary>
        [DataMember(Order = 7)]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Provider Namespace.
        /// </summary>
        [DataMember(Order = 8)]
        public string ProviderNamespace { get; set; }

        /// <summary>
        /// Gets or sets the AAD Authority.
        /// </summary>
        [DataMember(Order = 9)]
        public string AadAuthority { get; set; }

        /// <summary>
        /// Gets or sets the AAD Tenant Id.
        /// </summary>
        [DataMember(Order = 10)]
        public string AadTenantId { get; set; }

        /// <summary>
        /// Gets or sets the Service Principal Client Id.
        /// </summary>
        [DataMember(Order = 11)]
        public string ServicePrincipalClientId { get; set; }

        /// <summary>
        /// Gets or sets the Id Management Endpoint.
        /// </summary>
        [DataMember(Order = 12)]
        public string IdMgmtRestEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the agent links
        /// </summary>
        [DataMember(Order = 13)]
        public string AgentLinks { get; set; }
    }
}
