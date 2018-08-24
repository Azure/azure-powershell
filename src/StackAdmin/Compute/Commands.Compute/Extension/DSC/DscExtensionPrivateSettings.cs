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

namespace Microsoft.WindowsAzure.Commands.Common.Extensions.DSC
{
    using System.Collections;

    /// <summary>
    /// Represents private/protected settings. Serialized representation of this object stored as an encrypted string on the VM.
    /// Part of the protocol between Set-AzureVMDscExtension cmdlet and DSC Extension handler.
    /// </summary>
    public class DscExtensionPrivateSettings
    {
        /// <summary>
        /// Url to the blob storage with ConfigurationData .psd1 file.
        /// </summary>
        public string DataBlobUri { get; set; }

        /// <summary>
        /// This hashtable contains parameters that needs to be encrypted on target VM, like PSCredential.
        /// <see cref="DscExtensionPublicSettings.Properties" /> are not encrypted on target VM.
        /// </summary>
        public Hashtable Items { get; set; }
    }
}
