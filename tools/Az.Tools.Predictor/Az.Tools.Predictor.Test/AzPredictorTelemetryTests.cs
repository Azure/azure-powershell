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
using System.Linq;
using System.Management.Automation.Subsystem.Prediction;
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
            Assert.Equal(AzPredictorTelemetryTests.GetCommandName(inputData), telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(new List<string>() { AzPredictorConstants.CommandPlaceholder, AzPredictorConstants.CommandPlaceholder }, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);
            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(AzPredictorTelemetryTests.GetCommandName(inputData), telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.Equal("False", telemetryClient.RecordedTelemetry[0].Properties["Success"]);

            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal($"{AzPredictorConstants.CommandPlaceholder}\n{AzPredictorConstants.CommandPlaceholder}", telemetryClient.RecordedTelemetry[1].Properties["Command"]);

            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            Assert.Null(telemetryClient.GetSuggestionData);
            Assert.Null(telemetryClient.SuggestionDisplayedData);
            Assert.Null(telemetryClient.SuggestionAcceptedData);
            Assert.Null(telemetryClient.ParameterMapData);
        }

        /// <summary>
        /// Verify that the parameter values in the supported commands are masked in <see cref="AzPredictor.OnCommandLineAccepted"/>.
        /// </summary>
        [Fact]
        public async Task VerifyOnCommandLineAcceptedForOneSupportedCommandWithoutParameter()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            // There is only one command.
            IReadOnlyList<string> history = new List<string>()
            {
                "Get-AzContext",
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history[0], true);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(history[0], telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(new List<string>() { AzPredictorConstants.CommandPlaceholder, history[0] }, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(history[0], telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[0].Properties["Success"]);
            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal($"{AzPredictorConstants.CommandPlaceholder}\n{history[0]}", telemetryClient.RecordedTelemetry[1].Properties["Command"]);

            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            Assert.Null(telemetryClient.GetSuggestionData);
            Assert.Null(telemetryClient.SuggestionDisplayedData);
            Assert.Null(telemetryClient.SuggestionAcceptedData);
            Assert.Null(telemetryClient.ParameterMapData);
        }

        /// <summary>
        /// Verify that the parameter values in the supported commands are masked in <see cref="AzPredictor.OnCommandLineAccepted"/>.
        /// </summary>
        [Fact]
        public async Task VerifyOnCommandLineAcceptedForOneSupportedCommandWithParameter()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            // There is only one command with parameter.
            var history = new List<string>()
            {
                "New-AzVM -Name hello -Location WestUS"
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history[0], true);

            var maskedCommand = "New-AzVM -Location *** -Name ***";

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal("New-AzVM -Location *** -Name ***", telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);
            Assert.Equal(new List<string>() { AzPredictorConstants.CommandPlaceholder, maskedCommand }, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(maskedCommand, telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[0].Properties["Success"]);
            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal($"{AzPredictorConstants.CommandPlaceholder}\n{maskedCommand}", telemetryClient.RecordedTelemetry[1].Properties["Command"]);

            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

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
                "Get-AzContext",
                "New-AzVM -Name hello -Location WestUS",
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history[1], false);

            var maskedCommands = new List<string>()
            {
                "Get-AzContext",
                "New-AzVM -Location *** -Name ***",
            };

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommands[1], telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(maskedCommands, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(maskedCommands[1], telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.Equal("False", telemetryClient.RecordedTelemetry[0].Properties["Success"]);
            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal(string.Join("\n", maskedCommands), telemetryClient.RecordedTelemetry[1].Properties["Command"]);

            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

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
            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[0].Properties["Success"]);
            // Should use the placeholder for the assignment like \"$a='ResourceGroup01'\" where there is no command name at the right side.
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal($"{AzPredictorConstants.CommandPlaceholder}\n{AzPredictorConstants.CommandPlaceholder}", telemetryClient.RecordedTelemetry[1].Properties["Command"]);

            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

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
        public async Task VerifyOnCommandLineAcceptedForUnsupportedCommandAfterSupportedOnes()
        {
            var expectedTelemetryCount = 2;
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

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

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history[1], false);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommands[1], telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(maskedCommands, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);
            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(maskedCommands[1], telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.Equal("False", telemetryClient.RecordedTelemetry[0].Properties["Success"]);
            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal(string.Join("\n", maskedCommands), telemetryClient.RecordedTelemetry[1].Properties["Command"]);

            var firstHistoryData = telemetryClient.HistoryData;
            var firstRequestPredictionData = telemetryClient.RequestPredictionData;

            telemetryClient.ResetWaitingTasks();
            expectedTelemetryCount = 1;
            telemetryClient.ExceptedTelemetryRecordCount = expectedTelemetryCount;

            history.Add("git status");
            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), true);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(AzPredictorTelemetryTests.GetCommandName(history.Last()), telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            // Don't need to await on telemetryClient.RequestPredictioinTask, because "git" isn't a supported command and RequestPredictionsAsync isn't called.
            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);
            Assert.Null(telemetryClient.RequestPredictionData);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(AzPredictorTelemetryTests.GetCommandName(history.Last()), telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[0].Properties["Success"]);

            var secondHistoryData = telemetryClient.HistoryData;

            // Make sure that the RequestPrediction event can be correlated to the right History event.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(firstHistoryData, firstRequestPredictionData);
            AzPredictorTelemetryTests.EnsureSameRequestId(firstRequestPredictionData, secondHistoryData);

            AzPredictorTelemetryTests.EnsureSameSessionId(firstHistoryData, firstRequestPredictionData);
            AzPredictorTelemetryTests.EnsureSameSessionId(firstRequestPredictionData, secondHistoryData);

            telemetryClient.ResetWaitingTasks();
            expectedTelemetryCount = 1;
            telemetryClient.ExceptedTelemetryRecordCount = expectedTelemetryCount;

            history.Add(@"$a='NewResourceName'");
            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), false);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(AzPredictorConstants.CommandPlaceholder, telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            // Don't need to await on telemetryClient.RequestPredictioinTask, because assignment isn't a supported command and RequestPredictionsAsync isn't called.
            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);
            Assert.Null(telemetryClient.RequestPredictionData);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(AzPredictorTelemetryTests.GetCommandName(history.Last()), telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.Equal("False", telemetryClient.RecordedTelemetry[0].Properties["Success"]);

            // There is no new request prediction. The request id isn't changed.
            AzPredictorTelemetryTests.EnsureSameRequestId(firstRequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(firstRequestPredictionData, telemetryClient.HistoryData);

            telemetryClient.ResetWaitingTasks();
            expectedTelemetryCount = 2;
            telemetryClient.ExceptedTelemetryRecordCount = expectedTelemetryCount;

            history.Add("Get-AzResourceGroup -Name:ResourceGroup01");
            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), true);

            maskedCommands = new List<string>()
            {
                "New-AzVM -Location *** -Name ***",
                "Get-AzResourceGroup -Name:***",
            };

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommands[1], telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(maskedCommands, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);
            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(maskedCommands[1], telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.Equal("True", telemetryClient.RecordedTelemetry[0].Properties["Success"]);
            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal(string.Join("\n", maskedCommands), telemetryClient.RecordedTelemetry[1].Properties["Command"]);

            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);
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
                "New-AzVM -Name:hello -Location:WestUS"
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), false);

            var maskedCommands = new List<string>()
            {
                AzPredictorConstants.CommandPlaceholder,
                "New-AzVM -Location:*** -Name:***"
            };

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommands[1], telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(maskedCommands, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);
            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);
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
                "New-AzVM -Name hello -Location WestUS",
                "git status",
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), true);

            var maskedCommands = new List<string>()
            {
                AzPredictorConstants.CommandPlaceholder,
                "New-AzVM -Location *** -Name ***",
            };

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(AzPredictorTelemetryTests.GetCommandName(history[1]), telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.Equal(maskedCommands, telemetryClient.RequestPredictionData.Commands);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);
            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            // SetssionId is not changed.
            AzPredictorTelemetryTests.EnsureSameSessionId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);
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
                "New-AzVM -Name hello -Location WestUS",
            };

            var maskedCommand = "New-AzVM -Location *** -Name ***";

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), false);

            await telemetryClient.HistoryTaskCompletionSource.Task;
            Assert.Equal(maskedCommand, telemetryClient.HistoryData.Command);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.HistoryData.Client);

            await telemetryClient.RequestPredictionTaskCompletionSource.Task;
            Assert.IsType<MockTestException>(telemetryClient.RequestPredictionData.Exception);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.RequestPredictionData.Client);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("CommandHistory", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(maskedCommand, telemetryClient.RecordedTelemetry[0].Properties["History"]);
            Assert.Equal("False", telemetryClient.RecordedTelemetry[0].Properties["Success"]);

            Assert.EndsWith("RequestPrediction", telemetryClient.RecordedTelemetry[1].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[1].Properties["ClientId"]);
            Assert.Equal($"{AzPredictorConstants.CommandPlaceholder}\n{maskedCommand}", telemetryClient.RecordedTelemetry[1].Properties["Command"]);
            Assert.StartsWith($"Type: {typeof(MockTestException)}\nStack Trace: ", telemetryClient.RecordedTelemetry[1].Properties["Exception"]);

            // The request id are changed in OnRequestPrediction.
            AzPredictorTelemetryTests.EnsureDifferentRequestId(telemetryClient.RequestPredictionData, telemetryClient.HistoryData);

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
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            var predictionContext = PredictionContext.Create("New-AzResourceGroup -Name 'ResourceGroup01' -Location 'Central US' -WhatIf");
            var suggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);

            Assert.Equal(MockObjects.PredictionClient, telemetryClient.GetSuggestionData.Client);
            Assert.Equal(suggestionPackage.Session.Value, telemetryClient.GetSuggestionData.SuggestionSessionId);
            Assert.NotNull(telemetryClient.GetSuggestionData.Suggestion);
            Assert.NotNull(telemetryClient.GetSuggestionData.UserInput);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("GetSuggestion", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(suggestionPackage.Session.Value.ToString(CultureInfo.InvariantCulture), telemetryClient.RecordedTelemetry[0].Properties["SuggestionSessionId"]);
            Assert.Equal("New-AzResourceGroup -Location *** -Name *** -WhatIf ***", telemetryClient.RecordedTelemetry[0].Properties["UserInut"]);
            Assert.Equal("", telemetryClient.RecordedTelemetry[0].Properties["Suggestion"]);

            var displayCountOrIndex = 3;

            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryRecordCount = expectedTelemetryCount;

            azPredictor.OnSuggestionDisplayed(MockObjects.PredictionClient, suggestionPackage.Session.Value, displayCountOrIndex);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("DisplaySuggestion", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(suggestionPackage.Session.Value.ToString(CultureInfo.InvariantCulture), telemetryClient.RecordedTelemetry[0].Properties["SuggestionSessionId"]);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.SuggestionDisplayedData.Client);
            Assert.Equal("ListView", telemetryClient.RecordedTelemetry[0].Properties["SuggestionDisplayMode"]);
            Assert.Equal(displayCountOrIndex.ToString(CultureInfo.InvariantCulture), telemetryClient.RecordedTelemetry[0].Properties["SuggestionCount"]);
            Assert.False(telemetryClient.RecordedTelemetry[0].Properties.ContainsKey("SuggestionIndex"));

            var acceptedSuggestion = "SuggestionAccepted";
            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryRecordCount = expectedTelemetryCount;

            azPredictor.OnSuggestionAccepted(MockObjects.PredictionClient, suggestionPackage.Session.Value, acceptedSuggestion);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("AcceptSuggestion", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal(suggestionPackage.Session.Value.ToString(CultureInfo.InvariantCulture), telemetryClient.RecordedTelemetry[0].Properties["SuggestionSessionId"]);
            Assert.Equal(acceptedSuggestion, telemetryClient.RecordedTelemetry[0].Properties["AccepedSuggestion"]);

            Assert.Equal(suggestionPackage.Session.Value, telemetryClient.SuggestionDisplayedData.SuggestionSessionId);
            Assert.Equal(displayCountOrIndex, telemetryClient.SuggestionDisplayedData.SuggestionCountOrIndex);

            Assert.Equal(suggestionPackage.Session.Value, telemetryClient.SuggestionAcceptedData.SuggestionSessionId);
            Assert.Equal(acceptedSuggestion, telemetryClient.SuggestionAcceptedData.Suggestion);

            AzPredictorTelemetryTests.EnsureSameRequestId(telemetryClient.GetSuggestionData, telemetryClient.SuggestionDisplayedData);
            AzPredictorTelemetryTests.EnsureSameRequestId(telemetryClient.GetSuggestionData, telemetryClient.SuggestionAcceptedData);
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
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            var predictionContext = PredictionContext.Create("New-AzResourceGroup -Name 'ResourceGroup01' -Location 'Central US' -WhatIf");
            var firstSuggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);
            var firstGetSuggestionData = telemetryClient.GetSuggestionData;

            var secondSuggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);
            var secondGetSuggestionData = telemetryClient.GetSuggestionData;

            Assert.NotEqual(secondSuggestionPackage.Session, firstSuggestionPackage.Session);
            AzPredictorTelemetryTests.EnsureSameRequestId(secondGetSuggestionData, firstGetSuggestionData);
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
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            uint suggestionSessionId = 2;
            var suggestionCountOrIndex = 4;
            azPredictor.OnSuggestionDisplayed(MockObjects.PredictionClient, suggestionSessionId, suggestionCountOrIndex);

            Assert.Equal(suggestionCountOrIndex, telemetryClient.SuggestionDisplayedData.SuggestionCountOrIndex);
            Assert.Equal(SuggestionDisplayMode.ListView, telemetryClient.SuggestionDisplayedData.DisplayMode);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.SuggestionDisplayedData.Client);
            Assert.Equal(suggestionSessionId, telemetryClient.SuggestionDisplayedData.SuggestionSessionId);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("DisplaySuggestion", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
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
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            uint suggestionSessionId = 40;
            var suggestionCountOrIndex = 0;
            azPredictor.OnSuggestionDisplayed(MockObjects.PredictionClient, suggestionSessionId, suggestionCountOrIndex);

            Assert.Equal(suggestionCountOrIndex, telemetryClient.SuggestionDisplayedData.SuggestionCountOrIndex);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.SuggestionDisplayedData.Client);
            Assert.Equal(SuggestionDisplayMode.InlineView, telemetryClient.SuggestionDisplayedData.DisplayMode);
            Assert.Equal(suggestionSessionId, telemetryClient.SuggestionDisplayedData.SuggestionSessionId);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("DisplaySuggestion", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
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
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: false, expectedTelemetryCount);

            uint suggestionSessionId = 14;
            var suggestionCountOrIndex = -1;
            azPredictor.OnSuggestionDisplayed(MockObjects.PredictionClient, suggestionSessionId, suggestionCountOrIndex);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.Equal(Math.Abs(suggestionCountOrIndex), telemetryClient.SuggestionDisplayedData.SuggestionCountOrIndex);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.SuggestionDisplayedData.Client);
            Assert.Equal(SuggestionDisplayMode.InlineView, telemetryClient.SuggestionDisplayedData.DisplayMode);
            Assert.Equal(suggestionSessionId, telemetryClient.SuggestionDisplayedData.SuggestionSessionId);

            Assert.EndsWith("DisplaySuggestion", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
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
            var (azPredictor, telemetryClient) = CreateTestObjects(throwException: true, expectedTelemetryCount);

            var predictionContext = PredictionContext.Create("New-AzResourceGroup -Name 'ResourceGroup01' -Location 'Central US' -WhatIf");
            var suggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);

            Assert.IsType<MockTestException>(telemetryClient.GetSuggestionData.Exception);
            Assert.Equal(MockObjects.PredictionClient, telemetryClient.GetSuggestionData.Client);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            Assert.EndsWith("GetSuggestion", telemetryClient.RecordedTelemetry[0].EventName);
            Assert.Equal(MockObjects.PredictionClient.Name, telemetryClient.RecordedTelemetry[0].Properties["ClientId"]);
            Assert.Equal("New-AzResourceGroup -Location *** -Name *** -WhatIf ***", telemetryClient.RecordedTelemetry[0].Properties["UserInput"]);
            Assert.StartsWith($"Type: {typeof(MockTestException)}\nStack Trace: ", telemetryClient.RecordedTelemetry[0].Properties["Exception"]);
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
                "New-AzVM -Name hello -Location WestUS",
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), false);

            var predictionContext = PredictionContext.Create("New-AzResourceGroup -Name 'ResourceGroup01' -Location 'Central US'");
            var suggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            var originalHistoryData = telemetryClient.HistoryData;
            var firstRequestPredictionData = telemetryClient.RequestPredictionData;
            var firstGetSuggestionData = telemetryClient.GetSuggestionData;

            expectedTelemetryCount = 2;
            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryRecordCount = expectedTelemetryCount;

            history = new List<string>()
            {
                "Get-AzSqlServer",
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), false);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            var firstHistoryData = telemetryClient.HistoryData;
            var secondRequestPredictionData = telemetryClient.RequestPredictionData;

            EnsureSameRequestId(firstRequestPredictionData, firstGetSuggestionData);
            EnsureSameRequestId(firstRequestPredictionData, firstHistoryData);
            EnsureSameCommandId(firstHistoryData, firstRequestPredictionData);
            EnsureSameCommandId(firstHistoryData, firstGetSuggestionData);

            // TODO should verify the RecordedTelemetry

            EnsureDifferentComamandId(firstHistoryData, originalHistoryData);
            EnsureDifferentRequestId(firstRequestPredictionData, secondRequestPredictionData);

            // Now add a "git" command. It doesn't change the request id, but change the command id.

            expectedTelemetryCount = 2;
            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryRecordCount = expectedTelemetryCount;

            predictionContext = PredictionContext.Create("New-AzResourceGroup -Name 'ResourceGroup01' -Location 'Central US'");
            suggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);

            history =new List<string>()
            {
                "git status",
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), false);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            var secondGetSuggestionData = telemetryClient.GetSuggestionData;
            var secondHistoryData = telemetryClient.HistoryData;
            var thirdRequestPredictionData = telemetryClient.RequestPredictionData;

            expectedTelemetryCount = 2;
            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryRecordCount = expectedTelemetryCount;

            predictionContext = PredictionContext.Create("New-AzVM -Name 'VM01' -Location 'Central US'");
            suggestionPackage = azPredictor.GetSuggestion(MockObjects.PredictionClient, predictionContext, CancellationToken.None);

            history =new List<string>()
            {
                "git commit",
            };

            azPredictor.OnCommandLineAccepted(MockObjects.PredictionClient, history);
            azPredictor.OnCommandLineExecuted(MockObjects.PredictionClient, history.Last(), true);

            VerifyTelemetryRecordCount(expectedTelemetryCount, telemetryClient);

            var thirdGetSuggestionData = telemetryClient.GetSuggestionData;
            var thirdHistoryData = telemetryClient.HistoryData;
            var fourthRequestPredictionData = telemetryClient.RequestPredictionData;

            Assert.Null(thirdRequestPredictionData); // Since it's "git", we don't send the request.
            Assert.Null(fourthRequestPredictionData); // Since it's "git", we don't send the request.

            EnsureSameRequestId(secondRequestPredictionData, secondGetSuggestionData);
            EnsureSameRequestId(secondRequestPredictionData, secondHistoryData);
            EnsureSameRequestId(secondRequestPredictionData, thirdGetSuggestionData);
            EnsureSameRequestId(secondRequestPredictionData, thirdHistoryData);

            EnsureDifferentComamandId(secondHistoryData, firstHistoryData);
            EnsureSameCommandId(secondHistoryData, secondGetSuggestionData);

            EnsureDifferentComamandId(thirdHistoryData, secondHistoryData);
            EnsureSameCommandId(thirdHistoryData, thirdGetSuggestionData);
        }

        private (AzPredictor, MockAzPredictorTelemetryClient) CreateTestObjects(bool throwException, int expectedTelemetryEvent)
        {
            var telemetryClient = new MockAzPredictorTelemetryClient();
            telemetryClient.ResetWaitingTasks();
            telemetryClient.ExceptedTelemetryRecordCount = expectedTelemetryEvent;
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
        /// Verifies that the number of telemetry events to be sent is equal to <paramref name="expectedCount"/>.
        /// </summary>
        private void VerifyTelemetryRecordCount(int expectedCount, MockAzPredictorTelemetryClient telemetryClient)
        {
            Assert.True(telemetryClient.SendTelemetryTaskCompletionSource.Task.Wait(TimeSpan.FromMilliseconds(500)));
            Assert.Equal(expectedCount, telemetryClient.RecordedTelemetry.Count);
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

        private static void EnsureSameSessionId(ITelemetryData expected, ITelemetryData actual)
        {
            Assert.Equal(expected.SessionId, actual.SessionId);
        }

        /// <summary>
        /// Gets the command name offrom the user input.
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
