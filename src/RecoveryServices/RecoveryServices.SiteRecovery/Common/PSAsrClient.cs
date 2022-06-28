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
using System.Net.Security;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
// TODO: Remove IfDef
#if NETSTANDARD
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
#endif
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Newtonsoft.Json;
using Microsoft.Rest.Azure;
using rpError = Microsoft.Azure.Commands.RecoveryServices.RestApiInfra;
using Formatting = System.Xml.Formatting;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        ///     Amount of time to sleep before fetching job details again.
        /// </summary>
        public const int TimeToSleepBeforeFetchingJobDetailsAgain = 30000;

        /// <summary>
        ///     Resource credentials holds vault, cloud service name, vault key and other details.
        /// </summary>
        [SuppressMessage(
            "Microsoft.StyleCop.CSharp.MaintainabilityRules",
            "SA1401:FieldsMustBePrivate",
            Justification = "For Resource Credentials.")]
        public static ASRVaultCreds asrVaultCreds = new ASRVaultCreds();

        private static AzureContext AzureContext;

        /// <summary>
        ///     Subscription Cloud credentials
        /// </summary>
        private static SubscriptionCloudCredentials cloudCredentials;

        /// <summary>
        ///     End point Uri
        /// </summary>
        private static Uri endPointUri;

        public static string idPrefixtillvaultName = string.Empty;

        /// <summary>
        ///     Recovery services vault management client.
        /// </summary>
        private readonly RecoveryServicesClient recoveryServicesVaultClient;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PSRecoveryServicesClient" /> class with
        ///     required current subscription.
        /// </summary>
        /// <param name="azureProfile">Azure context.</param>
        public PSRecoveryServicesClient(
            IAzureContextContainer azureProfile)
        {
            AzureContext = (AzureContext)azureProfile.DefaultContext;

            var resourceNamespace = ARMResourceTypeConstants
                .RecoveryServicesResourceProviderNameSpace;
            var resourceType = ARMResourceTypeConstants.RecoveryServicesVault;

            // Get Resource provider namespace and type from config only if Vault context is not set
            // (hopefully it is required only for Vault related cmdlets)
            if (string.IsNullOrEmpty(asrVaultCreds.ResourceNamespace) ||
                string.IsNullOrEmpty(asrVaultCreds.ARMResourceType))
            {
                Utilities.UpdateCurrentVaultContext(
                    new ASRVaultCreds
                    {
                        ResourceNamespace = resourceNamespace,
                        ARMResourceType = resourceType
                    });
            }

            if (null == endPointUri)
            {
                endPointUri =
                    azureProfile.DefaultContext.Environment.GetEndpointAsUri(
                        AzureEnvironment.Endpoint.ResourceManager);
            }

            cloudCredentials = AzureSession.Instance.AuthenticationFactory
                .GetSubscriptionCloudCredentials(azureProfile.DefaultContext);
            this.recoveryServicesVaultClient = AzureSession.Instance.ClientFactory
                .CreateArmClient<RecoveryServicesClient>(
                    AzureContext,
                    AzureEnvironment.Endpoint.ResourceManager);
        }

        /// <summary>
        ///     client request id.
        /// </summary>
        public string ClientRequestId { get; set; }

        /// <summary>
        ///     Gets the value of recovery services vault management client.
        /// </summary>
        public RecoveryServicesClient GetRecoveryServicesVaultClient => this
            .recoveryServicesVaultClient;

        /// <summary>
        ///     Site Recovery requests that go to on-premise components (like the Provider installed
        ///     in VMM) require an authentication token that is signed with the vault key to indicate
        ///     that the request indeed originated from the end-user client.
        ///     Generating that authentication token here and sending it via http headers.
        /// </summary>
        /// <param name="clientRequestId">Unique identifier for the client's request</param>
        /// <param name="dateTime">Optional , datetime used for header genertion</param>
        /// <returns>The authentication token for the provider</returns>
        public static string GenerateAgentAuthenticationHeader(
            string clientRequestId,
            DateTime? dateTime = null)
        {
            var cikTokenDetails = new CikTokenDetails();

            var currentDateTime = dateTime == null ? DateTime.Now : dateTime.Value;
            currentDateTime = currentDateTime.AddHours(-1);
            cikTokenDetails.NotBeforeTimestamp = TimeZoneInfo.ConvertTimeToUtc(currentDateTime);
            cikTokenDetails.NotAfterTimestamp = cikTokenDetails.NotBeforeTimestamp.AddDays(7);
            cikTokenDetails.ClientRequestId = clientRequestId;
            cikTokenDetails.Version = new Version(
                1,
                2);
            cikTokenDetails.PropertyBag = new Dictionary<string, object>();

            JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };

            var shaInput = JsonConvert.SerializeObject(cikTokenDetails, microsoftDateFormatSettings);

            if (null == asrVaultCreds.ChannelIntegrityKey)
            {
                throw new ArgumentException(Resources.MissingChannelIntergrityKey);
            }

            var sha = new HMACSHA256(Encoding.UTF8.GetBytes(asrVaultCreds.ChannelIntegrityKey));
            cikTokenDetails.Hmac =
                Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(shaInput)));
            cikTokenDetails.HashFunction = CikSupportedHashFunctions.HMACSHA256.ToString();

            return JsonConvert.SerializeObject(cikTokenDetails, microsoftDateFormatSettings);
        }

        /// <summary>
        ///     Get extendVault Info.
        /// </summary>
        /// <param name="vaultResourceGroupName">Vault ResourceGroup Name</param>
        /// <param name="vaultName">Vault Name</param>
        /// <returns>VaultExtendedInfo Resource Object</returns>
        public VaultExtendedInfoResource GetVaultExtendedInfo(String vaultResourceGroupName, String vaultName)
        {
            VaultExtendedInfoResource extendedInformation = null;

            try
            {
                extendedInformation = this.recoveryServicesVaultClient
                                         .VaultExtendedInfo
                                         .GetWithHttpMessagesAsync(vaultResourceGroupName, vaultName, this.GetRequestHeaders(false))
                                         .GetAwaiter()
                                         .GetResult()
                                         .Body;
            }
            catch (Exception exception)
            {
                CloudException cloudException = exception as CloudException;

                if (!string.IsNullOrEmpty(cloudException?.Response?.Content))
                {
                    rpError.Error error = JsonConvert.DeserializeObject<rpError.Error>(cloudException.Response.Content);

                    if (error.ErrorCode.Equals(
                        RpErrorCode.ResourceExtendedInfoNotFound.ToString(),
                        StringComparison.InvariantCultureIgnoreCase))
                    {
                        extendedInformation = new VaultExtendedInfoResource();
                        extendedInformation.IntegrityKey = Utilities.GenerateRandomKey(128);
                        extendedInformation.Algorithm = CryptoAlgorithm.None.ToString();
                        extendedInformation = this.recoveryServicesVaultClient.VaultExtendedInfo.CreateOrUpdateWithHttpMessagesAsync(
                                                vaultResourceGroupName,
                                                vaultName,
                                                extendedInformation,
                                                GetRequestHeaders(false)).Result.Body;
                    }
                }
            }

            return extendedInformation;
        }

        public static string GetJobIdFromReponseLocation(
            string responseLocation)
        {
            const string operationResults = "operationresults";

            var startIndex = responseLocation.IndexOf(
                                 operationResults,
                                 StringComparison.OrdinalIgnoreCase) +
                             operationResults.Length +
                             1;
            var endIndex = responseLocation.IndexOf(
                "?",
                startIndex,
                StringComparison.OrdinalIgnoreCase);

            return responseLocation.Substring(
                startIndex,
                endIndex - startIndex);
        }

        /// <summary>
        ///     Gets request headers.
        /// </summary>
        /// <param name="shouldSignRequest">specifies whether to sign the request or not</param>
        /// <returns>Custom request headers</returns>
        public Dictionary<string, List<string>> GetRequestHeaders(
            bool shouldSignRequest = true)
        {
            var customHeaders = new Dictionary<string, List<string>>();

            this.ClientRequestId = Guid.NewGuid() +
                                   "-" +
                                   DateTime.Now.ToUniversalTime()
                                       .ToString("yyyy-MM-dd HH:mm:ssZ") +
                                   "-Ps";

            customHeaders.Add(
                "x-ms-client-request-id",
                new List<string> { this.ClientRequestId });

            if (shouldSignRequest)
            {
                customHeaders.Add(
                    "Agent-Authentication",
                    new List<string>
                    {
                        GenerateAgentAuthenticationHeader(this.ClientRequestId)
                    });
            }
            else
            {
                customHeaders.Add(
                    "Agent-Authentication",
                    new List<string> { "" });
            }

            return customHeaders;
        }

        public static string GetResourceGroup(
            string resourceId)
        {
            const string resourceGroup = "resourceGroups";

            var startIndex = resourceId.IndexOf(
                                 resourceGroup,
                                 StringComparison.OrdinalIgnoreCase) +
                             resourceGroup.Length +
                             1;
            var endIndex = resourceId.IndexOf(
                "/",
                startIndex,
                StringComparison.OrdinalIgnoreCase);

            return resourceId.Substring(
                startIndex,
                endIndex - startIndex);
        }

        public static string GetSubscriptionId(
            string resourceId)
        {
            const string subscriptions = "subscriptions";

            var startIndex = resourceId.IndexOf(
                                 subscriptions,
                                 StringComparison.OrdinalIgnoreCase) +
                             subscriptions.Length +
                             1;
            var endIndex = resourceId.IndexOf(
                "/",
                startIndex,
                StringComparison.OrdinalIgnoreCase);

            return resourceId.Substring(
                startIndex,
                endIndex - startIndex);
        }

        /// <summary>
        ///     Validates current in-memory Vault Settings.
        /// </summary>
        /// <param name="resourceName">Resource Name</param>
        /// <param name="resourceGroupName">Cloud Service Name</param>
        /// <returns>Whether Vault settings are valid or not</returns>
        public bool ValidateVaultSettings(
            string resourceName,
            string resourceGroupName)
        {
            if (string.IsNullOrEmpty(resourceName) ||
                string.IsNullOrEmpty(resourceGroupName))
            {
                throw new InvalidOperationException(Resources.MissingVaultSettings);
            }

            var validResource = false;

            //foreach (Management.RecoveryServices.Models.ResourceGroup resourceGroup in this.GetRecoveryServicesVaultClient.ResourceGroup.List())
            //{
            //    if (string.Compare(resourceGroup.Name, resourceGroupName, StringComparison.OrdinalIgnoreCase) == 0)
            //    {
            //        validResourceGroup = true;
            //        break;
            //    }
            //}

            //if (!validResourceGroup)
            //{
            //    throw new ArgumentException(Properties.Resources.InvalidResourceGroup);
            //}

            foreach (var vault in this.GetRecoveryServicesVaultClient.Vaults.ListByResourceGroup(
                resourceGroupName))
            {
                if (string.Compare(
                        vault.Name,
                        resourceName,
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    validResource = true;
                    idPrefixtillvaultName = vault.Id;
                    break;
                }
            }

            if (!validResource)
            {
                throw new ArgumentException(Resources.InvalidResource);
            }

            return true;
        }

        /// <summary>
        ///     Gets Site Recovery client.
        /// </summary>
        /// <returns>Site Recovery Management client</returns>
        private SiteRecoveryManagementClient GetSiteRecoveryClient()
        {
            if (string.IsNullOrEmpty(asrVaultCreds.ResourceName) ||
                string.IsNullOrEmpty(asrVaultCreds.ResourceGroupName))
            {
                throw new InvalidOperationException(Resources.MissingVaultSettings);
            }

            var creds =
                AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(
                    AzureContext);

            var siteRecoveryClient = AzureSession.Instance.ClientFactory
                .CreateArmClient<SiteRecoveryManagementClient>(
                    AzureContext,
                    AzureEnvironment.Endpoint.ResourceManager);

            siteRecoveryClient.ResourceGroupName = asrVaultCreds.ResourceGroupName;
            siteRecoveryClient.ResourceName = asrVaultCreds.ResourceName;
            siteRecoveryClient.SubscriptionId = cloudCredentials.SubscriptionId;
            siteRecoveryClient.BaseUri = endPointUri;

            if (null == siteRecoveryClient)
            {
                throw new InvalidOperationException(Resources.NullRecoveryServicesClient);
            }

            return siteRecoveryClient;
        }

        private static bool IgnoreCertificateErrorHandler(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }

    /// <summary>
    ///     Helper around serialization/deserialization of objects. This one is a thin wrapper around
    ///     DataContractUtils template class which is the one doing the heavy lifting.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public static class DataContractUtils
    {
        /// <summary>
        ///     Deserialize the string to the expected object type.
        /// </summary>
        /// <typeparam name="T">The object type</typeparam>
        /// <param name="xmlString">Serialized string</param>
        /// <param name="result">Deserialized object</param>
        public static void Deserialize<T>(
            string xmlString,
            out T result)
        {
            result = DataContractUtils<T>.Deserialize(xmlString);
        }

        /// <summary>
        ///     Serializes the supplied object to the string.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="obj">Object to serialize</param>
        /// <returns>Serialized string.</returns>
        public static string Serialize<T>(
            T obj)
        {
            return DataContractUtils<T>.Serialize(obj);
        }
    }

    /// <summary>
    ///     Template class for DataContractUtils.
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public static class DataContractUtils<T>
    {
        /// <summary>
        ///     Deserialize the string to the propertyBagContainer.
        /// </summary>
        /// <param name="xmlString">Serialized string</param>
        /// <returns>Deserialized object</returns>
        public static T Deserialize(
            string xmlString)
        {
            T propertyBagContainer;
            using (Stream stream = new MemoryStream())
            {
                var data = Encoding.UTF8.GetBytes(xmlString);
                stream.Write(
                    data,
                    0,
                    data.Length);
                stream.Position = 0;
                var deserializer = new DataContractSerializer(typeof(T));
                propertyBagContainer = (T)deserializer.ReadObject(stream);
            }

            return propertyBagContainer;
        }

        /// <summary>
        ///     Serializes the propertyBagContainer to the string.
        /// </summary>
        /// <param name="propertyBagContainer">Property bag</param>
        /// <returns>Serialized string </returns>
        public static string Serialize(
            T propertyBagContainer)
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
                    serializer.WriteObject(
                        writer,
                        propertyBagContainer);
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
    }
}
