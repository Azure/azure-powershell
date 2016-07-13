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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.RecoveryServices.Properties;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Retrieves Azure Recovery Services Vault Settings File.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRecoveryServicesVaultSettingsFile")]
    [OutputType(typeof(VaultSettingsFilePath))]
    public class GetAzureRmRecoveryServicesVaultSettingsFile : RecoveryServicesCmdletBase
    {
        /// <summary>
        /// Expiry in hours for generated certificate.
        /// </summary>
        private const int VaultCertificateExpiryInHoursForHRM = 120; 

        /// <summary>
        /// Expiry in hours for generated certificate.
        /// </summary>
        private const int VaultCertificateExpiryInHoursForBackup = 48;

        #region Parameters

        /// <summary>
        /// Gets or sets vault Object.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public ARSVault Vault { get; set; }

        /// <summary>
        /// Gets or sets Site Identifier.
        /// </summary>
        [Parameter(ParameterSetName = ARSParameterSets.ForSite, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public String SiteIdentifier { get; set; }

        /// <summary>
        /// Gets or sets SiteFriendlyName.
        /// </summary>
        [Parameter(ParameterSetName = ARSParameterSets.ForSite, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public String SiteFriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the path where the credential file is to be generated
        /// </summary>
        /// <summary>
        /// Gets or sets vault Object.
        /// </summary>
        [Parameter(Position = 2)]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the path where the credential file is to be generated
        /// </summary>
        /// <summary>
        /// Gets or sets vault Object.
        /// </summary>
        [Parameter(ParameterSetName = ARSParameterSets.ByDefault, Mandatory = false)]
        [Parameter(ParameterSetName = ARSParameterSets.ForSite, Mandatory = false)]
        public SwitchParameter SiteRecovery
        {
            get { return siteRecovery; }
            set { siteRecovery = value; }
        }
        private bool siteRecovery;

        /// <summary>
        /// Gets or sets the path where the credential file is to be generated
        /// </summary>
        /// <summary>
        /// Gets or sets vault Object.
        /// </summary>
        [Parameter(ParameterSetName = ARSParameterSets.ForBackupVaultType, Mandatory = true)]
        public SwitchParameter Backup
        {
            get { return backup; }
            set { backup = value; }
        }
        private bool backup;

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                if (backup)
                {
                    this.GetAzureRMRecoveryServicesVaultBackupCredentials();
                }
                else
                {
                    this.GetVaultSettingsFile();
                }
            }
            catch (AggregateException aggregateEx)
            {
                // if an exception is thrown from a task, it will be wrapped in AggregateException 
                // and propagated to the main thread. Just throwing the first exception in the list.
                Exception exception = aggregateEx.InnerExceptions.First<Exception>();
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Method to execute the command
        /// </summary>
        private void GetVaultSettingsFile()
        {
            AzureSubscription subscription = DefaultProfile.Context.Subscription;

            // Generate certificate
            X509Certificate2 cert = CertUtils.CreateSelfSignedCertificate(VaultCertificateExpiryInHoursForHRM, subscription.Id.ToString(), this.Vault.Name);

            ASRSite site = new ASRSite();

            if (!string.IsNullOrEmpty(this.SiteIdentifier) && !string.IsNullOrEmpty(this.SiteFriendlyName))
            {
                site.ID = this.SiteIdentifier; 
                site.Name = this.SiteFriendlyName;
            }

            // Generate file.
            ASRVaultCreds vaultCreds = RecoveryServicesClient.GenerateVaultCredential(
                                            cert,
                                            this.Vault,
                                            site);

            string filePath = string.IsNullOrEmpty(this.Path) ? Utilities.GetDefaultPath() : this.Path;
            string fileName = this.GenerateFileName();

            // write the content to a file.
            VaultSettingsFilePath output = new VaultSettingsFilePath()
            {
                FilePath = Utilities.WriteToFile<ASRVaultCreds>(vaultCreds, filePath, fileName)
            };

            // print the path to the user.
            this.WriteObject(output, true);
        }

        /// <summary>
        /// Method to generate the file name
        /// </summary>
        /// <returns>file name as string.</returns>
        private string GenerateFileName()
        {
            string fileName;
            string format = "yyyy-MM-ddTHH-mm-ss";

            if (string.IsNullOrEmpty(this.SiteIdentifier) || string.IsNullOrEmpty(this.SiteFriendlyName))
            {
                fileName = string.Format("{0}_{1}.VaultCredentials", this.Vault.Name, DateTime.UtcNow.ToString(format));
            }
            else
            {
                fileName = string.Format("{0}_{1}_{2}.VaultCredentials", this.SiteFriendlyName, this.Vault.Name, DateTime.UtcNow.ToString(format));
            }

            return fileName;
        }

        #region Backup Vault Credentials
        /// <summary>
        /// Get vault credentials for backup vault type.
        /// </summary>
        public void GetAzureRMRecoveryServicesVaultBackupCredentials()
        {
            string targetLocation = string.IsNullOrEmpty(this.Path) ? Utilities.GetDefaultPath() : this.Path;
            if (!Directory.Exists(targetLocation))
            {
                throw new ArgumentException(Resources.VaultCredPathException);
            }

            string subscriptionId = DefaultContext.Subscription.Id.ToString();
            string displayName = this.Vault.Name;

            WriteDebug(string.Format(CultureInfo.InvariantCulture,
                                      Resources.ExecutingGetVaultCredCmdlet,
                                      subscriptionId, this.Vault.ResourceGroupName, this.Vault.Name, targetLocation));

            // Generate certificate
            X509Certificate2 cert = CertUtils.CreateSelfSignedCertificate(
                VaultCertificateExpiryInHoursForBackup, subscriptionId.ToString(), this.Vault.Name);

            AcsNamespace acsNamespace = null;
            string channelIntegrityKey = string.Empty;
            try
            {
                // Upload cert into ID Mgmt
                WriteDebug(string.Format(CultureInfo.InvariantCulture, Resources.UploadingCertToIdmgmt));
                acsNamespace = UploadCert(cert);
                WriteDebug(string.Format(CultureInfo.InvariantCulture, Resources.UploadedCertToIdmgmt));
            }
            catch (Exception exception)
            {
                throw exception;
            }

            // generate vault credentials
            string vaultCredsFileContent = GenerateVaultCreds(cert, subscriptionId, acsNamespace);

            // NOTE: One of the scenarios for this cmdlet is to generate a file which will be an input 
            //       to DPM servers. 
            //       We found a bug in the DPM UI which is looking for a particular namespace in the input file.
            //       The below is a hack to circumvent this issue and this would be removed once the bug can be fixed.
            vaultCredsFileContent = vaultCredsFileContent.Replace("Microsoft.Azure.Commands.AzureBackup.Models",
                "Microsoft.Azure.Portal.RecoveryServices.Models.Common");

            // prepare for download
            string fileName = string.Format("{0}_{1:ddd MMM dd yyyy}.VaultCredentials", displayName, DateTime.UtcNow);
            string filePath = System.IO.Path.Combine(targetLocation, fileName);
            WriteDebug(string.Format(Resources.SavingVaultCred, filePath));

            File.WriteAllBytes(filePath, Encoding.UTF8.GetBytes(vaultCredsFileContent));

            VaultSettingsFilePath output = new VaultSettingsFilePath()
            {
                FilePath = filePath,
            };

            // Output filename back to user
            WriteObject(output);
        }

        /// <summary>
        /// Upload certificate
        /// </summary>
        /// <param name="cert">management certificate</param>
        /// <returns>acs namespace of the uploaded cert</returns>
        private AcsNamespace UploadCert(X509Certificate2 cert)
        {
            UploadCertificateResponse response = RecoveryServicesClient.UploadCertificate(cert, this.Vault);

            return new AcsNamespace(response);
        }

        /// <summary>
        /// Generates vault creds file
        /// </summary>
        /// <param name="cert">management certificate</param>
        /// <param name="subscriptionId">subscription Id</param>
        /// <param name="acsNamespace">acs namespace</param>
        /// <returns>xml file in string format</returns>
        private string GenerateVaultCreds(X509Certificate2 cert, string subscriptionId, AcsNamespace acsNamespace)
        {
            try
            {
                return GenerateVaultCredsForBackup(cert, subscriptionId, acsNamespace);
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
        /// <param name="acsNamespace">acs namespace</param>
        /// <returns>xml file in string format</returns>
        private string GenerateVaultCredsForBackup(X509Certificate2 cert, string subscriptionId, 
            AcsNamespace acsNamespace)
        {
            using (var output = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(output, GetXmlWriterSettings()))
                {
                    BackupVaultCreds backupVaultCreds = 
                        new BackupVaultCreds(subscriptionId,
                            this.Vault.Name,
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

        /// <summary>
        /// Get Agent Links
        /// </summary>
        /// <returns>Agent links in string format</returns>
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

        #endregion
    }
}
