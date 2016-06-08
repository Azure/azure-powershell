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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Management.SiteRecoveryVault;
using Microsoft.Azure.Management.SiteRecoveryVault.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;

namespace Microsoft.Azure.Commands.SiteRecovery
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
        public SiteRecoveryVaultManagementClient GetRecoveryServicesClient
        {
            get
            {
                return this.recoveryServicesClient;
            }
        }

        /// <summary>
        /// Amount of time to sleep before fetching job details again.
        /// </summary>
        public const int TimeToSleepBeforeFetchingJobDetailsAgain = 30000;

        /// <summary>
        /// Resource credentials holds vault, cloud service name, vault key and other details.
        /// </summary>
        [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1401:FieldsMustBePrivate",
        Justification = "For Resource Credentials.")]
        public static ASRVaultCreds asrVaultCreds = new ASRVaultCreds();

        public static string idPrefixtillvaultName = string.Empty;

        /// <summary>
        /// Recovery Services client.
        /// </summary>
        private SiteRecoveryVaultManagementClient recoveryServicesClient;

        /// <summary>
        /// End point Uri
        /// </summary>
        private static Uri endPointUri;

        /// <summary>
        /// Subscription Cloud credentials
        /// </summary>
        private static SubscriptionCloudCredentials cloudCredentials;

        /// <summary>
        /// Initializes a new instance of the <see cref="PSRecoveryServicesClient" /> class with 
        /// required current subscription.
        /// </summary>
        /// <param name="azureSubscription">Azure Subscription</param>
        public PSRecoveryServicesClient(IAzureProfile azureProfile)
        {
            System.Configuration.Configuration siteRecoveryConfig = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);

            System.Configuration.AppSettingsSection appSettings = (System.Configuration.AppSettingsSection)siteRecoveryConfig.GetSection("appSettings");

            string resourceNamespace = string.Empty;
            string resourceType = string.Empty;

            // Get Resource provider namespace and type from config only if Vault context is not set
            // (hopefully it is required only for Vault related cmdlets)
            if (string.IsNullOrEmpty(asrVaultCreds.ResourceNamespace) ||
                string.IsNullOrEmpty(asrVaultCreds.ARMResourceType))
            {
                if (appSettings.Settings.Count == 0)
                {
                    resourceNamespace = "Microsoft.SiteRecovery"; // ProviderNameSpace for Production is taken as default
                    resourceType = ARMResourceTypeConstants.SiteRecoveryVault;
                }
                else
                {
                    resourceNamespace =
                        null == appSettings.Settings["ProviderNamespace"]
                        ? "Microsoft.SiteRecovery"
                        : appSettings.Settings["ProviderNamespace"].Value;
                    resourceType =
                        null == appSettings.Settings["ResourceType"]
                        ? ARMResourceTypeConstants.SiteRecoveryVault
                        : appSettings.Settings["ResourceType"].Value;
                }

                Utilities.UpdateCurrentVaultContext(new ASRVaultCreds()
                {
                    ResourceNamespace = resourceNamespace,
                    ARMResourceType = resourceType
                });
            }

            if (null == endPointUri)
            {
                if (appSettings.Settings.Count == 0)
                {
                    endPointUri = azureProfile.Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager);
                }
                else
                {
                    if (null == appSettings.Settings["RDFEProxy"])
                    {
                        endPointUri = azureProfile.Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager);

                    }
                    else
                    {
                        // Setting Endpoint to RDFE Proxy
                        if (null == ServicePointManager.ServerCertificateValidationCallback)
                        {
                            ServicePointManager.ServerCertificateValidationCallback =
                                IgnoreCertificateErrorHandler;
                        }

                        endPointUri = new Uri(appSettings.Settings["RDFEProxy"].Value);
                    }
                }
            }

            cloudCredentials = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(azureProfile.Context);
            this.recoveryServicesClient =
            AzureSession.ClientFactory.CreateCustomClient<SiteRecoveryVaultManagementClient>(
                asrVaultCreds.ResourceNamespace,
                asrVaultCreds.ARMResourceType,
                cloudCredentials,
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

        /// <summary>
        /// Validates current in-memory Vault Settings.
        /// </summary>
        /// <param name="resourceName">Resource Name</param>
        /// <param name="resourceGroupName">Cloud Service Name</param>
        /// <returns>Whether Vault settings are valid or not</returns>
        public bool ValidateVaultSettings(
            string resourceName,
            string resourceGroupName)
        {
            if (string.IsNullOrEmpty(resourceName) || string.IsNullOrEmpty(resourceGroupName))
            {
                throw new InvalidOperationException(Properties.Resources.MissingVaultSettings);
            }

            bool validResourceGroup = false;
            bool validResource = false;

            foreach (ResourceGroup resourceGroup in this.GetRecoveryServicesClient.ResourceGroup.List())
            {
                if (string.Compare(resourceGroup.Name, resourceGroupName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    validResourceGroup = true;
                    break;
                }
            }

            if (!validResourceGroup)
            {
                throw new ArgumentException(Properties.Resources.InvalidResourceGroup);
            }

            foreach (Vault vault in GetRecoveryServicesClient.Vaults.Get(resourceGroupName, this.GetRequestHeaders(false)))
            {
                if (string.Compare(vault.Name, resourceName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    validResource = true;
                    idPrefixtillvaultName = vault.Id;
                    break;
                }
            }

            if (!validResource)
            {
                throw new ArgumentException(Properties.Resources.InvalidResource);
            }

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

        public static string GetJobIdFromReponseLocation(string responseLocation)
        {
            const string operationResults = "operationresults";

            var startIndex = responseLocation.IndexOf(operationResults, StringComparison.OrdinalIgnoreCase) + operationResults.Length + 1;
            var endIndex = responseLocation.IndexOf("?", startIndex, StringComparison.OrdinalIgnoreCase);

            return responseLocation.Substring(startIndex, endIndex - startIndex);
        }

        /// <summary>
        /// Site Recovery requests that go to on-premise components (like the Provider installed
        /// in VMM) require an authentication token that is signed with the vault key to indicate
        /// that the request indeed originated from the end-user client.
        /// Generating that authentication token here and sending it via http headers.
        /// </summary>
        /// <param name="clientRequestId">Unique identifier for the client's request</param>
        /// <returns>The authentication token for the provider</returns>
        public string GenerateAgentAuthenticationHeader(string clientRequestId)
        {
            CikTokenDetails cikTokenDetails = new CikTokenDetails();

            DateTime currentDateTime = DateTime.Now;
            currentDateTime = currentDateTime.AddHours(-1);
            cikTokenDetails.NotBeforeTimestamp = TimeZoneInfo.ConvertTimeToUtc(currentDateTime);
            cikTokenDetails.NotAfterTimestamp = cikTokenDetails.NotBeforeTimestamp.AddDays(7);
            cikTokenDetails.ClientRequestId = clientRequestId;
            cikTokenDetails.Version = new Version(1, 2);
            cikTokenDetails.PropertyBag = new Dictionary<string, object>();

            string shaInput = new JavaScriptSerializer().Serialize(cikTokenDetails);

            if (null == asrVaultCreds.ChannelIntegrityKey)
            {
                throw new ArgumentException(Properties.Resources.MissingChannelIntergrityKey);
            }
            HMACSHA256 sha = new HMACSHA256(Encoding.UTF8.GetBytes(asrVaultCreds.ChannelIntegrityKey));
            cikTokenDetails.Hmac =
                Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(shaInput)));
            cikTokenDetails.HashFunction = CikSupportedHashFunctions.HMACSHA256.ToString();

            return new JavaScriptSerializer().Serialize(cikTokenDetails);
        }

        /// <summary>
        /// Gets request headers.
        /// </summary>
        /// <param name="shouldSignRequest">specifies whether to sign the request or not</param>
        /// <returns>Custom request headers</returns>
        public CustomRequestHeaders GetRequestHeaders(bool shouldSignRequest = true)
        {
            this.ClientRequestId = Guid.NewGuid().ToString() + "-" + DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ssZ") + "-P";

            return new CustomRequestHeaders()
            {
                // ClientRequestId is a unique ID for every request to Azure Site Recovery.
                // It is useful when diagnosing failures in API calls.
                ClientRequestId = this.ClientRequestId,
                AgentAuthenticationHeader = shouldSignRequest ? this.GenerateAgentAuthenticationHeader(this.ClientRequestId) : ""
            };
        }

        /// <summary>
        /// Gets Site Recovery client.
        /// </summary>
        /// <returns>Site Recovery Management client</returns>
        private SiteRecoveryManagementClient GetSiteRecoveryClient()
        {
            this.ValidateVaultSettings(
                asrVaultCreds.ResourceName,
                asrVaultCreds.ResourceGroupName);

            SiteRecoveryManagementClient siteRecoveryClient =
                AzureSession.ClientFactory.CreateCustomClient<SiteRecoveryManagementClient>(
                asrVaultCreds.ResourceName,
                asrVaultCreds.ResourceGroupName,
                asrVaultCreds.ResourceNamespace,
                asrVaultCreds.ARMResourceType,
                cloudCredentials,
                endPointUri);

            if (null == siteRecoveryClient)
            {
                throw new InvalidOperationException(Properties.Resources.NullRecoveryServicesClient);
            }

            return siteRecoveryClient;
        }
    }

    /// <summary>
    /// Helper around serialization/deserialization of objects. This one is a thin wrapper around
    /// DataContractUtils template class which is the one doing the heavy lifting.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public static class DataContractUtils
    {
        /// <summary>
        /// Serializes the supplied object to the string.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="obj">Object to serialize</param>
        /// <returns>Serialized string.</returns>
        public static string Serialize<T>(T obj)
        {
            return DataContractUtils<T>.Serialize(obj);
        }

        /// <summary>
        /// Deserialize the string to the expected object type.
        /// </summary>
        /// <typeparam name="T">The object type</typeparam>
        /// <param name="xmlString">Serialized string</param>
        /// <param name="result">Deserialized object</param>
        public static void Deserialize<T>(string xmlString, out T result)
        {
            result = DataContractUtils<T>.Deserialize(xmlString);
        }
    }

    /// <summary>
    /// Template class for DataContractUtils.
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public static class DataContractUtils<T>
    {
        /// <summary>
        /// Serializes the propertyBagContainer to the string. 
        /// </summary>
        /// <param name="propertyBagContainer">Property bag</param>
        /// <returns>Serialized string </returns>
        public static string Serialize(T propertyBagContainer)
        {
            var serializer = new DataContractSerializer(typeof(T));
            string xmlString;
            StringWriter sw = null;
            try
            {
                sw = new StringWriter();
                using (var writer = new XmlTextWriter(sw))
                {
                    // Indent the XML so it's human readable.
                    writer.Formatting = Formatting.Indented;
                    serializer.WriteObject(writer, propertyBagContainer);
                    writer.Flush();
                    xmlString = sw.ToString();
                }
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }

            return xmlString;
        }

        /// <summary>
        /// Deserialize the string to the propertyBagContainer.
        /// </summary>
        /// <param name="xmlString">Serialized string</param>
        /// <returns>Deserialized object</returns>
        public static T Deserialize(string xmlString)
        {
            T propertyBagContainer;
            using (Stream stream = new MemoryStream())
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xmlString);
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
                propertyBagContainer = (T)deserializer.ReadObject(stream);
            }

            return propertyBagContainer;
        }
    }
}