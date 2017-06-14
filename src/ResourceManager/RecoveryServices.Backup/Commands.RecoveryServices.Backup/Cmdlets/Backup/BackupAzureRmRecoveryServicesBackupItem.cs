﻿// ----------------------------------------------------------------------------------
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
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Enables backup of an item protected by the recovery services vault.
    /// Returns the corresponding job created in the service to track this backup operation.
    /// </summary>
    [Cmdlet(VerbsData.Backup, "AzureRmRecoveryServicesBackupItem"), OutputType(typeof(JobBase))]
    public class BackupAzureRmRecoveryServicesBackupItem : RecoveryServicesBackupCmdletBase
    {
        /// <summary>
        /// The protected item on which backup has to be triggered.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsgs.Item.ProtectedItem,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ItemBase Item { get; set; }

        /// <summary>
        /// The protected item on which backup has to be triggered.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Item.ExpiryDateTimeUTC,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public DateTime? ExpiryDateTimeUTC { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            PsBackupProviderManager providerManager =
                new PsBackupProviderManager(new Dictionary<Enum, object>()
                {
                    {ItemParams.Item, Item},
                    {ItemParams.ExpiryDateTimeUTC, ExpiryDateTimeUTC},
                }, ServiceClientAdapter);

            IPsBackupProvider psBackupProvider =
                providerManager.GetProviderInstance(Item.WorkloadType, Item.BackupManagementType);
            var jobResponse = psBackupProvider.TriggerBackup();

            HandleCreatedJob(jobResponse, Resources.TriggerBackupOperation);
        }
    }
}
