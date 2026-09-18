// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Search.SearchService
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SearchNetworkSecurityPerimeterConfigurationReconcile",
    DefaultParameterSetName = ResourceNameParameterSetName,
    SupportsShouldProcess = true),
    OutputType(typeof(bool))]
    public class ReconcileNetworkSecurityPerimeterConfigurationCommand : NetworkSecurityPerimeterConfigurationsBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = ResourceGroupHelpMessage)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = ResourceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = NetworkSecurityPerimeterConfigurationNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            CatchThrowInnerException(() =>
            {
                SearchClient.NetworkSecurityPerimeterConfigurations.ReconcileWithHttpMessagesAsync(ResourceGroupName, ServiceName, Name).Wait();
            });

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
