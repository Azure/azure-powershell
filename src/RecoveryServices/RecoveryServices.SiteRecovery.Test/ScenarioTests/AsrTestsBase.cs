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
using RuntimeSerialization = System.Runtime.Serialization;
using System.Xml;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.ServiceManagement.Common.Models;
using System.Diagnostics;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace RecoveryServices.SiteRecovery.Test
{
    public abstract class AsrTestsBase : RMTestBase
    {
        protected string VaultSettingsFilePath;
        protected string PowershellFile;
        private ASRVaultCreds _asrVaultCreds;
        private EnvironmentSetupHelper _helper;

        protected void Initialize()
        {
            try
            {
                if (FileUtilities.DataStore.ReadFileAsText(VaultSettingsFilePath).ToLower().Contains("<asrvaultcreds"))
                {
                    var serializer1 = new RuntimeSerialization.DataContractSerializer(typeof(ASRVaultCreds));
                    using (var s = new FileStream(VaultSettingsFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        _asrVaultCreds = (ASRVaultCreds)serializer1.ReadObject(s);
                    }
                }
                else
                {
                    var serializer = new RuntimeSerialization.DataContractSerializer(typeof(RSVaultAsrCreds));
                    using (var s = new FileStream(VaultSettingsFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        var aadCreds = (RSVaultAsrCreds)serializer.ReadObject(s);
                        _asrVaultCreds = new ASRVaultCreds
                        {
                            ChannelIntegrityKey = aadCreds.ChannelIntegrityKey,
                            ResourceGroupName = aadCreds.VaultDetails.ResourceGroup,
                            Version = "2.0",
                            SiteId = aadCreds.SiteId,
                            SiteName = aadCreds.SiteName,
                            ResourceNamespace = aadCreds.VaultDetails.ProviderNamespace,
                            ARMResourceType = aadCreds.VaultDetails.ResourceType
                        };
                    }
                }
            }
            catch (XmlException xmlException)
            {
                throw new XmlException("XML is malformed or file is empty", xmlException);
            }
            _helper = new EnvironmentSetupHelper();
        }

        public ResourceManagementClient RmRestClient { get; private set; }
        public RecoveryServicesClient RecoveryServicesMgmtClient { get; private set; }
        public SiteRecoveryManagementClient SiteRecoveryMgmtClient { get; private set; }

        public void RunPowerShellTest(XunitTracingInterceptor logger, string scenario, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;

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
                {"Microsoft.Compute", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };

            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(scenario, context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var modules = new List<string>
                {
                    PowershellFile,
                    _helper.RMProfileModule,
#if !NETSTANDARD
                    _helper.GetRMModulePath("AzureRM.RecoveryServices.SiteRecovery.psd1"),
#endif
                    _helper.GetRMModulePath("AzureRM.RecoveryServices.psd1")
                };

                _helper.SetupModules(AzureModule.AzureResourceManager, modules.ToArray());

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

        protected void SetupManagementClients(string scenario, MockContext context)
        {
            RmRestClient = GetRmRestClient(context);
            RecoveryServicesMgmtClient = GetRecoveryServicesManagementClient(context);
            SiteRecoveryMgmtClient = GetSiteRecoveryManagementClient(context);
            _helper.SetupManagementClients(
                RmRestClient,
                RecoveryServicesMgmtClient,
                SiteRecoveryMgmtClient);
        }

        private static RecoveryServicesClient GetRecoveryServicesManagementClient(MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClient GetRmRestClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private SiteRecoveryManagementClient GetSiteRecoveryManagementClient(MockContext context)
        {
            var client = context.GetServiceClient<SiteRecoveryManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            client.ResourceGroupName = _asrVaultCreds.ResourceGroupName;
            client.ResourceName = _asrVaultCreds.ResourceName;

            return client;
        }
    }
}
