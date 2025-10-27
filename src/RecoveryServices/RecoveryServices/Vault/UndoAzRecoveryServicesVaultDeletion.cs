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
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.Models;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Undeletes a soft deleted Azure Recovery Services Vault.
    /// </summary>
    [Cmdlet("Undo", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesVaultDeletion", SupportsShouldProcess = true)]
    [OutputType(typeof(Object))] // chck: ServeClientModel.OperationStatus
    public class UndoAzRecoveryServicesVaultDeletion : RecoveryServicesCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets Resource Group name.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Vault Name.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Location.
        /// </summary>
        [Parameter(Position = 3, Mandatory = true)]
        [LocationCompleter]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Prevents the confirmation dialog when specified.
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.Name, "Undelete Recovery Services Vault") || Force.IsPresent)
            {
                try
                {
                    // Construct the recovery resource group ID
                    string subscriptionId = DefaultProfile.DefaultContext.Subscription.Id;
                    string recoveryResourceGroupId = $"/subscriptions/{subscriptionId}/resourceGroups/{this.ResourceGroupName}";

                    WriteVerbose($"Starting undelete operation for vault '{this.Name}' in location '{this.Location}'");
                    WriteVerbose($"Recovery Resource Group ID: {recoveryResourceGroupId}");

                    DeletedVault undeleteResult = RecoveryServicesClient.UndeleteSoftDeletedVault(
                        this.Location, 
                        this.Name, 
                        recoveryResourceGroupId);

                    WriteVerbose($"Undelete operation completed for vault '{this.Name}'");
                    
                    this.WriteObject(new ARSSoftDeletedVault(undeleteResult));
                }
                catch (Exception exception)
                {
                    this.HandleException(exception);
                }
            }
        }
    }
}