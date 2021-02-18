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
using System.Globalization;
using System.Management.Automation.Subsystem;
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
        private const string AzPredictorClient = "Test";
        private readonly ModelFixture _fixture;

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictorTelemetryTests"/>
        /// </summary>
        public AzPredictorTelemetryTests(ModelFixture modelFixture)
        {
            _fixture = modelFixture;
        }

        /// <summary>
        /// Verify that the unsupported commands are replaced with placeholders in <see cref="AzPredictor.StartEarlyProcessing"/>.
        /// </summary>
        [Theory]
        [InlineData("git status")]
        [InlineData("New-Item")]
        [InlineData(@"$a='ResourceGroup01'")]
        public async Task VerifyStartEarlyProessingForOneUnsupportedCommandHistory(string inputData)
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount + 1);

            IReadOnlyList<string> history = new List<string>()
            {
                inputData
            };

            azPredictor.StartEarlyProcessing(AzPredictorTelemetryTests.AzPredictorClient, history);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.HistoryData.Command);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.HistoryData.ClientId);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(new List<string>() { AzPredictorConstants.CommandPlaceholder, AzPredictorConstants.CommandPlaceholder }, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RequestPredictionData.ClientId);
            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.RecordedTelemetry[0].Properties["History"]);

            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal($"{AzPredictorConstants.CommandPlaceholder}\n{AzPredictorConstants.CommandPlaceholder}", telemetryClient.RecordedTelemetry[1].Properties["Command"]);

            // The correlation id are changed in OnHistory.
            AzPredictorTelemetryTests.EnsureDifferentCorrelationId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            Assert.Null(telemetryClient.GetSuggestionData);
            Assert.Null(telemetryClient.SuggestionDisplayedData);
            Assert.Null(telemetryClient.SuggestionAcceptedData);
            Assert.Null(telemetryClient.ParameterMapData);
        }

        /// <summary>
        /// Verify that the parameter values in the supported commands are masked in <see cref="AzPredictor.StartEarlyProcessing"/>.
        /// </summary>
        [Fact]
        public async Task VerifyStartEarlyProcessingForOneSupportedCommandWithoutParameter()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount + 1);

            var testCaseClientId = "TestCase";

            // There is only one command.
            IReadOnlyList<string> history = new List<string>()
            {
                "Get-AzContext",
            };

            azPredictor.StartEarlyProcessing(testCaseClientId, history);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(history[0], telemetryClient.HistoryData.Command);
            Assert.Equal(testCaseClientId, telemetryClient.HistoryData.ClientId);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(new List<string>() { AzPredictorConstants.CommandPlaceholder, history[0] }, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(testCaseClientId, telemetryClient.RequestPredictionData.ClientId);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(testCaseClientId, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(history[0], telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(testCaseClientId, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal($"{AzPredictorConstants.CommandPlaceholder}\n{history[0]}", telemetryClient.RecordedTelemetry[1].Properties["Command"]);

            // The correlation id are changed in OnHistory.
            AzPredictorTelemetryTests.EnsureDifferentCorrelationId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            Assert.Null(telemetryClient.GetSuggestionData);
            Assert.Null(telemetryClient.SuggestionDisplayedData);
            Assert.Null(telemetryClient.SuggestionAcceptedData);
            Assert.Null(telemetryClient.ParameterMapData);
        }

        /// <summary>
        /// Verify that the parameter values in the supported commands are masked in <see cref="AzPredictor.StartEarlyProcessing"/>.
        /// </summary>
        [Fact]
        public async Task VerifyStartEarlyProcessingForOneSupportedCommandWithParameter()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount + 1);
            var testCaseClientId = "TestCase";

            // There is only one command with parameter.
            var history = new List<string>()
            {
                "New-AzVM -Name hello -Location WestUS"
            };

            azPredictor.StartEarlyProcessing(testCaseClientId, history);

            var maskedCommand = "New-AzVM -Location *** -Name ***";

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal("New-AzVM -Location *** -Name ***", telemetryClient.HistoryData.Command);
            Assert.Equal(testCaseClientId, telemetryClient.HistoryData.ClientId);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);
            Assert.Equal(new List<string>() { AzPredictorConstants.CommandPlaceholder, maskedCommand }, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(testCaseClientId, telemetryClient.RequestPredictionData.ClientId);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(testCaseClientId, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(maskedCommand, telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(testCaseClientId, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal($"{AzPredictorConstants.CommandPlaceholder}\n{maskedCommand}", telemetryClient.RecordedTelemetry[1].Properties["Command"]);

            // The correlation id are changed in OnHistory.
            AzPredictorTelemetryTests.EnsureDifferentCorrelationId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            Assert.Null(telemetryClient.GetSuggestionData);
            Assert.Null(telemetryClient.SuggestionDisplayedData);
            Assert.Null(telemetryClient.SuggestionAcceptedData);
            Assert.Null(telemetryClient.ParameterMapData);
        }

        /// <summary>
        /// Verify that the parameter values in the supported commands are masked in <see cref="AzPredictor.StartEarlyProcessing"/>.
        /// </summary>
        [Fact]
        public async Task VerifyStartEarlyProcessingForTwoSupportedCommandHistory()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount + 1);
            IReadOnlyList<string> history = new List<string>()
            {
                "Get-AzContext",
                "New-AzVM -Name hello -Location WestUS",
            };

            azPredictor.StartEarlyProcessing(AzPredictorTelemetryTests.AzPredictorClient, history);

            var maskedCommands = new List<string>()
            {
                "Get-AzContext",
                "New-AzVM -Location *** -Name ***",
            };

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommands[1], telemetryClient.HistoryData.Command);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.HistoryData.ClientId);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(maskedCommands, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RequestPredictionData.ClientId);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(maskedCommands[1], telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal(string.Join("\n", maskedCommands), telemetryClient.RecordedTelemetry[1].Properties["Command"]);

            // The correlation id are changed in OnHistory.
            AzPredictorTelemetryTests.EnsureDifferentCorrelationId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            Assert.Null(telemetryClient.GetSuggestionData);
            Assert.Null(telemetryClient.SuggestionDisplayedData);
            Assert.Null(telemetryClient.SuggestionAcceptedData);
            Assert.Null(telemetryClient.ParameterMapData);
        }

        /// <summary>
        ///  Verify that we can handle the two unsupported command in sequences.
        /// </summary>
        [Fact]
        public async Task VerifyStartEarlyProcessingForTwoUnsupportedCommandInHistory()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount + 1);

            IReadOnlyList<string> history = new List<string>()
            {
                "git status",
                @"$a='ResourceGroup01'",
            };

            azPredictor.StartEarlyProcessing(AzPredictorTelemetryTests.AzPredictorClient, history);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.HistoryData.Command);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.HistoryData.ClientId);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(new List<string>() { AzPredictorConstants.CommandPlaceholder, AzPredictorConstants.CommandPlaceholder }, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RequestPredictionData.ClientId);
            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal($"{AzPredictorConstants.CommandPlaceholder}\n{AzPredictorConstants.CommandPlaceholder}", telemetryClient.RecordedTelemetry[1].Properties["Command"]);

            // The correlation id are changed in OnHistory.
            AzPredictorTelemetryTests.EnsureDifferentCorrelationId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            Assert.Null(telemetryClient.GetSuggestionData);
            Assert.Null(telemetryClient.SuggestionDisplayedData);
            Assert.Null(telemetryClient.SuggestionAcceptedData);
            Assert.Null(telemetryClient.ParameterMapData);
        }

        /// <summary>
        /// Verify that we record the history but not request prediction for the new unsupported commands.
        /// </summary>
        [Fact]
        public async Task VerifyStartEarlyProcessingForUnsupportedCommandAfterSupportedOnes()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount + 1);

            var history = new List<string>()
            {
                "New-AzResourceGroup -Name:resourceGroup01",
                "New-AzVM -Name hello -Location WestUS"
            };

            var maskedCommands = new List<string>()
            {
                "New-AzResourceGroup -Name:***",
                "New-AzVM -Location *** -Name ***"
            };

            azPredictor.StartEarlyProcessing(AzPredictorTelemetryTests.AzPredictorClient, history);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommands[1], telemetryClient.HistoryData.Command);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.HistoryData.ClientId);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(maskedCommands, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RequestPredictionData.ClientId);
            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(maskedCommands[1], telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal(string.Join("\n", maskedCommands), telemetryClient.RecordedTelemetry[1].Properties["Command"]);

            var firstHistoryData = telemetryClient.HistoryData;
            var firstRequestPredictionData = telemetryClient.RequestPredictionData;

            telemetryClient.ResetWaitingTasks();
            expectedTelemetryCount = 1;
            telemetryClient.ExceptedTelemetryRecordCount = expectedTelemetryCount + 1;

            history.Add("git status");
            azPredictor.StartEarlyProcessing(AzPredictorTelemetryTests.AzPredictorClient, history);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.HistoryData.Command);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.HistoryData.ClientId);

            // Don't need to await on telemetryClient.RequestPredictioinTask, because "git" isn't a supported command and RequestPredictionsAsync isn't called.
            // The commands to request predictions are the same as previous request.
            Assert.Equal(new List<string>() { "New-AzResourceGroup -Name:***", "New-AzVM -Location *** -Name ***" }, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RequestPredictionData.ClientId);
            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.RecordedTelemetry[0].Properties["History"]);

            var secondHistoryData = telemetryClient.HistoryData;

            // Make sure that the RequestPrediction event can be correlated to the right History event.
            AzPredictorTelemetryTests.EnsureDifferentCorrelationId(firstHistoryData, firstRequestPredictionData);
            AzPredictorTelemetryTests.EnsureSameCorrelationId(firstRequestPredictionData, secondHistoryData);

            AzPredictorTelemetryTests.EnsureSameSessionId(firstHistoryData, firstRequestPredictionData);
            AzPredictorTelemetryTests.EnsureSameSessionId(firstRequestPredictionData, secondHistoryData);

            telemetryClient.ResetWaitingTasks();
            expectedTelemetryCount = 1;
            telemetryClient.ExceptedTelemetryRecordCount = expectedTelemetryCount + 1;

            history.Add(@"$a='NewResourceName'");
            azPredictor.StartEarlyProcessing(AzPredictorTelemetryTests.AzPredictorClient, history);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.HistoryData.Command);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.HistoryData.ClientId);

            // Don't need to await on telemetryClient.RequestPredictioinTask, because assignment isn't a supported command and RequestPredictionsAsync isn't called.
            // The commands to request predictions are the same as previous request.
            Assert.Equal(new List<string>() { "New-AzResourceGroup -Name:***", "New-AzVM -Location *** -Name ***" }, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RequestPredictionData.ClientId);
            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.RecordedTelemetry[0].Properties["History"]);

            // There is no new request prediction. The correlation id isn't changed.
            AzPredictorTelemetryTests.EnsureSameCorrelationId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            telemetryClient.ResetWaitingTasks();
            expectedTelemetryCount = 2;
            telemetryClient.ExceptedTelemetryRecordCount = expectedTelemetryCount + 1;

            history.Add("Get-AzResourceGroup -Name:ResourceGroup01");
            azPredictor.StartEarlyProcessing(AzPredictorTelemetryTests.AzPredictorClient, history);

            maskedCommands = new List<string>()
            {
                "New-AzVM -Location *** -Name ***",
                "Get-AzResourceGroup -Name:***",
            };

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommands[1], telemetryClient.HistoryData.Command);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.HistoryData.ClientId);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(maskedCommands, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RequestPredictionData.ClientId);
            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(maskedCommands[1], telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal(string.Join("\n", maskedCommands), telemetryClient.RecordedTelemetry[1].Properties["Command"]);

            // The correlation id are changed in OnHistory.
            AzPredictorTelemetryTests.EnsureDifferentCorrelationId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);
        }

        /// <summary>
        /// Verify that we collect the correct telemetry when mixing supported and unsupported commands.
        /// </summary>
        [Fact]
        public async Task VerifyStartEarlyProcessingForUnsupportedAndSupportedCommands()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount + 1);
            var history = new List<string>()
            {
                "git status",
                "New-AzVM -Name:hello -Location:WestUS"
            };

            azPredictor.StartEarlyProcessing(AzPredictorTelemetryTests.AzPredictorClient, history);

            var maskedCommands = new List<string>()
            {
                AzPredictorConstants.CommandPlaceholder,
                "New-AzVM -Location:*** -Name:***"
            };

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommands[1], telemetryClient.HistoryData.Command);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.HistoryData.ClientId);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(maskedCommands, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RequestPredictionData.ClientId);
            // The correlation id are changed in OnHistory.
            AzPredictorTelemetryTests.EnsureDifferentCorrelationId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);
        }

        /// <summary>
        /// Verify that we collect the correct telemetry when mixing supported and unsupported commands.
        /// </summary>
        [Fact]
        public async Task VerifyStartEarlyProcessingForSupportedAndUnsupportedCommands()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount + 1);
            var history = new List<string>()
            {
                "New-AzVM -Name hello -Location WestUS",
                "git status",
            };

            azPredictor.StartEarlyProcessing(AzPredictorTelemetryTests.AzPredictorClient, history);

            var maskedCommands = new List<string>()
            {
                AzPredictorConstants.CommandPlaceholder,
                "New-AzVM -Location *** -Name ***",
            };

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommands[0], telemetryClient.HistoryData.Command);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.HistoryData.ClientId);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(maskedCommands, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RequestPredictionData.ClientId);
            // The correlation id are changed in OnHistory.
            AzPredictorTelemetryTests.EnsureDifferentCorrelationId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);
        }

        /// <summary>
        /// Verify that an exception is recorded in request prediction.
        /// </summary>
        [Fact]
        public async Task VerifyStartEarlyProcessingException()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: true, expectedTelemetryCount + 1);

            var history = new List<string>()
            {
                "New-AzVM -Name hello -Location WestUS",
            };

            var maskedCommand = "New-AzVM -Location *** -Name ***";

            azPredictor.StartEarlyProcessing(AzPredictorTelemetryTests.AzPredictorClient, history);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommand, telemetryClient.HistoryData.Command);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.HistoryData.ClientId);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.IsType<MockTestException>(telemetryClient.RequestPredictionData.Exception);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RequestPredictionData.ClientId);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(maskedCommand, telemetryClient.RecordedTelemetry[0].Properties["History"]);

            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal($"{AzPredictorConstants.CommandPlaceholder}\n{maskedCommand}", telemetryClient.RecordedTelemetry[1].Properties["Command"]);
            Assert.StartsWith($"Type: {typeof(MockTestException)}\nStack Trace: ", telemetryClient.RecordedTelemetry[1].Properties["Exception"]);

            // The correlation id are changed in OnHistory.
            AzPredictorTelemetryTests.EnsureDifferentCorrelationId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);
        }

        /// <summary>
        /// Verify that GetSuggestion, SuggestionDisplayed, and SessionAccepted all have the same suggestion session id.
        /// </summary>
        //[Fact]
        private void VerifySameSuggestionSessionId()
        {
            var expectedTelemetryCount = 1;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount + 1);

            var predictionContext = PredictionContext.Create("New-AzResourceGroup -Name 'ResourceGroup01' -Location 'Central US' -WhatIf");
            var suggestionPackage = azPredictor.GetSuggestion(AzPredictorTelemetryTests.AzPredictorClient, predictionContext, CancellationToken.None);

            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.GetSuggestionData.ClientId);
            Assert.Equal(suggestionPackage.Session.Value, telemetryClient.GetSuggestionData.SuggestionSessionId);
            Assert.NotNull(telemetryClient.GetSuggestionData.Suggestion);
            Assert.NotNull(telemetryClient.GetSuggestionData.UserInput);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("GetSuggestion", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(suggestionPackage.Session.Value.ToString(CultureInfo.InvariantCulture), telemetryClient.RecordedTelemetry[0].Properties["SuggestionSessionId"]);
            Assert.Equal("New-AzResourceGroup -Location *** -Name *** -WhatIf ***", telemetryClient.RecordedTelemetry[0].Properties["UserInut"]);
            Assert.Equal("", telemetryClient.RecordedTelemetry[0].Properties["Suggestion"]);

            var displayCountOrIndex = 3;

            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryRecordCount = expectedTelemetryCount + 1;

            azPredictor.OnSuggestionDisplayed(AzPredictorTelemetryTests.AzPredictorClient, suggestionPackage.Session.Value, displayCountOrIndex);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("DisplaySuggestion", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(suggestionPackage.Session.Value.ToString(CultureInfo.InvariantCulture), telemetryClient.RecordedTelemetry[0].Properties["SuggestionSessionId"]);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.SuggestionDisplayedData.ClientId);
            Assert.Equal("ListView", telemetryClient.RecordedTelemetry[0].Properties["SuggestionDisplayMode"]);
            Assert.Equal(displayCountOrIndex.ToString(CultureInfo.InvariantCulture), telemetryClient.RecordedTelemetry[0].Properties["SuggestionCount"]);
            Assert.False(telemetryClient.RecordedTelemetry[0].Properties.ContainsKey("SuggestionIndex"));

            var acceptedSuggestion = "SuggestionAccepted";
            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryRecordCount = expectedTelemetryCount + 1;

            azPredictor.OnSuggestionAccepted(AzPredictorTelemetryTests.AzPredictorClient, suggestionPackage.Session.Value, acceptedSuggestion);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("AcceptSuggestion", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(suggestionPackage.Session.Value.ToString(CultureInfo.InvariantCulture), telemetryClient.RecordedTelemetry[0].Properties["SuggestionSessionId"]);
            Assert.Equal(acceptedSuggestion, telemetryClient.RecordedTelemetry[0].Properties["AccepedSuggestion"]);

            Assert.Equal(suggestionPackage.Session.Value, telemetryClient.SuggestionDisplayedData.SuggestionSessionId);
            Assert.Equal(displayCountOrIndex, telemetryClient.SuggestionDisplayedData.SuggestionCountOrIndex);

            Assert.Equal(suggestionPackage.Session.Value, telemetryClient.SuggestionAcceptedData.SuggestionSessionId);
            Assert.Equal(acceptedSuggestion, telemetryClient.SuggestionAcceptedData.Suggestion);

            AzPredictorTelemetryTests.EnsureSameCorrelationId(telemetryClient.GetSuggestionData, telemetryClient.SuggestionDisplayedData);
            AzPredictorTelemetryTests.EnsureSameCorrelationId(telemetryClient.GetSuggestionData, telemetryClient.SuggestionAcceptedData);
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.GetSuggestionData, telemetryClient.SuggestionDisplayedData);
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.GetSuggestionData, telemetryClient.SuggestionAcceptedData);

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
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount + 1);

            var predictionContext = PredictionContext.Create("New-AzResourceGroup -Name 'ResourceGroup01' -Location 'Central US' -WhatIf");
            var firstSuggestionPackage = azPredictor.GetSuggestion(AzPredictorTelemetryTests.AzPredictorClient, predictionContext, CancellationToken.None);
            var firstGetSuggestionData = telemetryClient.GetSuggestionData;

            var secondSuggestionPackage = azPredictor.GetSuggestion(AzPredictorTelemetryTests.AzPredictorClient, predictionContext, CancellationToken.None);
            var secondGetSuggestionData = telemetryClient.GetSuggestionData;

            Assert.NotEqual(secondSuggestionPackage.Session, firstSuggestionPackage.Session);
            AzPredictorTelemetryTests.EnsureSameCorrelationId(secondGetSuggestionData, firstGetSuggestionData);
            AzPredictorTelemetryTests.EnsureSameSessionId(secondGetSuggestionData, firstGetSuggestionData);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);
        }

        /// <summary>
        /// Verify that we collect correct information for suggestion displayed event.
        /// </summary>
        [Fact]
        public void VerifyListViewInSuggestionDisplayed()
        {
            var expectedTelemetryCount = 1;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount + 1);

            uint suggestionSessionId = 2;
            var suggestionCountOrIndex = 4;
            azPredictor.OnSuggestionDisplayed(AzPredictorTelemetryTests.AzPredictorClient, suggestionSessionId, suggestionCountOrIndex);

            Assert.Equal(suggestionCountOrIndex, telemetryClient.SuggestionDisplayedData.SuggestionCountOrIndex);
            Assert.Equal(SuggestionDisplayMode.ListView, telemetryClient.SuggestionDisplayedData.DisplayMode);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.SuggestionDisplayedData.ClientId);
            Assert.Equal(suggestionSessionId, telemetryClient.SuggestionDisplayedData.SuggestionSessionId);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("DisplaySuggestion", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(suggestionSessionId.ToString(CultureInfo.InvariantCulture), telemetryClient.RecordedTelemetry[0].Properties["SuggestionSessionId"]);
            Assert.Equal("ListView", telemetryClient.RecordedTelemetry[0].Properties["SuggestionDisplayMode"]);
            Assert.Equal(suggestionCountOrIndex.ToString(CultureInfo.InvariantCulture), telemetryClient.RecordedTelemetry[0].Properties["SuggestionCount"]);
            Assert.False(telemetryClient.RecordedTelemetry[0].Properties.ContainsKey("SuggestionIndex"));
        }

        /// <summary>
        /// Verify that we collect correct information for suggestion displayed event.
        /// </summary>
        [Fact]
        public void VerifyInlineViewInSuggestionDisplayedAtEdge()
        {
            var expectedTelemetryCount = 1;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount + 1);

            uint suggestionSessionId = 40;
            var suggestionCountOrIndex = 0;
            azPredictor.OnSuggestionDisplayed(AzPredictorTelemetryTests.AzPredictorClient, suggestionSessionId, suggestionCountOrIndex);

            Assert.Equal(suggestionCountOrIndex, telemetryClient.SuggestionDisplayedData.SuggestionCountOrIndex);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.SuggestionDisplayedData.ClientId);
            Assert.Equal(SuggestionDisplayMode.InlineView, telemetryClient.SuggestionDisplayedData.DisplayMode);
            Assert.Equal(suggestionSessionId, telemetryClient.SuggestionDisplayedData.SuggestionSessionId);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("DisplaySuggestion", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(suggestionSessionId.ToString(CultureInfo.InvariantCulture), telemetryClient.RecordedTelemetry[0].Properties["SuggestionSessionId"]);
            Assert.Equal("InlineView", telemetryClient.RecordedTelemetry[0].Properties["SuggestionDisplayMode"]);
            Assert.Equal(suggestionCountOrIndex.ToString(CultureInfo.InvariantCulture), telemetryClient.RecordedTelemetry[0].Properties["SuggestionIndex"]);
            Assert.False(telemetryClient.RecordedTelemetry[0].Properties.ContainsKey("SuggestionCount"));
        }

        /// <summary>
        /// Verify that we collect correct information for suggestion displayed event.
        /// </summary>
        [Fact]
        public void VerifyInlineViewInSuggestionDisplayed()
        {
            var expectedTelemetryCount = 1;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount + 1);

            uint suggestionSessionId = 14;
            var suggestionCountOrIndex = -1;
            azPredictor.OnSuggestionDisplayed(AzPredictorTelemetryTests.AzPredictorClient, suggestionSessionId, suggestionCountOrIndex);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.Equal(Math.Abs(suggestionCountOrIndex), telemetryClient.SuggestionDisplayedData.SuggestionCountOrIndex);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.SuggestionDisplayedData.ClientId);
            Assert.Equal(SuggestionDisplayMode.InlineView, telemetryClient.SuggestionDisplayedData.DisplayMode);
            Assert.Equal(suggestionSessionId, telemetryClient.SuggestionDisplayedData.SuggestionSessionId);

            Assert.EndsWith("DisplaySuggestion", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(suggestionSessionId.ToString(CultureInfo.InvariantCulture), telemetryClient.RecordedTelemetry[0].Properties["SuggestionSessionId"]);
            Assert.Equal("InlineView", telemetryClient.RecordedTelemetry[0].Properties["SuggestionDisplayMode"]);
            Assert.Equal(Math.Abs(suggestionCountOrIndex).ToString(CultureInfo.InvariantCulture), telemetryClient.RecordedTelemetry[0].Properties["SuggestionIndex"]);
            Assert.False(telemetryClient.RecordedTelemetry[0].Properties.ContainsKey("SuggestionCount"));
        }

        /// <summary>
        /// Verify that the exception is caught correctly from <see also="AzPredictor.GetSuggestion"/>
        /// </summary>
        [Fact]
        public void VerifyExceptionInGetSuggestion()
        {
            var expectedTelemetryCount = 1;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: true, expectedTelemetryCount + 1);

            var predictionContext = PredictionContext.Create("New-AzResourceGroup -Name 'ResourceGroup01' -Location 'Central US' -WhatIf");
            var suggestionPackage = azPredictor.GetSuggestion(AzPredictorTelemetryTests.AzPredictorClient, predictionContext, CancellationToken.None);

            Assert.IsType<MockTestException>(telemetryClient.GetSuggestionData.Exception);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.GetSuggestionData.ClientId);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("GetSuggestion", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(AzPredictorTelemetryTests.AzPredictorClient, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal("New-AzResourceGroup -Location *** -Name *** -WhatIf ***", telemetryClient.RecordedTelemetry[0].Properties["UserInput"]);
            Assert.StartsWith($"Type: {typeof(MockTestException)}\nStack Trace: ", telemetryClient.RecordedTelemetry[0].Properties["Exception"]);
        }

        private (AzPredictor, MockAzPredictorTelemetryClient) CreateTestObjects(bool throwException, int expectedTelemetryEvent)
        {
            var telemetryClient = new MockAzPredictorTelemetryClient();
            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryRecordCount = expectedTelemetryEvent;
            var startHistory = $"{AzPredictorConstants.CommandPlaceholder}{AzPredictorConstants.CommandConcatenator}{AzPredictorConstants.CommandPlaceholder}";

            var service = new MockAzPredictorService(startHistory, _fixture.PredictionCollection[startHistory], _fixture.CommandCollection);
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
        /// Verifies that the number of telemetry events to be sent is equal to <paramref name="expectedCount"/>.
        /// </summary>
        /// <remarks>
        /// It requires to set up the <paramref name="telemetryClient"/> with the <see cref="MockAzPredictorTelemetryClient.ExceptedTelemetryRecordCount"/> one more than <paramref name="expectedCount"/>.
        /// That means the expectedTelemetryEvent in <see cref="CreateTestObjects"/> should be one plus
        /// <paramref name="expectedCount"/>.
        /// Internally, it'll check that the task in <see cref="MockAzPredictorTelemetryClient.SendTelemetryTaskCompletionSource"/> times out because it's waiting for one more telemetry event and that telemetry event never comes.
        /// </remarks>
        private void VerifyTelemetryRecordCount(int expectedCount, MockAzPredictorTelemetryClient telemetryClient)
        {
            Assert.False(telemetryClient.SendTelemetryTaskCompletionSource.Task.Wait(TimeSpan.FromMilliseconds(200)));
            Assert.Equal(expectedCount, telemetryClient.RecordedTelemetry.Count);
        }

        private static void EnsureDifferentCorrelationId(ITelemetryData expected, ITelemetryData actual)
        {
            Assert.NotEqual(expected.CorrelationId, actual.CorrelationId);
        }

        private static void EnsureSameCorrelationId(ITelemetryData expected, ITelemetryData actual)
        {
            Assert.Equal(expected.CorrelationId, actual.CorrelationId);
        }

        private static void EnsureSameSessionId(ITelemetryData expected, ITelemetryData actual)
        {
            Assert.Equal(expected.SessionId, actual.SessionId);
        }
    }
}
