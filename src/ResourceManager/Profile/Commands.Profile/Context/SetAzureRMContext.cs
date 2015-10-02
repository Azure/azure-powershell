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
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to change current Azure context. 
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRMContext", DefaultParameterSetName =TenantIdAndSubscriptionIdParameterSet)]
    [Alias("Select-AzureRmSubscription")]
    [OutputType(typeof(PSAzureContext))]
    public class SetAzureRMContextCommand : AzureRMCmdlet
    {
        private const string TenantIdParameterSet = "TenantId";
        private const string SubscriptionIdParameterSet = "Subscription";
        private const string TenantIdAndSubscriptionIdParameterSet = "TenantIdAndSubscriptionId";
        private const string ContextParameterSet = "Context";

        [Parameter(ParameterSetName = TenantIdParameterSet, Mandatory = false, HelpMessage = "TenantId name or ID", ValueFromPipelineByPropertyName=true)]
        [Parameter(ParameterSetName = TenantIdAndSubscriptionIdParameterSet, Mandatory = false, HelpMessage = "TenantId name or ID", ValueFromPipelineByPropertyName=true)]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }

        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = true, HelpMessage = "Subscription", ValueFromPipelineByPropertyName=true)]
        [Parameter(ParameterSetName = TenantIdAndSubscriptionIdParameterSet, Mandatory = true, HelpMessage = "Subscription", ValueFromPipelineByPropertyName=true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = SubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Subscription Name", ValueFromPipelineByPropertyName=true)]
        [Parameter(ParameterSetName = TenantIdAndSubscriptionIdParameterSet, Mandatory = false, HelpMessage = "Subscription Name", ValueFromPipelineByPropertyName=true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionName{ get; set; }
        
        [Parameter(ParameterSetName = ContextParameterSet, Mandatory = true, HelpMessage = "Context", ValueFromPipeline=true)]
        public PSAzureContext Context { get; set; }

        protected override void ProcessRecord()
        {
            if (ParameterSetName == ContextParameterSet)
            {
                AzureRmProfileProvider.Instance.Profile.Context = new AzureContext(Context.Subscription, Context.Account,
                    Context.Environment, Context.Tenant);
            }
            else
            {
                var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.Profile);
                profileClient.SetCurrentContext(SubscriptionId, TenantId);
                if (!string.IsNullOrWhiteSpace(SubscriptionName))
                {
                    AzureRmProfileProvider.Instance.Profile.Context.Subscription.Name = SubscriptionName;
                }
            }
            WriteObject((PSAzureContext)AzureRmProfileProvider.Instance.Profile.Context);
        }
    }
}
