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
using System.Xml;
using Hyak.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Newtonsoft.Json;
using System.Text;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// The base class for all Windows Azure Recovery Services commands
    /// </summary>
    public abstract class RecoveryServicesCmdletBase : AzureRMCmdlet
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
                ARMError error = null;
                try
                {
                    if (cloudException.Message != null)
                    {
                        string originalMessage = cloudException.Error.OriginalMessage;
                        error = JsonConvert.DeserializeObject<ARMError>(originalMessage);

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
        /// Handles interrupts.
        /// </summary>
        protected override void StopProcessing()
        {
            // Ctrl + C and etc
            base.StopProcessing();
            this.StopProcessingFlag = true;
        }
    }
}