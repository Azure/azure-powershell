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

using Microsoft.Azure.PowerShell.Tools.AzPredictor.Test.Mocks;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Subsystem;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test
{
    /// <summary>
    /// Tests for <see cref="AzPredictor"/>
    /// </summary>
    [Collection("Model collection")]
    public sealed class AzPredictorTests
    {
        private const string AzPredictorClient = "Test";
        private readonly ModelFixture _fixture;
        private readonly MockAzPredictorTelemetryClient _telemetryClient;
        private readonly MockAzPredictorService _service;
        private readonly AzPredictor _azPredictor;

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictorTests"/>
        /// </summary>
        public AzPredictorTests(ModelFixture modelFixture)
        {
            _fixture = modelFixture;
            var startHistory = $"{AzPredictorConstants.CommandPlaceholder}{AzPredictorConstants.CommandConcatenator}{AzPredictorConstants.CommandPlaceholder}";

            _service = new MockAzPredictorService(startHistory, _fixture.PredictionCollection[startHistory], _fixture.CommandCollection);
            _telemetryClient = new MockAzPredictorTelemetryClient();
            _azPredictor = new AzPredictor(_service, _telemetryClient, new Settings()
            {
                SuggestionCount = 1,
                MaxAllowedCommandDuplicate = 1,
            },
            null);
        }

        /// <summary>
        /// Verify we replace unsupported command with <see cref="AzPredictorConstants.CommandPlaceholder"/>.
        /// </summary>
        [Fact]
        public async Task VerifyRequestPredictionForOneUnsupportedCommandInHistory()
        {
            IReadOnlyList<string> history = new List<string>()
            {
                "git status"
            };

            _service.Commands = null;
            _service.History = null;
            _service.ResetRequestPredictionTask();

            _azPredictor.StartEarlyProcessing(AzPredictorTests.AzPredictorClient, history);
            await _service.RequestPredictionTaskCompletionSource.Task;

            Assert.Equal(new List<string>() { AzPredictorConstants.CommandPlaceholder, AzPredictorConstants.CommandPlaceholder }, _service.Commands);
            Assert.Null(_service.History);
        }

        /// <summary>
        /// Verify that we masked the supported command in requesting prediction and telemetry.
        /// </summary>
        [Fact]
        public async Task VerifyRequestPredictionForOneSupportedCommandInHistory()
        {
            IReadOnlyList<string> history = new List<string>()
            {
                "New-AzVM -Name hello -Location WestUS"
            };

            _service.Commands = null;
            _service.History = null;
            _service.ResetRequestPredictionTask();

            _azPredictor.StartEarlyProcessing(AzPredictorTests.AzPredictorClient, history);
            await _service.RequestPredictionTaskCompletionSource.Task;

            string maskedCommand = "New-AzVM -Location *** -Name ***";

            Assert.Equal(new List<string>() { AzPredictorConstants.CommandPlaceholder, maskedCommand }, _service.Commands);
            Assert.Equal(history[0], _service.History.ToString());
        }

        /// <summary>
        ///  Verify that we can handle the two supported command in sequences.
        /// </summary>
        [Fact]
        public async Task VerifyRequestPredictionForTwoSupportedCommandInHistory()
        {
            IReadOnlyList<string> history = new List<string>()
            {
                "New-AzResourceGroup -Name 'resourceGroup01'",
                "New-AzVM -Name:hello -Location:WestUS"
            };

            _service.Commands = null;
            _service.History = null;
            _service.ResetRequestPredictionTask();

            _azPredictor.StartEarlyProcessing(AzPredictorTests.AzPredictorClient, history);
            await _service.RequestPredictionTaskCompletionSource.Task;

            var maskedCommands = new List<string>()
            {
                "New-AzResourceGroup -Name ***",
                "New-AzVM -Location:*** -Name:***"
            };

            Assert.Equal(maskedCommands, _service.Commands);
            Assert.Equal(history[1], _service.History.ToString());
        }

        /// <summary>
        ///  Verify that we can handle the two unsupported command in sequences.
        /// </summary>
        [Fact]
        public async Task VerifyRequestPredictionForTwoUnsupportedCommandInHistory()
        {
            IReadOnlyList<string> history = new List<string>()
            {
                "git status",
                @"$a='ResourceGroup01'",
            };

            _service.Commands = null;
            _service.History = null;
            _service.ResetRequestPredictionTask();

            _azPredictor.StartEarlyProcessing(AzPredictorTests.AzPredictorClient, history);
            await _service.RequestPredictionTaskCompletionSource.Task;

            var maskedCommands = new List<string>()
            {
                AzPredictorConstants.CommandPlaceholder,
                AzPredictorConstants.CommandPlaceholder,
            };

            Assert.Equal(maskedCommands, _service.Commands);
            Assert.Null(_service.History);
        }

        /// <summary>
        /// Verify that we skip the unsupported commands.
        /// </summary>
        [Fact]
        public async Task VerifyNotTakeUnsupportedCommands()
        {
            var history = new List<string>()
            {
                "New-AzResourceGroup -Name:resourceGroup01",
                "New-AzVM -Name hello -Location WestUS"
            };

            _service.Commands = null;
            _service.History = null;
            _service.ResetRequestPredictionTask();

            _azPredictor.StartEarlyProcessing(AzPredictorTests.AzPredictorClient, history);
            await _service.RequestPredictionTaskCompletionSource.Task;

            _service.ResetRequestPredictionTask();
            history.Add("git status");
            _azPredictor.StartEarlyProcessing(AzPredictorTests.AzPredictorClient, history);
            // Don't need to await on _service.RequestPredictionTask, because "git" isn't a supported command and RequestPredictionsAsync isn't called.

            _service.ResetRequestPredictionTask();
            history.Add(@"$a='NewResourceName'");
            _azPredictor.StartEarlyProcessing(AzPredictorTests.AzPredictorClient, history);
            // Don't need to await on _service.RequestPredictionTask, because assignment isn't supported and RequestPredictionsAsync isn't called.

            // We don't take the last two unsupported command to request predictions.
            // But we send the masked one in telemetry.

            var maskedCommands = new List<string>()
            {
                "New-AzResourceGroup -Name:***",
                "New-AzVM -Location *** -Name ***"
            };

            Assert.Equal(maskedCommands, _service.Commands);
            Assert.Equal(history[1], _service.History.ToString());

            // When there is a new supported command, we'll use that for prediction.

            _service.ResetRequestPredictionTask();
            history.Add("Get-AzResourceGroup -Name ResourceGroup01");
            _azPredictor.StartEarlyProcessing(AzPredictorTests.AzPredictorClient, history);
            await _service.RequestPredictionTaskCompletionSource.Task;

            maskedCommands = new List<string>()
            {
                "New-AzVM -Location *** -Name ***",
                "Get-AzResourceGroup -Name ***",
            };

            Assert.Equal(maskedCommands, _service.Commands);
            Assert.Equal(history.Last(), _service.History.ToString());
        }

        /// <summary>
        /// Verify that we handle the three supported command in the same order.
        /// </summary>
        [Fact]
        public async Task VerifyThreeSupportedCommands()
        {
            var history = new List<string>()
            {
                "New-AzResourceGroup -Name resourceGroup01",
                "New-AzVM -Name:hello -Location:WestUS"
            };

            _service.Commands = null;
            _service.History = null;
            _service.ResetRequestPredictionTask();

            _azPredictor.StartEarlyProcessing(AzPredictorTests.AzPredictorClient, history);
            await _service.RequestPredictionTaskCompletionSource.Task;

            _service.ResetRequestPredictionTask();
            history.Add("Get-AzResourceGroup -Name resourceGroup01");
            _azPredictor.StartEarlyProcessing(AzPredictorTests.AzPredictorClient, history);
            await _service.RequestPredictionTaskCompletionSource.Task;

            var maskedCommands = new List<string>()
            {
                "New-AzVM -Location:*** -Name:***",
                "Get-AzResourceGroup -Name ***",
            };

            Assert.Equal(maskedCommands, _service.Commands);
            Assert.Equal(history.Last(), _service.History.ToString());
        }

        /// <summary>
        /// Verify that we handle the sequence of one unsupported command and one supported command.
        /// </summary>
        [Fact]
        public async Task VerifyUnsupportedAndSupportedCommands()
        {
            var history = new List<string>()
            {
                "git status",
                "New-AzVM -Name:hello -Location:WestUS"
            };

            _service.Commands = null;
            _service.History = null;
            _service.ResetRequestPredictionTask();

            _azPredictor.StartEarlyProcessing(AzPredictorTests.AzPredictorClient, history);
            await _service.RequestPredictionTaskCompletionSource.Task;

            var maskedCommands = new List<string>()
            {
                AzPredictorConstants.CommandPlaceholder,
                "New-AzVM -Location:*** -Name:***"
            };

            Assert.Equal(maskedCommands, _service.Commands);
            Assert.Equal(history.Last(), _service.History.ToString());
        }

        /// <summary>
        /// Verify that we handle the sequence of one supported command and one unsupported command.
        /// </summary>
        [Fact]
        public async Task VerifySupportedAndUnsupportedCommands()
        {
            var history = new List<string>()
            {
                "New-AzVM -Name hello -Location WestUS",
                "git status",
            };

            _service.Commands = null;
            _service.History = null;
            _service.ResetRequestPredictionTask();

            _azPredictor.StartEarlyProcessing(AzPredictorTests.AzPredictorClient, history);
            await _service.RequestPredictionTaskCompletionSource.Task;

            var maskedCommands = new List<string>()
            {
                AzPredictorConstants.CommandPlaceholder,
                "New-AzVM -Location *** -Name ***",
            };

            Assert.Equal(maskedCommands, _service.Commands);
            Assert.Equal(history.First(), _service.History.ToString());
        }

        /// <summary>
        /// Verifies AzPredictor returns the same value as AzPredictorService for the prediction.
        /// </summary>
        [Theory]
        [InlineData("new-azresourcegroup -name hello")]
        [InlineData("Get-AzContext -Name")]
        public void VerifySuggestion(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var expected = this._service.GetSuggestion(predictionContext, 1, 1, CancellationToken.None);
            var actual = this._azPredictor.GetSuggestion(AzPredictorTests.AzPredictorClient, predictionContext, CancellationToken.None);

            Assert.Equal(expected.Count, actual.SuggestionEntries.Count);
            Assert.Equal(expected.PredictiveSuggestions.First().SuggestionText, actual.SuggestionEntries.First().SuggestionText);
        }

        /// <summary>
        /// Verifies that we still return correct prediction when the user has input an incomplete command line.
        /// </summary>
        [Fact]
        public void VerifySuggestionOnIncompleteCommand()
        {
            // We need to get the suggestions for more than one. So we create a local version az predictor.
            var localAzPredictor = new AzPredictor(_service, _telemetryClient, new Settings()
            {
                SuggestionCount = 7,
                MaxAllowedCommandDuplicate = 1,
            },
            null);

            var userInput = "New-AzResourceGroup -Name 'ResourceGroup01' -Location 'Central US' -WhatIf -";
            var expected = "New-AzResourceGroup -Name 'ResourceGroup01' -Location 'Central US' -WhatIf -Tag value1";

            var predictionContext = PredictionContext.Create(userInput);
            var actual = localAzPredictor.GetSuggestion(AzPredictorTests.AzPredictorClient, predictionContext, CancellationToken.None);

            Assert.Equal(expected, actual.SuggestionEntries.First().SuggestionText);
        }

        /// <summary>
        /// Verify when we cannot parse the user input correctly.
        /// </summary>
        /// <remarks>
        /// When we can parse them correctly, please move the InlineData to the corresponding test methods, for example, "git status"
        /// can be moved to <see cref="VerifySuggestion"/>.
        /// </remarks>
        [Theory]
        [InlineData("git status")]
        public void VerifyMalFormattedCommandLine(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var actual = _azPredictor.GetSuggestion(AzPredictorTests.AzPredictorClient, predictionContext, CancellationToken.None);

            Assert.Null(actual.SuggestionEntries);
        }
    }
}
