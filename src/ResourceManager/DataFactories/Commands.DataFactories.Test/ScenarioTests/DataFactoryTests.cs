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

namespace Microsoft.Azure.Commands.DataFactories.Test
{
    public class DataFactoryTests : DataFactoriesScenarioTestsBase
    {
        public XunitTracingInterceptor _logger;

        public DataFactoryTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

#if NETSTANDARD
        [Fact(Skip = "Management library needs NetCore republish")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNonExistingDataFactory()
        {
            RunPowerShellTest(_logger, "Test-GetNonExistingDataFactory");
        }

#if NETSTANDARD
        [Fact(Skip = "Management library needs NetCore republish")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDataFactory()
        {
            RunPowerShellTest(_logger, "Test-CreateDataFactory");
        }

#if NETSTANDARD
        [Fact(Skip = "Management library needs NetCore republish")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteDataFactoryWithDataFactoryParameter()
        {
            RunPowerShellTest(_logger, "Test-DeleteDataFactoryWithDataFactoryParameter");
        }

#if NETSTANDARD
        [Fact(Skip = "Management library needs NetCore republish")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDataFactoryPiping()
        {
            RunPowerShellTest(_logger, "Test-DataFactoryPiping");
        }
    }
}
