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
    [Cmdlet(VerbsCommon.Get, "AzureProviderFeature", DefaultParameterSetName = GetAzureProviderFeatureCmdlet.ListAvailableParameterSet)]
    [OutputType(typeof(List<PSProviderFeature>))]
    public class GetAzureProviderFeatureCmdlet : AzureProviderFeatureCmdletBase
    {
        /// <summary>
        /// The filter unregistered parameter set
        /// </summary>
        internal const string ListAvailableParameterSet = "ListAvailableParameterSet";

        /// <summary>
        /// The get feature parameter set
        /// </summary>
        private const string GetFeatureParameterSet = "GetFeature";

        /// <summary>
        /// Gets or sets the provider name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource provider name.", ParameterSetName = GetAzureProviderFeatureCmdlet.GetFeatureParameterSet)]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource provider name.", ParameterSetName = GetAzureProviderFeatureCmdlet.ListAvailableParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProviderName { get; set; }

        /// <summary>
        /// Gets or sets the feature name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "The feature name.", ParameterSetName = GetAzureProviderFeatureCmdlet.GetFeatureParameterSet)]
        [ValidateNotNullOrEmpty]
        public string FeatureName { get; set; }

        /// <summary>
        /// Gets or sets a switch indicating whether to list all available features or just the ones registered with the current subscription
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "When set, lists all available features including those not registered with the current subscription.", ParameterSetName = GetAzureProviderFeatureCmdlet.ListAvailableParameterSet)]
        public SwitchParameter ListAvailable { get; set; }

        public override void ExecuteCmdlet()
        {
            this.WriteObject(this.ProviderFeatureClient.ListPSProviderFeatures(this.ProviderName, this.FeatureName, this.ListAvailable));
        }
    }
}
