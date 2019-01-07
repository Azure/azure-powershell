using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Aks.Generated.Version2017_08_31;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System.Reflection;
using System.IO;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.ServiceManagement.Common.Models;

namespace Commands.Aks.Test.ScenarioTests
{
    public class TestController : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        public ContainerServiceClient ContainerServiceClient { get; private set; }

        public TestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public static TestController NewInstance => new TestController();

        public ResourceManagementClient InternalResourceManagementClient { get; private set; }

        public void RunPowerShellTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;

            var d = new Dictionary<string, string>
            {
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null}
            };
            var providersToIgnore = new Dictionary<string, string>
                {
                    {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2017-05-10"},
                    {"Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2017-05-10"}
                };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(false, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);
                var callingClassName = callingClassType?.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"AzureRM.Aks.psd1"),
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    "AzureRM.Resources.ps1");

                if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Playback)
                {
                    AzureSession.Instance.DataStore = new MemoryDataStore();
                    var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    var dir = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
                    var subscription = HttpMockServer.Variables["SubscriptionId"];
                    AzureSession.Instance.DataStore.WriteFile(Path.Combine(home, ".ssh", "id_rsa.pub"), File.ReadAllText(dir + "/Fixtures/id_rsa.pub"));
                    var jsonOutput = @"{""" + subscription + @""":{ ""service_principal"":""foo"",""client_secret"":""bar""}}";
                    AzureSession.Instance.DataStore.WriteFile(Path.Combine(home, ".azure", "acsServicePrincipal.json"), jsonOutput);
                }
                else if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                {
                    AzureSession.Instance.DataStore = new MemoryDataStore();
                    var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    var dir = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
                    var subscription = HttpMockServer.Variables["SubscriptionId"];
                    var currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();
                    string spn = null;
                    string spnSecret = null;
                    if (currentEnvironment.ConnectionString.KeyValuePairs.ContainsKey("ServicePrincipal"))
                    {
                        spn = currentEnvironment.ConnectionString.KeyValuePairs["ServicePrincipal"];
                    }
                    if (currentEnvironment.ConnectionString.KeyValuePairs.ContainsKey("ServicePrincipalSecret"))
                    {
                        spnSecret = currentEnvironment.ConnectionString.KeyValuePairs["ServicePrincipalSecret"];
                    }
                    AzureSession.Instance.DataStore.WriteFile(Path.Combine(home, ".ssh", "id_rsa.pub"), File.ReadAllText(dir + "/Fixtures/id_rsa.pub"));
                    var jsonOutput = @"{""" + subscription + @""":{ ""service_principal"":""" + spn + @""",""client_secret"":"""+ spnSecret + @"""}}";
                    AzureSession.Instance.DataStore.WriteFile(Path.Combine(home, ".azure", "acsServicePrincipal.json"), jsonOutput);
                }

                _helper.RunPowerShellTest(scripts);
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            ContainerServiceClient = GetContainerServiceClient(context);
            InternalResourceManagementClient = GetInternalResourceManagementClient(context);
            _helper.SetupManagementClients(ContainerServiceClient, InternalResourceManagementClient);
        }

        private static ContainerServiceClient GetContainerServiceClient(MockContext context)
        {
            return context.GetServiceClient<ContainerServiceClient>();
        }
        private static ResourceManagementClient GetInternalResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }
    }
}