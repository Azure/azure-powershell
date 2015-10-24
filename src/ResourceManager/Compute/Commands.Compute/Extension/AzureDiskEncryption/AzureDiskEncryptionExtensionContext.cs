using Newtonsoft.Json;
using System.Security;
using Microsoft.Azure.Commands.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    /// <summary>
    /// This class represents the extension context of AzureDiskEncryption VM extension. This is returned as an output of Get-AzureDiskEncryption cmdlet
    /// </summary>
    public class AzureDiskEncryptionExtensionContext : PSVirtualMachineExtension
    {
        public const string ExtensionDefaultPublisher = "Microsoft.Azure.Security";
        //TODO: Replace ADETest with real name once finalized with publishing
        public const string ExtensionDefaultName = "ADETest";
        public const string ExtensionDefaultVersion = "1.3";
        public const string VolumeTypeOS = "OS";
        public const string VolumeTypeData = "Data";
        public const string VolumeTypeAll = "All";
        public const string StatusSucceeded = "Succeeded";

        // Extension configuration
        public string AadClientID { get; set; }
        public SecureString AadClientSecret { get; set; }
        public string KeyVaultURL { get; set; }
        public string KeyEncryptionKeyURL { get; set; }
        public string KeyEncryptionAlgorithm { get; set; }
        public string VolumeType { get; set; }
        public string AadClientCertThumbprint { get; set; }
        public string SequenceVersion { get; set; }

        private static SecureString ConvertStringToSecureString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return null;
            SecureString secStr = new SecureString();
            foreach (char ch in str.ToCharArray())
            {
                secStr.AppendChar(ch);
            }

            return secStr;
        }

        private void InitializeAzureDiskEncryptionMembers(PSVirtualMachineExtension psExt)
        {
            AzureDiskEncryptionExtensionPublicSettings publicSettings = string.IsNullOrEmpty(psExt.PublicSettings) ? null
                                    : JsonConvert.DeserializeObject<AzureDiskEncryptionExtensionPublicSettings>(psExt.PublicSettings);

            AzureDiskEncryptionExtensionProtectedSettings protectedSettings = string.IsNullOrEmpty(psExt.ProtectedSettings) ? null
                                    : JsonConvert.DeserializeObject<AzureDiskEncryptionExtensionProtectedSettings>(psExt.ProtectedSettings);

            AadClientID = (publicSettings == null) ? null : publicSettings.AadClientID;
            KeyVaultURL = (publicSettings == null) ? null : publicSettings.KeyVaultURL;
            KeyEncryptionKeyURL = (publicSettings == null) ? null : publicSettings.KeyEncryptionKeyURL;
            KeyEncryptionAlgorithm = (publicSettings == null) ? null : publicSettings.KeyEncryptionAlgorithm;
            VolumeType = (publicSettings == null) ? null : publicSettings.VolumeType;
            AadClientCertThumbprint = (publicSettings == null) ? null : publicSettings.AadClientCertThumbprint;
            SequenceVersion = (publicSettings == null) ? null : publicSettings.SequenceVersion;
            AadClientSecret = (protectedSettings == null) ? null : ConvertStringToSecureString(protectedSettings.AadClientSecret);
        }

        public AzureDiskEncryptionExtensionContext(PSVirtualMachineExtension psExt)
        {
            ResourceGroupName = psExt.ResourceGroupName;
            Name = psExt.Name;
            Location = psExt.Location;
            Etag = psExt.Etag;
            Publisher = psExt.Publisher;
            ExtensionType = psExt.ExtensionType;
            TypeHandlerVersion = psExt.TypeHandlerVersion;
            Id = psExt.Id;
            PublicSettings = psExt.PublicSettings;
            ProtectedSettings = psExt.ProtectedSettings;
            ProvisioningState = psExt.ProvisioningState;
            Statuses = psExt.Statuses;

            InitializeAzureDiskEncryptionMembers(psExt);
        }
    }
}