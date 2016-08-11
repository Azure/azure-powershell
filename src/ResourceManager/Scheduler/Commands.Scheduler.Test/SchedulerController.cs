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

namespace Microsoft.Azure.Commands.Scheduler.Test.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Gallery;
    using Microsoft.Azure.Management.Authorization;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Scheduler;
    using Microsoft.Azure.Subscriptions;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using LegacyTest = Microsoft.Azure.Test;

    public class SchedulerController
    {
        /// <summary>
        /// CSM test factory.
        /// </summary>
        private LegacyTest.CSMTestEnvironmentFactory _csmTestFactory;

        /// <summary>
        /// EnvironmentSetupHelper instance.
        /// </summary>
        private EnvironmentSetupHelper _helper;

        /// <summary>
        /// Authorization Api version.
        /// </summary>
        private readonly string AuthorizationApiVersion = "2014-07-01-preview";

        /// <summary>
        /// Gets or sets the ResourceManagementClient
        /// </summary>
        public ResourceManagementClient ResourceManagementClient { get; private set; }

        /// <summary>
        /// Gets or sets the SubscriptionClient.
        /// </summary>
        public SubscriptionClient SubscriptionClient { get; private set; }

        /// <summary>
        /// Gets or sets the AuthorizationManagementClient.
        /// </summary>
        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        /// <summary>
        /// Gets or sets the GalleryClient.
        /// </summary>
        public GalleryClient GalleryClient { get; private set; }

        /// <summary>
        /// Gets or sets the SchedulerManagementClient.
        /// </summary>
        public SchedulerManagementClient SchedulerManagementClient { get; private set; }

        /// <summary>
        /// Creates a new instance of workflow controller.
        /// </summary>
        public static SchedulerController NewInstance
        {
            get
            {
                return new SchedulerController();
            }
        }

        /// <summary>
        /// Initializes new instance of <see cref="Schedulercontroller"/> class.
        /// </summary>
        public SchedulerController()
        {
            this._helper = new EnvironmentSetupHelper();
        }

        /// <summary>
        /// RUns the PowerShell tests.
        /// </summary>
        /// <param name="scripts">Scripts to be executed.</param>
        public void RunPowerShellTests(params string[] scripts)
        {
            string callingClassType = TestUtilities.GetCallingClass(2);
            string mockName = TestUtilities.GetCurrentMethodName(2);
            RunPsTestScheduler(
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestScheduler(
            Func<string[]> scriptBuilder,
            Action<LegacyTest.CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            var providers = new Dictionary<string, string>();
            providers.Add("Microsoft.Authorization", this.AuthorizationApiVersion);
            providers.Add("Microsoft.Resources", null);
            providers.Add("Microsoft.Features", null);
            providers.Add("Microsoft.Storage", null);

            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");

            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(ignoreResourcesClient: true, providers: providers, userAgents: providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using(MockContext context = MockContext.Start(className: callingClassType, methodName: mockName))
            {
                this._csmTestFactory = new LegacyTest.CSMTestEnvironmentFactory();

                if (initialize != null)
                {
                    initialize(this._csmTestFactory);
                }

                SetupManagementClients(context);

                this._helper.SetupEnvironment(mode: AzureModule.AzureResourceManager);

                string callingClassName = callingClassType
                                    .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                    .Last();

                this._helper.SetupModules(AzureModule.AzureResourceManager,
                             "ScenarioTests\\Common.ps1",
                             "ScenarioTests\\" + callingClassName + ".ps1",
                             _helper.RMProfileModule,
                             _helper.RMResourceModule,
                             _helper.GetRMModulePath(@"AzureRM.Scheduler.psd1"),
                             "AzureRM.Resources.ps1",
                             "AzureRM.Storage.ps1");

                try
                {
                    if (scriptBuilder != null)
                    {
                        var pScripts = scriptBuilder();

                        if (pScripts != null)
                        {
                            this._helper.RunPowerShellTest(pScripts);
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

        /// <summary>
        /// Setup Mock clients.
        /// </summary>
        /// <param name="context"></param>
        private void SetupManagementClients(MockContext context)
        {
            this.ResourceManagementClient = GetResourceManagementClient();
            this.SubscriptionClient = GetSubscriptionClient();
            this.AuthorizationManagementClient = GetAuthorizationManagementClient();
            this.GalleryClient = GetGalleryClient();
            this.SchedulerManagementClient = GetSchedulerManagementClient(context);

            this._helper.SetupManagementClients(
                ResourceManagementClient,
                SubscriptionClient,
                AuthorizationManagementClient,
                GalleryClient,
                SchedulerManagementClient);
        }

        /// <summary>
        /// Creates a ResourceManagementClient instance.
        /// </summary>
        /// <returns>ResourceManagementClient instance.</returns>
        private ResourceManagementClient GetResourceManagementClient()
        {
           return LegacyTest.TestBase.GetServiceClient<ResourceManagementClient>(this._csmTestFactory);
        }

        /// <summary>
        /// Create a SubscriptionClient instance.
        /// </summary>
        /// <returns>SubscriptionClient instance.</returns>
        private SubscriptionClient GetSubscriptionClient()
        {
            return LegacyTest.TestBase.GetServiceClient<SubscriptionClient>(this._csmTestFactory);
        }

        /// <summary>
        /// Create an AuthorizationManagementClient instance.
        /// </summary>
        /// <returns>AuthorizationManagementClient instance.</returns>
        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<AuthorizationManagementClient>(this._csmTestFactory);
        }

        /// <summary>
        /// Creates GalleryClient instance.
        /// </summary>
        /// <returns>GalleryClient instance.</returns>
        private GalleryClient GetGalleryClient()
        {
            return LegacyTest.TestBase.GetServiceClient<GalleryClient>(this._csmTestFactory);
        }

        /// <summary>
        /// Creates SchedulerManagementClient based on mode setting.
        /// </summary>
        /// <param name="context">Context object.</param>
        /// <returns>SchedulerManagementClient instance.</returns>
        private SchedulerManagementClient GetSchedulerManagementClient(MockContext context)
        {
            return context.GetServiceClient<SchedulerManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
