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
    public class CommunicationTests : SupportTestRunner
    {
        public CommunicationTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketCommunicationNameParameterSet()
        {
            TestRunner.RunTestScript("New-AzSupportTicketCommunicationNameParameterSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketCommunicationParentObjectParameterSet()
        {
            TestRunner.RunTestScript("New-AzSupportTicketCommunicationParentObjectParameterSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzSupportTicketCommunicationByNameParameterSet()
        {
            TestRunner.RunTestScript("Get-AzSupportTicketCommunicationByNameParameterSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzSupportTicketCommunicationFilterByCommunicationType()
        {
            TestRunner.RunTestScript("Get-AzSupportTicketCommunicationFilterByCommunicationType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzSupportTicketCommunicationPagingParameters()
        {
            TestRunner.RunTestScript("Get-AzSupportTicketCommunicationPagingParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzSupportTicketCommunicationByParentObjectParameterSet()
        {
            TestRunner.RunTestScript("Get-AzSupportTicketCommunicationByParentObjectParameterSet");
        }
    }
}
