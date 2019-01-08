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

namespace Microsoft.Azure.Commands.TrafficManager.Models
{
    using Microsoft.Azure.Management.TrafficManager.Models;
    using System.Text;

    public class TrafficManagerIpAddressRange
    {
        public string First { get; set; }

        public string Last { get; set; }

        public int? Scope { get; set; }

        public EndpointPropertiesSubnetsItem ToSDKSubnetMapping()
        {
            return new EndpointPropertiesSubnetsItem
            {
                First = this.First,
                Last = this.Last,
                Scope = this.Scope,
            };
        }

        public static TrafficManagerIpAddressRange FromSDKSubnetMapping(EndpointPropertiesSubnetsItem endpointPropertiesSubnetsItem)
        {
            return new TrafficManagerIpAddressRange
            {
                First = endpointPropertiesSubnetsItem.First,
                Last = endpointPropertiesSubnetsItem.Last,
                Scope = endpointPropertiesSubnetsItem.Scope,
            };
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" {");
            sb.Append($"First:{this.First ?? "null"}");
            if (this.Last != null)
            {
                sb.Append($", Last:{this.Last}");
            }

            if (this.Scope.HasValue)
            {
                sb.Append($", Scope:{this.Scope}");
            }

            sb.Append("} ");
            return sb.ToString();
        }
    }
}
