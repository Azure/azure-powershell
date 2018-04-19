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
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public sealed class ComputeTestController : RMTestBase
    {
        bool testViaCsm = true; // Currently set to true, we will get this from Environment varialbe.

        private EnvironmentSetupHelper helper;
        private const string TenantIdKey = "TenantId";
        private const string DomainKey = "Domain";

        public GraphRbacManagementClient GraphClient { get; private set; }


        public StorageManagementClient StorageClient { get; private set; }

        public NetworkManagementClient NetworkManagementClient { get; private set; }

        public ComputeManagementClient ComputeManagementClient { get; private set; }

        public Microsoft.Azure.Management.ResourceManager.ResourceManagementClient ResourceManagementClient { get; private set; }

        public Microsoft.Azure.Management.Internal.Network.Version2017_10_01.NetworkManagementClient InternalNetworkManagementClient { get; private set; }

        public Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient InternalResourceManagementClient { get; private set; }

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
            helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(ServiceManagemenet.Common.Models.XunitTracingInterceptor logger, params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            helper.TracingInterceptor = logger;
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
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

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
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (RestTestFramework.MockContext context = RestTestFramework.MockContext.Start(callingClassType, mockName))
            {

                if (initialize != null)
                {
                    initialize(this);
                }

                SetupManagementClients(context);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\ComputeTestCommon.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.RMStorageDataPlaneModule,
                    helper.RMStorageModule,
                    helper.GetRMModulePath("AzureRM.Compute.psd1"),
                    helper.GetRMModulePath("AzureRM.Network.psd1"),
                    helper.GetRMModulePath("AzureRM.ServiceFabric.psd1"),
                    helper.RMStorageDataPlaneModule,
                    "AzureRM.Storage.ps1",
                    "AzureRM.Resources.ps1");

                try
                {
                    if (scriptBuilder != null)
                    {
                        var psScripts = scriptBuilder();

                        if (psScripts != null)
                        {
                            helper.RunPowerShellTest(psScripts);
                        }
                    }
                }
                finally
                {
                    if (cleanup != null)
                    {
                        cleanup();
                    }
                }
            }
        }

        private void SetupManagementClients(RestTestFramework.MockContext context)
        {
            StorageClient = GetStorageManagementClient(context);
            //var eventsClient = GetEventsClient();
            NetworkManagementClient = this.GetNetworkManagementClientClient(context);
            ComputeManagementClient = GetComputeManagementClient(context);
            InternalNetworkManagementClient = this.GetNetworkManagementClientInternal(context);
            InternalResourceManagementClient = this.GetResourceManagementClientInternal(context);
            ResourceManagementClient = GetResourceManagerResourceManagementClient(context);
            // GraphClient = GetGraphClient();

            helper.SetupManagementClients(
                StorageClient,
                NetworkManagementClient,
                ComputeManagementClient,
                InternalNetworkManagementClient,
                ResourceManagementClient,
                InternalResourceManagementClient);
            // GraphClient);
        }




        private Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient GetResourceManagementClientInternal(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }


        private StorageManagementClient GetStorageManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private Microsoft.Azure.Management.ResourceManager.ResourceManagementClient GetResourceManagerResourceManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<Microsoft.Azure.Management.ResourceManager.ResourceManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private NetworkManagementClient GetNetworkManagementClientClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private Microsoft.Azure.Management.Internal.Network.Version2017_10_01.NetworkManagementClient GetNetworkManagementClientInternal(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<Microsoft.Azure.Management.Internal.Network.Version2017_10_01.NetworkManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private ComputeManagementClient GetComputeManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ComputeManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
