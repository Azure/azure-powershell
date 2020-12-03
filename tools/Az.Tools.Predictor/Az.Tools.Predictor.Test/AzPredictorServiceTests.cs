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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Subsystem;
using System.Threading;
using Xunit;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test
{
    /// <summary>
    /// Tests for <see cref="AzPredictorService"/>
    /// </summary>
    [Collection("Model collection")]
    public class AzPredictorServiceTests
    {
        private class PredictiveSuggestionComparer : EqualityComparer<PredictiveSuggestion>
        {
            public override bool Equals(PredictiveSuggestion first, PredictiveSuggestion second)
            {
                if ((first == null) && (second == null))
                {
                    return true;
                }
                else if ((first == null) || (second == null))
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

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictorServiceTests"/>
        /// </summary>
        /// <param name="fixture"></param>
        public AzPredictorServiceTests(ModelFixture fixture)
        {
            this._fixture = fixture;
            var startHistory = $"{AzPredictorConstants.CommandPlaceholder}{AzPredictorConstants.CommandConcatenator}{AzPredictorConstants.CommandPlaceholder}";
            this._commandBasedPredictor = new CommandLinePredictor(this._fixture.PredictionCollection[startHistory], null);
            this._fallbackPredictor = new CommandLinePredictor(this._fixture.CommandCollection, null);

            this._service = new MockAzPredictorService(startHistory, this._fixture.PredictionCollection[startHistory], this._fixture.CommandCollection);

            this._noFallbackPredictorService = new MockAzPredictorService(startHistory, this._fixture.PredictionCollection[startHistory], null);
            this._noCommandBasedPredictorService = new MockAzPredictorService(null, null, this._fixture.CommandCollection);
            this._noPredictorService = new MockAzPredictorService(null, null, null);
        }

        /// <summary>
        /// Verify the method checks parameter values.
        /// </summary>
        [Fact]
        public void VerifyParameterValues()
        {
            var predictionContext = PredictionContext.Create("Get-AzContext");

            Action actual = () => this._service.GetSuggestion(null, 1, 1, CancellationToken.None);
            Assert.Throws<ArgumentNullException>(actual);

            actual = () => this._service.GetSuggestion(predictionContext.InputAst, 0, 1, CancellationToken.None);
            Assert.Throws<ArgumentOutOfRangeException>(actual);

            actual = () => this._service.GetSuggestion(predictionContext.InputAst, 1, 0, CancellationToken.None);
            Assert.Throws<ArgumentOutOfRangeException>(actual);
        }

        /// <summary>
        /// Verifies that the prediction comes from the command based list, not the fallback list.
        /// </summary>
        [Theory]
        [InlineData("CONNECT-AZACCOUNT")]
        [InlineData("set-azstorageaccount ")]
        [InlineData("Get-AzResourceG")]
        [InlineData("Get-AzStorageAcco")]
        [InlineData("Get-AzKeyVault -VaultName")]
        [InlineData("GET-AZSTORAGEACCOUNTKEY -NAME ")]
        [InlineData("new-azresourcegroup -name hello")]
        [InlineData("Get-AzContext -Name")]
        [InlineData("Get-AzContext -ErrorAction")]
        public void VerifyUsingCommandBasedPredictor(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var presentCommands = new System.Collections.Generic.Dictionary<string, int>();
            var expected = this._commandBasedPredictor.GetSuggestion(predictionContext.InputAst, presentCommands, 1, 1, CancellationToken.None);
            var actual = this._service.GetSuggestion(predictionContext.InputAst, 1, 1, CancellationToken.None);
            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.NotNull(actual.PredictiveSuggestions.First());
            Assert.NotNull(actual.PredictiveSuggestions.First().SuggestionText);
            Assert.Equal(expected.Count, actual.Count);
            Assert.Equal<PredictiveSuggestion>(expected.PredictiveSuggestions, actual.PredictiveSuggestions, new PredictiveSuggestionComparer());
            Assert.Equal<string>(expected.SourceTexts, actual.SourceTexts);
            Assert.All<SuggestionSource>(actual.SuggestionSources, (source) => Assert.Equal(SuggestionSource.CurrentCommand, source));

            actual = this._noFallbackPredictorService.GetSuggestion(predictionContext.InputAst, 1, 1, CancellationToken.None);
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
        [InlineData("Get-AzResource -Name hello -Pre")]
        [InlineData("Get-AzADServicePrincipal -ApplicationObject")]
        public void VerifyUsingFallbackPredictor(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var presentCommands = new System.Collections.Generic.Dictionary<string, int>();
            var expected = this._fallbackPredictor.GetSuggestion(predictionContext.InputAst, presentCommands, 1, 1, CancellationToken.None);
            var actual = this._service.GetSuggestion(predictionContext.InputAst, 1, 1, CancellationToken.None);
            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.NotNull(actual.PredictiveSuggestions.First());
            Assert.NotNull(actual.PredictiveSuggestions.First().SuggestionText);
            Assert.Equal(expected.Count, actual.Count);
            Assert.Equal<PredictiveSuggestion>(expected.PredictiveSuggestions, actual.PredictiveSuggestions, new PredictiveSuggestionComparer());
            Assert.Equal<string>(expected.SourceTexts, actual.SourceTexts);
            Assert.All<SuggestionSource>(actual.SuggestionSources, (source) => Assert.Equal(SuggestionSource.StaticCommands, source));

            actual = this._noCommandBasedPredictorService.GetSuggestion(predictionContext.InputAst, 1, 1, CancellationToken.None);
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
        [InlineData("Get-ChildItem")]
        [InlineData("new-azresourcegroup -NoExistingParam")]
        [InlineData("get-azaccount ")]
        [InlineData("NEW-AZCONTEXT")]
        public void VerifyNoPrediction(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var actual = this._service.GetSuggestion(predictionContext.InputAst, 1, 1, CancellationToken.None);
            Assert.Equal(0, actual.Count);

            actual = this._noFallbackPredictorService.GetSuggestion(predictionContext.InputAst, 1, 1, CancellationToken.None);
            Assert.Equal(0, actual.Count);

            actual = this._noCommandBasedPredictorService.GetSuggestion(predictionContext.InputAst, 1, 1, CancellationToken.None);
            Assert.Equal(0, actual.Count);

            actual = this._noPredictorService.GetSuggestion(predictionContext.InputAst, 1, 1, CancellationToken.None);
            Assert.Null(actual);
        }

        /// <summary>
        /// Verify when we cannot parse the user input correctly.
        /// </summary>
        /// <remarks>
        /// When we can parse them correctly, please move the InlineData to the corresponding test methods, for example, "git status"
        /// doesn't have any prediction so it should move to <see cref="VerifyNoPrediction"/>.
        /// </remarks>
        [Theory]
        [InlineData("git status")]
        [InlineData("Get-AzContext Name")]
        public void VerifyMalFormattedCommandLine(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            Action actual = () => this._service.GetSuggestion(predictionContext.InputAst, 1, 1, CancellationToken.None);
            _ = Assert.Throws<InvalidOperationException>(actual);
        }
    }
}
