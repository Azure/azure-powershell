// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.PolicyInsights.Cmdlets
{
    using System.Linq;
    using System.Management.Automation;
    using System.Threading;
    using Microsoft.Azure.Commands.PolicyInsights.Common;
    using Microsoft.Azure.Commands.PolicyInsights.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Management.PolicyInsights;
    using Microsoft.Azure.Management.PolicyInsights.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// Gets policy metadata.
    /// </summary>
    [Cmdlet("Get", AzureRMConstants.AzureRMPrefix + "PolicyMetadata"), OutputType(typeof(PSPolicyMetadata))]
    public class GetAzPolicyMetadata : PolicyInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Name)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.TopPolicyMetadata)]
        public int Top { get; set; }

        /// <summary>
        /// Executes the cmdlet to retrieve metadata resources
        /// </summary>
        public override void Execute()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                WriteObject(new PSPolicyMetadata(this.PolicyInsightsClient.PolicyMetadata.GetResource(resourceName: this.Name)));
            }
            else
            {
                var queryOptions = new QueryOptions
                {
                    Top = this.IsParameterBound(c => c.Top) ? (int?)Top : null,
                };

                PaginationHelper.ForEach(
                    getFirstPage: () => this.PolicyInsightsClient.PolicyMetadata.List(queryOptions: queryOptions),
                    getNextPage: nextLink => this.PolicyInsightsClient.PolicyMetadata.ListNext(nextPageLink: nextLink),
                    action: resources => this.WriteObject(sendToPipeline: resources.Select(m => new PSPolicyMetadata(m)), enumerateCollection: true),
                    top: queryOptions.Top.GetValueOrDefault(int.MaxValue),
                    cancellationToken: CancellationToken.None);
            }
        }
    }
}
