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

using System;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.SignalR.Properties;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.SignalR;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    public abstract class SignalRCmdletBase : SignalRCmdletBottom
    {
        private IResourceManagementClient _resourceClient;

        protected IResourceManagementClient ResourceClient => _resourceClient ?? (_resourceClient = BuildClient<ResourceManagementClient>());

        public abstract string ResourceGroupName { get; set; }

        /// <summary>
        /// Returns the default resource group set by Set-AzDefault, if present.
        /// </summary>
        protected string DefaultResourceGroupName
        {
            get
            {
                IAzureContext context;
                TryGetDefaultContext(out context);
                return context?.GetProperty(Resources.DefaultResourceGroupKey);
            }
        }

        /// <summary>
        /// Use the DefaultResourceGroupName for ResourceGroupName if not specified, and optionally validate it.
        /// </summary>
        protected void ResolveResourceGroupName(bool required = true)
        {
            if (string.IsNullOrEmpty(ResourceGroupName))
            {
                ResourceGroupName = DefaultResourceGroupName;
            }
            if (required && string.IsNullOrEmpty(ResourceGroupName))
            {
                throw new ArgumentException("ResourceGroupName is not specified and the default value is not present.");
            }
        }

        protected string GetLocationFromResourceGroup()
        {
            return ResourceClient.ResourceGroups.Get(ResourceGroupName).Location;
        }
    }
}
