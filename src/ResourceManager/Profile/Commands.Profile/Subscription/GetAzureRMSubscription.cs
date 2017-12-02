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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSubscription", DefaultParameterSetName = ListByIdInTenantParameterSet),
        OutputType(typeof(PSAzureSubscription))]
    public class GetAzureRMSubscriptionCommand : AzureRmLongRunningCmdlet
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
            var profile = DefaultProfile as AzureRmProfile;
            if (profile == null )
            {
                throw new InvalidOperationException(Resources.RmProfileNull);
            }

            if (DefaultContext == null || DefaultContext.Account == null)
            {
                throw new InvalidOperationException(Resources.ContextCannotBeNull);
            }

            _client = new RMProfileClient(profile);
            _client.WarningLog = (s) => WriteWarning(s);
        }

        public override void ExecuteCmdlet()
        {
            var tenant = TenantId;
            if (!string.IsNullOrWhiteSpace(this.SubscriptionName))
            {
                IAzureSubscription result;
                try
                {
                    if (!this._client.TryGetSubscriptionByName(tenant, this.SubscriptionName, out result))
                    {
                        ThrowSubscriptionNotFoundError(this.TenantId, this.SubscriptionName);
                    }

                    WriteObject(new PSAzureSubscription(result));
                }
                catch (AadAuthenticationException exception)
                {
                    ThrowTenantAuthenticationError(tenant, exception);
                    throw;
                }

            }
            else if (!string.IsNullOrWhiteSpace(this.SubscriptionId))
            {
                IAzureSubscription result;
                try
                {
                    if (!this._client.TryGetSubscriptionById(tenant, this.SubscriptionId, out result))
                    {
                        ThrowSubscriptionNotFoundError(this.TenantId, this.SubscriptionId);
                    }

                    WriteObject( new PSAzureSubscription(result));
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
                    var subscriptions = _client.ListSubscriptions(tenant);
                    WriteObject(subscriptions.Select((s) => new PSAzureSubscription(s)), enumerateCollection: true);
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
