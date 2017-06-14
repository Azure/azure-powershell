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

//using Microsoft.Azure.Commands.Compute.Models;
using Newtonsoft.Json;
using System.Security;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class VirtualMachineAccessExtensionContext : PSVirtualMachineExtension
    {
        public const string ExtensionDefaultPublisher = "Microsoft.Compute";
        public const string ExtensionDefaultName = "VMAccessAgent";
        public const string ExtensionDefaultVersion = "2.0";

        public string UserName { get; set; }
        public SecureString Password { get; set; }

        public VirtualMachineAccessExtensionContext(PSVirtualMachineExtension psExt)
        {
            var publicSettings = string.IsNullOrEmpty(psExt.PublicSettings) ? null
                                    : JsonConvert.DeserializeObject<VMAccessExtensionPublicSettings>(psExt.PublicSettings);

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
            UserName = (publicSettings == null) ? null : publicSettings.UserName;
        }
    }
}
