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

using Microsoft.Azure.Commands.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.Azure.Commands.SiteRecovery
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
    /// Fabric type class.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public class FabricProviders
    {
        /// <summary>
        /// Unknown type.
        /// </summary>
        public const string Other = "Other";

        /// <summary>
        /// VMM server type.
        /// </summary>
        public const string VMM = "VMM";

        /// <summary>
        /// Azure fabric type.
        /// </summary>
        public const string Azure = "Azure";

        /// <summary>
        /// HyperVSite server type.
        /// </summary>
        public const string HyperVSite = "HyperVSite";

        /// <summary>
        /// InMage server type.
        /// </summary>
        public const string VCenter = "VCenter";
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
    /// Error contract returned when some exception occurs in ASR REST API.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Error" /> class.
        /// </summary>
        public Error()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Error" /> class with required parameters.
        /// </summary>
        /// <param name="se">Service Error</param>
        public Error(ServiceError se)
        {
            this.ClientRequestId = se.ActivityId;
            this.Code = se.Code;
            this.Message = se.Message;
            this.PossibleCauses = se.PossibleCauses;
            this.RecommendedAction = se.RecommendedAction;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Error" /> class.
        /// </summary>
        /// <param name="errorCode">Service generated error code.</param>
        /// <param name="message">Error message.</param>
        /// <param name="possibleCauses">Possible causes of the error.</param>
        /// <param name="recommendedAction">Recommended action to resolve the error.</param>
        /// <param name="activityId">ActivityId in which error occurred.</param>
        public Error(
            string errorCode,
            string message,
            string possibleCauses,
            string recommendedAction,
            string activityId)
        {
            this.Code = errorCode;
            this.Message = message;
            this.PossibleCauses = possibleCauses;
            this.RecommendedAction = recommendedAction;
            this.ClientRequestId = activityId;
        }

        /// <summary>
        /// Gets or sets error code.
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets error message.
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets possible causes of error.
        /// </summary>
        [DataMember]
        public string PossibleCauses { get; set; }

        /// <summary>
        /// Gets or sets recommended action to resolve error.
        /// </summary>
        [DataMember]
        public string RecommendedAction { get; set; }

        /// <summary>
        /// Gets or sets client request Id.
        /// </summary>
        [DataMember(Name = "ActivityId")]
        public string ClientRequestId { get; set; }
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

    /// <summary>
    /// Possible states of the Job.
    /// </summary>
    public class JobStatus : TaskStatus
    {
    }

    /// <summary>
    /// Possible states of the Task.
    /// </summary>
    public class TaskStatus
    {
        /// <summary>
        /// TaskStatus NotStarted value.
        /// </summary>
        public static readonly string NotStarted = "NotStarted";

        /// <summary>
        /// Status InProgress value. 
        /// </summary>
        public static readonly string InProgress = "InProgress";

        /// <summary>
        /// Status Succeeded value.
        /// </summary>
        public static readonly string Succeeded = "Succeeded";

        /// <summary>
        /// Status Other value.
        /// </summary>
        public static readonly string Other = "Other";

        /// <summary>
        /// Status Failed value.
        /// </summary>
        public static readonly string Failed = "Failed";

        /// <summary>
        /// Status Cancelled value.
        /// </summary>
        public static readonly string Cancelled = "Cancelled";

        /// <summary>
        /// Status Suspended value.
        /// </summary>
        public static readonly string Suspended = "Suspended";
    }
}

//// TODO: Remove this once we get nuget
namespace Microsoft.Azure.Commands.SiteRecovery.RestApiInfra
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
        public VaultCreds(string subscriptionId, string resourceName, string managementCert, AcsNamespace acsNamespace)
        {
            this.SubscriptionId = subscriptionId;
            this.ResourceType = Constants.ASRVaultType;
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
    /// Class to define ASR Vault credentials
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
            string resourceType)
            : base(subscriptionId, resourceName, managementCert, acsNamespace)
        {
            this.ChannelIntegrityKey = channelIntegrityKey;
            this.ResourceGroupName = resourceGroupName;
            this.Version = Constants.VaultCredentialVersion;

            this.SiteId = siteId != null ? siteId : string.Empty;
            this.SiteName = siteName != null ? siteName : string.Empty;

            this.ResourceNamespace = resourceNamespace;
            this.ARMResourceType = resourceType;
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

    /// <summary>
    /// Azure Site Recovery Policy HyperVReplicaProviderSettings.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class HyperVReplicaProviderSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperVReplicaProviderSettings" /> class.
        /// </summary>
        public HyperVReplicaProviderSettings()
        {
        }

        #region Properties

        /// <summary>
        /// Gets or sets Replication Method.
        /// </summary>
        public string ReplicationMethod { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether profile can be dissociated or not.
        /// </summary>
        public bool CanDissociate { get; set; }

        /// <summary>
        /// Gets or sets Association Details.
        /// </summary>
        public List<ASRPolicyAssociationDetails> AssociationDetail { get; set; }

        /// <summary>
        /// Gets or sets Replication Frequency in seconds.
        /// </summary>
        public ushort ReplicationFrequencyInSeconds { get; set; }

        /// <summary>
        /// Gets or sets Recovery Points.
        /// </summary>
        public int RecoveryPoints { get; set; }

        /// <summary>
        /// Gets or sets Application Consistent Snapshot Frequency in hours.
        /// </summary>
        public int ApplicationConsistentSnapshotFrequencyInHours { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Compression is Enabled.
        /// </summary>
        public bool CompressionEnabled { get; set; }

        /// <summary>
        /// Gets or sets the replication port.
        /// </summary>
        public ushort ReplicationPort { get; set; }

        /// <summary>
        /// Gets or sets the allowed authentication type.
        /// </summary>
        public string Authentication { get; set; }

        /// <summary>
        /// Gets or sets Replication Start Time.
        /// </summary>
        public TimeSpan? ReplicationStartTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Replica Deletion should be enabled.
        /// </summary>
        public bool AllowReplicaDeletion { get; set; }

        #endregion
    }
}

namespace Microsoft.Azure.Portal.HybridServicesCore
{
    /// <summary>
    /// The ResourceExtendedInfo which represents the xml info stored in RP.
    /// </summary>
    [DataContract]
    public class ResourceExtendedInfo
    {
        #region properties

        /// <summary>
        /// Gets or sets the version
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the channel integrity key
        /// </summary>
        [DataMember(IsRequired = false)]
        public string ChannelIntegrityKey { get; set; }

        /// <summary>
        /// Gets or sets the Channel encryption key
        /// </summary>
        [DataMember(IsRequired = false)]
        public string ChannelEncryptionKey { get; set; }

        /// <summary>
        /// Gets or sets the channel encryption key thumbprint
        /// </summary>
        [DataMember(IsRequired = false)]
        public string ChannelEncryptionKeyThumbprint { get; set; }

        /// <summary>
        /// Gets or sets the portal certificate thumbprint
        /// </summary>
        [DataMember(IsRequired = false)]
        public string PortalCertificateThumbprint { get; set; }

        /// <summary>
        /// Gets or sets the algorithm used to encrypt the data.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Algorithm { get; set; }

        /// <summary>
        /// Gets or sets the tag to be sent while updating the resource extended info.
        /// </summary>
        [IgnoreDataMember]
        public string Etag { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Returns the Xml representation of this object.
        /// </summary>
        /// <returns>the xml as string</returns>
        public ResourceExtendedInformationArgs Translate()
        {
            if (string.IsNullOrEmpty(this.Etag))
            {
                this.Etag = Guid.NewGuid().ToString();
            }

            string serializedInfo = Utilities.Serialize<ResourceExtendedInfo>(this);
            ResourceExtendedInformationArgs extendedInfoArgs = new ResourceExtendedInformationArgs(
                Constants.VaultExtendedInfoContractVersion,
                serializedInfo,
                this.Etag);

            return extendedInfoArgs;
        }

        /// <summary>
        /// Method to generate security information
        /// </summary>
        public void GenerateSecurityInfo()
        {
            this.ChannelIntegrityKey = Utilities.GenerateRandomKey(128);
            this.Version = Constants.VaultSecurityInfoVersion;
            this.Algorithm = CryptoAlgorithm.None.ToString();
        }

        #endregion
    }
}
