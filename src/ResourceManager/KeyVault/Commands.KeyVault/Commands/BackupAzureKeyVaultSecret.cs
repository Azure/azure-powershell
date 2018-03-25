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
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Requests that a backup of the specified key be downloaded and stored to a file
    /// </summary>
    /// <remarks>
    /// The cmdlet returns the path of the newly created backup file.
    /// </remarks>
    [Cmdlet( VerbsData.Backup, "AzureKeyVaultSecret",
        SupportsShouldProcess = true,
        DefaultParameterSetName = BySecretNameParameterSet,
        HelpUri = Constants.KeyVaultHelpUri )]
    [OutputType( typeof( String ) )]
    public class BackupAzureKeyVaultSecret : KeyVaultCmdletBase
    {
        #region parameter sets

        private const string BySecretNameParameterSet = "BySecretName";
        private const string BySecretObjectParameterSet = "BySecret";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter( Mandatory = true,
                    Position = 0,
                    ValueFromPipelineByPropertyName = true,
                    ParameterSetName = BySecretNameParameterSet,
                    HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment." )]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Secret name
        /// </summary>
        [Parameter( Mandatory = true,
                    Position = 1,
                    ValueFromPipelineByPropertyName = true,
                    ParameterSetName = BySecretNameParameterSet,
                    HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name." )]
        [ValidateNotNullOrEmpty]
        [Alias( Constants.SecretName )]
        public string Name { get; set; }

        /// <summary>
        /// The secret object to be backed up.
        /// </summary>
        /// <remarks>
        /// Note that the backup applies to the entire family of a secret (current and all its versions); 
        /// since a key bundle represents a single version, the intent of this parameter is to allow pipelining.
        /// The backup cmdlet will use the Name and VaultName properties of the KeyBundle parameter.
        /// </remarks>
        [Parameter(Mandatory = true,
                    Position = 0,
                    ValueFromPipelineByPropertyName = true,
                    ValueFromPipeline = true,
                    ParameterSetName = BySecretObjectParameterSet,
                    HelpMessage = "Secret to be backed up, pipelined in from the output of a retrieval call.")]
        [ValidateNotNullOrEmpty]
        [Alias("Secret")]
        public PSKeyVaultSecretIdentityItem InputObject { get; set; }

        /// <summary>
        /// The output file in which the backup blob is to be stored
        /// </summary>
        [Parameter( Mandatory = false,
                    Position = 2,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "Output file. The output file to store the backed up secret blob in. If not present, a default filename is chosen." )]
        [ValidateNotNullOrEmpty]
        public string OutputFile { get; set; }

        /// <summary>
        /// Instructs the cmdlet to overwrite the destination file, if it exists.
        /// </summary>
        [Parameter( Mandatory = false,
                    Position = 3,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "Overwrite the given file if it exists" )]
        public SwitchParameter Force { get; set; }

        #endregion Input Parameter Definition

        public override void ExecuteCmdlet( )
        {
            if (InputObject != null)
            {
                Name = InputObject.Name;
                VaultName = InputObject.VaultName;
            }

            if ( ShouldProcess( Name, Properties.Resources.BackupSecret ) )
            {
                if ( string.IsNullOrEmpty( OutputFile ) )
                {
                    OutputFile = GetDefaultFileForOperation( "backup", VaultName, Name );
                }

                var filePath = this.GetUnresolvedProviderPathFromPSPath(OutputFile);

                // deny request if the file exists and overwrite is not authorized
                if ( !AzureSession.Instance.DataStore.FileExists( filePath )
                    || Force.IsPresent
                    || ShouldContinue( string.Format(Resources.FileOverwriteMessage, filePath ), Resources.FileOverwriteCaption ) )
                {
                    var backupBlobPath = this.DataServiceClient.BackupSecret(VaultName, Name, filePath);
                    this.WriteObject( backupBlobPath );
                }
            }
        }
    }
}
