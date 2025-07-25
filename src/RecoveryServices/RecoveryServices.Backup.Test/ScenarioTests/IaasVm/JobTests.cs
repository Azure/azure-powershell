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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.ScenarioTests
{
    public partial class JobTests : RecoveryServicesBackupTestRunner
    {
        private readonly string _IaasVmcommonModule = $"ScenarioTests/{PsBackupProviderTypes.IaasVm}/Common.ps1";
        private readonly string _IaasVmtestModule = $"ScenarioTests/{PsBackupProviderTypes.IaasVm}/JobTests.ps1";

        public JobTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMGetJobs()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMGetJobs"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMGetJobsTimeFilter()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMGetJobsTimeFilter"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMWaitJob()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMWaitJob"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVM)]
        public void TestAzureVMCancelJob()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_IaasVmcommonModule.AsAbsoluteLocation()}",
                $"Import-Module {_IaasVmtestModule.AsAbsoluteLocation()}",
                "Test-AzureVMCancelJob"
            );
        }
    }
}
