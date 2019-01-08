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
    public class DenyAssignmentTests : ResourceTestRunner
    {
        public XunitTracingInterceptor _logger;

        public DenyAssignmentTests(ITestOutputHelper output) : base(output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDa()
        {
            TestRunner.RunTestScript("Test-GetDa");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaById()
        {
            TestRunner.RunTestScript("Test-GetDaById");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByIdAndSpecifiedScope()
        {
            TestRunner.RunTestScript("Test-GetDaByIdAndSpecifiedScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByName()
        {
            TestRunner.RunTestScript("Test-GetDaByName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByNameAndSpecifiedScope()
        {
            TestRunner.RunTestScript("Test-GetDaByNameAndSpecifiedScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByObjectId()
        {
            TestRunner.RunTestScript("Test-GetDaByObjectId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByObjectIdAndGroupExpansion()
        {
            TestRunner.RunTestScript("Test-GetDaByObjectIdAndGroupExpansion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByObjectIdAndRGName()
        {
            TestRunner.RunTestScript("Test-GetDaByObjectIdAndRGName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByObjectIdAndRGNameResourceNameResourceType()
        {
            TestRunner.RunTestScript("Test-GetDaByObjectIdAndRGNameResourceNameResourceType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByObjectIdAndScope()
        {
            TestRunner.RunTestScript("Test-GetDaByObjectIdAndScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaBySignInNameAndRGName()
        {
            TestRunner.RunTestScript("Test-GetDaBySignInNameAndRGName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaBySignInNameAndRGNameResourceNameResourceType()
        {
            TestRunner.RunTestScript("Test-GetDaBySignInNameAndRGNameResourceNameResourceType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaBySignInNameAndScope()
        {
            TestRunner.RunTestScript("Test-GetDaBySignInNameAndScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaBySignInName()
        {
            TestRunner.RunTestScript("Test-GetDaBySignInName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaBySignInNameAndGroupExpansion()
        {
            TestRunner.RunTestScript("Test-GetDaBySignInNameAndGroupExpansion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByServicePrincipalName()
        {
            TestRunner.RunTestScript("Test-GetDaByServicePrincipalName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByServicePrincipalNameAndRGName()
        {
            TestRunner.RunTestScript("Test-GetDaByServicePrincipalNameAndRGName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByServicePrincipalNameAndRGNameResourceNameResourceType()
        {
            TestRunner.RunTestScript("Test-GetDaByServicePrincipalNameAndRGNameResourceNameResourceType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByServicePrincipalNameAndScope()
        {
            TestRunner.RunTestScript("Test-GetDaByServicePrincipalNameAndScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByScope()
        {
            TestRunner.RunTestScript("Test-GetDaByScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByRG()
        {
            TestRunner.RunTestScript("Test-GetDaByRG");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByRGNameResourceNameResourceType()
        {
            TestRunner.RunTestScript("Test-GetDaByRGNameResourceNameResourceType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaForEveryoneHasExpectedNameAndType()
        {
            TestRunner.RunTestScript("Test-GetDaForEveryoneHasExpectedNameAndType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByEveryoneObjectId()
        {
            TestRunner.RunTestScript("Test-GetDaByEveryoneObjectId");
        }
    }
}
