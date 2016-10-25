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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.Authentication;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Reflection;
using HyakRmNS = Microsoft.Azure.Management.Internal.Resources;
using RecoveryServicesNS = Microsoft.Azure.Management.RecoveryServices;
using ResourceManagementNS = Microsoft.Azure.Management.Resources;
using ResourceManagementRestNS = Microsoft.Azure.Management.ResourceManager;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.ScenarioTests
{
    public class TestController
    {
        CSMTestEnvironmentFactory csmTestFactory;
        EnvironmentSetupHelper helper;

        public RecoveryServicesBackupClient RsBackupClient { get; private set; }

        public RecoveryServicesNS.RecoveryServicesManagementClient RsClient { get; private set; }

        public ResourceManagementNS.ResourceManagementClient RmClient { get; private set; }

        public ResourceManagementRestNS.ResourceManagementClient RmRestClient { get; private set; }

        public HyakRmNS.ResourceManagementClient HyakRmClient { get; private set; }

        protected string ResourceNamespace { get; private set; }

        public static TestController NewInstance
        {
            get
            {
                return new TestController();
            }
        }

        public TestController()
        {
            this.helper = new EnvironmentSetupHelper();
            ResourceNamespace = "Microsoft.RecoveryServices";
        }

        protected void SetResourceNamespace(string resourceNamespace)
        {
            ResourceNamespace = resourceNamespace;
        }

        protected void SetupManagementClients(RestTestFramework.MockContext context)
        {
            RsBackupClient = GetRsBackupClient(context);
            RsClient = GetRsClient();
            RmClient = GetRmClient();
            RmRestClient = GetRmRestClient(context);
            HyakRmClient = GetHyakRmClient();

            helper.SetupManagementClients(
                RsBackupClient,
                RsClient,
                RmClient,
                RmRestClient,
                HyakRmClient);
        }

        private ResourceManagementNS.ResourceManagementClient GetRmClient()
        {
            return TestBase.GetServiceClient<ResourceManagementNS.ResourceManagementClient>(
                this.csmTestFactory);
        }

        private ResourceManagementRestNS.ResourceManagementClient GetRmRestClient(
            RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ResourceManagementRestNS.ResourceManagementClient>(
                RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private HyakRmNS.ResourceManagementClient GetHyakRmClient()
        {
            return TestBase.GetServiceClient<HyakRmNS.ResourceManagementClient>(
                this.csmTestFactory);
        }

        public void RunPsTest(PsBackupProviderTypes providerType, params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            RunPsTestWorkflow(
                providerType,
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            PsBackupProviderTypes providerType,
            Func<string[]> scriptBuilder,
            Action<CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            Dictionary<string, string> providers = new Dictionary<string, string>();
            providers.Add("Microsoft.Resources", null);
            providers.Add("Microsoft.Features", null);
            providers.Add("Microsoft.Authorization", null);
            providers.Add("Microsoft.Compute", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);

            HttpMockServer.RecordsDirectory = 
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (RestTestFramework.MockContext context = 
                RestTestFramework.MockContext.Start(callingClassType, mockName))
            {
                csmTestFactory = new CSMTestEnvironmentFactory();

                if (initialize != null)
                {
                    initialize.Invoke(csmTestFactory);
                }

                SetupManagementClients(context);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var testFolderName = providerType.ToString();
                var callingClassName = 
                    callingClassType
                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                string psFile = 
                    "ScenarioTests\\" + testFolderName + "\\" + callingClassName + ".ps1";
                string commonPsFile = "ScenarioTests\\" + testFolderName + "\\Common.ps1";
                string rmProfileModule = helper.RMProfileModule;
                string rmModulePath = helper.GetRMModulePath("AzureRM.RecoveryServices.Backup.psd1");
                string recoveryServicesModulePath =
                    helper.GetRMModulePath("AzureRM.RecoveryServices.psd1");

                List<string> modules = new List<string>();

                if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, commonPsFile)))
                {
                    modules.Add(commonPsFile);
                }

                modules.Add(psFile);
                modules.Add(rmProfileModule);
                modules.Add(rmModulePath);
                modules.Add(recoveryServicesModulePath);

                helper.SetupModules(AzureModule.AzureResourceManager, modules.ToArray());

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
                        cleanup.Invoke();
                    }
                }
            }
        }

        private RecoveryServicesNS.RecoveryServicesManagementClient GetRsClient()
        {
            return GetServiceClient<RecoveryServicesNS.RecoveryServicesManagementClient>();
        }

        public static T GetServiceClient<T>() where T : class
        {
            var factory = (TestEnvironmentFactory)new CSMTestEnvironmentFactory();
            var testEnvironment = factory.GetTestEnvironment();

            ServicePointManager.ServerCertificateValidationCallback = IgnoreCertificateErrorHandler;

            RecoveryServicesNS.RecoveryServicesManagementClient client;
            var credentials = new SubscriptionCredentialsAdapter(
                testEnvironment.AuthorizationContext.TokenCredentials[TokenAudience.Management],
                testEnvironment.SubscriptionId);

            if (testEnvironment.UsesCustomUri())
            {
                client = new RecoveryServicesNS.RecoveryServicesManagementClient(
                    "Microsoft.RecoveryServices",
                    credentials,
                    testEnvironment.BaseUri);
            }
            else
            {
                client = new RecoveryServicesNS.RecoveryServicesManagementClient(
                    "Microsoft.RecoveryServices",
                    credentials);
            }
            return GetServiceClient<T>(factory, client);
        }

        public static T GetServiceClient<T>(
            TestEnvironmentFactory factory, 
            RecoveryServicesNS.RecoveryServicesManagementClient client) where T : class
        {
            TestEnvironment testEnvironment = factory.GetTestEnvironment();

            HttpMockServer instance;
            try
            {
                instance = HttpMockServer.CreateInstance();
            }
            catch (ApplicationException)
            {
                HttpMockServer.Initialize("TestEnvironment", "InitialCreation");
                instance = HttpMockServer.CreateInstance();
            }
            T obj2 = typeof(T).GetMethod("WithHandler", new Type[1]
            {
                typeof (DelegatingHandler)
            }).Invoke((object)client, new object[1]
            {
                (object) instance
            }) as T;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables[TestEnvironment.SubscriptionIdKey] = testEnvironment.SubscriptionId;
            }

            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                PropertyInfo property1 = typeof(T).GetProperty("LongRunningOperationInitialTimeout", typeof(int));
                PropertyInfo property2 = typeof(T).GetProperty("LongRunningOperationRetryTimeout", typeof(int));
                if (property1 != (PropertyInfo)null && property2 != (PropertyInfo)null)
                {
                    property1.SetValue((object)obj2, (object)0);
                    property2.SetValue((object)obj2, (object)0);
                }
            }
            return obj2;
        }

        private static bool IgnoreCertificateErrorHandler
           (object sender,
           System.Security.Cryptography.X509Certificates.X509Certificate certificate,
           System.Security.Cryptography.X509Certificates.X509Chain chain,
           SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private RecoveryServicesBackupClient GetRsBackupClient(
            RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesBackupClient>(
                RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}