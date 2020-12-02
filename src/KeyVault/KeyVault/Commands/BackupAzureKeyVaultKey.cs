﻿// ----------------------------------------------------------------------------------
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
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Requests that a backup of the specified key be downloaded and stored to a file
    /// </summary>
    /// <remarks>
    /// The cmdlet returns the path of the newly created backup file.
    /// </remarks>
    [Cmdlet("Backup", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKey", SupportsShouldProcess = true, DefaultParameterSetName = ByKeyNameParameterSet)]
    [OutputType(typeof(String))]
    public class BackupAzureKeyVaultKey : KeyVaultCmdletBase
    {
        #region parameter sets

        private const string ByKeyNameParameterSet = "ByKeyName";
        private const string ByKeyObjectParameterSet = "ByKey";
        private const string HsmByKeyNameParameterSet = "HsmByKeyName";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByKeyNameParameterSet,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = HsmByKeyNameParameterSet,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName { get; set; }

        /// <summary>
        /// Key name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = ByKeyNameParameterSet,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = HsmByKeyNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.KeyName)]
        public string Name { get; set; }

        /// <summary>
        /// KeyBundle object to be backed up.
        /// </summary>
        /// <remarks>
        /// Note that the backup applies to the entire family of a key (current and all its versions);
        /// since a key bundle represents a single version, the intent of this parameter is to allow pipelining.
        /// The backup cmdlet will use the Name and VaultName properties of the KeyBundle parameter.
        /// </remarks>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = ByKeyObjectParameterSet,
            HelpMessage = "Key bundle to back up, pipelined in from the output of a retrieval call.")]
        [ValidateNotNullOrEmpty]
        [Alias("Key")]
        public PSKeyVaultKeyIdentityItem InputObject { get; set; }

        /// <summary>
        /// The output file in which the backup blob is to be stored
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 2,
            HelpMessage = "Output file. The output file to store the backed up key blob in. If not present, a default filename is chosen.")]
        [ValidateNotNullOrEmpty]
        public string OutputFile { get; set; }

        /// <summary>
        /// Instructs the cmdlet to overwrite the destination file, if it exists.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Overwrite the given file if it exists")]
        public SwitchParameter Force { get; set; }

        #endregion Input Parameter Definition

        public override void ExecuteCmdlet()
        {
            NormalizeParameterSets();

            if (string.IsNullOrEmpty(HsmName))
            {
                BackupKeyVaultKey();
            }
            else
            {
                BackupHsmKey();
            }
        }

        private void NormalizeParameterSets()
        {
            if (InputObject != null)
            {
                Name = InputObject.Name;
                if (InputObject.IsHsm)
                {
                    HsmName = InputObject.VaultName;
                }
                else
                {
                    VaultName = InputObject.VaultName;
                }
            }
        }

        private void BackupKeyVaultKey()
        {
            if (ShouldProcess(Name, Properties.Resources.BackupKey))
            {
                if (string.IsNullOrEmpty(OutputFile))
                {
                    OutputFile = GetDefaultFileForOperation("backup", VaultName, Name);
                }

                var filePath = this.GetUnresolvedProviderPathFromPSPath(OutputFile);

                // deny request if the file exists and overwrite is not authorized
                if (!AzureSession.Instance.DataStore.FileExists(filePath)
                    || Force.IsPresent
                    || ShouldContinue(string.Format(Resources.FileOverwriteMessage, filePath), Resources.FileOverwriteCaption))
                {
                    var backupBlobPath = this.DataServiceClient.BackupKey(VaultName, Name, filePath);
                    this.WriteObject(backupBlobPath);
                }
            }
        }

        private void BackupHsmKey()
        {
            if (ShouldProcess(Name, Properties.Resources.BackupKey))
            {
                if (string.IsNullOrEmpty(OutputFile))
                {
                    OutputFile = GetDefaultFileForOperation("backup", HsmName, Name);
                }

                var filePath = this.GetUnresolvedProviderPathFromPSPath(OutputFile);

                // deny request if the file exists and overwrite is not authorized
                if (!AzureSession.Instance.DataStore.FileExists(filePath)
                    || Force.IsPresent
                    || ShouldContinue(string.Format(Resources.FileOverwriteMessage, filePath), Resources.FileOverwriteCaption))
                {
                    var backupBlobPath = this.Track2DataClient.BackupManagedHsmKey(HsmName, Name, filePath);
                    this.WriteObject(backupBlobPath);
                }
            }
        }
    }
}
