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

using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Subscription", DefaultParameterSetName = ListByIdInTenantParameterSet),OutputType(typeof(PSAzureSubscription))]
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
            if (!string.IsNullOrWhiteSpace(this.SubscriptionName))
            {
                IEnumerable<IAzureSubscription> result;
                try
                {
                    if (!this._client.TryGetSubscriptionListByName(TenantId, this.SubscriptionName, out result))
                    {
                        ThrowSubscriptionNotFoundError(this.TenantId, this.SubscriptionName);
                    }
                    WriteSubscriptions(result);
                }
                catch (AadAuthenticationException exception)
                {
                    ThrowTenantAuthenticationError(TenantId, exception);
                    throw;
                }

            }
            else if (!string.IsNullOrWhiteSpace(this.SubscriptionId))
            {
                IEnumerable<IAzureSubscription> result = null;
                try
                {
                    result = this._client.TryGetSubscriptionById(TenantId, this.SubscriptionId);
                    if (result == null || result.Count() == 0)
                    {
                        ThrowSubscriptionNotFoundError(this.TenantId, this.SubscriptionId);
                    }
                    WriteObject(new PSAzureSubscription(result.FirstOrDefault()));
                }
                catch (AadAuthenticationException exception)
                {
                    ThrowTenantAuthenticationError(TenantId, exception);
                    throw;
                }

            }
            else
            {
                try
                {
                    if (DefaultContext.Account.Type.Equals("ManagedService"))
                    {
                        if (TenantId == null)
                        {
                            TenantId = DefaultContext.Tenant.Id;
                        }

                        if (TenantId.Equals(DefaultContext.Tenant.Id))
                        {
                            var subscriptions = _client.ListSubscriptions(TenantId);
                            WriteSubscriptions(subscriptions);
                        }
                    }
                    else
                    {
                        var subscriptions = _client.ListSubscriptions(TenantId);
                        WriteSubscriptions(subscriptions);
                    }
                }
                catch (AadAuthenticationException exception)
                {
                    ThrowTenantAuthenticationError(TenantId, exception);
                    throw;
                }
            }
        }

        private void ThrowSubscriptionNotFoundError(string tenant, string subscription)
        {
            PSArgumentException exception = new PSArgumentException(string.Format(Resources.SubscriptionNotFoundError, subscription, tenant));
            exception.Data[AzurePSErrorDataKeys.ErrorKindKey] = ErrorKind.UserError;
            throw exception;
        }

        private void ThrowTenantAuthenticationError(string tenant, AadAuthenticationException exception)
        {
            throw new PSArgumentException(string.Format(Resources.TenantAuthFailed, tenant), exception);
        }

        private void WriteSubscriptions(IEnumerable<IAzureSubscription> subscriptions)
        {
            if (null != subscriptions && subscriptions.Any())
            {
                WriteObject(subscriptions.Select((s) => new PSAzureSubscription(s)).OrderBy(s => s.TenantId).ThenBy(s=>s.Name), enumerateCollection: true);
            }
        }
    }
}
