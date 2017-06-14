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
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.DataFactories.Test
{
    public abstract class DataFactoriesScenarioTestsBase : RMTestBase
    {
        private EnvironmentSetupHelper helper;

        protected DataFactoriesScenarioTestsBase()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients()
        {
            var dataPipelineManagementClient = GetDataPipelineManagementClient();
            var resourceManagementClient = GetResourceManagementClient();
            var subscriptionsClient = GetSubscriptionClient();
            var galleryClient = GetGalleryClient();
            var authorizationManagementClient = GetAuthorizationManagementClient();

            helper.SetupManagementClients(dataPipelineManagementClient,
                resourceManagementClient,
                subscriptionsClient,
                galleryClient,
                authorizationManagementClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
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

                SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + this.GetType().Name + ".ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.GetRMModulePath("AzureRM.DataFactories.psd1"),
                    "AzureRM.Resources.ps1");

                helper.RunPowerShellTest(scripts);
            }
        }

        protected DataFactoryManagementClient GetDataPipelineManagementClient()
        {
            return TestBase.GetServiceClient<DataFactoryManagementClient>(new CSMTestEnvironmentFactory());
        }

        protected ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
        }

        protected SubscriptionClient GetSubscriptionClient()
        {
            return TestBase.GetServiceClient<SubscriptionClient>(new CSMTestEnvironmentFactory());
        }

        protected GalleryClient GetGalleryClient()
        {
            return TestBase.GetServiceClient<GalleryClient>(new CSMTestEnvironmentFactory());
        }

        protected AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return TestBase.GetServiceClient<AuthorizationManagementClient>(new CSMTestEnvironmentFactory());
        }
    }
}
