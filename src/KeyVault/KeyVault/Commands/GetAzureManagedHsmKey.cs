using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "ManagedHsmKey", DefaultParameterSetName = SpecifyHsmByHsmName + GetKeyWithoutConstraint)]
    [OutputType(typeof(PSKeyVaultKeyIdentityItem), typeof(PSKeyVaultKey), typeof(PSDeletedKeyVaultKeyIdentityItem), typeof(PSDeletedKeyVaultKey))]
    public class GetAzureManagedHsmKey : KeyVaultCmdletBase
    {

        #region Parameter Set Names

        private const string SpecifyHsmByHsmName = "SpecifyHsmByHsmName";
        private const string SpecifyHsmByInputObject = "SpecifyHsmByInputObject";
        private const string SpecifyHsmByResourceId = "SpecifyHsmByResourceId";

        private const string GetKeyWithoutConstraint = "GetKeyWithoutConstraint";
        private const string GetKeyWithSpecifiedVersion = "GetKeyWithSpecifiedVersion";
        private const string GetKeyIncludeAllVersions = "GetKeyIncludeAllVersions";

        private readonly string[] _supportedTypesForDownload = new string[] { Constants.RSA, Constants.RSAHSM };

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// HSM name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = SpecifyHsmByHsmName + GetKeyWithoutConstraint,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = SpecifyHsmByHsmName + GetKeyWithSpecifiedVersion,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = SpecifyHsmByHsmName + GetKeyIncludeAllVersions,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName { get; set; }

        /// <summary>
        /// HSM object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = SpecifyHsmByInputObject + GetKeyWithoutConstraint,
            HelpMessage = "HSM object.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = SpecifyHsmByInputObject + GetKeyWithSpecifiedVersion,
            HelpMessage = "HSM object.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = SpecifyHsmByInputObject + GetKeyIncludeAllVersions,
            HelpMessage = "HSM object.")]
        [ValidateNotNullOrEmpty]
        public PSManagedHsm InputObject { get; set; }

        /// <summary>
        /// HSM resource id
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = SpecifyHsmByResourceId + GetKeyWithoutConstraint,
            HelpMessage = "HSM Resource Id.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = SpecifyHsmByResourceId + GetKeyWithSpecifiedVersion,
            HelpMessage = "HSM Resource Id.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = SpecifyHsmByResourceId + GetKeyIncludeAllVersions,
            HelpMessage = "HSM ResourceId.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Key name.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = SpecifyHsmByHsmName + GetKeyWithoutConstraint,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from HSM name, currently selected environment and key name.")]
        [Parameter(Mandatory = false,
            ParameterSetName = SpecifyHsmByInputObject + GetKeyWithoutConstraint,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from HSM name, currently selected environment and key name.")]
        [Parameter(Mandatory = false,
            ParameterSetName = SpecifyHsmByResourceId + GetKeyWithoutConstraint,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from HSM name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = SpecifyHsmByHsmName + GetKeyWithSpecifiedVersion,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from HSM name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = SpecifyHsmByInputObject + GetKeyWithSpecifiedVersion,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from HSM name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = SpecifyHsmByResourceId + GetKeyWithSpecifiedVersion,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from HSM name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = SpecifyHsmByHsmName + GetKeyIncludeAllVersions,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from HSM name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = SpecifyHsmByInputObject + GetKeyIncludeAllVersions,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from HSM name, currently selected environment and key name.")]
        [Parameter(Mandatory = true,
            ParameterSetName = SpecifyHsmByResourceId + GetKeyIncludeAllVersions,
            Position = 1,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from HSM name, currently selected environment and key name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.KeyName)]
        [SupportsWildcards]
        public string Name { get; set; }

        /// <summary>
        /// Key version.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = SpecifyHsmByHsmName + GetKeyWithSpecifiedVersion,
            Position = 2,
            HelpMessage = "Key version. Cmdlet constructs the FQDN of a key from HSM name, currently selected environment, key name and key version.")]
        [Parameter(Mandatory = true,
            ParameterSetName = SpecifyHsmByInputObject + GetKeyWithSpecifiedVersion,
            Position = 2,
            HelpMessage = "Key version. Cmdlet constructs the FQDN of a key from HSM name, currently selected environment, key name and key version.")]
        [Parameter(Mandatory = true,
            ParameterSetName = SpecifyHsmByResourceId + GetKeyWithSpecifiedVersion,
            Position = 2,
            HelpMessage = "Key version. Cmdlet constructs the FQDN of a key from HSM name, currently selected environment, key name and key version.")]
        [Alias("KeyVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = SpecifyHsmByHsmName + GetKeyIncludeAllVersions,
            HelpMessage = "Specifies whether to include the versions of the key in the output.")]
        [Parameter(Mandatory = true,
            ParameterSetName = SpecifyHsmByInputObject + GetKeyIncludeAllVersions,
            HelpMessage = "Specifies whether to include the versions of the key in the output.")]
        [Parameter(Mandatory = true,
            ParameterSetName = SpecifyHsmByResourceId + GetKeyIncludeAllVersions,
            HelpMessage = "Specifies whether to include the versions of the key in the output.")]
        public SwitchParameter IncludeVersions { get; set; }

        [Parameter(Mandatory = false,
           ParameterSetName = SpecifyHsmByHsmName + GetKeyWithoutConstraint,
           HelpMessage = "Specifies whether to show the previously deleted keys in the output.")]
        [Parameter(Mandatory = false,
           ParameterSetName = SpecifyHsmByInputObject + GetKeyWithoutConstraint,
           HelpMessage = "Specifies whether to show the previously deleted keys in the output.")]
        [Parameter(Mandatory = false,
           ParameterSetName = SpecifyHsmByResourceId + GetKeyWithoutConstraint,
           HelpMessage = "Specifies whether to show the previously deleted keys in the output.")]
        public SwitchParameter InRemovedState { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies the output file for which this cmdlet saves the key. The public key is saved in PEM format by default.")]
        [ValidateNotNullOrEmpty]
        public string OutFile { get; set; }

        #endregion

        public override void ExecuteCmdlet()                                                                                                                                                    
        {
            PSKeyVaultKey keyBundle = null;

            if (InputObject != null)
            {
                HsmName = InputObject.VaultName;
            }
            else if (!string.IsNullOrEmpty(ResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                HsmName = parsedResourceId.ResourceName;
            }

            if (!string.IsNullOrEmpty(Version))
            {
                keyBundle = this.Track2DataClient.GetManagedHsmKey(HsmName, Name, Version);
                WriteObject(keyBundle);
            }
            else if (IncludeVersions.IsPresent)
            {
                WriteObject(this.Track2DataClient.GetManagedHsmKeyAllVersions(HsmName, Name), true);
            }
            else if (InRemovedState.IsPresent)
            {
                if (string.IsNullOrEmpty(Name) || WildcardPattern.ContainsWildcardCharacters(Name))
                {
                    WriteObject(KVSubResourceWildcardFilter(
                        Name, this.Track2DataClient.GetManagedHsmDeletedKeys(HsmName)),
                        true);
                }
                else
                {
                    PSDeletedKeyVaultKey deletedKeyBundle = this.Track2DataClient.GetManagedHsmDeletedKey(HsmName, Name);
                    WriteObject(deletedKeyBundle);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Name) || WildcardPattern.ContainsWildcardCharacters(Name))
                {
                    WriteObject(KVSubResourceWildcardFilter(
                        Name, this.Track2DataClient.GetManagedHsmKeys(HsmName)),
                        true);
                }
                else
                {
                    keyBundle = this.Track2DataClient.GetManagedHsmKey(HsmName, Name, string.Empty);
                    WriteObject(keyBundle);
                }
            }

            if (!string.IsNullOrEmpty(OutFile) && keyBundle != null)
            {
                DownloadKey(keyBundle.Key, OutFile);
            }
        }

        private void DownloadKey(JsonWebKey jwk, string path)
        {
            if (CanDownloadKey(jwk, out string reason))
            {
                var pem = JwkHelper.ExportPublicKeyToPem(jwk);
                AzureSession.Instance.DataStore.WriteFile(path, pem);
                WriteDebug(string.Format(Resources.PublicKeySavedAt, path));
            }
            else
            {
                WriteWarning(reason);
            }
        }

        private bool CanDownloadKey(JsonWebKey jwk, out string reason)
        {
            reason = string.Format(Resources.DownloadNotSupported, jwk.Kty);
            return _supportedTypesForDownload.Contains(jwk.Kty);
        }
    }
}
