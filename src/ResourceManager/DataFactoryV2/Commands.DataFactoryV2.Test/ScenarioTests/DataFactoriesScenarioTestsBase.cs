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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using LegacyTest = Microsoft.Azure.Test;

namespace Microsoft.Azure.Commands.DataFactoryV2.Test
{
    public abstract class DataFactoriesScenarioTestsBase : RMTestBase
    {
        private EnvironmentSetupHelper helper;

        protected DataFactoriesScenarioTestsBase()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(MockContext context)
        {
            var resourceManagementClient = GetResourceManagementClient();
            var dataPipelineManagementClient = GetDataPipelineManagementClient(context);
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
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (MockContext context = MockContext.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2)))
            {
                SetupManagementClients(context);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + this.GetType().Name + ".ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.GetRMModulePath("AzureRM.DataFactoryV2.psd1"),
                    "AzureRM.Resources.ps1");

                helper.RunPowerShellTest(scripts);
            }
        }

        protected DataFactoryManagementClient GetDataPipelineManagementClient(MockContext context)
        {
            return context.GetServiceClient<DataFactoryManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected ResourceManagementClient GetResourceManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ResourceManagementClient>(new LegacyTest.CSMTestEnvironmentFactory());
        }

        protected SubscriptionClient GetSubscriptionClient()
        {
            return LegacyTest.TestBase.GetServiceClient<SubscriptionClient>(new LegacyTest.CSMTestEnvironmentFactory());
        }

        protected GalleryClient GetGalleryClient()
        {
            return LegacyTest.TestBase.GetServiceClient<GalleryClient>(new LegacyTest.CSMTestEnvironmentFactory());
        }

        protected AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<AuthorizationManagementClient>(new LegacyTest.CSMTestEnvironmentFactory());
        }
    }
}
