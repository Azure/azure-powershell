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

using Hyak.Common;
using Microsoft.Azure.Commands.SiteRecovery.Properties;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Management.SiteRecoveryVault;
using Microsoft.Azure.Portal.HybridServicesCore;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using rpError = Microsoft.Azure.Commands.SiteRecovery.RestApiInfra;


namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Gets Vault Extended Information
        /// </summary>
        /// <returns>Vault Extended Information Response</returns>
        public async Task<ResourceExtendedInformation> GetExtendedInfo()
        {
            ResourceExtendedInformationResponse response =
                await this.recoveryServicesClient.VaultExtendedInfo.GetExtendedInfoAsync(
                asrVaultCreds.ResourceGroupName,
                asrVaultCreds.ResourceName,
                this.GetRequestHeaders(false));

            return response.ResourceExtendedInformation;
        }

        /// <summary>
        /// Creates the extended information for the vault
        /// </summary>
        /// <param name="extendedInfoArgs">extended info to be created</param>
        /// <returns>Vault Extended Information</returns>
        public AzureOperationResponse CreateExtendedInfo(ResourceExtendedInformationArgs extendedInfoArgs)
        {
            return this.recoveryServicesClient.VaultExtendedInfo.CreateExtendedInfo(
                asrVaultCreds.ResourceGroupName,
                asrVaultCreds.ResourceName,
                extendedInfoArgs,
                this.GetRequestHeaders(false));
        }

        /// <summary>
        /// Updates the vault certificate
        /// </summary>
        /// <param name="args">the certificate update arguments</param>
        /// <returns>Upload Certificate Response</returns>
        public async Task<UploadCertificateResponse> UpdateVaultCertificate(CertificateArgs args, string certFriendlyName)
        {
            return await this.recoveryServicesClient.VaultExtendedInfo.UploadCertificateAsync(
                asrVaultCreds.ResourceGroupName,
                asrVaultCreds.ResourceName,
                args, certFriendlyName,
                this.GetRequestHeaders(false));
        }

        /// <summary>
        /// Gets the vault credential object
        /// </summary>
        /// <param name="managementCert">certificate to be uploaded</param>
        /// <param name="vault">vault object</param>
        /// <returns>credential object</returns>
        public ASRVaultCreds GenerateVaultCredential(X509Certificate2 managementCert, ASRVault vault, ASRSite site)
        {
            ASRVaultCreds currentVaultContext = new ASRVaultCreds(
                PSRecoveryServicesClient.asrVaultCreds.SubscriptionId,
                PSRecoveryServicesClient.asrVaultCreds.ResourceName,
                PSRecoveryServicesClient.asrVaultCreds.ManagementCert,
                PSRecoveryServicesClient.asrVaultCreds.AcsNamespace,
                PSRecoveryServicesClient.asrVaultCreds.ChannelIntegrityKey,
                PSRecoveryServicesClient.asrVaultCreds.ResourceGroupName,
                PSRecoveryServicesClient.asrVaultCreds.SiteId,
                PSRecoveryServicesClient.asrVaultCreds.SiteName,
                PSRecoveryServicesClient.asrVaultCreds.ResourceNamespace,
                PSRecoveryServicesClient.asrVaultCreds.ResourceType);

            string resourceProviderNamespace = string.Empty;
            string resourceType = string.Empty;
            Utilities.GetResourceProviderNamespaceAndType(vault.ID, out resourceProviderNamespace, out resourceType);
            // Update vault settings with the working vault to generate file
            Utilities.UpdateCurrentVaultContext(new ASRVaultCreds()
            {
                ResourceGroupName = vault.ResourceGroupName,
                ResourceName = vault.Name,
                ResourceNamespace = resourceProviderNamespace,
                ARMResourceType = resourceType
            });

            // Get Channel Integrity key
            string channelIntegrityKey;
            Task<string> getChannelIntegrityKey = this.GetChannelIntegrityKey();

            // Making sure we can generate the file, once the SDK and portal are inter-operable
            // upload certificate and fetch of ACIK can be made parallel to improvve the performace.
            getChannelIntegrityKey.Wait();

            // Upload certificate
            UploadCertificateResponse acsDetails;
            Task<UploadCertificateResponse> uploadCertificate = this.UpdateVaultCertificate(managementCert);
            uploadCertificate.Wait();

            acsDetails = uploadCertificate.Result;
            channelIntegrityKey = getChannelIntegrityKey.Result;

            ASRVaultCreds asrVaultCreds = this.GenerateCredentialObject(
                                                managementCert,
                                                acsDetails,
                                                channelIntegrityKey,
                                                vault,
                                                site);

            // Update back the original vault settings
            Utilities.UpdateCurrentVaultContext(currentVaultContext);

            return asrVaultCreds;
        }

        /// <summary>
        /// Changes the Vault context
        /// </summary>
        /// <param name="vault">vault object</param>
        /// <returns>credential object</returns>
        public ASRVaultCreds ChangeVaultContext(ASRVault vault)
        {
            string resourceProviderNamespace = string.Empty;
            string resourceType = string.Empty;
            Utilities.GetResourceProviderNamespaceAndType(vault.ID, out resourceProviderNamespace, out resourceType);
            Utilities.UpdateCurrentVaultContext(new ASRVaultCreds()
            {
                ResourceGroupName = vault.ResourceGroupName,
                ResourceName = vault.Name,
                ResourceNamespace = resourceProviderNamespace,
                ARMResourceType = resourceType
            });

            // Get Channel Integrity key
            Task<string> getChannelIntegrityKey = this.GetChannelIntegrityKey();
            getChannelIntegrityKey.Wait();

            // Update vault settings along with Channel integrity key
            Utilities.UpdateCurrentVaultContext(new ASRVaultCreds()
            {
                ResourceGroupName = vault.ResourceGroupName,
                ResourceName = vault.Name,
                ChannelIntegrityKey = getChannelIntegrityKey.Result,
                ResourceNamespace = resourceProviderNamespace,
                ARMResourceType = resourceType
            });

            return asrVaultCreds;
        }

        /// <summary>
        /// Method to update vault certificate
        /// </summary>
        /// <param name="cert">certificate object </param>
        /// <returns>Upload Certificate Response</returns>
        private async Task<UploadCertificateResponse> UpdateVaultCertificate(X509Certificate2 cert)
        {
            var certificateArgs = new CertificateArgs();
            certificateArgs.Properties = new Dictionary<string, string>();
            certificateArgs.Properties.Add("certificate", Convert.ToBase64String(cert.GetRawCertData()));
            // CertificateArgs.Properties.Add("ContractVersion", "V2012_12");

            UploadCertificateResponse response = await this.UpdateVaultCertificate(certificateArgs, cert.FriendlyName);

            return response;
        }

        /// <summary>
        /// Get the Integrity key
        /// </summary>
        /// <returns>key as string.</returns>
        private async Task<string> GetChannelIntegrityKey()
        {
            ResourceExtendedInformation extendedInformation = null;
            try
            {
                extendedInformation = await this.GetExtendedInfo();
            }
            catch (Exception exception)
            {
                CloudException cloudException = exception as CloudException;

                if (cloudException != null && cloudException.Response != null && !string.IsNullOrEmpty(cloudException.Response.Content))
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    rpError.Error error = serializer.Deserialize<rpError.Error>(cloudException.Response.Content);

                    // rpError.Error error = (rpError.Error)Utilities.Deserialize<rpError.Error>(cloudException.Response.Content);
                    if (error.ErrorCode.Equals(RpErrorCode.ResourceExtendedInfoNotFound.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        extendedInformation = new ResourceExtendedInformation();
                    }
                }
            }

            ResourceExtendedInfo extendedInfo = Utilities.Deserialize<ResourceExtendedInfo>(extendedInformation.ExtendedInfo);

            if (extendedInfo == null)
            {
                extendedInfo = this.CreateVaultExtendedInformation();
            }
            else
            {
                if (!extendedInfo.Algorithm.Equals(CryptoAlgorithm.None.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    // In case this condition is true that means the credential was first generated in portal
                    // and hence can not be fetched here.
                    throw new CloudException(Resources.VaultSettingsGenerationUnSupported);
                }
            }

            return extendedInfo.ChannelIntegrityKey;
        }

        /// <summary>
        /// Method to create the extended info for the vault.
        /// </summary>
        /// <returns>returns the object as task</returns>
        private ResourceExtendedInfo CreateVaultExtendedInformation()
        {
            ResourceExtendedInfo extendedInfo = new ResourceExtendedInfo();
            extendedInfo.GenerateSecurityInfo();
            ResourceExtendedInformationArgs extendedInfoArgs = extendedInfo.Translate();
            this.CreateExtendedInfo(extendedInfoArgs);

            return extendedInfo;
        }

        /// <summary>
        /// Method to generate the credential file content
        /// </summary>
        /// <param name="managementCert">management cert</param>
        /// <param name="acsDetails">ACS details</param>
        /// <param name="channelIntegrityKey">Integrity key</param>
        /// <param name="vault">vault object</param>
        /// <param name="site">site object</param>
        /// <returns>vault credential object</returns>
        private ASRVaultCreds GenerateCredentialObject(X509Certificate2 managementCert, UploadCertificateResponse acsDetails, string channelIntegrityKey, ASRVault vault, ASRSite site)
        {
            string serializedCertifivate = Convert.ToBase64String(managementCert.Export(X509ContentType.Pfx));

            AcsNamespace acsNamespace = new AcsNamespace(acsDetails);

            string resourceProviderNamespace = string.Empty;
            string resourceType = string.Empty;
            Utilities.GetResourceProviderNamespaceAndType(vault.ID, out resourceProviderNamespace, out resourceType);
            ASRVaultCreds vaultCreds = new ASRVaultCreds(
                                            vault.SubscriptionId,
                                            vault.Name,
                                            serializedCertifivate,
                                            acsNamespace,
                                            channelIntegrityKey,
                                            vault.ResourceGroupName,
                                            site.ID,
                                            site.Name,
                                            resourceProviderNamespace,
                                            resourceType);

            return vaultCreds;
        }
    }
}
