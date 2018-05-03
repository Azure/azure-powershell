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

using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using AutoMapper;

    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;

    public class AzureRouteFilterRuleConfigBase: NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the route filter rule")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The access type of the rule. Possible values are: 'Allow', 'Deny'")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
           MNM.Access.Allow,
           MNM.Access.Deny,
           IgnoreCase = true)]
        public virtual string Access { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The route filter rule type of the rule. Possible values are: 'Community'")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            "Community",
            IgnoreCase = true)]
        public virtual string RouteFilterRuleType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The list of community value that route filter will filter on")]
        [ValidateNotNull]
        public virtual List<string> CommunityList { get; set; }

        public IRouteFilterRulesOperations RouteFilterRuleClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.RouteFilterRules;
            }
        }

        public bool IsRouteFilterRulePresent(PSRouteFilter filter, string name)
        {
            var rule = filter.Rules.SingleOrDefault(resource => string.Equals(resource.Name, name, System.StringComparison.CurrentCultureIgnoreCase));

            if (rule != null)
            {
                return true;
            }
            return false;
        }

        public bool IsRouteFilterRulePresent(string resourceGroupName, string filterName, string name)
        {
            try
            {
                this.GetRouteFilterRule(resourceGroupName, filterName, name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }

                throw;
            }

            return true;
        }

        public PSRouteFilterRule GetRouteFilterRule(string resourceGroupName, string filterName, string name)
        {
            var routeFilterRule = this.RouteFilterRuleClient.Get(resourceGroupName, filterName, name);

            var psRouteFilterRule = NetworkResourceManagerProfile.Mapper.Map<PSRouteFilterRule>(routeFilterRule);
            
            return psRouteFilterRule;
        }
    }
}
