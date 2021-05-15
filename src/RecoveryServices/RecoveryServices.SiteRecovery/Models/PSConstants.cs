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

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     General Constant definition
    /// </summary>
    public static class Constants
    {
        /// <summary>
        ///     Represents A2A string constant.
        /// </summary>
        public const string A2A = "A2A";

        /// <summary>
        ///     Represents Type of health event.
        /// </summary>
        public const string AgentHealth = "AgentHealth";

        /// <summary>
        ///     ASR vault type
        /// </summary>
        public const string ASRVaultType = "HyperVRecoveryManagerVault";

        /// <summary>
        ///     Replication type - async.
        /// </summary>
        public const string Async = "Async";

        /// <summary>
        ///     Authentication Type as Certificate based authentication.
        /// </summary>
        public const string AuthenticationTypeCertificate = "Certificate";

        /// <summary>
        ///     Authentication Type as Kerberos.
        /// </summary>
        public const string AuthenticationTypeKerberos = "Kerberos";

        /// <summary>
        ///     Represents HyperVReplica string constant.
        /// </summary>
        public const string AzureContainer = "Microsoft Azure";

        /// <summary>
        /// FabricType - Azure.
        /// </summary>
        public const string Azure = "Azure";

        /// <summary>
        ///     Azure fabric Id. In E2A context Recovery Server Id is always this.
        /// </summary>
        public const string AzureFabricId = "21a9403c-6ec1-44f2-b744-b4e50b792387";

        /// <summary>
        ///     Represents AzureToAzure string constant.
        /// </summary>
        public const string AzureToAzureFabric = "AzureToAzure";

        /// <summary>
        ///     Group Type: Boot
        /// </summary>
        public const string Boot = "Boot";

        /// <summary>
        ///     Failover deployment model: Classic
        /// </summary>
        public const string Classic = "Classic";

        /// <summary>
        /// Classic compute namespace.
        /// </summary>
        public const string ClassicCompute = "Microsoft.ClassicCompute";

        /// <summary>
        ///     Cloud service name prefix
        /// </summary>
        public const string CloudServiceNameExtensionPrefix = "CS-";

        /// <summary>
        ///     Cloud service name suffix
        /// </summary>
        public const string CloudServiceNameExtensionSuffix = "-RecoveryServices";

        /// <summary>
        /// Compute namespace.
        /// </summary>
        public const string Compute = "Microsoft.Compute";

        /// <summary>
        ///     Represents RecoveryVmCreationOption value for CreateVmIfNotFound in failback.
        /// </summary>
        public const string CreateVmIfNotFound = "CreateVmIfNotFound";

        /// <summary>
        ///     Name value for configure alert setting.
        /// </summary>
        public const string DefaultAlertSettingName = "DefaultAlertSetting";

        /// <summary>
        ///     Represents Direction string value.
        /// </summary>
        public const string Direction = "Direction";

        /// <summary>
        ///     Disable.
        /// </summary>
        public const string Disable = "Disable";

        /// <summary>
        ///     Disabled.
        /// </summary>
        public const string Disabled = "Disabled";

        /// <summary>
        ///     Represents Disable protection.
        /// </summary>
        public const string DisableProtection = "Disable";

        /// <summary>
        ///     Enable.
        /// </summary>
        public const string Enable = "Enable";

        /// <summary>
        ///     Enabled.
        /// </summary>
        public const string Enabled = "Enabled";

        /// <summary>
        ///     Represents Enable protection.
        /// </summary>
        public const string EnableProtection = "Enable";

        /// <summary>
        ///     Represents Existing string value.
        /// </summary>
        public const string Existing = "Existing";

        /// <summary>
        ///     Suffix to add in client request id while making SDS calls.
        /// </summary>
        public const string FabricDiscoveryClientRequestIdSuffix = "-Ps";

        /// <summary>
        ///     Group Type: Failover
        /// </summary>
        public const string Failover = "Failover";

        /// <summary>
        ///    false.
        /// </summary>
        public const string False = "False";

        /// <summary>
        ///     Represents Optimize value ForDowntime.
        /// </summary>
        public const string ForDownTime = "ForDownTime";

        /// <summary>
        ///     Represents Optimize value for Synchronization.
        /// </summary>
        public const string ForSynchronization = "ForSynchronization";

        /// <summary>
        ///     Represents HyperVReplica string constant.
        /// </summary>
        public const string HyperVReplica2012 = "HyperVReplica2012";

        /// <summary>
        ///     Represents HyperVReplicaBlue string constant.
        /// </summary>
        public const string HyperVReplica2012R2 = "HyperVReplica2012R2";

        /// <summary>
        ///     Represents HyperVReplica2012ReplicationDetails string constant.
        /// </summary>
        public const string HyperVReplica2012ReplicationDetails =
            "HyperVReplica2012ReplicationDetails";

        /// <summary>
        ///     Represents HyperVReplica string constant.
        /// </summary>
        public const string HyperVReplicaAzure = "HyperVReplicaAzure";

        /// <summary>
        ///     Represents HyperVReplicaAzureReplicationDetails string constant.
        /// </summary>
        public const string HyperVReplicaAzureReplicationDetails =
            "HyperVReplicaAzureReplicationDetails";

        /// <summary>
        ///     FabricType - HyperVSite.
        /// </summary>
        public const string HyperVSite = "HyperVSite";

        /// <summary>
        ///     Represents ID string value.
        /// </summary>
        public const string ID = "ID";

        /// <summary>
        ///     Represents InMage string constant.
        /// </summary>
        public const string InMage = "InMage";

        /// <summary>
        ///     Represents InMageAzureV2 string constant.
        /// </summary>
        public const string InMageAzureV2 = "InMageAzureV2";

        /// <summary>
        ///     Represents InMageAzureV2ProviderSpecificSettings string constant.
        /// </summary>
        public const string InMageAzureV2ProviderSpecificSettings =
            "InMageAzureV2ProviderSpecificSettings";

        /// <summary>
        ///     Represents InMageProviderSpecificSettings string constant.
        /// </summary>
        public const string InMageProviderSpecificSettings = "InMageProviderSpecificSettings";

        /// <summary>
        ///     Represents InMageRcm string constant.
        /// </summary>
        public const string InMageRcm = "InMageRcm";

        /// <summary>
        ///     Represents InMageRcmFailback string constant.
        /// </summary>
        public const string InMageRcmFailback = "InMageRcmFailback";

        /// <summary>
        ///     JSON field: InstanceType
        /// </summary>
        public const string InstanceType = "InstanceType";

        /// <summary>
        ///     The windows server license type for
        ///     HUB https://azure.microsoft.com/en-in/pricing/hybrid-use-benefit/
        /// </summary>
        public const string LicenseTypeWindowsServer = "WindowsServer";

        /// <summary>
        ///     No license type for SQL https://azure.microsoft.com/en-in/blog/azure-hybrid-benefit-for-sql-server-on-azure-virtual-machines/
        /// </summary>
        public const string NoLicenseTypeSql = "NoLicenseType";

        /// <summary>
        ///     The SQL server license type for 
        ///     PAYG https://azure.microsoft.com/en-in/blog/azure-hybrid-benefit-for-sql-server-on-azure-virtual-machines/
        /// </summary>
        public const string LicenseTypePAYG = "PAYG";

        /// <summary>
        ///     The SQL server license type for 
        ///     AHUB https://azure.microsoft.com/en-in/blog/azure-hybrid-benefit-for-sql-server-on-azure-virtual-machines/
        /// </summary>
        public const string LicenseTypeAHUB = "AHUB";

        /// <summary>
        ///     Represents NetworkType string value.
        /// </summary>
        public const string NetworkType = "NetworkType";

        /// <summary>
        ///     Never Enable RDP On Target Option while Enabling Protection for InMageAzureV2.
        /// </summary>
        public const string NeverEnableRDPOnTargetOption = "Never";

        /// <summary>
        ///     Represents New string value.
        /// </summary>
        public const string New = "New";

        /// <summary>
        ///     Represents Next page link.
        /// </summary>
        public const string NextPageLink = "nextPageLink";

        /// <summary>
        ///     Acceptable values of Replication Frequency in seconds (as per portal).
        /// </summary>
        public const string NineHundred = "900";

        /// <summary>
        ///     Represents No.
        /// </summary>
        public const string No = "No";

        /// <summary>
        ///     Represents RecoveryVmCreationOption value for NoAction in failback.
        /// </summary>
        public const string NoAction = "NoAction";

        /// <summary>
        ///     No license type for HUB https://azure.microsoft.com/en-in/pricing/hybrid-use-benefit/
        /// </summary>
        public const string NoLicenseType = "NoLicenseType";

        /// <summary>
        ///     Represents None string value.
        /// </summary>
        public const string None = "None";

        /// <summary>
        ///     Failover deployment model: NotApplicable
        /// </summary>
        public const string NotApplicable = "NotApplicable";

        /// <summary>
        ///     SourceSiteOperations - NotRequired.
        /// </summary>
        public const string NotRequired = "NotRequired";

        /// <summary>
        ///     Nic Selection Type - NotSelected
        /// </summary>
        public const string NotSelected = "NotSelected";

        /// <summary>
        ///     Represents OfflineReplicationMethod string constant.
        /// </summary>
        public const string OfflineReplicationMethod = "Offline";

        /// <summary>
        ///     Represents OnlineReplicationMethod string constant.
        /// </summary>
        public const string OnlineReplicationMethod = "Online";

        /// <summary>
        ///     Represents string constant for OperatingSystem.
        /// </summary>
        public const string OperatingSystem = "OperatingSystem";

        /// <summary>
        ///     Represents OS Linux.
        /// </summary>
        public const string OSLinux = "Linux";

        /// <summary>
        ///     Represents OS Windows.
        /// </summary>
        public const string OSWindows = "Windows";

        /// <summary>
        ///     Represents Premium_LRS storage account.
        /// </summary>
        public const string Premium_LRS = "Premium_LRS";

        /// <summary>
        ///     Represents primary location.
        /// </summary>
        public const string PrimaryLocation = "Primary";

        /// <summary>
        ///     Represents direction primary to secondary.
        /// </summary>
        public const string PrimaryToRecovery = "PrimaryToRecovery";

        /// <summary>
        ///     Represents ProtectionEntityId string value.
        /// </summary>
        public const string ProtectionEntityId = "ProtectionEntityId";

        /// <summary>
        ///     A valid value for the string field
        ///     Microsoft.WindowsAzure.CloudServiceManagement.resource.OperationStatus.Failed
        /// </summary>
        public const string RdfeOperationStatusResultFailed = "Failed";

        /// <summary>
        ///     A valid value for the string field
        ///     Microsoft.WindowsAzure.CloudServiceManagement.resource.OperationStatus.InProgress
        /// </summary>
        public const string RdfeOperationStatusResultInProgress = "InProgress";

        /// <summary>
        ///     A valid value for the string field
        ///     Microsoft.WindowsAzure.CloudServiceManagement.resource.OperationStatus.Result
        /// </summary>
        public const string RdfeOperationStatusResultSucceeded = "Succeeded";

        /// <summary>
        ///     A valid value for the string field
        ///     Microsoft.WindowsAzure.CloudServiceManagement.resource.OperationStatus.Type
        /// </summary>
        public const string RdfeOperationStatusTypeCreate = "Create";

        /// <summary>
        ///     A valid value for the string field
        ///     Microsoft.WindowsAzure.CloudServiceManagement.resource.OperationStatus.Type
        /// </summary>
        public const string RdfeOperationStatusTypeDelete = "Delete";

        /// <summary>
        ///     Represents Recovery location.
        /// </summary>
        public const string RecoveryLocation = "Recovery";

        /// <summary>
        ///     Recovery Tag for application consistent recovery point type.
        /// </summary>
        public const string RecoveryTagApplicationConsistent = "RecoveryTagApplicationConsistent";

        /// <summary>
        ///     Recovery Tag for crash consistent recovery point type.
        /// </summary>
        public const string RecoveryTagCrashConsistent = "RecoveryTagCrashConsistent";

        /// <summary>
        ///     Recovery Tag for Latest Recovery Point.
        /// </summary>
        public const string RecoveryTagLatest = "Latest";

        /// <summary>
        ///     Recovery Tag for Latest Available Recovery Point.
        /// </summary>
        public const string RecoveryTagLatestAvailable = "LatestAvailable";

        /// <summary>
        ///     Recovery Tag for Latest Available Application Consistent Recovery Point.
        /// </summary>
        public const string RecoveryTagLatestAvailableApplicationConsistent =
            "LatestAvailableApplicationConsistent";

        /// <summary>
        ///     Recovery Tag for Latest Available Application Consistent Recovery Point.
        /// </summary>
        public const string RecoveryTagLatestAvailableCrashConsistent =
            "LatestAvailableCrashConsistent";

        /// <summary>
        ///     Represents direction secondary to primary.
        /// </summary>
        public const string RecoveryToPrimary = "RecoveryToPrimary";

        /// <summary>
        ///     SourceSiteOperations - Required.
        /// </summary>
        public const string Required = "Required";

        /// <summary>
        ///     Failover deployment model: ResourceMananger
        /// </summary>
        public const string ResourceManager = "ResourceManager";

        /// <summary>
        ///     Resource Provider Namespace.
        /// </summary>
        public const string ResourceNamespace = "WAHyperVRecoveryManager";

        /// <summary>
        ///     Represents RPId string value.
        /// </summary>
        public const string RPId = "RPId";

        /// <summary>
        ///     Schema Version of RP
        /// </summary>
        public const string RpSchemaVersion = "1.1";

        /// <summary>
        ///     Represents San string constant.
        /// </summary>
        public const string San = "San";

        /// <summary>
        ///     Nic Selection Type - SelectedByDefault
        /// </summary>
        public const string SelectedByDefault = "SelectedByDefault";

        /// <summary>
        ///     Secondary Vm on Recovery cloud
        /// </summary>
        public const string SecondaryVMOnRecoveryCloud = "SecondaryVMOnRecoveryCloud";

        /// <summary>
        ///     Nic Selection Type - SelectedByUser
        /// </summary>
        public const string SelectedByUser = "SelectedByUser";

        /// <summary>
        ///     Represents Type of health event.
        /// </summary>
        public const string ServerHealth = "ServerHealth";

        /// <summary>
        ///     Group Type: Shutdown
        /// </summary>
        public const string Shutdown = "Shutdown";

        /// <summary>
        ///     Replication type - async.
        /// </summary>
        public const string Sync = "Sync";

        /// <summary>
        ///     Represents Standard_LRS storage account.
        /// </summary>
        public const string Standard_LRS = "Standard_LRS";

        /// <summary>
        ///     Represents StandardSSD_LRS storage account.
        /// </summary>
        public const string StandardSSD_LRS = "StandardSSD_LRS";

        /// <summary>
        ///     Represents Standard_SSD storage account.
        /// </summary>
        public const string Standard_SSD = "Standard_SSD";

        /// <summary>
        ///     Azure VM temporary disk name, to be excluded as part of switch protection.
        /// </summary>
        public const string TemporaryStorage = "Temporary Storage";

        /// <summary>
        ///     Acceptable values of Replication Frequency in seconds (as per portal).
        /// </summary>
        public const string Thirty = "30";

        /// <summary>
        ///     Acceptable values of Replication Frequency in seconds (as per portal).
        /// </summary>
        public const string ThreeHundred = "300";

        /// <summary>
        ///    True.
        /// </summary>
        public const string True = "True";

        /// <summary>
        ///     Vault Credential version.
        /// </summary>
        public const string VaultCredentialVersion = "1.0";

        /// <summary>
        ///     extended information version.
        /// </summary>
        public const string VaultExtendedInfoContractVersion = "V2014_09";

        /// <summary>
        ///     The version of Extended resource info.
        /// </summary>
        public const string VaultSecurityInfoVersion = "1.0";

        /// <summary>
        ///     Represents Type of health event.
        /// </summary>
        public const string VmHealth = "VmHealth";

        /// <summary>
        ///     FabricType - VMM.
        /// </summary>
        public const string VMM = "VMM";

        /// <summary>
        ///     Represents VmmToAzureFabric string constant.
        /// </summary>
        public const string VmmToAzureFabric = "VmmToAzure";

        /// <summary>
        ///     Represents VmmToVmmFabric string constant.
        /// </summary>
        public const string VmmToVmmFabric = "VmmToVmm";

        /// <summary>
        ///     FabricType - VMware.
        /// </summary>
        public const string VMware = "VMware";

        /// <summary>
        ///     Represents Yes.
        /// </summary>
        public const string Yes = "Yes";

        /// <summary>
        /// Represents use of recovery cloud service provided by user for test failover.
        /// </summary>
        public const string UseRecoveryCloudService = "UseRecoveryCloudService";

        /// <summary>
        ///     Sets the Utc date time format.
        /// </summary>
        public const string UtcDateTimeFormat = "yyyy-MM-dd HH:mm:ssZ";

        /// <summary>
        /// Represents autocreation of cloud service for test failover.
        /// </summary>
        public const string AutoCreateCloudService = "AutoCreateCloudService";
    }

    /// <summary>
    ///     ARM Resource Type Constants
    /// </summary>
    public static class ARMResourceTypeConstants
    {
        /// <summary>
        ///     Alerts resource name.
        /// </summary>
        public const string Alerts = "replicationAlertSettings";

        /// <summary>
        ///     Azure Network.
        /// </summary>
        public const string AzureNetwork = "azureNetwork";

        /// <summary>
        /// Compute namespace.
        /// </summary>
        public const string Compute = "Microsoft.Compute";

        /// <summary>
        ///     Events resource name.
        /// </summary>
        public const string Events = "replicationEvents";

        /// <summary>
        ///     Jobs resource name.
        /// </summary>
        public const string Jobs = "replicationJobs";

        /// <summary>
        ///     Logical Networks resource name.
        /// </summary>
        public const string LogicalNetworks = "replicationLogicalNetworks";

        /// <summary>
        ///     Network Mappings resource name.
        /// </summary>
        public const string NetworkMappings = "replicationNetworkMappings";

        /// <summary>
        ///     Policies resource name.
        /// </summary>
        public const string Policies = "replicationPolicies";

        /// <summary>
        ///     Protectable Items resource name.
        /// </summary>
        public const string ProtectableItems = "replicationProtectableItems";

        /// <summary>
        ///     Protection container mappings resource name.
        /// </summary>
        public const string ProtectionContainerMappings = "replicationProtectionContainerMappings";

        /// <summary>
        ///     Providers
        /// </summary>
        public const string Providers = "providers";

        /// <summary>
        ///     RecoveryPlans resource name.
        /// </summary>
        public const string RecoveryPlans = "replicationRecoveryPlans";

        /// <summary>
        ///     Recovery Points resource name.
        /// </summary>
        public const string RecoveryPoints = "recoveryPoints";

        /// <summary>
        ///     Recovery provider resource name.
        /// </summary>
        public const string RecoveryServicesProviders = "replicationRecoveryServicesProviders";

        /// <summary>
        ///     RecoveryServices Resource ProviderNameSpace
        /// </summary>
        public const string RecoveryServicesResourceProviderNameSpace =
            "Microsoft.RecoveryServices";

        /// <summary>
        ///     Recovery Services Vault
        /// </summary>
        public const string RecoveryServicesVault = "vaults";

        /// <summary>
        ///      ARM resource type for virtual machines
        /// </summary>
        public static string VirtualMachine = "virtualMachines";

        /// <summary>
        ///     Replication Fabrics
        /// </summary>
        public const string ReplicationFabrics = "replicationFabrics";

        /// <summary>
        ///     Replication Networks
        /// </summary>
        public const string ReplicationNetworks = "replicationNetworks";

        /// <summary>
        ///     Replication Policies
        /// </summary>
        public const string ReplicationPolicies = "replicationPolicies";

        /// <summary>
        ///     Replication Protected Items
        /// </summary>
        public const string ReplicationProtectedItems = "replicationProtectedItems";

        /// <summary>
        ///     Replication Protected Items
        /// </summary>
        public const string ReplicationProtectableItems = "replicationProtectableItems";

        /// <summary>
        ///     Replication Protection Containers
        /// </summary>
        public const string ReplicationProtectionContainers = "replicationProtectionContainers";

        /// <summary>
        ///     Replication Vault Usages.
        /// </summary>
        public const string ReplicationVaultUsages = "replicationUsages";

        /// <summary>
        ///     Resource Groups
        /// </summary>
        public const string ResourceGroups = "resourceGroups";

        /// <summary>
        ///     SiteRecovery Resource ProviderNameSpace
        /// </summary>
        public const string SiteRecoveryResourceProviderNameSpace =
            "Microsoft.RecoveryServices.SiteRecovery";

        /// <summary>
        ///     Site Recovery Vault
        /// </summary>
        public const string SiteRecoveryVault = "SiteRecoveryVault";

        /// <summary>
        ///     Storage classification resource name.
        /// </summary>
        public const string StorageClassification = "replicationStorageClassifications";

        /// <summary>
        ///     Storage classification mapping resource name.
        /// </summary>
        public const string StorageClassificationMapping =
            "replicationStorageClassificationMappings";

        /// <summary>
        ///     Subscriptions
        /// </summary>
        public const string Subscriptions = "subscriptions";

        /// <summary>
        ///     List Recovery Azure Vm size operation name.
        /// </summary>
        public const string TargetComputeSizes = "targetComputeSizes";

        /// <summary>
        ///     Vault Usages.
        /// </summary>
        public const string VaultUsages = "usages";

        /// <summary>
        ///     vCenters resource name.
        /// </summary>
        public const string vCenters = "replicationvCenters";

        /// <summary>
        ///     Virtual Networks
        /// </summary>
        public const string VirtualNetworks = "virtualNetworks";
    }

    /// <summary>
    ///     Constants for current version.
    /// </summary>
    public class ARMResourceIdPaths
    {
        /// <summary>
        ///     ARM resource path for event.
        /// </summary>
        public const string AlertsResourceIdPath = ARMRoutePathConstants.AlertsRoutePath + "/{0}";

        /// <summary>
        ///     ARM resource path for event.
        /// </summary>
        public const string EventResourceIdPath = ARMRoutePathConstants.EventsRoutePath + "/{0}";

        /// <summary>
        ///     ARM resource path for fabric.
        /// </summary>
        public const string FabricResourceIdPath = ARMRoutePathConstants.FabricsRoutePath + "/{0}";

        /// <summary>
        ///     ARM resource path for Jobs.
        /// </summary>
        public const string JobResourceIdPath = ARMRoutePathConstants.JobsRoutePath + "/{0}";

        /// <summary>
        ///     ARM resource path for LogicalNetworks.
        /// </summary>
        public const string LogicalNetworkResourceIdPath =
            FabricResourceIdPath + "/" + ARMResourceTypeConstants.LogicalNetworks + "/{1}";

        /// <summary>
        ///     ARM resource path for Network Mappings.
        /// </summary>
        public const string NetworkMappingResourceIdPath =
            NetworkResourceIdPath + "/" + ARMResourceTypeConstants.NetworkMappings + "/{2}";

        /// <summary>
        ///     ARM resource path for Networks.
        /// </summary>
        public const string NetworkResourceIdPath =
            FabricResourceIdPath + "/" + ARMResourceTypeConstants.ReplicationNetworks + "/{1}";

        /// <summary>
        ///     ARM resource path for Policies.
        /// </summary>
        public const string PolicyResourceIdPath = ARMRoutePathConstants.PoliciesRoutePath + "/{0}";

        /// <summary>
        ///     ARM resource path for ProtectableItems.
        /// </summary>
        public const string ProtectableItemResourceIdPath =
            ProtectionContainerResourceIdPath +
            "/" +
            ARMResourceTypeConstants.ProtectableItems +
            "/{2}";

        /// <summary>
        ///     ARM resource path for protection container mappings.
        /// </summary>
        public const string ProtectionContainerMappingResourceIdPath =
            ProtectionContainerResourceIdPath +
            "/" +
            ARMResourceTypeConstants.ProtectionContainerMappings +
            "/{2}";

        /// <summary>
        ///     ARM resource path for recovery services providers.
        /// </summary>
        public const string ProtectionContainerResourceIdPath =
            FabricResourceIdPath +
            "/" +
            ARMResourceTypeConstants.ReplicationProtectionContainers +
            "/{1}";

        /// <summary>
        ///     ARM resource path for RecoveryPlans.
        /// </summary>
        public const string RecoveryPlanResourceIdPath =
            ARMRoutePathConstants.RecoveryPlansRoutePath + "/{0}";

        /// <summary>
        ///     ARM resource path for RecoveryPoints.
        /// </summary>
        public const string RecoveryPointResourceIdPath =
            ReplicatedProtectedItemResourceIdPath +
            "/" +
            ARMResourceTypeConstants.RecoveryPoints +
            "/{3}";

        /// <summary>
        ///     ARM resource path for recovery services providers.
        /// </summary>
        public const string RecoveryServicesProviderResourceIdPath =
            FabricResourceIdPath +
            "/" +
            ARMResourceTypeConstants.RecoveryServicesProviders +
            "/{1}";

        /// <summary>
        ///     ARM resource path for ReplicatedProtectedItems.
        /// </summary>
        public const string ReplicatedProtectedItemResourceIdPath =
            ProtectionContainerResourceIdPath +
            "/" +
            ARMResourceTypeConstants.ReplicationProtectedItems +
            "/{2}";

        /// <summary>
        ///     SRS ARM Url Pattern.
        /// </summary>
        public const string SRSArmUrlPattern =
            "/Subscriptions/{0}/resourceGroups/{1}/providers/{2}/{3}/{4}";

        /// <summary>
        ///     ARM resource path for storage classification mapping.
        /// </summary>
        public const string StorageClassificationMappingResourceIdPath =
            StorageClassificationResourceIdPath +
            "/" +
            ARMResourceTypeConstants.StorageClassificationMapping +
            "/{2}";

        /// <summary>
        ///     ARM resource path for storage classification.
        /// </summary>
        public const string StorageClassificationResourceIdPath =
            FabricResourceIdPath + "/" + ARMResourceTypeConstants.StorageClassification + "/{1}";

        /// <summary>
        ///     ARM Resource path for Vcenters.
        /// </summary>
        public const string vCenterResourceIdPath =
            FabricResourceIdPath + "/" + ARMResourceTypeConstants.vCenters + "/{1}";

        #region External ARM Resource Id

        /// <summary>
        ///     Storage account ARM Id.
        /// </summary>
        public const string StorageAccountArmId =
            "/subscriptions/{0}/resourceGroups/{1}/providers/{2}/storageAccounts/{3}";

        /// <summary>
        ///     ARM resource path for Azure Networks.
        /// </summary>
        public const string AzureNetworksPath =
            "/subscriptions/{0}/resourceGroups/{1}/providers/{2}/virtualNetworks/{3}";

        /// <summary>
        ///     Automation runbook ARM Id.
        /// </summary>
        public const string AutomationRunbookArmId =
                "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Automation/automationAccounts/{2}/runbooks/{3}"
            ;

        #endregion
    }

    /// <summary>
    ///     Constants for Route paths.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related classes together.")]
    public class ARMRoutePathConstants
    {
        /// <summary>
        ///     Alerts route path.
        /// </summary>
        public const string AlertsRoutePath = ARMResourceTypeConstants.Alerts;

        /// <summary>
        ///     Events route path.
        /// </summary>
        public const string EventsRoutePath = ARMResourceTypeConstants.Events;

        /// <summary>
        ///     Fabric route path.
        /// </summary>
        public const string FabricsRoutePath = ARMResourceTypeConstants.ReplicationFabrics;

        /// <summary>
        ///     Jobs route path.
        /// </summary>
        public const string JobsRoutePath = ARMResourceTypeConstants.Jobs;

        /// <summary>
        ///     Replication Logical Networks Route Path
        /// </summary>
        public const string LogicalNetworksRoutePath =
            FabricsRoutePath + "/{fabricName}/" + ARMResourceTypeConstants.LogicalNetworks;

        /// <summary>
        ///     Network Mappings Route Path
        /// </summary>
        public const string NetworkMappingsRoutePath =
            NetworksRoutePath + "/{networkName}/" + ARMResourceTypeConstants.NetworkMappings;

        /// <summary>
        ///     Replication Networks Route Path
        /// </summary>
        public const string NetworksRoutePath = FabricsRoutePath +
            "/{fabricName}/" +
            ARMResourceTypeConstants.ReplicationNetworks;

        /// <summary>
        ///     Operations route path.
        /// </summary>
        public const string OperationsRoutePath = "operations";

        /// <summary>
        ///     Jobs route path.
        /// </summary>
        public const string PoliciesRoutePath = ARMResourceTypeConstants.Policies;

        /// <summary>
        ///     ProtectableItems route path.
        /// </summary>
        public const string ProtectableItemsRoutePath =
            ProtectionContainersRoutePath +
            "/{protectionContainerName}/" +
            ARMResourceTypeConstants.ProtectableItems;

        /// <summary>
        ///     Protection container mappings path.
        /// </summary>
        public const string ProtectionContainerMappingsRoutePath =
            ProtectionContainersRoutePath +
            "/{protectionContainerName}/" +
            ARMResourceTypeConstants.ProtectionContainerMappings;

        /// <summary>
        ///     ProtectionContainer route path.
        /// </summary>
        public const string ProtectionContainersRoutePath =
            FabricsRoutePath +
            "/{fabricName}/" +
            ARMResourceTypeConstants.ReplicationProtectionContainers;

        /// <summary>
        ///     Jobs route path.
        /// </summary>
        public const string RecoveryPlansRoutePath = ARMResourceTypeConstants.RecoveryPlans;

        /// <summary>
        ///     RecoveryPoints route path.
        /// </summary>
        public const string RecoveryPointsRoutePath =
            ReplicationProtectedItemsRoutePath +
            "/{replicatedProtectedItemName}/" +
            ARMResourceTypeConstants.RecoveryPoints;

        /// <summary>
        ///     RecoveryServicesProvider route path.
        /// </summary>
        public const string RecoveryServicesProvidersRoutePath =
            FabricsRoutePath +
            "/{fabricName}/" +
            ARMResourceTypeConstants.RecoveryServicesProviders;

        /// <summary>
        ///     RecoveryServicesProvider view API route path.
        /// </summary>
        public const string RecoveryServicesProvidersViewRoutePath =
            ARMResourceTypeConstants.RecoveryServicesProviders;

        /// <summary>
        ///     ReplicatedProtectedItems route path.
        /// </summary>
        public const string ReplicationProtectedItemsRoutePath =
            ProtectionContainersRoutePath +
            "/{protectionContainerName}/" +
            ARMResourceTypeConstants.ReplicationProtectedItems;

        /// <summary>
        ///     Storage mapping route path.
        /// </summary>
        public const string StorageClassificationMappingRoutePath =
            StorageClassificationRoutePath +
            "/{storageClassificationName}/" +
            ARMResourceTypeConstants.StorageClassificationMapping;

        /// <summary>
        ///     Storage route path.
        /// </summary>
        public const string StorageClassificationRoutePath =
            FabricsRoutePath + "/{fabricName}/" + ARMResourceTypeConstants.StorageClassification;

        /// <summary>
        ///     Operations route path.
        /// </summary>
        public const string TargetComputesSizesPath =
            ReplicationProtectedItemsRoutePath +
            "/{replicatedProtectedItemName}/" +
            ARMResourceTypeConstants.TargetComputeSizes;

        /// <summary>
        ///     Vault level ProtectionContainerMappings route path.
        /// </summary>
        public const string VaultLevelProtectionContainerMappingsRoutePath =
            ARMResourceTypeConstants.ProtectionContainerMappings;

        /// <summary>
        ///     Vault level ProtectionContainers route path.
        /// </summary>
        public const string VaultLevelProtectionContainersRoutePath =
            ARMResourceTypeConstants.ReplicationProtectionContainers;

        /// <summary>
        ///     Vault level ReplicatedProtectedItems route path.
        /// </summary>
        public const string VaultLevelReplicationProtectedItemsRoutePath =
            ARMResourceTypeConstants.ReplicationProtectedItems;

        /// <summary>
        ///     Vault level storage classification mapping route path.
        /// </summary>
        public const string VaultLevelStorageClassificationMappingRoutePath =
            ARMResourceTypeConstants.StorageClassificationMapping;

        /// <summary>
        ///     Vault level storage classification route path.
        /// </summary>
        public const string VaultLevelStorageClassificationRoutePath =
            ARMResourceTypeConstants.StorageClassification;

        /// <summary>
        ///     vCenters route path.
        /// </summary>
        public const string vCentersRoutePath = FabricsRoutePath +
            "/{fabricName}/" +
            ARMResourceTypeConstants.vCenters;
    }

    /// <summary>
    ///     Status of whether email alerts should be sent or not.
    /// </summary>
    public static class SendToOwners
    {
        /// <summary>
        ///     Indicates that email alerts must not be sent.
        /// </summary>
        public const string DoNotSend = "DoNotSend";

        /// <summary>
        ///     Indicates that email alerts is off for owners.
        /// </summary>
        public const string Off = "Off";

        /// <summary>
        ///     Indicates that email alerts is on for owners.
        /// </summary>
        public const string On = "On";

        /// <summary>
        ///     Indicates that email alerts must be sent.
        /// </summary>
        public const string Send = "Send";
    }

    /// <summary>
    ///     ASR Heatlth Event Severity mapped with Monitoring Event in SRS.
    /// </summary>
    public static class ASRHealthEventServerity
    {
        /// <summary>
        ///     Represents severity of the health event-Critical.
        /// </summary>
        public const string Critical = "Critical";

        /// <summary>
        ///     Represents severity of the health event - Ok.
        /// </summary>
        public const string OK = "OK";

        /// <summary>
        ///     Represents severity of the health event -Unknowns.
        /// </summary>
        public const string Unknown = "Unknown";

        /// <summary>
        ///     Represents severity of the health event -Warning.
        /// </summary>
        public const string Warning = "Warning";
    }

    /// <summary>
    /// Http headers.
    /// </summary>
    public static class HttpHeaders
    {
        /// <summary>
        /// Accept language header key.
        /// </summary>
        public const string AcceptLanguage = "accept-language";

        /// <summary>
        /// Client request Id header key.
        /// </summary>
        public const string ClientRequestId = "x-ms-client-request-id";

        /// <summary>
        /// Request Id header key.
        /// </summary>
        public const string RequestId = "x-ms-request-id";
    }
}
