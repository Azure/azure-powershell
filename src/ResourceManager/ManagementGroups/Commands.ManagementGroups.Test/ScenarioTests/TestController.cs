using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using ResourceManagementClient = Microsoft.Azure.Management.Resources.ResourceManagementClient;
using SubscriptionClient = Microsoft.Azure.Subscriptions.SubscriptionClient;
using TestBase = Microsoft.Azure.Test.TestBase;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using TestUtilities = Microsoft.Azure.Test.TestUtilities;

namespace Commands.ManagementGroups.Test.ScenarioTests
{
    public class TestController : RMTestBase
    {
        private CSMTestEnvironmentFactory _csmTestFactory;

        private readonly EnvironmentSetupHelper _helper;

        public Microsoft.Azure.Management.Resources.ResourceManagementClient ResourceManagementClient { get; private set; }

        public Microsoft.Azure.Subscriptions.SubscriptionClient SubscriptionClient { get; private set; }

        public GalleryClient GalleryClient { get; private set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        public ManagementGroupsAPIClient ManagementGroupsApiClient { get; private set; }

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
            ResourceManagementClient = GetResourceManagementClient();
            SubscriptionClient = GetSubscriptionClient();
            GalleryClient = GetGalleryClient();
            AuthorizationManagementClient = GetAuthorizationManagementClient();
            ManagementGroupsApiClient = GetManagementGroupsApiClient(context);

            _helper.SetupManagementClients(
                ManagementGroupsApiClient,
                ResourceManagementClient,
                SubscriptionClient,
                GalleryClient,
                AuthorizationManagementClient);
        }

        public void RunPowerShellTest(Microsoft.Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor logger, params string[] scripts)
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

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action<CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {

            var providers = new Dictionary<string, string>();
            providers.Add("Microsoft.Resources", null);
            providers.Add("Microsoft.Features", null);
            providers.Add("Microsoft.Authorization", null);
            providers.Add("Microsoft.Compute", null);

            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);

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
                    _helper.RMProfileModule,
                    @"AzureRM.ManagementGroups.psd1",
                    "ScenarioTests\\" + callingClassName + ".ps1");
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


        protected ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(_csmTestFactory);
        }

        protected AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return TestBase.GetServiceClient<AuthorizationManagementClient>(_csmTestFactory);
        }

        protected SubscriptionClient GetSubscriptionClient()
        {
            return TestBase.GetServiceClient<SubscriptionClient>(_csmTestFactory);
        }

        protected GalleryClient GetGalleryClient()
        {
            return TestBase.GetServiceClient<GalleryClient>(_csmTestFactory);
        }

        protected ManagementGroupsAPIClient GetManagementGroupsApiClient(MockContext context)
        {
            return context.GetServiceClient<ManagementGroupsAPIClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
