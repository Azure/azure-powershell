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
using System;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.OperationalInsights.Test
{
    public class DataSourceTests : OperationalInsightsScenarioTestBase
    {
        public XunitTracingInterceptor _logger;

        public DataSourceTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDataSourceCreateUpdateDelete()
        {
            RunPowerShellTest(_logger, "Test-DataSourceCreateUpdateDelete");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDataSourceCreateFailsWithoutWorkspace()
        {
            RunPowerShellTest(_logger, "Test-DataSourceCreateFailsWithoutWorkspace");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAllKindsOfDataSource()
        {
            RunPowerShellTest(_logger, "Test-CreateAllKindsOfDataSource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestToggleSingletonDataSourceState()
        {
            RunPowerShellTest(_logger, "Test-ToggleSingletonDataSourceState");
        }
    }
}
