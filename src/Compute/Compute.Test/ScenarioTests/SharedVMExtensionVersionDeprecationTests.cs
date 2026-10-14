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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    /// <summary>
    /// Deterministic unit tests for the deprecation-status business logic used by
    /// Set-AzSharedVMExtensionVersionDeprecation. These exercise every validation branch
    /// without any live Azure calls.
    /// </summary>
    public class SharedVMExtensionVersionDeprecationTests
    {
        private static readonly DateTime UtcNow = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ActiveWithoutParametersClearsDeprecation()
        {
            var status = SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                ExtensionState.Active, null, null, UtcNow);

            Assert.Equal(ExtensionState.Active, status.State);
            Assert.Null(status.DeprecationTime);
            Assert.Null(status.DeprecationType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ActiveWithDaysThrows()
        {
            Assert.Throws<PSArgumentException>(() =>
                SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                    ExtensionState.Active, 30, null, UtcNow));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ActiveWithTypeThrows()
        {
            Assert.Throws<PSArgumentException>(() =>
                SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                    ExtensionState.Active, null, DeprecationType.Minor, UtcNow));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ScheduledForDeprecationWithBothParametersSetsTimeAndType()
        {
            var status = SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                ExtensionState.ScheduledForDeprecation, 30, DeprecationType.Minor, UtcNow);

            Assert.Equal(ExtensionState.ScheduledForDeprecation, status.State);
            Assert.Equal(DeprecationType.Minor, status.DeprecationType);
            Assert.Equal(UtcNow.AddDays(30), status.DeprecationTime);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ScheduledForDeprecationMissingDaysThrows()
        {
            Assert.Throws<PSArgumentException>(() =>
                SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                    ExtensionState.ScheduledForDeprecation, null, DeprecationType.Minor, UtcNow));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ScheduledForDeprecationMissingTypeThrows()
        {
            Assert.Throws<PSArgumentException>(() =>
                SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                    ExtensionState.ScheduledForDeprecation, 30, null, UtcNow));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ScheduledForDeprecationMissingBothThrows()
        {
            Assert.Throws<PSArgumentException>(() =>
                SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                    ExtensionState.ScheduledForDeprecation, null, null, UtcNow));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DeprecatedWithTypeDeprecatesImmediately()
        {
            var status = SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                ExtensionState.Deprecated, null, DeprecationType.Major, UtcNow);

            Assert.Equal(ExtensionState.Deprecated, status.State);
            Assert.Equal(DeprecationType.Major, status.DeprecationType);
            Assert.Equal(UtcNow, status.DeprecationTime);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DeprecatedMissingTypeThrows()
        {
            Assert.Throws<PSArgumentException>(() =>
                SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                    ExtensionState.Deprecated, null, null, UtcNow));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DeprecatedWithDaysThrows()
        {
            Assert.Throws<PSArgumentException>(() =>
                SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                    ExtensionState.Deprecated, 5, DeprecationType.Major, UtcNow));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void StatusIsRebuiltFromInputsOnly()
        {
            var scheduled = SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                ExtensionState.ScheduledForDeprecation, 30, DeprecationType.Minor, UtcNow);
            var rescheduled = SetAzSharedVMExtensionVersionDeprecation.ComputeDeprecationStatus(
                ExtensionState.ScheduledForDeprecation, 45, DeprecationType.Patch, UtcNow);

            Assert.Equal(DeprecationType.Patch, rescheduled.DeprecationType);
            Assert.Equal(UtcNow.AddDays(45), rescheduled.DeprecationTime);
            Assert.NotEqual(scheduled.DeprecationTime, rescheduled.DeprecationTime);
        }
    }
}
