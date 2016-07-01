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

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;
using Microsoft.Azure.Commands.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Hash functions which can be used to calculate CIK HMAC.
    /// </summary>
    public enum CikSupportedHashFunctions
    {
        /// <summary>
        /// Represents a HMACSHA256 hash function.
        /// </summary>
        HMACSHA256,

        /// <summary>
        /// Represents a HMACSHA384 hash function.
        /// </summary>
        HMACSHA384,

        /// <summary>
        /// Represents a HMACSHA512 hash function.
        /// </summary>
        HMACSHA512
    }

    /// <summary>
    /// The types of crypto algorithms
    /// </summary>
    public enum CryptoAlgorithm
    {
        /// <summary>
        /// The asymmetric key based RSA 2048 algorithm.
        /// </summary>
        RSAPKCS1V17,

        /// <summary>
        /// The asymmetric key based RSA 2048 algorithm.
        /// </summary>
        RSAPKCS1V15,

        /// <summary>
        /// The symmetric key based AES algorithm with key size 256 bits.
        /// </summary>
        AES256,

        /// <summary>
        /// The symmetric key based SHA 256 Algorithm
        /// </summary>
        HMACSHA256,

        /// <summary>
        /// When no algorithm is used.
        /// </summary>
        None
    }

    /// <summary>
    /// The RP service error code that needs to be handled by portal.
    /// </summary>
    public enum RpErrorCode
    {
        /// <summary>
        /// The error code sent by RP if the Resource extended info doesn't exists.
        /// </summary>
        ResourceExtendedInfoNotFound
    }

    /// <summary>
    /// ARM specified Error
    /// </summary>
    public class ARMError
    {
        /// <summary>
        /// Gets ARM formatted exception.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public ARMException Error { get; private set; }
    }

    /// <summary>
    /// ARM exception class.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related classes together.")]
    public class ARMException
    {
        /// <summary>
        /// Gets HTTP status code for the error.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string ErrorCode { get; private set; }

        /// <summary>
        /// Gets exception message.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; private set; }

        /// <summary>
        /// Gets exception target.
        /// </summary>
        [JsonProperty(PropertyName = "target",
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Target { get; private set; }

        /// <summary>
        /// Gets service based error details.
        /// </summary>
        [JsonProperty(PropertyName = "details")]
        public List<ARMExceptionDetails> Details { get; private set; }
    }

    /// <summary>
    /// Service based exception details.
    /// </summary>
    public class ARMExceptionDetails
    {
        /// <summary>
        /// Gets service error code.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string ErrorCode { get; private set; }

        /// <summary>
        /// Gets error message.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; private set; }

        /// <summary>
        /// Gets possible cause for error.
        /// </summary>
        [JsonProperty(PropertyName = "possibleCauses",
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PossibleCauses { get; private set; }

        /// <summary>
        /// Gets recommended action for the error.
        /// </summary>
        [JsonProperty(PropertyName = "recommendedAction",
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string RecommendedAction { get; private set; }

        /// <summary>
        /// Gets the client request Id for the session.
        /// </summary>
        [JsonProperty(PropertyName = "clientRequestId",
        NullValueHandling = NullValueHandling.Ignore,
        DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ClientRequestId { get; private set; }

                /// <summary>
        /// Gets the activity Id for the session.
        /// </summary>
        [JsonProperty(PropertyName = "activityId")]
        public string ActivityId { get; private set; }

        /// <summary>
        /// Gets exception target.
        /// </summary>
        [JsonProperty(PropertyName = "target",
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Target { get; private set; }
    }

    /// <summary>
    /// CIK token details.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    [DataContract]
    public class CikTokenDetails
    {
        /// <summary>
        /// Gets or sets the timestamp before which the token is not valid.
        /// </summary>
        [DataMember]
        public DateTime NotBeforeTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the timestamp after which the token is not valid.
        /// </summary>
        [DataMember]
        public DateTime NotAfterTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the client request Id for the operation linked with this CIK token.
        /// </summary>
        [DataMember]
        public string ClientRequestId { get; set; }

        /// <summary>
        /// Gets or sets Hash function used to calculate the HMAC.
        /// </summary>
        [DataMember]
        public string HashFunction { get; set; }

        /// <summary>
        /// Gets or sets the HMAC generated using the CIK key.
        /// </summary>
        [DataMember]
        public string Hmac { get; set; }

        /// <summary>
        /// Gets or sets Data contract version.
        /// </summary>
        [DataMember(Name = "Version")]
        public Version Version { get; set; }

        /// <summary>
        /// Gets or sets property bag. This property bag is introduced to support addition of any 
        /// new property in data contract without breaking the existing clients.
        /// If any new property needs to be introduced in the contract, 
        /// add a key value pair for it in this dictionary. 
        /// </summary>
        [DataMember]
        public Dictionary<string, object> PropertyBag { get; set; }

        /// <summary>
        /// Converts the object into string.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NotBeforeTimestamp: " + this.NotBeforeTimestamp);
            sb.AppendLine("NotAfterTimestamp: " + this.NotAfterTimestamp);
            sb.AppendLine("ClientRequestId: " + this.ClientRequestId);
            sb.AppendLine("Hmac: " + this.Hmac);
            return sb.ToString();
        }
    }
}

//// TODO: Remove this once we get nuget
namespace Microsoft.Azure.Commands.RecoveryServices.RestApiInfra
{
    /// <summary>
    /// Class to define the error for RP
    /// </summary>
    [SuppressMessage(
    "Microsoft.StyleCop.CSharp.MaintainabilityRules",
    "SA1402:FileMayOnlyContainASingleClass",
    Justification = "Keeping all contracts together.")]
    [DataContract(Namespace = "http://schemas.microsoft.com/wars")]
    public class Error
    {
        /// <summary>
        /// Gets or sets the value for the error as string.
        /// </summary>
        [DataMember]
        public string ErrorCode { get; set; }
    }
}

namespace Microsoft.Azure.Portal.RecoveryServices.Models.Common
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
            this.ResourceType = string.IsNullOrEmpty(resourceType) ? Constants.VaultType : resourceType;
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
            this.Version = Constants.VaultCredentialVersion;

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
    /// Class to define backup vault credentials
    /// </summary>
    [DataContract]
    public class BackupVaultCreds : VaultCreds
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
        public BackupVaultCreds(string subscriptionId, string resourceName, string managementCert, 
            AcsNamespace acsNamespace)
            : base(subscriptionId, resourceName, managementCert, acsNamespace, Constants.BackupVaultType) { }

        /// <summary>
        /// Initializes a new instance of the BackupVaultCreds class
        /// </summary>
        /// <param name="subscriptionId">subscription Id</param>
        /// <param name="resourceType">resource type</param>
        /// <param name="resourceName">resource name</param>
        /// <param name="managementCert">management cert</param>
        /// <param name="acsNamespace">acs namespace</param>
        /// <param name="agentLinks">agent links</param>
        public BackupVaultCreds(string subscriptionId, string resourceName, string managementCert, 
            AcsNamespace acsNamespace, string agentLinks)
            : this(subscriptionId, resourceName, managementCert, acsNamespace)
        {
            AgentLinks = agentLinks;
        }

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
        public AcsNamespace(UploadCertificateResponse acsDetails)
        {
            this.HostName = acsDetails.Properties.GlobalAcsHostName;
            this.Namespace = acsDetails.Properties.GlobalAcsNamespace;
            this.ResourceProviderRealm = acsDetails.Properties.GlobalAcsRPRealm;
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
}
