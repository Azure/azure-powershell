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

namespace Microsoft.Azure.Commands.NotificatioHubs.Test.ScenarioTests
{
    using System;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.Azure.Test;
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Common.Authentication;
    using Microsoft.Azure.Management.Rdfe;
    using Microsoft.Azure.Gallery;
    using Microsoft.Azure.Management.Authorization;
    using System.Collections.Generic;

    public abstract class TestBaseClass: IDisposable
    {
        private EnvironmentSetupHelper helper;

        protected TestBaseClass()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients()
        {
            var nhManagementClient = GetNotificationHubsManagementClient();
            var resourceManagementClient = GetResourceManagementClient();
            var galaryClient = GetGalleryClient();
            var authorizationManagementClient = GetAuthorizationManagementClient();
            var managementClient = GetManagementClient();

            helper.SetupManagementClients(nhManagementClient, resourceManagementClient, galaryClient,
                                            authorizationManagementClient, managementClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));

                SetupManagementClients();

                string str = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
                List<string> modules = new List<string>();
                modules.Add("Microsoft.Azure.Commands.NotificationHubs.dll");
                modules.Add("ScenarioTests\\" + this.GetType().Name + ".ps1");  


                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager, modules.ToArray());
                helper.RunPowerShellTest(scripts);
            }
        }

        protected NotificationHubsManagementClient GetNotificationHubsManagementClient()
        {
            return TestBase.GetServiceClient<NotificationHubsManagementClient>(new CSMTestEnvironmentFactory());
        }

        private ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
        }

        private GalleryClient GetGalleryClient()
        {
            return TestBase.GetServiceClient<GalleryClient>(new CSMTestEnvironmentFactory());
        }

        private ManagementClient GetManagementClient()
        {
            return TestBase.GetServiceClient<ManagementClient>(new RDFETestEnvironmentFactory());
        }

        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return TestBase.GetServiceClient<AuthorizationManagementClient>(new CSMTestEnvironmentFactory());
        }

        public void Dispose()
        {
        }
    }
}
