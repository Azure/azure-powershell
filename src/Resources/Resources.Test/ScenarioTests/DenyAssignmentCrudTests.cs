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
    /// <summary>
    /// Tests for New-AzDenyAssignment and Remove-AzDenyAssignment cmdlets.
    /// Covers both Everyone mode and per-principal (User/ServicePrincipal) mode.
    /// </summary>
    public class DenyAssignmentCrudTests : ResourcesTestRunner
    {
        public DenyAssignmentCrudTests(ITestOutputHelper output) : base(output)
        {
        }

        // =============================================
        // New-AzDenyAssignment tests
        // =============================================

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void NewDaAtSubscriptionScope()
        {
            TestRunner.RunTestScript("Test-NewDaAtSubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void NewDaAtResourceGroupScope()
        {
            TestRunner.RunTestScript("Test-NewDaAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void NewDaWithDataActions()
        {
            TestRunner.RunTestScript("Test-NewDaWithDataActions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void NewDaWithExcludePrincipals()
        {
            TestRunner.RunTestScript("Test-NewDaWithExcludePrincipals");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void NewDaDoNotApplyToChildScopes()
        {
            TestRunner.RunTestScript("Test-NewDaDoNotApplyToChildScopes");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void NewDaFromInputFile()
        {
            TestRunner.RunTestScript("Test-NewDaFromInputFile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void NewDaWithCustomId()
        {
            TestRunner.RunTestScript("Test-NewDaWithCustomId");
        }

        // =============================================
        // Per-Principal deny assignment tests
        // =============================================

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void NewDaWithUserPrincipal()
        {
            TestRunner.RunTestScript("Test-NewDaWithUserPrincipal");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void NewDaWithServicePrincipal()
        {
            TestRunner.RunTestScript("Test-NewDaWithServicePrincipal");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void NewDaPerPrincipalNoExcludes()
        {
            TestRunner.RunTestScript("Test-NewDaPerPrincipalNoExcludes");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void NewDaPerPrincipalWithExcludes()
        {
            TestRunner.RunTestScript("Test-NewDaPerPrincipalWithExcludes");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void NewDaPerPrincipalGroupRejected()
        {
            TestRunner.RunTestScript("Test-NewDaPerPrincipalGroupRejected");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void NewDaPerPrincipalFromInputFile()
        {
            TestRunner.RunTestScript("Test-NewDaPerPrincipalFromInputFile");
        }

        // =============================================
        // Remove-AzDenyAssignment tests
        // =============================================

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RemoveDaById()
        {
            TestRunner.RunTestScript("Test-RemoveDaById");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RemoveDaByNameAndScope()
        {
            TestRunner.RunTestScript("Test-RemoveDaByNameAndScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RemoveDaByInputObject()
        {
            TestRunner.RunTestScript("Test-RemoveDaByInputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RemoveDaWithPassThru()
        {
            TestRunner.RunTestScript("Test-RemoveDaWithPassThru");
        }

        // =============================================
        // End-to-end: Create then Delete
        // =============================================

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void NewAndRemoveDaEndToEnd()
        {
            TestRunner.RunTestScript("Test-NewAndRemoveDaEndToEnd");
        }
    }
}
