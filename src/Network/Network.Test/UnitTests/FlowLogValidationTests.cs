// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
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
            Assert.Null(Record.Exception(() => ValidateFormatVersion(formatVersion)));
        }

        [Theory]
        [InlineData("XML")]
        [InlineData("CSV")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InvalidFormatTypeReportsFormatTypeError(string formatType)
        {
            var command = new NewAzNetworkWatcherFlowLogCommand();

            var exception = Assert.Throws<System.Management.Automation.PSArgumentException>(
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

            Assert.Contains("format type", exception.Message, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
