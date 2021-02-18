// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PSDeploymentCmdletParameters
    {
<<<<<<< HEAD
        public string ResourceGroupName { get; set; }

=======
        public string ManagementGroupId { get; set; }

        public string ResourceGroupName { get; set; }

        public DeploymentScopeType ScopeType { get; set; }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public string DeploymentName { get; set; }

        public string Location { get; set; }

        public DeploymentMode DeploymentMode { get; set; }

        public string TemplateFile { get; set; }

<<<<<<< HEAD
=======
        public string TemplateSpecId { get; set; }

        public string QueryString { get; set; }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public Hashtable TemplateObject { get; set; }

        public Hashtable TemplateParameterObject { get; set; }

        public string ParameterUri { get; set; }

<<<<<<< HEAD
=======
        public IDictionary<string, string> Tags { get; set; }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public string DeploymentDebugLogLevel { get; set; }

        public OnErrorDeployment OnErrorDeployment { get; set; }
    }
}
