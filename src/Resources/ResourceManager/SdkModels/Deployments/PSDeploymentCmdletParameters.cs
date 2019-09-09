// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PSDeploymentCmdletParameters
    {
        public string ResourceGroupName { get; set; }

        public string DeploymentName { get; set; }

        public string Location { get; set; }

        public DeploymentMode DeploymentMode { get; set; }

        public string TemplateFile { get; set; }

        public Hashtable TemplateObject { get; set; }

        public Hashtable TemplateParameterObject { get; set; }

        public string ParameterUri { get; set; }

        public string DeploymentDebugLogLevel { get; set; }

        public OnErrorDeployment OnErrorDeployment { get; set; }
    }
}
