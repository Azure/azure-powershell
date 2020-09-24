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

using System.Management.Automation.Subsystem;
using System.Threading;
using Xunit;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test
{
    /// <summary>
    /// Test cases for <see cref="Predictor" />
    /// </summary>
    [Collection("Model collection")]
    public class PredictorTests
    {
        private readonly ModelFixture _fixture;
        private readonly Predictor _predictor;

        /// <summary>
        /// Constructs a new instance of <see cref="PredictorTests" />
        /// </summary>
        public PredictorTests(ModelFixture fixture)
        {
            this._fixture = fixture;
            var startHistory = $"{AzPredictorConstants.CommandPlaceholder}{AzPredictorConstants.CommandConcatenator}{AzPredictorConstants.CommandPlaceholder}";
            this._predictor = new Predictor(this._fixture.PredictionCollection[startHistory], null);
        }

        /// <summary>
        /// Tests in the case there is no prediction for the user input or the user input matches exact what we have in the model.
        /// </summary>
        [Theory]
        [InlineData("NEW-AZCONTEXT")]
        [InlineData("Get-AzStorageAccount ")] // A complete command and we have exact the same on in the model.
        [InlineData("get-azaccount ")]
        [InlineData(AzPredictorConstants.CommandPlaceholder)]
        [InlineData("git status")]
        [InlineData("Get-ChildItem")]
        public void GetNullPredictionWithCommandName(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var result = this._predictor.Query(predictionContext.InputAst, CancellationToken.None);
            Assert.Null(result);
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
            var result = this._predictor.Query(predictionContext.InputAst, CancellationToken.None);
            Assert.NotNull(result);
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
            var result = this._predictor.Query(predictionContext.InputAst, CancellationToken.None);
            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests in the case when the user inputs the command name and parameters.
        /// </summary>
        [Theory]
        [InlineData("Get-AzResource -Name hello -Pre")]
        [InlineData("Get-AzADServicePrincipal -ApplicationObject")] // Doesn't exist
        [InlineData("new-azresourcegroup -NoExistingParam")]
        [InlineData("Set-StorageAccount -WhatIf")]
        [InlineData("Get-AzContext Name")] // a wrong command
        public void GetNullPredictionWithCommandNameParameters(string userInput)
        {
            var predictionContext = PredictionContext.Create(userInput);
            var result = this._predictor.Query(predictionContext.InputAst, CancellationToken.None);
            Assert.Null(result);
        }

        /// <summary>
        /// Verify that the prediction for the command (without parameter) has the right parameters.
        /// </summary>
        [Fact]
        public void VerifyPredictionForCommand()
        {
            var predictionContext = PredictionContext.Create("Connect-AzAccount");
            var result = this._predictor.Query(predictionContext.InputAst, CancellationToken.None);

            Assert.Equal("Connect-AzAccount -Credential <PSCredential> -ServicePrincipal -Tenant <>", result);
        }

        /// <summary>
        /// Verify that the prediction for the command (with parameter) has the right parameters.
        /// </summary>
        [Fact]
        public void VerifyPredictionForCommandAndParameters()
        {
            var predictionContext = PredictionContext.Create("GET-AZSTORAGEACCOUNTKEY -NAME");
            var result = this._predictor.Query(predictionContext.InputAst, CancellationToken.None);

            Assert.Equal("Get-AzStorageAccountKey -Name 'ContosoStorage' -ResourceGroupName 'ContosoGroup02'", result);
        }
    }
}
