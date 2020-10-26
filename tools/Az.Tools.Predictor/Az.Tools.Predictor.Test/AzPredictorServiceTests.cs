﻿// ----------------------------------------------------------------------------------
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
        private readonly ModelFixture _fixture;
        private readonly AzPredictorService _service;
        private readonly Predictor _suggestionsPredictor;
        private readonly Predictor _commandsPredictor;

        /// <summary>
        /// Constructs a new instance of <see cref="AzPredictorServiceTests"/>
        /// </summary>
        /// <param name="fixture"></param>
        public AzPredictorServiceTests(ModelFixture fixture)
        {
            this._fixture = fixture;
            var startHistory = $"{AzPredictorConstants.CommandPlaceholder}{AzPredictorConstants.CommandConcatenator}{AzPredictorConstants.CommandPlaceholder}";
            this._suggestionsPredictor = new Predictor(this._fixture.PredictionCollection[startHistory], null);
            this._commandsPredictor = new Predictor(this._fixture.CommandCollection, null);

            this._service = new MockAzPredictorService(startHistory, this._fixture.PredictionCollection[startHistory], this._fixture.CommandCollection);
        }


        /// <summary>
        /// Verifies that the prediction comes from the suggestions list, not the command list.
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
        public void VerifyUsingSuggestion(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var expected = this._suggestionsPredictor.Query(predictionContext.InputAst, 1, CancellationToken.None);
            var actual = this._service.GetSuggestion(predictionContext.InputAst, 1, CancellationToken.None);
            Assert.NotEmpty(actual);
            Assert.NotNull(actual.First().Item1);
            Assert.Equal(expected.First(), actual.First().Item1);
            Assert.Equal(PredictionSource.CurrentCommand, actual.First().Item2);
        }

        /// <summary>
        /// Verifies that when no prediction is in the suggestion list, we'll use the command list.
        /// </summary>
        [Theory]
        [InlineData("Get-AzResource -Name hello -Pre")]
        [InlineData("Get-AzADServicePrincipal -ApplicationObject")]
        public void VerifyUsingCommand(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var expected = this._commandsPredictor.Query(predictionContext.InputAst, 1, CancellationToken.None);
            var actual = this._service.GetSuggestion(predictionContext.InputAst, 1, CancellationToken.None);
            Assert.NotEmpty(actual);
            Assert.NotNull(actual.First().Item1);
            Assert.Equal(expected.First(), actual.First().Item1);
            Assert.Equal(PredictionSource.StaticCommands, actual.First().Item2);
        }

        /// <summary>
        /// Verify that no prediction for the user input, meaning it's not in the prediction list or the command list.
        /// </summary>
        [Theory]
        [InlineData(AzPredictorConstants.CommandPlaceholder)]
        [InlineData("git status")]
        [InlineData("Get-ChildItem")]
        [InlineData("new-azresourcegroup -NoExistingParam")]
        [InlineData("get-azaccount ")]
        [InlineData("Get-AzContext Name")]
        [InlineData("NEW-AZCONTEXT")]
        public void VerifyNoPrediction(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var actual = this._service.GetSuggestion(predictionContext.InputAst, 1, CancellationToken.None);
            Assert.Empty(actual);
        }
    }
}
