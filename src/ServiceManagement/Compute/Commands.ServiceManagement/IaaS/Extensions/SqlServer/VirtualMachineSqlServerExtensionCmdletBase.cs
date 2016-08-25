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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    /// <summary>
    /// Base class for SQL extension specific cmdlets
    /// </summary>
    public class VirtualMachineSqlServerExtensionCmdletBase : VirtualMachineExtensionCmdletBase
    {
        protected const string VirtualMachineSqlServerExtensionNoun = "AzureVMSqlServerExtension";

        /// <summary>
        /// Extension's publisher name 
        /// </summary>
        protected const string ExtensionPublishedNamespace = "Microsoft.SqlServer.Management";

        /// <summary>
        /// Extension's name - 
        /// </summary>
        protected const string ExtensionPublishedName = "SqlIaaSAgent";

        /// <summary>
        /// Extension's default version 
        /// </summary>
        protected const string ExtensionDefaultVersion = "1.*";

        /// <summary>
        /// value of Auto-patching settings object that can be set by derived classes
        /// </summary>
        public virtual AutoPatchingSettings AutoPatchingSettings { get; set; }

        /// <summary>
        /// value of Auto-backup settings object that can be set by derived classes
        /// </summary>
        public virtual AutoBackupSettings AutoBackupSettings { get; set; }

        /// <summary>
        /// Azure Key Vault SQL Credentials settings
        /// </summary>
        public virtual KeyVaultCredentialSettings KeyVaultCredentialSettings { get; set; }

        /// <summary>
        /// value of Auto-telemetry settings object that can be set by derived classes
        /// </summary>
        public virtual AutoTelemetrySettings AutoTelemetrySettings { get; set; }

        /// <summary>
        /// Sets extension's publisher and name
        /// </summary>
        public VirtualMachineSqlServerExtensionCmdletBase()
        {
            base.publisherName = ExtensionPublishedNamespace;
            base.extensionName = ExtensionPublishedName;
        }

        /// <summary>
        /// Returns the public configuration as string
        /// </summary>
        /// <returns></returns>
        protected string GetPublicConfiguration()
        {
            // Create auto backup settings if set
            PublicAutoBackupSettings autoBackupSettings = null;
            
            if (this.AutoBackupSettings != null)
            {
                autoBackupSettings = new PublicAutoBackupSettings()
                {
                    Enable  = this.AutoBackupSettings.Enable,
                    EnableEncryption = this.AutoBackupSettings.EnableEncryption,
                    RetentionPeriod = this.AutoBackupSettings.RetentionPeriod                       
                };
            }

            // Create Key vault settings if set
            PublicKeyVaultCredentialSettings akvSettings = null;

            if(this.KeyVaultCredentialSettings != null)
            {
                akvSettings = new PublicKeyVaultCredentialSettings()
                {
                    Enable = this.KeyVaultCredentialSettings == null ? false : this.KeyVaultCredentialSettings.Enable,
                    CredentialName = this.KeyVaultCredentialSettings == null ? null : this.KeyVaultCredentialSettings.CredentialName
                };
            }

            return JsonUtilities.TryFormatJson(JsonConvert.SerializeObject(
               new SqlServerPublicSettings
               {
                   AutoPatchingSettings = this.AutoPatchingSettings,
                   AutoTelemetrySettings = this.AutoTelemetrySettings,
                   AutoBackupSettings = autoBackupSettings,
                   KeyVaultCredentialSettings = akvSettings
               }));
        }

        /// <summary>
        /// Returns private configuration as string
        /// </summary>
        /// <returns></returns>
        protected string GetPrivateConfiguration()
        {

            PrivateKeyVaultCredentialSettings akvPrivateSettings = null;

            if(this.KeyVaultCredentialSettings != null)
            {
                akvPrivateSettings = new PrivateKeyVaultCredentialSettings { AzureKeyVaultUrl = this.KeyVaultCredentialSettings.AzureKeyVaultUrl, 
                                                                             ServicePrincipalName = this.KeyVaultCredentialSettings.ServicePrincipalName, 
                                                                             ServicePrincipalSecret = this.KeyVaultCredentialSettings.ServicePrincipalSecret 
                                                                           };
            }

            return JsonUtilities.TryFormatJson(JsonConvert.SerializeObject(
                       new SqlServerPrivateSettings
                       {
                           StorageUrl = (this.AutoBackupSettings == null) ? string.Empty : this.AutoBackupSettings.StorageUrl,
                           StorageAccessKey = (this.AutoBackupSettings == null) ? string.Empty : this.AutoBackupSettings.StorageAccessKey,
                           Password = (this.AutoBackupSettings == null) ? string.Empty : this.AutoBackupSettings.Password,
                           PrivateKeyVaultCredentialSettings = (akvPrivateSettings == null) ? null : akvPrivateSettings
                       }));
        }
    }
}
