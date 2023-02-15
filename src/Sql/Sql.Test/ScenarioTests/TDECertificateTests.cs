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
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class TDECertificateTests : SqlTestRunner
    {
        public TDECertificateTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForSqlServerDefaultParameterSetNoPassword()
        {
            TestRunner.RunTestScript("Test-AddTdeCertificateForSqlServerDefaultParameterSetNoPassword");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForSqlServerDefaultParameterSetWithPassword()
        {
            TestRunner.RunTestScript("Test-AddTdeCertificateForSqlServerDefaultParameterSetWithPassword");
        }

        [Fact(Skip = "Skip due to long setup time for managed instance")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForManagedInstanceDefaultParameterSetNoPassword()
        {
            TestRunner.RunTestScript("Test-AddTdeCertificateForManagedInstanceDefaultParameterSetNoPassword");
        }

        [Fact(Skip = "Skip due to long setup time for managed instance")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForManagedInstanceDefaultParameterSetWithPassword()
        {
            TestRunner.RunTestScript("Test-AddTdeCertificateForManagedInstanceDefaultParameterSetWithPassword");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForSqlServerInputObjectParameterSetWithPassword()
        {
            TestRunner.RunTestScript("Test-AddTdeCertificateForSqlServerInputObjectParameterSetWithPassword");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForSqlServerResourceIdParameterSetWithPassword()
        {
            TestRunner.RunTestScript("Test-AddTdeCertificateForSqlServerResourceIdParameterSetWithPassword");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForSqlServerInputObjectParameterSetNoPassword()
        {
            TestRunner.RunTestScript("Test-AddTdeCertificateForSqlServerInputObjectParameterSetNoPassword");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForSqlServerResourceIdParameterSetNoPassword()
        {
            TestRunner.RunTestScript("Test-AddTdeCertificateForSqlServerResourceIdParameterSetNoPassword");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForSqlServerWithPiping()
        {
            TestRunner.RunTestScript("Test-AddTdeCertificateForSqlServerWithPiping");
        }
    }
}
