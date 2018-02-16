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
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Reflection;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using LegacyTest = Microsoft.Azure.Test;
using Microsoft.Azure.Test.Authentication;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using HyakRmNS = Microsoft.Azure.Management.Internal.Resources;
using RecoveryServicesNS = Microsoft.Azure.Management.RecoveryServices;
using ResourceManagementNS = Microsoft.Azure.Management.Resources;
using ResourceManagementRestNS = Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using StorageMgmtNS = Microsoft.Azure.Management.Storage;
using NetworkMgmtNS = Microsoft.Azure.Management.Network;
using ComputeMgmtNS = Microsoft.Azure.Management.Compute;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.ScenarioTests
{
    public class TestController
    {
        LegacyTest.CSMTestEnvironmentFactory csmTestFactory;
        EnvironmentSetupHelper helper;

        public RecoveryServicesBackupClient RsBackupClient { get; private set; }

        public RecoveryServicesNS.RecoveryServicesClient RsClient { get; private set; }

        public ResourceManagementNS.ResourceManagementClient RmClient { get; private set; }

        public ResourceManagementRestNS.ResourceManagementClient RmRestClient { get; private set; }

        public HyakRmNS.ResourceManagementClient HyakRmClient { get; private set; }

        public StorageMgmtNS.StorageManagementClient StorageClient { get; private set; }

        public NetworkMgmtNS.NetworkManagementClient NetworkManagementClient { get; private set; }

        public ComputeMgmtNS.ComputeManagementClient ComputeManagementClient { get; private set; }

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

        protected void SetupManagementClients(MockContext context)
        {
            RsBackupClient = GetRsBackupClient(context);
            RsClient = GetRsClient(context);
            RmClient = GetRmClient();
            RmRestClient = GetRmRestClient(context);
            HyakRmClient = GetHyakRmClient(context);

            StorageClient = GetStorageManagementClient(context);
            NetworkManagementClient = GetNetworkManagementClient(context);
            ComputeManagementClient = GetComputeManagementClient(context);

            helper.SetupManagementClients(
                RsBackupClient,
                RsClient,
                RmClient,
                RmRestClient,
                HyakRmClient,
                StorageClient,
                NetworkManagementClient,
                ComputeManagementClient);
        }

        private StorageMgmtNS.StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageMgmtNS.StorageManagementClient>(
                TestEnvironmentFactory.GetTestEnvironment());
        }

        private NetworkMgmtNS.NetworkManagementClient GetNetworkManagementClient(MockContext context)
        {
            return context.GetServiceClient<NetworkMgmtNS.NetworkManagementClient>(
                TestEnvironmentFactory.GetTestEnvironment());
        }

        private ComputeMgmtNS.ComputeManagementClient GetComputeManagementClient(MockContext context)
        {
            return context.GetServiceClient<ComputeMgmtNS.ComputeManagementClient>(
                TestEnvironmentFactory.GetTestEnvironment());
        }

        private ResourceManagementNS.ResourceManagementClient GetRmClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ResourceManagementNS.ResourceManagementClient>(
                this.csmTestFactory);
        }

        private ResourceManagementRestNS.ResourceManagementClient GetRmRestClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementRestNS.ResourceManagementClient>(
                TestEnvironmentFactory.GetTestEnvironment());
        }

        private HyakRmNS.ResourceManagementClient GetHyakRmClient(MockContext context)
        {
            return context.GetServiceClient<HyakRmNS.ResourceManagementClient>(
                TestEnvironmentFactory.GetTestEnvironment());
        }

        public Collection<PSObject> RunPsTest(PsBackupProviderTypes providerType, params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            return RunPsTestWorkflow(
                providerType,
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup
                null,
                callingClassType,
                mockName);
        }

        public Collection<PSObject> RunPsTestWorkflow(
            PsBackupProviderTypes providerType,
            Func<string[]> scriptBuilder,
            Action<LegacyTest.CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            Dictionary<string, string> providers = new Dictionary<string, string>();
            providers.Add("Microsoft.Resources", null);
            providers.Add("Microsoft.Features", null);
            providers.Add("Microsoft.Authorization", null);
            providers.Add("Microsoft.Compute", null);
            providers.Add("Microsoft.Network", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);

            HttpMockServer.RecordsDirectory =
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                csmTestFactory = new LegacyTest.CSMTestEnvironmentFactory();

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
                modules.Add(helper.RMResourceModule);
                modules.Add(helper.RMStorageDataPlaneModule);
                modules.Add(helper.RMStorageModule);
                modules.Add(helper.GetRMModulePath("AzureRM.Compute.psd1"));
                modules.Add(helper.GetRMModulePath("AzureRM.Network.psd1"));
                modules.Add("AzureRM.Storage.ps1");
                modules.Add("AzureRM.Resources.ps1");

                helper.SetupModules(AzureModule.AzureResourceManager, modules.ToArray());

                try
                {
                    if (scriptBuilder != null)
                    {
                        var psScripts = scriptBuilder();

                        if (psScripts != null)
                        {
                            return helper.RunPowerShellTest(psScripts);
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

            return null;
        }

        private RecoveryServicesNS.RecoveryServicesClient GetRsClient(MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesNS.RecoveryServicesClient>(
                TestEnvironmentFactory.GetTestEnvironment());
        }

        private static bool IgnoreCertificateErrorHandler
           (object sender,
           System.Security.Cryptography.X509Certificates.X509Certificate certificate,
           System.Security.Cryptography.X509Certificates.X509Chain chain,
           SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private RecoveryServicesBackupClient GetRsBackupClient(MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesBackupClient>(
                TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}