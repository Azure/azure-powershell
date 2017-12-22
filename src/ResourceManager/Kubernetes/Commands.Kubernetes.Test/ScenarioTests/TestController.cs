using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Kubernetes.Generated;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Commands.Kubernetes.Test.ScenarioTests
{
    public class TestController : RMTestBase
    {
        private EnvironmentSetupHelper helper;

        public ContainerServiceClient ContainerServiceClient { get; private set; }

        public ResourceManagementClient ResourceClient { get; private set; }

        public TestController()
        {
            helper = new EnvironmentSetupHelper();
        }

        public static TestController NewInstance => new TestController();



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
                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    "ScenarioTests\\Common.ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.GetRMModulePath(@"AzureRM.Kubernetes.psd1"));

                helper.RunPowerShellTest(scripts);
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            ContainerServiceClient = GetContainerServiceClient(context);
            ResourceClient = GetResourceManagementClient(context);
            helper.SetupManagementClients(ContainerServiceClient, ResourceClient);
        }

        private ContainerServiceClient GetContainerServiceClient(MockContext context)
        {
            return context.GetServiceClient<ContainerServiceClient>();
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }
    }
}