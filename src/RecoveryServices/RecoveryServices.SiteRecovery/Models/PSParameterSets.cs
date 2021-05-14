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

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Parameter Sets used for Azure Site Recovery commands.
    /// </summary>
    internal static class ASRParameterSets
    {
        /// <summary>
        ///     Add protected entities to RP
        /// </summary>
        internal const string AddProtectedEntities = "AddProtectedEntities";

        /// <summary>
        ///     Add  replication protected items to RP
        /// </summary>
        internal const string AddReplicationProtectedItems = "AddReplicationProtectedItems";

        /// <summary>
        ///     To append group to RP.
        /// </summary>
        internal const string AppendGroup = "AppendGroup";

        /// <summary>
        ///     Handle ARS Vault.
        /// </summary>
        internal const string ARSVault = "AzureRecoveryServicesVault";

        /// </summary>
        /// Handle ASR Vault.
        /// </summary>
        internal const string ASRVault = "AzureSiteRecoveryVault";

        /// </summary>
        /// Handle ASR Vault - Azure Fabric.
        /// </summary>
        internal const string Azure = "Azure";

        /// </summary>
        /// Handle ASR Vault - A2A Fabric.
        /// </summary>
        internal const string AzureToAzure = "AzureToAzure";

        /// </summary>
        /// Handle ASR Vault - A2A Fabric.
        /// </summary>
        internal const string AzureToAzureWithoutDiskDetails = "AzureToAzureWithoutDiskDetails";
        
        /// </summary>
        /// Handle ASR Vault - Paramset for A2a ManagedDisk.
        /// </summary>
        internal const string AzureToAzureManagedDisk = "AzureToAzureManagedDisk";

        /// </summary>
        /// Handle ASR Vault - A2A Fabric name.
        /// </summary>
        internal const string AzureToAzureWithFabricName = "AzureToAzureWithFabricName";

        /// </summary>
        /// Handle ASR Vault - A2A Fabric -AzureToAzureWithMultipleStorageAccount.
        /// </summary>
        internal const string AzureToAzureWithMultipleStorageAccount = "AzureToAzureWithMultipleStorageAccount";

        /// </summary>
        /// Handle ASR Vault - A2A Zone to zone replication.
        /// </summary>
        internal const string AzureZoneToZone = "AzureZoneToZone";
        
        /// </summary>
        /// Handle ASR Vault.
        /// </summary>
        internal const string AzureToVMware = "AzureToVMware";

        /// <summary>
        ///     When only Name is passed to the command.
        /// </summary>
        internal const string ByFabricObject = "ByFabricObject";

        /// <summary>
        ///     When FabricId is passed to the command.
        /// </summary>
        internal const string ByFabricId = "ByFabricId";

        /// <summary>
        ///     When only Name is passed to the command.
        /// </summary>
        internal const string ByFabricName = "ByFabricName";

        /// <summary>
        ///     When only Name is passed to the command.
        /// </summary>
        internal const string ByFriendlyName = "ByFriendlyName";

        /// <summary>
        ///     When only Friendly Name is passed to the command Legacy.
        /// </summary>
        internal const string ByFriendlyNameLegacy = "ByFriendlyNameLegacy";

        /// <summary>
        ///     When only ID is passed to the command.
        /// </summary>
        internal const string ById = "ById";

        /// <summary>
        ///     When group of IDs are passed to the command.
        /// </summary>
        internal const string ByIDs = "ByIDs";

        /// <summary>
        ///     When group of IDs and ID are passed to the command.
        /// </summary>
        internal const string ByIDsWithId = "ByIDsWithId";

        /// <summary>
        ///     When group of IDs and Name are passed to the command.
        /// </summary>
        internal const string ByIDsWithName = "ByIDsWithName";

        /// <summary>
        ///     When only Name is passed to the command.
        /// </summary>
        internal const string ByName = "ByName";

        /// <summary>
        ///     When only NetworkName Fabric is passed to the command.
        /// </summary>
        internal const string ByNetworkNameFabric = "ByNetworkNameFabric";

        /// <summary>
        ///     When only NetworkName FabricName is passed to the command.
        /// </summary>
        internal const string ByNetworkNameFabricName = "ByNetworkNameFabricName";

        /// <summary>
        ///     When only Name is passed to the command Legacy.
        /// </summary>
        internal const string ByNameLegacy = "ByNameLegacy";

        /// <summary>
        ///     To define parameter set containing network object.
        /// </summary>
        internal const string ByNetworkObject = "ByNetworkObject";

        /// <summary>
        ///     When only Object is passed to the command.
        /// </summary>
        internal const string ByObject = "ByObject";

        /// <summary>
        ///     When Object and Name are passed to the command.
        /// </summary>
        internal const string ByObjectWithFriendlyName = "ByObjectWithFriendlyName";

        /// <summary>
        ///     When Object and Name are passed to the command Legacy.
        /// </summary>
        internal const string ByObjectWithFriendlyNameLegacy = "ByObjectWithFriendlyNameLegacy";

        /// <summary>
        ///     When Object and ID are passed to the command.
        /// </summary>
        internal const string ByObjectWithId = "ByObjectWithId";

        /// <summary>
        ///     When Object and Name are passed to the command.
        /// </summary>
        internal const string ByObjectWithName = "ByObjectWithName";

        /// <summary>
        ///     When Object and Site ID are passed to the command.
        /// </summary>
        internal const string ByObjectWithSiteId = "ByObjectWithSiteId";

        /// <summary>
        ///     When Object, Site ID and FriendlyName are passed to the command.
        /// </summary>
        internal const string ByObjectWithSiteIdAndFriendlyName = "ByObjectWithSiteIdAndFriendlyName";

        /// <summary>
        ///     When Object and Name are passed to the command Legacy.
        /// </summary>
        internal const string ByObjectWithNameLegacy = "ByObjectWithNameLegacy";

        /// <summary>
        ///     When parameters are passed to the command.
        /// </summary>
        internal const string ByParam = "ByParam";

        /// <summary>
        ///     When only PC and PE ids are passed to the command.
        /// </summary>
        internal const string ByPEId = "ByPEId";

        /// <summary>
        ///     When only PC and PE ids are passed along with logical network ID to the command.
        /// </summary>
        internal const string ByPEIdWithLogicalNetworkID = "ByPEIdWithLogicalNetworkID";

        /// <summary>
        ///     When only PC and PE ids are passed along with VM network to the command.
        /// </summary>
        internal const string ByPEIdWithVMNetwork = "ByPEIdWithVMNetwork";

        /// <summary>
        ///     When only PC and PE ids are passed along with VM network ID to the command.
        /// </summary>
        internal const string ByPEIdWithVMNetworkID = "ByPEIdWithVMNetworkID";

        /// <summary>
        ///     When only PE Object is passed to the command.
        /// </summary>
        internal const string ByPEObject = "ByPEObject";

        /// <summary>
        ///     When only PE Object with E2A provider is passed to the command.
        /// </summary>
        internal const string ByPEObjectE2A = "ByPEObjectE2A";

        /// <summary>
        ///     When only PE Object with E2A provider is passed to the failback command.
        /// </summary>
        internal const string ByPEObjectE2AFailback = "ByPEObjectE2AFailback";

        /// <summary>
        ///     When only PE Object is passed along with Logical VM network to the command.
        /// </summary>
        internal const string ByPEObjectWithAzureVMNetworkId = "ByPEObjectWithAzureVMNetworkId";

        /// <summary>
        ///     When only PE Object is passed along with logical network ID to the command.
        /// </summary>
        internal const string ByPEObjectWithLogicalNetworkID = "ByPEObjectWithLogicalNetworkID";

        /// <summary>
        ///     When only PE Object is passed along with Logical VM network to the command.
        /// </summary>
        internal const string ByPEObjectWithLogicalVMNetwork = "ByPEObjectWithLogicalVMNetwork";

        /// <summary>
        ///     When only PE Object is passed along with VM network to the command.
        /// </summary>
        internal const string ByPEObjectWithVMNetwork = "ByPEObjectWithVMNetwork";

        /// <summary>
        ///     When only PE Object is passed along with VM network ID to the command.
        /// </summary>
        internal const string ByPEObjectWithVMNetworkID = "ByPEObjectWithVMNetworkID";

        /// <summary>
        ///     When Object and Name are passed to the command.
        /// </summary>
        internal const string ByProtectableItemObject = "ByProtectableItemObject";

        /// <summary>
        ///     When only Name is ResourceId to the command.
        /// </summary>
        internal const string ByResourceId = "ByResourceId";

        /// <summary>
        ///     When only RP File is passed to the command.
        /// </summary>
        internal const string ByRPFile = "ByRPFile";

        /// <summary>
        ///     When only RP ID is passed to the command.
        /// </summary>
        internal const string ByRPId = "ByRPId";

        /// <summary>
        ///     When only RP Id is passed along with logical network ID to the command.
        /// </summary>
        internal const string ByRPIdWithLogicalNetworkID = "ByRPIdWithLogicalNetworkID";

        /// <summary>
        ///     When only RP Id is passed along with VM network to the command.
        /// </summary>
        internal const string ByRPIdWithVMNetwork = "ByRPIdWithVMNetwork";

        /// <summary>
        ///     When only RP Id is passed along with VM network ID to the command.
        /// </summary>
        internal const string ByRPIdWithVMNetworkID = "ByRPIdWithVMNetworkID";

        /// <summary>
        ///     When only RPI Object with RecoveryTag is passed to the command.currently used only in case on InMage.
        /// </summary>
        internal const string ByRPIObjectWithRecoveryTag = "ByRPIObjectWithRecoveryTag";

        /// <summary>
        ///     When only RPI Object is passed to the command.
        /// </summary>
        internal const string ByRPIObject = "ByRPIObject";

        /// <summary>
        ///     When only RPI Object is passed along with Logical VM network to the command.
        /// </summary>
        internal const string ByRPIObjectWithAzureVMNetworkId = "ByRPIObjectWithAzureVMNetworkId";

        /// <summary>
        ///     When only RPI Object is passed along with Logical VM network to the command.
        /// </summary>
        internal const string ByRPIObjectWithAzureVMNetworkIdAndRecoveryTag = "ByRPIObjectWithAzureVMNetworkIdAndRecoveryTag";

        /// <summary>
        ///     When only RPI Object is passed along with Logical VM network to the command.
        /// </summary>
        internal const string ByRPIObjectWithAzureVMNetworkIdAndRecoveryPoint = "ByRPIObjectWithAzureVMNetworkIdAndRecoveryPoint";

        /// <summary>
        ///     When only RPI Object is passed along with Logical VM network to the command.
        /// </summary>
        internal const string ByRPIObjectWithLogicalVMNetwork = "ByRPIObjectWithLogicalVMNetwork";

        /// <summary>
        ///     When only RPI Object is passed along with VM network to the command.
        /// </summary>
        internal const string ByRPIObjectWithVMNetwork = "ByRPIObjectWithVMNetwork";

        /// <summary>
        ///     When only RPI Object is passed along with VM network to the command.
        /// </summary>
        internal const string ByRPIObjectWithVMNetworkAndRecoveryTag = "ByRPIObjectWithVMNetworkAndRecoveryTag";

        /// <summary>
        ///     When only RPI Object is passed along with VM network to the command.
        /// </summary>
        internal const string ByRPIObjectWithVMNetworkAndRecoveryPoint = "ByRPIObjectWithVMNetworkAndRecoveryPoint";

        /// <summary>
        ///     When only RP Object is passed to the command.
        /// </summary>
        internal const string ByRPObject = "ByRPObject";

        /// <summary>
        ///     When only RP Object with E2A provider is passed to the command.
        /// </summary>
        internal const string ByRPObjectE2A = "ByRPObjectE2A";

        /// <summary>
        ///     When only RP Object with E2A provider is passed to the failback command.
        /// </summary>
        internal const string ByRPObjectE2AFailback = "ByRPObjectE2AFailback";

        /// <summary>
        ///     When only RP Object is passed along with Azure VM Network Id to the command.
        /// </summary>
        internal const string ByRPObjectWithAzureVMNetworkId = "ByRPObjectWithAzureVMNetworkId";

        /// <summary>
        ///     When only RP Object is passed along with Azure VM Network Id to the command.
        /// </summary>
        internal const string ByRPObjectWithAzureVMNetworkIdAndRecoveryTag = "ByRPObjectWithAzureVMNetworkIdAndRecoveryTag";

        /// <summary>
        ///     When only RP object is passed along with logical network ID to the command.
        /// </summary>
        internal const string ByRPObjectWithLogicalNetworkID = "ByRPObjectWithLogicalNetworkID";

        /// <summary>
        ///     When only RP Object is passed along with VM network to the command.
        /// </summary>
        internal const string ByRPObjectWithVMNetwork = "ByRPObjectWithVMNetwork";

        /// <summary>
        ///     When only RP Object is passed along with VM network to the command.
        /// </summary>
        internal const string ByRPObjectWithVMNetworkAndRecoveryTag = "ByRPObjectWithVMNetworkAndRecoveryTag";
        
        /// <summary>
        ///     When only RP Object is passed along with VM network ID to the command.
        /// </summary>
        internal const string ByRPObjectWithVMNetworkID = "ByRPObjectWithVMNetworkID";

        /// <summary>
        ///     When only Server Object is passed to the command.
        /// </summary>
        internal const string ByServerObject = "ByServerObject";

        /// <summary>
        ///     When only Server Object is passed to the command.
        /// </summary>
        internal const string ByTime = "ByTime";

        /// <summary>
        ///     When only Object type is passed to the command.
        /// </summary>
        internal const string ByType = "ByType";

        /// <summary>
        ///     When nothing is passed to the command.
        /// </summary>
        internal const string Default = "Default";

        /// <summary>
        ///     Disable
        /// </summary>
        internal const string Disable = "Disable";

        /// <summary>
        ///     DisableEmailToSubcriptionOwner setAlertSettings.
        /// </summary>
        internal const string DisableEmailToSubcriptionOwner = "DisableEmailToSubcriptionOwner";

        /// <summary>
        ///     Disable DR
        /// </summary>
        internal const string DisableDR = "DisableDR";

        /// <summary>
        ///     For Disable replication group parameter set.
        /// </summary>
        internal const string DisableReplicationGroup = "DisableReplicationGroup";

        /// <summary>
        ///     For Enable replication group parameter set.
        /// </summary>
        internal const string EnableReplicationGroup = "EnableReplicationGroup";

        /// <summary>
        ///     Mapping between Enterprise to Azure.
        /// </summary>
        internal const string EnterpriseToAzure = "EnterpriseToAzure";

        /// <summary>
        ///     Mapping between Enterprise to Azure.
        /// </summary>
        internal const string EnterpriseToAzureByName = "EnterpriseToAzureByName";

        /// <summary>
        ///     Mapping between Enterprise to Azure Legacy.
        /// </summary>
        internal const string EnterpriseToAzureLegacy = "EnterpriseToAzureLegacy";

        /// <summary>
        ///     Mapping between Enterprise to Enterprise.
        /// </summary>
        internal const string EnterpriseToEnterprise = "EnterpriseToEnterprise";

        /// <summary>
        ///     Mapping between Enterprise to Enterprise.
        /// </summary>
        internal const string EnterpriseToEnterpriseByName = "EnterpriseToEnterpriseByName";

        /// <summary>
        ///     Mapping between Enterprise to Enterprise Recovery Plan.
        /// </summary>
        internal const string EnterpriseToEnterpriseRP = "EnterpriseToEnterpriseRP";

        /// <summary>
        ///     Mapping between Enterprise to Enterprise Legacy.
        /// </summary>
        internal const string EnterpriseToEnterpriseLegacy = "EnterpriseToEnterpriseLegacy";

        /// <summary>
        ///     Mapping between Enterprise to Enterprise San.
        /// </summary>
        internal const string EnterpriseToEnterpriseSan = "EnterpriseToEnterpriseSan";

        /// <summary>
        ///     EmailSubscriptionOwner SetAlert.
        /// </summary>
        internal const string EmailToSubscriptionOwner = "EmailToSubscriptionOwner";

        /// <summary>
        ///     When only RP Object is passed to the command.
        /// </summary>
        internal const string ForSite = "ForSite";

        /// <summary>
        ///     Mapping between HyperV Site to Azure.
        /// </summary>
        internal const string HyperVSiteToAzure = "HyperVSiteToAzure";

        /// <summary>
        ///     Mapping between HyperV to Azure.
        /// </summary>
        internal const string HyperVToAzure = "HyperVToAzure";

        /// <summary>
        ///     Mapping between HyperV Site to Azure Recovery Plan.
        /// </summary>
        internal const string HyperVSiteToAzureRP = "HyperVSiteToAzureRP";

        /// <summary>
        ///     Mapping between HyperV to Azure Recovery Plan.
        /// </summary>
        internal const string HyperVToAzureRP = "HyperVToAzureRP";

        /// <summary>
        ///     Mapping between HyperV Site to Azure Legacy.
        /// </summary>
        internal const string HyperVSiteToAzureLegacy = "HyperVSiteToAzureLegacy";

        /// <summary>
        ///     To remove group from RP
        /// </summary>
        internal const string RemoveGroup = "RemoveGroup";

        /// <summary>
        ///     Remove protected entities from RP
        /// </summary>
        internal const string RemoveProtectedEntities = "RemoveProtectedEntities";

        /// <summary>
        ///     Remove replication protected items from RP
        /// </summary>
        internal const string RemoveReplicationProtectedItems = "RemoveReplicationProtectedItems";

        /// <summary>
        /// Mapping for Azure to VMware using RCM.
        /// </summary>
        internal const string ReplicateAzureToVMware = "ReplicateAzureToVMware";

        /// <summary>
        ///     Mapping for VMware to Azure using RCM.
        /// </summary>
        internal const string ReplicateVMwareToAzure = "ReplicateVMwareToAzure";

        /// <summary>
        ///     Mapping for VMware to Azure using RCM with disk input.
        /// </summary>
        internal const string ReplicateVMwareToAzureWithDiskInput = "ReplicateVMwareToAzureWithDiskInput";

        /// <summary>
        ///     Set alerts to send to owners.
        /// </summary>
        internal const string SendToOwners = "SendToOwners";

        /// <summary>
        ///     Set alerts to send to owners.
        /// </summary>
        internal const string Set = "Set";

        /// <summary>
        ///     Set email addresses.
        /// </summary>
        internal const string SetEmail = "SetEmail";

        /// <summary>
        ///     Mapping for VMware to Azure.
        /// </summary>
        internal const string VMwareToAzure = "VMwareToAzure";

        /// <summary>
        ///     Mapping for both VMware to Azure and VMware to VMware.
        /// </summary>
        internal const string VMwareToAzureAndVMwareToVMware = "VMwareToAzureAndVMwareToVMware";

        /// <summary>
        ///     Mapping for both VMware to Azure and VMware to VMware for RP.
        /// </summary>
        internal const string VMwareToAzureAndVMwareToVMwareRP = "VMwareToAzureAndVMwareToVMwareRP";

        /// <summary>
        ///     Mapping for both VMware to Azure and VMware to VMware for RPI.
        /// </summary>
        internal const string VMwareToAzureAndVMwareToVMwareRPI =
            "VMwareToAzureAndVMwareToVMwareRPI";

        /// <summary>
        ///     Mapping for VMware to Azure for RP.
        /// </summary>
        internal const string VMwareToAzureRP = "VMwareToAzureRP";

        /// <summary>
        ///     Mapping for VMware to Azure for RPI.
        /// </summary>
        internal const string VMwareToAzureRPI = "VMwareToAzureRPI";

        /// <summary>
        ///     Mapping for VMware to VMware.
        /// </summary>
        internal const string VMWareToVMWare = "VMWareToVMWare";

        /// <summary>
        ///     Mapping for VMware to VMware for RPI.
        /// </summary>
        internal const string VMwareToVMwareRPI = "VMwareToVMwareRPI";
    }
}
