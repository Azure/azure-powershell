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

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.AzureBackup.Models
{
    /// <summary>
    /// Class to define vault credentials
    /// </summary>
    [DataContract]
    internal class VaultCreds
    {
        #region Properties

        /// <summary>
        /// Gets or sets the key name for SubscriptionId entry
        /// </summary>
        [DataMember(Order = 0)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the key name for ResourceType entry
        /// </summary>
        [DataMember(Order = 1)]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the key name for ResourceName entry
        /// </summary>
        [DataMember(Order = 2)]
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the key name for ManagementCert entry
        /// </summary>
        [DataMember(Order = 3)]
        public string ManagementCert { get; set; }

        /// <summary>
        /// Gets or sets the key name for AcsNamespace entry
        /// </summary>
        [DataMember(Order = 4)]
        public AcsNamespace AcsNamespace { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the VaultCreds class
        /// </summary>
        public VaultCreds() { }

        /// <summary>
        /// Initializes a new instance of the VaultCreds class
        /// </summary>
        /// <param name="subscriptionId">subscription id</param>
        /// <param name="resourceType">resource type</param>
        /// <param name="resourceName">resource name</param>
        /// <param name="managementCert">management cert</param>
        /// <param name="acsNamespace">acs namespace</param>
        public VaultCreds(string subscriptionId, string resourceType, string resourceName, string managementCert, AcsNamespace acsNamespace)
        {
            SubscriptionId = subscriptionId;
            ResourceType = resourceType;
            ResourceName = resourceName;
            ManagementCert = managementCert;
            AcsNamespace = acsNamespace;
        }

        #endregion
    }

    /// <summary>
    /// Class to define backup vault credentials
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Grouping classes based on entity")]
    [DataContract]
    internal class BackupVaultCreds : VaultCreds
    {
        /// <summary>
        /// Gets or sets the agent links
        /// </summary>
        [DataMember(Order = 0)]
        public string AgentLinks { get; set; }

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BackupVaultCreds class
        /// </summary>
        public BackupVaultCreds() { }

        /// <summary>
        /// Initializes a new instance of the BackupVaultCreds class
        /// </summary>
        /// <param name="subscriptionId">subscription Id</param>
        /// <param name="resourceType">resource type</param>
        /// <param name="resourceName">resource name</param>
        /// <param name="managementCert">management cert</param>
        /// <param name="acsNamespace">acs namespace</param>
        public BackupVaultCreds(string subscriptionId, string resourceType, string resourceName, string managementCert, AcsNamespace acsNamespace)
            : base(subscriptionId, resourceType, resourceName, managementCert, acsNamespace)
        { }

        /// <summary>
        /// Initializes a new instance of the BackupVaultCreds class
        /// </summary>
        /// <param name="subscriptionId">subscription Id</param>
        /// <param name="resourceType">resource type</param>
        /// <param name="resourceName">resource name</param>
        /// <param name="managementCert">management cert</param>
        /// <param name="acsNamespace">acs namespace</param>
        /// <param name="agentLinks">agent links</param>
        public BackupVaultCreds(string subscriptionId, string resourceType, string resourceName, string managementCert, AcsNamespace acsNamespace, string agentLinks)
            : this(subscriptionId, resourceType, resourceName, managementCert, acsNamespace)
        {
            AgentLinks = agentLinks;
        }

        #endregion
    }

    /// <summary>
    /// AcsNamespace is where the certificate is uploaded into
    /// </summary>
    [DataContract]
    internal class AcsNamespace
    {
        /// <summary>
        /// Gets or sets the key name for HostName entry
        /// </summary>
        [DataMember(Order = 0)]
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets the key name for Namespace entry
        /// </summary>
        [DataMember(Order = 1)]
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the value for ResourceProviderRealm entry
        /// </summary>
        [DataMember(Order = 2)]
        public string ResourceProviderRealm { get; set; }

        /// <summary>
        /// Initializes a new instance of the AcsNamespace class
        /// </summary>
        public AcsNamespace() { }

        /// <summary>
        /// Initializes a new instance of the AcsNamespace class.
        /// </summary>
        /// <param name="hostName">host name</param>
        /// <param name="acsNmespace">acs namespace</param>
        /// <param name="resourceProviderRealm">rp realm</param>
        public AcsNamespace(string hostName, string acsNmespace, string resourceProviderRealm)
        {
            this.HostName = hostName;
            this.Namespace = acsNmespace;
            this.ResourceProviderRealm = resourceProviderRealm;
        }
    }
}
