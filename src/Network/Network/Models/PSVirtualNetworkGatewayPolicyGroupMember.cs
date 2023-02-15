// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network.Models
{
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;

    public class PSVirtualNetworkGatewayPolicyGroupMember
    {
        public string Name { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string AttributeType { get; set; }
        
        public string AttributeValue { get; set; }
    }
}