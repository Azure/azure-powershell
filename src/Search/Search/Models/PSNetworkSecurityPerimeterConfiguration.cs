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

using Microsoft.Azure.Management.Search.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public class PSNetworkSecurityPerimeterConfiguration
    {
        [Ps1Xml(Label = "Network security perimeter configuration name", Target = ViewControl.List, Position = 0)]
        public string Name { get; private set; }

        [Ps1Xml(Label = "Network security perimeter configuration resource id", Target = ViewControl.List, Position = 1)]
        public string Id { get; private set; }

        [Ps1Xml(Label = "Network security perimeter configuration type", Target = ViewControl.List, Position = 2)]
        public string Type { get; private set; }

        [Ps1Xml(Label = "Network security perimeter configuration provisioning state", Target = ViewControl.List, Position = 3)]
        public PSNetworkSecurityPerimeterConfigurationProvisioningState ProvisioningState { get; private set; }

        [Ps1Xml(Label = "Network security perimeter configuration network security perimeter", Target = ViewControl.List, Position = 4)]
        public PSNetworkSecurityPerimeter NetworkSecurityPerimeter { get; private set; }

        [Ps1Xml(Label = "Network security perimeter configuration resource association", Target = ViewControl.List, Position = 5)]
        public PSResourceAssociation ResourceAssociation { get; private set; }

        [Ps1Xml(Label = "Network security perimeter configuration profile", Target = ViewControl.List, Position = 6)]
        public PSNetworkSecurityProfile Profile { get; private set; }

        public PSNetworkSecurityPerimeterConfiguration(NetworkSecurityPerimeterConfiguration configuration)
        {
            Name = configuration.Name;
            Id = configuration.Id;
            Type = configuration.Type;

            if (configuration.Properties.ProvisioningState != null &&
                Enum.TryParse(configuration.Properties.ProvisioningState, ignoreCase: true, out PSNetworkSecurityPerimeterConfigurationProvisioningState provisioningState))
            {
                ProvisioningState = provisioningState;
            }

            if (configuration.Properties.NetworkSecurityPerimeter != null)
            {
                NetworkSecurityPerimeter = (PSNetworkSecurityPerimeter)configuration.Properties.NetworkSecurityPerimeter;
            }

            if (configuration.Properties.ResourceAssociation != null)
            {
                ResourceAssociation = (PSResourceAssociation)configuration.Properties.ResourceAssociation;
            }
            if (configuration.Properties.Profile != null)
            {
                Profile = (PSNetworkSecurityProfile)configuration.Properties.Profile;
            }
        }
    }
}
