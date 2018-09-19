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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.Utilities
{
    /// <summary>
    /// Custom implementation of the PSHostUserInterface to allow handling input in tests.
    /// </summary>
    public class SqlCustomPsHostUserInterface : PSHostUserInterface
    {
        /// <summary>
        /// Gets or sets an array of the inputs to supply to the prompt (in order)
        /// </summary>
        public PSObject[] PromptInputs { get; set; }

        /// <summary>
        /// Gets or sets the index of the option to choose when the user is prompted to choose from a list of options.
        /// </summary>
        public int PromptForChoiceInputIndex { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SqlCustomPsHostUserInterface()
        {
            PromptForChoiceInputIndex = -1;
        }

        /// <summary>
        /// This is called when a parameter wasn't supplied for a cmdlet.  This will be called to prompt the user for the needed value.
        /// Here we use the values in PromptInputs instead of getting them from the user.
        /// </summary>
        /// <param name="caption">The caption for the prompt</param>
        /// <param name="message">The message to show the user</param>
        /// <param name="descriptions">The names of all the fields that need input</param>
        /// <returns>A dictionary containing the response from the user with the FieldDescription.Name as the key</returns>
        public override Dictionary<string, System.Management.Automation.PSObject> Prompt(string caption, string message, System.Collections.ObjectModel.Collection<FieldDescription> descriptions)
        {
            Assert.IsNotNull(PromptInputs);
            Assert.AreEqual(PromptInputs.Length, descriptions.Count, "The number of Prompt inputs needs to be the same as the number of prompts");
            
            Dictionary<string, PSObject> ret = new Dictionary<string, PSObject>();
            for (int i = 0; i < descriptions.Count; i++)
            {
                ret.Add(descriptions[i].Name, PromptInputs[i]);
            }
            return ret;
        }

        /// <summary>
        /// This is called when the user needs to select an option from a list (eg: "Are you sure you want to continue: Yes, No").
        /// Instead of getting the input from the user we get the index of the option to choose from the value of PromptForChoiceInputIndex.
        /// </summary>
        /// <param name="caption">The caption for the request for input</param>
        /// <param name="message">The message to show</param>
        /// <param name="choices">The list of available choices</param>
        /// <param name="defaultChoice">The default choice.</param>
        /// <returns>The index of the choice that was selected</returns>
        public override int PromptForChoice(string caption, string message, System.Collections.ObjectModel.Collection<ChoiceDescription> choices, int defaultChoice)
        {
            Assert.IsTrue(PromptForChoiceInputIndex < choices.Count, "Must provide an index within the range of choices.");
            Assert.IsTrue(PromptForChoiceInputIndex >= 0, "Cannot have a negative index");

            return PromptForChoiceInputIndex;
        }

        /// <summary>
        /// Not needed
        /// </summary>
        public override System.Management.Automation.PSCredential PromptForCredential(string caption, string message, string userName, string targetName, System.Management.Automation.PSCredentialTypes allowedCredentialTypes, System.Management.Automation.PSCredentialUIOptions options)
        {
            return null;
        }

        /// <summary>
        /// Not needed
        /// </summary>
        public override System.Management.Automation.PSCredential PromptForCredential(string caption, string message, string userName, string targetName)
        {
            return null;
        }

        /// <summary>
        /// Not needed
        /// </summary>
        public override PSHostRawUserInterface RawUI
        {
            get { return null; }
        }

        /// <summary>
        /// Reads a line from input.  Not used.
        /// </summary>
        /// <returns></returns>
        public override string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Not needed
        /// </summary>
        public override System.Security.SecureString ReadLineAsSecureString()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Writes information to the console.
        /// </summary>
        /// <param name="foregroundColor">The foreground color to use</param>
        /// <param name="backgroundColor">The background color to use</param>
        /// <param name="value">What to write to the console</param>
        public override void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
        {
            var fg = Console.ForegroundColor;
            var bg = Console.BackgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(value);
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
        }

        /// <summary>
        /// Write a string to the console
        /// </summary>
        /// <param name="value">The string to display</param>
        public override void Write(string value)
        {
            Console.Write(value);
        }

        /// <summary>
        /// Write debug information to the console.
        /// </summary>
        /// <param name="message">The debug message to display</param>
        public override void WriteDebugLine(string message)
        {
            DebugRecord r = new DebugRecord(message);
            Console.WriteLine(r);
        }

        /// <summary>
        /// Dispays an error to the console
        /// </summary>
        /// <param name="value">The error to display</param>
        public override void WriteErrorLine(string value)
        {
            Console.Error.Write(value);
        }

        /// <summary>
        /// Write a line to the console.
        /// </summary>
        /// <param name="value">The string to write</param>
        public override void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Not needed
        /// </summary>
        public override void WriteProgress(long sourceId, System.Management.Automation.ProgressRecord record)
        {
        }

        /// <summary>
        /// Write verbose message to the console
        /// </summary>
        /// <param name="message">The message to display</param>
        public override void WriteVerboseLine(string message)
        {
            Console.WriteLine("VERBOSE: " + message);
        }

        /// <summary>
        /// Write a warning to the screen
        /// </summary>
        /// <param name="message">The warning to display</param>
        public override void WriteWarningLine(string message)
        {
            Console.WriteLine("WARNING: " + message);
        }
    }
}
