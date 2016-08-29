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
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Hyak.Common;
using Microsoft.Azure.Commands.RecoveryServices.Properties;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using rpError = Microsoft.Azure.Commands.RecoveryServices.RestApiInfra;

namespace Microsoft.Azure.Commands.RecoveryServices
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
                arsVaultCreds.ResourceGroupName,
                arsVaultCreds.ResourceName,
                this.GetRequestHeaders());

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
                arsVaultCreds.ResourceGroupName,
                arsVaultCreds.ResourceName,
                extendedInfoArgs,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Updates the vault certificate
        /// </summary>
        /// <param name="args">the certificate update arguments</param>
        /// <returns>Upload Certificate Response</returns>
        public async Task<UploadCertificateResponse> UpdateVaultCertificate(CertificateArgs args, string certFriendlyName)
        {
            return await this.recoveryServicesClient.VaultExtendedInfo.UploadCertificateAsync(
                arsVaultCreds.ResourceGroupName, 
                arsVaultCreds.ResourceName,
                args, certFriendlyName, 
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Gets the vault credential object
        /// </summary>
        /// <param name="managementCert">certificate to be uploaded</param>
        /// <param name="vault">vault object</param>
        /// <returns>credential object</returns>
        public ASRVaultCreds GenerateVaultCredential(X509Certificate2 managementCert, ARSVault vault, ASRSite site)
        {
            ASRVaultCreds currentVaultContext = PSRecoveryServicesClient.arsVaultCreds;

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

            ASRVaultCreds arsVaultCreds = this.GenerateCredentialObject(
                                                managementCert,
                                                acsDetails,
                                                channelIntegrityKey,
                                                vault,
                                                site);

            // Update back the original vault settings
            Utilities.UpdateCurrentVaultContext(currentVaultContext);

            return arsVaultCreds;
        }

        /// <summary>
        /// Upload cert to idmgmt
        /// </summary>
        /// <param name="managementCert">certificate to be uploaded</param>
        /// <param name="vault">vault object</param>
        /// <returns>Upload Certificate Response</returns>
        public UploadCertificateResponse UploadCertificate(X509Certificate2 managementCert, ARSVault vault)
        {
            var certificateArgs = new CertificateArgs();
            certificateArgs.Properties = new Dictionary<string, string>();
            certificateArgs.Properties.Add("certificate", Convert.ToBase64String(managementCert.GetRawCertData()));

            var response = this.recoveryServicesClient.VaultExtendedInfo.UploadCertificateAsync(
                vault.ResourceGroupName,
                vault.Name,
                certificateArgs, managementCert.FriendlyName,
                this.GetRequestHeaders());
            response.Wait();
            return response.Result;
        }

        /// <summary>
        /// Changes the Vault context
        /// </summary>
        /// <param name="vault">vault object</param>
        /// <returns>credential object</returns>
        public ASRVaultCreds ChangeVaultContext(ARSVault vault)
        {
            string resourceProviderNamespace = string.Empty;
            string resourceType = string.Empty;
            Utilities.GetResourceProviderNamespaceAndType(vault.ID, out resourceProviderNamespace, out resourceType);
            Utilities.UpdateCurrentVaultContext(new ASRVaultCreds()
            {
                ResourceGroupName = vault.ResourceGroupName,
                ResourceName = vault.Name,
                ResourceNamespace = resourceProviderNamespace,
                ARMResourceType= resourceType
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

            return arsVaultCreds;
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

                    if (error.ErrorCode.Equals(RpErrorCode.ResourceExtendedInfoNotFound.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        extendedInformation = new ResourceExtendedInformation();
                    }
                }
            }

            if (null == extendedInformation.Properties)
            {
                extendedInformation = this.CreateVaultExtendedInformation();
            }
            else
            {
                if (!extendedInformation.Properties.Algorithm.Equals(CryptoAlgorithm.None.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    // In case this condition is true that means the credential was first generated in portal
                    // and hence can not be fetched here.
                    throw new CloudException(Resources.VaultSettingsGenerationUnSupported);
                }
            }

            return extendedInformation.Properties.IntegrityKey;
        }

        /// <summary>
        /// Method to create the extended info for the vault.
        /// </summary>
        /// <returns>returns the object as task</returns>
        private ResourceExtendedInformation CreateVaultExtendedInformation()
        {
            ResourceExtendedInformation extendedInformation =
                new ResourceExtendedInformation();
            extendedInformation.Properties = new ResourceExtendedInfoProperties();
            extendedInformation.Properties.IntegrityKey = Utilities.GenerateRandomKey(128);
            extendedInformation.Properties.Algorithm = CryptoAlgorithm.None.ToString();

            ResourceExtendedInformationArgs extendedInfoArgs = new ResourceExtendedInformationArgs();
            extendedInfoArgs.Properties = new ResourceExtendedInfoProperties();
            extendedInfoArgs.Properties.Algorithm = extendedInformation.Properties.Algorithm;
            extendedInfoArgs.Properties.IntegrityKey = extendedInformation.Properties.IntegrityKey;

            this.CreateExtendedInfo(extendedInfoArgs);

            return extendedInformation;
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
        private ASRVaultCreds GenerateCredentialObject(X509Certificate2 managementCert, UploadCertificateResponse acsDetails, string channelIntegrityKey, ARSVault vault, ASRSite site)
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
                                            resourceType,
                                            vault.Location);

            return vaultCreds;
        }
    }
}
