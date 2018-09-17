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

using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class ElasticJobExecutionCrudTests : SqlTestsBase
    {
        public ElasticJobExecutionCrudTests(ITestOutputHelper output) : base(output)
        {
        }

        #region Start Job Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestJobStart()
        {
            RunPowerShellTest("Test-StartJob");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestJobStartWait()
        {
            RunPowerShellTest("Test-StartJobWait");
        }

        #endregion

        #region Stop Job Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestJobStop()
        {
            RunPowerShellTest("Test-StopJob");
        }

        #endregion

        #region Get Job Execution Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestJobExecutionGet()
        {
            RunPowerShellTest("Test-GetJobExecution");
        }

        #endregion

        #region Get Job Step Execution Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestJobStepExecutionGet()

        {
            RunPowerShellTest("Test-GetJobStepExecution");
        }

        #endregion

        #region Get Job Target Execution Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestJobTargetExecutionGet()
        {
            RunPowerShellTest("Test-GetJobTargetExecution");
        }

        #endregion
    }
}