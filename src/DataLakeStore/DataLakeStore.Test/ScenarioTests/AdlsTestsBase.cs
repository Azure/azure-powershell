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
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using NewResourceManagementClient = Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System.IO;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Commands.DataLakeStore.Models;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Commands.DataLake.Test.ScenarioTests;

namespace Microsoft.Azure.Commands.DataLakeStore.Test.ScenarioTests
{
    public class AdlsTestsBase : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        internal const string ResourceGroupLocation = "westus";

        public NewResourceManagementClient NewResourceManagementClient { get; private set; }

        public DataLakeStoreAccountManagementClient DataLakeStoreAccountManagementClient { get; private set; }

        public NetworkManagementClient NetworkClient { get; private set; }
        
        public static AdlsTestsBase NewInstance => new AdlsTestsBase();


        public AdlsTestsBase()
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
                // no custom cleanup
                null,
                callingClassType,
                mockName);
        }


        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            var d = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null},
                {"Microsoft.Network", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new UrlDecodingRecordMatcher(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (var context = AdlMockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                // register the namespace.
                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.RMNetworkModule,
                    _helper.GetRMModulePath(@"AzureRM.DataLakeStore.psd1"),
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
                    ReSetDataLakeStoreFileSystemManagementClient();
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            DataLakeStoreAccountManagementClient = GetDataLakeStoreAccountManagementClient(context);
            SetDataLakeStoreFileSystemManagementClient(context);
            NewResourceManagementClient = GetNewResourceManagementClient(context);
            NetworkClient = GetNetworkClient(context);
            _helper.SetupManagementClients(NewResourceManagementClient, NetworkClient, DataLakeStoreAccountManagementClient);
        }

        #region client creation helpers

        private static NewResourceManagementClient GetNewResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<NewResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static DataLakeStoreAccountManagementClient GetDataLakeStoreAccountManagementClient(MockContext context)
        {
            return context.GetServiceClient<DataLakeStoreAccountManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static void ReSetDataLakeStoreFileSystemManagementClient() { AdlsClientFactory.IsTest = false; }

        private static void SetDataLakeStoreFileSystemManagementClient(MockContext context)
        {
            var currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            AdlsClientFactory.IsTest = true;
            AdlsClientFactory.CustomDelegatingHAndler = ((AdlMockContext)context).GetDelegatingHAndlersForDataPlane(currentEnvironment, new AdlMockDelegatingHandler());
            AdlsClientFactory.MockCredentials = currentEnvironment.TokenInfo[TokenAudience.Management];
        }

        protected NetworkManagementClient GetNetworkClient(MockContext context)
        {
            NetworkManagementClient client =
                context.GetServiceClient<NetworkManagementClient>(
                    TestEnvironmentFactory.GetTestEnvironment());
            return client;
        }
        #endregion
    }
}
