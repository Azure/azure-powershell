// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
using Microsoft.Azure.Management.Resources.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PSDeploymentCmdletParameters
    {
        public string ManagementGroupId { get; set; }

        public string ResourceGroupName { get; set; }

        public DeploymentScopeType ScopeType { get; set; }

        public string DeploymentName { get; set; }

        public string Location { get; set; }

        public DeploymentMode DeploymentMode { get; set; }

        public string TemplateFile { get; set; }

        public string TemplateSpecId { get; set; }

        public string QueryString { get; set; }

        public Hashtable TemplateObject { get; set; }

        public Hashtable TemplateParameterObject { get; set; }

        public string ParameterUri { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public string DeploymentDebugLogLevel { get; set; }

        public OnErrorDeployment OnErrorDeployment { get; set; }
    }
}
