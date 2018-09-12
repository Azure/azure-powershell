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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Newtonsoft.Json;

namespace RecoveryServices.SiteRecovery.Test
{
    /// <summary>
    /// Class to define Vault credentials
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    [DataContract]
    public class VaultCreds
    {
        #region Constructores

        /// <summary>
        /// Initializes a new instance of the <see cref="VaultCreds"/> class.
        /// </summary>
        public VaultCreds()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VaultCreds"/> class.
        /// </summary>
        /// <param name="subscriptionId">subscription Id</param>
        /// <param name="resourceName">resource name</param>
        /// <param name="managementCert">management cert</param>
        /// <param name="acsNamespace">authenticating service namespace</param>
        /// <param name="resourceType">resource type backup vault or ASR vault</param>
        public VaultCreds(string subscriptionId, string resourceName, string managementCert, AcsNamespace acsNamespace, string resourceType = null)
        {
            this.SubscriptionId = subscriptionId;
            //this.ResourceType = string.IsNullOrEmpty(resourceType) ? Constants.VaultType : resourceType;
            this.ResourceName = resourceName;
            this.ManagementCert = managementCert;
            this.AcsNamespace = acsNamespace;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the key name for Namespace entry
        /// </summary>
        [DataMember(Order = 0)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the key name for Namespace entry
        /// </summary>
        [DataMember(Order = 1)]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the key name for Namespace entry
        /// </summary>
        [DataMember(Order = 2)]
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the key name for Namespace entry
        /// </summary>
        [DataMember(Order = 3)]
        public string ManagementCert { get; set; }

        /// <summary>
        /// Gets or sets the key name for HostName entry
        /// </summary>
        [DataMember(Order = 4)]
        public AcsNamespace AcsNamespace { get; set; }

        #endregion
    }

    /// <summary>
    /// Class to define ARS Vault credentials
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public class ASRVaultCreds : VaultCreds
    {
        #region Constructores

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVaultCreds"/> class.
        /// </summary>
        public ASRVaultCreds()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVaultCreds"/> class.
        /// </summary>
        /// <param name="subscriptionId">subscription Id</param>
        /// <param name="resourceName">resource name</param>
        /// <param name="managementCert">management cert</param>
        /// <param name="acsNamespace">authenticating service  namespace</param>
        /// <param name="channelIntegrityKey">Agent Channel Integrity Key</param>
        /// <param name="resourceGroupName">cloud service name</param>
        /// <param name="siteId">custom site Id</param>
        /// <param name="siteName">custom site name</param>
        public ASRVaultCreds(
            string subscriptionId,
            string resourceName,
            string managementCert,
            AcsNamespace acsNamespace,
            string channelIntegrityKey,
            string resourceGroupName,
            string siteId,
            string siteName,
            string resourceNamespace,
            string resourceType,
            string location)
            : base(subscriptionId, resourceName, managementCert, acsNamespace)
        {
            this.ChannelIntegrityKey = channelIntegrityKey;
            this.ResourceGroupName = resourceGroupName;
            //this.Version = Constants.VaultCredentialVersion;

            this.SiteId = siteId != null ? siteId : string.Empty;
            this.SiteName = siteName != null ? siteName : string.Empty;

            this.ResourceNamespace = resourceNamespace;
            this.ARMResourceType = resourceType;
            this.Location = location;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the value for ACIK
        /// </summary>
        [DataMember(Order = 0)]
        public string ChannelIntegrityKey { get; set; }

        /// <summary>
        /// Gets or sets the value for cloud service name
        /// </summary>
        [DataMember(Order = 1)]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the values for the version of the credentials
        /// </summary>
        [DataMember(Order = 2)]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the site Id
        /// </summary>
        [DataMember(Order = 3)]
        public string SiteId { get; set; }

        /// <summary>
        /// Gets or sets the site name
        /// </summary>
        [DataMember(Order = 4)]
        public string SiteName { get; set; }

        /// <summary>
        /// Gets or sets Resource namespace
        /// </summary>
        [DataMember(Order = 5)]
        public string ResourceNamespace { get; set; }

        /// <summary>
        /// Gets or sets Resource type
        /// </summary>
        [DataMember(Order = 6)]
        public string ARMResourceType { get; set; }

        /// <summary>
        /// Gets or sets the vault location
        /// </summary>
        [DataMember(Order = 7)]
        public string Location { get; set; }

        #endregion
    }

    /// <summary>
    /// Class to define ACS name space
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    [DataContract]
    public class AcsNamespace
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AcsNamespace"/> class.
        /// </summary>
        /// <param name="acsDetails">authenticating service Details name</param>
        public AcsNamespace(ResourceCertificateAndAcsDetails acsDetails)
        {
            this.HostName = acsDetails.GlobalAcsHostName;
            this.Namespace = acsDetails.GlobalAcsNamespace;
            this.ResourceProviderRealm = acsDetails.GlobalAcsRPRealm;
        }

        /// <summary>
        /// Gets or sets Host name
        /// </summary>
        [DataMember(Order = 0)]
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets Name space
        /// </summary>
        [DataMember(Order = 0)]
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets Resource provider realm
        /// </summary>
        [DataMember(Order = 0)]
        public string ResourceProviderRealm { get; set; }
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
}