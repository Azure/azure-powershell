namespace Microsoft.Azure.Commands.HPCCache.Test.Fixtures
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Web;
    using Microsoft.Azure.Commands.HPCCache.Test.Helper;
    using Microsoft.Azure.Commands.HPCCache.Test.Utilities;
    using Microsoft.Azure.Commands.TestFx;
    using Microsoft.Azure.Management.Internal.Resources.Models;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Management.Storage.Models;
    using Microsoft.Azure.Management.StorageCache;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Storage account fixture to share created storage accounts between the tests in same class.
    /// </summary>
    [Collection("HpcCacheCollection")]
    public class StorageAccountFixture : IDisposable
    {
        private static readonly Regex ClfsTargetRegex = new Regex(@"^(/subscriptions/[-0-9a-f]{36}/resourcegroups/[-\w\._\(\)]+/providers/Microsoft.Storage/storageAccounts/(?<StorageAccountName>[-\w\._\(\)]+))/blobServices/default/containers/(?<ContainerName>[-\w\._\(\)]+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Defines the Fixture.
        /// </summary>
        private readonly HpcCacheTestFixture fixture;

        /// <summary>
        /// Defines the storage accounts cache.
        /// </summary>
        private readonly Dictionary<string, StorageAccount> storageAccountsCache = new Dictionary<string, StorageAccount>();

        /// <summary>
        /// Defines the blob containers cache.
        /// </summary>
        private readonly Dictionary<string, BlobContainer> blobContainersCache = new Dictionary<string, BlobContainer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageAccountFixture"/> class.
        /// </summary>
        /// <param name="fixture">HpcCacheTestFixture.</param>
        public StorageAccountFixture(HpcCacheTestFixture fixture)
        {
            this.fixture = fixture;
            using (this.Context = new HpcCacheTestContext(this.GetType().Name))
            {
                this.StorageTarget = this.AddClfsStorageTarget(this.Context);
                Match clfsTargetMatch = ClfsTargetRegex.Match(this.StorageTarget.Clfs.Target);
                var storageAccountName = clfsTargetMatch.Groups["StorageAccountName"].Value;
                StorageManagementClient storageManagementClient = this.Context.GetClient<StorageManagementClient>();
                StorageAccountsHelper storageAccountsHelper = new StorageAccountsHelper(storageManagementClient, this.fixture.ResourceGroup);
                StorageAccount existingStorageAccount = storageAccountsHelper.GetStorageAccount(this.fixture.ResourceGroup.Name, storageAccountName);
                if (!this.storageAccountsCache.TryGetValue(existingStorageAccount.Name, out StorageAccount _))
                {
                    this.storageAccountsCache.Add(existingStorageAccount.Name, existingStorageAccount);
                }

                for (int i = 0; i < 10; i++)
                {
                    this.AddBlobContainer(this.Context, this.fixture.ResourceGroup, existingStorageAccount, suffix: i.ToString());
                }
            }
        }

        /// <summary>
        /// Gets or sets the Context.
        /// </summary>
        public HpcCacheTestContext Context { get; set; }

        /// <summary>
        /// Gets or sets the storageTarget.
        /// </summary>
        public StorageTarget StorageTarget { get; set; }

        /// <inheritdoc/>
        public void Dispose()
        {
            // We do not create anything in this fixture but
            // just use the HpcCacheTestFixture which has its own disposal method.
        }

        /// <summary>
        /// Adds storage account in given resource group and applies required roles.
        /// </summary>
        /// <param name="context">HpcCacheTestContext.</param>
        /// <param name="resourceGroup">Object representing a resource group.</param>
        /// <param name="storageAccountName">storage account name.</param>
        /// <param name="suffix">suffix.</param>
        /// <param name="addPermissions">Whether to add storage account contributor roles.</param>
        /// <param name="testOutputHelper">testOutputHelper.</param>
        /// <param name="sleep">Sleep time for permissions to get propagated.</param>
        /// <param name="waitForPermissions">Whether to wait for permissions to be propagated.</param>
        /// <returns>StorageAccount.</returns>
        public StorageAccount AddStorageAccount(
            HpcCacheTestContext context,
            ResourceGroup resourceGroup,
            string storageAccountName,
            string suffix = null,
            bool addPermissions = true,
            ITestOutputHelper testOutputHelper = null,
            int sleep = 300,
            bool waitForPermissions = true)
        {
            if (this.storageAccountsCache.TryGetValue(storageAccountName + suffix, out StorageAccount storageAccount))
            {
                if (testOutputHelper != null)
                {
                    testOutputHelper.WriteLine($"Using existing storage account {storageAccountName + suffix}");
                }

                return storageAccount;
            }

            StorageManagementClient storageManagementClient = context.GetClient<StorageManagementClient>();
            StorageAccountsHelper storageAccountsHelper = new StorageAccountsHelper(storageManagementClient, resourceGroup);
            storageAccount = storageAccountsHelper.CreateStorageAccount(storageAccountName + suffix);
            if (addPermissions)
            {
                this.AddStorageAccountAccessRules(context, storageAccount);
            }

            if (waitForPermissions && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                if (testOutputHelper != null)
                {
                    testOutputHelper.WriteLine($"Sleeping {sleep.ToString()} seconds while permissions propagates.");
                }
                TestUtilities.Wait(new TimeSpan(0, 0, sleep));
            }

            this.storageAccountsCache.Add(storageAccount.Name, storageAccount);
            return storageAccount;
        }

        /// <summary>
        /// Adds blob container.
        /// </summary>
        /// <param name="context">HpcCacheTestContext.</param>
        /// <param name="resourceGroup">Object representing a resource group.</param>
        /// <param name="storageAccount">Object representing a storage account.</param>
        /// <param name="containerName">containerName.</param>
        /// <param name="suffix">suffix.</param>
        /// <param name="testOutputHelper">testOutputHelper.</param>
        /// <returns>BlobContainer.</returns>
        public BlobContainer AddBlobContainer(
            HpcCacheTestContext context,
            ResourceGroup resourceGroup,
            StorageAccount storageAccount,
            string containerName = "cmdletcontnr",
            string suffix = null,
            ITestOutputHelper testOutputHelper = null)
        {
            if (this.blobContainersCache.TryGetValue(containerName + suffix, out BlobContainer blobContainer))
            {
                if (testOutputHelper != null)
                {
                    testOutputHelper.WriteLine($"Using existing blob container {containerName + suffix}");
                }

                return blobContainer;
            }

            StorageManagementClient storageManagementClient = context.GetClient<StorageManagementClient>();
            StorageAccountsHelper storageAccountsHelper = new StorageAccountsHelper(storageManagementClient, resourceGroup);
            blobContainer = storageAccountsHelper.CreateBlobContainer(storageAccount.Name, containerName + suffix);
            this.blobContainersCache.Add(blobContainer.Name, blobContainer);
            return blobContainer;
        }

        /// <summary>
        /// Creates storage account, blob container and adds CLFS storage account to cache.
        /// </summary>
        /// <param name="context">HpcCacheTestContext.</param>
        /// <param name="suffix">suffix.</param>
        /// <param name="waitForStorageTarget">Whether to wait for storage target to deploy.</param>
        /// <param name="addPermissions">Whether to add storage account contributor roles.</param>
        /// <param name="testOutputHelper">testOutputHelper.</param>
        /// <param name="sleep">Sleep time for permissions to get propagated.</param>
        /// <param name="waitForPermissions">Whether to wait for permissions to be propagated.</param>
        /// <param name="maxRequestTries">Max retries.</param>
        /// <returns>StorageTarget.</returns>
        public StorageTarget AddClfsStorageTarget(
            HpcCacheTestContext context,
            string storageTargetName = "msazure",
            string storageAccountName = "cmdletsa",
            string containerName = "cmdletcontnr",
            string suffix = null,
            bool waitForStorageTarget = true,
            bool addPermissions = true,
            ITestOutputHelper testOutputHelper = null,
            int sleep = 300,
            bool waitForPermissions = true,
            int maxRequestTries = 25)
        {
            StorageTarget storageTarget;

            if (string.IsNullOrEmpty(HpcCacheTestEnvironmentUtilities.StorageTargetName))
            {
                storageTargetName = string.IsNullOrEmpty(suffix) ? storageTargetName : storageTargetName + suffix;
            }
            else
            {
                storageTargetName = HpcCacheTestEnvironmentUtilities.StorageTargetName;
            }

            var client = context.GetClient<StorageCacheManagementClient>();
            client.ApiVersion = Constants.DefaultAPIVersion;
            this.fixture.CacheHelper.StoragecacheManagementClient = client;
            storageTarget = this.fixture.CacheHelper.GetStorageTarget(this.fixture.Cache.Name, storageTargetName);

            if (storageTarget == null)
            {
                string junction = "/junction" + suffix;
                var storageAccount = this.AddStorageAccount(
                    context,
                    this.fixture.ResourceGroup,
                    storageAccountName,
                    suffix,
                    addPermissions,
                    testOutputHelper,
                    sleep: sleep,
                    waitForPermissions: waitForPermissions);
                var blobContainer = this.AddBlobContainer(context, this.fixture.ResourceGroup, storageAccount, containerName, suffix, testOutputHelper);
                StorageTarget storageTargetParameters = this.fixture.CacheHelper.CreateClfsStorageTargetParameters(
                    storageAccount.Name,
                    blobContainer.Name,
                    junction);
                storageTarget = this.fixture.CacheHelper.CreateStorageTarget(
                    this.fixture.Cache.Name,
                    storageTargetName,
                    storageTargetParameters,
                    testOutputHelper,
                    waitForStorageTarget,
                    maxRequestTries);
            }

            return storageTarget;
        }

        /// <summary>
        /// Adds storage account access roles.
        /// Storage Account Contributor or Storage blob Contributor.
        /// </summary>
        /// <param name="context">Object representing a HpcCacheTestContext.</param>
        /// <param name="storageAccount">Object representing a storage account.</param>
        /// <param name="testOutputHelper">Object representing a testOutputHelper.</param>
        private void AddStorageAccountAccessRules(
            HpcCacheTestContext context,
            StorageAccount storageAccount,
            ITestOutputHelper testOutputHelper = null)
        {
            try
            {
                string role1 = "Storage Account Contributor";
                context.AddRoleAssignment(context, storageAccount.Id, role1, TestUtilities.GenerateGuid().ToString());

                // string role2 = "Storage Blob Data Contributor";
                // context.AddRoleAssignment(context, storageAccount.Id, role2, TestUtilities.GenerateGuid().ToString());
                if (testOutputHelper != null)
                {
                    testOutputHelper.WriteLine($"Added {role1} role to storage account {storageAccount.Name}.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
