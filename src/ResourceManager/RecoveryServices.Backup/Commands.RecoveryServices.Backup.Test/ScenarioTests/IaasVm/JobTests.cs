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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.ScenarioTests
{
    public class JobTests : RMTestBase
    {
        public JobTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetJobs()
        {
            TestController.NewInstance.RunPsTest(PsBackupProviderTypes.IaasVm, "Test-GetJobsScenario");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetJobsTimeFilter()
        {
            TestController.NewInstance.RunPsTest(PsBackupProviderTypes.IaasVm, "Test-GetJobsTimeFilter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetJobsStatusFilter()
        {
            TestController.NewInstance.RunPsTest(PsBackupProviderTypes.IaasVm, "Test-GetJobsStatusFilter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetJobsOperationFilter()
        {
            TestController.NewInstance.RunPsTest(PsBackupProviderTypes.IaasVm, "Test-GetJobsOperationFilter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetJobsBackupManagementTypeFilter()
        {
            TestController.NewInstance.RunPsTest(PsBackupProviderTypes.IaasVm, "Test-GetJobsBackupManagementTypeFilter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetJobDetails()
        {
            TestController.NewInstance.RunPsTest(PsBackupProviderTypes.IaasVm, "Test-GetJobDetails");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWaitJobScenario()
        {
            TestController.NewInstance.RunPsTest(PsBackupProviderTypes.IaasVm, "Test-WaitJobScenario");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWaitJobPipeScenario()
        {
            TestController.NewInstance.RunPsTest(PsBackupProviderTypes.IaasVm, "Test-WaitJobPipeScenario");
        }

        public void TestCancelJobScenario()
        {
            TestController.NewInstance.RunPsTest(PsBackupProviderTypes.IaasVm, "Test-CancelJobScenario");
        }
    }
}
