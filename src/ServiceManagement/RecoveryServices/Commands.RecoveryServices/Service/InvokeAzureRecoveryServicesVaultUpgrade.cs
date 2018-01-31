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
    [OutputType(typeof(ASRVaultUpgradeResponse))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "equivalent cmdlet from the AzureRm.RecoveryServices.SiteRecovery module instead.",
        false)]
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
            if (result == CheckVaultUpgradePrerequisitesResponse.Failed)
            {
                return;
            }
            
            bool actionConfirmed = false;
            ResourceUpgradeDetails response = null;
            string message = result == CheckVaultUpgradePrerequisitesResponse.Succeeded ?
                Properties.Resources.PrerequisitesCheckPassed :
                Properties.Resources.PrerequisitesCheckReturnedWarnings;

            try
            {
                if (this.ShouldProcess(this.VaultName, Properties.Resources.StartVaultUpgradeWhatIfMessage) &&
                    (this.Force.IsPresent || this.ShouldContinue(string.Format(message), string.Empty)))
                {
                    response = this.RecoveryServicesClient.StartVaultUpgrade(
                        this.VaultName,
                        this.Location,
                        this.ResourceType,
                        this.TargetResourceGroupName,
                        this.Profile.Context.Subscription.Id.ToString());

                    actionConfirmed = true;
                }

                if (actionConfirmed)
                {
                    this.WaitForJobCompletion(response);
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
        /// <param name="details">StartVaultUpgrade response.</param> 
        private void WaitForJobCompletion(ResourceUpgradeDetails details)
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

            record.RecordType = ProgressRecordType.Completed;
            this.WriteProgress(record);

            string operationResult = string.Empty;
            string operationStatus = string.Empty;
            string message = string.Empty;

            if (response.OperationStatus == Constants.Completed)
            {
                operationResult = response.OperationResult;
                operationStatus = response.OperationStatus;
                    
                if (response.OperationResult == Constants.Succeeded)
                {
                    message =
                        string.Format(
                            Properties.Resources.VaultUpgradeSucceded,
                            this.ResourceType,
                            this.VaultName);
                }
                else
                {
                    message =
                        Properties.Resources.VaultUpgradeNotSucceded;
                }
            }
            else if (this.StopProcessingFlag)
            {
                operationResult = VaultUpgradeOperationResult.Unavailable.ToString();
                operationStatus = VaultUpgradeOperationResult.InProgress.ToString();
                message = Properties.Resources.VaultUpgradeTerminated;
            }
            else
            {
                operationResult = VaultUpgradeOperationResult.Failed.ToString();
                operationStatus = VaultUpgradeOperationResult.TimedOut.ToString();
                message = Properties.Resources.VaultUpgradeTimedOut;
            }

            this.WriteObject(
                new ASRVaultUpgradeResponse(details, operationResult, operationStatus, message));
        }

        /// <summary>
        /// Validating vault upgrade prerequisites.
        /// </summary>
        /// <returns>CheckPrerequisites response.</returns> 
        private CheckVaultUpgradePrerequisitesResponse ValidateVaultUpgradePrerequisites()
        {
            CheckVaultUpgradePrerequisitesResponse response =
                CheckVaultUpgradePrerequisitesResponse.Succeeded;

            try
            {
                this.RecoveryServicesClient.TestVaultUpgradePrerequistes(
                    this.VaultName,
                    this.Location,
                    this.ResourceType,
                    this.TargetResourceGroupName,
                    this.Profile.Context.Subscription.Id.ToString());
            }
            catch (Exception exception)
            {
                ExceptionDetails details =
                    this.HandleVaultUpgradeException(exception);

                if (details != null)
                {
                    if (!string.IsNullOrEmpty(details.WarningDetails))
                    {
                        this.WriteWarning(details.WarningDetails + Environment.NewLine);
                        response = CheckVaultUpgradePrerequisitesResponse.SucceededWithWarnings;
                    }

                    if (!string.IsNullOrEmpty(details.ErrorDetails))
                    {
                        response = CheckVaultUpgradePrerequisitesResponse.Failed;
                        Exception ex = new InvalidOperationException(
                            string.Format(
                                Properties.Resources.ConfirmVaultUpgradePrereqFailed,
                                Properties.Resources.VaultUpgradeExceptionDetails,
                                details.ErrorDetails));

                        this.WriteVaultUpgradeError(ex);
                    }
                }
                else
                {
                    response = CheckVaultUpgradePrerequisitesResponse.Failed;
                }
            }

            return response;
        }
    }
}