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

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Resources;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// ComputeClient for the new Azure.ResourceManager.Compute SDK (Track 2)
    /// </summary>
    public class ComputeClientTrack2
    {
        private readonly ArmClient _armClient;
        private readonly string _subscriptionId;

        /// <summary>
        /// Gets the ARM client for accessing Azure Resource Manager resources
        /// </summary>
        public ArmClient ArmClient => _armClient;

        /// <summary>
        /// Gets the subscription ID
        /// </summary>
        public string SubscriptionId => _subscriptionId;

        /// <summary>
        /// Gets the subscription resource
        /// </summary>
        public SubscriptionResource SubscriptionResource => _armClient.GetSubscriptionResource(
            new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));

        /// <summary>
        /// Logger for verbose output
        /// </summary>
        public Action<string> VerboseLogger { get; set; }

        /// <summary>
        /// Logger for error output
        /// </summary>
        public Action<string> ErrorLogger { get; set; }

        /// <summary>
        /// Initializes a new instance of ComputeClientTrack2 using Azure context
        /// </summary>
        /// <param name="context">Azure context containing authentication and subscription information</param>
        public ComputeClientTrack2(IAzureContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Subscription == null)
            {
                throw new ArgumentException("Context must contain a valid subscription", nameof(context));
            }

            _subscriptionId = context.Subscription.Id;

            // Create credential from the context
            TokenCredential credential = CreateCredentialFromContext(context);

            // Initialize the ARM client
            var armClientOptions = new ArmClientOptions();
            _armClient = new ArmClient(credential, _subscriptionId, armClientOptions);
        }

        /// <summary>
        /// Initializes a new instance of ComputeClientTrack2 with an existing ArmClient
        /// </summary>
        /// <param name="armClient">The ARM client to use</param>
        /// <param name="subscriptionId">The subscription ID</param>
        public ComputeClientTrack2(ArmClient armClient, string subscriptionId)
        {
            _armClient = armClient ?? throw new ArgumentNullException(nameof(armClient));
            _subscriptionId = subscriptionId ?? throw new ArgumentNullException(nameof(subscriptionId));
        }

        /// <summary>
        /// Gets a resource group resource
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The resource group resource</returns>
        public async Task<ResourceGroupResource> GetResourceGroupAsync(
            string resourceGroupName, 
            CancellationToken cancellationToken = default)
        {
            LogVerbose($"Getting resource group: {resourceGroupName}");
            
            try
            {
                var response = await SubscriptionResource.GetResourceGroupAsync(
                    resourceGroupName, 
                    cancellationToken);
                return response.Value;
            }
            catch (Exception ex)
            {
                LogError($"Failed to get resource group {resourceGroupName}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets a resource group resource synchronously
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <returns>The resource group resource</returns>
        public ResourceGroupResource GetResourceGroup(string resourceGroupName)
        {
            return GetResourceGroupAsync(resourceGroupName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a virtual machine resource
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="vmName">The virtual machine name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The virtual machine resource</returns>
        public async Task<VirtualMachineResource> GetVirtualMachineAsync(
            string resourceGroupName,
            string vmName,
            CancellationToken cancellationToken = default)
        {
            LogVerbose($"Getting virtual machine: {vmName} in resource group: {resourceGroupName}");
            
            try
            {
                var resourceGroup = await GetResourceGroupAsync(resourceGroupName, cancellationToken);
                var response = await resourceGroup.GetVirtualMachineAsync(vmName, cancellationToken:cancellationToken);
                return response.Value;
            }
            catch (Exception ex)
            {
                LogError($"Failed to get virtual machine {vmName}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets a virtual machine resource synchronously
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="vmName">The virtual machine name</param>
        /// <returns>The virtual machine resource</returns>
        public VirtualMachineResource GetVirtualMachine(string resourceGroupName, string vmName)
        {
            return GetVirtualMachineAsync(resourceGroupName, vmName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets an availability set resource
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="availabilitySetName">The availability set name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The availability set resource</returns>
        public async Task<AvailabilitySetResource> GetAvailabilitySetAsync(
            string resourceGroupName,
            string availabilitySetName,
            CancellationToken cancellationToken = default)
        {
            LogVerbose($"Getting availability set: {availabilitySetName} in resource group: {resourceGroupName}");
            
            try
            {
                var resourceGroup = await GetResourceGroupAsync(resourceGroupName, cancellationToken);
                var response = await resourceGroup.GetAvailabilitySetAsync(availabilitySetName, cancellationToken);
                return response.Value;
            }
            catch (Exception ex)
            {
                LogError($"Failed to get availability set {availabilitySetName}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets an availability set resource synchronously
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="availabilitySetName">The availability set name</param>
        /// <returns>The availability set resource</returns>
        public AvailabilitySetResource GetAvailabilitySet(string resourceGroupName, string availabilitySetName)
        {
            return GetAvailabilitySetAsync(resourceGroupName, availabilitySetName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a virtual machine scale set resource
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="vmssName">The virtual machine scale set name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The virtual machine scale set resource</returns>
        public async Task<VirtualMachineScaleSetResource> GetVirtualMachineScaleSetAsync(
            string resourceGroupName,
            string vmssName,
            CancellationToken cancellationToken = default)
        {
            LogVerbose($"Getting virtual machine scale set: {vmssName} in resource group: {resourceGroupName}");
            
            try
            {
                var resourceGroup = await GetResourceGroupAsync(resourceGroupName, cancellationToken);
                var response = await resourceGroup.GetVirtualMachineScaleSetAsync(vmssName, cancellationToken:cancellationToken);
                return response.Value;
            }
            catch (Exception ex)
            {
                LogError($"Failed to get virtual machine scale set {vmssName}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets a virtual machine scale set resource synchronously
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="vmssName">The virtual machine scale set name</param>
        /// <returns>The virtual machine scale set resource</returns>
        public VirtualMachineScaleSetResource GetVirtualMachineScaleSet(string resourceGroupName, string vmssName)
        {
            return GetVirtualMachineScaleSetAsync(resourceGroupName, vmssName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates a credential from the Azure context
        /// </summary>
        /// <param name="context">The Azure context</param>
        /// <returns>A token credential</returns>
        private TokenCredential CreateCredentialFromContext(IAzureContext context)
        {
            // Get the token from the existing authenticated context
            // This reuses the authentication that PowerShell already established
            return new ComputeTokenCredential(context);
        }

        /// <summary>
        /// Logs a verbose message
        /// </summary>
        /// <param name="message">The message to log</param>
        private void LogVerbose(string message)
        {
            VerboseLogger?.Invoke(message);
        }

        /// <summary>
        /// Logs an error message
        /// </summary>
        /// <param name="message">The message to log</param>
        private void LogError(string message)
        {
            ErrorLogger?.Invoke(message);
        }

        /// <summary>
        /// Token credential that uses the Azure PowerShell context for authentication
        /// </summary>
        private class ComputeTokenCredential : TokenCredential
        {
            private readonly IAzureContext _context;

            public ComputeTokenCredential(IAzureContext context)
            {
                _context = context;
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return GetTokenAsync(requestContext, cancellationToken).GetAwaiter().GetResult();
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                // Get the token from the Azure PowerShell session
                var accessToken = AzureSession.Instance.AuthenticationFactory.Authenticate(
                    _context.Account,
                    _context.Environment,
                    _context.Tenant.Id,
                    null,
                    null,
                    null);

                return new ValueTask<AccessToken>(new AccessToken(accessToken.AccessToken, DateTimeOffset.UtcNow.AddHours(1)));
            }
        }
    }
}