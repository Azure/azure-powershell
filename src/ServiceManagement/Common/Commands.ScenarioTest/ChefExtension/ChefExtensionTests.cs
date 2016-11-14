using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.ServiceManagemenet;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication;
using Xunit.Abstractions;
using Microsoft.WindowsAzure.ServiceManagemenet.Common.Models;


namespace Microsoft.WindowsAzure.Commands.ScenarioTest
{    
    public class ChefExtensionTests
    {
        private EnvironmentSetupHelper helper = new EnvironmentSetupHelper();

        public ChefExtensionTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestSetAzureVMChefExtension()
        {
            this.RunPowerShellTest("Test-SetAzureVMChefExtension");
        }

        protected void SetupManagementClients()
        {
            var rdfeTestFactory = new RDFETestEnvironmentFactory();
            var managementClient = TestBase.GetServiceClient<ManagementClient>(rdfeTestFactory);
            var computeClient = TestBase.GetServiceClient<ComputeManagementClient>(rdfeTestFactory);
            var networkClient = TestBase.GetServiceClient<NetworkManagementClient>(rdfeTestFactory);
            var storageClient = TestBase.GetServiceClient<StorageManagementClient>(rdfeTestFactory);

            helper.SetupSomeOfManagementClients(
                managementClient,
                computeClient,
                networkClient,
                storageClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(1), TestUtilities.GetCurrentMethodName(2));
                
                SetupManagementClients();

                var modules = new List<string>
                {
                    "Resources\\ChefExtension\\ChefExtensionTests.ps1",
                    "Resources\\ServiceManagement\\Common.ps1",
                    @"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Compute\AzurePreview.psd1",
                    @"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Compute\PIR.psd1"
                };

                helper.SetupEnvironment(AzureModule.AzureServiceManagement);
                helper.SetupModules(AzureModule.AzureServiceManagement, modules.ToArray());


                var scriptEnvPath = new List<string>();
                scriptEnvPath.Add(
                    string.Format(
                    "$env:PSModulePath=\"{0};$env:PSModulePath\"",
                    @"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Compute".AsAbsoluteLocation()));

                helper.RunPowerShellTest(scriptEnvPath, scripts);
            }
        }                
    }
}
