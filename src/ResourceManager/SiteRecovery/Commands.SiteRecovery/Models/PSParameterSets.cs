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

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Parameter Sets used for Azure Site Recovery commands.
    /// </summary>
    internal static class ASRParameterSets
    {
        /// <summary>
        /// When only RP Object is passed to the command.
        /// </summary>
        internal const string ForSite = "ForSite";

        /// <summary>
        /// When only RP Object is passed to the command.
        /// </summary>
        internal const string ByRPObject = "ByRPObject";

        /// <summary>
        /// When only RP File is passed to the command.
        /// </summary>
        internal const string ByRPFile = "ByRPFile";

        /// <summary>
        /// When only Object is passed to the command.
        /// </summary>
        internal const string ByObject = "ByObject";

        /// <summary>
        /// When only Server Object is passed to the command.
        /// </summary>
        internal const string ByServerObject = "ByServerObject";

        /// <summary>
        /// When only PE Object is passed to the command.
        /// </summary>
        internal const string ByPEObject = "ByPEObject";

        /// <summary>
        /// When only RP Object with E2A provider is passed to the command.
        /// </summary>
        internal const string ByRPObjectE2A = "ByRPObjectE2A";

        /// <summary>
        /// When only PE Object with E2A provider is passed to the failback command.
        /// </summary>
        internal const string ByPEObjectE2AFailback = "ByPEObjectE2AFailback";

        /// <summary>
        /// When only RP Object with E2A provider is passed to the failback command.
        /// </summary>
        internal const string ByRPObjectE2AFailback = "ByRPObjectE2AFailback";

        /// <summary>
        /// When only PE Object with E2A provider is passed to the command.
        /// </summary>
        internal const string ByPEObjectE2A = "ByPEObjectE2A";

        /// <summary>
        /// When only PE Object is passed along with logical network ID to the command.
        /// </summary>
        internal const string ByPEObjectWithLogicalNetworkID = "ByPEObjectWithLogicalNetworkID";

        /// <summary>
        /// When only RP Object is passed along with VM network ID to the command.
        /// </summary>
        internal const string ByRPObjectWithVMNetworkID = "ByRPObjectWithVMNetworkID";

        /// <summary>
        /// When only RP Id is passed along with VM network ID to the command.
        /// </summary>
        internal const string ByRPIdWithVMNetworkID = "ByRPIdWithVMNetworkID";

        /// <summary>
        /// When only RP Object is passed along with VM network to the command.
        /// </summary>
        internal const string ByRPObjectWithVMNetwork = "ByRPObjectWithVMNetwork";

        /// <summary>
        /// When only RP Id is passed along with VM network to the command.
        /// </summary>
        internal const string ByRPIdWithVMNetwork = "ByRPIdWithVMNetwork";

        /// <summary>
        /// When only RP Object is passed along with Azure VM Network Id to the command.
        /// </summary>
        internal const string ByRPObjectWithAzureVMNetworkId = "ByRPObjectWithAzureVMNetworkId";

        /// <summary>
        /// When only PE Object is passed along with VM network ID to the command.
        /// </summary>
        internal const string ByPEObjectWithVMNetworkID = "ByPEObjectWithVMNetworkID";

        /// <summary>
        /// When only PE Object is passed along with VM network to the command.
        /// </summary>
        internal const string ByPEObjectWithVMNetwork = "ByPEObjectWithVMNetwork";

        /// <summary>
        /// When only PE Object is passed along with Logical VM network to the command.
        /// </summary>
        internal const string ByPEObjectWithLogicalVMNetwork = "ByPEObjectWithLogicalVMNetwork";

        /// <summary>
        /// When only PE Object is passed along with Logical VM network to the command.
        /// </summary>
        internal const string ByPEObjectWithAzureVMNetworkId = "ByPEObjectWithAzureVMNetworkId";

        /// <summary>
        /// When only PC and PE ids are passed to the command.
        /// </summary>
        internal const string ByPEId = "ByPEId";

        /// <summary>
        /// When only PC and PE ids are passed along with logical network ID to the command.
        /// </summary>
        internal const string ByPEIdWithLogicalNetworkID = "ByPEIdWithLogicalNetworkID";

        /// <summary>
        /// When only RP object is passed along with logical network ID to the command.
        /// </summary>
        internal const string ByRPObjectWithLogicalNetworkID = "ByRPObjectWithLogicalNetworkID";

        /// <summary>
        /// When only RP Id is passed along with logical network ID to the command.
        /// </summary>
        internal const string ByRPIdWithLogicalNetworkID = "ByRPIdWithLogicalNetworkID";

        /// <summary>
        /// When only PC and PE ids are passed along with VM network ID to the command.
        /// </summary>
        internal const string ByPEIdWithVMNetworkID = "ByPEIdWithVMNetworkID";

        /// <summary>
        /// When only PC and PE ids are passed along with VM network to the command.
        /// </summary>
        internal const string ByPEIdWithVMNetwork = "ByPEIdWithVMNetwork";

        /// <summary>
        /// When only ID is passed to the command.
        /// </summary>
        internal const string ById = "ById";

        /// <summary>
        /// When only RP ID is passed to the command.
        /// </summary>
        internal const string ByRPId = "ByRPId";

        /// <summary>
        /// When only Name is passed to the command.
        /// </summary>
        internal const string ByName = "ByName";

        /// <summary>
        /// When only Name is passed to the command.
        /// </summary>
        internal const string ByFriendlyName = "ByFriendlyName";

        /// <summary>
        /// When nothing is passed to the command.
        /// </summary>
        internal const string Default = "Default";

        /// <summary>
        /// When group of IDs are passed to the command.
        /// </summary>
        internal const string ByIDs = "ByIDs";

        /// <summary>
        /// When Object and ID are passed to the command.
        /// </summary>
        internal const string ByObjectWithId = "ByObjectWithId";

        /// <summary>
        /// When Object and Name are passed to the command.
        /// </summary>
        internal const string ByObjectWithName = "ByObjectWithName";

        /// <summary>
        /// When Object and Name are passed to the command.
        /// </summary>
        internal const string ByObjectWithFriendlyName = "ByObjectWithFriendlyName";

        /// <summary>
        /// When group of IDs and ID are passed to the command.
        /// </summary>
        internal const string ByIDsWithId = "ByIDsWithId";

        /// <summary>
        /// When group of IDs and Name are passed to the command.
        /// </summary>
        internal const string ByIDsWithName = "ByIDsWithName";

        /// <summary>
        /// When parameters are passed to the command.
        /// </summary>
        internal const string ByParam = "ByParam";

        /// <summary>
        /// Mapping between Enterprise to Enterprise.
        /// </summary>
        internal const string EnterpriseToEnterprise = "EnterpriseToEnterprise";

        /// <summary>
        /// Mapping between Enterprise to Azure.
        /// </summary>
        internal const string EnterpriseToAzure = "EnterpriseToAzure";

        /// <summary>
        /// Mapping between HyperV Site to Azure.
        /// </summary>
        internal const string HyperVSiteToAzure = "HyperVSiteToAzure";

        /// <summary>
        /// Disable DR
        /// </summary>
        internal const string DisableDR = "DisableDR";

        /// <summary>
        /// Mapping between Enterprise to Enterprise San.
        /// </summary>
        internal const string EnterpriseToEnterpriseSan = "EnterpriseToEnterpriseSan";

        /// <summary>
        /// For Enable replication group parameter set.
        /// </summary>
        internal const string EnableReplicationGroup = "EnableReplicationGroup";

        /// <summary>
        /// For Disable replication group parameter set.
        /// </summary>
        internal const string DisableReplicationGroup = "DisableReplicationGroup";

        /// <summary>
        /// To append group to RP.
        /// </summary>
        internal const string AppendGroup = "AppendGroup";

        /// <summary>
        /// To remove group from RP
        /// </summary>
        internal const string RemoveGroup = "RemoveGroup";

        /// <summary>
        /// Add protected entities to RP
        /// </summary>
        internal const string AddProtectedEntities = "AddProtectedEntities";

        /// <summary>
        /// Remove protected entities from RP
        /// </summary>
        internal const string RemoveProtectedEntities = "RemoveProtectedEntities";

        /// </summary>
        /// Handle ASR Vault.
        /// </summary>
        internal const string ASRVault = "AzureSiteRecoveryVault";

        /// <summary>
        /// Handle ARS Vault.
        /// </summary>
        internal const string ARSVault = "AzureRecoveryServicesVault";
    }
}