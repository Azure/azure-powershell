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

namespace Microsoft.AzureStack.Commands
{
    using System;
    using System.Management.Automation;
    using System.Runtime.InteropServices.ComTypes;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// Set Managed Subscription Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, Nouns.UserSubscription, SupportsShouldProcess = true)]
    [OutputType(typeof(SubscriptionDefinition))]
    [Alias("Set-AzureRmManagedSubscription", "Set-AzsTenantSubscription")]
    public class SetUserSubscription : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the subscription to be updated.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public AdminSubscriptionDefinition Subscription { get; set; }

        /// <summary>
        /// Performs the API operation(s) against subscriptions as administrator.
        /// </summary>
        protected override void ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("Set-AzureRmManagedSubscription", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias Set-AzureRmManagedSubscription will be deprecated in a future release. Please use the cmdlet name Set-AzsUserSubscription instead");
            }

            if (this.MyInvocation.InvocationName.Equals("Set-AzsTenantSubscription", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias Set-AzsTenantSubscription will be deprecated in a future release. Please use the cmdlet name Set-AzsUserSubscription instead");
            }

            if (ShouldProcess(this.Subscription.SubscriptionId, VerbsCommon.Set))
            {
                using (var client = this.GetAzureStackClient())
                {
                    this.WriteVerbose(
                        Resources.UpdatingManagedSubscription.FormatArgs(
                            this.Subscription.SubscriptionId));

                    var parameters = new SubscriptionCreateOrUpdateAsAdminParameters(this.Subscription);
                    var result = client.TenantSubscriptions.CreateOrUpdate(parameters).Subscription;
                }
            }
        }
    }
}
