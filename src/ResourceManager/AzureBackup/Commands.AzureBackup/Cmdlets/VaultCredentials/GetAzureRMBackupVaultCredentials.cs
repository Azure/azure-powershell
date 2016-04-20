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

using Microsoft.Azure.Commands.AzureBackup.Library;
using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Command to download an azure backup vault's credentials.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmBackupVaultCredentials"), OutputType(typeof(string))]
    public class GetAzureRMBackupVaultCredentials : AzureBackupVaultCmdletBase
    {
        [Parameter(Position = 2, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.TargetLocation)]
        [ValidateNotNullOrEmpty]
        public string TargetLocation { get; set; }

        private const int VaultCertificateExpiryInHoursForBackup = 48;

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                if (!Directory.Exists(TargetLocation))
                {
                    throw new ArgumentException(Resources.VaultCredPathException);
                }

                string subscriptionId = DefaultContext.Subscription.Id.ToString();
                string resourceType = "BackupVault";
                string displayName = subscriptionId + "_" + Vault.ResourceGroupName + "_" + Vault.Name;

                WriteDebug(string.Format(CultureInfo.InvariantCulture,
                                          Resources.ExecutingGetVaultCredCmdlet,
                                          subscriptionId, Vault.ResourceGroupName, Vault.Name, TargetLocation));

                X509Certificate2 cert = CertUtils.CreateSelfSignedCert(CertUtils.DefaultIssuer,
                                                                       CertUtils.GenerateCertFriendlyName(subscriptionId, Vault.Name),
                                                                       CertUtils.DefaultPassword,
                                                                       DateTime.UtcNow.AddMinutes(-10),
                                                                       DateTime.UtcNow.AddHours(this.GetCertificateExpiryInHours()));

                AcsNamespace acsNamespace = new AcsNamespace();
                string channelIntegrityKey = string.Empty;
                try
                {
                    // Upload cert into ID Mgmt
                    WriteDebug(string.Format(CultureInfo.InvariantCulture, Resources.UploadingCertToIdmgmt));
                    acsNamespace = UploadCert(cert, subscriptionId, Vault.Name, resourceType, Vault.ResourceGroupName);
                    WriteDebug(string.Format(CultureInfo.InvariantCulture, Resources.UploadedCertToIdmgmt));
                }
                catch (Exception exception)
                {
                    throw exception;
                }

                // generate vault credentials
                string vaultCredsFileContent = GenerateVaultCreds(cert, subscriptionId, resourceType, acsNamespace);

                // NOTE: One of the scenarios for this cmdlet is to generate a file which will be an input to DPM servers. 
                //       We found a bug in the DPM UI which is looking for a particular namespace in the input file.
                //       The below is a hack to circumvent this issue and this would be removed once the bug can be fixed.
                vaultCredsFileContent = vaultCredsFileContent.Replace("Microsoft.Azure.Commands.AzureBackup.Models",
                                                                      "Microsoft.Azure.Portal.RecoveryServices.Models.Common");

                // prepare for download
                string fileName = string.Format("{0}_{1}.VaultCredentials", displayName, DateTime.UtcNow.ToString("yyyy-dd-M--HH-mm-ss"));
                string filePath = Path.Combine(TargetLocation, fileName);
                WriteDebug(string.Format(Resources.SavingVaultCred, filePath));

                File.WriteAllBytes(filePath, Encoding.UTF8.GetBytes(vaultCredsFileContent));

                // Output filename back to user
                WriteObject(fileName);
            });
        }

        /// <summary>
        /// Method to return the Certificate Expiry time in hours
        /// </summary>
        /// <param name="resourceType"></param>
        /// <returns></returns>
        private int GetCertificateExpiryInHours(string resourceType = null)
        {
            return VaultCertificateExpiryInHoursForBackup;
        }

        /// <summary>
        /// Upload certificate
        /// </summary>
        /// <param name="cert">management certificate</param>
        /// <param name="subscriptionId">subscription Id</param>
        /// <param name="resourceName">resource name</param>
        /// <param name="resourceType">resource type</param>
        /// <param name="resourceGroupName">resource group name</param>
        /// <returns>acs namespace of the uploaded cert</returns>
        private AcsNamespace UploadCert(X509Certificate2 cert, string subscriptionId, string resourceName, string resourceType, string resourceGroupName)
        {
            string rawCertDataString = Convert.ToBase64String(cert.RawData);
            VaultCredUploadCertRequest vaultCredUploadCertRequest = new VaultCredUploadCertRequest()
            {
                RawCertificateData = new RawCertificateData()
                {
                    Certificate = rawCertDataString,
                },
            };

            var vaultCredUploadCertResponse = AzureBackupClient.UploadCertificate(resourceGroupName, resourceName, "IdMgmtInternalCert", vaultCredUploadCertRequest);

            return new AcsNamespace(vaultCredUploadCertResponse.ResourceCertificateAndACSDetails.GlobalAcsHostName,
                                    vaultCredUploadCertResponse.ResourceCertificateAndACSDetails.GlobalAcsNamespace,
                                    vaultCredUploadCertResponse.ResourceCertificateAndACSDetails.GlobalAcsRPRealm);
        }

        /// <summary>
        /// Generates vault creds file
        /// </summary>
        /// <param name="cert">management certificate</param>
        /// <param name="subscriptionId">subscription Id</param>
        /// <param name="resourceType">resource type</param>
        /// <param name="displayName">display name</param>
        /// <param name="acsNamespace">acs namespace</param>
        /// <returns>xml file in string format</returns>
        private string GenerateVaultCreds(X509Certificate2 cert, string subscriptionId, string resourceType, AcsNamespace acsNamespace)
        {
            try
            {
                return GenerateVaultCredsForBackup(cert, subscriptionId, resourceType, acsNamespace);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Generates vault creds file content for backup Vault
        /// </summary>
        /// <param name="cert">management certificate</param>
        /// <param name="subscriptionId">subscription Id</param>
        /// <param name="resourceType">resource type</param>
        /// <param name="displayName">display name</param>
        /// <param name="acsNamespace">acs namespace</param>
        /// <returns>xml file in string format</returns>
        private string GenerateVaultCredsForBackup(X509Certificate2 cert, string subscriptionId, string resourceType, AcsNamespace acsNamespace)
        {
            using (var output = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(output, GetXmlWriterSettings()))
                {
                    BackupVaultCreds backupVaultCreds = new BackupVaultCreds(subscriptionId,
                                                                             resourceType,
                                                                             Vault.Name,
                                                                             CertUtils.SerializeCert(cert, X509ContentType.Pfx),
                                                                             acsNamespace,
                                                                             GetAgentLinks());
                    DataContractSerializer serializer = new DataContractSerializer(typeof(BackupVaultCreds));
                    serializer.WriteObject(writer, backupVaultCreds);

                    WriteDebug(string.Format(CultureInfo.InvariantCulture, Resources.BackupVaultSerialized));
                }

                return Encoding.UTF8.GetString(output.ToArray());
            }
        }

        private static string GetAgentLinks()
        {
            return "WABUpdateKBLink,http://go.microsoft.com/fwlink/p/?LinkId=229525;" +
                   "StorageQuotaPurchaseLink,http://go.microsoft.com/fwlink/?LinkId=205490;" +
                   "WebPortalLink,http://go.microsoft.com/fwlink/?LinkId=252913;" +
                   "WABprivacyStatement,http://go.microsoft.com/fwlink/?LinkId=221308";
        }

        /// <summary>
        /// A set of XmlWriterSettings to use for the publishing profile
        /// </summary>
        /// <returns>The XmlWriterSettings set</returns>
        private XmlWriterSettings GetXmlWriterSettings()
        {
            return new XmlWriterSettings
            {
                Encoding = new UTF8Encoding(false),
                Indent = true,
                NewLineOnAttributes = true
            };
        }
    }
}
