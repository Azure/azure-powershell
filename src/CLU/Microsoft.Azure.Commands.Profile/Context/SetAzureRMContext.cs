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

using System.Collections.Generic;
using System.Management.Automation;
using System.Linq;
using Microsoft.Azure.Commands.Models;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Profile.Properties;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to change current Azure context. 
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmContext", DefaultParameterSetName = SubscriptionNameParameterSet)]
    [Alias("Select-AzureRmSubscription")]
    [OutputType(typeof(PSAzureContext))]
    [CliCommandAlias("context set")]
    [CliCommandAlias("subscription set")]
    public class SetAzureRMContextCommand : AzureRMCmdlet
    {
        private const string SubscriptionNameParameterSet = "SubscriptionName";
        private const string SubscriptionIdParameterSet = "SubscriptionId";
        private const string ContextParameterSet = "Context";

        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "TenantId name or ID", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "TenantId name or ID", ValueFromPipelineByPropertyName = true)]
        [Alias("Domain", "t")]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }
        
        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Subscription", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("s", "id")]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "Subscription Name", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("n", "name")]
        public string SubscriptionName { get; set; }

        [Parameter(ParameterSetName = ContextParameterSet, Mandatory = true, HelpMessage = "Context", ValueFromPipeline = true)]
        public PSAzureContext Context { get; set; }

        protected override void ProcessRecord()
        {
            if (ParameterSetName == ContextParameterSet)
            {
                DefaultProfile.SetContextWithCache(new AzureContext(Context.Subscription, Context.Account,
                    Context.Environment, Context.Tenant));
            }
            else if (ParameterSetName == SubscriptionNameParameterSet || ParameterSetName == SubscriptionIdParameterSet)
            {
                if (string.IsNullOrWhiteSpace(SubscriptionId) 
                    && string.IsNullOrWhiteSpace(SubscriptionName)
                    && string.IsNullOrWhiteSpace(TenantId))
                {
                    throw new PSInvalidOperationException(Resources.SetAzureRmContextNoParameterSet);
                }

                var profileClient = new RMProfileClient(AuthenticationFactory, ClientFactory, DefaultProfile);
                if (!string.IsNullOrWhiteSpace(SubscriptionId) || !string.IsNullOrWhiteSpace(SubscriptionName))
                {
                    profileClient.SetCurrentContext(SubscriptionId, SubscriptionName, TenantId);
                }
                else
                {
                    profileClient.SetCurrentContext(TenantId);
                }
            }
            WriteObject((PSAzureContext)DefaultContext);
        }
    }
}
