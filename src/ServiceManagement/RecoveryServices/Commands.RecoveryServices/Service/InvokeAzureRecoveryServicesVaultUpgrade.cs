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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.RecoveryServicesVaultUpgrade.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Used to initiate vault upgrade operation.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "AzureRecoveryServicesVaultUpgrade", SupportsShouldProcess = true)]
    [OutputType(typeof(List<string>))]
    public class InvokeAzureRecoveryServicesVaultUpgrade : RecoveryServicesCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets vault type.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(
            Constants.ASRVaultType,
            Constants.BackupVault,
            IgnoreCase = true)]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets vault name.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Gets or sets location of the vault.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets target resource group.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [Alias("TargetRG", "TargetRGName", "RG")]
        public string TargetResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            CheckVaultUpgradePrerequisitesResponse result =
                this.ValidateVaultUpgradePrerequisites();

            bool actionConfirmed = false;
            ResourceUpgradeDetails response = null;
            string message = result == CheckVaultUpgradePrerequisitesResponse.Succeeded ?
                Properties.Resources.PrerequisitesCheckPassed :
                Properties.Resources.PrerequisitesCheckReturnedWarnings;

            try
            {
                this.ConfirmAction(
                    this.Force.IsPresent,
                    string.Format(message),
                    Properties.Resources.StartVaultUpgradeWhatIfMessage,
                    this.VaultName,
                    () =>
                        {
                            response = this.RecoveryServicesClient.StartVaultUpgrade(
                                this.VaultName,
                                this.Location,
                                this.ResourceType,
                                this.TargetResourceGroupName,
                                this.Profile.Context.Subscription.Id.ToString());

                            actionConfirmed = true;
                        });

                if (actionConfirmed)
                {
                    this.WriteObject(new ASRVaultUpgradeDetails(response));
                    this.WaitForJobCompletion();
                }
            }
            catch (Exception exception)
            {
                this.HandleVaultUpgradeException(exception);
            }
        }

        /// <summary>
        /// Track resource upgrade operation.
        /// </summary>
        private void WaitForJobCompletion()
        {
            TrackResourceUpgradeResponse response = null;
            DateTime startTime = DateTime.Now;
            double taskTimeoutInSeconds = 6000;
            double elapsedSeconds = 0;
            ProgressRecord record =
                new ProgressRecord(
                    0,
                    Properties.Resources.VaultUpgradeInProgress,
                    Properties.Resources.WaitingForCompletion);

            do
            {
                TestMockSupport.Delay(PSRecoveryServicesClient.TimeToSleepBeforeFetchingJobDetailsAgain);
                response = this.RecoveryServicesClient.TrackVaultUpgrade(
                    this.VaultName,
                    this.Location,
                    this.ResourceType);

                elapsedSeconds = DateTime.Now.Subtract(startTime).TotalSeconds;
                record.PercentComplete = (int)elapsedSeconds * 100 / (int)taskTimeoutInSeconds;
                this.WriteProgress(record);
            }
            while (response.OperationStatus == Constants.InProgress &&
                elapsedSeconds < taskTimeoutInSeconds &&
                !this.StopProcessingFlag);

            if (response.OperationStatus == Constants.Completed)
            {
                this.WriteResponse(
                    string.Format(
                        Properties.Resources.TrackVaultUpgradeJobResult,
                        response.OperationResult,
                        response.OperationStatus));

                if (response.OperationResult == Constants.Succeeded)
                {
                    this.WriteResponse(
                        string.Format(
                            Properties.Resources.VaultUpgradeSucceded,
                            this.ResourceType,
                            this.VaultName));
                }
                else
                {
                    this.WriteResponse(Properties.Resources.VaultUpgradeNotSucceded);
                }
            }
            else if (this.StopProcessingFlag)
            {
                this.WriteResponse(Properties.Resources.VaultUpgradeTerminated);
            }
            else
            {
                this.WriteResponse(Properties.Resources.VaultUpgradeTimedOut);
            }
        }

        /// <summary>
        /// Validating vault upgrade prerequisites.
        /// </summary>
        /// <returns>CheckPrerequisites response.</returns> 
        private CheckVaultUpgradePrerequisitesResponse ValidateVaultUpgradePrerequisites()
        {
            CheckVaultUpgradePrerequisitesResponse response =
                CheckVaultUpgradePrerequisitesResponse.Succeeded;

            this.WriteResponse(Properties.Resources.StartingPrerequisitesCheck);

            try
            {
                this.RecoveryServicesClient.TestVaultUpgradePrerequistes(
                    this.VaultName,
                    this.Location,
                    this.ResourceType,
                    this.TargetResourceGroupName,
                    this.Profile.Context.Subscription.Id.ToString());

                this.WriteObject(Properties.Resources.CheckPrereqSucceeded);
            }
            catch (Exception exception)
            {
                this.WriteObject(Properties.Resources.CheckPrereqFailed);
                ExceptionDetails details =
                    this.HandleVaultUpgradeException(exception);
                if (!string.IsNullOrEmpty(details.WarningDetails))
                {
                    this.WriteWarning(details.WarningDetails);
                }

                if (!string.IsNullOrEmpty(details.ErrorDetails))
                {
                    Exception ex = new InvalidOperationException(
                        string.Format(
                            Properties.Resources.ConfirmVaultUpgradePrereqFailed,
                            Properties.Resources.VaultUpgradeExceptionDetails,
                            details.ErrorDetails));

                    this.ThrowTerminatingError(
                        new ErrorRecord(
                            ex,
                            string.Empty,
                            ErrorCategory.InvalidOperation,
                            null));
                }

                response = CheckVaultUpgradePrerequisitesResponse.SucceededWithWarnings;
            }

            return response;
        }
    }
}