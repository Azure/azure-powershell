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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.Endpoint;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Cdn.Endpoint
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnDeliveryRuleAction", DefaultParameterSetName = CacheExpirationActionParameterSet), OutputType(typeof(PSDeliveryRuleAction))]
    public class NewAzCdnDeliveryRuleAction : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Caching behavior for the action", ParameterSetName = CacheExpirationActionParameterSet)]
        [PSArgumentCompleter("BypassCache", "SetIfMissing", "Override")]
        [ValidateNotNullOrEmpty]
        public string CacheBehavior { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The duration for which the content needs to be cached. Allowed format is [d.]hh:mm:ss", ParameterSetName = CacheExpirationActionParameterSet)]
        [PSArgumentCompleter("[d.]hh:mm:ss")]
        [ValidateNotNullOrEmpty]
        public string CacheDuration { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Whether to modify request header or response header", ParameterSetName = HeaderActionParameterSet)]
        [PSArgumentCompleter("ModifyRequestHeader", "ModifyResponseHeader")]
        public string HeaderActionType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Action to perform.", ParameterSetName = HeaderActionParameterSet)]
        [PSArgumentCompleter("Append", "Overwrite", "Delete")]
        [ValidateNotNullOrEmpty]
        public string Action { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Name of the header to modify.", ParameterSetName = HeaderActionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string HeaderName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Value for the specified action.", ParameterSetName = HeaderActionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }
        
        [Parameter(Mandatory = true, HelpMessage = "The redirect type the rule will use when redirecting traffic", ParameterSetName = UrlRedirectActionParameterSet)]
        [PSArgumentCompleter("Moved", "Found", "TemporaryRedirect", "PermanentRedirect")]
        public string RedirectType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Protocol to use for the redirect. The default value is MatchRequest.", ParameterSetName = UrlRedirectActionParameterSet)]
        [PSArgumentCompleter("MatchRequest", "Http", "Https")]
        [ValidateNotNullOrEmpty]
        public string DestinationProtocol { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The full path to redirect. Path cannot be empty and must start with /. Leave empty to use the incoming path as destination path.", ParameterSetName = UrlRedirectActionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string CustomPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Host to redirect. Leave empty to use use the incoming host as the destination host.", ParameterSetName = UrlRedirectActionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string CustomHostname { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The set of query strings to be placed in the redirect URL. Setting this value would replace any existing query string; leave empty to preserve the incoming query string. Query string must be in <key>=<value> format. ? and & will be added automatically so do not include them.", ParameterSetName = UrlRedirectActionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string CustomQueryString { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Fragment to add to the redirect URL. Fragment is the part of the URL that comes after #. Do not include the #.", ParameterSetName = UrlRedirectActionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string CustomFragment { get; set; }


        public override void ExecuteCmdlet()
        {
            PSDeliveryRuleAction deliveryRuleAction;
            if (ParameterSetName == CacheExpirationActionParameterSet)
            {
                deliveryRuleAction = new PSDeliveryRuleCacheExpirationAction
                {
                    Parameters = new PSCacheExpirationActionParameters
                    {
                        CacheBehavior = CacheBehavior,
                        CacheDuration = CacheDuration
                    }
                };
            }
            else if (ParameterSetName == HeaderActionParameterSet)
            {
                deliveryRuleAction = new PSDeliveryRuleHeaderAction
                {
                    HeaderActionType = HeaderActionType,
                    Action = Action,
                    HeaderName = HeaderName,
                    Value = Value
                };
            }
            else if (ParameterSetName == UrlRedirectActionParameterSet)
            {
                deliveryRuleAction = new PSDeliveryRuleUrlRedirectAction
                {
                   RedirectType = RedirectType,
                   DestinationProtocol = DestinationProtocol,
                   CustomPath = CustomPath,
                   CustomHostname = CustomHostname,
                   CustomQueryString = CustomQueryString,
                   CustomFragment = CustomFragment
                };
            }
            else
            {
                deliveryRuleAction = new PSDeliveryRuleAction();
            }
            WriteObject(deliveryRuleAction);
        }
    }
}
