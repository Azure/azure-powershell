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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;

namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSubscription", DefaultParameterSetName = ListByIdInTenantParameterSet), 
        OutputType(typeof(PSAzureSubscription))]
    public class GetAzureRMSubscriptionCommand : AzureRMCmdlet
    {
        public const string ListByIdInTenantParameterSet = "ListByIdInTenant";
        public const string ListByNameInTenantParameterSet = "ListByNameInTenant";
        public const string ListAllParameterSet = "ListAll";

        private RMProfileClient _client;

        [Parameter(ParameterSetName= ListByIdInTenantParameterSet, ValueFromPipelineByPropertyName = true, Mandatory=false)]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ListByNameInTenantParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false)]
        public string SubscriptionName { get; set; }

        [Parameter(ParameterSetName = ListByIdInTenantParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false)]
        [Parameter(ParameterSetName = ListByNameInTenantParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false)]
        public string TenantId { get; set; }

        [Parameter(ParameterSetName = ListAllParameterSet, Mandatory = true)]
        public SwitchParameter All { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            _client = new RMProfileClient(DefaultProfile);
            _client.WarningLog = (s) => WriteWarning(s);
        }

        protected override void ProcessRecord()
        {
            if (this.ParameterSetName == ListAllParameterSet)
            { 
                try
                {
                    WriteObject(_client.ListSubscriptions().Select((s) => (PSAzureSubscription)(s)), enumerateCollection: true);
                }
                catch (AadAuthenticationException exception)
                {
                    var account = DefaultContext.Account == null || DefaultContext.Account.Id == null
                        ? Resources.NoAccountProvided
                        : DefaultContext.Account.Id;
                    throw new PSInvalidOperationException(string.Format(Resources.CommonTenantAuthFailed, account), exception);
                }
            }
            else if (!string.IsNullOrWhiteSpace(this.SubscriptionName))
            {
                var tenant = EnsureValidTenant();
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
                var tenant = EnsureValidTenant();
                AzureSubscription result;
                try
                {
                    if (!this._client.TryGetSubscription(tenant, this.SubscriptionId, out result))
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
                var tenant = EnsureValidTenant();
                try
                {
                    WriteObject(_client.ListSubscriptions(tenant).Select((s) => (PSAzureSubscription)s), enumerateCollection: true);
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

        private string EnsureValidTenant()
        {
            var tenant = this.TenantId;
            if (string.IsNullOrWhiteSpace(tenant) && (DefaultContext.Tenant == null ||
                DefaultContext.Tenant.Id == null))
            {
                throw new PSArgumentException(Resources.NoValidTenant);
            }

            return tenant ?? DefaultContext.Tenant.Id.ToString();
        }
    }
}
