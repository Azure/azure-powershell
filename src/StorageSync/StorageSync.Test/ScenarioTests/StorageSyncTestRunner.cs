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
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0;
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.Interfaces;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ResourceManager.Version2021_01_01;
using Microsoft.Azure.Management.Storage.Version2017_10_01;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using StorageSync.Test.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.TestFx;
using Microsoft.Azure.Internal.Common;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Xunit.Abstractions;

namespace ScenarioTests
{
    /// <summary>
    /// Class StorageSyncTestRunner.
    /// </summary>
    public class StorageSyncTestRunner
    {
        /// <summary>
        /// The tenant identifier key
        /// </summary>
        private const string TenantIdKey = StorageSyncConstants.TenantId;
        /// <summary>
        /// The domain key
        /// </summary>
        private const string DomainKey = "Domain";
        /// <summary>
        /// The subscription identifier key
        /// </summary>
        private const string SubscriptionIdKey = "SubscriptionId";

        /// <summary>
        /// Gets the user domain.
        /// </summary>
        /// <value>The user domain.</value>
        public string UserDomain { get; private set; }

        protected readonly ITestRunner TestRunner;

        protected StorageSyncTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"Common.ps1",
                    @"../AzureRM.Storage.ps1",
                    @"../AzureRM.Resources.ps1"
                })
                .WithNewRmModules(helper => new[]
                {
                    helper.RMProfileModule,
                    helper.RMStorageModule,
                    helper.GetRMModulePath("Az.StorageSync.psd1")
                })
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null},
                        {"Microsoft.Storage", null},
                        {"Microsoft.StorageSync", null}
                    }
                ).WithMockContextAction(() =>
                    {
                        var sf = new StackTrace().GetFrame(2);
                        var callingClassType = sf.GetMethod().ReflectedType?.ToString();
                        var testName = sf.GetMethod().Name;

                        using (var context = MockContext.Start(callingClassType, testName))
                        {
                            RegisterComponents(context, testName);
                        }
                    }
                )
                .Build();
        }

        /// <summary>
        /// Registers the components.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="testName">Name of the test.</param>
        private void RegisterComponents(MockContext context, string testName)
        {
            AzureSession.Instance.RegisterComponent<IStorageSyncResourceManager>(StorageSyncConstants.StorageSyncResourceManager, () => new MockStorageSyncResourceManager(testName), overwrite: true);
        }

        /// <summary>
        /// Gets the resource management client.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>ResourceManagementClient.</returns>
        private ResourceManagementClient GetRMClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        /// <summary>
        /// Gets the subscription client.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>SubscriptionClient.</returns>
        private SubscriptionClient GetSubClient(MockContext context)
        {
            return context.GetServiceClient<SubscriptionClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        /// <summary>
        /// Gets the storage sync management client.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>StorageSyncManagementClient.</returns>
        private StorageSyncManagementClient GetStorageSyncClient(MockContext context)
        {
            return context.GetServiceClient<StorageSyncManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        /// <summary>
        /// Gets the storage management client.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>StorageManagementClient.</returns>
        private StorageManagementClient GetStorageClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        /// <summary>
        /// Gets the graph client.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>MicrosoftGraphClient.</returns>
        private MicrosoftGraphClient GetGraphClient(MockContext context)
        {
            var environment = TestEnvironmentFactory.GetTestEnvironment();
            string tenantId = null;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                tenantId = environment.Tenant;
                UserDomain = String.IsNullOrEmpty(environment.UserName) ? String.Empty : environment.UserName.Split(new[] { "@" }, StringSplitOptions.RemoveEmptyEntries).Last();

                HttpMockServer.Variables[TenantIdKey] = tenantId;
                HttpMockServer.Variables[DomainKey] = UserDomain;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                if (HttpMockServer.Variables.ContainsKey(TenantIdKey))
                {
                    tenantId = HttpMockServer.Variables[TenantIdKey];
                }
                if (HttpMockServer.Variables.ContainsKey(DomainKey))
                {
                    UserDomain = HttpMockServer.Variables[DomainKey];
                }
                if (HttpMockServer.Variables.ContainsKey(SubscriptionIdKey))
                {
                    AzureRmProfileProvider.Instance.Profile.DefaultContext.Subscription.Id = HttpMockServer.Variables[SubscriptionIdKey];
                }
            }

            var client = context.GetGraphServiceClient<MicrosoftGraphClient>(environment, true);
            client.TenantID = tenantId;
            if (AzureRmProfileProvider.Instance != null &&
                AzureRmProfileProvider.Instance.Profile != null &&
                AzureRmProfileProvider.Instance.Profile.DefaultContext != null &&
                AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant != null)
            {
                AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Id = client.TenantID;
            }
            return client;
        }

        /// <summary>
        /// Gets the authorization management client.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>AuthorizationManagementClient.</returns>
        private AuthorizationManagementClient GetAuthClient(MockContext context)
        {
            return context.GetServiceClient<AuthorizationManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}