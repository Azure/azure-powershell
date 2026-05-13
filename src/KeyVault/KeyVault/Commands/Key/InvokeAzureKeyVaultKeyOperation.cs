using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

using System;
using System.Management.Automation;

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
        [PSArgumentCompleter(
            // RSA (asymmetric)
            "RSA-OAEP", "RSA-OAEP-256", "RSA1_5",
            // AES (symmetric, supported on Managed HSM)
            "A128CBC", "A128CBCPAD", "A128GCM",
            "A192CBC", "A192CBCPAD", "A192GCM",
            "A256CBC", "A256CBCPAD", "A256GCM")]
        [Alias("EncryptionAlgorithm", "WrapAlgorithm")]
        public string Algorithm { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The value to be operated in byte array format.")]
        [ValidateNotNullOrEmpty]
        public byte[] ByteArrayValue { get; set; }

        #endregion Input Parameter Definitions

        private Operations opt = Operations.Unknown;

        internal void ValidateParameters() { }

        internal override void NormalizeParameterSets()
        {
            if (InputObject != null)
            {
                Version = Version ?? InputObject.Version;
            }

            Enum.TryParse(Operation, out opt);

            base.NormalizeParameterSets();
        }
        
        public override void ExecuteCmdlet()
        {
            ValidateParameters();
            NormalizeParameterSets();

            if (string.IsNullOrEmpty(HsmName))
            {
                switch (opt)
                {
                    case Operations.Encrypt:
                        this.WriteObject(
                            this.Track2DataClient.Encrypt(VaultName, Name, Version, ByteArrayValue, Algorithm));
                        break;
                    case Operations.Decrypt:
                        this.WriteObject(
                            this.Track2DataClient.Decrypt(VaultName, Name, Version, ByteArrayValue, Algorithm));
                        break;
                    case Operations.Wrap:
                        this.WriteObject(
                            this.Track2DataClient.WrapKey(VaultName, Name, Version, ByteArrayValue, Algorithm));
                        break;
                    case Operations.Unwrap:
                        this.WriteObject(
                            this.Track2DataClient.UnwrapKey(VaultName, Name, Version, ByteArrayValue, Algorithm));
                        break;
                    case Operations.Unknown:
                        throw new NotSupportedException($"Not supported operation '{Operation}' yet");
                }
            }
            else
            {
                switch (opt)
                {
                    case Operations.Encrypt:
                        this.WriteObject(
                            this.Track2DataClient.ManagedHsmKeyEncrypt(HsmName, Name, Version, ByteArrayValue, Algorithm));
                        break;
                    case Operations.Decrypt:
                        this.WriteObject(
                            this.Track2DataClient.ManagedHsmKeyDecrypt(HsmName, Name, Version, ByteArrayValue, Algorithm));
                        break;
                    case Operations.Wrap:
                        this.WriteObject(
                            this.Track2DataClient.ManagedHsmWrapKey(HsmName, Name, Version, ByteArrayValue, Algorithm));
                        break;
                    case Operations.Unwrap:
                        this.WriteObject(
                            this.Track2DataClient.ManagedHsmUnwrapKey(HsmName, Name, Version, ByteArrayValue, Algorithm));
                        break;
                    case Operations.Unknown:
                        throw new NotSupportedException($"Not supported operation '{Operation}' yet");
                }
                
            }
        }
    }
}
