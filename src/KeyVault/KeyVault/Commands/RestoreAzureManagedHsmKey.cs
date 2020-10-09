using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Restores the backup key into a vault 
    /// </summary>
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzurePrefix + "ManagedHsmKey", SupportsShouldProcess = true, DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSKeyVaultKey))]
    public class RestoreAzureManagedHsmKey : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByVaultNameParameterSet = "ByVaultName";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByVaultNameParameterSet,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// KeyVault object
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByInputObjectParameterSet,
                   ValueFromPipeline = true,
                   HelpMessage = "KeyVault object")]
        [ValidateNotNullOrEmpty]
        public PSKeyVaultKeyIdentityItem InputObject { get; set; }

        /// <summary>
        /// KeyVault ResourceId
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByResourceIdParameterSet,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "KeyVault Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

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
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
            }
            else if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                VaultName = resourceIdentifier.ResourceName;
            }

            if (ShouldProcess(VaultName, Properties.Resources.RestoreKey))
            {
                var filePath = ResolveKeyVaultPath(InputFile);

                var restoredKeyBundle = this.Track2DataClient.RestoreManagedHsmKey(VaultName, filePath);

                this.WriteObject(restoredKeyBundle);
            }
        }

        private string ResolveKeyVaultPath(string filePath)
        {
            FileInfo keyFile = new FileInfo(this.ResolveUserPath(filePath));
            if (!keyFile.Exists)
            {
                throw new FileNotFoundException(string.Format(Resources.BackupKeyFileNotFound, filePath));
            }
            return keyFile.FullName;
        }
    }
}