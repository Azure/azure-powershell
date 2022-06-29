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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.ServiceManagement.Common.Models;

namespace Microsoft.Azure.Commands.UsageAggregates.Test.ScenarioTests
{
    // This TestController class called EnvironmentSetupHelper.SetupSomeOfManagementClients() method.
    public sealed class UsageAggregatesTestController
    {
        private readonly EnvironmentSetupHelper _helper;

        public static UsageAggregatesTestController NewInstance => new UsageAggregatesTestController();

        public UsageAggregatesTestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (MockContext.Start(callingClassType, mockName))
            {
                _helper.SetupSomeOfManagementClients();
                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType?.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"AzureRM.Billing.psd1"));

                _helper.RunPowerShellTest(scripts);
            }
        }
    }
}
