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

using System.IO;
using System.Net;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Xml;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Test;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using Microsoft.Azure.Test.Authentication;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Microsoft.Azure.Management.Resources;

namespace Microsoft.Azure.Commands.RecoveryServices.Test.ScenarioTests
{
    public class TestController
    {
        CSMTestEnvironmentFactory csmTestFactory;
        EnvironmentSetupHelper helper;

        public RecoveryServicesClient RsClient { get; private set; }

        public ResourceManagementClient RmClient { get; private set; }

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
        }

        protected void SetupManagementClients(MockContext context)
        {
            RsClient = GetRsClient(context);
            RmClient = GetRmClient();

            helper.SetupManagementClients(
                RsClient,
                RmClient);
        }

        private ResourceManagementClient GetRmClient()
        {
            return Azure.Test.TestBase.GetServiceClient<ResourceManagementClient>(
                this.csmTestFactory);
        }

        public void RunPsTest(params string[] scripts)
        {
            var callingClassType = Azure.Test.TestUtilities.GetCallingClass(2);
            var mockName = Azure.Test.TestUtilities.GetCurrentMethodName(2);

            RunPsTestWorkflow(
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
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

            using (MockContext context =
                MockContext.Start(callingClassType, mockName))
            {
                csmTestFactory = new CSMTestEnvironmentFactory();

                if (initialize != null)
                {
                    initialize.Invoke(csmTestFactory);
                }

                SetupManagementClients(context);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName =
                    callingClassType
                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                string psFile =
                    "ScenarioTests\\" + callingClassName + ".ps1";
                string rmProfileModule = helper.RMProfileModule;
                string rmModulePath = helper.GetRMModulePath("AzureRM.RecoveryServices.psd1");

                List<string> modules = new List<string>();

                modules.Add(psFile);
                modules.Add(rmProfileModule);
                modules.Add(rmModulePath);

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

        private RecoveryServicesClient GetRsClient(MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesClient>(
                Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}