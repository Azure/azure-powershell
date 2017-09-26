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

using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class VirtualMachineCustomScriptExtensionContext : PSVirtualMachineExtension
    {
        public const string ExtensionDefaultPublisher = "Microsoft.Compute";
        public const string ExtensionDefaultName = "CustomScriptExtension";
        public const string ExtensionDefaultVersion = "1.4";

        public string CommandToExecute { get; set; }
        public string[] Uri { get; set; }

        public VirtualMachineCustomScriptExtensionContext(PSVirtualMachineExtension psExt)
        {
            var publicSettings = string.IsNullOrEmpty(psExt.PublicSettings) ? null
                                    : JsonConvert.DeserializeObject<CustomScriptExtensionPublicSettings>(psExt.PublicSettings);

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
            CommandToExecute = (publicSettings == null) ? null : publicSettings.commandToExecute;
            Uri = (publicSettings == null) ? null : publicSettings.fileUris;
        }
    }
}
