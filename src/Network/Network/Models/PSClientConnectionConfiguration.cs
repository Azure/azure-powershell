// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Commands.Network.Models
{
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;
    public class PSClientConnectionConfiguration
    {
        public string Name { get; set; }

        [Ps1Xml(Label = "Provisioning State", Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [Ps1Xml(Label = "VirtualNetworkGatewayPolicyGroup ids", Target = ViewControl.Table)]
        public List<PSResourceId> VirtualNetworkGatewayPolicyGroups { get; set; }

        public PSAddressSpace VpnClientAddressPool { get; set; }
    }
}
