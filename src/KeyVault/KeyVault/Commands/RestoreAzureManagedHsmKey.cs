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
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzurePrefix + "ManagedHsmKey", SupportsShouldProcess = true, DefaultParameterSetName = ByHsmNameParameterSet)]
    [OutputType(typeof(PSKeyVaultKey))]
    public class RestoreAzureManagedHsmKey : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByHsmNameParameterSet = "ByHsmName";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// HSM name
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByHsmNameParameterSet,
                   HelpMessage = "HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName { get; set; }

        /// <summary>
        /// HSM object
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByInputObjectParameterSet,
                   ValueFromPipeline = true,
                   HelpMessage = "Hsm object")]
        [ValidateNotNullOrEmpty]
        public PSManagedHsm InputObject { get; set; }

        /// <summary>
        /// HSM ResourceId
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByResourceIdParameterSet,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Hsm Resource Id")]
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
                HsmName = InputObject.VaultName;
            }
            else if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                HsmName = resourceIdentifier.ResourceName;
            }

            if (ShouldProcess(HsmName, Properties.Resources.RestoreKey))
            {
                var filePath = ResolveKeyPath(InputFile);

                var restoredKeyBundle = this.Track2DataClient.RestoreManagedHsmKey(HsmName, filePath);

                this.WriteObject(restoredKeyBundle);
            }
        }

        private string ResolveKeyPath(string filePath)
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