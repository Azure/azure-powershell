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
    /// Test cases for <see cref="CommandLinePredictor" />
    /// </summary>
    [Collection("Model collection")]
    public sealed class CommandLinePredictorTests : IDisposable
    {
        private readonly ModelFixture _fixture;
        private readonly CommandLinePredictor _predictor;
        private readonly AzContext _azContext;
        private MockPowerShellRuntime _powerShellRuntime;

        /// <summary>
        /// Constructs a new instance of <see cref="CommandLinePredictorTests" />
        /// </summary>
        public CommandLinePredictorTests(ModelFixture fixture)
        {
            _fixture = fixture;
            _powerShellRuntime = new MockPowerShellRuntime();
            _azContext = new AzContext(_powerShellRuntime);
            var startHistory = $"{AzPredictorConstants.CommandPlaceholder}{AzPredictorConstants.CommandConcatenator}{AzPredictorConstants.CommandPlaceholder}";
            _predictor = new CommandLinePredictor(_fixture.PredictionCollection[startHistory], null,null,  _azContext);
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
            var predictionContext = PredictionContext.Create("Remove-Item");
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst, _azContext);
            var rawUserInput = predictionContext.InputAst.Extent.Text;
            var presentCommands = new Dictionary<string, int>();

            Action actual = () => this._predictor.GetSuggestion(null,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    1,
                    1,
                    CancellationToken.None);
            Assert.Throws<ArgumentException>(actual);

            actual = () => this._predictor.GetSuggestion(commandName,
                    null,
                    rawUserInput,
                    presentCommands,
                    1,
                    1,
                    CancellationToken.None);
            Assert.Throws<ArgumentNullException>(actual);

            actual = () => this._predictor.GetSuggestion(commandName,
                    inputParameterSet,
                    null,
                    presentCommands,
                    1,
                    1,
                    CancellationToken.None);
            Assert.Throws<ArgumentException>(actual);

            actual = () => this._predictor.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    null,
                    1,
                    1,
                    CancellationToken.None);
            Assert.Throws<ArgumentNullException>(actual);

            actual = () => this._predictor.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    0,
                    1,
                    CancellationToken.None);
            Assert.Throws<ArgumentOutOfRangeException>(actual);

            actual = () => this._predictor.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    1,
                    0,
                    CancellationToken.None);
            Assert.Throws<ArgumentOutOfRangeException>(actual);
        }

        /// <summary>
        /// Tests in the case there is no prediction for the user input or the user input matches exact what we have in the model.
        /// </summary>
        [Theory]
        [InlineData("GET-CHILDITEM")]
        [InlineData("copy-item ")]
        [InlineData(AzPredictorConstants.CommandPlaceholder)]
        [InlineData("Get-LogProperties -Name 'Windows'")]
        public void GetNoPredictionWithCommandName(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst, _azContext);
            var rawUserInput = predictionContext.InputAst.Extent.Text;
            var presentCommands = new Dictionary<string, int>();
            var result = this._predictor.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    1,
                    1,
                    CancellationToken.None);
            Assert.Equal(0, result.Count);
        }

        /// <summary>
        /// Tests in the case when the user inputs only the command name
        /// </summary>
        [Theory]
        [InlineData("Get-LogProperties ")]
        [InlineData("CLEAR-VARIABLE")]
        [InlineData("compare-object")]
        [InlineData("Clear-Con")]
        [InlineData("set-con")]
        public void GetPredictionWithCommandName(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst, _azContext);
            var rawUserInput = predictionContext.InputAst.Extent.Text;
            var presentCommands = new Dictionary<string, int>();
            var result = this._predictor.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    1,
                    1,
                    CancellationToken.None);
            Assert.True(result.Count > 0);
        }

        /// <summary>
        /// Tests in the case when the user inputs the command name and parameters.
        /// </summary>
        [Theory]
        [InlineData("Clear-Variable -Name")]
        [InlineData("CLEAR-CONTENT -PATH ")]
        [InlineData("set-content -path file")]
        [InlineData("set-content file")]
        public void GetPredictionWithCommandNameParameters(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst, _azContext);
            var rawUserInput = predictionContext.InputAst.Extent.Text;
            var presentCommands = new Dictionary<string, int>();
            var result = this._predictor.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    1,
                    1,
                    CancellationToken.None);
            Assert.True(result.Count > 0);
        }

        /// <summary>
        /// Tests in the case when the user inputs the command name and parameters.
        /// </summary>
        [Theory]
        [InlineData("Set-Content -Name hello -Pre")]
        [InlineData("Get-ccontent -path ")] // Doesn't exist
        [InlineData("get-logproperties -NoExistingParam")]
        [InlineData("Set-StorageAccount -WhatIf")]
        [InlineData("git status")]
        [InlineData("Get-AzContext Name")] // a wrong command
        public void GetNoPredictionWithCommandNameParameters(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst, _azContext);
            var rawUserInput = predictionContext.InputAst.Extent.Text;
            var presentCommands = new Dictionary<string, int>();
            var result = this._predictor.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    1,
                    1,
                    CancellationToken.None);
            Assert.Equal(0, result.Count);
        }

        /// <summary>
        /// Verify that the prediction for the command (without parameter) has the right parameters.
        /// </summary>
        [Fact]
        public void VerifyPredictionForCommand()
        {
            var predictionContext = PredictionContext.Create("Set-Content");
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst, _azContext);
            var rawUserInput = predictionContext.InputAst.Extent.Text;
            var presentCommands = new Dictionary<string, int>();
            var result = this._predictor.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    1,
                    1,
                    CancellationToken.None);

            Assert.Equal("Set-Content -Path C:\\Temp\\* -Filter *.txt -Value 'Empty'", result.PredictiveSuggestions.First().SuggestionText);
        }

        /// <summary>
        /// Verify that the prediction for the command with named parameter has the right parameters.
        /// </summary>
        [Fact]
        public void VerifyPredictionForCommandAndNamedParameters()
        {
            var predictionContext = PredictionContext.Create("set-CONTENT -PATH");
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst, _azContext);
            var rawUserInput = predictionContext.InputAst.Extent.Text;
            var presentCommands = new Dictionary<string, int>();
            var result = this._predictor.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    1,
                    1,
                    CancellationToken.None);

            Assert.Equal("Set-Content -Path C:\\Temp\\* -Filter *.txt -Value 'Empty'", result.PredictiveSuggestions.First().SuggestionText);
        }

        /// <summary>
        /// Verify that the prediction for the command with positional parameter has the right parameters.
        /// </summary>
        [Fact]
        public void VerifyPredictionForCommandAndTwoPositionalParameters()
        {
            var predictionContext = PredictionContext.Create("Compare-Object test test"); // Two positional parameters with the same value.
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst, _azContext);
            var rawUserInput = predictionContext.InputAst.Extent.Text;
            var presentCommands = new Dictionary<string, int>();
            var result = this._predictor.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    3,
                    1,
                    CancellationToken.None);

            var expected = new PredictiveSuggestion[]
            {
                new PredictiveSuggestion("Compare-Object test test -IncludeEqual -ExcludeDifferent"),
            };

            Assert.Equal(expected.Select(e => e.SuggestionText), result.PredictiveSuggestions.Select(r => r.SuggestionText));
        }

        /// <summary>
        /// Verify that the prediction for the command with positional parameter has the right parameters.
        /// </summary>
        [Fact]
        public void VerifyPredictionForCommandAndPositionalParameters()
        {
            var predictionContext = PredictionContext.Create("clear-content file");
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst, _azContext);
            var rawUserInput = predictionContext.InputAst.Extent.Text;
            var presentCommands = new Dictionary<string, int>();
            var result = this._predictor.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    3,
                    1,
                    CancellationToken.None);

            var expected = new PredictiveSuggestion[]
            {
                new PredictiveSuggestion("Clear-Content file -Stream Zone.Identifier"),
                new PredictiveSuggestion("Clear-Content file -Filter '*.log' -Force"),
            };

            Assert.Equal(expected.Select(e => e.SuggestionText), result.PredictiveSuggestions.Select(r => r.SuggestionText));
        }
    }
}
