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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Xml;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// The base class for all Windows Azure Recovery Services commands
    /// </summary>
    public abstract class SiteRecoveryCmdletBase : AzureRMCmdlet
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
                    this.recoveryServicesClient = new PSRecoveryServicesClient(DefaultProfile);
                }

                return this.recoveryServicesClient;
            }
        }

        /// <summary>
        /// Adds delegating handlers to the client pipeline:
        /// 1. RpNamespaceHandler - modified the RP namespace "Microsoft.RecoveryServices" based 
        ///    on the value provided in the dll config file.
        /// </summary>
        protected override void SetupHttpClientPipeline()
        {
            base.SetupHttpClientPipeline();
            AzureSession.Instance.ClientFactory.AddHandler(
                new RpNamespaceHandler(PSRecoveryServicesClient.asrVaultCreds.ResourceNamespace != null ? PSRecoveryServicesClient.asrVaultCreds.ResourceNamespace : ARMResourceTypeConstants.RecoveryServicesResourceProviderNameSpace));
        }

        /// <summary>
        /// Virtual method to be implemented by Site Recovery cmdlets.
        /// </summary>
        public virtual void ExecuteSiteRecoveryCmdlet()
        {
            SiteRecoveryAutoMapperProfile.Initialize();
            // Do Nothing
        }

        /// <summary>
        /// Overriding base implementation go execute cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                base.ExecuteCmdlet();
                ExecuteSiteRecoveryCmdlet();
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
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
            if (cloudException != null && cloudException.Body != null && cloudException.Response != null)
            {               
                try
                {
                    if (cloudException.Message != null)
                    {
                        ARMError error = Rest.Serialization.SafeJsonConvert.DeserializeObject<ARMError>(cloudException.Response.Content); ;
                        StringBuilder exceptionMessage = new StringBuilder();
                        exceptionMessage.Append(Properties.Resources.CloudExceptionDetails);

                        if (error.Error.Details != null)
                        {
                            foreach (ARMExceptionDetails detail in error.Error.Details)
                            {
                                if (!string.IsNullOrEmpty(detail.ErrorCode))
                                    exceptionMessage.AppendLine("ErrorCode: " + detail.ErrorCode);
                                if (!string.IsNullOrEmpty(detail.Message))
                                    exceptionMessage.AppendLine("Message: " + detail.Message);
                                if (!string.IsNullOrEmpty(detail.PossibleCauses))
                                    exceptionMessage.AppendLine("Possible Causes: " + detail.PossibleCauses);
                                if (!string.IsNullOrEmpty(detail.RecommendedAction))
                                    exceptionMessage.AppendLine("Recommended Action: " + detail.RecommendedAction);
                                if (!string.IsNullOrEmpty(detail.ClientRequestId))
                                    exceptionMessage.AppendLine("ClientRequestId: " + detail.ClientRequestId);
                                if (!string.IsNullOrEmpty(detail.ActivityId))
                                    exceptionMessage.AppendLine("ActivityId: " + detail.ActivityId);

                                exceptionMessage.AppendLine();
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(error.Error.ErrorCode))
                                exceptionMessage.AppendLine("ErrorCode: " + error.Error.ErrorCode);
                            if (!string.IsNullOrEmpty(error.Error.Message))
                                exceptionMessage.AppendLine("Message: " + error.Error.Message);
                        }

                        throw new InvalidOperationException(exceptionMessage.ToString());
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
                catch (JsonReaderException)
                {
                    throw new JsonReaderException(
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
        /// <returns>Final job response</returns>
        public Job WaitForJobCompletion(string jobId)
        {
            Job job = null;
            do
            {
                Thread.Sleep(PSRecoveryServicesClient.TimeToSleepBeforeFetchingJobDetailsAgain);
                job = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(jobId);
                this.WriteProgress(
                    new System.Management.Automation.ProgressRecord(
                        0,
                        Properties.Resources.WaitingForCompletion,
                        job.Properties.State));
            }
            while (!(job.Properties.State == JobStatus.Cancelled ||
                            job.Properties.State == JobStatus.Failed ||
                            job.Properties.State == JobStatus.Suspended ||
                            job.Properties.State == JobStatus.Succeeded ||
                        this.StopProcessingFlag));
            return job;
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
            if (replicationProvider != Constants.HyperVReplica2012)
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
    }
}