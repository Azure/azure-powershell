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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Test.ScenarioTests
{
    public abstract class AsrTestsBase : RMTestBase
    {
        public ResourceManagementClient RmRestClient { get; private set; }
        public RecoveryServicesClient RecoveryServicesMgmtClient { get; private set; }
        public SiteRecoveryManagementClient SiteRecoveryMgmtClient { get; private set; }
        private readonly ASRVaultCreds asrVaultCreds;
        private CSMTestEnvironmentFactory csmTestFactory;
        private readonly EnvironmentSetupHelper helper;
        protected string vaultSettingsFilePath;

        protected AsrTestsBase()
        {
            vaultSettingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests\\vaultSettings.VaultCredentials");

            if (File.Exists(vaultSettingsFilePath))
            {
                try
                {
                    var serializer1 = new DataContractSerializer(typeof(ASRVaultCreds));
                    using (var s = new FileStream(vaultSettingsFilePath,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.Read))
                    {
                        asrVaultCreds = (ASRVaultCreds) serializer1.ReadObject(s);
                    }
                }
                catch (XmlException xmlException)
                {
                    throw new XmlException("XML is malformed or file is empty",
                        xmlException);
                }
                catch (SerializationException serializationException)
                {
                    throw new SerializationException("XML is malformed or file is empty",
                        serializationException);
                }
            }
            else
            {
                throw new FileNotFoundException(
                    string.Format(
                        "Vault settings file not found at '{0}', please pass the file downloaded from portal",
                        vaultSettingsFilePath));
            }

            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(string scenario,
            RestTestFramework.MockContext context)
        {
            RmRestClient = GetRmRestClient(context);
            RecoveryServicesMgmtClient = GetRecoveryServicesManagementClient(context);
            SiteRecoveryMgmtClient = GetSiteRecoveryManagementClient(scenario,
                context);
            helper.SetupManagementClients(RmRestClient,
                RecoveryServicesMgmtClient,
                SiteRecoveryMgmtClient);
        }

        public void RunPowerShellTest(string scenario,
            params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            RunPsTestWorkflow(scenario,
                () => scripts,

                // no custom initializer
                null,

                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(string scenario,
            Func<string[]> scriptBuilder,
            Action<CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            var providers = new Dictionary<string, string>();
            providers.Add("Microsoft.Resources",
                null);
            providers.Add("Microsoft.Features",
                null);
            providers.Add("Microsoft.Authorization",
                null);
            providers.Add("Microsoft.Compute",
                null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient",
                "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true,
                providers,
                providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "SessionRecords");

            using (var context = RestTestFramework.MockContext.Start(callingClassType,
                mockName))
            {
                csmTestFactory = new CSMTestEnvironmentFactory();

                if (initialize != null)
                {
                    initialize.Invoke(csmTestFactory);
                }

                SetupManagementClients(scenario,
                    context);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var testFolderName = scenario;
                var callingClassName = callingClassType.Split(new[] {"."},
                        StringSplitOptions.RemoveEmptyEntries)
                    .Last();
                var psFile = "ScenarioTests\\" + callingClassName + ".ps1";
                var rmProfileModule = helper.RMProfileModule;
                var rmModulePath =
                    helper.GetRMModulePath("AzureRM.RecoveryServices.SiteRecovery.psd1");
                var recoveryServicesModulePath =
                    helper.GetRMModulePath("AzureRM.RecoveryServices.psd1");

                var modules = new List<string>();

                modules.Add(psFile);
                modules.Add(rmProfileModule);
                modules.Add(rmModulePath);
                modules.Add(recoveryServicesModulePath);

                helper.SetupModules(AzureModule.AzureResourceManager,
                    modules.ToArray());

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

        private SiteRecoveryManagementClient GetSiteRecoveryManagementClient(string scenario,
            RestTestFramework.MockContext context)
        {
            var resourceGroupName = "";
            var resourceName = "";
            switch (scenario)
            {
                case Constants.NewModel:
                    resourceName = asrVaultCreds.ResourceName;
                    resourceGroupName = asrVaultCreds.ResourceGroupName;
                    break;

                default:
                    resourceName = asrVaultCreds.ResourceName;
                    resourceGroupName = asrVaultCreds.ResourceGroupName;
                    break;
            }

            ;

            var client = GetSiteRecoveryManagementClient(context);
            client.ResourceGroupName = resourceGroupName;
            client.ResourceName = resourceName;

            return client;
        }

        private static bool IgnoreCertificateErrorHandler(object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private RecoveryServicesClient GetRecoveryServicesManagementClient(
            RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesClient>(RestTestFramework
                .TestEnvironmentFactory.GetTestEnvironment());
        }

        private SiteRecoveryManagementClient GetSiteRecoveryManagementClient(
            RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<SiteRecoveryManagementClient>(RestTestFramework
                .TestEnvironmentFactory.GetTestEnvironment());
        }

        private ResourceManagementClient GetRmRestClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(RestTestFramework
                .TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}