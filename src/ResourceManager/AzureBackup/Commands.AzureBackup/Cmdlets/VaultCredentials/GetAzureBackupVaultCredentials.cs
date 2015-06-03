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

using Microsoft.Azure.Management.BackupServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// API to download the azure backup vault's credentials.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureBackupVaultCredentials"), OutputType(typeof(string))]
    public class GetAzureBackupVaultCredentials : AzureBackupVaultCmdletBase
    {
        [Parameter(Position = 2, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.TargetLocation)]
        [ValidateNotNullOrEmpty]
        public string TargetLocation { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteVerbose(string.Format("Profile == null : {0}", (Profile == null).ToString()));
                WriteVerbose(string.Format("Profile.DefaultSubscription == null : {0}", (Profile.DefaultSubscription == null).ToString()));
                string subscriptionId = Profile.DefaultSubscription.Id.ToString();
                string resourceType = "resourceType";
                string displayName = subscriptionId + "_" + ResourceGroupName + "_" + ResourceName;

                WriteVerbose(string.Format(CultureInfo.InvariantCulture,
                                          "Executing cmdlet with SubscriptionId = {0}, ResourceGroupName = {1}, ResourceName = {2}, TargetLocation = {3}",
                                          subscriptionId, ResourceGroupName, ResourceName, TargetLocation));

                X509Certificate2 cert = CertUtils.CreateSelfSignedCert(CertUtils.DefaultIssuer,
                                                                       CertUtils.GenerateCertFriendlyName(subscriptionId, ResourceName),
                                                                       CertUtils.DefaultPassword,
                                                                       DateTime.UtcNow.AddMinutes(-10),
                                                                       DateTime.UtcNow.AddHours(this.GetCertificateExpiryInHours()));

                AcsNamespace acsNamespace = new AcsNamespace();

                string channelIntegrityKey = string.Empty;
                try
                {
                    // Upload cert into acs namespace
                    WriteVerbose(string.Format(CultureInfo.InvariantCulture, "RecoveryService - Going to upload the certificate"));
                    acsNamespace = UploadCert(cert, subscriptionId, ResourceName, resourceType, ResourceGroupName);
                    WriteVerbose(string.Format(CultureInfo.InvariantCulture, "RecoveryService - Successfully uploaded the certificate"));
                }
                catch (Exception exception)
                {
                    throw exception;
                }

                // generate vault credentials
                string vaultCredsFileContent = GenerateVaultCreds(cert, subscriptionId, resourceType, acsNamespace);

                // prepare for download
                string fileName = string.Format("{0}_{1}.VaultCredentials", displayName, DateTime.UtcNow.ToLongDateString());
                string filePath = Path.Combine(Path.GetDirectoryName(TargetLocation), fileName);
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
            return Constants.VaultCertificateExpiryInHoursForBackup;
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

            string response = string.Empty;
            VaultCredUploadCertResponse vaultCredUploadCertResponse =
                AzureBackupClient.VaultCredentials.UploadCertificateAsync(
                    "IdMgmtInternalCert",
                    vaultCredUploadCertRequest,
                    GetCustomRequestHeaders(),
                    CmdletCancellationToken).Result;

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
                                                                             ResourceName,
                                                                             CertUtils.SerializeCert(cert, X509ContentType.Pfx),
                                                                             acsNamespace);

                    DataContractSerializer serializer = new DataContractSerializer(typeof(BackupVaultCreds));
                    serializer.WriteObject(writer, backupVaultCreds);

                    WriteVerbose(string.Format(CultureInfo.InvariantCulture, "RecoveryService - Backup Vault - Successfully serialized the file content"));
                }

                return Encoding.UTF8.GetString(output.ToArray());
            }
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