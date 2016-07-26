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

namespace Microsoft.Azure.Commands.Scheduler.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Management.Resources.Models;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Scheduler;

    /// <summary>
    /// Scheduler client class.
    /// </summary>
    public partial class SchedulerClient
    {
        /// <summary>
        /// Azure resource managment client.
        /// </summary>
        private ResourceManagementClient _resourceManagementClient;

        /// <summary>
        /// Scheduler available regions.
        /// </summary>
        private IList<string> _availableRegions;

        /// <summary>
        /// Gets or sets Scheduler client instance.
        /// </summary>
        public ISchedulerManagementClient SchedulerManagementClient { get; set; }

        /// <summary>
        /// Gets available regions for Scheduler.
        /// </summary>
        public IList<string> AvailableRegions
        {
            get
            {
                return _availableRegions;
            }
        }

        /// <summary>
        /// Initializes new instance of the <see cref="SchedulerClient"/> class.
        /// </summary>
        /// <param name="context">The Azure context reference.</param>
        public SchedulerClient(AzureContext context)
        {
            this.SchedulerManagementClient = AzureSession.ClientFactory.CreateArmClient<SchedulerManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
            this._resourceManagementClient = AzureSession.ClientFactory.CreateClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);

            ProviderResourceType providerResourceType= _resourceManagementClient.Providers.Get(Constants.ProviderNamespace).Provider.ResourceTypes.First((resourceType) => resourceType.Name.Equals(Constants.ResourceType, StringComparison.InvariantCultureIgnoreCase));

            _availableRegions = providerResourceType != null ? providerResourceType.Locations : null;

            this.SchedulerManagementClient.SubscriptionId = context.Subscription.Id.ToString();
        }

        /// <summary>
        /// Check whether resource group exists.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <returns>true if resource group exists, false otherwise</returns>
        internal bool DoesResourceGroupExists(string resourceGroupName)
        {
            return this._resourceManagementClient.ResourceGroups.CheckExistence(resourceGroupName).Exists;
        }
    }
}
