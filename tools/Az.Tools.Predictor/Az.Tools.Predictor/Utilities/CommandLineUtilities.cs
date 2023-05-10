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

using System.Linq;
using System.Management.Automation.Language;
using System.Text;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities
{
    /// <summary>
    /// A utility class for Az command line.
    /// </summary>
    internal static class CommandLineUtilities
    {
        /// <summary>
        /// Gets the CommandAst for the whole command line.
        /// </summary>
        /// <param name="commandLine">The command line to get the CommandAst.</param>
        /// <returns>The CommandAst.</returns>
        /// <remarks>This parses the command line and returns the last one it encounters. The reason to choose the last one is because <see cref="AzPredictorService.GetSuggestion" /> returns suggestions to the last one too.
        /// It doesn't work well in a complex command line, for example: <c>Get-AzContext | Set-AzContext</c> will return <c>Set-AzContext</c>.</remarks>
        public static CommandAst GetCommandAst(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine))
            {
                return null;
            }

            Ast ast = Parser.ParseInput(commandLine, out _, out _);
            return CommandLineUtilities.GetCommandAst(ast);
        }

        /// <summary>
        /// Gets the CommandAst for the ast for the raw command line.
        /// </summary>
        /// <param name="ast">The original ast to get the CommandAst.</param>
        /// <returns>The CommandAst.</returns>
        public static CommandAst GetCommandAst(Ast ast)
        {
            if (ast is null)
            {
                return null;
            }

            var commandAst = ast.FindAll((ast) => ast is CommandAst, searchNestedScriptBlocks: false).LastOrDefault() as CommandAst;
            return commandAst;
        }

        /// <summary>
        /// Masks the user input of any data, like names and locations.
        /// Also alphabetizes the parameters to normalize them before sending
        /// them to the model.
        /// e.g., Get-AzContext -Name Hello -Location 'EastUS' => Get-AzContext -Location *** -Name ***
        /// </summary>
        /// <param name="commandLine">The command line to mask.</param>
        public static string MaskCommandLine(string commandLine)
        {
            var commandAst = CommandLineUtilities.GetCommandAst(commandLine);

            return CommandLineUtilities.MaskCommandLine(commandAst);
        }

        /// <summary>
        /// Masks the user input of any data, like names and locations.
        /// Also alphabetizes the parameters to normalize them before sending
        /// them to the model.
        /// e.g., Get-AzContext -Name Hello -Location 'EastUS' => Get-AzContext -Location *** -Name ***
        /// </summary>
        /// <param name="commandAst">The command to mask.</param>
        public static string MaskCommandLine(CommandAst commandAst)
        {
            var commandElements = commandAst?.CommandElements;

            if (commandElements == null)
            {
                return null;
            }

            if (commandElements.Count == 1)
            {
                return commandAst.Extent.Text;
            }

            var sb = new StringBuilder(commandAst.Extent.Text.Length);
            _ = sb.Append(commandElements[0].ToString());
            var parameters = commandElements
                .Skip(1)
                .Where(element => element is CommandParameterAst)
                .Cast<CommandParameterAst>()
                .OrderBy(ast => ast.ParameterName);

            foreach (CommandParameterAst param in parameters)
            {
                _ = sb.Append(AzPredictorConstants.CommandParameterSeperator);
                if (param.Argument != null)
                {
                    // Parameter is in the form of `-Name:value`
                    _ = sb.Append(AzPredictorConstants.ParameterIndicator)
                        .Append(param.ParameterName)
                        .Append(AzPredictorConstants.ParameterValueSeperator)
                        .Append(AzPredictorConstants.ParameterValueMask);
                }
                else
                {
                    // Parameter is in the form of `-Name value`
                    _ = sb.Append(AzPredictorConstants.ParameterIndicator)
                        .Append(param.ParameterName)
                        .Append(AzPredictorConstants.CommandParameterSeperator)
                        .Append(AzPredictorConstants.ParameterValueMask);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Escaping the prediction text is necessary because KnowledgeBase predicted suggestions.
        /// such as "&lt;PSSubnetConfig&gt;" are incorrectly identified as pipe operators.
        /// </summary>
        /// <param name="text">The text to escape.</param>
        public static string EscapePredictionText(string text)
        {
            return text.Replace("<", "'<")
                .Replace(">", ">'")
                .Replace("{", "[[")
                .Replace("}", "]]");
        }

        /// <summary>
        /// Unescape the prediction text from <see cref="EscapePredictionText"/>.
        /// We don't want to show the escaped one to the user.
        /// </summary>
        /// <param name="text">The text to unescape.</param>
        public static string UnescapePredictionText(string text)
        {
            // Since the value with '<', and '>' doesn't make it a valid powershell command and
            // make it hard to use Alt+a from PSReadLine to navigate parameter value, we replace '<' with '{' and '>' with '}'.
            return text.Replace("'<", "{")
                .Replace(">'", "}")
                .Replace("[[", "{")
                .Replace("]]", "}");
        }
    }
}
