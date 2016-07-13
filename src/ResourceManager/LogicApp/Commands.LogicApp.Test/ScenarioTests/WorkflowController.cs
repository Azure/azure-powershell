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

namespace Microsoft.Azure.Commands.LogicApp.Test.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Gallery;
    using Microsoft.Azure.Management.Authorization;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Subscriptions;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using LegacyTest = Microsoft.Azure.Test;
    using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
    using TestUtilities = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities;
    using Microsoft.Azure.Management.WebSites;
    using System.IO;

    /// <summary>
    /// Test controller for the logic app scenario testing
    /// </summary>
    public class WorkflowController
    {
        /// <summary>
        /// CSM test factory
        /// </summary>
        private LegacyTest.CSMTestEnvironmentFactory csmTestFactory;
        
        /// <summary>
        /// EnvironmentSetupHelper instance
        /// </summary>
        private EnvironmentSetupHelper helper;

        /// <summary>
        /// Authorization Api Version
        /// </summary>       
        private const string AuthorizationApiVersion = "2014-07-01-preview";

        /// <summary>
        /// Gets or sets the ResourceManagementClient
        /// </summary>
        public ResourceManagementClient ResourceManagementClient { get; private set; }

        /// <summary>
        /// Gets or sets the SubscriptionClient
        /// </summary>
        public SubscriptionClient SubscriptionClient { get; private set; }

        /// <summary>
        /// Gets or sets the LogicManagementClient
        /// </summary>
        public LogicManagementClient LogicManagementClient { get; private set; }

        /// <summary>
        /// Gets or sets the WebSiteManagementClient
        /// </summary>
        public WebSiteManagementClient WebsiteManagementClient { get; private set; }

        /// <summary>
        /// Gets or sets the AuthorizationManagementClient
        /// </summary>
        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        /// <summary>
        /// Gets or sets the GalleryClient
        /// </summary>
        public GalleryClient GalleryClient { get; private set; }

        /// <summary>
        /// Create a new instance of workflow controller.
        /// </summary>
        public static WorkflowController NewInstance
        {
            get { return new WorkflowController(); }
        }

        /// <summary>
        /// Initiliazes the workflow controller 
        /// </summary>
        public WorkflowController()
        {
            helper = new EnvironmentSetupHelper();
        }

        /// <summary>
        /// Runs the PowerShell test
        /// </summary>
        /// <param name="scripts">script to be executed</param>
        public void RunPowerShellTest(params string[] scripts)
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

        /// <summary>
        /// Runs the PowerShell test under mock undo context based on the test mode setting (Record|Playback)
        /// </summary>
        /// <param name="scriptBuilder">Script builder delegate</param>
        /// <param name="initialize">initialize action</param>
        /// <param name="cleanup">cleanup action</param>
        /// <param name="callingClassType">Calling class type</param>
        /// <param name="mockName">Mock Name</param>
        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action<LegacyTest.CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Authorization", AuthorizationApiVersion);
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                this.csmTestFactory = new LegacyTest.CSMTestEnvironmentFactory();
                if (initialize != null)
                {
                    initialize(this.csmTestFactory);
                }
                SetupManagementClients(context);
                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                    .Split(new[] {"."}, StringSplitOptions.RemoveEmptyEntries)
                    .Last();
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,                    
                    helper.GetRMModulePath(@"AzureRM.LogicApp.psd1"),
                    "ScenarioTests\\AzureRM.Resources.ps1");

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
                        cleanup();
                    }
                }
            }
        }

        /// <summary>
        /// Set up mock clients
        /// </summary>
        /// <param name="context"></param>
        private void SetupManagementClients(MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient();
            SubscriptionClient = GetSubscriptionClient();
            AuthorizationManagementClient = GetAuthorizationManagementClient();
            GalleryClient = GetGalleryClient();
            LogicManagementClient = GetLogicManagementClient(context);
            WebsiteManagementClient = GetWebsiteManagementClient(context);
            helper.SetupManagementClients(ResourceManagementClient,
                SubscriptionClient,
                AuthorizationManagementClient,
                GalleryClient,
                LogicManagementClient,
                WebsiteManagementClient
                );
        }

        /// <summary>
        /// Create an AuthorizationManagementClient instance based on mode setting
        /// </summary>
        /// <returns>AuthorizationManagementClient instance</returns>
        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory);
        }

        /// <summary>
        /// Creates a ResourceManagementClient instance
        /// </summary>
        /// <returns>ResourceManagementClient instance</returns>
        private ResourceManagementClient GetResourceManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory);
        }

        /// <summary>
        /// Creates LogicManagementClient instance  based on mode setting
        /// </summary>
        /// <param name="context">Mock undocontext</param>
        /// <returns>LogicManagementClient instance</returns>
        private LogicManagementClient GetLogicManagementClient(MockContext context)
        {
            return context.GetServiceClient<LogicManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        /// <summary>
        /// Creates WebSiteManagementClient instance  based on mode setting
        /// </summary>
        /// <param name="context">Mock undocontext</param>
        /// <returns>WebSiteManagementClient instance</returns>
        private WebSiteManagementClient GetWebsiteManagementClient(MockContext context)
        {
            return context.GetServiceClient<WebSiteManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private SubscriptionClient GetSubscriptionClient()
        {
            return LegacyTest.TestBase.GetServiceClient<SubscriptionClient>(this.csmTestFactory);
        }

        /// <summary>
        /// Creates a Gallery Client  based on mode setting
        /// </summary>
        /// <returns>GalleryClient instamce</returns>
        private GalleryClient GetGalleryClient()
        {
            return LegacyTest.TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory);
        }
    }
}

