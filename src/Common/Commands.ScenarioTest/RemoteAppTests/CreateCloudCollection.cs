using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Test;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.RemoteAppTests
{
    public class CreateCloudCollection //: AzurePowerShellCertificateTest
    {
        private EnvironmentSetupHelper helper = null;
        private RDFETestEnvironmentFactory rdfeTestFactory = null;

        public CreateCloudCollection()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients()
        {
//            StorageManagementClient managedCacheClient = GetManagedCacheClient();
//            helper.SetupManagementClients(managedCacheClient);
            helper.SetupSomeOfManagementClients();
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(1), TestUtilities.GetCurrentMethodName(2));
                List<string> modules = null;

//                rdfeTestFactory = new RDFETestEnvironmentFactory();

                SetupManagementClients();

                modules = Directory.GetFiles(@"ServiceManagement\Azure\RemoteApp", "*.ps1").ToList();

                helper.SetupModules(AzureModule.AzureServiceManagement, modules.ToArray());
//                helper.SetupEnvironment(AzureModule.AzureServiceManagement);

                helper.RunPowerShellTest(scripts);
            }
        }

#if false
        protected StorageManagementClient GetManagedCacheClient()
        {
            return TestBase.GetServiceClient<StorageManagementClient>(new RDFETestEnvironmentFactory());
        }
#endif

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void foo1()
        {
            RunPowerShellTest("Hello");
        }
    }
}
