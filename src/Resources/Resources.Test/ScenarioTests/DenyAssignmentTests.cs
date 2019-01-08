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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class DenyAssignmentTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public DenyAssignmentTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDa()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDa");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaById()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaById");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByIdAndSpecifiedScope()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByIdAndSpecifiedScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByName()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByNameAndSpecifiedScope()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByNameAndSpecifiedScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByObjectId()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByObjectId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByObjectIdAndGroupExpansion()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByObjectIdAndGroupExpansion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByObjectIdAndRGName()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByObjectIdAndRGName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByObjectIdAndRGNameResourceNameResourceType()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByObjectIdAndRGNameResourceNameResourceType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByObjectIdAndScope()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByObjectIdAndScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaBySignInNameAndRGName()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaBySignInNameAndRGName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaBySignInNameAndRGNameResourceNameResourceType()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaBySignInNameAndRGNameResourceNameResourceType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaBySignInNameAndScope()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaBySignInNameAndScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaBySignInName()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaBySignInName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaBySignInNameAndGroupExpansion()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaBySignInNameAndGroupExpansion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByServicePrincipalName()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByServicePrincipalName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByServicePrincipalNameAndRGName()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByServicePrincipalNameAndRGName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByServicePrincipalNameAndRGNameResourceNameResourceType()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByServicePrincipalNameAndRGNameResourceNameResourceType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByServicePrincipalNameAndScope()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByServicePrincipalNameAndScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByScope()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByRG()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByRG");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByRGNameResourceNameResourceType()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByRGNameResourceNameResourceType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaForEveryoneHasExpectedNameAndType()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaForEveryoneHasExpectedNameAndType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDaByEveryoneObjectId()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetDaByEveryoneObjectId");
        }
    }
}
