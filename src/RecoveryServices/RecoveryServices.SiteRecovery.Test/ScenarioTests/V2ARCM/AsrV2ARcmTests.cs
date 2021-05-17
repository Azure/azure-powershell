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

using System;
using System.IO;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace RecoveryServices.SiteRecovery.Test
{
    public class AsrV2ARCMTests : AsrV2ARCMTestsBase
    {
        public XunitTracingInterceptor _logger;

        public AsrV2ARCMTests(
            ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            this.PowershellFile = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "V2ARCM", "AsrV2ARCMTests.ps1");
            this.Initialize();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMFabric()
        {
            this.RunPowerShellTest(_logger, Constants.NewModel, "Test-V2ARCMFabric");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMPolicy()
        {
            this.RunPowerShellTest(_logger, Constants.NewModel, "Test-V2ARCMPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMContainer()
        {
            this.RunPowerShellTest(_logger, Constants.NewModel, "Test-V2ARCMContainer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMContainerMapping()
        {
            this.RunPowerShellTest(_logger, Constants.NewModel, "Test-V2ARCMContainerMapping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestV2ARCMEnableDR()
        {
            this.RunPowerShellTest(_logger, Constants.NewModel, "Test-V2ARCMEnableDR");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMUpdateProtection()
        {
            this.RunPowerShellTest(_logger, Constants.NewModel, "Test-V2ARCMUpdateProtection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMTestFailover()
        {
            this.RunPowerShellTest(_logger, Constants.NewModel, "Test-V2ARCMTestFailover");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMFailover()
        {
            this.RunPowerShellTest(_logger, Constants.NewModel, "Test-V2ARCMFailover");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMCommit()
        {
            this.RunPowerShellTest(_logger, Constants.NewModel, "Test-V2ARCMCommit");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMReprotect()
        {
            this.RunPowerShellTest(_logger, Constants.NewModel, "Test-V2ARCMReprotect");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMFailback()
        {
            this.RunPowerShellTest(_logger, Constants.NewModel, "Test-V2ARCMFailback");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMCancelFailover()
        {
            this.RunPowerShellTest(_logger, Constants.NewModel, "Test-V2ARCMCancelFailover");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMRecoveryPlan()
        {
            this.RunPowerShellTest(_logger, Constants.NewModel, "Test-V2ARCMRecoveryPlan");
        }
    }
}
