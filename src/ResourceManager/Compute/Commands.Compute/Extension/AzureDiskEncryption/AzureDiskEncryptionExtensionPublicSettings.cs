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
    public class AzureDiskEncryptionExtensionPublicSettings
    {
        public string AadClientID { get; set; }
        public string KeyVaultURL { get; set; }
        public string KeyEncryptionKeyURL { get; set; }
        public string KeyEncryptionAlgorithm { get; set; }
        public string VolumeType { get; set; }
        public string AadClientCertThumbprint { get; set; }
        public string SequenceVersion { get; set; }
        public string EncryptionOperation { get; set; }
    }
}
