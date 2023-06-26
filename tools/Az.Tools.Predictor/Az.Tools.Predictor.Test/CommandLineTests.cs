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

using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities;
using System.Linq;
using System.Management.Automation.Language;
using Xunit;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test
{
    /// <summary>
    /// Tests command line parsing.
    /// </summary>
    public sealed class CommandLineTests
    {
        /// <summary>
        /// Verify that we escape th texts.
        /// </summary>
        [Theory]
        [InlineData("'<String[]>'", "<String[]>")]
        [InlineData("http://www.microsoft.com", "http://www.microsoft.com")]
        [InlineData("/subscription/[[subId]]", "/subscription/{subId}")]
        public void VerifyEscapingText(string expected, string input)
        {
            var actual = CommandLineUtilities.EscapePredictionText(input);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Verify that we unescape the texts.
        /// </summary>
        [Theory]
        [InlineData("{String[]}", "'<String[]>'")]
        [InlineData("http://www.microsoft.com", "http://www.microsoft.com")]
        [InlineData("/subscription/{subId}", "/subscription/[[subId]]")]
        public void VerifyUnescapingText(string expected, string input)
        {
            var actual = CommandLineUtilities.UnescapePredictionText(input);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Verify tht we mask the command line parameter values.
        /// </summary>
        [Theory]
        [InlineData("Get-AzContext -ListAvailable ***", "Get-AzContext -ListAvailable")]
        // Reorder the parameter list
        [InlineData("Get-AzResourceGroup -Location:*** -Name ***", "Get-AzResourceGroup -Name Test -Location:WestUS2")]
        // skip the positional parameter
        [InlineData("Get-AzResourceGroup -Location:***", "Get-AzResourceGroup Test -Location:WestUS2")]
        [InlineData("Get-AzResourceGroup", "Get-AzResourceGroup Test WestUS2")]
        // Take the last command in a pipe
        [InlineData("Set-AzContext", "$context | Set-AzContext")]
        // Take the command at the right of assignment
        [InlineData("Get-AzRoleAssignment -ObjectId ***", "$a=Get-AzRoleAssignment -ObjectId xxx")]
        // Take the command inside parentheses
        [InlineData("Get-AzRoleAssignment -ObjectId ***", "Remove-AzRoleAssignment -RoleDefinitionId (Get-AzRoleAssignment -ObjectId xxx")]
        [InlineData("git", "git status")]
        [InlineData("customCommand -Parameter ***", "customCommand -Parameter Value")]
        [InlineData("customCommand", "customCommand /Parameter Value")]
        [InlineData("customCommand", "customCommand --Parameter Value")]
        public void VerifyMaskCommandLine(string expected, string input)
        {
            string maskedCommandLine = CommandLineUtilities.MaskCommandLine(input);

            Assert.Equal(expected, maskedCommandLine);
        }

        /// <summary>
        /// Verify that GetCommandAst return the right command ast.
        /// </summary>
        [Theory]
        [InlineData("Set-AzContext -Subscription 'xxxx-xxxx-xxxx-xxxx' -Tenant <String>", null)]
        [InlineData("Set-AzContext -Subscription 'xxxx-xxxx-xxxx-xxxx' -Tenant {String}", null)]
        [InlineData("Set-AzContext -Subscription $subscription -Tenant [[String]]", null)]
        [InlineData("Set-AzContext -Subscription 'xxxx-xxxx-xxxx-xxxx' -Tenant TenantName", null)]
        [InlineData("Get-AzContext | Set-AzContext", "Set-AzContext")]
        public void VerifyGetCommandAst(string input, string expected)
        {
            if (expected == null)
            {
                expected = input;
            }

            var commandAst = CommandLineUtilities.GetCommandAst(input);
            Assert.Equal(expected, commandAst.ToString());
        }
    }
}
