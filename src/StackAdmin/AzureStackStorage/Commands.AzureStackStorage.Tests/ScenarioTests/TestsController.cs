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
using System.Linq;
using Microsoft.Azure.Test;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Authorization;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using TestBase = Microsoft.Azure.Test.TestBase;
using TestUtilities = Microsoft.Azure.Test.TestUtilities;


namespace Microsoft.AzureStack.Commands.StorageAdmin.Test.ScenarioTests
{
    public sealed class TestsController : RMTestBase
    {
        private CSMTestEnvironmentFactory csmTestFactory;
        private EnvironmentSetupHelper helper;
        
        public string UserDomain { get; private set; }

        public static TestsController NewInstance 
        { 
            get
            {
                return new TestsController();
            }
        }

        public TestsController()
        {
            helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

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
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                this.csmTestFactory = new CSMTestEnvironmentFactory();

                if(initialize != null)
                {
                    initialize(this.csmTestFactory);
                }
                
                SetupManagementClients(context);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                
                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupModules(
                    AzureModule.AzureResourceManager, 
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    helper.StackRMProfileModule,
                    helper.GetStackRMModulePath("AzureRM.AzureStackStorage.psd1"));

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
                    if(cleanup !=null)
                    {
                        cleanup();
                    }
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            IStorageAdminManagementClient storageAdminClient = GetStorageManagementClient();
            Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient internalResourceManagementClient = GetInternalResourceManagementClient(context);
            Microsoft.Azure.Management.ResourceManager.ResourceManagementClient legacyResourceManagementClient = GetLegacyResourceManagementClient(context);
            GalleryClient galleryClient = GetGalleryClient();
            AuthorizationManagementClient authorizationManagementClient = this.GetAuthorizationManagementClient();
            helper.SetupManagementClients(storageAdminClient, internalResourceManagementClient, legacyResourceManagementClient, galleryClient, authorizationManagementClient);
        }

        private IStorageAdminManagementClient GetStorageManagementClient()
        {
            return TestBase.GetServiceClient<StorageAdminManagementClient>(this.csmTestFactory);
        }
        private Microsoft.Azure.Management.ResourceManager.ResourceManagementClient GetLegacyResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<Microsoft.Azure.Management.ResourceManager.ResourceManagementClient>(Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient GetInternalResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient>(Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private GalleryClient GetGalleryClient()
        {
            return TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory);
        }
        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory);
        }
    }
}
