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
using Microsoft.Azure.Commands.SignalR.Properties;
using Microsoft.Azure.Management.SignalR;
using Microsoft.Rest;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    public abstract class SignalRCmdletBase : AzureRMCmdlet
    {
        protected const string SignalRNoun = "AzureRmSignalR";
        protected const string SignalRKeyNoun = "AzureRmSignalRKey";
        protected const string ResourceGroupParameterSet = "ResourceGroupParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string ListSignalRServiceParameterSet = "ListSignalRServiceParameterSet";
        protected const string InputObjectParameterSet = "InputObjectParameterSet";

        private ISignalRManagementClient _client;

        protected ISignalRManagementClient Client => _client ?? (_client = BuildClient<SignalRManagementClient>());

        /// <summary>
        /// Run Cmdlet with Error Handling (report error correctly)
        /// </summary>
        /// <param name="action">The actual Cmdlet action to be wrapped.</param>
        protected void RunCmdlet(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (Rest.Azure.CloudException ex)
            {
                throw new PSInvalidOperationException(ex.Body.Message, ex);
            }
        }

        private T BuildClient<T>(string endpoint = null, Func<T, T> postBuild = null) where T : ServiceClient<T>
        {
            var instance = AzureSession.Instance.ClientFactory.CreateArmClient<T>(
                DefaultProfile.DefaultContext, endpoint ?? AzureEnvironment.Endpoint.ResourceManager);
            return postBuild == null ? instance : postBuild(instance);
        }

        public abstract string ResourceGroupName { get; set; }

        /// <summary>
        /// Returns the default resource group set by Set-AzureRmDefault, if present.
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
    }
}
