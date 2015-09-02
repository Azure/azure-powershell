﻿//// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;

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
    /// Error contract returned when some exception occurs in ASR REST API.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    [DataContract]
    public class ErrorInException : Error
    {
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
        public VaultCreds(string subscriptionId, string resourceName, string managementCert, AcsNamespace acsNamespace, string resourceNamespace)
        {
            this.SubscriptionId = subscriptionId;
            this.ResourceType = Constants.ASRVaultType;
            this.ResourceName = resourceName;
            this.ManagementCert = managementCert;
            this.AcsNamespace = acsNamespace;
            this.ResourceNamespace = resourceNamespace;
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

        /// <summary>
        /// Gets or sets the key name for HostName entry
        /// </summary>
        [DataMember(Order = 5)]
        public string ResourceNamespace { get; set; }

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
        /// <param name="cloudServiceName">cloud service name</param>
        /// <param name="siteId">custom site Id</param>
        /// <param name="siteName">custom site name</param>
        public ASRVaultCreds(
            string subscriptionId,
            string resourceName,
            string managementCert,
            AcsNamespace acsNamespace,
            string channelIntegrityKey,
            string cloudServiceName,
            string resourceNamespace = "Microsoft.SiteRecovery")
            : base(subscriptionId, resourceName, managementCert, acsNamespace, resourceNamespace)
        {
            this.ChannelIntegrityKey = channelIntegrityKey;
            this.ResourceGroupName = cloudServiceName;
            this.Version = Constants.VaultCredentialVersion;
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

    ///// <summary>
    ///// Hyper-V Replica specific protection profile Input.
    ///// </summary>
    //[DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    //public class HyperVReplicaSP1ProtectionProfileInput
    //{
    //    /// <summary>
    //    /// Gets or sets a value indicating the number of recovery points.
    //    /// </summary>
    //    [DataMember(Name = "recoveryPoints")]
    //    public int RecoveryPoints { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating the application consistent frequency.
    //    /// </summary>
    //    [DataMember(Name = "applicationConsistentSnapshotFrequencyInHours")]
    //    public int ApplicationConsistentSnapshotFrequencyInHours { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating whether compression has to be enabled.
    //    /// </summary>
    //    [DataMember(Name = "compressionEnabled")]
    //    public bool CompressionEnabled { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating whether IR is online.
    //    /// </summary>
    //    [DataMember(Name = "onlineReplicationMethod")]
    //    public bool OnlineReplicationMethod { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating the online IR start time.
    //    /// </summary>
    //    [DataMember(Name = "onlineReplicationStartTime")]
    //    public TimeSpan? OnlineReplicationStartTime { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating the offline IR import path.
    //    /// </summary>
    //    [DataMember(Name = "offlineReplicationImportPath")]
    //    public string OfflineReplicationImportPath { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating the offline IR export path.
    //    /// </summary>
    //    [DataMember(Name = "offlineReplicationExportPath")]
    //    public string OfflineReplicationExportPath { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating the recovery HTTPS port.
    //    /// </summary>
    //    [DataMember(Name = "replicationPort")]
    //    public ushort ReplicationPort { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating the authentication type.
    //    /// </summary>
    //    [DataMember(Name = "allowedAuthenticationType")]
    //    public ushort AllowedAuthenticationType { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating whether the VM has to be auto deleted.
    //    /// </summary>
    //    [DataMember(Name = "allowReplicaDeletion")]
    //    public bool AllowReplicaDeletion { get; set; }
    //}

    ///// <summary>
    ///// Hyper-V Replica specific protection profile Input.
    ///// </summary>
    //[DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    //public class HyperVReplicaProtectionProfileInput : HyperVReplicaSP1ProtectionProfileInput
    //{
    //    /// <summary>
    //    /// Gets or sets a value indicating the replication interval.
    //    /// </summary>
    //    [DataMember(Name = "replicationFrequencyInSeconds")]
    //    public ushort ReplicationFrequencyInSeconds { get; set; }
    //}

    ///// <summary>
    ///// Hyper-V Replica specific protection profile details.
    ///// </summary>
    //[DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    //public class HyperVReplicaSP1ProtectionProfileDetails
    //{
    //    /// <summary>
    //    /// Gets or sets a value indicating the number of recovery points.
    //    /// </summary>
    //    [DataMember]
    //    public int RecoveryPoints { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating the application consistent frequency.
    //    /// </summary>
    //    [DataMember]
    //    public int ApplicationConsistentSnapshotFrequencyInHours { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating whether compression has to be enabled.
    //    /// </summary>
    //    [DataMember]
    //    public bool CompressionEnabled { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating whether IR is online.
    //    /// </summary>
    //    [DataMember]
    //    public bool OnlineReplicationMethod { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating the online IR start time.
    //    /// </summary>
    //    [DataMember]
    //    public TimeSpan? OnlineReplicationStartTime { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating the offline IR import path.
    //    /// </summary>
    //    [DataMember]
    //    public string OfflineReplicationImportPath { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating the offline IR export path.
    //    /// </summary>
    //    [DataMember]
    //    public string OfflineReplicationExportPath { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating the recovery HTTPS port.
    //    /// </summary>
    //    [DataMember]
    //    public ushort ReplicationPort { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating the authentication type.
    //    /// </summary>
    //    [DataMember]
    //    public ushort AllowedAuthenticationType { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating whether the VM has to be auto deleted.
    //    /// Supported Values: String.Empty, None, OnRecoveryCloud
    //    /// </summary>
    //    [DataMember]
    //    public string ReplicaDeletionOption { get; set; }
    //}

    ///// <summary>
    ///// Hyper-V Replica Blue specific protection profile details.
    ///// </summary>
    //[DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    //public class HyperVReplicaProtectionProfileDetails : HyperVReplicaSP1ProtectionProfileDetails
    //{
    //    /// <summary>
    //    /// Gets or sets a value indicating the replication interval.
    //    /// </summary>
    //    [DataMember]
    //    public ushort ReplicationFrequencyInSeconds { get; set; }
    //}

    /// <summary>
    /// Azure Site Recovery Protection Profile HyperVReplicaProviderSettings.
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
        public List<ASRProtectionProfileAssociationDetails> AssociationDetail { get; set; }

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

//    /*
//    /// <summary>
//    /// Disk details for E2A provider.
//    /// </summary>
//    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
//    [SuppressMessage(
//        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
//        "SA1402:FileMayOnlyContainASingleClass",
//        Justification = "Keeping all related classes together.")]
//    public class AzureVmDiskDetails
//    {
//        /// <summary>
//        /// Gets or sets the List of all Disk in VM.
//        /// </summary>
//        [DataMember]
//        public string OsType { get; set; }

//        /// <summary>
//        /// Gets or sets the Type of OS “Windows|Linux” as set.
//        /// </summary>
//        [DataMember]
//        public List<VirtualHardDisk> Disks { get; set; }

//        /// <summary>
//        /// Gets or sets the Name of OS Disk as set.
//        /// </summary>
//        [DataMember]
//        public string OsDisk { get; set; }

//        /// <summary>
//        /// Gets or sets the VHD id.
//        /// </summary>
//        [DataMember]
//        public string VHDId { get; set; }

//        /// <summary>
//        /// Gets or sets MaxSizeMB.
//        /// </summary>
//        [DataMember]
//        public ulong MaxSizeMB { get; set; }
//    }
//    */

//    /// <summary>
//    /// Replication provider specific settings.
//    /// </summary>
//    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
//    [SuppressMessage(
//        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
//        "SA1402:FileMayOnlyContainASingleClass",
//        Justification = "Keeping all related classes together.")]
//    public class ReplicationProviderSpecificSettings
//    {
//        /// <summary>
//        /// Gets or sets Azure VM Disk details.
//        /// </summary>
//        [DataMember]
//        public AzureVmDiskDetails AzureVMDiskDetails { get; set; }

//        /// <summary>
//        /// Gets or sets VM properties.
//        /// </summary>
//        [DataMember]
//        public VMProps VMProperties { get; set; }
//    }
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
