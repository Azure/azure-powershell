using System;
using System.IO;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Kubernetes.Test.ScenarioTests
{
    public class KubernetesTests : RMTestBase
    {
        public KubernetesTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Playback)
            {
                AzureSession.Instance.DataStore = new MemoryDataStore();
                var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                AzureSession.Instance.DataStore.WriteFile(Path.Combine(home, ".ssh", "id_rsa.pub"), File.ReadAllText("Fixtures/id_rsa.pub"));
                AzureSession.Instance.DataStore.WriteFile(Path.Combine(home, ".azure", "acsServicePrincipal.json"), "Fixtures/acsServicePrincipal.json");
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureKubernetes()
        {
            TestController.NewInstance.RunPowerShellTest("Test-AzureRmKubernetes");
        }
    }
}