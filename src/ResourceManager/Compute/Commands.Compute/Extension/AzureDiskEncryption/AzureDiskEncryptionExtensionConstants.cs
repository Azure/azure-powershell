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

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    /// <summary>
    /// This class includes contant values used in AzureDiskEncryption
    /// </summary>
    public static class AzureDiskEncryptionExtensionConstants
    {
        public const string aadClientCertParameterSet = "AAD Client Cert Parameters";
        public const string aadClientSecretParameterSet = "AAD Client Secret Parameters";
        public const string enableEncryptionOperation = "EnableEncryption";
        public const string disableEncryptionOperation = "DisableEncryption";
        public const string queryEncryptionStatusOperation = "QueryEncryptionStatus";
        public const string encryptionResultOsKey = "os";
        public const string encryptionResultDataKey = "data";
        public const string aadClientIDKey = "AADClientID";
        public const string aadClientSecretKey = "AADClientSecret";
        public const string aadClientCertThumbprintKey = "AADClientCertThumbprint";
        public const string keyVaultUrlKey = "KeyVaultURL";
        public const string keyEncryptionKeyUrlKey = "KeyEncryptionKeyURL";
        public const string keyEncryptionAlgorithmKey = "KeyEncryptionAlgorithm";
        public const string volumeTypeKey = "VolumeType";
        public const string encryptionOperationKey = "EncryptionOperation";
        public const string sequenceVersionKey = "SequenceVersion";
        public const string passphraseKey = "Passphrase";
        public const string osTypeLinux = "Linux";
        public const string osTypeWindows = "Windows";
        public const string defaultKeyEncryptionAlgorithm = "RSA-OAEP";
    }
}