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

using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class DenyAssignmentTests : ResourcesTestRunner
    {
        public XunitTracingInterceptor _logger;

        public DenyAssignmentTests(ITestOutputHelper output) : base(output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDa()
        {
            TestRunner.RunTestScript("Test-GetDa");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaById()
        {
            TestRunner.RunTestScript("Test-GetDaById");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByIdAndSpecifiedScope()
        {
            TestRunner.RunTestScript("Test-GetDaByIdAndSpecifiedScope");
        }

        [Fact(Skip = "Name filter issue is detected, refer to: https://github.com/Azure/azure-powershell/issues/16410")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByName()
        {
            TestRunner.RunTestScript("Test-GetDaByName");
        }

        [Fact(Skip = "Name filter issue is detected, refer to: https://github.com/Azure/azure-powershell/issues/16410")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByNameAndSpecifiedScope()
        {
            TestRunner.RunTestScript("Test-GetDaByNameAndSpecifiedScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByObjectId()
        {
            TestRunner.RunTestScript("Test-GetDaByObjectId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByObjectIdAndGroupExpansion()
        {
            TestRunner.RunTestScript("Test-GetDaByObjectIdAndGroupExpansion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByObjectIdAndRGName()
        {
            TestRunner.RunTestScript("Test-GetDaByObjectIdAndRGName");
        }

        [Fact(Skip = "Skip complex scenario temporarily, will test it when bandwidth is allowed")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByObjectIdAndRGNameResourceNameResourceType()
        {
            TestRunner.RunTestScript("Test-GetDaByObjectIdAndRGNameResourceNameResourceType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByObjectIdAndScope()
        {
            TestRunner.RunTestScript("Test-GetDaByObjectIdAndScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaBySignInNameAndRGName()
        {
            TestRunner.RunTestScript("Test-GetDaBySignInNameAndRGName");
        }

        [Fact(Skip = "Skip complex scenario temporarily, will test it when bandwidth is allowed")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaBySignInNameAndRGNameResourceNameResourceType()
        {
            TestRunner.RunTestScript("Test-GetDaBySignInNameAndRGNameResourceNameResourceType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaBySignInNameAndScope()
        {
            TestRunner.RunTestScript("Test-GetDaBySignInNameAndScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaBySignInName()
        {
            TestRunner.RunTestScript("Test-GetDaBySignInName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaBySignInNameAndGroupExpansion()
        {
            TestRunner.RunTestScript("Test-GetDaBySignInNameAndGroupExpansion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByServicePrincipalName()
        {
            TestRunner.RunTestScript("Test-GetDaByServicePrincipalName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByServicePrincipalNameAndRGName()
        {
            TestRunner.RunTestScript("Test-GetDaByServicePrincipalNameAndRGName");
        }

        [Fact(Skip = "Skip complex scenario temporarily, will test it when bandwidth is allowed")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByServicePrincipalNameAndRGNameResourceNameResourceType()
        {
            TestRunner.RunTestScript("Test-GetDaByServicePrincipalNameAndRGNameResourceNameResourceType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByServicePrincipalNameAndScope()
        {
            TestRunner.RunTestScript("Test-GetDaByServicePrincipalNameAndScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByScope()
        {
            TestRunner.RunTestScript("Test-GetDaByScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByRG()
        {
            TestRunner.RunTestScript("Test-GetDaByRG");
        }

        [Fact(Skip = "Skip complex scenario temporarily, will test it when bandwidth is allowed")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByRGNameResourceNameResourceType()
        {
            TestRunner.RunTestScript("Test-GetDaByRGNameResourceNameResourceType");
        }

        [Fact(Skip = "Name filter issue is detected, refer to: https://github.com/Azure/azure-powershell/issues/16410")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaForEveryoneHasExpectedNameAndType()
        {
            TestRunner.RunTestScript("Test-GetDaForEveryoneHasExpectedNameAndType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetDaByEveryoneObjectId()
        {
            TestRunner.RunTestScript("Test-GetDaByEveryoneObjectId");
        }
    }
}
