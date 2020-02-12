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
    public class CommunicationTests
    {
        private XunitTracingInterceptor _logger;

        public CommunicationTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketCommunicationNameParameterSet()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "New-AzSupportTicketCommunicationNameParameterSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzSupportTicketCommunicationParentObjectParameterSet()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "New-AzSupportTicketCommunicationParentObjectParameterSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzSupportTicketCommunicationByNameParameterSet()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzSupportTicketCommunicationByNameParameterSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzSupportTicketCommunicationFilterByCommunicationType()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzSupportTicketCommunicationFilterByCommunicationType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzSupportTicketCommunicationPagingParameters()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzSupportTicketCommunicationPagingParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzSupportTicketCommunicationByParentObjectParameterSet()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzSupportTicketCommunicationByParentObjectParameterSet");
        }
    }
}
