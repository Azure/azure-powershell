// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Management.Resources;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using System.Net.Http;
using Xunit.Abstractions;
using Microsoft.WindowsAzure.ServiceManagemenet.Common.Models;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Common
{
    public class PSCmdletTests
    {
        public PSCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.Service, Category.ServiceManagement)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void CmdletNameAndParameterSetInHeader()
        {
            var client = RunPowerShellTest("Get-TestResource").FirstOrDefault().BaseObject as ManagementClient;
            Assert.NotNull(client);
            var handler = client.GetHttpPipeline().FirstOrDefault(h => h is CmdletInfoHandler);
            Assert.NotNull(handler);
            Assert.Equal("Get-TestResource", ((CmdletInfoHandler)handler).Cmdlet);
            Assert.Equal("ParameterSet1", ((CmdletInfoHandler)handler).ParameterSet);
        }

        private EnvironmentSetupHelper helper = new EnvironmentSetupHelper();

        protected void SetupManagementClients()
        {
            var rdfeTestFactory = new RDFETestEnvironmentFactory();
            var managementClient = TestBase.GetServiceClient<ManagementClient>(rdfeTestFactory);

            AzureSession.ClientFactory = new ClientFactory();
        }

        protected Collection<PSObject> RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(1), TestUtilities.GetCurrentMethodName(2));

                SetupManagementClients();

                List<string> modules = new List<string>();
                modules.Add("Microsoft.WindowsAzure.Commands.Common.Test.dll");

                helper.SetupEnvironment(AzureModule.AzureServiceManagement);
                helper.SetupModules(modules.ToArray());

                return helper.RunPowerShellTest(scripts);
            }
        }
    }
}