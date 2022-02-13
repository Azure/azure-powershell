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

using Microsoft.Azure.Commands.Cdn.AfdHelpers;
using Microsoft.Azure.Commands.Cdn.AfdModels;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdRule
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnRule", SupportsShouldProcess = true), OutputType(typeof(PSAfdRule))]
    public class NewAzFrontDoorCdnRule : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleActions)]
        public List<PSAfdRuleAction> Action { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleConditions)]
        public List<PSAfdRuleCondition> Condition { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleSetName)]
        [ValidateNotNullOrEmpty]
        public string RuleSetName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleName)]
        [ValidateNotNullOrEmpty]
        public string RuleName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdRuleOrder)]
        [ValidateNotNullOrEmpty]
        public int Order { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdRuleMatchProcessingBehavior)]
        [PSArgumentCompleter("Continue", "Stop")]
        [ValidateNotNullOrEmpty]
        public string MatchProcessingBehavior { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(AfdResourceProcessMessage.AfdRuleCreateMessage, this.RuleName, this.CreateAfdRule);
        }

        private void CreateAfdRule()
        {
            try
            {
                Rule afdRule = new Rule
                {
                    Order = this.Order,
                    Actions = this.CreateAfdRuleActions(),
                    Conditions = this.CreateAfdRuleConditions()
                };
                
                if (MyInvocation.BoundParameters.ContainsKey("MatchProcessingBehavior"))
                {
                    afdRule.MatchProcessingBehavior = this.MatchProcessingBehavior;
                }

                PSAfdRule psAfdRule = this.CdnManagementClient.Rules.Create(this.ResourceGroupName, this.ProfileName, this.RuleSetName, this.RuleName, afdRule).ToPSAfdRule();

                WriteObject(psAfdRule);
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }
    
        private List<DeliveryRuleAction> CreateAfdRuleActions()
        {
            List<DeliveryRuleAction> afdRuleActions = new List<DeliveryRuleAction>();

            foreach (PSAfdRuleAction afdAction in this.Action)
            {
                if (afdAction is PSAfdRuleCacheExpirationAction)
                {
                    PSAfdRuleCacheExpirationAction psCacheExpirationAction = (PSAfdRuleCacheExpirationAction)afdAction;

                    DeliveryRuleCacheExpirationAction cacheExpirationAction = new DeliveryRuleCacheExpirationAction
                    {
                        Parameters = new CacheExpirationActionParameters
                        {
                            CacheBehavior = psCacheExpirationAction.CacheBehavior,
                            CacheDuration = psCacheExpirationAction.CacheDuration
                        }
                    };

                    afdRuleActions.Add(cacheExpirationAction);
                }

                if (afdAction is PSAfdRuleHeaderAction)
                {
                    PSAfdRuleHeaderAction psHeaderAction = (PSAfdRuleHeaderAction)afdAction;

                    if (psHeaderAction.HeaderType == "ModifyRequestHeader")
                    {
                        DeliveryRuleRequestHeaderAction requestHeaderAction = new DeliveryRuleRequestHeaderAction
                        {
                            Parameters = new HeaderActionParameters
                            {
                                HeaderAction = psHeaderAction.HeaderAction,
                                HeaderName = psHeaderAction.HeaderName,
                                Value = psHeaderAction.HeaderValue
                            }
                        };
                        afdRuleActions.Add(requestHeaderAction);
                    }
                    else if (psHeaderAction.HeaderType == "ModifyResponseHeader")
                    {
                        DeliveryRuleResponseHeaderAction responseHeaderAction = new DeliveryRuleResponseHeaderAction
                        {
                            Parameters = new HeaderActionParameters
                            {
                                HeaderAction = psHeaderAction.HeaderAction,
                                HeaderName = psHeaderAction.HeaderName,
                                Value = psHeaderAction.HeaderValue
                            }
                        };
                        afdRuleActions.Add(responseHeaderAction);
                    }
                }

                if (afdAction is PSAfdRuleCacheKeyQueryStringAction)
                {
                    PSAfdRuleCacheKeyQueryStringAction psCacheKeyQueryString = (PSAfdRuleCacheKeyQueryStringAction)afdAction;

                    DeliveryRuleCacheKeyQueryStringAction cacheKeyQueryStringAction = new DeliveryRuleCacheKeyQueryStringAction
                    {
                        Parameters = new CacheKeyQueryStringActionParameters
                        {
                            QueryParameters = psCacheKeyQueryString.QueryParameters,
                            QueryStringBehavior = psCacheKeyQueryString.QueryStringBehavior
                        }
                    };

                    afdRuleActions.Add(cacheKeyQueryStringAction);
                }

                if (afdAction is PSAfdRuleUrlRedirectAction)
                {
                    PSAfdRuleUrlRedirectAction psUrlRedirectAction = (PSAfdRuleUrlRedirectAction)afdAction;

                    UrlRedirectAction urlRedirectAction = new UrlRedirectAction
                    {
                        Parameters = new UrlRedirectActionParameters
                        {
                            CustomFragment = psUrlRedirectAction.CustomFragment,
                            CustomHostname = psUrlRedirectAction.CustomHostname,
                            CustomPath = psUrlRedirectAction.CustomPath,
                            CustomQueryString = psUrlRedirectAction.CustomQueryString,
                            DestinationProtocol = psUrlRedirectAction.DestinationProtocol,
                            RedirectType = psUrlRedirectAction.RedirectType
                        }
                    };

                    afdRuleActions.Add(urlRedirectAction);
                }

                if (afdAction is PSAfdRuleUrlRewriteAction)
                {
                    PSAfdRuleUrlRewriteAction psUrlRewriteAction = (PSAfdRuleUrlRewriteAction)afdAction;

                    UrlRewriteAction urlRewriteAction = new UrlRewriteAction
                    { 
                        Parameters = new UrlRewriteActionParameters
                        {
                            SourcePattern = psUrlRewriteAction.SourcePattern,
                            Destination = psUrlRewriteAction.Destination,
                            PreserveUnmatchedPath = psUrlRewriteAction.PreservePath
                        }
                    };

                    afdRuleActions.Add(urlRewriteAction);
                }
                
                if (afdAction is PSAfdRuleOriginGroupOverrideAction)
                {
                    PSAfdRuleOriginGroupOverrideAction psOriginGroupOverrideAction = (PSAfdRuleOriginGroupOverrideAction)afdAction;

                    OriginGroupOverrideAction originGroupOverrideAction = new OriginGroupOverrideAction
                    {
                        Parameters = new OriginGroupOverrideActionParameters
                        {
                            OriginGroup = new ResourceReference(psOriginGroupOverrideAction.OriginGroup)
                        }
                    };

                    afdRuleActions.Add(originGroupOverrideAction);
                }
            }

            return afdRuleActions;
        }

        private List<DeliveryRuleCondition> CreateAfdRuleConditions()
        {
            List<DeliveryRuleCondition> afdRuleConditions = new List<DeliveryRuleCondition>();

            if (!MyInvocation.BoundParameters.ContainsKey("Condition"))
            {
                return afdRuleConditions;
            }

            foreach (PSAfdRuleCondition afdRuleCondition in this.Condition)
            {
                switch (afdRuleCondition.MatchVariable)
                {
                    case "Cookies":
                        DeliveryRuleCookiesCondition cookieCondition = new DeliveryRuleCookiesCondition
                        {
                            Parameters = new CookiesMatchConditionParameters
                            {
                                MatchValues = afdRuleCondition.MatchValue,
                                NegateCondition = afdRuleCondition.NegateCondition,
                                OperatorProperty = afdRuleCondition.Operator,
                                Selector = afdRuleCondition.Selector,
                                Transforms = afdRuleCondition.Transforms
                            }
                        };
                        afdRuleConditions.Add(cookieCondition);
                        break;

                    case "RemoteAddress":
                        DeliveryRuleRemoteAddressCondition remoteAddressCondition = new DeliveryRuleRemoteAddressCondition
                        {
                            Parameters = new RemoteAddressMatchConditionParameters
                            {
                                MatchValues = afdRuleCondition.MatchValue,
                                NegateCondition = afdRuleCondition.NegateCondition,
                                OperatorProperty = afdRuleCondition.Operator,
                                Transforms = afdRuleCondition.Transforms
                            }
                        };
                        afdRuleConditions.Add(remoteAddressCondition);
                        break;

                    case "RequestMethod":
                        DeliveryRuleRequestMethodCondition requestMethodCondition = new DeliveryRuleRequestMethodCondition
                        {
                            Parameters = new RequestMethodMatchConditionParameters
                            {
                                MatchValues = afdRuleCondition.MatchValue,
                                NegateCondition = afdRuleCondition.NegateCondition
                            }
                        };
                        afdRuleConditions.Add(requestMethodCondition);
                        break;

                    case "QueryString":
                        DeliveryRuleQueryStringCondition queryStringCondition = new DeliveryRuleQueryStringCondition
                        {
                            Parameters = new QueryStringMatchConditionParameters
                            {
                                MatchValues = afdRuleCondition.MatchValue,
                                NegateCondition = afdRuleCondition.NegateCondition,
                                OperatorProperty = afdRuleCondition.Operator,
                                Transforms = afdRuleCondition.Transforms
                            }
                        };
                        afdRuleConditions.Add(queryStringCondition);
                        break;

                    case "PostArgs":
                        DeliveryRulePostArgsCondition postArgsCondition = new DeliveryRulePostArgsCondition
                        { 
                            Parameters = new PostArgsMatchConditionParameters
                            {
                                MatchValues = afdRuleCondition.MatchValue,
                                NegateCondition = afdRuleCondition.NegateCondition,
                                OperatorProperty = afdRuleCondition.Operator,
                                Selector = afdRuleCondition.Selector,
                                Transforms = afdRuleCondition.Transforms
                            }
                        };
                        afdRuleConditions.Add(postArgsCondition);
                        break;

                    case "RequestUri":
                        DeliveryRuleRequestUriCondition requestUriCondition = new DeliveryRuleRequestUriCondition
                        {
                            Parameters = new RequestUriMatchConditionParameters
                            {
                                MatchValues = afdRuleCondition.MatchValue,
                                NegateCondition = afdRuleCondition.NegateCondition,
                                OperatorProperty = afdRuleCondition.Operator,
                                Transforms = afdRuleCondition.Transforms
                            }
                        };
                        afdRuleConditions.Add(requestUriCondition);
                        break;

                    case "RequestHeader":
                        DeliveryRuleRequestHeaderCondition requestHeaderCondition = new DeliveryRuleRequestHeaderCondition
                        {
                            Parameters = new RequestHeaderMatchConditionParameters
                            {
                                MatchValues = afdRuleCondition.MatchValue,
                                NegateCondition = afdRuleCondition.NegateCondition,
                                OperatorProperty = afdRuleCondition.Operator,
                                Selector = afdRuleCondition.Selector,
                                Transforms = afdRuleCondition.Transforms
                            }
                        };
                        afdRuleConditions.Add(requestHeaderCondition);
                        break;

                    case "RequestBody":
                        DeliveryRuleRequestBodyCondition requestBodyCondition = new DeliveryRuleRequestBodyCondition
                        {
                            Parameters = new RequestBodyMatchConditionParameters
                            {
                                MatchValues = afdRuleCondition.MatchValue,
                                NegateCondition = afdRuleCondition.NegateCondition,
                                OperatorProperty = afdRuleCondition.Operator,
                                Transforms = afdRuleCondition.Transforms
                            }
                        };
                        afdRuleConditions.Add(requestBodyCondition);
                        break;

                    case "RequestScheme":
                        DeliveryRuleRequestSchemeCondition requestSchemeCondition = new DeliveryRuleRequestSchemeCondition
                        {
                            Parameters = new RequestSchemeMatchConditionParameters
                            {
                                MatchValues = afdRuleCondition.MatchValue,
                                NegateCondition = afdRuleCondition.NegateCondition
                            }
                        };
                        afdRuleConditions.Add(requestSchemeCondition);
                        break;

                    case "UrlPath":
                        DeliveryRuleUrlPathCondition urlPathCondition = new DeliveryRuleUrlPathCondition
                        {
                            Parameters = new UrlPathMatchConditionParameters
                            {
                                MatchValues = afdRuleCondition.MatchValue,
                                NegateCondition = afdRuleCondition.NegateCondition,
                                OperatorProperty = afdRuleCondition.Operator,
                                Transforms = afdRuleCondition.Transforms
                            }
                        };
                        afdRuleConditions.Add(urlPathCondition);
                        break;

                    case "UrlFileExtension":
                        DeliveryRuleUrlFileExtensionCondition urlFileExtensionCondition = new DeliveryRuleUrlFileExtensionCondition
                        {
                            Parameters = new UrlFileExtensionMatchConditionParameters
                            {
                                MatchValues = afdRuleCondition.MatchValue,
                                NegateCondition = afdRuleCondition.NegateCondition,
                                OperatorProperty = afdRuleCondition.Operator,
                                Transforms = afdRuleCondition.Transforms
                            }
                        };
                        afdRuleConditions.Add(urlFileExtensionCondition);
                        break;

                    case "UrlFilename":
                        DeliveryRuleUrlFileNameCondition urlFileNameCondition = new DeliveryRuleUrlFileNameCondition
                        {
                            Parameters = new UrlFileNameMatchConditionParameters
                            {
                                MatchValues = afdRuleCondition.MatchValue,
                                NegateCondition = afdRuleCondition.NegateCondition,
                                OperatorProperty = afdRuleCondition.Operator,
                                Transforms = afdRuleCondition.Transforms
                            }
                        };
                        afdRuleConditions.Add(urlFileNameCondition);
                        break;

                    case "HttpVersion":
                        DeliveryRuleHttpVersionCondition httpVersionCondition = new DeliveryRuleHttpVersionCondition
                        { 
                            Parameters = new HttpVersionMatchConditionParameters
                            {
                                MatchValues = afdRuleCondition.MatchValue,
                                NegateCondition = afdRuleCondition.NegateCondition,
                            }
                        };
                        afdRuleConditions.Add(httpVersionCondition);
                        break;

                    case "IsDevice":
                        DeliveryRuleIsDeviceCondition isDeviceCondition = new DeliveryRuleIsDeviceCondition
                        {
                            Parameters = new IsDeviceMatchConditionParameters
                            {
                                MatchValues = afdRuleCondition.MatchValue,
                                NegateCondition = afdRuleCondition.NegateCondition,
                                Transforms = afdRuleCondition.Transforms
                            }
                        };
                        afdRuleConditions.Add(isDeviceCondition);
                        break;
                }
            }

            return afdRuleConditions;
        }
    }
}
