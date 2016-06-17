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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using System.Configuration;
using System.Net.Security;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// client request id.
        /// </summary>
        public string ClientRequestId { get; set; }

        /// <summary>
        /// Gets the value of recovery services management client.
        /// </summary>
        public RecoveryServicesManagementClient GetRecoveryServicesClient
        {
            get
            {
                return this.recoveryServicesClient;
            }
        }

        /// Azure profile
        /// </summary>
        public IAzureProfile Profile { get; set; }

        /// <summary>
        /// Resource credentials holds vault, cloud service name, vault key and other details.
        /// </summary>
        [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1401:FieldsMustBePrivate",
        Justification = "For Resource Credentials.")]
        public static ASRVaultCreds arsVaultCreds = new ASRVaultCreds();

        /// <summary>
        /// Resource credentials holds vault, resource group name, location and other details.
        /// </summary>
        [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1401:FieldsMustBePrivate",
        Justification = "For Resource Credentials.")]
        public static ARSVault arsVault = new ARSVault();
        /// <summary>
        /// Recovery Services client.
        /// </summary>
        private RecoveryServicesManagementClient recoveryServicesClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PSRecoveryServicesClient" /> class with 
        /// required current subscription.
        /// </summary>
        /// <param name="azureSubscription">Azure Subscription</param>
        public PSRecoveryServicesClient(IAzureProfile azureProfile)
        {
            System.Configuration.Configuration recoveryServicesConfig = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);

            System.Configuration.AppSettingsSection appSettings = (System.Configuration.AppSettingsSection)recoveryServicesConfig.GetSection("appSettings");

            string resourceNamespace = string.Empty;
            string resourceType = string.Empty;
            
            // Get Resource provider namespace from config if needed to communicate with internal deployments
            if (string.IsNullOrEmpty(arsVaultCreds.ResourceNamespace))
            {
                if (appSettings.Settings.Count == 0)
                {
                    resourceNamespace = "Microsoft.RecoveryServices";
                }
                else
                {
                    resourceNamespace =
                        null == appSettings.Settings["ProviderNamespace"]
                        ? "Microsoft.RecoveryServices"
                        : appSettings.Settings["ProviderNamespace"].Value;
                }

                Utilities.UpdateCurrentVaultContext(new ASRVaultCreds()
                {
                    ResourceNamespace = resourceNamespace,
                    ARMResourceType = resourceType
                });
            }

            this.recoveryServicesClient =
            AzureSession.ClientFactory.CreateCustomClient<RecoveryServicesManagementClient>(
                arsVaultCreds.ResourceNamespace,
                AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(azureProfile.Context),
                azureProfile.Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager));
        }

        private static bool IgnoreCertificateErrorHandler
           (object sender,
           System.Security.Cryptography.X509Certificates.X509Certificate certificate,
           System.Security.Cryptography.X509Certificates.X509Chain chain,
           SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static string GetResourceGroup(string resourceId)
        {
            const string resourceGroup = "resourceGroups";

            var startIndex = resourceId.IndexOf(resourceGroup, StringComparison.OrdinalIgnoreCase) + resourceGroup.Length + 1;
            var endIndex = resourceId.IndexOf("/", startIndex, StringComparison.OrdinalIgnoreCase);

            return resourceId.Substring(startIndex, endIndex - startIndex);
        }

        public static string GetSubscriptionId(string resourceId)
        {
            const string subscriptions = "subscriptions";

            var startIndex = resourceId.IndexOf(subscriptions, StringComparison.OrdinalIgnoreCase) + subscriptions.Length + 1;
            var endIndex = resourceId.IndexOf("/", startIndex, StringComparison.OrdinalIgnoreCase);

            return resourceId.Substring(startIndex, endIndex - startIndex);
        }

        /// <summary>
        /// Gets request headers.
        /// </summary>
        /// <param name="shouldSignRequest">specifies whether to sign the request or not</param>
        /// <returns>Custom request headers</returns>
        public CustomRequestHeaders GetRequestHeaders()
        {
            this.ClientRequestId = Guid.NewGuid().ToString() + "-" + DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ssZ") + "-P";

            return new CustomRequestHeaders()
            {
                // ClientRequestId is a unique ID for every request.
                // It is useful when diagnosing failures in API calls.
                ClientRequestId = this.ClientRequestId,
                AgentAuthenticationHeader = ""
            };
        }
    }
}