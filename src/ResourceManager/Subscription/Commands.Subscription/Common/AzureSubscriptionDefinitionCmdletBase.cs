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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Subscription.Models;
using Microsoft.Azure.Management.Subscription;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Subscription.Common
{
    /// <summary>
    /// Base class of Azure Subscription Definition Cmdlet.
    /// </summary>
    public abstract class AzureSubscriptionDefinitionCmdletBase : AzureRMCmdlet
    {
        private ISubscriptionDefinitionsClient _subscriptionDefinitionClient;

        /// <summary>
        /// Gets or sets the subscription definition management client.
        /// </summary>
        public ISubscriptionDefinitionsClient SubscriptionDefinitionsClient
        {
            get
            {
                return _subscriptionDefinitionClient ??
                       (_subscriptionDefinitionClient =
                           AzureSession.Instance.ClientFactory.CreateArmClient<SubscriptionDefinitionsClient>(DefaultContext,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _subscriptionDefinitionClient = value; }
        }

        protected void WriteSubscriptionDefinitionObject(Microsoft.Azure.Management.Subscription.Models.SubscriptionDefinition subscriptionDefinition)
        {
            this.WriteObject(new PSSubscriptionDefinition(subscriptionDefinition));
        }

        protected void WriteSubscriptionDefinitionObjects(IEnumerable<Microsoft.Azure.Management.Subscription.Models.SubscriptionDefinition> subscriptionDefinitions)
        {
            this.WriteObject(subscriptionDefinitions.Select(x => new PSSubscriptionDefinition(x)), enumerateCollection: true);
        }
    }
}
