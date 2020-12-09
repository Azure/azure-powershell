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

namespace Microsoft.Azure.Commands.HPCCache.Test.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.HPCCache.Test.Fixtures;
    using Microsoft.Azure.Management.Internal.Resources;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Management.StorageCache;
    using Microsoft.Azure.ServiceManagement.Common.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

    /// <summary>
    /// Base test controller class.
    /// </summary>
    public class HpcCacheController : RMTestBase
    {
        private readonly EnvironmentSetupHelper helper;

        /// <summary>
        /// Initializes a new instance of the <see cref="HpcCacheController"/> class.
        /// </summary>
        protected HpcCacheController()
        {
            this.helper = new EnvironmentSetupHelper();
        }

        /// <summary>
        /// Gets HpcCacheTestBase instance.
        /// </summary>
        public static HpcCacheController NewInstance => new HpcCacheController();

        /// <summary>
        /// Gets resource management client.
        /// </summary>
        public ResourceManagementClient ResourceManagementClient { get; private set; }

        /// <summary>
        /// Gets HPC cache management client.
        /// </summary>
        public StorageCacheManagementClient StorageCacheManagementClient { get; private set; }

        /// <summary>
        /// Gets storage management client.
        /// </summary>
        public StorageManagementClient StorageManagementClient { get; private set; }

        /// <summary>
        /// Methods for invoking PowerShell scripts.
        /// </summary>
        /// <param name="logger">logger.</param>
        /// <param name="scripts">scripts.</param>
        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            logger.Information(string.Format("Test method entered: {0}.{1}", callingClassType, mockName));
            this.RunPsTestWorkflow(
                logger,
                () => scripts,
                null,
                callingClassType,
                mockName);
            logger.Information(string.Format("Test method finished: {0}.{1}", callingClassType, mockName));
        }

        /// <summary>
        /// Gets storage management client.
        /// </summary>
        static public IRecordMatcher GetRecordMatcher()
        {
            var d = new Dictionary<string, string>
            {
                { "Microsoft.Resources", null },
                { "Microsoft.Features", null },
                { "Microsoft.Authorization", null },
                { "Microsoft.Network", null },
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                { "Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01" },
                { "Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2017-05-10" },
            };
            return new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
        }

        /// <summary>
        /// RunPsTestWorkflow.
        /// </summary>
        /// <param name="logger">logger.</param>
        /// <param name="scriptBuilder">scriptBuilder.</param>
        /// <param name="cleanup">cleanup.</param>
        /// <param name="callingClassType">callingClassType.</param>
        /// <param name="mockName">mockName.</param>
        /// <param name="initialize">initialize.</param>
        protected void RunPsTestWorkflow(
            XunitTracingInterceptor logger,
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string mockName,
            Action initialize = null)
        {
            this.helper.TracingInterceptor = logger;
            HttpMockServer.Matcher = GetRecordMatcher();
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (var context = new HpcCacheTestContext(callingClassType, mockName))
            {
                initialize?.Invoke();
                this.SetupManagementClients(context);

                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.helper.SetupModules(
                    AzureModule.AzureResourceManager,
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    this.helper.RMProfileModule,
                    this.helper.GetRMModulePath("Az.HPCCache.psd1"),
                    "AzureRM.Resources.ps1");

                try
                {
                    var psScripts = scriptBuilder?.Invoke();
                    if (psScripts != null)
                    {
                        this.helper.RunPowerShellTest(psScripts);
                    }
                }
                finally
                {
                    cleanup?.Invoke();
                }
            }
        }

        /// <summary>
        /// Management clients.
        /// </summary>
        /// <param name="context">context.</param>
        protected void SetupManagementClients(HpcCacheTestContext context)
        {
            var hpcCacheManagementClient = this.GetHpcCacheManagementClient(context);
            var resourceManagementClient = this.GetResourceManagementClient(context);
            var storageManagementClient = this.GetStorageManagementClient(context);

            this.helper.SetupManagementClients(
                hpcCacheManagementClient,
                resourceManagementClient,
                storageManagementClient);
        }

        /// <summary>
        /// GetHpcCacheManagementClient.
        /// </summary>
        /// <param name="context">context.</param>
        /// <returns>StorageCacheManagementClient.</returns>
        protected StorageCacheManagementClient GetHpcCacheManagementClient(HpcCacheTestContext context)
        {
            return context.GetClient<StorageCacheManagementClient>();
        }

        /// <summary>
        /// GetResourceManagementClient.
        /// </summary>
        /// <param name="context">context.</param>
        /// <returns>ResourceManagementClient.</returns>
        protected ResourceManagementClient GetResourceManagementClient(HpcCacheTestContext context)
        {
            return context.GetClient<ResourceManagementClient>();
        }

        /// <summary>
        /// GetStorageManagementClient.
        /// </summary>
        /// <param name="context">context.</param>
        /// <returns>StorageManagementClient.</returns>
        protected StorageManagementClient GetStorageManagementClient(HpcCacheTestContext context)
        {
            return context.GetClient<StorageManagementClient>();
        }
    }
}
