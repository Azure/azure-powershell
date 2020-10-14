using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Requests that a backup of the specified key be downloaded and stored to a file
    /// </summary>
    /// <remarks>
    /// The cmdlet returns the path of the newly created backup file.
    /// </remarks>
    [Cmdlet("Backup", ResourceManager.Common.AzureRMConstants.AzurePrefix + "ManagedHsmKey", SupportsShouldProcess = true, DefaultParameterSetName = ByKeyNameParameterSet)]
    [OutputType(typeof(String))]
    public class BackupAzureManagedHsmKey : KeyVaultCmdletBase
    {
        #region parameter sets

        private const string ByKeyNameParameterSet = "ByKeyName";
        private const string ByKeyObjectParameterSet = "ByKey";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// HSM name
        /// </summary>
        [Parameter(Mandatory = true,
                    Position = 0,
                    ParameterSetName = ByKeyNameParameterSet,
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
                    HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from managed HSM name, currently selected environment and key name.")]
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
            if (InputObject != null)
            {
                Name = InputObject.Name;
                HsmName = InputObject.VaultName;
            }

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