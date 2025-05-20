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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Rest.Azure.OData;
using System;
using Microsoft.Azure.Commands.Common.Exceptions;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Disable protection of an item protected by the recovery services vault. 
    /// Returns the corresponding job created in the service to track this operation.
    /// </summary>
    [Cmdlet("Disable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupProtection", SupportsShouldProcess = true), OutputType(typeof(JobBase))]
    public class DisableAzureRmRecoveryServicesBackupProtection : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// The protected item whose protection needs to be disabled.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, HelpMessage = ParamHelpMsgs.Item.ProtectedItem,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ItemBase Item { get; set; }

        /// <summary>
        /// If this option is used, all the data backed up for this item will 
        /// also be deleted and restoring the data will not be possible.
        /// </summary>
        [Parameter(Position = 2, Mandatory = false,
            HelpMessage = ParamHelpMsgs.Item.RemoveProtectionOption)]
        public SwitchParameter RemoveRecoveryPoints
        {
            get { return DeleteBackupData; }
            set { DeleteBackupData = value; }
        }

        /// <summary>
        /// If this option is used, all the data backed up for this item will 
        /// expire as per the protection policy retention settings
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Item.SuspendBackupOption)]
        public SwitchParameter RetainRecoveryPointsAsPerPolicy { get; set; }

        /// <summary>
        /// Parameter deprecated. Please use SecureToken instead.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.ResourceGuard.TokenDepricated, ValueFromPipeline = false)]
        [ValidateNotNullOrEmpty]
        public string Token;

        /// <summary>
        /// Auxiliary access token for authenticating critical operation to resource guard subscription
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.ResourceGuard.AuxiliaryAccessToken, ValueFromPipeline = false)]
        [ValidateNotNullOrEmpty]
        public System.Security.SecureString SecureToken;

        /// <summary>
        /// Prevents the confirmation dialog when specified.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Item.ForceOption)]
        public SwitchParameter Force { get; set; }

        private bool DeleteBackupData;

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.DisableProtectionWarning, Item.Name),
                    Resources.DisableProtectionMessage,
                    Item.Name, () =>
                    {
                        base.ExecuteCmdlet();

                        ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                        string vaultName = resourceIdentifier.ResourceName;
                        string resourceGroupName = resourceIdentifier.ResourceGroupName;

                        string plainToken = HelperUtils.GetPlainToken(Token, SecureToken);
                        if (plainToken != "" && plainToken != null && !this.DeleteBackupData && RetainRecoveryPointsAsPerPolicy.IsPresent)
                        {
                            throw new ArgumentException(String.Format(Resources.DisableWithRetainBackupNotCrititcal));
                        }

                        if (DeleteBackupData && RetainRecoveryPointsAsPerPolicy.IsPresent)
                        {
                            throw new AzPSArgumentException(String.Format(Resources.CantRemoveAndRetainRPsSimultaneously), "RetainRecoveryPointsAsPerPolicy");
                        }

                        PsBackupProviderManager providerManager =
                            new PsBackupProviderManager(new Dictionary<System.Enum, object>()
                            {
                                { VaultParams.VaultName, vaultName },
                                { VaultParams.ResourceGroupName, resourceGroupName },
                                { ItemParams.Item, Item },
                                { ItemParams.DeleteBackupData, this.DeleteBackupData },
                                { ResourceGuardParams.Token, plainToken },
                            }, ServiceClientAdapter);

                        IPsBackupProvider psBackupProvider =
                            providerManager.GetProviderInstance(Item.WorkloadType,
                            Item.BackupManagementType);

                        if (DeleteBackupData)
                        {
                            #region Archived RPs 
                            // Fetch RecoveryPoints in Archive Tier, if yes throw warning and confirmation prompt
                            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(Item.Id);
                            string containerUri = HelperUtils.GetContainerUri(uriDict, Item.Id);
                            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, Item.Id);

                            ODataQuery<ServiceClientModel.BmsrpQueryObject> queryFilter = null;
                            if (string.Compare(Item.BackupManagementType.ToString(), BackupManagementType.AzureWorkload.ToString()) == 0)
                            {
                                var restorePointQueryType = "FullAndDifferential";

                                string queryFilterString = QueryBuilder.Instance.GetQueryString(new ServiceClientModel.BmsrpQueryObject()
                                {
                                    RestorePointQueryType = restorePointQueryType,
                                    ExtendedInfo = true
                                });
                                queryFilter = new ODataQuery<ServiceClientModel.BmsrpQueryObject>();
                                queryFilter.Filter = queryFilterString;
                            }

                            var rpListResponse = ServiceClientAdapter.GetRecoveryPoints(
                               containerUri,
                               protectedItemName,
                               queryFilter,
                               vaultName: vaultName,
                               resourceGroupName: resourceGroupName);

                            var recoveryPointList = RecoveryPointConversions.GetPSAzureRecoveryPoints(rpListResponse, Item);

                            recoveryPointList = RecoveryPointConversions.FilterRPsBasedOnTier(recoveryPointList, RecoveryPointTier.VaultArchive);

                            #endregion

                            if (recoveryPointList.Count != 0)
                            {
                                bool yesToAll = Force.IsPresent;
                                bool noToAll = false;
                                if (ShouldContinue(Resources.DeleteArchiveRecoveryPoints, Resources.DeleteRecoveryPoints, ref yesToAll, ref noToAll))
                                {
                                    var itemResponse = psBackupProvider.DisableProtectionWithDeleteData();
                                    Logger.Instance.WriteDebug("item Response " + JsonConvert.SerializeObject(itemResponse));
                                    // Track Response and display job details
                                    HandleCreatedJob(
                                            itemResponse,
                                            Resources.DisableProtectionOperation,
                                            vaultName: vaultName,
                                            resourceGroupName: resourceGroupName);
                                }
                            }
                            else
                            {
                                var itemResponse = psBackupProvider.DisableProtectionWithDeleteData();

                                // Track Response and display job details
                                HandleCreatedJob(
                                        itemResponse,
                                        Resources.DisableProtectionOperation,
                                        vaultName: vaultName,
                                        resourceGroupName: resourceGroupName);
                            }
                        }
                        else if (RetainRecoveryPointsAsPerPolicy.IsPresent)
                        {
                            var itemResponse = psBackupProvider.SuspendBackup();
                            Logger.Instance.WriteDebug("Suspend backup response " + JsonConvert.SerializeObject(itemResponse));

                            // Track Response and display job details
                            HandleCreatedJob(
                                    itemResponse,
                                    Resources.DisableProtectionOperation,
                                    vaultName: vaultName,
                                    resourceGroupName: resourceGroupName);
                        }
                        else
                        {
                            var itemResponse = psBackupProvider.DisableProtection();
                            Logger.Instance.WriteDebug("Disable protection response " + JsonConvert.SerializeObject(itemResponse));
                            // Track Response and display job details
                            HandleCreatedJob(
                                    itemResponse,
                                    Resources.DisableProtectionOperation,
                                    vaultName: vaultName,
                                    resourceGroupName: resourceGroupName);
                        }
                    }
                );
            }, ShouldProcess(Item.Name, VerbsLifecycle.Disable));
        }        
    }
}
