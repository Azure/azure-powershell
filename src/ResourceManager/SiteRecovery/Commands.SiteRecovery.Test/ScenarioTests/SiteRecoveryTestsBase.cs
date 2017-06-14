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
using Microsoft.Azure.Management.SiteRecovery;
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
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;

namespace Microsoft.Azure.Commands.SiteRecovery.Test.ScenarioTests
{
    public abstract class SiteRecoveryTestsBase : RMTestBase
    {
        private EnvironmentSetupHelper helper;
        protected string vaultSettingsFilePath;
        private ASRVaultCreds asrVaultCreds = null;

        public SiteRecoveryManagementClient SiteRecoveryMgmtClient { get; private set; }
        public SiteRecoveryVaultManagementClient RecoveryServicesMgmtClient { get; private set; }

        protected SiteRecoveryTestsBase()
        {
            this.vaultSettingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScenarioTests\\vaultSettings.VaultCredentials");

            if (File.Exists(this.vaultSettingsFilePath))
            {
                try
                {
                    var serializer1 = new DataContractSerializer(typeof(ASRVaultCreds));
                    using (var s = new FileStream(
                        this.vaultSettingsFilePath,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.Read))
                    {
                        asrVaultCreds = (ASRVaultCreds)serializer1.ReadObject(s);
                    }
                }
                catch (XmlException xmlException)
                {
                    throw new XmlException(
                        "XML is malformed or file is empty", xmlException);
                }
                catch (SerializationException serializationException)
                {
                    throw new SerializationException(
                        "XML is malformed or file is empty", serializationException);
                }
            }
            else
            {
                throw new FileNotFoundException(
                    string.Format(
                        "Vault settings file not found at '{0}', please pass the file downloaded from portal",
                        this.vaultSettingsFilePath));
            }

            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(String scenario)
        {
            RecoveryServicesMgmtClient = GetSiteRecoveryVaultManagementClient(scenario);
            SiteRecoveryMgmtClient = GetSiteRecoveryManagementClient(scenario);

            helper.SetupManagementClients(RecoveryServicesMgmtClient, SiteRecoveryMgmtClient);
        }

        protected void RunPowerShellTest(String scenario, params string[] scripts)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));

                SetupManagementClients(scenario);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\" + this.GetType().Name + ".ps1",
                    helper.RMProfileModule,
                    helper.GetRMModulePath(@"AzureRM.SiteRecovery.psd1"));
                helper.RunPowerShellTest(scripts);
            }
        }

        private SiteRecoveryVaultManagementClient GetSiteRecoveryVaultManagementClient(String scenario)
        {
            return GetServiceClient<SiteRecoveryVaultManagementClient>(scenario);
        }

        private SiteRecoveryManagementClient GetSiteRecoveryManagementClient(String scenario)
        {
            return GetServiceClient<SiteRecoveryManagementClient>(scenario);
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
                    resourceNamespace = "Microsoft.SiteRecovery";
                    resourceType = "SiteRecoveryVault";
                    resourceName = "ReleaseVault";
                    resourceGroupName = "ReleaseResourceGroup";
                    break;

                default:
                    resourceNamespace = "Microsoft.SiteRecoveryBVTD2";
                    resourceType = "SiteRecoveryVault";
                    resourceName = asrVaultCreds.ResourceName;
                    resourceGroupName = asrVaultCreds.ResourceGroupName;
                    break;

            };

            if (typeof(T) == typeof(SiteRecoveryVaultManagementClient))
            {
                SiteRecoveryVaultManagementClient client;

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
                return GetRSMServiceClient<T>(factory, client);
            }
            else
            {
                SiteRecoveryManagementClient client;

                if (testEnvironment.UsesCustomUri())
                {
                    client = new SiteRecoveryManagementClient(
                        resourceName,
                        resourceGroupName,
                        resourceNamespace,
                        resourceType,
                        credentials,
                        testEnvironment.BaseUri);
                }

                else
                {
                    client = new SiteRecoveryManagementClient(
                        resourceName,
                        resourceGroupName,
                        resourceNamespace,
                        resourceType,
                        credentials);
                }

                return GetSRMServiceClient<T>(factory, client);
            }

        }

        public static T GetRSMServiceClient<T>(TestEnvironmentFactory factory, SiteRecoveryVaultManagementClient client) where T : class
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

        public static T GetSRMServiceClient<T>(TestEnvironmentFactory factory, SiteRecoveryManagementClient client) where T : class
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