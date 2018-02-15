using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Kubernetes.Generated;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using System.Collections.Generic;
using Microsoft.Azure.Test.HttpRecorder;

namespace Commands.Kubernetes.Test.ScenarioTests
{
    public class TestController : RMTestBase
    {
        private EnvironmentSetupHelper helper;

        public ContainerServiceClient ContainerServiceClient { get; private set; }

        public Microsoft.Azure.Management.ResourceManager.ResourceManagementClient ResourceClient { get; private set; }

        public TestController()
        {
            helper = new EnvironmentSetupHelper();
        }

        public static TestController NewInstance => new TestController();

        public Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient InternalResourceManagementClient { get; private set; }

        public GraphRbacManagementClient GraphRbacManagementClient { get; private set; }

        public void RunPowerShellTest(params string[] scripts)
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            var callingClassType = sf.GetMethod().ReflectedType.ToString();
            var mockName = st.GetFrame(2).GetMethod().Name;

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);
                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();

                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("Microsoft.Features", null);
                d.Add("Microsoft.Authorization", null);
                var providersToIgnore = new Dictionary<string, string>
                {
                    {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2017-05-10"}
                };
                HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(false, d, providersToIgnore);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager,
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.GetRMModulePath(@"AzureRM.Kubernetes.psd1"),
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1");

                helper.RunPowerShellTest(scripts);
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            ContainerServiceClient = GetContainerServiceClient(context);
            ResourceClient = GetResourceManagementClient(context);
            InternalResourceManagementClient = GetInternalResourceManagementClient(context);
            GraphRbacManagementClient = GetRbacManagementClient(context);
            helper.SetupManagementClients(ContainerServiceClient, ResourceClient, InternalResourceManagementClient, GraphRbacManagementClient);
        }

        private ContainerServiceClient GetContainerServiceClient(MockContext context)
        {
            return context.GetServiceClient<ContainerServiceClient>();
        }

        private Microsoft.Azure.Management.ResourceManager.ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<Microsoft.Azure.Management.ResourceManager.ResourceManagementClient>();
        }

        private Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient GetInternalResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient>();
        }

        private GraphRbacManagementClient GetRbacManagementClient(MockContext context)
        {
            return context.GetGraphServiceClient<GraphRbacManagementClient>();
        }
    }
}