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

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public class PSNetworkSecurityPerimeter
    {
        [Ps1Xml(Label = "Network security perimeter id", Target = ViewControl.List, Position = 0)]
        public string Id { get; private set; }

        [Ps1Xml(Label = "Network security perimeter guid", Target = ViewControl.List, Position = 1)]
        public System.Guid? PerimeterGuid { get; private set; }

        [Ps1Xml(Label = "Network security perimeter location", Target = ViewControl.List, Position = 2)]
        public string Location { get; private set; }

        public static explicit operator PSNetworkSecurityPerimeter(NetworkSecurityPerimeter v)
        {
            return new PSNetworkSecurityPerimeter()
            {
                Id = v.Id,
                PerimeterGuid = v.PerimeterGuid,
                Location = v.Location,
            };
        }

        public static explicit operator NetworkSecurityPerimeter(PSNetworkSecurityPerimeter v)
        {
            return new NetworkSecurityPerimeter()
            {
                Id = v.Id,
                PerimeterGuid = v.PerimeterGuid,
                Location = v.Location,
            };
        }
    }
}
