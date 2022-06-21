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
using System.Net.Security;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        public const string ProductionRpNamespace = "Microsoft.RecoveryServices";

        /// <summary>
        /// client request id.
        /// </summary>
        public string ClientRequestId { get; set; }

        /// <summary>
        /// Gets the value of recovery services management client.
        /// </summary>
        public RecoveryServicesClient GetRecoveryServicesClient
        {
            get
            {
                return this.recoveryServicesClient;
            }
        }

        /// <summary>
        /// Gets the value of recovery services backup client.
        /// </summary>
        public RecoveryServicesBackupClient GetRecoveryServicesBackupClient
        {
            get
            {
                return this.recoveryServicesBackupClient;
            }
        }

        public ResourceManagementClient RmClient
        {
            get
            {
                return resourceManagementClient;
            }
        }

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
        private RecoveryServicesClient recoveryServicesClient;

        private ResourceManagementClient resourceManagementClient;

        private RecoveryServicesBackupClient recoveryServicesBackupClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PSRecoveryServicesClient" /> class with 
        /// required current subscription.
        /// </summary>
        /// <param name="defaultContext"></param>
        public PSRecoveryServicesClient(IAzureContext defaultContext)
        {
            string resourceType = string.Empty;

            // Get Resource provider namespace from config if needed to communicate with internal deployments
            if (string.IsNullOrEmpty(arsVaultCreds.ResourceNamespace))
            {
                Utilities.UpdateCurrentVaultContext(new ASRVaultCreds()
                {
                    ResourceNamespace = ProductionRpNamespace,
                    ARMResourceType = resourceType
                });
            }

            this.recoveryServicesClient =
            AzureSession.Instance.ClientFactory.CreateArmClient<RecoveryServicesClient>(
                defaultContext, AzureEnvironment.Endpoint.ResourceManager);

            this.recoveryServicesBackupClient =
            AzureSession.Instance.ClientFactory.CreateArmClient<RecoveryServicesBackupClient>(
                defaultContext, AzureEnvironment.Endpoint.ResourceManager);

            resourceManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(defaultContext, AzureEnvironment.Endpoint.ResourceManager);
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
        /// <returns>Custom request headers</returns>
        public Dictionary<string, List<string>> GetRequestHeaders()
        {
            this.ClientRequestId = Guid.NewGuid().ToString() + "-" + DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ssZ") + "-P";

            var dict = new Dictionary<string, List<string>>();
            dict["x-ms-client-request-id"] = new List<string>() { ClientRequestId };

            return dict;
        }
    }
}
