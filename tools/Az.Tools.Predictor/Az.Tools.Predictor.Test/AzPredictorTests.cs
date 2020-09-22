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
using Xunit;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test
{
    /// <summary>
    /// Tests for <see cref="AzPredictor"/>
    /// </summary>
    [Collection("Model collection")]
    public sealed class AzPredictorTests
    {
        private readonly ModelFixture _fixture;
        private readonly MockAzPredictorTelemetryClient _telemetryClient;
        private readonly MockAzPredictorService _service;
        private readonly AzPredictor _azPredictor;

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictorTests"/>
        /// </summary>
        public AzPredictorTests(ModelFixture modelFixture)
        {
            this._fixture = modelFixture;
            var startHistory = $"{AzPredictorConstants.CommandHistoryPlaceholder}{AzPredictorConstants.CommandConcatenator}{AzPredictorConstants.CommandHistoryPlaceholder}";

            this._service = new MockAzPredictorService(startHistory, this._fixture.PredictionCollection[startHistory], this._fixture.CommandCollection);
            this._telemetryClient = new MockAzPredictorTelemetryClient();
            this._azPredictor = new AzPredictor(this._service, this._telemetryClient, new Settings()
            {
                SuggestionCount = 1,
            });
        }

        /// <summary>
        /// Verifies when the last command in history are not supported.
        /// We don't collect the telemetry and only request prediction while StartEarlyProcess is called.
        /// </summary>
        [Theory]
        [InlineData("start_of_snippet\nstart_of_snippet\nstart_of_snippet")]
        [InlineData("start_of_snippet")]
        [InlineData("")]
        [InlineData("git status")]
        [InlineData("git status\nGet-ChildItem")]
        [InlineData("^29a9l2")]
        [InlineData("'Get-AzResource'")]
        [InlineData("Get-AzResource\ngit log")]
        [InlineData("Get-ChildItem")]
        public void VerifyWithNonSupportedCommand(string historyLine)
        {
            IReadOnlyList<string> history = historyLine.Split('\n');

            this._telemetryClient.RecordedSuggestion = null;
            this._service.IsPredictionRequested = false;

            this._azPredictor.StartEarlyProcessing(history);

            Assert.True(this._service.IsPredictionRequested);
            Assert.Null(this._telemetryClient.RecordedSuggestion);
        }

        /// <summary>
        /// Verifies when the last command in history are not supported.
        /// We don't collect the telemetry and only request prediction while StartEarlyProcess is called.
        /// </summary>
        [Theory]
        [InlineData("start_of_snippet\nConnect-AzAccount")]
        [InlineData("Get-AzResource")]
        [InlineData("git status\nGet-AzContext")]
        [InlineData("Get-AzContext\nGet-AzLog")]
        public void VerifyWithOneSupportedCommand(string historyLine)
        {
            IReadOnlyList<string> history = historyLine.Split('\n');

            this._telemetryClient.RecordedSuggestion = null;
            this._service.IsPredictionRequested = false;

            this._azPredictor.StartEarlyProcessing(history);

            Assert.True(this._service.IsPredictionRequested);
            Assert.NotNull(this._telemetryClient.RecordedSuggestion);
        }

        /// <summary>
        /// Verify that the supported commands parameter values are masked.
        /// </summary>
        [Fact]
        public void VerifySupportedCommandMasked()
        {
            var input = "Get-AzVMExtension -ResourceGroupName 'ResourceGroup11' -VMName 'VirtualMachine22'";
            var expected = "Get-AzVMExtension -ResourceGroupName *** -VMName ***";

            this._telemetryClient.RecordedSuggestion = null;
            this._service.IsPredictionRequested = false;

            this._azPredictor.StartEarlyProcessing(new List<string> { input } );

            Assert.True(this._service.IsPredictionRequested);
            Assert.NotNull(this._telemetryClient.RecordedSuggestion);
            Assert.Equal(expected, this._telemetryClient.RecordedSuggestion.HistoryLine);

            input = "Get-AzStorageAccountKey -Name:'ContosoStorage' -ResourceGroupName:'ContosoGroup02'";
            expected = "Get-AzStorageAccountKey -Name:*** -ResourceGroupName:***";


            this._telemetryClient.RecordedSuggestion = null;
            this._service.IsPredictionRequested = false;

            this._azPredictor.StartEarlyProcessing(new List<string> { input } );

            Assert.True(this._service.IsPredictionRequested);
            Assert.NotNull(this._telemetryClient.RecordedSuggestion);
            Assert.Equal(expected, this._telemetryClient.RecordedSuggestion.HistoryLine);
        }

        /// <summary>
        /// Verifies AzPredictor returns the same value as AzPredictorService for the prediction.
        /// </summary>
        [Theory]
        [InlineData("git status")]
        [InlineData("new-azresourcegroup -name hello")]
        [InlineData("Get-AzContext -Name")]
        [InlineData("Get-AzContext -ErrorAction")]
        [InlineData("Get-AzADServicePrincipal -ApplicationObject")]
        public void VerifySuggestion(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var expected = this._service.GetSuggestion(predictionContext.InputAst, 1, CancellationToken.None);
            var actual = this._azPredictor.GetSuggestion(predictionContext, CancellationToken.None);

            Assert.Equal(expected.Select(e => e.Item1), actual.Select(a => a.SuggestionText));
        }
    }
}
