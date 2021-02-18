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

using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Support.Test.ScenarioTests
{
    public class SupportTicketTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public SupportTicketTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzSupportTicketByNameParameterSet()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzSupportTicketByNameParameterSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzSupportTicketFilterByStatus()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzSupportTicketFilterByStatus");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzSupportTicketPagingParameters()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzSupportTicketPagingParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketWithContactObject()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "New-AzSupportTicketWithContactObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketQuotaWithContactObject()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "New-AzSupportTicketQuotaWithContactObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketTechnicalWithContactObject()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "New-AzSupportTicketTechnicalWithContactObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketWithContactDetail()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "New-AzSupportTicketWithContactDetail");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketQuotaWithContactDetail()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "New-AzSupportTicketQuotaWithContactDetail");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketTechnicalWithContactDetail()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, string.Format("New-AzSupportTicketTechnicalWithContactDetail"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketParentObjectParameterSetWithContactObject()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Update-AzSupportTicketParentObjectParameterSetWithContactObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketNameParameterSetWithContactObject()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Update-AzSupportTicketNameParameterSetWithContactObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketParentObjectParameterSetWithContactDetail()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Update-AzSupportTicketParentObjectParameterSetWithContactDetail");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketNameParameterSetWithContactDetail()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Update-AzSupportTicketNameParameterSetWithContactDetail");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketParentObjectParameterSetUpdateSeverity()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Update-AzSupportTicketParentObjectParameterSetUpdateSeverity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketNameParameterSetUpdateSeverity()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Update-AzSupportTicketNameParameterSetUpdateSeverity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketParentObjectParameterSetUpdateStatus()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Update-AzSupportTicketParentObjectParameterSetUpdateStatus");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketNameParameterSetUpdateStatus()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Update-AzSupportTicketNameParameterSetUpdateStatus");
        }
    }
}