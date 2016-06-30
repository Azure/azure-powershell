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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to change current Azure context.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmContext", DefaultParameterSetName = SubscriptionNameParameterSet, 
        SupportsShouldProcess=true)]
    [Alias("Select-AzureRmSubscription")]
    [OutputType(typeof(PSAzureContext))]
    public class SetAzureRMContextCommand : AzureRMCmdlet, IDynamicParameters
    {
        private const string SubscriptionNameParameterSet = "SubscriptionName";
        private const string SubscriptionIdParameterSet = "SubscriptionId";
        private const string ContextParameterSet = "Context";
        private RuntimeDefinedParameter _tenantId;
        private RuntimeDefinedParameter _subscriptionId;

        [Parameter(ParameterSetName = SubscriptionNameParameterSet, Mandatory = false, HelpMessage = "Subscription Name", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionName { get; set; }

        [Parameter(ParameterSetName = ContextParameterSet, Mandatory = true, HelpMessage = "Context", ValueFromPipeline = true)]
        public PSAzureContext Context { get; set; }

        private string TenantId
        {
            get
            {
                return _tenantId == null ? null : (string)_tenantId.Value;
            }
        }

        private string SubscriptionId
        {
            get
            {
                return _subscriptionId == null ? null : (string)_subscriptionId.Value;
            }
        }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ContextParameterSet)
            {
                if (ShouldProcess(string.Format(Resources.ChangingContextUsingPipeline, Context.Tenant, Context.Subscription), 
                    Resources.ContextChangeWarning, string.Empty))
                {
                    AzureRmProfileProvider.Instance.Profile.SetContextWithCache(new AzureContext(Context.Subscription,
                        Context.Account,
                        Context.Environment, Context.Tenant));
                    CompleteContextProcessing();
                }
            }
            else if (ParameterSetName == SubscriptionNameParameterSet || ParameterSetName == SubscriptionIdParameterSet)
            {
                if (string.IsNullOrWhiteSpace(SubscriptionId)
                    && string.IsNullOrWhiteSpace(SubscriptionName)
                    && string.IsNullOrWhiteSpace(TenantId))
                {
                    throw new PSInvalidOperationException(Resources.SetAzureRmContextNoParameterSet);
                }

                    var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.Profile);
                    if (!string.IsNullOrWhiteSpace(SubscriptionId) || !string.IsNullOrWhiteSpace(SubscriptionName))
                    {
                        if (ShouldProcess(string.Format(Resources.ChangingContextSubscription, 
                            SubscriptionName ?? SubscriptionId), 
                            Resources.SubscriptionChangeWarning , string.Empty))
                        {
                            profileClient.SetCurrentContext(SubscriptionId, SubscriptionName, TenantId);
                            CompleteContextProcessing();
                        }
                    }
                    else
                    {
                        if (ShouldProcess(string.Format(Resources.ChangingContextTenant, TenantId),
                            Resources.TenantChangeWarning, string.Empty))
                        {
                            profileClient.SetCurrentContext(TenantId);
                            CompleteContextProcessing();
                        }
                    }
            }
            else
            {
                CompleteContextProcessing();
            }

        }

        private void CompleteContextProcessing()
        {
            if (AzureRmProfileProvider.Instance.Profile.Context != null &&
                AzureRmProfileProvider.Instance.Profile.Context.Subscription != null &&
                AzureRmProfileProvider.Instance.Profile.Context.Subscription.State != null &&
                !AzureRmProfileProvider.Instance.Profile.Context.Subscription.State.Equals(
                "Enabled",
                StringComparison.OrdinalIgnoreCase))
            {
                WriteWarning(string.Format(
                               Microsoft.Azure.Commands.Profile.Properties.Resources.SelectedSubscriptionNotActive,
                               AzureRmProfileProvider.Instance.Profile.Context.Subscription.State));
            }
            WriteObject((PSAzureContext)AzureRmProfileProvider.Instance.Profile.Context);
        }

        public object GetDynamicParameters()
        {
            return CreateDynamicParameterDictionary();
        }

        private RuntimeDefinedParameterDictionary CreateDynamicParameterDictionary()
        {
            var runtimeDefinedParameterDictionary = new RuntimeDefinedParameterDictionary();

            var subscriptionIdAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    ParameterSetName = SubscriptionIdParameterSet,
                    Mandatory = false,
                    HelpMessage = "Subscription",
                    ValueFromPipelineByPropertyName = true
                }
            };

            var tenantIdAttributes = new Collection<Attribute>
            {
                new ParameterAttribute
                {
                    ParameterSetName = SubscriptionNameParameterSet,
                    Mandatory = false,
                    HelpMessage = "Tenant name or ID",
                    ValueFromPipelineByPropertyName = true
                },
                new ParameterAttribute
                {
                    ParameterSetName = SubscriptionIdParameterSet,
                    Mandatory = false,
                    HelpMessage = "Tenant name or ID",
                    ValueFromPipelineByPropertyName = true
                },
                new AliasAttribute("Domain")
            };

            if (AzureRmProfileProvider.Instance != null
                && AzureRmProfileProvider.Instance.Profile != null
                && AzureRmProfileProvider.Instance.Profile.Context != null
                && AzureRmProfileProvider.Instance.Profile.Context.Account != null)
            {
                var account = AzureRmProfileProvider.Instance.Profile.Context.Account;
                if (account.IsPropertySet(AzureAccount.Property.Subscriptions))
                {
                    var subscriptions = account.GetPropertyAsArray(AzureAccount.Property.Subscriptions);
                    if (subscriptions != null && subscriptions.Length > 0)
                    {
                        subscriptionIdAttributes.Add(
                            new ValidateSetAttribute(subscriptions));
                    }
                }
                if (account.IsPropertySet(AzureAccount.Property.Tenants))
                {
                    var tenants = account.GetPropertyAsArray(AzureAccount.Property.Tenants);
                    if (tenants != null && tenants.Length > 0)
                    {
                        tenantIdAttributes.Add(
                            new ValidateSetAttribute(tenants));
                    }
                }
            }

            _tenantId = new RuntimeDefinedParameter("TenantId", typeof(string), tenantIdAttributes);
            _subscriptionId = new RuntimeDefinedParameter("SubscriptionId", typeof(string), subscriptionIdAttributes);

            runtimeDefinedParameterDictionary.Add("SubscriptionId", _subscriptionId);
            runtimeDefinedParameterDictionary.Add("TenantId", _tenantId);

            return runtimeDefinedParameterDictionary;
        }
    }
}
