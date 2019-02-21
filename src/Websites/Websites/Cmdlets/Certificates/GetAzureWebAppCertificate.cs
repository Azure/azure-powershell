﻿// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using Microsoft.Azure.Commands.WebApps.Utilities;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you get existing web app certificates using ARM APIs
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppCertificate")]
    [OutputType(typeof(PSCertificate))]
    public class GetAzureWebAppCertificate : WebAppBaseClientCmdLet
    {
        [Parameter(Position = 0, Mandatory = false, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = false, HelpMessage = "Thumbprint of the certificate that already exists in web space")]
        [ValidateNotNullOrEmpty]
        public string Thumbprint { get; set; }

        protected override void ProcessRecord()
        {
           var certificates = CmdletHelpers.GetCertificates(this.ResourcesClient, this.WebsitesClient, ResourceGroupName, Thumbprint);
            var output = new List<PSCertificate>();
            foreach (var certificate in certificates)
            {
               output.Add(new PSCertificate(certificate));
            }
            WriteObject(certificates);
        }
    }
}
