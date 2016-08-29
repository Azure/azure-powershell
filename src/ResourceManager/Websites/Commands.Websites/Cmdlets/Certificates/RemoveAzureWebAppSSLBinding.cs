// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Rest.Azure;
using System.Linq;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you delete an existing Web app Ssl binding
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmWebAppSSLBinding", SupportsShouldProcess = true)]
    public class RemoveAzureWebAppSSLBinding : WebAppSSLBindingBaseCmdlet
    {
        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The name of the host name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "Delete the certificate if it's the last certificate binding. The default selection is true")]
        [ValidateNotNullOrEmpty]
        public bool? DeleteCertificate { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingWebAppSSLBinding, Name),
                Properties.Resources.RemoveWebAppSSLBinding,
                Name,
                () =>
                {
                    var webapp = WebsitesClient.GetWebApp(resourceGroupName, webAppName, slot);
                    var hostNameSslStates = CmdletHelpers.GetHostNameSslStatesFromSiteResponse(webapp, Name).ToList();
                    if (hostNameSslStates.Count > 0)
                    {
                        var thumbprint = hostNameSslStates[0].Thumbprint;
                        WebsitesClient.UpdateHostNameSslState(resourceGroupName, webAppName, slot, webapp.Location, Name, SslState.Disabled, null);

                        if (!DeleteCertificate.HasValue || DeleteCertificate.Value)
                        {
                            var certificateResourceGroup = CmdletHelpers.GetResourceGroupFromResourceId(webapp.ServerFarmId);
                            var certificates = CmdletHelpers.GetCertificates(this.ResourcesClient, this.WebsitesClient, certificateResourceGroup, thumbprint);
                            if (certificates.Length > 0)
                            {
                                try
                                {
                                    WebsitesClient.RemoveCertificate(certificateResourceGroup, certificates[0].Name);
                                }
                                catch (CloudException e)
                                {
                                    // This exception is thrown when there are other Ssl bindings using this certificate. Let's swallow it and continue.
                                    if (e.Response.StatusCode != HttpStatusCode.Conflict)
                                    {
                                        throw;
                                    }
                                }
                            }
                        }
                    }
                });
        }
    }
}
