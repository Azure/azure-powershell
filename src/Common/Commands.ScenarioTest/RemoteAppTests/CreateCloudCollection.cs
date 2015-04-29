using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Test;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.IO;
using System.Linq;
using Xunit;

using Microsoft.Azure.Management.RemoteApp;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.RemoteAppTests
{
    
    public class CreateCloudCollection
    {
        private EnvironmentSetupHelper helper = null;

        protected void SetupManagementClients()
        {
            StorageManagementClient managedCacheClient = GetManagedCacheClient();
	    helper = new EnvironmentSetupHelper();
            helper.SetupManagementClients(managedCacheClient);
            helper.SetupSomeOfManagementClients();
        }


        protected void SetupAzureEnvironment()
        {
            EnvironmentSetupHelper helper = new EnvironmentSetupHelper();
            helper.SetupEnvironment(AzureModule.AzureServiceManagement);
        }

        protected Collection<T> RunPowerShellTest<T>(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(1), TestUtilities.GetCurrentMethodName(2));
                List<string> modules = null;
                Collection<PSObject> pipeLineObjects = null;
                Collection<T> result = new Collection<T>();
                EnvironmentSetupHelper helper = new EnvironmentSetupHelper();

                modules = Directory.GetFiles(@"ServiceManagement\Azure\RemoteApp", "*.ps1").ToList();

                helper.SetupSomeOfManagementClients();
                helper.SetupEnvironment(AzureModule.AzureServiceManagement);
                helper.SetupModules(AzureModule.AzureServiceManagement, modules.ToArray());

                pipeLineObjects = helper.RunPowerShellTest(scripts);
                foreach (PSObject obj in pipeLineObjects)
                {
                    T item = LanguagePrimitives.ConvertTo<T>(obj);
                    result.Add(item);
                }
                return result;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CheckinTest()
        {
            RunPowerShellTest<string>("CheckinTest");
        }
    }
}
