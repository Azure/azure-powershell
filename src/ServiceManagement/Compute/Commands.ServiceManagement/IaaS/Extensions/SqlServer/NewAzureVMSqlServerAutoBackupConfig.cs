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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Security;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Management.Storage;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    /// <summary>
    /// Helper cmdlet to construct instance of AutoBackup settings class
    /// </summary>
   [Cmdlet(
        VerbsCommon.New,
        AzureVMSqlServerAutoBackupConfigNoun,
        DefaultParameterSetName = StorageUriParamSetName),
    OutputType(
        typeof(AutoBackupSettings))]
    public class NewAzureVMSqlServerAutoBackupConfigCommand : ServiceManagementBaseCmdlet
    {
        protected const string AzureVMSqlServerAutoBackupConfigNoun = "AzureVMSqlServerAutoBackupConfig";

        protected const string StorageContextParamSetName            = "StorageContextSqlServerAutoBackup";
        protected const string StorageUriParamSetName                = "StorageUriSqlServerAutoBackup";

        [Parameter(
            Mandatory = false,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Enable Automatic Backup.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Enable { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Backup Retention period in days.")]
        [ValidateNotNullOrEmpty]
        public int RetentionPeriodInDays { get; set; }

        [Parameter(
             Mandatory = false,
             Position = 2,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Enable Backup Encryption.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter EnableEncryption { get; set; }

        [Parameter(
             Mandatory = false,
             Position = 3,
             ValueFromPipelineByPropertyName = false,
             HelpMessage = "Certificate password.")]
        public SecureString CertificatePassword { get; set; }

        [Parameter(
            ParameterSetName = StorageContextParamSetName,
            Mandatory = false,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage connection context")]
        [ValidateNotNullOrEmpty]
        public AzureStorageContext StorageContext
        {
            get;
            set;
        }

        [Parameter(
             Mandatory = false,
             Position = 4,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The storage uri")]
        [ValidateNotNullOrEmpty]
        public Uri StorageUri
        {
            get;
            set;
        }

        [Parameter(
          Mandatory = false,
          Position = 5,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The storage access key")]
        [ValidateNotNullOrEmpty]
        public SecureString StorageKey
        {
            get;
            set;
        }

        /// <summary>
        /// Initialzies a new instance of the <see cref="NewAzureVMSqlServerAutoBackupConfigCommand"/> class.
        /// </summary>
        public NewAzureVMSqlServerAutoBackupConfigCommand()
        {
        }

        /// <summary>
        /// Creates and returns <see cref="AutoBackupSettings"/> object.
        /// </summary>
        protected override void ProcessRecord()
        {
            AutoBackupSettings autoBackupSettings = new AutoBackupSettings();
            
            autoBackupSettings.Enable = (Enable.IsPresent) ? Enable.ToBool() : false;
            autoBackupSettings.EnableEncryption = (EnableEncryption.IsPresent) ? EnableEncryption.ToBool() : false;
            autoBackupSettings.RetentionPeriod = RetentionPeriodInDays;

            switch(ParameterSetName)
            {
                case StorageContextParamSetName:
                    autoBackupSettings.StorageUrl = StorageContext.BlobEndPoint;
                    autoBackupSettings.StorageAccessKey = this.GetStorageKey();
                break;

                case StorageUriParamSetName:
                    autoBackupSettings.StorageUrl = (StorageUri == null)? null: StorageUri.ToString();
                    autoBackupSettings.StorageAccessKey = (StorageKey == null)? null: SecureStringHelper.ConvertToUnsecureString(StorageKey);
                break;
            }

            // Check if certificate password was set
            autoBackupSettings.Password = (CertificatePassword == null) ? null : SecureStringHelper.ConvertToUnsecureString(CertificatePassword);

            WriteObject(autoBackupSettings);
        }

        protected string GetStorageKey()
        {
            string storageKey = string.Empty;
            string storageAccountName = (this.StorageContext == null)? null: this.StorageContext.StorageAccountName;

            if (!string.IsNullOrEmpty(storageAccountName))
            {
                var storageAccount = this.StorageClient.StorageAccounts.Get(storageAccountName);
                if (storageAccount != null)
                {
                    var keys = this.StorageClient.StorageAccounts.GetKeys(storageAccountName);
                    if (keys != null)
                    {
                        storageKey = !string.IsNullOrEmpty(keys.PrimaryKey) ? keys.PrimaryKey : keys.SecondaryKey;
                    }
                }
            }

            return storageKey;
        }
    }
}
