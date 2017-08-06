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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to change current Azure context.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmContext", DefaultParameterSetName = SubscriptionParameterSet,
        SupportsShouldProcess = true)]
    [Alias("Select-AzureRmSubscription")]
    [OutputType(typeof(PSAzureContext))]
    public class SetAzureRMContextCommand : AzureContextModificationCmdlet
    {
        private const string SubscriptionParameterSet = "Subscription";
        private const string TenantOnlyParameterSet = "Tenant";
        private const string ContextParameterSet = "Context";

        [Parameter(ParameterSetName = ContextParameterSet, Mandatory = true, HelpMessage = "Context", ValueFromPipeline = true)]
        public PSAzureContext Context { get; set; }

        [Parameter(ParameterSetName = SubscriptionParameterSet, Mandatory = false,
                    HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = TenantOnlyParameterSet, Mandatory = true,
                    HelpMessage = "Tenant name or ID")]
        [Alias("Domain", "TenantId")]
        [ValidateNotNullOrEmpty]
        public string Tenant { get; set; }

        [Parameter(ParameterSetName = SubscriptionParameterSet, Mandatory = true,
                    HelpMessage = "Subscription Name or Id")]
        [Alias("SubscriptionId", "SubscriptionName")]
        [ValidateNotNullOrEmpty]
        public string Subscription { get; set; }

        [Parameter(Mandatory =false, HelpMessage ="Additional context properties")]
        public IDictionary<string, string> ExtendedProperty { get; set;}

        [Parameter(Mandatory = false, HelpMessage = "Name of the context")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ContextParameterSet)
            {
                if (ShouldProcess(string.Format(Resources.ChangingContextUsingPipeline, Context.Tenant, Context.Subscription),
                    Resources.ContextChangeWarning, string.Empty))
                {
                    ModifyContext((profile, client) =>
                        {
                            AzureRmProfileProvider.Instance.Profile.SetContextWithCache(new AzureContext(Context.Subscription,
                              Context.Account,
                              Context.Environment, Context.Tenant));
                            CompleteContextProcessing(profile);
                        });
                }
            }
            else if (ParameterSetName == TenantOnlyParameterSet)
            {
                if (ShouldProcess(string.Format(Resources.ChangingContextTenant, Tenant),
                    Resources.TenantChangeWarning, string.Empty))
                {
                    ModifyContext((profile, client) =>
                    {
                        client.SetCurrentContext(null, Tenant);
                        CompleteContextProcessing(profile);
                    });
                }
            }
            else if (ParameterSetName == SubscriptionParameterSet)
            {
                if (ShouldProcess(string.Format(Resources.ChangingContextSubscription, Subscription),
                        Resources.SubscriptionChangeWarning, string.Empty))
                {
                    ModifyContext((profile, client) =>
                    {
                        client.SetCurrentContext(Subscription, Tenant);
                        CompleteContextProcessing(profile);
                    });
                }
            }
            else
            {
                ModifyContext((profile, client) =>
                {
                    CompleteContextProcessing(profile);
                });
            }
        }

        private void CompleteContextProcessing(IProfileOperations profile)
        {
            var context = profile.DefaultContext;
            if (context != null &&
                context.Subscription != null &&
                context.Subscription.State != null &&
                !context.Subscription.State.Equals(
                "Enabled",
                StringComparison.OrdinalIgnoreCase))
            {
                WriteWarning(string.Format(
                              Resources.SelectedSubscriptionNotActive,
                               context.Subscription.State));
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(ExtendedProperty)))
            {
                foreach (var property in ExtendedProperty)
                {
                    if (ShouldProcess(string.Format("Context '{0}'", Name??"default"), string.Format("Setting property '{0}'='{1}' ", property.Key, property.Value)))
                    {
                        context.SetProperty(property.Key, property.Value);
                    }
                }
            }

            WriteObject(new PSAzureContext(context));
        }
    }
}
