using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

using System;
using System.Management.Automation;
using System.Security;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Commands.Key
{
    /// <summary>
    /// 1. Encrypts an arbitrary sequence of bytes using an encryption key that is stored in a key vault.
    /// 2. Decrypts a single block of encrypted data.
    /// 3. Wraps a symmetric key using a specified key.
    /// 4. Unwraps a symmetric key using the specified key that was initially used for wrapping that key.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKeyOperation", SupportsShouldProcess = true, DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSKeyOperationResult))]
    public class InvokeAzureKeyVaultKeyOperation : KeyVaultKeyCmdletBase
    {
        #region Supported Operation 
        enum Operations
        {
            Unknown,
            Encrypt,
            Decrypt,
            Wrap,
            Unwrap
        }
        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Key version.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Key version.")]
        [Alias("KeyVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Algorithm identifier")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Encrypt", "Decrypt", "Wrap", "Unwrap")]
        public string Operation { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Algorithm identifier")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("RSA-OAEP", "RSA-OAEP-256", "RSA1_5")]
        [Alias("EncryptionAlgorithm", "WrapAlgorithm")]
        public string Algorithm { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The value to be operated")]
        [ValidateNotNullOrEmpty]
        public SecureString Value { get; set; }
        #endregion Input Parameter Definitions

        internal override void NormalizeParameterSets()
        {
            if (InputObject != null)
            {
                Version = Version ?? InputObject.Version;
            }
            base.NormalizeParameterSets();
        }
        
        public override void ExecuteCmdlet()
        {
            NormalizeParameterSets();

            Operations opt = Operations.Unknown;
            Enum.TryParse(Operation, out opt);

            if (string.IsNullOrEmpty(HsmName))
            {
                switch (opt)
                {
                    case Operations.Encrypt:
                        this.WriteObject(
                            this.Track2DataClient.Encrypt(VaultName, Name, Version,
                                Encoding.ASCII.GetBytes(Value.ConvertToString()), Algorithm));
                        break;
                    case Operations.Decrypt:
                        this.WriteObject(
                            this.Track2DataClient.Decrypt(VaultName, Name, Version,
                                Convert.FromBase64String(Value.ConvertToString()), Algorithm));
                        break;
                    case Operations.Wrap:
                        this.WriteObject(
                            this.Track2DataClient.WrapKey(VaultName, Name, Version,
                                Encoding.ASCII.GetBytes(Value.ConvertToString()), Algorithm));
                        break;
                    case Operations.Unwrap:
                        this.WriteObject(
                            this.Track2DataClient.UnwrapKey(VaultName, Name, Version,
                                Convert.FromBase64String(Value.ConvertToString()), Algorithm));
                        break;
                    case Operations.Unknown:
                        throw new NotSupportedException("Not supported ${Operation} yet");
                }
            }
            else
            {
                switch (opt)
                {
                    case Operations.Encrypt:
                        this.WriteObject(
                            this.Track2DataClient.ManagedHsmKeyEncrypt(HsmName, Name, Version,
                                Encoding.ASCII.GetBytes(Value.ConvertToString()), Algorithm));
                        break;
                    case Operations.Decrypt:
                        this.WriteObject(
                            this.Track2DataClient.ManagedHsmKeyDecrypt(HsmName, Name, Version,
                                Convert.FromBase64String(Value.ConvertToString()), Algorithm));
                        break;
                    case Operations.Wrap:
                        this.WriteObject(
                            this.Track2DataClient.ManagedHsmWrapKey(HsmName, Name, Version,
                                Encoding.ASCII.GetBytes(Value.ConvertToString()), Algorithm));
                        break;
                    case Operations.Unwrap:
                        this.WriteObject(
                            this.Track2DataClient.ManagedHsmUnwrapKey(HsmName, Name, Version,
                                Convert.FromBase64String(Value.ConvertToString()), Algorithm));
                        break;
                    case Operations.Unknown:
                        throw new NotSupportedException("Not supported ${Operation} yet");
                }
                
            }
        }
    }
}
