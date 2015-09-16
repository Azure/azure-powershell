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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Hyak.Common;
using Microsoft.Azure.Common.Authentication.Factories;
using Microsoft.Azure.Subscriptions;

namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet(VerbsCommon.Get, "AzureRMSubscription", DefaultParameterSetName = ListInTenantParameterSet), 
        OutputType(typeof(AzureSubscription))]
    public class GetAzureRMSubscriptionCommand : AzureRMCmdlet
    {
        public const string ListInTenantParameterSet = "ListInTenant";
        public const string ListAllParameterSet = "ListAll";

        private RMProfileClient _client;

        [Parameter(ParameterSetName= ListInTenantParameterSet, ValueFromPipelineByPropertyName = true, Mandatory=false)]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ListInTenantParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false)]
        public string Tenant { get; set; }

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
                    WriteObject(_client.ListSubscriptions());
                }
                catch (AadAuthenticationException)
                {
                    WriteErrorWithTimestamp(string.Format("Could not authenticate your user account {0} with the common tenant.  " +
                       "Please login again using Login-AzureRMAccount.", DefaultContext.Account));
                    throw;
                }
            }
            else if (!string.IsNullOrWhiteSpace(this.SubscriptionId))
            {
                AzureSubscription result;
                if (!this._client.TryGetSubscription(this.Tenant, this.SubscriptionId, out result))
                {
                    WriteSubscriptionNotFoundError(this.Tenant, this.SubscriptionId);
                }

                WriteObject( result);
            }
            else
            {
                var tenant = this.Tenant;
                if (string.IsNullOrWhiteSpace(tenant))
                {
                    if (DefaultContext.Tenant != null && DefaultContext.Tenant.Id != null)
                    {
                        tenant = DefaultContext.Tenant.Id.ToString();
                    }
                    else
                    {
                        throw new PSArgumentException(
                            "No tenant Id was provided.  Please log in using Login-AzureRMAcount, or provide a tenant in the 'Tenant' parameter.");
                    }
                }

                WriteObject(_client.ListSubscriptions(tenant));
            }
        }

        private void WriteSubscriptionNotFoundError(string subscription, string tenant)
        {
            throw new PSArgumentException(string.Format("Subscription {0} was not found in tenant {1}.  " +
                   "Please verify that the subscription exists in this tenant.", subscription, tenant));
        }
    }
}
