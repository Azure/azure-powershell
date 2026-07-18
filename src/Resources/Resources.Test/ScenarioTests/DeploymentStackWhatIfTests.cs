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
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class DeploymentStackWhatIfTests : ResourcesTestRunner
    {
        public DeploymentStackWhatIfTests(ITestOutputHelper output) : base(output)
        {
        }

        // ---- Resource Group Scope ----

        // Validates creating RG-scope WhatIf results with template parameters, identity fields, property changes, and missing template errors.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-NewResourceGroupDeploymentStackWhatIfResult");
        }

        // Validates updating an existing RG-scope WhatIf result and preserving expected identity fields across action-on-unmanage changes.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetResourceGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-SetResourceGroupDeploymentStackWhatIfResult");
        }

        // Validates listing and getting RG-scope WhatIf results by name, including list membership and not-found handling.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-GetResourceGroupDeploymentStackWhatIfResult");
        }

        // Validates removing an RG-scope WhatIf result and confirming it is no longer returned by direct get or list.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveResourceGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-RemoveResourceGroupDeploymentStackWhatIfResult");
        }

        // Validates New RG-scope WhatIf result output includes property changes and does not render null deployment-scope text.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceGroupDeploymentStackWhatIfReturnsPropertyChanges()
        {
            TestRunner.RunTestScript("Test-NewResourceGroupDeploymentStackWhatIfReturnsPropertyChanges");
        }

        // Validates RG-scope Get with -WithPropertyChanges uses the WhatIf POST path and returns resource-change details.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceGroupDeploymentStackWhatIfWithPropertyChanges()
        {
            TestRunner.RunTestScript("Test-GetResourceGroupDeploymentStackWhatIfWithPropertyChanges");
        }

        // Validates RG-scope Get by ResourceId resolves the correct WhatIf result and rejects malformed resource IDs.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceGroupDeploymentStackWhatIfResultByResourceId()
        {
            TestRunner.RunTestScript("Test-GetResourceGroupDeploymentStackWhatIfResultByResourceId");
        }

        // ---- Subscription Scope ----

        // Validates creating subscription-scope WhatIf results, identity fields, missing template errors, and explicit unavailable-service handling.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSubscriptionDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-NewSubscriptionDeploymentStackWhatIfResult");
        }

        // Validates updating subscription-scope WhatIf results when available, including action-on-unmanage changes and unavailable-service handling.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetSubscriptionDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-SetSubscriptionDeploymentStackWhatIfResult");
        }

        // Validates listing and getting subscription-scope WhatIf results by name when available, including not-found handling.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSubscriptionDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-GetSubscriptionDeploymentStackWhatIfResult");
        }

        // Validates removing subscription-scope WhatIf results when available and confirming direct get/list no longer return them.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSubscriptionDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-RemoveSubscriptionDeploymentStackWhatIfResult");
        }

        // Validates New subscription-scope WhatIf output formatting and property handling, with explicit unavailable-service handling.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSubscriptionDeploymentStackWhatIfReturnsPropertyChanges()
        {
            TestRunner.RunTestScript("Test-NewSubscriptionDeploymentStackWhatIfReturnsPropertyChanges");
        }

        // Validates subscription-scope Get with -WithPropertyChanges when available and skips follow-up checks only after asserting unavailable service.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSubscriptionDeploymentStackWhatIfWithPropertyChanges()
        {
            TestRunner.RunTestScript("Test-GetSubscriptionDeploymentStackWhatIfWithPropertyChanges");
        }

        // Validates subscription-scope Get by ResourceId and malformed ResourceId errors when the service creates a result.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSubscriptionDeploymentStackWhatIfResultByResourceId()
        {
            TestRunner.RunTestScript("Test-GetSubscriptionDeploymentStackWhatIfResultByResourceId");
        }

        // ---- Management Group Scope ----

        // Validates creating management-group-scope WhatIf results with a configurable management group and unavailable-service handling.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-NewManagementGroupDeploymentStackWhatIfResult");
        }

        // Validates updating management-group-scope WhatIf results when available, including identity fields and action-on-unmanage changes.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetManagementGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-SetManagementGroupDeploymentStackWhatIfResult");
        }

        // Validates listing and getting management-group-scope WhatIf results by name, including list membership and not-found handling.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-GetManagementGroupDeploymentStackWhatIfResult");
        }

        // Validates removing management-group-scope WhatIf results and confirming they are no longer returned.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveManagementGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-RemoveManagementGroupDeploymentStackWhatIfResult");
        }

        // Validates New management-group-scope WhatIf output formatting and property handling, with explicit unavailable-service handling.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupDeploymentStackWhatIfReturnsPropertyChanges()
        {
            TestRunner.RunTestScript("Test-NewManagementGroupDeploymentStackWhatIfReturnsPropertyChanges");
        }

        // Validates management-group-scope Get with -WithPropertyChanges when available and identity fields across GET/POST paths.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroupDeploymentStackWhatIfWithPropertyChanges()
        {
            TestRunner.RunTestScript("Test-GetManagementGroupDeploymentStackWhatIfWithPropertyChanges");
        }

        // Validates management-group-scope Get by ResourceId and malformed ResourceId errors when the service creates a result.
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroupDeploymentStackWhatIfResultByResourceId()
        {
            TestRunner.RunTestScript("Test-GetManagementGroupDeploymentStackWhatIfResultByResourceId");
        }
    }
}
