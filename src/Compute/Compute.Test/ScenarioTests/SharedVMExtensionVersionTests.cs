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

using Microsoft.Azure.Commands.Compute.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class SharedVMExtensionVersionTests
    {
        private const string ResourceId =
            "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.Compute/sharedVMExtensions/myVMExtension/versions/1.0.0";

        public SharedVMExtensionVersionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSharedVMExtensionVersionResourceIdParsing()
        {
            Assert.Equal("myResourceGroup", ComputeAutomationBaseCmdlet.GetResourceGroupName(ResourceId));
            Assert.Equal("myVMExtension", ComputeAutomationBaseCmdlet.GetResourceName(ResourceId, "Microsoft.Compute/sharedVMExtensions", "versions"));
            Assert.Equal("1.0.0", ComputeAutomationBaseCmdlet.GetInstanceId(ResourceId, "Microsoft.Compute/sharedVMExtensions", "versions"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSharedVMExtensionVersionMapping()
        {
            var deprecationTime = DateTime.UtcNow.AddDays(90);
            var sdkObject = new SharedVMExtensionVersion(
                location: "westus",
                id: ResourceId,
                name: "1.0.0",
                type: "Microsoft.Compute/sharedVMExtensions/versions",
                mediaLink: "https://example.com/media.zip",
                regions: new[] { "westus", "eastus" },
                computeRole: "IaaS",
                deprecationStatus: new ExtensionDeprecationStatus(
                    state: ExtensionState.ScheduledForDeprecation,
                    deprecationTime: deprecationTime,
                    deprecationType: DeprecationType.Minor));

            var psObject = new PSSharedVMExtensionVersion();
            ComputeAutomationAutoMapperProfile.Mapper.Map<SharedVMExtensionVersion, PSSharedVMExtensionVersion>(sdkObject, psObject);

            Assert.Equal(ResourceId, psObject.Id);
            Assert.Equal("westus", psObject.Location);
            Assert.Equal("https://example.com/media.zip", psObject.MediaLink);
            Assert.NotNull(psObject.DeprecationStatus);
            Assert.Equal(ExtensionState.ScheduledForDeprecation, psObject.DeprecationStatus.State);
            Assert.Equal(deprecationTime, psObject.DeprecationStatus.DeprecationTime);
            Assert.Equal(DeprecationType.Minor, psObject.DeprecationStatus.DeprecationType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestScheduleDeprecationSetsTimeAndType()
        {
            var utcNow = DateTime.UtcNow;

            var result = SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                existing: null,
                deprecationState: ExtensionState.ScheduledForDeprecation,
                daysUntilDeprecation: 90,
                deprecationType: DeprecationType.Minor,
                utcNow: utcNow);

            Assert.Equal(ExtensionState.ScheduledForDeprecation, result.State);
            Assert.Equal(utcNow.AddDays(90), result.DeprecationTime);
            Assert.Equal(DeprecationType.Minor, result.DeprecationType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestScheduleDeprecationWithoutDaysThrowsWhenNoPriorValueExists()
        {
            Assert.Throws<PSArgumentException>(() => SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                existing: null,
                deprecationState: ExtensionState.ScheduledForDeprecation,
                daysUntilDeprecation: null,
                deprecationType: null,
                utcNow: DateTime.UtcNow));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestReactivateClearsStaleDeprecationData()
        {
            var existing = new ExtensionDeprecationStatus(
                state: ExtensionState.ScheduledForDeprecation,
                deprecationTime: DateTime.UtcNow.AddDays(30),
                deprecationType: DeprecationType.Major);

            var result = SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                existing: existing,
                deprecationState: ExtensionState.Active,
                daysUntilDeprecation: null,
                deprecationType: null,
                utcNow: DateTime.UtcNow);

            Assert.Equal(ExtensionState.Active, result.State);
            Assert.Null(result.DeprecationTime);
            Assert.Null(result.DeprecationType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestReactivateWithExplicitValuesKeepsThem()
        {
            var existing = new ExtensionDeprecationStatus(
                state: ExtensionState.ScheduledForDeprecation,
                deprecationTime: DateTime.UtcNow.AddDays(30),
                deprecationType: DeprecationType.Major);
            var utcNow = DateTime.UtcNow;

            var result = SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                existing: existing,
                deprecationState: ExtensionState.Active,
                daysUntilDeprecation: 10,
                deprecationType: DeprecationType.Patch,
                utcNow: utcNow);

            Assert.Equal(ExtensionState.Active, result.State);
            Assert.Equal(utcNow.AddDays(10), result.DeprecationTime);
            Assert.Equal(DeprecationType.Patch, result.DeprecationType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestReactivateWithOnlyOneOverrideThrows()
        {
            Assert.Throws<PSArgumentException>(() => SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                existing: null,
                deprecationState: ExtensionState.Active,
                daysUntilDeprecation: 10,
                deprecationType: null,
                utcNow: DateTime.UtcNow));

            Assert.Throws<PSArgumentException>(() => SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                existing: null,
                deprecationState: ExtensionState.Active,
                daysUntilDeprecation: null,
                deprecationType: DeprecationType.Patch,
                utcNow: DateTime.UtcNow));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdatingDeprecatedStatePreservesExistingScheduleWhenNotOverridden()
        {
            var existing = new ExtensionDeprecationStatus(
                state: ExtensionState.ScheduledForDeprecation,
                deprecationTime: DateTime.UtcNow.AddDays(5),
                deprecationType: DeprecationType.Hotfix);

            var result = SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                existing: existing,
                deprecationState: ExtensionState.Deprecated,
                daysUntilDeprecation: null,
                deprecationType: null,
                utcNow: DateTime.UtcNow);

            Assert.Equal(ExtensionState.Deprecated, result.State);
            Assert.Equal(existing.DeprecationTime, result.DeprecationTime);
            Assert.Equal(DeprecationType.Hotfix, result.DeprecationType);
        }
    }
}
