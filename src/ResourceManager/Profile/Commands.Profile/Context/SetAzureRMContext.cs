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
using Microsoft.Azure.Commands.Common.Authentication.Models;
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
    [Cmdlet(VerbsCommon.Set, "AzureRmContext", DefaultParameterSetName = ContextParameterSet,
        SupportsShouldProcess = true)]
    [Alias("Select-AzureRmSubscription")]
    [OutputType(typeof(PSAzureContext))]
    public class SetAzureRMContextCommand : AzureContextModificationCmdlet
    {
        private const string SubscriptionParameterSet = "Subscription";
        private const string ContextParameterSet = "Context";
        private const string SubscriptionObjectParameterSet = "SubscriptionObject";
        private const string TenantObjectParameterSet = "TenantObject";
        private const string TenantNameParameterSet = "TenantNameOnly";


        [Parameter(ParameterSetName = ContextParameterSet, Mandatory = true, HelpMessage = "Context", ValueFromPipeline = true, Position = 0)]
        public PSAzureContext Context { get; set; }

        [Parameter(ParameterSetName = TenantObjectParameterSet, Mandatory = true, HelpMessage = "A Tenant Object", ValueFromPipeline = true, Position = 0)]
        public PSAzureTenant TenantObject { get; set; }

        [Parameter(ParameterSetName = SubscriptionObjectParameterSet, Mandatory = true, HelpMessage = "A subscription object", ValueFromPipeline = true, Position = 0)]
        public PSAzureSubscription SubscriptionObject { get; set; }

        [Parameter(ParameterSetName = SubscriptionParameterSet, Mandatory = false,
                    HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = TenantNameParameterSet, Mandatory = true,
                    HelpMessage = "Tenant name or ID")]
        [Alias("Domain", "TenantId")]
        [ValidateNotNullOrEmpty]
        public string Tenant { get; set; }

        [Parameter(ParameterSetName = SubscriptionParameterSet, Mandatory = true,
                    HelpMessage = "Subscription Name or Id", Position = 0)]
        [Alias("SubscriptionId", "SubscriptionName")]
        [ValidateNotNullOrEmpty]
        public string Subscription { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Additional context properties")]
        public IDictionary<string, string> ExtendedProperty { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the context")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Overwrite the existing context with the same name, if any.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ContextParameterSet)
            {
                if (ShouldProcess(string.Format(Resources.ChangingContextUsingPipeline, Context.Tenant, Context.Subscription),
                    Resources.ContextChangeWarning, string.Empty))
                {
                    SetContextWithOverwritePrompt((profile, client, name) =>
                        {
                            profile.SetContextWithCache(new AzureContext(Context.Subscription,
                              Context.Account,
                              Context.Environment, Context.Tenant), name);
                            CompleteContextProcessing(profile);
                        });
                }
            }
            else if (TenantOnlyParameters())
            {
                var tenantId = Tenant ?? TenantObject?.Directory;
                if (string.IsNullOrWhiteSpace(tenantId))
                {
                    throw new ArgumentException("You must supply a valid tenant object with a valid Id or a valid tenant id string. Please check the input tenant value and try again.");
                }
                if (DefaultContext != null && ShouldProcess(string.Format(Resources.ChangingContextTenant, tenantId),
                    Resources.TenantChangeWarning, string.Empty))
                {
                    SetContextWithOverwritePrompt((profile, client, name) =>
                    {
                        client.SetCurrentContext(null, tenantId, name);
                        CompleteContextProcessing(profile);
                    });
                }
            }
            else
            {
                var tenantId = Tenant ?? TenantObject?.Directory;
                var subscriptionId = Subscription ?? SubscriptionObject?.Id ?? SubscriptionObject?.Name;
                if (DefaultContext != null && !string.IsNullOrWhiteSpace(subscriptionId))
                {
                    if (ShouldProcess(string.Format(Resources.ChangingContextSubscription, subscriptionId),
                           Resources.SubscriptionChangeWarning, string.Empty))
                    {
                        SetContextWithOverwritePrompt((profile, client, name) =>
                        {
                            client.SetCurrentContext(subscriptionId, tenantId, name);
                            CompleteContextProcessing(profile);
                        });
                    }
                }
                else
                {
                    ModifyContext((profile, client) => CompleteContextProcessing(profile));
                }
            }
        }

        bool TenantOnlyParameters()
        {
            return ParameterSetName == TenantObjectParameterSet
                || ParameterSetName == TenantNameParameterSet;
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

            if (context != null)
            {
                if (MyInvocation.BoundParameters.ContainsKey(nameof(ExtendedProperty)))
                {
                    foreach (var property in ExtendedProperty)
                    {
                        if (ShouldProcess(string.Format(Resources.ContextNameTarget, Name ?? "default"),
                            string.Format(Resources.SetPropertyAction, property.Key, property.Value)))
                        {
                            context.SetProperty(property.Key, property.Value);
                        }
                    }
                }

                var psContext = new PSAzureContext(context);
                string name = Name;
                if (string.IsNullOrWhiteSpace(name))
                {
                    profile.TryFindContext(context, out name);
                }

                psContext.Name = name;
                WriteObject(psContext);
            }
        }

        bool CheckForExistingContext(AzureRmProfile profile, string name)
        {
            return name != null && profile != null && profile.Contexts != null && profile.Contexts.ContainsKey(name);
        }

        void SetContextWithOverwritePrompt(Action<AzureRmProfile, RMProfileClient, string> setContextAction)
        {
            string name = null;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
            {
                name = Name;
            }

            AzureRmProfile profile = DefaultProfile as AzureRmProfile;
            if (!CheckForExistingContext(profile, name)
                || Force.IsPresent
                || ShouldContinue(string.Format(Resources.ReplaceContextQuery, name),
                string.Format(Resources.ReplaceContextCaption, name)))
            {
                ModifyContext((prof, client) => setContextAction(prof, client, name));
            }
        }
    }
}
