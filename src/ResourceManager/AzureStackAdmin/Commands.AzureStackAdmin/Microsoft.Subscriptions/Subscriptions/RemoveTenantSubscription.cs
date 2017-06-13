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
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// Subscription Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, Nouns.TenantSubscription, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureOperationResponse))]
    [Alias("Remove-AzureRmManagedSubscription")]
    public class RemoveTenantSubscription : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the subscription ID to be deleted.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateGuidNotEmpty]
        [Alias("TargetSubscriptionId")]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Performs the API operation(s) against subscriptions as administrator.
        /// </summary>
        protected override void ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("Remove-AzureRmManagedSubscription", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias Remove-AzureRmManagedSubscription will be deprecated in a future release. Please use the cmdlet name Remove-AzsTenantSubscription instead");
            }

            if (ShouldProcess(this.SubscriptionId.ToString(), VerbsCommon.Remove))
            {
                using (var client = this.GetAzureStackClient())
                {
                    this.WriteVerbose(Resources.DeletingSubscription.FormatArgs(this.SubscriptionId));
                    var result = client.TenantSubscriptions.Delete(this.SubscriptionId.ToString());
                    WriteObject(result);
                }
            }
        }
    }
}
