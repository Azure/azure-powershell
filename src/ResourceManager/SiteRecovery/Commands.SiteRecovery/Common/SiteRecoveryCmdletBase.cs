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
using System.IO;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml;
using Hyak.Common;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// The base class for all Windows Azure Recovery Services commands
    /// </summary>
    public abstract class SiteRecoveryCmdletBase : AzurePSCmdlet
    {
        /// <summary>
        /// Recovery Services client.
        /// </summary>
        private PSRecoveryServicesClient recoveryServicesClient;

        /// <summary>
        /// Gets or sets a value indicating whether stop processing has been triggered.
        /// </summary>
        internal bool StopProcessingFlag { get; set; }

        /// <summary>
        /// Gets Recovery Services client.
        /// </summary>
        internal PSRecoveryServicesClient RecoveryServicesClient
        {
            get
            {
                if (this.recoveryServicesClient == null)
                {
                    this.recoveryServicesClient = new PSRecoveryServicesClient(Profile, Profile.Context.Subscription);
                }

                return this.recoveryServicesClient;
            }
        }

        /// <summary>
        /// Exception handler.
        /// </summary>
        /// <param name="ex">Exception to handle.</param>
        public void HandleException(Exception ex)
        {
            string clientRequestIdMsg = string.Empty;
            if (this.recoveryServicesClient != null)
            {
                clientRequestIdMsg = "ClientRequestId: " + this.recoveryServicesClient.ClientRequestId + "\n";
            }

            CloudException cloudException = ex as CloudException;
            if (cloudException != null)
            {
                Error error = null;
                try
                {
                    using (Stream stream = new MemoryStream())
                    {
                        if (cloudException.Message != null)
                        {
                            byte[] data = System.Text.Encoding.UTF8.GetBytes(cloudException.Message);
                            stream.Write(data, 0, data.Length);
                            stream.Position = 0;

                            var deserializer = new DataContractSerializer(typeof(ErrorInException));
                            error = (Error)deserializer.ReadObject(stream);

                            throw new InvalidOperationException(
                                string.Format(
                                Properties.Resources.CloudExceptionDetails,
                                error.Message,
                                error.PossibleCauses,
                                error.RecommendedAction,
                                error.ClientRequestId));
                        }
                        else
                        {
                            throw new Exception(
                                string.Format(
                                Properties.Resources.InvalidCloudExceptionErrorMessage,
                                clientRequestIdMsg + ex.Message),
                                ex);
                        }
                    }
                }
                catch (XmlException)
                {
                    throw new XmlException(
                        string.Format(
                        Properties.Resources.InvalidCloudExceptionErrorMessage,
                        cloudException.Message),
                        cloudException);
                }
                catch (SerializationException)
                {
                    throw new SerializationException(
                        string.Format(
                        Properties.Resources.InvalidCloudExceptionErrorMessage,
                        clientRequestIdMsg + cloudException.Message),
                        cloudException);
                }
            }
            else if (ex.Message != null)
            {
                throw new Exception(
                    string.Format(
                    Properties.Resources.InvalidCloudExceptionErrorMessage,
                    clientRequestIdMsg + ex.Message),
                    ex);
            }
        }

        /// <summary>
        /// Waits for the job to complete.
        /// </summary>
        /// <param name="jobId">Id of the job to wait for.</param>
        public void WaitForJobCompletion(string jobId)
        {
            JobResponse jobResponse = null;
            do
            {
                Thread.Sleep(PSRecoveryServicesClient.TimeToSleepBeforeFetchingJobDetailsAgain);
                jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(jobId);
                this.WriteProgress(
                    new System.Management.Automation.ProgressRecord(
                        0,
                        Properties.Resources.WaitingForCompletion,
                        jobResponse.Job.Properties.State));
            }
            while (!(jobResponse.Job.Properties.State == JobStatus.Cancelled ||
                            jobResponse.Job.Properties.State == JobStatus.Failed ||
                            jobResponse.Job.Properties.State == JobStatus.Suspended ||
                            jobResponse.Job.Properties.State == JobStatus.Succeeded ||
                        this.StopProcessingFlag));
        }

        /// <summary>
        /// Handles interrupts.
        /// </summary>
        protected override void StopProcessing()
        {
            // Ctrl + C and etc
            base.StopProcessing();
            this.StopProcessingFlag = true;
        }

        /// <summary>
        /// Validates if the usage by ID is allowed or not.
        /// </summary>
        /// <param name="replicationProvider">Replication provider.</param>
        /// <param name="paramName">Parameter name.</param>
        protected void ValidateUsageById(string replicationProvider, string paramName)
        {
            if (replicationProvider != Constants.HyperVReplica)
            {
                throw new Exception(
                    string.Format(
                    "Call using ID based parameter {0} is not supported for this provider. Please use its corresponding full object parameter instead",
                    paramName));
            }
            else
            {
                this.WriteWarningWithTimestamp(
                    string.Format(
                    Properties.Resources.IDBasedParamUsageNotSupportedFromNextRelease,
                    paramName));
            }
        }

        /// <summary>
        /// Gets the current vault location.
        /// </summary>
        /// <returns>The current vault location.</returns>
        protected string GetCurrentValutLocation()
        {
            string location = string.Empty;

            VaultListResponse vaultListResponse =
                RecoveryServicesClient.GetVaultsInResouceGroup(PSRecoveryServicesClient.asrVaultCreds.ResourceGroupName);

            foreach (Vault vault in vaultListResponse.Vaults)
            {
                if (0 == string.Compare(PSRecoveryServicesClient.asrVaultCreds.ResourceName, vault.Name, true))
                {
                    location = vault.Location;
                    break;
                }
            }

            return location;
        }
    }
}