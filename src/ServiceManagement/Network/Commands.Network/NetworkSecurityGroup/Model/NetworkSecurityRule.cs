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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.NetworkSecurityGroup.Model
{
    public class NetworkSecurityRule
    {
        public string Action { get; set; }
        public string DestinationAddressPrefix { get; set; }
        public string DestinationPortRange { get; set; }
        public bool IsDefault { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Protocol { get; set; }
        public string SourceAddressPrefix { get; set; }
        public string SourcePortRange { get; set; }
        public string State { get; set; }
        public string Type { get; set; }

        public NetworkSecurityGroupWithRules PSParentPath { get; set; }
    }
}
