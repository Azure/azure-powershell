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

using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Commands.Network.Properties;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Management.Automation;
using Xunit;

namespace Commands.Network.Test.UnitTests
{
    public class FlowLogValidationTests
    {
        private const string TargetResourceId =
            "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Network/networkSecurityGroups/test-nsg";

        private const string StorageId =
            "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Storage/storageAccounts/teststorage";

        private static void ValidateFormatVersion(int? formatVersion)
        {
            var command = new NewAzNetworkWatcherFlowLogCommand();

            command.ValidateFlowLogParameters(
                targetResourceId: TargetResourceId,
                storageId: StorageId,
                enabledFilteringCriteria: null,
                recordType: null,
                formatVersion: formatVersion,
                formatType: "JSON",
                enableTrafficAnalytics: false,
                trafficAnalyticsWorkspaceId: null,
                trafficAnalyticsInterval: null,
                retentionPolicyDays: null,
                userAssignedIdentityId: null);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PreviouslySupportedFormatVersionsAreAccepted(int? formatVersion)
        {
            Assert.Null(Record.Exception(() => ValidateFormatVersion(formatVersion)));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(10)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FormatVersionIsNoLongerValidatedOnTheClient(int formatVersion)
        {
            // Previously these values (> 2) were rejected client-side. The upper-bound check
            // has been removed since the service is authoritative on which versions are supported.
            Assert.Null(Record.Exception(() => ValidateFormatVersion(formatVersion)));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-5)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NegativeFormatVersionStillThrowsClientSide(int formatVersion)
        {
            var exception = Assert.Throws<PSArgumentException>(
                () => ValidateFormatVersion(formatVersion));

            Assert.Equal(Resources.InvalidFlowLogFormatVersion, exception.Message);
        }

        [Theory]
        [InlineData("XML")]
        [InlineData("CSV")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InvalidFormatTypeReportsFormatTypeError(string formatType)
        {
            var command = new NewAzNetworkWatcherFlowLogCommand();

            var exception = Assert.Throws<PSArgumentException>(
                () => command.ValidateFlowLogParameters(
                    targetResourceId: TargetResourceId,
                    storageId: StorageId,
                    enabledFilteringCriteria: null,
                    recordType: null,
                    formatVersion: null,
                    formatType: formatType,
                    enableTrafficAnalytics: false,
                    trafficAnalyticsWorkspaceId: null,
                    trafficAnalyticsInterval: null,
                    retentionPolicyDays: null,
                    userAssignedIdentityId: null));

            Assert.Equal(Resources.InvalidFlowLogFormatType, exception.Message);
        }

        [Theory]
        [InlineData("JSON")]
        [InlineData("FlowLogJSON")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidFormatTypeDoesNotThrow(string formatType)
        {
            var command = new NewAzNetworkWatcherFlowLogCommand();

            var exception = Record.Exception(() => command.ValidateFlowLogParameters(
                targetResourceId: TargetResourceId,
                storageId: StorageId,
                enabledFilteringCriteria: null,
                recordType: null,
                formatVersion: null,
                formatType: formatType,
                enableTrafficAnalytics: false,
                trafficAnalyticsWorkspaceId: null,
                trafficAnalyticsInterval: null,
                retentionPolicyDays: null,
                userAssignedIdentityId: null));

            Assert.Null(exception);
        }
    }
}
