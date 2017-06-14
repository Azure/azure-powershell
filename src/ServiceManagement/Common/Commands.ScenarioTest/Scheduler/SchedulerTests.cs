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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ScenarioTest.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication;
using System;
using Xunit.Abstractions;
using Microsoft.WindowsAzure.ServiceManagemenet.Common.Models;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest
{
    public class SchedulerTests
    {
        private EnvironmentSetupHelper helper = new EnvironmentSetupHelper();

        public SchedulerTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        [Trait(Category.Service, Category.Scheduler)]
        public void TestSchedulerEndToEnd()
        {
            this.RunPowerShellTest("Test-SchedulerEndToEnd");
        }

        protected void SetupManagementClients()
        {
            helper.SetupSomeOfManagementClients();
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(1), TestUtilities.GetCurrentMethodName(2));

                SetupManagementClients();

                List<string> modules = Directory.GetFiles("Resources\\Scheduler".AsAbsoluteLocation(), "*.ps1").ToList();

                helper.SetupEnvironment(AzureModule.AzureServiceManagement);
                helper.SetupModules(AzureModule.AzureServiceManagement, modules.ToArray());

                helper.RunPowerShellTest(scripts);
            }
        }
    }
}
