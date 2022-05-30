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
        /// Check if a storage account name is available
        /// </summary>
        public CheckNameAvailabilityResult CheckNameAvailability(StorageAccountCheckNameAvailabilityContent content) =>
            GetSubscription(_subscription).CheckStorageAccountNameAvailability(content);

        /// <summary>
        /// get Storage usages
        /// </summary>
        public Pageable<StorageUsage> GetStorageUsages(string location) =>
            GetSubscription(_subscription).GetUsagesByLocation(location);

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
        /// Get Blob inventory policy resource
        public Track2.BlobInventoryPolicyResource GetBlobInventoryPolicyResource(string resourceGroupName, string storageAccountName, string policyName) =>
            _armClient.GetBlobInventoryPolicyResource(Track2.BlobInventoryPolicyResource.CreateResourceIdentifier(_subscription, resourceGroupName, storageAccountName, policyName));

        /// <summary>
        /// Get immutability policy resource
        /// </summary>
        public Track2.ImmutabilityPolicyResource GetImmutabilityPolicyResource(string resourceGroupName, string storageAccountName, string containerName) =>
            _armClient.GetImmutabilityPolicyResource(Track2.ImmutabilityPolicyResource.CreateResourceIdentifier(_subscription, resourceGroupName, storageAccountName, containerName));

        /// <summary>
        /// Get management policy resource
        /// </summary>
        public Track2.ManagementPolicyResource GetManagementPolicyResource(string resourceGroupName, string storageAccountName, string policyName) =>
            _armClient.GetManagementPolicyResource(Track2.ManagementPolicyResource.CreateResourceIdentifier(_subscription, resourceGroupName, storageAccountName, policyName));

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
        /// Get file share resource
        /// </summary>
        public Track2.FileShareResource GetFileShareResource(string resourceGroupName, string storageAccountName, string shareName) =>
            _armClient.GetFileShareResource(FileShareResource.CreateResourceIdentifier(_subscription, resourceGroupName, storageAccountName, shareName));

        /// <summary>
        /// Get file service resource
        /// </summary>
        public Track2.FileServiceResource GetFileServiceResource(string resourceGroupName, string storageAccountName) =>
            _armClient.GetFileServiceResource(FileServiceResource.CreateResourceIdentifier(_subscription, resourceGroupName, storageAccountName));

        /// <summary>
        /// Get encryption scope resource
        /// </summary>
        public Track2.EncryptionScopeResource GetEncryptionScopeResource(string resourceGroupName, string accountName, string encryptionScopeName) =>
            _armClient.GetEncryptionScopeResource(EncryptionScopeResource.CreateResourceIdentifier(_subscription, resourceGroupName, accountName, encryptionScopeName));

        /// <summary>
        /// Get object replication policy resource
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="storageAccountName"></param>
        /// <param name="policyId"></param>
        /// <returns></returns>
        public Track2.ObjectReplicationPolicyResource GetObjectReplicationPolicyResource(string resourceGroupName, string storageAccountName, string policyId) =>
            _armClient.GetObjectReplicationPolicyResource(ObjectReplicationPolicyResource.CreateResourceIdentifier(_subscription, resourceGroupName, storageAccountName, policyId));
    }
}