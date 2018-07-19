﻿// ----------------------------------------------------------------------------------
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


using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.OperationalInsights.Test
{
    public class QueryTests : OperationalInsightsScenarioTestBase
    {
        public XunitTracingInterceptor _logger;

        public QueryTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleQuery()
        {
            RunDataPowerShellTest(_logger, "Test-SimpleQuery");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleQueryWithTimespan()
        {
            RunDataPowerShellTest(_logger, "Test-SimpleQueryWithTimespan");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExceptionWithSyntaxError()
        {
            RunDataPowerShellTest(_logger, "Test-ExceptionWithSyntaxError");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExceptionWithShortWait()
        {
            RunDataPowerShellTest(_logger, "Test-ExceptionWithShortWait");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAsJob()
        {
            RunDataPowerShellTest(_logger, "Test-AsJob");
        }
    }
}
