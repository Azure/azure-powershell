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


using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NewResourceManagementClient = Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System.IO;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Management.Synapse;
using Microsoft.Azure.Synapse;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Azure.Management.Storage;

namespace Microsoft.Azure.Commands.Synapse.Test.ScenarioTests
{
    public class SynapseTestBase : RMTestBase
    {
        internal string ResourceGroupName { get; set; }
        internal const string ResourceGroupLocation = "northeurope";

        protected readonly EnvironmentSetupHelper _helper;

        public NewResourceManagementClient NewResourceManagementClient { get; private set; }

        public SynapseManagementClient SynapseManagementClient { get; private set; }

        public SynapseSqlV3ManagementClient SynapseSqlV3ManagementClient { get; private set; }

        public SynapseClient SynapseClient { get; private set; }

        public StorageManagementClient StorageManagementClient { get; private set; }

        public static SynapseTestBase NewInstance => new SynapseTestBase();

        protected static string TestResourceGroupName;

        protected static string TestWorkspaceName;

        protected static string TestSparkPoolName;

        protected SynapseTestBase()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            _helper.TracingInterceptor = logger;
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

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
                {"Microsoft.Authorization", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                {"Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2017-05-10"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(
                    AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"Az.Synapse.psd1"),
                    "AzureRM.Resources.ps1",
                    _helper.GetRMModulePath(@"Az.Storage.psd1"));

                try
                {
                    var psScripts = scriptBuilder?.Invoke();

                    if (psScripts == null) return;
                    _helper.RunPowerShellTest(psScripts);
                }
                finally
                {
                    cleanup?.Invoke();
                }
            }
        }

        protected void SetupManagementClients(MockContext context)
        {
            SynapseManagementClient = GetSynapseManagementClient(context);
            SynapseSqlV3ManagementClient = GetSynapseSqlV3ManagementClient(context);
            SynapseClient = GetSynapseClient(context);
            StorageManagementClient = GetStorageManagementClient(context);
            NewResourceManagementClient = GetResourceManagementClient(context);
            _helper.SetupManagementClients(
                SynapseManagementClient,
                SynapseSqlV3ManagementClient,
                SynapseClient,
                StorageManagementClient,
                NewResourceManagementClient
            );

            // register the namespace.
            _helper.SetupEnvironment(AzureModule.AzureResourceManager);
        }

        private void SetupDataPlaneClient(MockContext context)
        {
            _helper.SetupManagementClients(
                GetResourceManagementClient(context), 
                GetSynapseManagementClient(context), 
                GetSynapseClient(context)
            );
        }

        #region client creation helpers
        protected static NewResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<NewResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected static StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected static SynapseManagementClient GetSynapseManagementClient(MockContext context)
        {
            return context.GetServiceClient<SynapseManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected static SynapseSqlV3ManagementClient GetSynapseSqlV3ManagementClient(MockContext context)
        {
            return context.GetServiceClient<SynapseSqlV3ManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected static SynapseClient GetSynapseClient(MockContext context)
        {
            string environmentConnectionString = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
            string accessToken = "fakefakefake";

            // When recording, we should have a connection string passed into the code from the environment
            if (!string.IsNullOrEmpty(environmentConnectionString))
            {
                // Gather test client credential information from the environment
                var connectionInfo = new ConnectionString(Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION"));
                string servicePrincipal = connectionInfo.GetValue<string>(ConnectionStringKeys.ServicePrincipalKey);
                string servicePrincipalSecret = connectionInfo.GetValue<string>(ConnectionStringKeys.ServicePrincipalSecretKey);
                string aadTenant = connectionInfo.GetValue<string>(ConnectionStringKeys.AADTenantKey);

                // Create credentials
                var clientCredentials = new ClientCredential(servicePrincipal, servicePrincipalSecret);
                var authContext = new AuthenticationContext($"https://login.windows.net/{aadTenant}", TokenCache.DefaultShared);
                accessToken = authContext.AcquireTokenAsync("https://dev.azuresynapse.net", clientCredentials).Result.AccessToken;
            }

            return new SynapseClient(new TokenCredentials(accessToken), HttpMockServer.CreateInstance());
        }
        #endregion
    }
}
