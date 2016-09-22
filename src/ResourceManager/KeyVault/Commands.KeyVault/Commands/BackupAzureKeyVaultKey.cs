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

using Microsoft.Azure.Commands.KeyVault.Models;
using System;
using System.IO;
using System.Management.Automation;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Requests that a backup of the specified key be downloaded and stored to a file
    /// </summary>
    [Cmdlet(VerbsData.Backup, "AzureKeyVaultKey",
        SupportsShouldProcess = true, 
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(String))]
    public class BackupAzureKeyVaultKey : KeyVaultCmdletBase
    {
        public static readonly DateTime EpochDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ValidateNotNullOrEmpty]        
        public string VaultName { get; set; }

        /// <summary>
        /// Key name
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 1,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [ValidateNotNullOrEmpty]        
        [Alias(Constants.KeyName)]
        public string Name { get; set; }

        /// <summary>
        /// The output file in which the backup blob is to be stored
        /// </summary>
        [Parameter(Mandatory = false,
                   Position = 2,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Output file. The output file to store the backed up key blob in. If not present, a default filename is chosen.")]
        [ValidateNotNullOrEmpty]
        public string OutputFile { get; set; }

        #endregion Input Parameter Definition

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Properties.Resources.BackupKey))
            {
                if (string.IsNullOrEmpty(OutputFile))
                {
                    OutputFile = GetDefaultFile();
                }

                var filePath = ResolvePath(OutputFile);

                var backupBlobPath = this.DataServiceClient.BackupKey(VaultName, Name, filePath);

                this.WriteObject(backupBlobPath);
            }
        }

        private string GetDefaultFile()
        {
            var currentPath = CurrentPath();            
            var filename = string.Format("{0}\\backup-{1}-{2}-{3}", currentPath, VaultName, Name, DateTime.UtcNow.Subtract(EpochDate).TotalSeconds);
            return filename;
        }

        private string ResolvePath(string filePath)
        {
            FileInfo keyFile = new FileInfo(this.GetUnresolvedProviderPathFromPSPath(filePath));
            if (keyFile.Exists)
            {
                throw new IOException(string.Format(KeyVaultProperties.Resources.BackupKeyFileAlreadyExists, filePath));
            }
            return keyFile.FullName;
        }
    }
}
