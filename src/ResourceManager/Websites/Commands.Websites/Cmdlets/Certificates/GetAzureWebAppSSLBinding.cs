// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.WebApps.Utilities;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you get an existing web app Ssl binding using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmWebAppSSLBinding")]
    public class GetAzureWebAppSSLBinding : WebAppSSLBindingBaseCmdlet
    {
        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The name of the host name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            var webapp = WebsitesClient.GetWebApp(resourceGroupName, webAppName, slot);
            WriteObject(CmdletHelpers.GetHostNameSslStatesFromSiteResponse(webapp, Name));
        }
    }
}
