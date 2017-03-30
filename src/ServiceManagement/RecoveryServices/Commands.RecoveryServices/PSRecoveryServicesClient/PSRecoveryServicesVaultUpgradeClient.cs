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
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using Hyak.Common;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.WindowsAzure.Management.RecoveryServicesVaultUpgrade;
using Microsoft.WindowsAzure.Management.RecoveryServicesVaultUpgrade.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Method to validate vault upgrade prerequisites.
        /// </summary>
        /// <param name="resourceName">Vault name.</param>
        /// <param name="location">Vault location.</param>
        /// <param name="resourceType">Vault type.</param>
        /// <param name="resourceGroupName">Target resource group name</param>
        /// <param name="subscriptionId">Subscription id.</param>
        /// <returns>Azure operation response.</returns>
        public AzureOperationResponse TestVaultUpgradePrerequistes(
            string resourceName,
            string location,
            string resourceType,
            string resourceGroupName,
            string subscriptionId)
        {
            var input = this.GetResourceUpgradeInput(subscriptionId, resourceGroupName, resourceName);
            return this.GetVaultUpgradeClient(location, resourceName, resourceType)
                .RecoveryServicesVaultUpgrade.CheckPrerequisitesForRecoveryServicesVaultUpgrade(input, this.GetCustomRequestHeaders(false));
        }

        /// <summary>
        /// Method to initiate vault upgrade operation.
        /// </summary>
        /// <param name="resourceName">Vault name.</param>
        /// <param name="location">Vault location.</param>
        /// <param name="resourceType">Vault type.</param>
        /// <param name="resourceGroupName">Target resource group name</param>
        /// <param name="subscriptionId">Subscription id.</param>
        /// <returns>Instance of Resource upgrade details object.</returns>
        public ResourceUpgradeDetails StartVaultUpgrade(
            string resourceName,
            string location,
            string resourceType,
            string resourceGroupName,
            string subscriptionId)
        {
            var input = this.GetResourceUpgradeInput(subscriptionId, resourceGroupName, resourceName);
            return this.GetVaultUpgradeClient(location, resourceName, resourceType)
                .RecoveryServicesVaultUpgrade.UpgradeResource(input, this.GetCustomRequestHeaders(false));
        }

        /// <summary>
        /// Method to track vault upgrade operation.
        /// </summary>
        /// <param name="resourceName">Vault name.</param>
        /// <param name="location">Vault location.</param>
        /// <param name="resourceType">Vault type.</param>
        /// <returns>Instance of TrackResourceUpgradeResponse object.</returns>
        public TrackResourceUpgradeResponse TrackVaultUpgrade(
            string resourceName,
            string location,
            string resourceType)
        {
            return this.GetVaultUpgradeClient(location, resourceName, resourceType)
                .RecoveryServicesVaultUpgrade.TrackResourceUpgrade(this.GetCustomRequestHeaders(false));
        }

        /// <summary>
        /// Parse the exception details got as part of vault upgrade operations.
        /// </summary>
        /// <param name="migrationErrorDetails">Error details</param>
        /// <param name="clientRequestIdMsg">Contains client request id.</param>
        /// <returns>Exception message to be shown to customer.</returns>
        public ExceptionDetails ParseErrorDetails(
            List<VaultUpgradeErrorDetails> migrationErrorDetails,
            string clientRequestIdMsg)
        {
            HashSet<string> errorCodes = new HashSet<string>();
            StringBuilder warningDetails = new StringBuilder();
            StringBuilder errorDetails = new StringBuilder();

            foreach (VaultUpgradeErrorDetails detail in migrationErrorDetails)
            {
                StringBuilder exceptionMessage = this.ParseErrorComponents(detail);
                if (!string.IsNullOrEmpty(detail.Code))
                {
                    errorCodes.Add(detail.Code);
                }

                if (detail.Type.Equals(ErrorType.Warning.ToString(), StringComparison.InvariantCulture))
                {
                    warningDetails.Append(exceptionMessage);
                }
                else
                {
                    errorDetails.Append(exceptionMessage);
                }
            }

            if (string.IsNullOrEmpty(errorDetails.ToString()))
            {
                warningDetails.AppendLine(" ").AppendLine(clientRequestIdMsg);
            }
            else
            {
                errorDetails.AppendLine(" ").AppendLine(clientRequestIdMsg);
            }

            return new ExceptionDetails(
                errorDetails.ToString(), warningDetails.ToString(), errorCodes);
        }

        /// <summary>
        /// Parse the exception thrown from vault upgrade operations.
        /// </summary>
        /// <param name="error">Instance of VaultUpgradeError.</param>
        /// <returns>Exception message to be shown to customer.</returns>
        public StringBuilder ParseError(
            VaultUpgradeError error)
        {
            StringBuilder exceptionMessage = new StringBuilder();

            if (!string.IsNullOrEmpty(error.Code))
            {
                exceptionMessage.AppendLine("ErrorCode: " + error.Code);
            }

            if (!string.IsNullOrEmpty(error.Message))
            {
                exceptionMessage.AppendLine("Message: " + error.Message);
            }

            if (!string.IsNullOrEmpty(error.RecommendedAction))
            {
                exceptionMessage.AppendLine("Recommended Action: " + error.RecommendedAction);
            }

            return exceptionMessage.AppendLine(" ");
        }

        /// <summary>
        /// Parse the error components of errors got as part of vault upgrade operations.
        /// </summary>
        /// <param name="detail">Error detail</param>
        /// <returns>Exception message to be shown to customer.</returns>
        private StringBuilder ParseErrorComponents(VaultUpgradeErrorDetails detail)
        {
            StringBuilder exceptionMessage = new StringBuilder();
            exceptionMessage.AppendLine(" ");
            if (!string.IsNullOrEmpty(detail.Category))
            {
                exceptionMessage.AppendLine("Category: " + detail.Category);
            }

            if (!string.IsNullOrEmpty(detail.Code))
            {
                exceptionMessage.AppendLine("ErrorCode: " + detail.Code);
            }

            exceptionMessage.AppendLine("Type: " + detail.Type);
            if (!string.IsNullOrEmpty(detail.Message))
            {
                exceptionMessage.Append("Message: ");
                string prefixRowToken = string.Empty;
                string[] msgDetails = detail.Message.Split('|');
                foreach (var msg in msgDetails)
                {
                    exceptionMessage.Append(prefixRowToken);
                    prefixRowToken = "\n";

                    string prefixColToken = string.Empty;
                    string[] data = msg.Split(';');
                    foreach (var info in data)
                    {
                        exceptionMessage.Append(prefixColToken).Append(info);
                        prefixColToken = "\t";
                    }
                }
            }

            if (!string.IsNullOrEmpty(detail.Properties))
            {
                exceptionMessage.AppendLine(" ").AppendLine("Properties: " + detail.Properties);
            }

            if (!string.IsNullOrEmpty(detail.RecommendedAction))
            {
                exceptionMessage.AppendLine(" ").AppendLine("Recommended Action: " + detail.RecommendedAction);
            }

            return exceptionMessage;
        }

        /// <summary>
        /// Creates input required for checking prerequisites as well as to initiate vault upgrade.
        /// </summary>
        /// <param name="subscriptionId">Subscription id.</param>
        /// <param name="resourceGroupName">Target resource group name</param>
        /// <param name="vaultName">Vault name.</param>
        /// <returns>Instance of ResourceUpgradeInput object.</returns>
        private ResourceUpgradeInput GetResourceUpgradeInput(
            string subscriptionId,
            string resourceGroupName,
            string vaultName)
        {
            string newResourcePath =
                string.Format(
                    "/subscriptions/{0}/resourceGroups/{1}/providers/{2}/{3}/{4}",
                    subscriptionId,
                    resourceGroupName,
                    Constants.RecoveryServicesNamespace,
                    Constants.Vaults,
                    vaultName);

            return new ResourceUpgradeInput() { NewResourcePath = newResourcePath };
        }

        /// <summary>
        /// Gets request headers.
        /// </summary>
        /// <param name="shouldSignRequest">specifies whether to sign the request or not</param>
        /// <returns>Custom request headers</returns>
        private CustomRequestHeaders GetCustomRequestHeaders(bool shouldSignRequest = true)
        {
            this.ClientRequestId = Guid.NewGuid().ToString() + "-" + DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ssZ") + "-P";

            return new CustomRequestHeaders()
            {
                // ClientRequestId is a unique ID for every request to Azure Site Recovery.
                // It is useful when diagnosing failures in API calls.
                ClientRequestId = this.ClientRequestId
            };
        }
    }
}
