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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.SubscriptionDefinition.Common;
using Microsoft.Azure.Commands.SubscriptionDefinition.Models;
using Microsoft.Azure.Management.ResourceManager;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SubscriptionDefinition.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSubscriptionDefinition", DefaultParameterSetName = ParameterSetNames.BySubscription), OutputType(typeof(List<PSSubscriptionDefinition>))]
    public class GetAzureRmSubscriptionDefinition : AzureSubscriptionDefinitionCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroup, Mandatory = true, HelpMessage = "Id of the management group for which to retrieve subscription definitions.")]
        public Guid ManagementGroupId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByManagementGroup, Mandatory = false, HelpMessage = "Name of the subscription definition to retrieve.")]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.BySubscription, Mandatory = false, ValueFromPipeline = true)]
        public IAzureSubscription Subscription { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ManagementGroupId != Guid.Empty)
            {
                // Get subscription definition(s) in the specified management group.
                this.SubscriptionDefinitionClient.SetManagementGroupScope(this.ManagementGroupId, this.Name);
            }
            else if (this.Subscription != null)
            {
                // Get subscription definition for the specified subscription.
                this.SubscriptionDefinitionClient.SetSubscriptionScope(Guid.Parse(this.Subscription.Id));
            }
            else
            {
                // Get subscription definition for the subscription in the current context.
                this.SubscriptionDefinitionClient.SetSubscriptionScope(Guid.Parse(this.DefaultContext.Subscription.Id));
            }

            if (IsListOperation())
            {
                var subscriptionDefinitions = this.SubscriptionDefinitionClient.SubscriptionDefinitions.List();
                this.WriteSubscriptionDefinitionObjects(subscriptionDefinitions.Value);
            }
            else
            {
                this.WriteSubscriptionDefinitionObject(this.SubscriptionDefinitionClient.SubscriptionDefinitions.Get());
            }
        }

        private bool IsListOperation()
        {
            return this.ManagementGroupId != Guid.Empty && string.IsNullOrEmpty(this.Name);
        }
    }
}
