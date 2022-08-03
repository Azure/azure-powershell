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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Support.Test.ScenarioTests
{
    public class SupportTicketTests : SupportTestRunner
    {
        public SupportTicketTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzSupportTicketByNameParameterSet()
        {
            TestRunner.RunTestScript("Get-AzSupportTicketByNameParameterSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzSupportTicketFilterByStatus()
        {
            TestRunner.RunTestScript("Get-AzSupportTicketFilterByStatus");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzSupportTicketPagingParameters()
        {
            TestRunner.RunTestScript("Get-AzSupportTicketPagingParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketWithContactObject()
        {
            TestRunner.RunTestScript("New-AzSupportTicketWithContactObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketQuotaWithContactObject()
        {
            TestRunner.RunTestScript("New-AzSupportTicketQuotaWithContactObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketTechnicalWithContactObject()
        {
            TestRunner.RunTestScript("New-AzSupportTicketTechnicalWithContactObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketWithContactDetail()
        {
            TestRunner.RunTestScript("New-AzSupportTicketWithContactDetail");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketQuotaWithContactDetail()
        {
            TestRunner.RunTestScript("New-AzSupportTicketQuotaWithContactDetail");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketTechnicalWithContactDetail()
        {
            TestRunner.RunTestScript(string.Format("New-AzSupportTicketTechnicalWithContactDetail"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketParentObjectParameterSetWithContactObject()
        {
            TestRunner.RunTestScript("Update-AzSupportTicketParentObjectParameterSetWithContactObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketNameParameterSetWithContactObject()
        {
            TestRunner.RunTestScript("Update-AzSupportTicketNameParameterSetWithContactObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketParentObjectParameterSetWithContactDetail()
        {
            TestRunner.RunTestScript("Update-AzSupportTicketParentObjectParameterSetWithContactDetail");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketNameParameterSetWithContactDetail()
        {
            TestRunner.RunTestScript("Update-AzSupportTicketNameParameterSetWithContactDetail");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketParentObjectParameterSetUpdateSeverity()
        {
            TestRunner.RunTestScript("Update-AzSupportTicketParentObjectParameterSetUpdateSeverity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketNameParameterSetUpdateSeverity()
        {
            TestRunner.RunTestScript("Update-AzSupportTicketNameParameterSetUpdateSeverity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketParentObjectParameterSetUpdateStatus()
        {
            TestRunner.RunTestScript("Update-AzSupportTicketParentObjectParameterSetUpdateStatus");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzSupportTicketNameParameterSetUpdateStatus()
        {
            TestRunner.RunTestScript("Update-AzSupportTicketNameParameterSetUpdateStatus");
        }
    }
}