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

using Microsoft.Azure.Commands.Compute.Models;
using Newtonsoft.Json;
using System.Security;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    /// <summary>
    /// This class represents the extension context of AzureDiskEncryption VM extension. This is returned as an output of Get-AzureDiskEncryption cmdlet
    /// </summary>
    public class AzureDiskEncryptionExtensionContext : PSVirtualMachineExtension
    {
        public const string LinuxExtensionDefaultPublisher = "Microsoft.Azure.Security";
        public const string LinuxExtensionDefaultName = "AzureDiskEncryptionForLinux";
        public const string LinuxExtensionDefaultVersion = "0.1";

        public const string ExtensionDefaultPublisher = "Microsoft.Azure.Security";
        public const string ExtensionDefaultName = "AzureDiskEncryption";
        public const string ExtensionDefaultVersion = "1.1";
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
        public string EncryptionOperation { get; set; }
        public SecureString Passphrase { get; set; }

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
            EncryptionOperation = (publicSettings == null) ? null : publicSettings.EncryptionOperation;
            AadClientSecret = (protectedSettings == null) ? null : ConvertStringToSecureString(protectedSettings.AadClientSecret);
            Passphrase = (protectedSettings == null) ? null : ConvertStringToSecureString(protectedSettings.Passphrase);
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
            SubStatuses = psExt.SubStatuses;

            InitializeAzureDiskEncryptionMembers(psExt);
        }
    }
}