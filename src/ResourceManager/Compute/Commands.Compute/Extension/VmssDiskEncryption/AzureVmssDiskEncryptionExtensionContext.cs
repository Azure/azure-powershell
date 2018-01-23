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

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    /// <summary>
    /// This class represents the extension context of AzureDiskEncryption VM Scale Set extension. 
    /// This is returned as an output of Get-AzureRmVmssDiskEncryptionStatus cmdlet
    /// </summary>
    public class AzureVmssDiskEncryptionExtensionContext : PSVirtualMachineScaleSetExtension
    {
        public const string LinuxExtensionDefaultPublisher = "Microsoft.Azure.Security";
        public const string LinuxExtensionDefaultName = "AzureDiskEncryptionForLinux";
        public const string LinuxExtensionDefaultVersion = "1.1";

        public const string ExtensionDefaultPublisher = "Microsoft.Azure.Security";
        public const string ExtensionDefaultName = "AzureDiskEncryption";
        public const string ExtensionDefaultVersion = "2.1";
        public const string VolumeTypeOS = "OS";
        public const string VolumeTypeData = "Data";
        public const string VolumeTypeAll = "All";
        public const string StatusSucceeded = "succeeded";
        public const string EncryptionStateString = "EncryptionState/";
    }
}
