using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Track2
{
    public class Track2ComputeClient
    {
        private ArmClient _armClient;
        private string _subscription;
        private IClientFactory _clientFactory;

        public Track2ComputeClient(IClientFactory clientFactory, IAzureContext context)
        {
            _clientFactory = clientFactory;
            _armClient = _clientFactory.CreateArmClient(context, AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId);
            _subscription = context.Subscription.Id;
        }

        /// <summary>
        /// Get resource group instance
        /// </summary>
        /// <param name="resourcegroup"></param>
        public ResourceGroupResource GetResourceGroup(string resourcegroup) =>
            _armClient.GetResourceGroupResource(new global::Azure.Core.ResourceIdentifier(
                string.Format("/subscriptions/{0}/resourceGroups/{1}", _subscription, resourcegroup)));


        public SubscriptionResource GetSubscription(string subscription) =>
            _armClient.GetSubscriptionResource(new global::Azure.Core.ResourceIdentifier(
                string.Format("/subscriptions/{0}", subscription)));

        public Pageable<DiskAccessResource> ListDiskAccessesByResourceGroup(string resourceGroupName) =>
            GetResourceGroup(resourceGroupName).GetDiskAccesses().GetAll();

        public DiskAccessResource GetDiskAccess(string resourceGroup, string diskAccessName) =>
            _armClient.GetDiskAccessResource(DiskAccessResource.CreateResourceIdentifier(_subscription, resourceGroup, diskAccessName));

        public DiskAccessResource GetDiskAccess2(string resourceGroupName, string diskAccessName) =>
            GetResourceGroup(resourceGroupName).GetDiskAccess(diskAccessName);

        public Pageable<DiskAccessResource> ListDiskAccessesBySubscription() =>
            GetSubscription(_subscription).GetDiskAccesses();

    }
}