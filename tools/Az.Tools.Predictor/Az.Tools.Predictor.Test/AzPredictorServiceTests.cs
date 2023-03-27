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
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;
using System.Management.Automation.Subsystem.Prediction;
using System.Threading;
using Xunit;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test
{
    /// <summary>
    /// Tests for <see cref="AzPredictorService"/>
    /// </summary>
    [Collection("Model collection")]
    public sealed class AzPredictorServiceTests : IDisposable
    {
        private class PredictiveSuggestionComparer : EqualityComparer<PredictiveSuggestion>
        {
            public override bool Equals(PredictiveSuggestion first, PredictiveSuggestion second)
            {
                if ((first is null) && (second is null))
                {
                    return true;
                }
                else if ((first is null) || (second is null))
                {
                    return false;
                }

                return string.Equals(first.SuggestionText, second.SuggestionText, StringComparison.Ordinal);
            }

            public override int GetHashCode(PredictiveSuggestion suggestion)
            {
                return suggestion.SuggestionText.GetHashCode();
            }
        }

        private readonly ModelFixture _fixture;
        private readonly AzPredictorService _service;
        private readonly CommandLinePredictor _commandBasedPredictor;
        private readonly CommandLinePredictor _fallbackPredictor;

        private readonly AzPredictorService _noFallbackPredictorService;
        private readonly AzPredictorService _noCommandBasedPredictorService;
        private readonly AzPredictorService _noPredictorService;
        private readonly AzContext _azContext;

        private MockPowerShellRuntime _powerShellRuntime;

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictorServiceTests"/>
        /// </summary>
        /// <param name="fixture"></param>
        public AzPredictorServiceTests(ModelFixture fixture)
        {
            this._fixture = fixture;
            _powerShellRuntime = new MockPowerShellRuntime();
            _azContext = new AzContext(_powerShellRuntime);
            var startHistory = $"{AzPredictorConstants.CommandPlaceholder}{AzPredictorConstants.CommandConcatenator}{AzPredictorConstants.CommandPlaceholder}";
            this._commandBasedPredictor = new CommandLinePredictor(this._fixture.PredictionCollection[startHistory], null, null, _azContext);
            this._fallbackPredictor = new CommandLinePredictor(this._fixture.CommandCollection, null, null, _azContext);

            this._service = new MockAzPredictorService(startHistory, this._fixture.PredictionCollection[startHistory], this._fixture.CommandCollection, _azContext);

            this._noFallbackPredictorService = new MockAzPredictorService(startHistory, this._fixture.PredictionCollection[startHistory], null, _azContext);
            this._noCommandBasedPredictorService = new MockAzPredictorService(null, null, this._fixture.CommandCollection, _azContext);
            this._noPredictorService = new MockAzPredictorService(null, null, null, null);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_powerShellRuntime is not null)
            {
                _powerShellRuntime.Dispose();
                _powerShellRuntime = null;
            }
        }

        /// <summary>
        /// Verify the method checks parameter values.
        /// </summary>
        [Fact]
        public void VerifyParameterValues()
        {
            var predictionContext = PredictionContext.Create("Set-Content");

            Action actual = () => this._service.GetSuggestion(null, 1, 1, CancellationToken.None);
            Assert.Throws<ArgumentNullException>(actual);

            actual = () => this._service.GetSuggestion(predictionContext, 0, 1, CancellationToken.None);
            Assert.Throws<ArgumentOutOfRangeException>(actual);

            actual = () => this._service.GetSuggestion(predictionContext, 1, 0, CancellationToken.None);
            Assert.Throws<ArgumentOutOfRangeException>(actual);
        }

        /// <summary>
        /// Verifies that the prediction comes from the command based list, not the fallback list.
        /// </summary>
        [Theory]
        [InlineData("SET-CONTENT")]
        [InlineData("get-logproperties ")]
        [InlineData("Clear-C")]
        [InlineData("compare-")]
        [InlineData("Clear-Variable -Name")]
        [InlineData("CLEAR-CONTENT -PATH test")]
        [InlineData("Clear-content -path test")]
        [InlineData("clear-content ./Test.log")]
        public void VerifyUsingCommandBasedPredictor(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var commandName = commandAst?.GetCommandName();
            var inputParameterSet = new ParameterSet(commandAst, _azContext);
            var rawUserInput = predictionContext.InputAst.Extent.Text;
            var presentCommands = new Dictionary<string, int>();
            var expected = this._commandBasedPredictor.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    1,
                    1,
                    CancellationToken.None);

            var actual = this._service.GetSuggestion(predictionContext, 1, 1, CancellationToken.None);
            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.NotNull(actual.PredictiveSuggestions.First());
            Assert.NotNull(actual.PredictiveSuggestions.First().SuggestionText);
            Assert.Equal(expected.Count, actual.Count);
            Assert.Equal<PredictiveSuggestion>(expected.PredictiveSuggestions, actual.PredictiveSuggestions, new PredictiveSuggestionComparer());
            Assert.Equal<string>(expected.SourceTexts, actual.SourceTexts);
            Assert.All<SuggestionSource>(actual.SuggestionSources, (source) => Assert.Equal(SuggestionSource.CurrentCommand, source));

            actual = this._noFallbackPredictorService.GetSuggestion(predictionContext, 1, 1, CancellationToken.None);
            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.NotNull(actual.PredictiveSuggestions.First());
            Assert.NotNull(actual.PredictiveSuggestions.First().SuggestionText);
            Assert.Equal(expected.Count, actual.Count);
            Assert.Equal<PredictiveSuggestion>(expected.PredictiveSuggestions, actual.PredictiveSuggestions, new PredictiveSuggestionComparer());
            Assert.Equal<string>(expected.SourceTexts, actual.SourceTexts);
            Assert.All<SuggestionSource>(actual.SuggestionSources, (source) => Assert.Equal(SuggestionSource.CurrentCommand, source));
        }

        /// <summary>
        /// Verifies that when no prediction is in the command based list, we'll use the fallback list.
        /// </summary>
        [Theory]
        [InlineData("Set-Variable -Name desc -Value ")]
        [InlineData("remove-ite")]
        public void VerifyUsingFallbackPredictor(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst, _azContext);
            var rawUserInput = predictionContext.InputAst.Extent.Text;
            var presentCommands = new Dictionary<string, int>();
            var expected = this._fallbackPredictor.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    1,
                    1,
                    CancellationToken.None);

            var actual = this._service.GetSuggestion(predictionContext, 1, 1, CancellationToken.None);
            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.NotNull(actual.PredictiveSuggestions.First());
            Assert.NotNull(actual.PredictiveSuggestions.First().SuggestionText);
            Assert.Equal(expected.Count, actual.Count);
            Assert.Equal<PredictiveSuggestion>(expected.PredictiveSuggestions, actual.PredictiveSuggestions, new PredictiveSuggestionComparer());
            Assert.Equal<string>(expected.SourceTexts, actual.SourceTexts);
            Assert.All<SuggestionSource>(actual.SuggestionSources, (source) => Assert.Equal(SuggestionSource.StaticCommands, source));

            actual = this._noCommandBasedPredictorService.GetSuggestion(predictionContext, 1, 1, CancellationToken.None);
            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.NotNull(actual.PredictiveSuggestions.First());
            Assert.NotNull(actual.PredictiveSuggestions.First().SuggestionText);
            Assert.Equal(expected.Count, actual.Count);
            Assert.Equal<PredictiveSuggestion>(expected.PredictiveSuggestions, actual.PredictiveSuggestions, new PredictiveSuggestionComparer());
            Assert.Equal<string>(expected.SourceTexts, actual.SourceTexts);
            Assert.All<SuggestionSource>(actual.SuggestionSources, (source) => Assert.Equal(SuggestionSource.StaticCommands, source));
        }

        /// <summary>
        /// Verify that no prediction for the user input, meaning it's not in the command based list or the fallback list.
        /// </summary>
        [Theory]
        [InlineData(AzPredictorConstants.CommandPlaceholder)]
        [InlineData("Get-Help")]
        [InlineData("Get-ChildItem")]
        [InlineData("Remove-Item -NoExistingParam")]
        [InlineData("get-childitem ")]
        [InlineData("NEW-CHILDITEM ")]
        [InlineData("git status")]
        [InlineData("get-item name")]
        public void VerifyNoPrediction(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var actual = this._service.GetSuggestion(predictionContext, 1, 1, CancellationToken.None);
            Assert.Equal(0, actual.Count);

            actual = this._noFallbackPredictorService.GetSuggestion(predictionContext, 1, 1, CancellationToken.None);
            Assert.Equal(0, actual.Count);

            actual = this._noCommandBasedPredictorService.GetSuggestion(predictionContext, 1, 1, CancellationToken.None);
            Assert.Equal(0, actual.Count);

            actual = this._noPredictorService.GetSuggestion(predictionContext, 1, 1, CancellationToken.None);
            Assert.Empty(actual.PredictiveSuggestions);
        }

        /// <summary>
        /// Verify that it returns null when we cannot parse the user input.
        /// </summary>
        [Theory]
        [InlineData("Remove-Item -Name A $Location")]
        public void VerifyFailToParseUserInput(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            Assert.Throws<CommandLineException>(() => _service.GetSuggestion(predictionContext, 1, 1, CancellationToken.None));
        }
    }
}
