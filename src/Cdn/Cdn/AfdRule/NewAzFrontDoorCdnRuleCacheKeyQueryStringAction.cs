// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Cdn.AfdModels;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdRule
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnRuleCacheKeyQueryStringAction", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSAfdRuleCacheKeyQueryStringAction))]
    public class NewAzFrontDoorCdnRuleCacheKeyQueryStringAction : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleQueryStringBehavior, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Include", "IncludeAll", "Exclude", "ExcludeAll")]
        public string QueryStringBehavior { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleQueryParameters, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string QueryParameters { get; set; }

        public override void ExecuteCmdlet()
        {
            PSAfdRuleCacheKeyQueryStringAction afdRuleCacheKeyQueryStringAction = new PSAfdRuleCacheKeyQueryStringAction();

            if (this.QueryStringBehavior.ToLower() == "include")
            {
                afdRuleCacheKeyQueryStringAction.QueryStringBehavior = "Include";
            }
            else if (this.QueryStringBehavior.ToLower() == "includeall")
            {
                afdRuleCacheKeyQueryStringAction.QueryStringBehavior = "IncludeAll";
            }
            else if (this.QueryStringBehavior.ToLower() == "exclude")
            {
                afdRuleCacheKeyQueryStringAction.QueryStringBehavior = "Exclude";
            }
            else if (this.QueryStringBehavior.ToLower() == "excludeall")
            {
                afdRuleCacheKeyQueryStringAction.QueryStringBehavior = "ExcludeAll";
            }
            else
            {
                throw new PSArgumentException($"{this.QueryStringBehavior} is not valid. Please use : Include, IncludeAll, Exclude, or ExcludeAll");
            }

            afdRuleCacheKeyQueryStringAction.QueryParameters = this.QueryParameters;

            WriteObject(afdRuleCacheKeyQueryStringAction);
        }
    }
}
