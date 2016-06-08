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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSubscription", DefaultParameterSetName = ListByIdInTenantParameterSet),
        OutputType(typeof(PSAzureSubscription))]
    public class GetAzureRMSubscriptionCommand : AzureRMCmdlet
    {
        public const string ListByIdInTenantParameterSet = "ListByIdInTenant";
        public const string ListByNameInTenantParameterSet = "ListByNameInTenant";

        private RMProfileClient _client;

        [Parameter(ParameterSetName = ListByIdInTenantParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false)]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ListByNameInTenantParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false)]
        public string SubscriptionName { get; set; }

        [Parameter(ParameterSetName = ListByIdInTenantParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false)]
        [Parameter(ParameterSetName = ListByNameInTenantParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false)]
        public string TenantId { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            _client = new RMProfileClient(DefaultProfile);
            _client.WarningLog = (s) => WriteWarning(s);
        }

        public override void ExecuteCmdlet()
        {
            var tenant = TenantId;
            if (!string.IsNullOrWhiteSpace(this.SubscriptionName))
            {
                AzureSubscription result;
                try
                {
                    if (!this._client.TryGetSubscriptionByName(tenant, this.SubscriptionName, out result))
                    {
                        ThrowSubscriptionNotFoundError(this.TenantId, this.SubscriptionName);
                    }

                    WriteObject((PSAzureSubscription)result);
                }
                catch (AadAuthenticationException exception)
                {
                    ThrowTenantAuthenticationError(tenant, exception);
                    throw;
                }

            }
            else if (!string.IsNullOrWhiteSpace(this.SubscriptionId))
            {
                AzureSubscription result;
                try
                {
                    if (!this._client.TryGetSubscriptionById(tenant, this.SubscriptionId, out result))
                    {
                        ThrowSubscriptionNotFoundError(this.TenantId, this.SubscriptionId);
                    }

                    WriteObject((PSAzureSubscription)result);
                }
                catch (AadAuthenticationException exception)
                {
                    ThrowTenantAuthenticationError(tenant, exception);
                    throw;
                }

            }
            else
            {
                try
                {
                    var tenantsList = new List<string>();

                    if (string.IsNullOrWhiteSpace(tenant))
                    {
                        tenantsList.AddRange(_client.ListTenants()
                            .Select(t => (t.Id == Guid.Empty) ? t.Domain : t.Id.ToString()));
                    }
                    else
                    {
                        tenantsList.Add(tenant);
                    }

                    foreach (var tenantId in tenantsList)
                    {
                        try
                        {
                            string listNextLink = null;
                            do
                            {
                                var subscriptions = _client.ListSubscriptions(tenantId, ref listNextLink);
                                WriteObject(subscriptions.Select((s) => (PSAzureSubscription)s), enumerateCollection: true);
                            } while (listNextLink != null);
                        }
                        catch (AadAuthenticationException)
                        {
                            if (!string.IsNullOrWhiteSpace(tenant))
                            {
                                throw;
                            }
                            WriteWarning(string.Format(
                                Microsoft.Azure.Commands.Profile.Properties.Resources.UnableToLogin,
                                AzureRmProfileProvider.Instance.Profile.Context.Account,
                                tenant));
                        }
                    }
                }
                catch (AadAuthenticationException exception)
                {
                    ThrowTenantAuthenticationError(tenant, exception);
                    throw;
                }
            }
        }

        private void ThrowSubscriptionNotFoundError(string tenant, string subscription)
        {
            throw new PSArgumentException(string.Format(Resources.SubscriptionNotFoundError, subscription, tenant));
        }

        private void ThrowTenantAuthenticationError(string tenant, AadAuthenticationException exception)
        {
            throw new PSArgumentException(string.Format(Resources.TenantAuthFailed, tenant), exception);
        }
    }
}
