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

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    using WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Xunit.Abstractions;

    public class DeploymentWhatIfTests : ResourceTestRunner
    {
        public DeploymentWhatIfTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RGLevelWhatIf_BlankTemplate_ReturnsNoChange()
        {
            TestRunner.RunTestScript("Test-WhatIfWithBlankTemplateAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RGLevelWhatIf_ResourceIdOnlyMode_ReturnsChanges()
        {
            TestRunner.RunTestScript("Test-WhatIfWithResourceIdOnlyAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RGLevelWhatIf_CreateResources_ReturnsCreateChanges()
        {
            TestRunner.RunTestScript("Test-WhatIfCreateResourcesAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RGLevelWhatIf_ModifyResources_ReturnsModifyChanges()
        {
            TestRunner.RunTestScript("Test-WhatIfModifyResourcesAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RGLevelWhatIf_DeleteResources_ReturnsDeleteChanges()
        {
            TestRunner.RunTestScript("Test-WhatIfDeleteResourcesAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubLevelWhatIf_BlankTemplate_ReturnsNoChange()
        {
            TestRunner.RunTestScript("Test-WhatIfWithBlankTemplateAtSubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubLevelWhatIf_ResourceIdOnlyMode_ReturnsChanges()
        {
            TestRunner.RunTestScript("Test-WhatIfWithResourceIdOnlyAtSubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubLevelWhatIf_CreateResources_ReturnsCreateChanges()
        {
            TestRunner.RunTestScript("Test-WhatIfCreateResourcesAtSubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubLevelWhatIf_ModifyResources_ReturnsModifyChanges()
        {
            TestRunner.RunTestScript("Test-WhatIfModifyResourcesAtSubscriptionScope");
        }
    }
}

