// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Resources
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Resources.Models;

    /// <summary>
    /// Un-registers the resource provider from the current subscription.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Unregister, "AzureProvider"), OutputType(typeof(List<PSResourceProvider>))]
    public class UnregisterAzureProviderCmdlet : ResourcesBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the provider name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource provider name.")]
        [ValidateNotNullOrEmpty]
        public string ProviderName { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            this.WriteObject(this.ResourcesClient.UnregisterProvider(providerName: this.ProviderName));
        }
    }
}