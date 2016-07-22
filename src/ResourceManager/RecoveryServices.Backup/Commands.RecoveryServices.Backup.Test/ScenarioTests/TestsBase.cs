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

using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Reflection;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.Test.Authentication;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.ScenarioTests
{
    public abstract class TestsBase : RMTestBase
    {
        CSMTestEnvironmentFactory csmTestFactory;
        EnvironmentSetupHelper helper;

        public RecoveryServicesBackupManagementClient RsBackupClient { get; private set; }

        protected string ResourceNamespace { get; private set; }

        protected TestsBase()
        {
            this.helper = new EnvironmentSetupHelper();
            this.csmTestFactory = new CSMTestEnvironmentFactory();
            ResourceNamespace = "Microsoft.RecoveryServices";
        }

        protected void SetResourceNamespace(string resourceNamespace)
        {
            ResourceNamespace = resourceNamespace;
        }

        protected void SetupManagementClients()
        {
            RsBackupClient = GetRsBackupClient();

            helper.SetupSomeOfManagementClients(RsBackupClient);
        }

        protected void RunPowerShellTest(string testFolderName, params string[] scripts)
        {
            Dictionary<string, string> providers = new Dictionary<string, string>();
            providers.Add("Microsoft.Resources", null);
            providers.Add("Microsoft.Features", null);
            providers.Add("Microsoft.Authorization", null);
            providers.Add("Microsoft.Compute", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);

            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));

                string psFile = "ScenarioTests\\" + testFolderName + "\\" + this.GetType().Name + ".ps1";
                string commonPsFile = "ScenarioTests\\" + testFolderName + "\\Common.ps1";
                string rmProfileModule = helper.RMProfileModule;
                string rmModulePath = helper.GetRMModulePath("AzureRM.RecoveryServices.Backup.psd1");
                string recoveryServicesModulePath =
                    helper.GetRMModulePath("AzureRM.RecoveryServices.psd1");

                SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

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
                helper.RunPowerShellTest(scripts);
            }
        }

        private RecoveryServicesBackupManagementClient GetRsBackupClient()
        {
            var factory = (TestEnvironmentFactory)new CSMTestEnvironmentFactory();

            var testEnvironment = factory.GetTestEnvironment();

            ServicePointManager.ServerCertificateValidationCallback = IgnoreCertificateErrorHandler;

            RecoveryServicesBackupManagementClient client;
            var credentials = new SubscriptionCredentialsAdapter(
                testEnvironment.AuthorizationContext.TokenCredentials[TokenAudience.Management],
                testEnvironment.SubscriptionId);

            if (testEnvironment.UsesCustomUri())
            {
                client = new RecoveryServicesBackupManagementClient(
                    credentials,
                    testEnvironment.BaseUri);
            }

            else
            {
                client = new RecoveryServicesBackupManagementClient(
                    credentials);
            }

            client.ResourceNamespace = this.ResourceNamespace;

            return GetServiceClient<RecoveryServicesBackupManagementClient>(factory, client);
        }

        public static T GetServiceClient<T>(TestEnvironmentFactory factory, RecoveryServicesBackupManagementClient client) where T : class
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
                    property1.SetValue((object)obj2, (object)-1);
                    property2.SetValue((object)obj2, (object)-1);
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
    }
}