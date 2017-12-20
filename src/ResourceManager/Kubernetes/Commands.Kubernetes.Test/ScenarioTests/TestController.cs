using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Kubernetes.Generated;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

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

        private void SetupManagementClients(MockContext context)
        {
            ContainerServiceClient = GetContainerServiceClient(context);
            ResourceClient = GetResourceManagementClient(context);
            helper.SetupManagementClients(ContainerServiceClient, ResourceClient);
        }

        public void RunPowerShellTest(params string[] scripts)
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            var callingClassType = sf.GetMethod().ReflectedType.ToString();
            var mockName = st.GetFrame(2).GetMethod().Name;

            var d = new Dictionary<string, string> {{"Microsoft.Resources", null}};
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };

            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            HttpMockServer.Initialize(callingClassType, mockName);
            var str = HttpMockServer.FileSystemUtilsObject.GetEnvironmentVariable("AZURE_TEST_MODE");
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
                    helper.GetRMModulePath(@"AzureRM.Kubernetes.Netcore.psd1"));

                if (scripts != null)
                {
                    helper.RunPowerShellTest(scripts);
                }
            }
        }

        private ContainerServiceClient GetContainerServiceClient(MockContext context)
        {
            return context.GetServiceClient<ContainerServiceClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}