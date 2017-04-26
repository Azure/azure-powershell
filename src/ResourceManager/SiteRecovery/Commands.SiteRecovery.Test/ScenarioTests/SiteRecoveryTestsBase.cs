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
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Management.SiteRecoveryVault;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.Authentication;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using Microsoft.Azure.Management.RecoveryServices;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.SiteRecovery.Test.ScenarioTests
{
    public abstract class SiteRecoveryTestsBase : RMTestBase
    {
        CSMTestEnvironmentFactory csmTestFactory;
        private EnvironmentSetupHelper helper;

        public SiteRecoveryVaultManagementClient SiteRecoveryVaultMgmtClient { get; private set; }
        public SiteRecoveryManagementClient SiteRecoveryMgmtClient { get; private set; }
        public RecoveryServicesManagementClient RecoveryServicesMgmtClient { get; private set; }

        protected SiteRecoveryTestsBase()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(String scenario, RestTestFramework.MockContext context)
        {
            SiteRecoveryVaultMgmtClient = GetSiteRecoveryVaultManagementClient(scenario);
            RecoveryServicesMgmtClient = GetRecoveryServicesManagementClient(scenario);
            SiteRecoveryMgmtClient = GetSiteRecoveryManagementClient(scenario, context);
            helper.SetupManagementClients(SiteRecoveryMgmtClient, RecoveryServicesMgmtClient, SiteRecoveryVaultMgmtClient);
        }

        public void RunPowerShellTest(String scenario, params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            RunPsTestWorkflow(
                scenario,
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            String scenario,
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

                SetupManagementClients(scenario, context);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var testFolderName = scenario;
                var callingClassName =
                    callingClassType
                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                string psFile =
                    "ScenarioTests\\" + callingClassName + ".ps1";
                string commonPsFile = "ScenarioTests\\" + testFolderName + "\\Common.ps1";
                string rmProfileModule = helper.RMProfileModule;
                string rmModulePath = helper.GetRMModulePath("AzureRM.SiteRecovery.psd1");
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

        private SiteRecoveryVaultManagementClient GetSiteRecoveryVaultManagementClient(String scenario)
        {
            return GetServiceClient<SiteRecoveryVaultManagementClient>(scenario);
        }

        private RecoveryServicesManagementClient GetRecoveryServicesManagementClient(String scenario)
        {
            return GetServiceClient<RecoveryServicesManagementClient>(scenario);
        }

        private SiteRecoveryManagementClient GetSiteRecoveryManagementClient(String scenario, RestTestFramework.MockContext context)
        {
            var resourceGroupName = "";
            var resourceName = "";
            switch (scenario)
            {
                case Constants.NewModel:
                    resourceName = "b2aRSvaultprod17012017";
                    resourceGroupName = "siterecoveryprod1";
                    break;

                default:
                    resourceName = "";
                    resourceGroupName = "";
                    break;
            };

            var client = GetSiteRecoveryManagementClient(context);
            client.ResourceGroupName = resourceGroupName;
            client.ResourceName = resourceName;

            return client;
        }

        public T GetServiceClient<T>(String scenario) where T : class
        {
            var factory = (TestEnvironmentFactory)new CSMTestEnvironmentFactory();
            var testEnvironment = factory.GetTestEnvironment();

            ServicePointManager.ServerCertificateValidationCallback = IgnoreCertificateErrorHandler;

            var credentials = new SubscriptionCredentialsAdapter(
                testEnvironment.AuthorizationContext.TokenCredentials[TokenAudience.Management],
                testEnvironment.SubscriptionId);
            var resourceNamespace = "";
            var resourceType = "";
            var resourceName = "";
            var resourceGroupName = "";

            switch (scenario)
            {
                case Constants.NewModel:
                    resourceNamespace = "Microsoft.RecoveryServices";
                    resourceType = "vaults";
                    resourceName = "b2aRSvaultprod17012017";
                    resourceGroupName = "siterecoveryprod1";
                    break;

                default:
                    resourceNamespace = "Microsoft.RecoveryServices";
                    resourceType = "vaults";
                    resourceName = "";
                    resourceGroupName = "";
                    break;
            };

            if (typeof(T) == typeof(RecoveryServicesManagementClient))
            {
                RecoveryServicesManagementClient client = null;

                if (testEnvironment.UsesCustomUri())
                {
                    client = new RecoveryServicesManagementClient(
                        resourceNamespace,
                        credentials,
                        testEnvironment.BaseUri);
                }

                else
                {
                    client = new RecoveryServicesManagementClient(
                        resourceNamespace,
                        credentials);
                }

                return GetRSMServiceClient<T>(factory, client);
            }
            else if(typeof(T) == typeof(SiteRecoveryVaultManagementClient))
            {
                SiteRecoveryVaultManagementClient client = null;

                if (testEnvironment.UsesCustomUri())
                {
                    client = new SiteRecoveryVaultManagementClient(
                        resourceNamespace,
                        resourceType,
                        credentials,
                        testEnvironment.BaseUri);
                }

                else
                {
                    client = new SiteRecoveryVaultManagementClient(
                        resourceNamespace,
                        resourceType,
                        credentials);
                }

                return GetSRVMServiceClient<T>(factory, client);
            }

            return null;
        }

        public static T GetRSMServiceClient<T>(TestEnvironmentFactory factory, RecoveryServicesManagementClient client) where T : class
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

        public static T GetSRVMServiceClient<T>(TestEnvironmentFactory factory, SiteRecoveryVaultManagementClient client) where T : class
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

        private SiteRecoveryManagementClient GetSiteRecoveryManagementClient(
            RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<SiteRecoveryManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}