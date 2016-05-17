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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.ScenarioTests
{
    public class JobTests : TestsBase
    {
        public JobTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetJobs()
        {
            this.RunPowerShellTest(PsBackupProviderTypes.IaasVm.ToString(), "Test-GetJobsScenario");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetJobsTimeFilter()
        {
            this.RunPowerShellTest(PsBackupProviderTypes.IaasVm.ToString(), "Test-GetJobsTimeFilter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetJobsStatusFilter()
        {
            this.RunPowerShellTest(PsBackupProviderTypes.IaasVm.ToString(), "Test-GetJobsStatusFilter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetJobsOperationFilter()
        {
            this.RunPowerShellTest(PsBackupProviderTypes.IaasVm.ToString(), "Test-GetJobsOperationFilter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetJobsBackupManagementTypeFilter()
        {
            this.RunPowerShellTest(PsBackupProviderTypes.IaasVm.ToString(), "Test-GetJobsBackupManagementTypeFilter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetJobDetails()
        {
            this.RunPowerShellTest(PsBackupProviderTypes.IaasVm.ToString(), "Test-GetJobDetails");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWaitJobScenario()
        {
            this.RunPowerShellTest(PsBackupProviderTypes.IaasVm.ToString(), "Test-WaitJobScenario");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWaitJobPipeScenario()
        {
            this.RunPowerShellTest(PsBackupProviderTypes.IaasVm.ToString(), "Test-WaitJobPipeScenario");
        }

        public void TestCancelJobScenario()
        {
            this.RunPowerShellTest(PsBackupProviderTypes.IaasVm.ToString(), "Test-CancelJobScenario");
        }
    }
}
