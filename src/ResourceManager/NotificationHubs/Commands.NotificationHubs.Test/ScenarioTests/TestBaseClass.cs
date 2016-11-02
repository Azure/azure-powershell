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

namespace Commands.NotificationHubs.Test
{
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Gallery;
    using Microsoft.Azure.Management.Authorization;
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.Resources;
    using LegacyTest = Microsoft.Azure.Test;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using Microsoft.WindowsAzure.Management;
    using System.Collections.Generic;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Linq;
    using System.IO;

    public abstract class TestBaseClass : RMTestBase
    {
        private EnvironmentSetupHelper helper;
        private LegacyTest.CSMTestEnvironmentFactory csmTestFactory;

        protected TestBaseClass()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(MockContext context)
        {
            var nhManagementClient = GetNotificationHubsManagementClient(context);
            var resourceManagementClient = GetResourceManagementClient();
            var gallaryClient = GetGalleryClient();
            var authorizationManagementClient = GetAuthorizationManagementClient();
            var managementClient = GetManagementClient();

            helper.SetupManagementClients(nhManagementClient, resourceManagementClient, gallaryClient,
                                            authorizationManagementClient, managementClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                this.csmTestFactory = new LegacyTest.CSMTestEnvironmentFactory();

                SetupManagementClients(context);

                var callingClassName = callingClassType
                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                        .Last();

                List<string> modules = new List<string>();
                //modules.Add("Microsoft.Azure.Commands.NotificationHubs.dll");
                modules.Add("ScenarioTests\\" + this.GetType().Name + ".ps1");
                modules.Add(helper.RMProfileModule);
                modules.Add(helper.RMResourceModule);
                modules.Add(helper.GetRMModulePath(@"AzureRM.NotificationHubs.psd1"));
                modules.Add("AzureRM.Resources.ps1");

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager, modules.ToArray());

                if (scripts != null)
                {
                    helper.RunPowerShellTest(scripts);
                }
            }
        }

        protected NotificationHubsManagementClient GetNotificationHubsManagementClient(MockContext context)
        {
            return context.GetServiceClient<NotificationHubsManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private ResourceManagementClient GetResourceManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory);
        }

        private GalleryClient GetGalleryClient()
        {
            return LegacyTest.TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory);
        }

        private ManagementClient GetManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ManagementClient>(new LegacyTest.RDFETestEnvironmentFactory());
        }

        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory);
        }

        public void Dispose()
        {
        }
    }
}
