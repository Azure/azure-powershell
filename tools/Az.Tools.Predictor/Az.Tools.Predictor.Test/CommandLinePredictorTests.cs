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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;
using System.Management.Automation.Subsystem;
using System.Threading;
using Xunit;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test
{
    /// <summary>
    /// Test cases for <see cref="CommandLinePredictor" />
    /// </summary>
    [Collection("Model collection")]
    public class CommandLinePredictorTests
    {
        private readonly ModelFixture _fixture;
        private readonly CommandLinePredictor _predictor;

        /// <summary>
        /// Constructs a new instance of <see cref="CommandLinePredictorTests" />
        /// </summary>
        public CommandLinePredictorTests(ModelFixture fixture)
        {
            this._fixture = fixture;
            var startHistory = $"{AzPredictorConstants.CommandPlaceholder}{AzPredictorConstants.CommandConcatenator}{AzPredictorConstants.CommandPlaceholder}";
            this._predictor = new CommandLinePredictor(this._fixture.PredictionCollection[startHistory], null);
        }

        /// <summary>
        /// Verify the method checks parameter values.
        /// </summary>
        [Fact]
        public void VerifyParameterValues()
        {
            var predictionContext = PredictionContext.Create("Get-AzContext");
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst);
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
        [InlineData("NEW-AZCONTEXT")]
        [InlineData("get-azaccount ")]
        [InlineData(AzPredictorConstants.CommandPlaceholder)]
        [InlineData("Get-ChildItem")]
        public void GetNoPredictionWithCommandName(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst);
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
        /// Tests in the case there are no az commands in the history.
        /// </summary>
        [Theory]
        [InlineData("New-AzKeyVault ")]
        [InlineData("CONNECT-AZACCOUNT")]
        [InlineData("set-azstorageaccount ")]
        [InlineData("Get-AzResourceG")]
        [InlineData("Get-AzStorageAcco")] // an imcomplete command and there is a record "Get-AzStorageAccount" in the model.
        public void GetPredictionWithCommandName(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst);
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
        [InlineData("Get-AzKeyVault -VaultName")]
        [InlineData("GET-AZSTORAGEACCOUNTKEY -NAME ")]
        [InlineData("new-azresourcegroup -name hello")]
        [InlineData("Get-AzContext -Name")]
        public void GetPredictionWithCommandNameParameters(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst);
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
        [InlineData("Get-AzResource -Name hello -Pre")]
        [InlineData("Get-AzADServicePrincipal -ApplicationObject")] // Doesn't exist
        [InlineData("new-azresourcegroup -NoExistingParam")]
        [InlineData("Set-StorageAccount -WhatIf")]
        // Enable "git status" and "Get-AzContext Name" when ParameterSet can parse this format of command
        // [InlineData("git status")]
        // [InlineData("Get-AzContext Name")] // a wrong command
        public void GetNoPredictionWithCommandNameParameters(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst);
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
            var predictionContext = PredictionContext.Create("Connect-AzAccount");
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst);
            var rawUserInput = predictionContext.InputAst.Extent.Text;
            var presentCommands = new Dictionary<string, int>();
            var result = this._predictor.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    1,
                    1,
                    CancellationToken.None);

            Assert.Equal("Connect-AzAccount -Credential <PSCredential> -ServicePrincipal -Tenant <>", result.PredictiveSuggestions.First().SuggestionText);
        }

        /// <summary>
        /// Verify that the prediction for the command (with parameter) has the right parameters.
        /// </summary>
        [Fact]
        public void VerifyPredictionForCommandAndParameters()
        {
            var predictionContext = PredictionContext.Create("GET-AZSTORAGEACCOUNTKEY -NAME");
            var commandAst = predictionContext.InputAst.FindAll(p => p is CommandAst, true).LastOrDefault() as CommandAst;
            var commandName = (commandAst?.CommandElements?.FirstOrDefault() as StringConstantExpressionAst)?.Value;
            var inputParameterSet = new ParameterSet(commandAst);
            var rawUserInput = predictionContext.InputAst.Extent.Text;
            var presentCommands = new Dictionary<string, int>();
            var result = this._predictor.GetSuggestion(commandName,
                    inputParameterSet,
                    rawUserInput,
                    presentCommands,
                    1,
                    1,
                    CancellationToken.None);

            Assert.Equal("Get-AzStorageAccountKey -Name 'ContosoStorage' -ResourceGroupName 'ContosoGroup02'", result.PredictiveSuggestions.First().SuggestionText);
        }
    }
}
