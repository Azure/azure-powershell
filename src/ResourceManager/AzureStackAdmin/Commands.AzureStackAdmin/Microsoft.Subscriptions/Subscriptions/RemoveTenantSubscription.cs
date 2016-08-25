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
    using Microsoft.Azure;
    using Microsoft.AzureStack.Management;
    using Microsoft.WindowsAzure.Commands.Common;
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Subscription Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, Nouns.TenantSubscription)]
    [OutputType(typeof(AzureOperationResponse))]
    public class RemoveTenantSubscription : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the subscription ID to be deleted.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateGuidNotEmpty]
        public Guid TargetSubscriptionId { get; set; }

        /// <summary>
        /// Performs the API operation(s) against tenant subscriptions.
        /// </summary>
        protected override object ExecuteCore()
        {
            using (var client = this.GetAzureStackClient())
            {
                this.WriteVerbose(Resources.DeletingSubscription.FormatArgs(this.TargetSubscriptionId));
                return client.Subscriptions.Delete(this.TargetSubscriptionId.ToString());
            }
        }
    }
}
