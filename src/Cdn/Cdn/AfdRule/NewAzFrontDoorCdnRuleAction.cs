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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnRuleAction", DefaultParameterSetName = AfdParameterSet.AfdRuleCacheExpirationAction), OutputType(typeof(PSAfdRuleAction))]
    public class NewAzFrontDoorCdnRuleAction : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleCachingBehavior, ParameterSetName = AfdParameterSet.AfdRuleCacheExpirationAction)]
        [PSArgumentCompleter("BypassCache", "SetIfMissing", "Override")]
        [ValidateNotNullOrEmpty]
        public string CacheBehavior { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleCacheDuration, ParameterSetName = AfdParameterSet.AfdRuleCacheExpirationAction)]
        [PSArgumentCompleter("[d.]hh:mm:ss")]
        [ValidateNotNullOrEmpty]
        public string CacheDuration { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleHeaderType, ParameterSetName = AfdParameterSet.AfdRuleHeaderTypeAction)]
        [PSArgumentCompleter("ModifyRequestHeader", "ModifyResponseHeader")]
        public string HeaderType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleHeaderAction, ParameterSetName = AfdParameterSet.AfdRuleHeaderTypeAction)]
        [PSArgumentCompleter("Append", "Overwrite", "Delete")]
        [ValidateNotNullOrEmpty]
        public string HeaderAction { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleHeaderName, ParameterSetName = AfdParameterSet.AfdRuleHeaderTypeAction)]
        [ValidateNotNullOrEmpty]
        public string HeaderName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleHeaderValue, ParameterSetName = AfdParameterSet.AfdRuleHeaderTypeAction)]
        [ValidateNotNullOrEmpty]
        public string HeaderValue { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleQueryStringBehavior, ParameterSetName = AfdParameterSet.AfdRuleCacheKeyQueryStringAction)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Include", "IncludeAll", "Exclude", "ExcludeAll")]
        public string QueryStringBehavior { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleQueryParameters, ParameterSetName = AfdParameterSet.AfdRuleCacheKeyQueryStringAction)]
        [ValidateNotNullOrEmpty]
        public string QueryParameter { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleRedirectType, ParameterSetName = AfdParameterSet.AfdRuleUrlRedirectAction)]
        [PSArgumentCompleter("Moved", "Found", "TemporaryRedirect", "PermanentRedirect")]
        public string RedirectType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleDestinationProtocol, ParameterSetName = AfdParameterSet.AfdRuleUrlRedirectAction)]
        [PSArgumentCompleter("MatchRequest", "Http", "Https")]
        [ValidateNotNullOrEmpty]
        public string DestinationProtocol { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleCustomPath, ParameterSetName = AfdParameterSet.AfdRuleUrlRedirectAction)]
        [ValidateNotNullOrEmpty]
        public string CustomPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleCustomHostname, ParameterSetName = AfdParameterSet.AfdRuleUrlRedirectAction)]
        [ValidateNotNullOrEmpty]
        public string CustomHostname { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleCustomQueryString, ParameterSetName = AfdParameterSet.AfdRuleUrlRedirectAction)]
        [ValidateNotNullOrEmpty]
        public string CustomQueryString { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleCustomFragment, ParameterSetName = AfdParameterSet.AfdRuleUrlRedirectAction)]
        [ValidateNotNullOrEmpty]
        public string CustomFragment { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleSourcePattern, ParameterSetName = AfdParameterSet.AfdRuleUrlRewriteAction)]
        public string SourcePattern { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleDestination, ParameterSetName = AfdParameterSet.AfdRuleUrlRewriteAction)]
        public string Destination { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRulePreservePath, ParameterSetName = AfdParameterSet.AfdRuleUrlRewriteAction)]
        public SwitchParameter PreservePath { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleOriginGroupOverride, ParameterSetName = AfdParameterSet.AfdRuleOriginGroupOverrideAction)]
        public string OriginGroupOverride { get; set; }

        public override void ExecuteCmdlet()
        {
            PSAfdRuleAction afdRuleAction = new PSAfdRuleAction();

            if (ParameterSetName == AfdParameterSet.AfdRuleCacheExpirationAction)
            {
                afdRuleAction = new PSAfdRuleCacheExpirationAction
                {
                    CacheBehavior = this.CacheBehavior,
                    CacheDuration = this.CacheDuration
                }; 
            }
            else if (ParameterSetName == AfdParameterSet.AfdRuleHeaderTypeAction)
            {
                afdRuleAction = new PSAfdRuleHeaderAction
                {
                    HeaderType = this.HeaderType,
                    HeaderAction = this.HeaderAction,
                    HeaderName = this.HeaderName,
                    HeaderValue = this.HeaderValue
                };
            }
            else if (ParameterSetName == AfdParameterSet.AfdRuleCacheKeyQueryStringAction)
            {
                afdRuleAction = new PSAfdRuleCacheKeyQueryStringAction
                {
                    QueryParameters = this.QueryParameter,
                    QueryStringBehavior = this.QueryStringBehavior
                };
            }
            else if (ParameterSetName == AfdParameterSet.AfdRuleUrlRedirectAction)
            {
                afdRuleAction = new PSAfdRuleUrlRedirectAction
                {
                    CustomFragment = this.CustomFragment,
                    CustomHostname =  this.CustomHostname,
                    CustomPath = this.CustomPath,
                    CustomQueryString = this.CustomQueryString,
                    DestinationProtocol = this.DestinationProtocol,
                    RedirectType = this.RedirectType
                };
            }
            else if (ParameterSetName == AfdParameterSet.AfdRuleUrlRewriteAction)
            {
                afdRuleAction = new PSAfdRuleUrlRewriteAction
                {
                    SourcePattern = this.SourcePattern,
                    Destination = this.Destination,
                    PreservePath = this.PreservePath
                };
            }
            else if (ParameterSetName == AfdParameterSet.AfdRuleOriginGroupOverrideAction)
            {
                afdRuleAction = new PSAfdRuleOriginGroupOverrideAction
                {
                    OriginGroup = this.OriginGroupOverride
                };
            }

            WriteObject(afdRuleAction);
        }
    }
}
