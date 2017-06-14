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
using System.IO;
using System.Management.Automation;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Restores the backup key into a vault 
    /// </summary>
    [Cmdlet(VerbsData.Restore, "AzureKeyVaultKey",
        SupportsShouldProcess = true,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(KeyBundle))]
    public class RestoreAzureKeyVaultKey : KeyVaultCmdletBase
    {
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
        /// The input file in which the backup blob is stored
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 1,
                   HelpMessage = "Input file. The input file containing the backed-up blob")]
        [ValidateNotNullOrEmpty]
        public string InputFile { get; set; }

        #endregion Input Parameter Definitions

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(VaultName, Properties.Resources.RestoreKey))
            {
                var filePath = ResolvePath(InputFile);

            var restoredKeyBundle = this.DataServiceClient.RestoreKey(VaultName, filePath);

            this.WriteObject(restoredKeyBundle);
            }
        }

        private string ResolvePath(string filePath)
        {
            FileInfo keyFile = new FileInfo(this.GetUnresolvedProviderPathFromPSPath(filePath));
            if (!keyFile.Exists)
            {
                throw new FileNotFoundException(string.Format(KeyVaultProperties.Resources.BackupKeyFileNotFound, filePath));
            }
            return keyFile.FullName;
        }
    }
}
