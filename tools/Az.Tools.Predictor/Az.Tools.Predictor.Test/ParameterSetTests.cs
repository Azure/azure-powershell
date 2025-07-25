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
using System.Management.Automation.Language;
using System.Management.Automation.Subsystem.Prediction;
using Xunit;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test
{
    /// <summary>
    /// Tests for <see cref="ParameterSet"/>. Positional parameter test cases requires the corresponding Az module installed.
    /// </summary>
    public sealed class ParameterSetTests : IDisposable
    {
        private readonly AzContext _azContext;
        private MockPowerShellRuntime _powerShellRuntime;

        /// <summary>
        /// Creates a new instance of <see cref="ParameterSetTests" />.
        /// </summary>
        public ParameterSetTests()
        {
            _powerShellRuntime = new MockPowerShellRuntime();
            _azContext = new AzContext(_powerShellRuntime);
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
        /// Verify that we can get the two named parameters.
        /// </summary>
        [Fact]
        public void VerifyTwoCompleteNamedParameters()
        {
            var predictionContext = PredictionContext.Create("Get-AzResourceGroup -Name test -Location:WestUs2");
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var expected = new List<Parameter>()
            {
                new Parameter("Name", "test", false),
                new Parameter("Location", "WestUs2", false),
            };

            var parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);
        }

        /// <summary>
        /// Verify that we can get the one named parameter.
        /// </summary>
        [Theory]
        [InlineData("new-azresourcegroup -Name test")]
        [InlineData("Get-AzResourceGroup -Name:test")]
        public void VerifyOneCompleteNamedParameters(string inputData)
        {
            var predictionContext = PredictionContext.Create(inputData);
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var expected = new List<Parameter>()
            {
                new Parameter("Name", "test", false),
            };

            var parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);
        }

        /// <summary>
        /// Verify only the command name is used.
        /// </summary>
        [Theory]
        [InlineData("Get-AzStorage")]
        public void VerifyOnlyCommandName(string inputData)
        {
            var predictionContext = PredictionContext.Create(inputData);
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Empty(parameterSet.Parameters);
        }

        /// <summary>
        /// Verify only parameter name is used.
        /// </summary>
        [Fact]
        public void VerifyOnlyParameterName()
        {
            var predictionContext = PredictionContext.Create("Get-AzKeyVault -VaultName");
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var expected = new List<Parameter>()
            {
                new Parameter("VaultName", null, false),
            };

            var parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);
        }

        /// <summary>
        /// Verify that the switch parameter at the end can be parsed.
        /// </summary>
        [Fact]
        public void VerifySwitchParameterAtTheEnd()
        {
            var predictionContext = PredictionContext.Create("Get-AzContext -ListAvailable");
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var expected = new List<Parameter>()
            {
                new Parameter("ListAvailable", null, false),
            };

            var parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);
        }

        /// <summary>
        /// Verify that the switch parameter in the middel can be parsed.
        /// </summary>
        [Fact]
        public void VerifySwitchParameterInMiddle()
        {
            var predictionContext = PredictionContext.Create("Get-AzContext -ListAvailable -DefaultProfile:$Profile");
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var expected = new List<Parameter>()
            {
                new Parameter("ListAvailable", null, false),
                new Parameter("DefaultProfile", "$Profile", false),
            };

            var parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);
        }

        /// <summary>
        /// Verify that a special placeholder parameter is added.
        /// </summary>
        [Theory]
        [InlineData("Get-AzStorage -")]
        public void VerifyIncompleteParameterAfterCommandName(string inputData)
        {
            var predictionContext = PredictionContext.Create(inputData);
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var parameterSet = new ParameterSet(commandAst, _azContext);
            var expected = new List<Parameter>()
            {
                new Parameter(AzPredictorConstants.DashParameterName, null, false),
            };
            Assert.Equal(expected, parameterSet.Parameters);
        }

        /// <summary>
        /// Verify that the incomplete parameter is ignored.
        /// </summary>
        [Theory]
        [InlineData("Get-LogProperties -Name:name -", false)]
        [InlineData("Get-LogProperties -Name name -", false)]
        [InlineData("Get-LogProperties name -", true)]
        public void VerifyIncompleteParameterAtTheEnd(string inputData, bool isPositional)
        {
            var predictionContext = PredictionContext.Create(inputData);
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var expected = new List<Parameter>()
            {
                new Parameter("Name", "name", isPositional),
                new Parameter(AzPredictorConstants.DashParameterName, null, false),
            };

            var parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);
        }

        /// <summary>
        /// Verify that the incomplete parameter in the middel is an error.
        /// </summary>
        [Theory]
        [InlineData("Get-AzResourceGroup - -Name Test")]
        [InlineData("Get-AzResourceGroup - Test")]
        public void VerifyIncompleteParameterInMiddel(string inputData)
        {
            var predictionContext = PredictionContext.Create(inputData);
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();

            Assert.Throws<CommandLineException>(() => new ParameterSet(commandAst, _azContext));
        }

        /// <summary>
        /// Verify that we can parse the - in the parameter value.
        /// </summary>
        [Fact]
        public void VerifyMinusInParameterValue()
        {
            var inputData = "Set-Date -Adjust -0:10:0 -DisplayHint Time";
            var predictionContext = PredictionContext.Create(inputData);
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var expected = new List<Parameter>()
            {
                new Parameter("Adjust", "-0:10:0", false),
                new Parameter("DisplayHint", "Time", false),
            };

            var parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);
        }

        /// <summary>
        /// Verify that the one positional parameter can be parsed.
        /// </summary>
        [Fact]
        public void VerifyOnlyOnePositionalParameter()
        {
            var predictionContext = PredictionContext.Create("Get-LogProperties name");
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var expected = new List<Parameter>()
            {
                new Parameter("Name", "name", true),
            };

            var parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);
        }

        /// <summary>
        /// Verify that the two poitional parameters can be parsed.
        /// </summary>
        [Fact]
        public void VerifyTwoPositionalParameters()
        {
            var predictionContext = PredictionContext.Create("Set-Content test.txt abc");
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var expected = new List<Parameter>()
            {
                new Parameter("Path", "test.txt", true),
                new Parameter("Value", "abc", true),
            };

            var parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);
        }

        /// <summary>
        /// Verify that we throw the exception when thre are excess positioinal parameters.
        /// </summary>
        [Fact]
        public void VerifyExcessPositionalParameters()
        {
            //var predictionContext = PredictionContext.Create("Get-AzResourceGroup Name Location Test");
            var predictionContext = PredictionContext.Create("Get-LogProperties name test");
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            Assert.Throws<CommandLineException>(() => new ParameterSet(commandAst, _azContext));
        }

        /// <summary>
        /// Verify that a positioinal parameter is followed by a switch parameter.
        /// </summary>
        [Fact]
        public void VerifyPositionalParametersFollowedBySwitchParameters()
        {

            var predictionContext = PredictionContext.Create(@"Clear-Content C:\*.log -Force");
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var expected = new List<Parameter>()
            {
                new Parameter("Path", @"C:\*.log", true),
                new Parameter("Force", null, false),
            };

            var parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);
        }

        /// <summary>
        /// Verify that positional parameters are followed by named parameters.
        /// </summary>
        [Fact]
        public void VerifyPositionalParametersFollowedByNamedParameters()
        {
            var predictionContext = PredictionContext.Create(@"Get-Content C:\Copy-Script.ps1 -Stream Zone.Identifier");
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var expected = new List<Parameter>()
            {
                new Parameter("Path", @"C:\Copy-Script.ps1", true),
                new Parameter("Stream", "Zone.Identifier", false),
            };

            var parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);
        }

        /// <summary>
        /// Verify that we throw the exception when the positional paramters are after th named ones.
        /// </summary>
        [Fact]
        public void VerifyPositionalParametersAfterNamedParameters()
        {
            var predictionContext = PredictionContext.Create("Get-AzResourceGroup -Name Test Location");
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            Assert.Throws<CommandLineException>(() =>  new ParameterSet(commandAst, _azContext));
        }

        /// <summary>
        /// Verify that we can parse the @ in the parameter names/values.
        /// </summary>
        [Fact]
        public void VerifyParameterValuesWithAtSymbol()
        {
            // We should be able to parse the @ symbol when it's used as the parameter value.
            var inputData = "New-AzWebApp -Location westus -ResourceGroupName webappGroup -Name webappname -AppServicePlan appServicePlan -Force -Tag @{ Name1 = \"value\"; Name2 = \"Value2\" }";
            var predictionContext = PredictionContext.Create(inputData);
            var commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            var expected = new List<Parameter>()
            {
                new Parameter("Location", "westus", false),
                new Parameter("ResourceGroupName", "webappGroup", false),
                new Parameter("Name", "webappname", false),
                new Parameter("AppServicePlan", "appServicePlan", false),
                new Parameter("Force", null, false),
                new Parameter("Tag", "@{ Name1 = \"value\"; Name2 = \"Value2\" }", false),
            };

            var parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);

            // We should be able to parse the @ symbol when it's used as the parameter value.
            inputData = "Invoke-AzMLWorkspaceDiagnose -ResourceGroupName ml-rg-test -Name mlworkspace-cli01 -ApplicationInsightId @{'key1'=\"/subscriptions/xxxx-xxxxx-xxxxxxxxx-xxxx/resourceGroups/ml-rg-test/providers/Microsoft.insights/components/xxxxxxxxxxx\"}";
            predictionContext = PredictionContext.Create(inputData);
            commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            expected = new List<Parameter>()
            {
                new Parameter("ResourceGroupName", "ml-rg-test", false),
                new Parameter("Name", "mlworkspace-cli01", false),
                new Parameter("ApplicationInsightId", "@{'key1'=\"/subscriptions/xxxx-xxxxx-xxxxxxxxx-xxxx/resourceGroups/ml-rg-test/providers/Microsoft.insights/components/xxxxxxxxxxx\"}", false),
            };

            parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);

            inputData = "New-AzActivityLogAlertActionGroupObject -Id $ActionGroupResourceId -WebhookProperty @{\"sampleWebhookProperty\"=\"SamplePropertyValue\"}";
            predictionContext = PredictionContext.Create(inputData);
            commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            expected = new List<Parameter>()
            {
                new Parameter("Id", "$ActionGroupResourceId", false),
                new Parameter("WebhookProperty", "@{\"sampleWebhookProperty\"=\"SamplePropertyValue\"}", false),
            };

            parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);

            inputData = "New-AzAutoscaleWebhookNotificationObject -Property @{} -ServiceUri \"http://myservice.com\"";
            predictionContext = PredictionContext.Create(inputData);
            commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            expected = new List<Parameter>()
            {
                new Parameter("Property", "@{}", false),
                new Parameter("ServiceUri", "\"http://myservice.com\"", false),
            };

            parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);

            inputData = "New-AzCommunicationServiceKey -CommunicationServiceName ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -Parameter @{KeyType=\"Primary\"}";
            predictionContext = PredictionContext.Create(inputData);
            commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            expected = new List<Parameter>()
            {
                new Parameter("CommunicationServiceName", "ContosoAcsResource1", false),
                new Parameter("ResourceGroupName", "ContosoResourceProvider1", false),
                new Parameter("Parameter", "@{KeyType=\"Primary\"}", false),
            };

            parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);

            parameterSet = new ParameterSet(commandAst, _azContext);
            Assert.Equal(expected, parameterSet.Parameters);

            // When @ is used to indicate the variable for the parameter name/value pair, we throw the exception since we
            // don't want to provide that as the suggestion.
            inputData = "New-ScriptFileInfo @newScriptInfo";
            predictionContext = PredictionContext.Create(inputData);
            commandAst = predictionContext.RelatedAsts.OfType<CommandAst>().LastOrDefault();
            Assert.Throws<CommandLineException>(() => new ParameterSet(commandAst, _azContext));
        }
    }
}
