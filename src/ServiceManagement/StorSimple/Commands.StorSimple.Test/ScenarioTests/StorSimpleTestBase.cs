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

using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Reflection;
using Microsoft.Azure;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Management.Scheduler;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.Azure.Test.Authentication;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Test.ScenarioTests
{
    public class StorSimpleTestBase
    {
        private EnvironmentSetupHelper helper;
        private RDFETestEnvironmentFactory rdfeTestFactory;

        protected StorSimpleTestBase()
        {
            this.helper = new EnvironmentSetupHelper();
            this.rdfeTestFactory = new RDFETestEnvironmentFactory();
        }

        protected void SetupManagementClients()
        {
            var storSimpleManagementClient = GetStorSimpleClient();
            var cloudServiceClient = GetCloudServiceClient();
            helper.SetupSomeOfManagementClients(storSimpleManagementClient, cloudServiceClient);

            //helper.SetupSomeOfManagementClients();
        }

        private StorSimpleManagementClient GetStorSimpleClient()
        {
            try
            {
                //var testEnvironment = this.rdfeTestFactory.GetTestEnvironment();
                
                var storSimpleClient = GetServiceClient<StorSimpleManagementClient>();
                
                //var storSimpleClient = new StorSimpleManagementClient("", "", "", "", "",
                //    testEnvironment.Credentials as SubscriptionCloudCredentials, testEnvironment.BaseUri).WithHandler(HttpMockServer.CreateInstance());
                return storSimpleClient;
            }
            catch (ReflectionTypeLoadException leException)
            {
                
                throw leException;
            }
            
        }

        private CloudServiceManagementClient GetCloudServiceClient()
        {
            return TestBase.GetServiceClient<CloudServiceManagementClient>(this.rdfeTestFactory);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));
                
                SetupManagementClients();
                
                helper.SetupEnvironment(AzureModule.AzureServiceManagement);
                
                helper.SetupModules(AzureModule.AzureServiceManagement, "ScenarioTests\\" + this.GetType().Name + ".ps1");
                helper.RunPowerShellTest(scripts);
            }
        }

        public static T GetServiceClient<T>() where T : class
        {
            var factory = (TestEnvironmentFactory)new RDFETestEnvironmentFactory();

            var testEnvironment = factory.GetTestEnvironment();

            ServicePointManager.ServerCertificateValidationCallback = IgnoreCertificateErrorHandler;

            StorSimpleManagementClient client;
            var credentials = new SubscriptionCredentialsAdapter(
                testEnvironment.AuthorizationContext.TokenCredentials[TokenAudience.Management],
                testEnvironment.SubscriptionId);

            if (testEnvironment.UsesCustomUri())
            {
                client = new StorSimpleManagementClient(
                    ConfigurationManager.AppSettings["CloudServiceName"],
                    ConfigurationManager.AppSettings["ResourceName"],
                    ConfigurationManager.AppSettings["ResourceId"],
                    ConfigurationManager.AppSettings["ResourceNamespace"],
                    credentials,
                    testEnvironment.BaseUri);
            }

            else
            {
                client = new StorSimpleManagementClient(
                    ConfigurationManager.AppSettings["CloudServiceName"],
                    ConfigurationManager.AppSettings["ResourceName"],
                    ConfigurationManager.AppSettings["ResourceId"],
                    ConfigurationManager.AppSettings["ResourceNamespace"],
                    credentials);
            }

            return GetServiceClient<T>(factory, client);
        }

        public static T GetServiceClient<T>(TestEnvironmentFactory factory, StorSimpleManagementClient client) where T : class
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
    }
}