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

using Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry;
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Subsystem.Prediction;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test
{
    /// <summary>
    /// This class is to test the logic whether we collect the telemetry events correctly.
    /// There are some tests in <see cref="AzPredictor"/> covering telemetry.
    /// </summary>
    [Collection("Model collection")]
    public sealed class AzPredictorTelemetryTests
    {
        private readonly ModelFixture _fixture;

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictorTelemetryTests"/>
        /// </summary>
        public AzPredictorTelemetryTests(ModelFixture modelFixture)
        {
            _fixture = modelFixture;
        }

        /// <summary>
        /// Verify that the unsupported commands are replaced with placeholders in <see cref="AzPredictor.OnCommandLineAccepted"/>.
        /// </summary>
        [Theory]
        [InlineData("git status")]
        [InlineData("New-Item")]
        [InlineData(@"$a=ls 'ResourceGroup01'")]
        [InlineData(@"C:\Users\MyName\exe param")]
        [InlineData(@"C:\Users\MyName\exe")]
        [InlineData(@"az storage")]
        [InlineData(@"get")]
        [InlineData(@"-StorageAccountKey""xxx""NewAzStorageContainer -context xxx")]
        [InlineData(@"-StorageAccountKey\""xxx\""NewAzStorageContainer -context xxx")]
        [InlineData(@"-StorageAccountKey""xxx""New-AzStorageContainer -context xxx")]
        [InlineData(@"New-AzureStorageContext-StorageAccountName ""xxx"" -StorageAccountKey ""xxx""")]
        [InlineData(@"sig=xxxxxxxxxxx/Sensor-Azure")]
        [InlineData(@"sig=Signature/Test-Sensor-Azu")]
        public async Task VerifyOnCommandLineAcceptedForOneUnsupportedCommandHistory(string inputData)
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            IReadOnlyList<string> history = new List<string>()
            {
                inputData
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history[0], false);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(new List<string>() { AzPredictorConstants.CommandPlaceholder, AzPredictorConstants.CommandPlaceholder }, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);
            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameCommand]);
            Assert.Equal("False", telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameSuccess]);
            Assert.False(telemetryClient.RecordedTelemetry[0].Properties.ContainsKey(RequestPredictionTelemetryData.PropertyNameHttpRequestSent));

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[1].Properties[RequestPredictionTelemetryData.PropertyNameHttpRequestSent]);
            Assert.False(telemetryClient.RecordedTelemetry[1].Properties.ContainsKey(HistoryTelemetryData.PropertyNameCommand));

            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);
            Assert.NotEqual(telemetryClient.RecordedTelemetry[0].Properties["RequestId"], telemetryClient.RecordedTelemetry[1].Properties["RequestId"]);

            Assert.Null(telemetryClient.GetSuggestionData);
            Assert.Null(telemetryClient.SuggestionDisplayedData);
            Assert.Null(telemetryClient.SuggestionAcceptedData);
            Assert.Null(telemetryClient.ParameterMapData);
        }

        /// <summary>
        /// Verify that the parameter values in the supported commands are masked in <see cref="AzPredictor.OnCommandLineAccepted"/>.
        /// </summary>
        [Theory]
        [InlineData("Get-LogProperties", "Get-LogProperties")]
        [InlineData("Get-AzVM", "$a=Get-AzVM")]
        public async Task VerifyOnCommandLineAcceptedForOneSupportedCommandWithoutParameter(string expectedValue, string inputData)
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            // There is only one command.
            IReadOnlyList<string> history = new List<string>()
            {
                inputData
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history[0], true);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(expectedValue, telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(new List<string>() { AzPredictorConstants.CommandPlaceholder, expectedValue }, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(expectedValue, telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameCommand]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameSuccess]);

            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);
            Assert.NotEqual(telemetryClient.RecordedTelemetry[0].Properties["RequestId"], telemetryClient.RecordedTelemetry[1].Properties["RequestId"]);

            Assert.Null(telemetryClient.GetSuggestionData);
            Assert.Null(telemetryClient.SuggestionDisplayedData);
            Assert.Null(telemetryClient.SuggestionAcceptedData);
            Assert.Null(telemetryClient.ParameterMapData);
        }

        /// <summary>
        /// Verify that the parameter values in the supported commands are masked in <see cref="AzPredictor.OnCommandLineAccepted"/>.
        /// </summary>
        [Theory]
        [InlineData("Clear-Variable -Name *** -Scope ***", "Clear-Variable -Name my* -Scope Global")]
        [InlineData("Get-AzRoleAssignment -ObjectId ***", "Remove-AzRoleAssignment -RoleDefinitionId (Get-AzRoleAssignment -ObjectId xxxx)")]
        [InlineData("Get-AzResourceGroup -Location:***", "Get-AzResourceGroup rg1 -Location:WestUS3")]
        [InlineData("Get-AzResourceGroup", "Get-AzResourceGroup rg1 WestUS3")]
        [InlineData("New-AzureStorageContext -StorageAccountKey *** -StorageAccountName ***", @"New-AzureStorageContext -StorageAccountName ""accountName"" -StorageAccountKey ""accountKey""")]
        public async Task VerifyOnCommandLineAcceptedForOneSupportedCommandWithParameter(string expectedValue, string inputData)
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            // There is only one command with parameter.
            var history = new List<string>()
            {
                inputData
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history[0], true);

            var maskedCommand = expectedValue;

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommand, telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);
            Assert.Equal(new List<string>() { AzPredictorConstants.CommandPlaceholder, maskedCommand }, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(maskedCommand, telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameCommand]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameSuccess]);
            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[1].Properties[RequestPredictionTelemetryData.PropertyNameHttpRequestSent]);

            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);
            Assert.NotEqual(telemetryClient.RecordedTelemetry[0].Properties["RequestId"], telemetryClient.RecordedTelemetry[1].Properties["RequestId"]);

            Assert.Null(telemetryClient.GetSuggestionData);
            Assert.Null(telemetryClient.SuggestionDisplayedData);
            Assert.Null(telemetryClient.SuggestionAcceptedData);
            Assert.Null(telemetryClient.ParameterMapData);
        }

        /// <summary>
        /// Verify that the parameter values in the supported commands are masked in <see cref="AzPredictor.OnCommandLineAccepted"/>.
        /// </summary>
        [Fact]
        public async Task VerifyOnCommandLineAcceptedForTwoSupportedCommandHistory()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);
            IReadOnlyList<string> history = new List<string>()
            {
                "Write-Output 'Hello' | Set-Content -Path C:\\Temp\\* -Filter *.txt",
                "Get-LogProperties -Name:'Windows PowerShell'"
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history[1], false);

            var maskedCommands = new List<string>()
            {
                "Set-Content -Filter *** -Path ***",
                "Get-LogProperties -Name:***"
            };

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommands[1], telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(maskedCommands, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(maskedCommands[1], telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameCommand]);
            Assert.Equal("False", telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameSuccess]);
            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[1].Properties[RequestPredictionTelemetryData.PropertyNameHttpRequestSent]);

            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);
            Assert.NotEqual(telemetryClient.RecordedTelemetry[0].Properties["RequestId"], telemetryClient.RecordedTelemetry[1].Properties["RequestId"]);

            Assert.Null(telemetryClient.GetSuggestionData);
            Assert.Null(telemetryClient.SuggestionDisplayedData);
            Assert.Null(telemetryClient.SuggestionAcceptedData);
            Assert.Null(telemetryClient.ParameterMapData);
        }

        /// <summary>
        ///  Verify that we can handle the two unsupported command in sequences.
        /// </summary>
        [Fact]
        public async Task VerifyOnCommandLineAcceptedForTwoUnsupportedCommandInHistory()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            IReadOnlyList<string> history = new List<string>()
            {
                "git status",
                @"$a='ResourceGroup01'",
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history[1], true);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(new List<string>() { AzPredictorConstants.CommandPlaceholder, AzPredictorConstants.CommandPlaceholder }, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);
            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameSuccess]);
            // Should use the placeholder for the assignment like \"$a='ResourceGroup01'\" where there is no command name at the right side.
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameCommand]);
            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[1].Properties[RequestPredictionTelemetryData.PropertyNameHttpRequestSent]);

            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);
            Assert.NotEqual(telemetryClient.RecordedTelemetry[0].Properties["RequestId"], telemetryClient.RecordedTelemetry[1].Properties["RequestId"]);

            Assert.Null(telemetryClient.GetSuggestionData);
            Assert.Null(telemetryClient.SuggestionDisplayedData);
            Assert.Null(telemetryClient.SuggestionAcceptedData);
            Assert.Null(telemetryClient.ParameterMapData);
        }

        /// <summary>
        /// Verify that we record the history but not request prediction for the new unsupported commands.
        /// </summary>
        [Fact]
        public async Task VerifyOnCommandLineAcceptedForUnsupportedCommandAfterSupportedOnes()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            var history = new List<string>()
            {
                "Set-Content -Path C:\\Temp\\* -Filter *.txt -Value 'Empty'",
                "Get-LogProperties -Name:'Windows PowerShell'"
            };

            var maskedCommands = new List<string>()
            {
                "Set-Content -Filter *** -Path *** -Value ***",
                "Get-LogProperties -Name:***"
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history[1], false);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommands[1], telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(maskedCommands, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);
            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(maskedCommands[1], telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameCommand]);
            Assert.Equal("False", telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameSuccess]);
            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[1].Properties[RequestPredictionTelemetryData.PropertyNameHttpRequestSent]);

            var firstHistoryData = telemetryClient.HistoryData;
            var firstRequestPredictionData = telemetryClient.RequestPredictionData;

            telemetryClient.ResetWaitingTasks();
            expectedTelemetryCount = 1;
            telemetryClient.ExceptedTelemetryDispatchCount = expectedTelemetryCount;

            history.Add("git status");
            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), true);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            // Don't need to await on telemetryClient.RequestPredictionTask, because "git" isn't a supported command and RequestPredictionsAsync isn't called.
            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);
            Assert.Null(telemetryClient.RequestPredictionData);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameCommand]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameSuccess]);
            Assert.False(telemetryClient.RecordedTelemetry[1].Properties.ContainsKey(RequestPredictionTelemetryData.PropertyNameHttpRequestSent));

            var secondHistoryData = telemetryClient.HistoryData;

            // Make sure that the RequestPrediction event can be correlated to the right History event.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(firstHistoryData, firstRequestPredictionData);
            AzPredictorTelemetryTests.EnsureSameRequestId(firstRequestPredictionData, secondHistoryData);

            telemetryClient.ResetWaitingTasks();
            expectedTelemetryCount = 1;
            telemetryClient.ExceptedTelemetryDispatchCount = expectedTelemetryCount;

            history.Add(@"$a='NewResourceName'");
            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), false);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            // Don't need to await on telemetryClient.RequestPredictioinTask, because assignment isn't a supported command and RequestPredictionsAsync isn't called.
            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);
            Assert.Null(telemetryClient.RequestPredictionData);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(AzPredictorTelemetryTests.GetCommandName(history.Last()), telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameCommand]);
            Assert.Equal("False", telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameSuccess]);

            // There is no new request prediction. The request id isn't changed.
            AzPredictorTelemetryTests.EnsureSameRequestId(firstRequestPredictionData, telemetryClient.HistoryData);

            telemetryClient.ResetWaitingTasks();
            expectedTelemetryCount = 2;
            telemetryClient.ExceptedTelemetryDispatchCount = expectedTelemetryCount;

            history.Add("Clear-Variable -Name my* -Scope Global");
            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), true);

            maskedCommands = new List<string>()
            {
                "Get-LogProperties -Name:***",
                "Clear-Variable -Name *** -Scope ***",
            };

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommands[1], telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(maskedCommands, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);
            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(maskedCommands[1], telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameCommand]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameSuccess]);
            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[1].Properties[RequestPredictionTelemetryData.PropertyNameHttpRequestSent]);

            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);
        }

        /// <summary>
        /// Verify that we collect the correct telemetry when mixing supported and unsupported commands.
        /// </summary>
        [Fact]
        public async Task VerifyOnCommandLineAcceptedForUnsupportedAndSupportedCommands()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);
            var history = new List<string>()
            {
                "git status",
                "Set-Content -Path C:\\Temp\\* -Filter *.txt -Value 'Empty'",
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), false);

            var maskedCommands = new List<string>()
            {
                AzPredictorConstants.CommandPlaceholder,
                "Set-Content -Filter *** -Path *** -Value ***",
            };

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommands[1], telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(maskedCommands, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);
            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);
        }

        /// <summary>
        /// Verify that we collect the correct telemetry when mixing supported and unsupported commands.
        /// </summary>
        [Fact]
        public async Task VerifyOnCommandLineAcceptedForSupportedAndUnsupportedCommands()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);
            var history = new List<string>()
            {
                "Get-LogProperties -Name:'Windows PowerShell'",
                "git status",
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), true);

            var maskedCommands = new List<string>()
            {
                AzPredictorConstants.CommandPlaceholder,
                "Get-LogProperties -Name:***",
            };

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(maskedCommands, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);
            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);
        }

        /// <summary>
        /// Verify that an exception is recorded in request prediction.
        /// </summary>
        [Fact]
        public async Task VerifyOnCommandLineAcceptedException()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: true, expectedTelemetryCount);
            var history = new List<string>()
            {
                "Clear-Variable -Name my* -Scope Global",
            };

            var maskedCommand = "Clear-Variable -Name *** -Scope ***";

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), false);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommand, telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.IsType<MockTestException>(telemetryClient.RequestPredictionData.Exception);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(maskedCommand, telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameCommand]);
            Assert.Equal("False", telemetryClient.RecordedTelemetry[0].Properties[HistoryTelemetryData.PropertyNameSuccess]);

            Assert.EndsWith("Exception", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.StartsWith($"Type: {typeof(MockTestException)}\nStack Trace: ", telemetryClient.RecordedTelemetry[1].Properties["Exception"]);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[2].EventName);
            Assert.Equal(telemetryClient.RecordedTelemetry[2].Properties["RequestId"], telemetryClient.RecordedTelemetry[1].Properties["RequestId"]);
            Assert.Equal("False", telemetryClient.RecordedTelemetry[2].Properties[RequestPredictionTelemetryData.PropertyNameHttpRequestSent]);

            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);
            Assert.NotEqual(telemetryClient.RecordedTelemetry[0].Properties["RequestId"], telemetryClient.RecordedTelemetry[2].Properties["RequestId"]);
        }

        /// <summary>
        /// Verify that GetSuggestion, SuggestionDisplayed, and SessionAccepted all have the same suggestion session id.
        /// </summary>
        [Theory]
        [InlineData("Clear-Content -Filter *** -Path ***", "Clear-Content -Path '*' -Filter '*.log'")]
        [InlineData("start_of_snippet", "az storage")]
        [InlineData("start_of_snippet", "$a = (az storage)")]
        [InlineData("start_of_snippet", "random_command")]
        [InlineData("Remove-AzRoleAssignment", "Get-AzRoleAssignment -ObjectId $id | Remove-AzRoleAssignment")]
        [InlineData("Get-AzRoleAssignment -ObjectId ***", "Remove-AzRoleAssignment -RoleDefinitionId (Get-AzRoleAssignment -ObjectId xxx)")]
        [InlineData("Get-AzContext", "Get-AzContext")]
        [InlineData("Get-AzResourceGroup -Location *** -Name ***", "Get-AzResourceGroup -Location westus2 -Name rg1")]
        [InlineData("Get-AzResourceGroup -Location ***", "Get-AzResourceGroup rg1 -Location westus2")]
        [InlineData("get-azresourcegroup", "get-azresourcegroup rg1 westus2")]
        [InlineData("Set-Az", "Set-Az")]
        [InlineData("Get-azR", "Get-azR")]
        [InlineData("start_of_snippet", "NonVerb-AzResource")]
        [InlineData("Get", "Get")]
        [InlineData("Set-", "Set-")]
        [InlineData("New-AzureStorageContext -StorageAccountKey *** -StorageAccountName ***", @"New-AzureStorageContext -StorageAccountName ""accountName"" -StorageAccountKey ""accountKey""")]
        [InlineData("start_of_snippet", @"-StorageAccountKey""xxx""NewAzStorageContainer -context xxx")]
        [InlineData("start_of_snippet", @"-StorageAccountKey\""xxx\""NewAzStorageContainer -context xxx")]
        [InlineData("start_of_snippet", @"-StorageAccountKey""xxx""New-AzStorageContainer -context xxx")]
        [InlineData("start_of_snippet", @"New-AzureStorageContext-StorageAccountName ""xxx"" -StorageAccountKey ""xxx""")]
        [InlineData("start_of_snippet", @"sig=xxxxxxxxxxx/Sensor-Azure")]
        [InlineData("start_of_snippet", @"sig=Signature/Test-Sensor-Azu")]
        public void VerifyUserInputInGetSuggestionEvent(string expectedUserInput, string input)
        {
            var expectedTelemetryCount = 1;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            var predictionContext = PredictionContext.Create(input);
            var suggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);

            Assert.NotNull(telemetryClient.GetSuggestionData.Suggestion);
            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            var suggestionSessions = JsonSerializer.Deserialize<IList<IDictionary<string, object>>>(telemetryClient.RecordedTelemetry[0].Properties[GetSuggestionTelemetryData.PropertyNamePrediction]);
            Assert.Equal(expectedUserInput, ((JsonElement)(suggestionSessions[0][GetSuggestionTelemetryData.PropertyNameUserInput])).GetString());
        }

        /// <summary>
        /// Verify that GetSuggestion, SuggestionDisplayed, and SessionAccepted all have the same suggestion session id.
        /// </summary>
        [Fact]
        private void VerifySameSuggestionSessionId()
        {
            var expectedTelemetryCount = 1;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            var predictionContext = PredictionContext.Create("Clear-Content -Path '*' -Filter '*.log'");
            var suggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);

            Assert.Equal(MockObjects.PredictionClient, telemetryClient.GetSuggestionData.Client);
            Assert.Equal(suggestionPackage.Session.Value, telemetryClient.GetSuggestionData.SuggestionSessionId);
            Assert.NotNull(telemetryClient.GetSuggestionData.Suggestion);
            Assert.NotNull(telemetryClient.GetSuggestionData.UserInput);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            var suggestionSessions = JsonSerializer.Deserialize<IList<IDictionary<string, object>>>(telemetryClient.RecordedTelemetry[0].Properties[GetSuggestionTelemetryData.PropertyNamePrediction]);
            Assert.Equal("Clear-Content -Filter *** -Path ***", ((JsonElement)(suggestionSessions[0][GetSuggestionTelemetryData.PropertyNameUserInput])).GetString());
            Assert.Equal(1, ((JsonElement)suggestionSessions[0][GetSuggestionTelemetryData.PropertyNameFound]).GetArrayLength());

            var displayCountOrIndex = 3;

            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryDispatchCount = expectedTelemetryCount;

            azPredictor.OnSuggestionDisplayed(MockObjects.PredictionClient, suggestionPackage.Session.Value, displayCountOrIndex);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            suggestionSessions = JsonSerializer.Deserialize<IList<IDictionary<string, object>>>(telemetryClient.RecordedTelemetry[0].Properties[GetSuggestionTelemetryData.PropertyNamePrediction]);
            Assert.Equal((int)SuggestionDisplayMode.ListView, ((JsonElement)suggestionSessions[0][SuggestionDisplayedTelemetryData.PropertyNameDisplayed])[0].GetInt32());
            Assert.Equal(Math.Abs(displayCountOrIndex), ((JsonElement)suggestionSessions[0][SuggestionDisplayedTelemetryData.PropertyNameDisplayed])[1].GetInt32());
            Assert.Equal(suggestionPackage.Session.Value, ((JsonElement)suggestionSessions[0][GetSuggestionTelemetryData.PropertyNameSuggestionSessionId]).GetUInt32());
            Assert.Equal(suggestionPackage.Session.Value, telemetryClient.SuggestionDisplayedData.SuggestionSessionId);
            Assert.Equal(displayCountOrIndex, telemetryClient.SuggestionDisplayedData.SuggestionCountOrIndex);


            var acceptedSuggestion = "SuggestionAccepted";
            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryDispatchCount = expectedTelemetryCount;

            azPredictor.OnSuggestionAccepted(MockObjects.PredictionClient, suggestionPackage.Session.Value, acceptedSuggestion);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            suggestionSessions = JsonSerializer.Deserialize<IList<IDictionary<string, object>>>(telemetryClient.RecordedTelemetry[0].Properties[GetSuggestionTelemetryData.PropertyNamePrediction]);
            Assert.Equal(suggestionPackage.Session.Value, ((JsonElement)suggestionSessions[0][GetSuggestionTelemetryData.PropertyNameSuggestionSessionId]).GetUInt32());
            Assert.Equal(acceptedSuggestion, ((JsonElement)suggestionSessions[0][SuggestionAcceptedTelemetryData.PropertyNameAccepted]).GetString());
            AzPredictorTelemetryTests.EnsureSameRequestId(telemetryClient.GetSuggestionData, telemetryClient.SuggestionDisplayedData);
            AzPredictorTelemetryTests.EnsureSameRequestId(telemetryClient.GetSuggestionData, telemetryClient.SuggestionAcceptedData);

            Assert.Null(telemetryClient.HistoryData);
            Assert.Null(telemetryClient.RequestPredictionData);
        }

        /// <summary>
        /// Verify that the suggestion session id is changed.
        /// </summary>
        [Fact]
        public void VerifySuggestionSessionIdChanged()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            var predictionContext = PredictionContext.Create("Clear-Content -Path '*' -Filter '*.log'");
            var firstSuggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);
            var firstGetSuggestionData = telemetryClient.GetSuggestionData;

            var secondSuggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);
            var secondGetSuggestionData = telemetryClient.GetSuggestionData;

            Assert.NotEqual(secondSuggestionPackage.Session, firstSuggestionPackage.Session);
            AzPredictorTelemetryTests.EnsureSameRequestId(secondGetSuggestionData, firstGetSuggestionData);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);
        }

        /// <summary>
        /// Verify that we collect correct information for suggestion displayed event.
        /// </summary>
        [Fact]
        public void VerifyListViewInSuggestionDisplayed()
        {
            var expectedTelemetryCount = 1;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            uint suggestionSessionId = 2;
            var suggestionCountOrIndex = 4;
            azPredictor.OnSuggestionDisplayed(MockObjects.PredictionClient, suggestionSessionId, suggestionCountOrIndex);

            Assert.Equal(suggestionCountOrIndex, telemetryClient.SuggestionDisplayedData.SuggestionCountOrIndex);
            Assert.Equal(SuggestionDisplayMode.ListView, telemetryClient.SuggestionDisplayedData.DisplayMode);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.SuggestionDisplayedData.Client);
            Assert.Equal(suggestionSessionId, telemetryClient.SuggestionDisplayedData.SuggestionSessionId);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            var suggestionSessions = JsonSerializer.Deserialize<IList<IDictionary<string, object>>>(telemetryClient.RecordedTelemetry[0].Properties[GetSuggestionTelemetryData.PropertyNamePrediction]);
            Assert.Equal((int)SuggestionDisplayMode.ListView, ((JsonElement)suggestionSessions[0][SuggestionDisplayedTelemetryData.PropertyNameDisplayed])[0].GetInt32());
            Assert.Equal(Math.Abs(suggestionCountOrIndex), ((JsonElement)suggestionSessions[0][SuggestionDisplayedTelemetryData.PropertyNameDisplayed])[1].GetInt32());
            Assert.Equal(suggestionSessionId, ((JsonElement)suggestionSessions[0][GetSuggestionTelemetryData.PropertyNameSuggestionSessionId]).GetUInt32());
        }

        /// <summary>
        /// Verify that we collect correct information for suggestion displayed event.
        /// </summary>
        [Fact]
        public void VerifyInlineViewInSuggestionDisplayedAtEdge()
        {
            var expectedTelemetryCount = 1;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            uint suggestionSessionId = 40;
            var suggestionCountOrIndex = 0;
            azPredictor.OnSuggestionDisplayed(MockObjects.PredictionClient, suggestionSessionId, suggestionCountOrIndex);

            Assert.Equal(suggestionCountOrIndex, telemetryClient.SuggestionDisplayedData.SuggestionCountOrIndex);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.SuggestionDisplayedData.Client);
            Assert.Equal(SuggestionDisplayMode.InlineView, telemetryClient.SuggestionDisplayedData.DisplayMode);
            Assert.Equal(suggestionSessionId, telemetryClient.SuggestionDisplayedData.SuggestionSessionId);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);

            var suggestionSessions = JsonSerializer.Deserialize<IList<IDictionary<string, object>>>(telemetryClient.RecordedTelemetry[0].Properties[GetSuggestionTelemetryData.PropertyNamePrediction]);
            Assert.Equal((int)SuggestionDisplayMode.InlineView, ((JsonElement)suggestionSessions[0][SuggestionDisplayedTelemetryData.PropertyNameDisplayed])[0].GetInt32());
            Assert.Equal(Math.Abs(suggestionCountOrIndex), ((JsonElement)suggestionSessions[0][SuggestionDisplayedTelemetryData.PropertyNameDisplayed])[1].GetInt32());
            Assert.Equal(suggestionSessionId, ((JsonElement)suggestionSessions[0][GetSuggestionTelemetryData.PropertyNameSuggestionSessionId]).GetUInt32());
        }

        /// <summary>
        /// Verify that we collect correct information for suggestion displayed event.
        /// </summary>
        [Fact]
        public void VerifyInlineViewInSuggestionDisplayed()
        {
            var expectedTelemetryCount = 1;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            uint suggestionSessionId = 14;
            var suggestionCountOrIndex = -1;
            azPredictor.OnSuggestionDisplayed(MockObjects.PredictionClient, suggestionSessionId, suggestionCountOrIndex);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.Equal(Math.Abs(suggestionCountOrIndex), telemetryClient.SuggestionDisplayedData.SuggestionCountOrIndex);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.SuggestionDisplayedData.Client);
            Assert.Equal(SuggestionDisplayMode.InlineView, telemetryClient.SuggestionDisplayedData.DisplayMode);
            Assert.Equal(suggestionSessionId, telemetryClient.SuggestionDisplayedData.SuggestionSessionId);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            var suggestionSessions = JsonSerializer.Deserialize<IList<IDictionary<string, object>>>(telemetryClient.RecordedTelemetry[0].Properties[GetSuggestionTelemetryData.PropertyNamePrediction]);
            Assert.Equal((int)SuggestionDisplayMode.InlineView, ((JsonElement)suggestionSessions[0][SuggestionDisplayedTelemetryData.PropertyNameDisplayed])[0].GetInt32());
            Assert.Equal(Math.Abs(suggestionCountOrIndex), ((JsonElement)suggestionSessions[0][SuggestionDisplayedTelemetryData.PropertyNameDisplayed])[1].GetInt32());
        }

        /// <summary>
        /// Verify that the exception is caught correctly from <see also="AzPredictor.GetSuggestion"/>
        /// </summary>
        [Fact]
        public void VerifyExceptionInGetSuggestion()
        {
            var expectedTelemetryCount = 1;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: true, expectedTelemetryCount);

            var predictionContext = PredictionContext.Create("Clear-Content -Path '*' -Filter '*.log' -Force");
            var suggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);

            Assert.IsType<MockTestException>(telemetryClient.GetSuggestionData.Exception);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.GetSuggestionData.Client);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("Exception", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.RecordedTelemetry[0].Properties["UserInput"]);
            Assert.StartsWith($"Type: {typeof(MockTestException)}\nStack Trace: ", telemetryClient.RecordedTelemetry[0].Properties["Exception"]);

            Assert.EndsWith("Aggregation", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(telemetryClient.RecordedTelemetry[0].Properties["RequestId"], telemetryClient.RecordedTelemetry[1].Properties["RequestId"]);
            Assert.Equal(telemetryClient.RecordedTelemetry[0].Properties["CommandId"], telemetryClient.RecordedTelemetry[1].Properties["CommandId"]);
        }

        /// <summary>
        /// Verify that the command id is matched.
        /// </summary>
        [Fact]
        public void VerifyCommandIds()
        {
            var expectedTelemetryCount = 3;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            var history = new List<string>()
            {
                "Clear-Variable -Name my* -Scope Global",
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), false);

            var predictionContext = PredictionContext.Create("Clear-Content -Path '*' -Filter '*.log'");
            var suggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            var originalHistoryData = telemetryClient.HistoryData;
            var firstRequestPredictionData = telemetryClient.RequestPredictionData;
            var firstGetSuggestionData = telemetryClient.GetSuggestionData;

            var originalHistoryRecordedData = telemetryClient.RecordedTelemetry[0];
            var firstSuggestionRecordedData = telemetryClient.RecordedTelemetry[1];

            expectedTelemetryCount = 2;
            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryDispatchCount = expectedTelemetryCount;

            history = new List<string>()
            {
                "Set-Content -Path C:\\Temp\\* -Filter *.txt -Value 'Empty'",
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), false);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            var firstHistoryData = telemetryClient.HistoryData;
            var secondRequestPredictionData = telemetryClient.RequestPredictionData;
            var firstHistoryRecordedData = telemetryClient.RecordedTelemetry[0];
            var secondRequestRecordedData = telemetryClient.RecordedTelemetry[1];

            EnsureSameRequestId(firstRequestPredictionData, firstGetSuggestionData);
            EnsureSameRequestId(firstRequestPredictionData, firstHistoryData);
            Assert.Equal(firstSuggestionRecordedData.Properties["RequestId"], firstHistoryRecordedData.Properties["RequestId"]);
            EnsureSameCommandId(firstHistoryData, firstRequestPredictionData);
            EnsureSameCommandId(firstHistoryData, firstGetSuggestionData);
            Assert.Equal(firstSuggestionRecordedData.Properties["CommandId"], firstHistoryRecordedData.Properties["CommandId"]);

            EnsureDifferentComamandId(firstHistoryData, originalHistoryData);
            Assert.NotEqual(firstHistoryRecordedData.Properties["CommandId"], originalHistoryRecordedData.Properties["CommandId"]);
            EnsureDifferentRequestId(firstRequestPredictionData, secondRequestPredictionData);
            Assert.NotEqual(firstSuggestionRecordedData.Properties["RequestId"], secondRequestRecordedData.Properties["RequestId"]);

            // Now add a "git" command. It doesn't change the request id, but change the command id.

            expectedTelemetryCount = 2;
            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryDispatchCount = expectedTelemetryCount;

            predictionContext = PredictionContext.Create("Clear-Content -Path '*' -Filter '*.log'");
            suggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);

            history =new List<string>()
            {
                "git status",
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), false);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            var secondGetSuggestionData = telemetryClient.GetSuggestionData;
            var secondHistoryData = telemetryClient.HistoryData;
            var secondHistoryRecordedData = telemetryClient.RecordedTelemetry[0];
            var thirdRequestPredictionData = telemetryClient.RequestPredictionData;

            expectedTelemetryCount = 2;
            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryDispatchCount = expectedTelemetryCount;

            predictionContext = PredictionContext.Create("Clear-Content -Path '*' -Filter '*.log'");
            suggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);

            history =new List<string>()
            {
                "git commit",
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), true);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            var thirdGetSuggestionData = telemetryClient.GetSuggestionData;
            var thirdHistoryData = telemetryClient.HistoryData;
            var thirdHistoryRecordedData = telemetryClient.RecordedTelemetry[0];
            var fourthRequestPredictionData = telemetryClient.RequestPredictionData;

            Assert.Null(thirdRequestPredictionData); // Since it's "git", we don't send the request.
            Assert.Null(fourthRequestPredictionData); // Since it's "git", we don't send the request.

            EnsureSameRequestId(secondRequestPredictionData, secondGetSuggestionData);
            EnsureSameRequestId(secondRequestPredictionData, secondHistoryData);
            Assert.Equal(secondRequestRecordedData.Properties["RequestId"], secondHistoryRecordedData.Properties["RequestId"]);
            EnsureSameRequestId(secondRequestPredictionData, thirdGetSuggestionData);
            EnsureSameRequestId(secondRequestPredictionData, thirdHistoryData);
            Assert.Equal(secondRequestRecordedData.Properties["RequestId"], thirdHistoryRecordedData.Properties["RequestId"]);

            EnsureDifferentComamandId(secondHistoryData, firstHistoryData);
            Assert.NotEqual(secondHistoryRecordedData.Properties["CommandId"], firstHistoryRecordedData.Properties["CommandId"]);
            EnsureSameCommandId(secondHistoryData, secondGetSuggestionData);

            EnsureDifferentComamandId(thirdHistoryData, secondHistoryData);
            Assert.NotEqual(secondHistoryRecordedData.Properties["CommandId"], thirdHistoryRecordedData.Properties["CommandId"]);
            EnsureSameCommandId(thirdHistoryData, thirdGetSuggestionData);
        }

        /// <summary>
        /// Verifies that the Suggestion field is divided into events when GetSuggestionTelemetryData is added.
        /// </summary>
        [Fact]
        public void VerifyAggregationDataSplitAtGetSuggestion()
        {
            var expectedTelemetryCount = 59;
            var expectedSuggestionSessionInFirstBatch = expectedTelemetryCount;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount, flushTelemetry: false);

            for (int i = 0; i < expectedTelemetryCount; ++i)
            {
                // Call the methods a few times to make sure the telemetry data is less than AzPredictorTelemetryClient.MaxPropertyValueSizeWithBuffer but the next such call will
                // make it larger than it.
                var predictionContext = PredictionContext.Create($"Clear-Content -Path '*' -Filter '{i}.log'");
                var _ = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);
            }

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);

            Assert.True(telemetryClient.RecordedAggregatedData.EstimateSuggestionSessionSize < AzPredictorTelemetryClient.MaxPropertyValueSizeWithBuffer);

            expectedTelemetryCount = 1;
            var expectedSuggestionSessionInSecondBatch = expectedTelemetryCount;
            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryDispatchCount = expectedTelemetryCount;

            for (int i = 0; i < expectedTelemetryCount; ++i)
            {
                // This time make sure that the size exceeds the max property value size with buffer.
                var predictionContext = PredictionContext.Create($"Clear-Content -Path '*' -Filter '{i}.log'");
                var _ = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);
            }

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);
            telemetryClient.FlushTelemetry();

            var recordedTelemetry = telemetryClient.RecordedTelemetry[0];
            var suggestionSessions = JsonSerializer.Deserialize<IList<IDictionary<string, object>>>(recordedTelemetry.Properties[GetSuggestionTelemetryData.PropertyNamePrediction]);
            Assert.Equal(expectedSuggestionSessionInFirstBatch, suggestionSessions.Count());

            recordedTelemetry = telemetryClient.RecordedTelemetry[1];
            suggestionSessions = JsonSerializer.Deserialize<IList<IDictionary<string, object>>>(recordedTelemetry.Properties[GetSuggestionTelemetryData.PropertyNamePrediction]);
            Assert.Equal(expectedSuggestionSessionInSecondBatch, suggestionSessions.Count());
            Assert.True(suggestionSessions[0].ContainsKey(GetSuggestionTelemetryData.PropertyNameFound));
        }

        /// <summary>
        /// Verifies that the Suggestion field is divided into events when SuggestionDisplayedTelemetryData is added.
        /// </summary>
        [Fact]
        public void VerifyAggregationDataSplitAtDisplaySuggestion()
        {
            var expectedTelemetryCount = 64;
            var expectedSuggestionSessionInFirstBatch = expectedTelemetryCount;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount, flushTelemetry: false);
            PredictionContext predictionContext = default;
            SuggestionPackage suggestionPackage = default;

            for (int i = 0; i < expectedTelemetryCount - 1; ++i)
            {
                // Call the methods a few times to make sure the telemetry data is less than AzPredictorTelemetryClient.MaxPropertyValueSizeWithBuffer.
                predictionContext = PredictionContext.Create($"Clear-Variable -Name my* -Scop");
                var _ = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);
            }

            // This call just to make sure that the size is close enough to AzPredictorTelemetryClient.MaxPropertyValueSizeWithBuffer.
            predictionContext = PredictionContext.Create("Get-ChildIte");

            suggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);
            Assert.True(telemetryClient.RecordedAggregatedData.EstimateSuggestionSessionSize < AzPredictorTelemetryClient.MaxPropertyValueSizeWithBuffer);

            expectedTelemetryCount = 2;
            var expectedSuggestionSessionInSecondBatch = 1;
            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryDispatchCount = expectedTelemetryCount;

            // OnSuggestionDisplayed makes the property value size larger than AzPredictorTelemetryClient.MaxPropertyValueSizeWithBuffer.
            azPredictor.OnSuggestionDisplayed(MockObjects.PredictionClient, suggestionPackage.Session.Value, 1);
            // We'll send the first batch that contains the found suggestions when we process SuggestionDisplayedTelemetryData.
            azPredictor.OnSuggestionAccepted(MockObjects.PredictionClient, suggestionPackage.Session.Value, "Get-ChildItem");

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);
            telemetryClient.FlushTelemetry();

            var recordedTelemetry = telemetryClient.RecordedTelemetry[0];
            var suggestionSessions = JsonSerializer.Deserialize<IList<IDictionary<string, object>>>(recordedTelemetry.Properties[GetSuggestionTelemetryData.PropertyNamePrediction]);
            Assert.Equal(expectedSuggestionSessionInFirstBatch, suggestionSessions.Count());
            Assert.True(suggestionSessions.All((s) => s.ContainsKey(GetSuggestionTelemetryData.PropertyNameFound) && s.ContainsKey(GetSuggestionTelemetryData.PropertyNameUserInput)));
            Assert.True(suggestionSessions.All((s) => !s.ContainsKey(SuggestionAcceptedTelemetryData.PropertyNameAccepted)));
            Assert.True(suggestionSessions.All((s) => !s.ContainsKey(SuggestionDisplayedTelemetryData.PropertyNameDisplayed)));
            Assert.Equal(suggestionPackage.Session.Value, ((JsonElement)suggestionSessions.Last()[GetSuggestionTelemetryData.PropertyNameSuggestionSessionId]).GetUInt32());

            recordedTelemetry = telemetryClient.RecordedTelemetry[1];
            suggestionSessions = JsonSerializer.Deserialize<IList<IDictionary<string, object>>>(recordedTelemetry.Properties[GetSuggestionTelemetryData.PropertyNamePrediction]);
            Assert.Equal(expectedSuggestionSessionInSecondBatch, suggestionSessions.Count());
            Assert.False(suggestionSessions[0].ContainsKey(GetSuggestionTelemetryData.PropertyNameFound));
            Assert.False(suggestionSessions[0].ContainsKey(GetSuggestionTelemetryData.PropertyNameUserInput));
            Assert.False(suggestionSessions[0].ContainsKey(GetSuggestionTelemetryData.PropertyNameIsCancelled));
            Assert.Equal(suggestionPackage.Session.Value, ((JsonElement)suggestionSessions[0][GetSuggestionTelemetryData.PropertyNameSuggestionSessionId]).GetUInt32());
            Assert.Equal(1, ((JsonElement)suggestionSessions[0][SuggestionDisplayedTelemetryData.PropertyNameDisplayed])[0].GetInt32());
            Assert.Equal(1, ((JsonElement)suggestionSessions[0][SuggestionDisplayedTelemetryData.PropertyNameDisplayed])[1].GetInt32());
            Assert.Equal("Get-ChildItem", ((JsonElement)suggestionSessions[0][SuggestionAcceptedTelemetryData.PropertyNameAccepted]).GetString());
        }

        /// <summary>
        /// Verifies that the Suggestion field is divided into events when SuggestionAcceptedTelemetryData is added.
        /// </summary>
        [Fact]
        public void VerifyAggregationDataSplitAtAcceptSuggestion()
        {
            var expectedTelemetryCount = 64;
            var expectedSuggestionSessionInFirstBatch = expectedTelemetryCount - 1; // The display info is in the same suggstion session as the GetSuggestionTelemetryData
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount, flushTelemetry: false);
            PredictionContext predictionContext = default;
            SuggestionPackage suggestionPackage = default;

            for (int i = 0; i < expectedTelemetryCount - 1; ++i)
            {
                // Call the methods a few times to make sure the telemetry data is less than AzPredictorTelemetryClient.MaxPropertyValueSizeWithBuffer.
                predictionContext = PredictionContext.Create($"Clear-Variable -Name my* -Scope");
                suggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);
            }

            // With this call, the size is still less than AzPredictorTelemetryClient.MaxPropertyValueSizeWithBuffer.
            azPredictor.OnSuggestionDisplayed(MockObjects.PredictionClient, suggestionPackage.Session.Value, 1);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);
            Assert.True(telemetryClient.RecordedAggregatedData.EstimateSuggestionSessionSize < AzPredictorTelemetryClient.MaxPropertyValueSizeWithBuffer);

            expectedTelemetryCount = 1;
            var expectedSuggestionSessionInSecondBatch = 1;
            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryDispatchCount = expectedTelemetryCount;

            // With this call, the size will exceed AzPredictorTelemetryClient.MaxPropertyValueSizeWithBuffer.
            // We'll send the first batch contains the found suggestions and displayed info when we process SuggestionAcceptedTelemetryData.
            var acceptedSuggestion = "Clear-Variable -Name my* -Scope Global";
            azPredictor.OnSuggestionAccepted(MockObjects.PredictionClient, suggestionPackage.Session.Value, acceptedSuggestion);

            VerifyTelemetryDispatchCount(expectedTelemetryCount, telemetryClient);
            telemetryClient.FlushTelemetry();

            var recordedTelemetry = telemetryClient.RecordedTelemetry[0];
            var suggestionSessions = JsonSerializer.Deserialize<IList<IDictionary<string, object>>>(recordedTelemetry.Properties[GetSuggestionTelemetryData.PropertyNamePrediction]);
            Assert.Equal(expectedSuggestionSessionInFirstBatch, suggestionSessions.Count());
            Assert.True(suggestionSessions.All((s) => s.ContainsKey(GetSuggestionTelemetryData.PropertyNameFound) && s.ContainsKey(GetSuggestionTelemetryData.PropertyNameUserInput)));
            Assert.True(suggestionSessions.All((s) => !s.ContainsKey(SuggestionAcceptedTelemetryData.PropertyNameAccepted)));
            Assert.True(suggestionSessions.SkipLast(1).All((s) => !s.ContainsKey(SuggestionDisplayedTelemetryData.PropertyNameDisplayed) && !s.ContainsKey(GetSuggestionTelemetryData.PropertyNameSuggestionSessionId)));
            Assert.Equal(suggestionPackage.Session.Value, ((JsonElement)suggestionSessions.Last()[GetSuggestionTelemetryData.PropertyNameSuggestionSessionId]).GetUInt32());
            Assert.Equal(1, ((JsonElement)suggestionSessions.Last()[SuggestionDisplayedTelemetryData.PropertyNameDisplayed])[0].GetInt32());
            Assert.Equal(1, ((JsonElement)suggestionSessions.Last()[SuggestionDisplayedTelemetryData.PropertyNameDisplayed])[1].GetInt32());

            recordedTelemetry = telemetryClient.RecordedTelemetry[1];
            suggestionSessions = JsonSerializer.Deserialize<IList<IDictionary<string, object>>>(recordedTelemetry.Properties[GetSuggestionTelemetryData.PropertyNamePrediction]);
            Assert.Equal(expectedSuggestionSessionInSecondBatch, suggestionSessions.Count());
            Assert.False(suggestionSessions[0].ContainsKey(GetSuggestionTelemetryData.PropertyNameFound));
            Assert.False(suggestionSessions[0].ContainsKey(GetSuggestionTelemetryData.PropertyNameUserInput));
            Assert.False(suggestionSessions[0].ContainsKey(GetSuggestionTelemetryData.PropertyNameIsCancelled));
            Assert.Equal(suggestionPackage.Session.Value, ((JsonElement)suggestionSessions[0][GetSuggestionTelemetryData.PropertyNameSuggestionSessionId]).GetUInt32());
            Assert.Equal(acceptedSuggestion, ((JsonElement)suggestionSessions[0][SuggestionAcceptedTelemetryData.PropertyNameAccepted]).GetString());
        }

        private (AzPredictor, MockAzPredictorTelemetryClient) CreateTestObjects(bool throwException, int expectedTelemetryEvent, bool flushTelemetry = true)
        {
            var telemetryClient = new MockAzPredictorTelemetryClient();
            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryDispatchCount = expectedTelemetryEvent;
            telemetryClient.FlushAtDispatch = flushTelemetry;
            var startHistory = $"{AzPredictorConstants.CommandPlaceholder}{AzPredictorConstants.CommandConcatenator}{AzPredictorConstants.CommandPlaceholder}";

            var service = new MockAzPredictorService(startHistory, _fixture.PredictionCollection[startHistory], _fixture.CommandCollection, null);
            service.ThrowException = throwException;
            var azPredictor = new AzPredictor(service, telemetryClient, new Settings()
            {
                SuggestionCount = 1,
                MaxAllowedCommandDuplicate = 1,
            },
            null);

            return (azPredictor, telemetryClient);
        }

        /// <summary>
        /// Verifies that the number of telemetry events to be dispatched is equal to <paramref name="expectedCount"/>.
        /// </summary>
        private void VerifyTelemetryDispatchCount(int expectedCount, MockAzPredictorTelemetryClient telemetryClient)
        {
            Assert.True(telemetryClient.DispatchTelemetryTaskCompletionSource.Task.Wait(TimeSpan.FromMilliseconds(1000)));
            Assert.Equal(expectedCount, telemetryClient.DispatchedTelemetry.Count);
        }

        private static void EnsureDifferentComamandId(ITelemetryData expected, ITelemetryData actual)
        {
            Assert.NotEqual(expected.CommandId, actual.CommandId);
        }

        private static void EnsureSameCommandId(ITelemetryData expected, ITelemetryData actual)
        {
            Assert.Equal(expected.CommandId, actual.CommandId);
        }

        private static void EnsureDifferentRequestId(ITelemetryData expected, ITelemetryData actual)
        {
            Assert.NotEqual(expected.RequestId, actual.RequestId);
        }

        private static void EnsureSameRequestId(ITelemetryData expected, ITelemetryData actual)
        {
            Assert.Equal(expected.RequestId, actual.RequestId);
        }

        /// <summary>
        /// Gets the command name out of the user input.
        /// </summary>
        /// <remarks>
        /// It only needs to be able to get the commands name from the user input in the test cases. It's not intended to be
        /// comprehensive and fine tuned.
        /// </remarks>
        private static string GetCommandName(string commandInput)
        {
            // If there is a '=' in it, treat as assignment and parse the right side.
            var inputSegments = commandInput.Split('=');

            if (inputSegments.Count() == 1)
            {
                return commandInput.Split(' ')[0];
            }

            var rightSide = inputSegments.Last().Trim();

            if ((('a' <= rightSide[0]) && (rightSide[0] <= 'z')) || (('A' <= rightSide[0]) && (rightSide[0] <= 'Z')))
            {
                return GetCommandName(rightSide);
            }

            return AzPredictorConstants.CommandPlaceholder;

        }
    }
}
