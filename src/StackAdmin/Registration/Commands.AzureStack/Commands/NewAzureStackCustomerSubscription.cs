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

namespace Microsoft.Azure.Commands.AzureStack
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.AzureStack.Models;
    using Microsoft.Azure.Commands.AzureStack.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("New", AzureStackClient.CustomerSubscriptionsCmdletName, SupportsShouldProcess = true), OutputType(typeof(CustomerSubscriptionResult))]
    public class NewAzureStackCustomerSubscription : AzureStackCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group where Azure Stack registration is created.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of Azure Stack registration.")]
        [ValidateNotNullOrEmpty]
        public string RegistrationName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of Azure Stack customer subscription.")]
        [ValidateNotNullOrEmpty]
        public string CustomerSubscriptionName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Azure Stack tenant ID.")]
        [ValidateNotNullOrEmpty]
        public string TenantId { get; set; }

        public override void ExecuteCmdlet()
        {
            ValidateResourceGroupName(this.ResourceGroupName);
            ValidateResourceName(this.RegistrationName);

            ConfirmAction(
              string.Format(Resources.CreateCustomerSubscription, this.CustomerSubscriptionName),
              this.CustomerSubscriptionName,
              () =>
              {
                  var subscription = AzsClient.CreateCustomerSubscription(this.ResourceGroupName, this.RegistrationName, this.CustomerSubscriptionName, this.TenantId);
                  WriteObject(new CustomerSubscriptionResult(subscription));
              });
        }
    }
}