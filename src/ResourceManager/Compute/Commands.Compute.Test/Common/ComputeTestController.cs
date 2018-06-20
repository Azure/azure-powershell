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
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;
using TestBase = Microsoft.Azure.Test.TestBase;
#endif
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using NetworkManagementClientInternal = Microsoft.Azure.Management.Internal.Network.Version2017_10_01.NetworkManagementClient;
using ResourceManagementClientInternal = Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public sealed class ComputeTestController : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        public StorageManagementClient StorageClient { get; private set; }

        public ComputeManagementClient ComputeManagementClient { get; private set; }

        public NetworkManagementClient NetworkManagementClient { get; private set; }

        public NetworkManagementClientInternal NetworkManagementClientInternal { get; private set; }

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public ResourceManagementClientInternal InternalResourceManagementClient { get; private set; }

        public string UserDomain { get; private set; }

        public static ComputeTestController NewInstance => new ComputeTestController();

        public ComputeTestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;
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
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            d.Add("Microsoft.Compute", null);
            d.Add("Microsoft.Network", null);
            d.Add("Microsoft.Storage", null);

            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            providersToIgnore.Add("Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2017-05-10");
            providersToIgnore.Add("Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient", "2016-09-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                initialize?.Invoke(this);

                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\ComputeTestCommon.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.RMResourceModule,
                    _helper.RMStorageDataPlaneModule,
                    _helper.RMStorageModule,
                    _helper.GetRMModulePath("AzureRM.Compute.psd1"),
                    _helper.GetRMModulePath("AzureRM.Network.psd1"),
                    "AzureRM.Storage.ps1",
                    "AzureRM.Resources.ps1");

                try
                {
                    var psScripts = scriptBuilder?.Invoke();

                    if (psScripts != null)
                    {
                        _helper.RunPowerShellTest(psScripts);
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
            StorageClient = GetStorageManagementClient(context);
            ComputeManagementClient = GetComputeManagementClient(context);
            NetworkManagementClient = GetNetworkManagementClient(context);
            NetworkManagementClientInternal = GetNetworkManagementClientInternal(context);
            ResourceManagementClient = GetResourceManagementClient(context);
            InternalResourceManagementClient = GetResourceManagementClientInternal(context);

            _helper.SetupSomeOfManagementClients(
                StorageClient,
                ComputeManagementClient,
                NetworkManagementClient,
                NetworkManagementClientInternal,
                ResourceManagementClient,
                InternalResourceManagementClient);
        }

        private static ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
#if NETSTANDARD
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
#else
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
#endif
        }

        private static ResourceManagementClientInternal GetResourceManagementClientInternal(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClientInternal>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static NetworkManagementClient GetNetworkManagementClient(MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static NetworkManagementClientInternal GetNetworkManagementClientInternal(MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClientInternal>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ComputeManagementClient GetComputeManagementClient(MockContext context)
        {
            return context.GetServiceClient<ComputeManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
