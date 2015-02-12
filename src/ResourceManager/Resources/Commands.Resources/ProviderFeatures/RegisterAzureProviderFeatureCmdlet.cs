// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Resources.ProviderFeatures
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Resources.Models.ProviderFeatures;

    /// <summary>
    /// Register the previewed features of a certain azure resource provider.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "AzureProviderFeature"), OutputType(typeof(List<PSProviderFeature>))]
    public class RegisterAzureProviderFeatureCmdlet : AzureProviderFeatureCmdletBase
    {
        /// <summary>
        /// Gets or sets the provider name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource provider name.")]
        [ValidateNotNullOrEmpty]
        public string FeatureName { get; set; }

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
            this.WriteObject(this.ProviderFeatureClient.RegisterProviderFeature(providerName: this.ProviderName, featureName: this.FeatureName));
        }
    }
}