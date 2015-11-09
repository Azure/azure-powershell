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
using Microsoft.Azure.Commands.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// General Constant definition
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// ASR vault type
        /// </summary>
        public const string ASRVaultType = "HyperVRecoveryManagerVault";

        /// <summary>
        /// Vault Credential version.
        /// </summary>
        public const string VaultCredentialVersion = "1.0";

        /// <summary>
        /// The version of Extended resource info.
        /// </summary>
        public const string VaultSecurityInfoVersion = "1.0";

        /// <summary>
        /// extended information version.
        /// </summary>
        public const string VaultExtendedInfoContractVersion = "V2014_09";

        /// <summary>
        /// A valid value for the string field Microsoft.WindowsAzure.CloudServiceManagement.resource.OperationStatus.Type
        /// </summary>
        public const string RdfeOperationStatusTypeCreate = "Create";

        /// <summary>
        /// A valid value for the string field Microsoft.WindowsAzure.CloudServiceManagement.resource.OperationStatus.Type
        /// </summary>
        public const string RdfeOperationStatusTypeDelete = "Delete";

        /// <summary>
        /// A valid value for the string field Microsoft.WindowsAzure.CloudServiceManagement.resource.OperationStatus.Result
        /// </summary>
        public const string RdfeOperationStatusResultSucceeded = "Succeeded";

        /// <summary>
        /// A valid value for the string field Microsoft.WindowsAzure.CloudServiceManagement.resource.OperationStatus.Failed
        /// </summary>
        public const string RdfeOperationStatusResultFailed = "Failed";

        /// <summary>
        /// A valid value for the string field Microsoft.WindowsAzure.CloudServiceManagement.resource.OperationStatus.InProgress
        /// </summary>
        public const string RdfeOperationStatusResultInProgress = "InProgress";

        /// <summary>
        /// Cloud service name prefix
        /// </summary>
        public const string CloudServiceNameExtensionPrefix = "CS-";

        /// <summary>
        /// Cloud service name suffix
        /// </summary>
        public const string CloudServiceNameExtensionSuffix = "-RecoveryServices";

        /// <summary>
        /// Schema Version of RP
        /// </summary>
        public const string RpSchemaVersion = "1.1";

        /// <summary>
        /// Resource Provider Namespace.
        /// </summary>
        public const string ResourceNamespace = "WAHyperVRecoveryManager";

        /// <summary>
        /// Represents None string value.
        /// </summary>
        public const string None = "None";

        /// <summary>
        /// Represents Existing string value.
        /// </summary>
        public const string Existing = "Existing";

        /// <summary>
        /// Represents New string value.
        /// </summary>
        public const string New = "New";

        /// <summary>
        /// Represents direction primary to secondary.
        /// </summary>
        public const string PrimaryToRecovery = "PrimaryToRecovery";

        /// <summary>
        /// Represents direction secondary to primary.
        /// </summary>
        public const string RecoveryToPrimary = "RecoveryToPrimary";

        /// <summary>
        /// Represents Optimize value ForDowntime.
        /// </summary>
        public const string ForDowntime = "ForDowntime";

        /// <summary>
        /// Represents Optimize value for Synchronization.
        /// </summary>
        public const string ForSynchronization = "ForSynchronization";

        /// <summary>
        /// Represents primary location.
        /// </summary>
        public const string PrimaryLocation = "Primary";

        /// <summary>
        /// Represents Recovery location.
        /// </summary>
        public const string RecoveryLocation = "Recovery";

        /// <summary>
        /// Represents HyperVReplica string constant.
        /// </summary>
        public const string HyperVReplica2012 = "HyperVReplica2012";

        /// <summary>
        /// Represents HyperVReplicaBlue string constant.
        /// </summary>
        public const string HyperVReplica2012R2 = "HyperVReplica2012R2";

        /// <summary>
        /// Represents HyperVReplica string constant.
        /// </summary>
        public const string HyperVReplicaAzure = "HyperVReplicaAzure";

        /// <summary>
        /// Represents San string constant.
        /// </summary>
        public const string San = "San";

        /// <summary>
        /// Represents HyperVReplica string constant.
        /// </summary>
        public const string AzureContainer = "Microsoft Azure";

        /// <summary>
        /// Represents OnlineReplicationMethod string constant.
        /// </summary>
        public const string OnlineReplicationMethod = "Online";

        /// <summary>
        /// Represents OfflineReplicationMethod string constant.
        /// </summary>
        public const string OfflineReplicationMethod = "Offline";

        /// <summary>
        /// Represents OS Windows.
        /// </summary>
        public const string OSWindows = "Windows";

        /// <summary>
        /// Represents OS Linux.
        /// </summary>
        public const string OSLinux = "Linux";

        /// <summary>
        /// Represents Enable protection.
        /// </summary>
        public const string EnableProtection = "Enable";

        /// <summary>
        /// Represents Disable protection.
        /// </summary>
        public const string DisableProtection = "Disable";

        /// <summary>
        /// Represents Direction string value.
        /// </summary>
        public const string Direction = "Direction";

        /// <summary>
        /// Represents RPId string value.
        /// </summary>
        public const string RPId = "RPId";

        /// <summary>
        /// Represents ID string value.
        /// </summary>
        public const string ID = "ID";

        /// <summary>
        /// Represents NetworkType string value.
        /// </summary>
        public const string NetworkType = "NetworkType";

        /// <summary>
        /// Represents ProtectionEntityId string value.
        /// </summary>
        public const string ProtectionEntityId = "ProtectionEntityId";

        /// <summary>
        /// Azure fabric Id. In E2A context Recovery Server Id is always this.
        /// </summary>
        public const string AzureFabricId = "21a9403c-6ec1-44f2-b744-b4e50b792387";

        /// <summary>
        /// Authentication Type as Certificate based authentication.
        /// </summary>
        public const string AuthenticationTypeCertificate = "Certificate";

        /// <summary>
        /// Authentication Type as Kerberos.
        /// </summary>
        public const string AuthenticationTypeKerberos = "Kerberos";

        /// <summary>
        /// Acceptable values of Replication Frequency in seconds (as per portal).
        /// </summary>
        public const string Thirty = "30";

        /// <summary>
        /// Acceptable values of Replication Frequency in seconds (as per portal).
        /// </summary>
        public const string ThreeHundred = "300";

        /// <summary>
        /// Acceptable values of Replication Frequency in seconds (as per portal).
        /// </summary>
        public const string NineHundred = "900";

        /// <summary>
        /// Replication type - async.
        /// </summary>
        public const string Sync = "Sync";

        /// <summary>
        /// Replication type - async.
        /// </summary>
        public const string Async = "Async";

        /// <summary>
        /// SourceSiteOperations - Required.
        /// </summary>
        public const string Required = "Required";

        /// <summary>
        /// SourceSiteOperations - NotRequired.
        /// </summary>
        public const string NotRequired = "NotRequired";

        /// <summary>
        /// FabricType - VMM.
        /// </summary>
        public const string VMM = "VMM";

        /// <summary>
        /// FabricType - HyperVSite.
        /// </summary>
        public const string HyperVSite = "HyperVSite";

        /// <summary>
        /// FabricType - VMware.
        /// </summary>
        public const string VMware = "VMware";

        /// <summary>
        /// Nic Selection Type - NotSelected
        /// </summary>
        public const string NotSelected = "NotSelected";

        /// <summary>
        /// Nic Selection Type - SelectedByDefault
        /// </summary>
        public const string SelectedByDefault = "SelectedByDefault";

        /// <summary>
        /// Nic Selection Type - SelectedByUser
        /// </summary>
        public const string SelectedByUser = "SelectedByUser";
    }

     /// <summary>
    /// ARM Resource Type Constants
    /// </summary>
    public static class ARMResourceTypeConstants
    {
        /// <summary>
        /// Subscriptions
        /// </summary>
        public const string Subscriptions = "subscriptions";

        /// <summary>
        /// Resource Groups
        /// </summary>
        public const string ResourceGroups = "resourceGroups";

        /// <summary>
        /// Providers
        /// </summary>
        public const string Providers = "providers";

        /// <summary>
        /// Site Recovery Vault
        /// </summary>
        public const string SiteRecoveryVault = "SiteRecoveryVault";

        /// <summary>
        /// Recovery Services Vault
        /// </summary>
        public const string RecoveryServicesVault = "Vaults";

        /// <summary>
        /// Replication Policies
        /// </summary>
        public const string ReplicationPolicies = "replicationPolicies";

        /// <summary>
        /// Replication Fabrics
        /// </summary>
        public const string ReplicationFabrics = "replicationFabrics";

        /// <summary>
        /// Replication Protection Containers
        /// </summary>
        public const string ReplicationProtectionContainers = "replicationProtectionContainers";

        /// <summary>
        /// Replication Protected Items
        /// </summary>
        public const string ReplicationProtectedItems = "replicationProtectedItems";
        
        /// <summary>
        /// Replication Networks
        /// </summary>
        public const string ReplicationNetworks = "replicationNetworks";

        /// <summary>
        /// Virtual Networks
        /// </summary>
        public const string VirtualNetworks = "virtualNetworks";
    }
}
