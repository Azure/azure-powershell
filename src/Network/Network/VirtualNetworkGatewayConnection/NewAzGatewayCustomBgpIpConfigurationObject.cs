// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGatewayConnection
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "GatewayCustomBgpIpConfigurationObject",
       DefaultParameterSetName = "ByName", SupportsShouldProcess = true), OutputType(typeof(PSGatewayCustomBgpIpConfiguration))]

    public class NewAzGatewayCustomBgpIpConfigurationObject : VirtualNetworkGatewayConnectionBaseCmdlet
    {
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The virtual network gateway IpConfigurationId for BgpPeeringAddresses used in connection.")]
        [ValidateNotNullOrEmpty]
        public string IpConfigurationId { get; set; }

        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The virtual network gateway CustomBgpIpAddress for BgpPeeringAddresses used in connection.")]
        [ValidateNotNullOrEmpty]
        public string CustomBgpIpAddress { get; set; }

        public override void Execute()
        {
            base.Execute();
            var output = new PSGatewayCustomBgpIpConfiguration
            {
                IpconfigurationId = this.IpConfigurationId,
                CustomBgpIpAddress = this.CustomBgpIpAddress
            };
            WriteObject(output);
        }
    }
}

