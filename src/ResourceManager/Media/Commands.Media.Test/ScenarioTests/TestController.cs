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
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Subscriptions;
using TestBase = Microsoft.Azure.Test.TestBase;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using TestUtilities = Microsoft.Azure.Test.TestUtilities;

namespace Microsoft.Azure.Commands.Media.Test.ScenarioTests
{
    /// <summary>
    /// Setup for Scenario Tests
    /// </summary>
    public class TestController : RMTestBase
    {
        private CSMTestEnvironmentFactory _csmTestFactory;

        private readonly EnvironmentSetupHelper _helper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public SubscriptionClient SubscriptionClient { get; private set; }

        public GalleryClient GalleryClient { get; private set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        public MediaServicesManagementClient MediaServicesManagementClient { get; private set; }

        public StorageManagementClient StorageManagementClient { get; private set; }

        public static TestController NewInstance
        {
            get
            {
                return new TestController();
            }
        }

        protected TestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(MockContext context)
        {
            ResourceManagementClient = TestBase.GetServiceClient<ResourceManagementClient>(_csmTestFactory);
            SubscriptionClient = TestBase.GetServiceClient<SubscriptionClient>(_csmTestFactory);
            GalleryClient = TestBase.GetServiceClient<GalleryClient>(_csmTestFactory);
            AuthorizationManagementClient = TestBase.GetServiceClient<AuthorizationManagementClient>(_csmTestFactory);
            StorageManagementClient = TestBase.GetServiceClient<StorageManagementClient>(_csmTestFactory);
            MediaServicesManagementClient = context.GetServiceClient<MediaServicesManagementClient>(TestEnvironmentFactory.GetTestEnvironment());

            _helper.SetupManagementClients(
                ResourceManagementClient,
                SubscriptionClient,
                StorageManagementClient,
                GalleryClient,
                AuthorizationManagementClient,
                MediaServicesManagementClient);
        }

        /// <summary>
        /// Methods for invoking PowerShell scripts
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="scripts"></param>
        public void RunPowerShellTest(ServiceManagemenet.Common.Models.XunitTracingInterceptor logger, params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            _helper.TracingInterceptor = logger;
            RunPsTestWorkflow(
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        private void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action<CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {

            var d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            d.Add("Microsoft.Compute", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {

                _csmTestFactory = new CSMTestEnvironmentFactory();

                if (initialize != null)
                {
                    initialize(_csmTestFactory);
                }

                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();

                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.RMResourceModule,
                    _helper.RMStorageDataPlaneModule,
                    _helper.RMStorageModule,
                    @"AzureRM.Media.psd1",
                    "AzureRM.Resources.ps1",
                    "AzureRM.Storage.ps1");
                try
                {
                    if (scriptBuilder != null)
                    {
                        var psScripts = scriptBuilder();

                        if (psScripts != null)
                        {
                            _helper.RunPowerShellTest(psScripts);
                        }
                    }
                }
                finally
                {
                    if (cleanup != null)
                    {
                        cleanup();
                    }
                }
            }
        }
    }
}
