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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.Storage.Version2017_10_01;
using Microsoft.Azure.ServiceManagement.Common.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.ScenarioTests
{
    public class TestController
    {
        private readonly EnvironmentSetupHelper _helper;

        public RecoveryServicesBackupClient RsBackupClient { get; private set; }

        public RecoveryServicesClient RsClient { get; private set; }

        public ResourceManagementClient RmRestClient { get; private set; }

        public StorageManagementClient StorageClient { get; private set; }

        public NetworkManagementClient NetworkManagementClient { get; private set; }

        public ComputeManagementClient ComputeManagementClient { get; private set; }

        protected string ResourceNamespace { get; private set; }

        public static TestController NewInstance => new TestController();

        public TestController()
        {
            _helper = new EnvironmentSetupHelper();
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
            RmRestClient = GetRmRestClient(context);

            StorageClient = GetStorageManagementClient(context);
            NetworkManagementClient = GetNetworkManagementClient(context);
            ComputeManagementClient = GetComputeManagementClient(context);

            _helper.SetupManagementClients(
                RsBackupClient,
                RsClient,
                RmRestClient,
                StorageClient,
                NetworkManagementClient,
                ComputeManagementClient);
        }

        public Collection<PSObject> RunPsTest(XunitTracingInterceptor logger, PsBackupProviderTypes providerType, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;

            return RunPsTestWorkflow(
                providerType,
                () => scripts,
                // no custom cleanup
                null,
                callingClassType,
                mockName);
        }

        public Collection<PSObject> RunPsTestWorkflow(
            PsBackupProviderTypes providerType,
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            var providers = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null},
                {"Microsoft.Compute", null},
                {"Microsoft.Network", null},
                {"Microsoft.Storage", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                {"Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient", "2016-02-01"}
            };

            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var testFolderName = providerType.ToString();
                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                var modules = new List<string>
                {
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + testFolderName + "\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath("AzureRM.RecoveryServices.psd1"),
                    _helper.GetRMModulePath("AzureRM.Compute.psd1"),
                    _helper.GetRMModulePath("AzureRM.Network.psd1"),
                    "AzureRM.Storage.ps1",
                    "AzureRM.Resources.ps1"
                };

                var workloadCommonPsFile = Path.Combine("ScenarioTests", testFolderName, "Common.ps1");
                if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, workloadCommonPsFile)))
                {
                    modules.Add(workloadCommonPsFile);
                }

                _helper.SetupModules(AzureModule.AzureResourceManager, modules.ToArray());

                try
                {
                    var psScripts = scriptBuilder?.Invoke();
                    if (psScripts != null)
                    {
                        return _helper.RunPowerShellTest(psScripts);
                    }
                }
                finally
                {
                    cleanup?.Invoke();
                }
            }

            return null;
        }

        private static RecoveryServicesClient GetRsClient(MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static RecoveryServicesBackupClient GetRsBackupClient(MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesBackupClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static NetworkManagementClient GetNetworkManagementClient(MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ComputeManagementClient GetComputeManagementClient(MockContext context)
        {
            return context.GetServiceClient<ComputeManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClient GetRmRestClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}