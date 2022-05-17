using Azure.ResourceManager;
using Track2 = Azure.ResourceManager.Storage;
using Track2Model = Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Resources;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

using System.Collections.Generic;
using Azure.ResourceManager.Storage;
using Azure;
using Azure.Core;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Azure.ResourceManager.Storage.Models;
using Microsoft.Azure.Storage.Blob.Protocol;
using System.Diagnostics.Contracts;

namespace Microsoft.Azure.Commands.Management.Storage
{
    public class Track2StorageManagementClient
    {
        private ArmClient _armClient;
        private string _subscription;
        private IClientFactory _clientFactory;

        public Track2StorageManagementClient(IClientFactory clientFactory, IAzureContext context)
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

        /// <summary>
        /// List accounts from subscription
        /// </summary>
        /// 
        public Pageable<StorageAccountResource> ListStorageAccounts() =>
            _armClient.GetSubscriptionResource(new global::Azure.Core.ResourceIdentifier(
                string.Format("/subscriptions/{0}", _subscription)))
            .GetStorageAccounts();

        /// <summary>
        /// List accounts from Resource group
        /// </summary>
        public Pageable<Track2.StorageAccountResource> ListStorageAccounts(string resourcegroup) =>
            GetResourceGroup(resourcegroup).GetStorageAccounts().GetAll();

        /// <summary>
        /// Get single storage account with no data
        /// </summary>
        public Track2.StorageAccountResource GetStorageAccount(string resourcegroup, string storageAccountName) =>
            _armClient.GetStorageAccountResource(Track2.StorageAccountResource.CreateResourceIdentifier(_subscription, resourcegroup, storageAccountName));

        /// <summary>
        /// Get a single Storage account with its data 
        /// </summary>
        public Track2.StorageAccountResource GetSingleStorageAccount(string resourceGroup, string storageAccountName, StorageAccountExpand? expand = null) =>
            GetResourceGroup(resourceGroup).GetStorageAccounts().Get(storageAccountName, expand);

        /// <summary>
        /// Create a Storage account 
        /// </summary>
        public StorageAccountResource CreateStorageAccount(string resourceGroup, string storageAccountName, StorageAccountCreateOrUpdateContent content) =>
            GetResourceGroup(resourceGroup).GetStorageAccounts().CreateOrUpdate(WaitUntil.Completed, storageAccountName, content).Value;

        /// <summary>
        /// Update a Storage account
        /// </summary>
        public Track2.StorageAccountResource UpdateStorageAccount(string resourcegroup, string storageAccountName, StorageAccountPatch patch) =>
            GetStorageAccount(resourcegroup, storageAccountName).Update(patch);

        /// <summary>
        /// Get BlobServiceResource with subscription, resource group name, and storage account name
        /// </summary>
        public Track2.BlobServiceResource GetBlobServiceResource(string resourceGroupName, string storageAccountName) =>
            _armClient.GetBlobServiceResource(Track2.BlobServiceResource.CreateResourceIdentifier(_subscription, resourceGroupName, storageAccountName));

        /// <summary>
        /// Get BlobContainerResource with subscription, resource group name, and storage account name 
        /// </summary>
        public Track2.BlobContainerResource GetBlobContainerResource(string resourceGroupName, string storageAccountName, string containerName) =>
             _armClient.GetBlobContainerResource(Track2.BlobContainerResource.CreateResourceIdentifier(_subscription, resourceGroupName, storageAccountName, containerName));

        /// <summary>
        /// List blob containers under a resource group and storage account 
        /// </summary>
        public Track2.BlobContainerCollection GetBlobContainers(string resourceGroupName, string storageAccountName) =>
            GetBlobServiceResource(resourceGroupName, storageAccountName).GetBlobContainers();

        /// <summary>
        /// Get a blob container under a resource group and storage account with container name 
        /// </summary>
        public Track2.BlobContainerResource GetBlobContainer(string resourceGroupName, string storageAccountName, string containerName) =>
            GetBlobContainerResource(resourceGroupName, storageAccountName, containerName).Get();

        /// <summary>
        /// Update a blob container 
        /// </summary>
        public Track2.BlobContainerResource UpdateBlobContainer(string resourceGroupName, string storageAccountName, string containerName, BlobContainerData data) =>
           GetBlobContainerResource(resourceGroupName, storageAccountName, containerName).Update(data);

        /// <summary>
        /// Create a blob container 
        /// </summary>
        public Track2.BlobContainerResource CreateBlobContainer(string resourceGroupName, string storageAccountName, string containerName, BlobContainerData data) =>
            GetBlobContainers(resourceGroupName, storageAccountName).CreateOrUpdate(WaitUntil.Completed, containerName, data).Value;

        /// <summary>
        /// Get immutability policy of a blob container 
        /// </summary>
        public Track2.ImmutabilityPolicyResource GetImmutabilityPolicy(string resourceGroupName, string storageAccountName, string containerName, string etag) =>
            GetBlobContainerResource(resourceGroupName, storageAccountName, containerName).GetImmutabilityPolicy().Get(etag);

        /// <summary>
        /// Lock immutability policy of a blob container 
        /// </summary>
        public Track2.ImmutabilityPolicyResource LockImmutabilityPolicy(string resourceGroupName, string storageAccountName, string containerName, string etag) =>
            GetBlobContainerResource(resourceGroupName, storageAccountName, containerName).GetImmutabilityPolicy().LockImmutabilityPolicy(etag);

        /// <summary>
        /// Create immutability policy for a blob container 
        /// </summary>
        public Track2.ImmutabilityPolicyResource CreateImmutabilityPolicy(string resourceGroupName, string storageAccountName, string containerName, ImmutabilityPolicyData data, string etag) =>
            GetBlobContainerResource(resourceGroupName, storageAccountName, containerName).GetImmutabilityPolicy().CreateOrUpdate(WaitUntil.Completed, data, etag).Value;

        /// <summary>
        /// Extend immutability policy for a blob container 
        /// </summary>
        public Track2.ImmutabilityPolicyResource ExtendImmutabilityPolicy(string resourceGroupName, string storageAccountName, string containerName, ImmutabilityPolicyData data, string etag) =>
            GetBlobContainerResource(resourceGroupName, storageAccountName, containerName).GetImmutabilityPolicy().ExtendImmutabilityPolicy(etag, data);

        /// <summary>
        /// Delete immutability policy for a blob container 
        /// </summary>
        public Track2.ImmutabilityPolicyResource DeleteImmutabilityPolicy(string resourceGroupName, string storageAccountName, string containerName, string etag) =>            
            GetBlobContainerResource(resourceGroupName, storageAccountName, containerName).GetImmutabilityPolicy().Delete(WaitUntil.Completed, etag).Value;
    }
}