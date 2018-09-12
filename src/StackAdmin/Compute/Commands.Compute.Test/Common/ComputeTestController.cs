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
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Azure.Management.Network;
#if NETSTANDARD
using Microsoft.Azure.Management.ResourceManager;
#else
//using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.ResourceManager;
#endif
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using ResourceManagementClientInternal = Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public sealed class ComputeTestController : RMTestBase
    {

        private readonly EnvironmentSetupHelper _helper;
        private const string TenantIdKey = "TenantId";
        private const string DomainKey = "Domain";

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public ResourceManagementClientInternal InternalResourceManagementClient { get; private set; }

        public StorageManagementClient StorageClient { get; private set; }

        public NetworkManagementClient NetworkManagementClient { get; private set; }

        public ComputeManagementClient ComputeManagementClient { get; private set; }

        public string UserDomain { get; private set; }

        public static ComputeTestController NewInstance
        {
            get
            {
                return new ComputeTestController();
            }
        }

        public ComputeTestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void SetLogger(XunitTracingInterceptor logger)
        {
            _helper.TracingInterceptor = logger;
        }

        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            SetLogger(logger);

            RunPsTestWorkflow(
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTest(params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            RunPsTestWorkflow(
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action<object> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            Dictionary<string, string> d = new Dictionary<string, string> {
                { "Microsoft.Resources", null },
                { "Microsoft.Features", null },
                { "Microsoft.Authorization", null },
                { "Microsoft.Compute", null }
            };

            var providersToIgnore = new Dictionary<string, string>();

            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                initialize?.Invoke(this);

                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                
                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\ComputeTestCommon.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.StackRMProfileModule,
                    _helper.StackRMResourceModule,
                    _helper.StackRMStorageDataPlaneModule,
                    _helper.StackRMStorageModule,
                    _helper.GetStackRMModulePath("AzureRM.Compute"),
                    _helper.GetStackRMModulePath("AzureRM.Network"));

                try
                {
                    if (scriptBuilder != null)
                    {
                        var psScripts = scriptBuilder();

                        if (psScripts != null)
                        {
                            _helper.RunPowerShellTest(psScripts);
                        }
                    }
                }
                finally
                {
                    cleanup?.Invoke();
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {

            ResourceManagementClient = GetResourceManagementClient(context);
            StorageClient = GetStorageManagementClient(context);
            NetworkManagementClient = this.GetNetworkManagementClientClient(context);
            ComputeManagementClient = GetComputeManagementClient(context);
            InternalResourceManagementClient = GetResourceManagementClientInternal(context);

            _helper.SetupManagementClients(
                ResourceManagementClient,
                StorageClient,
                NetworkManagementClient,
                ComputeManagementClient,
                InternalResourceManagementClient);
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClientInternal GetResourceManagementClientInternal(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClientInternal>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private NetworkManagementClient GetNetworkManagementClientClient(MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private ComputeManagementClient GetComputeManagementClient(MockContext context)
        {
            return context.GetServiceClient<ComputeManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
