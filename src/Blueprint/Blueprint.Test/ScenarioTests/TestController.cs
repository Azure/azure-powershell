using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using Microsoft.Azure.Commands.Blueprint.Cmdlets;
using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Management.Blueprint;
using LegacyResourceManagementClient = Microsoft.Azure.Management.ResourceManager.ResourceManagementClient;
using Microsoft.Rest;


namespace Microsoft.Azure.Commands.Blueprint.Test.ScenarioTests
{
    public class TestController : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        public BlueprintManagementClient BlueprintManagementClient { get; private set; }
        public ServiceClientCredentials ClientCredentials { get; private set; }
        public GraphRbacManagementClient GraphRbacManagementClient { get; private set; }
        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }
        public ResourceManagementClient ResourceManagerClient { get; private set; }
        public LegacyResourceManagementClient LegacyResourceManagementClient { get; private set; }

        public static TestController NewInstance => new TestController();

        protected TestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(MockContext context)
        {
            BlueprintManagementClient = GetBlueprintManagementClient(context);
            GraphRbacManagementClient = GetGraphRbacManagementClient(context);
            AuthorizationManagementClient = GetAuthorizationManagementClient(context);
            ResourceManagerClient = GetResourceManagementClient(context);
            LegacyResourceManagementClient = GetLegacyResourceManagementClient(context);

            _helper.SetupManagementClients(
                BlueprintManagementClient,
                GraphRbacManagementClient,
                AuthorizationManagementClient,
                ResourceManagerClient,
                LegacyResourceManagementClient);
        }

        public void RunPowerShellTest(ServiceManagement.Common.Models.XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;
            RunPsTestWorkflow(
                () => scripts,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            var providers = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null},
                {"Microsoft.Compute", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);
                _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath("AzureRM.Blueprint.psd1"),
                    _helper.GetRMModulePath("AzureRM.Resources.psd1"),
                    "ScenarioTests\\" + callingClassName + ".ps1");
                try
                {
                    var psScripts = scriptBuilder?.Invoke();
                    if (psScripts != null)
                    {
                        _helper.RunPowerShellTest(psScripts);
                    }
                }
                finally
                {
                    cleanup?.Invoke();
                }
            }
        }

        private static BlueprintManagementClient GetBlueprintManagementClient(MockContext context)
        {
            return context.GetServiceClient<BlueprintManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static GraphRbacManagementClient GetGraphRbacManagementClient(MockContext context)
        {
            var environment = TestEnvironmentFactory.GetTestEnvironment();
            string tenantId = null;

            var client = context.GetGraphServiceClient<GraphRbacManagementClient>(environment);
            client.TenantID = tenantId;

            return client;
        }
        
        private static AuthorizationManagementClient GetAuthorizationManagementClient(MockContext context)
        {
            return context.GetServiceClient<AuthorizationManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private LegacyResourceManagementClient GetLegacyResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<LegacyResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
