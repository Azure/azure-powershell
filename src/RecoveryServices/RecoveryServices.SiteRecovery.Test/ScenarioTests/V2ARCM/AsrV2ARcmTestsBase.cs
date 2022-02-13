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
using System.Diagnostics;
using System.IO;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using InternalNetwork = Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using Microsoft.Azure.Management.Storage.Version2017_10_01;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.RecoveryServices.Backup;

namespace RecoveryServices.SiteRecovery.Test
{
    public abstract class AsrV2ARCMTestsBase : RMTestBase
    {
        protected string VaultSettingsFilePath;

        protected string PowershellFile;

        private EnvironmentSetupHelper _helper;

        protected void Initialize()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public RecoveryServicesClient RecoveryServicesMgmtClient { get; private set; }

        public SiteRecoveryManagementClient SiteRecoveryMgmtClient { get; private set; }

        public ResourceManagementClient ResourceManagementRestClient { get; private set; }

        public StorageManagementClient StorageClient { get; private set; }

        public ComputeManagementClient ComputeManagementRestClient { get; private set; }

        public RecoveryServicesBackupClient RecoveryServicesBackupClient { get; private set; }

        public void RunPowerShellTest(XunitTracingInterceptor logger, string scenario, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            RunPsTestWorkflow(
                scenario,
                () => scripts,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            string scenario,
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
                {"Microsoft.Storage", null},
                {"Microsoft.Network", null}
            };

            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient", "2016-09-01"}
            };

            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            try
            {
                using (var context = MockContext.Start(callingClassType, mockName))
                {
                    SetupManagementClients(context);

                    _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                    var rmProfileModule = _helper.RMProfileModule;

                    _helper.SetupModules(
                        AzureModule.AzureResourceManager,
                        PowershellFile,
                        rmProfileModule,
                        _helper.GetRMModulePath("AzureRM.Network.psd1"),
                        "AzureRM.Storage.ps1",
                        _helper.GetRMModulePath("AzureRM.Compute.psd1"),
                        _helper.GetRMModulePath("AzureRM.RecoveryServices.psd1"),
#if !NETSTANDARD
                        _helper.GetRMModulePath("AzureRM.RecoveryServices.SiteRecovery.psd1"),
#endif
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
                    }
                }
            }
            catch (UriFormatException)
            {
                // Pass.
            }
        }

        protected void SetupManagementClients(MockContext context)
        {
            ResourceManagementRestClient = GetResourceManagementClientRestClient(context);
            RecoveryServicesMgmtClient = GetRecoveryServicesManagementClient(context);
            SiteRecoveryMgmtClient = GetSiteRecoveryManagementClient(context);
            StorageClient = GetStorageManagementClient(context);
            ComputeManagementRestClient = GetComputeManagementClientRestClient(context);
            RecoveryServicesBackupClient = GetRecoveryServicesBackupClient(context);

            _helper.SetupManagementClients(
                RecoveryServicesMgmtClient,
                SiteRecoveryMgmtClient,
                ResourceManagementRestClient,
                StorageClient,
                ComputeManagementRestClient,
                GetNetworkManagementClientRestClient(context),
                GetNetworkManagementClient(context),
                RecoveryServicesBackupClient);
        }

        private static RecoveryServicesClient GetRecoveryServicesManagementClient(MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClient GetResourceManagementClientRestClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static InternalNetwork.NetworkManagementClient GetNetworkManagementClient(MockContext context)
        {
            return context.GetServiceClient<InternalNetwork.NetworkManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static NetworkManagementClient GetNetworkManagementClientRestClient(MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ComputeManagementClient GetComputeManagementClientRestClient(MockContext context)
        {
            return context.GetServiceClient<ComputeManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static SiteRecoveryManagementClient GetSiteRecoveryManagementClient(MockContext context)
        {
            var client = context.GetServiceClient<SiteRecoveryManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            client.ResourceGroupName = Constants.InMageRcmResourceGroupName;
            client.ResourceName = Constants.InMageRcmResourceName;

            return client;
        }

        private static RecoveryServicesBackupClient GetRecoveryServicesBackupClient(MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesBackupClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
