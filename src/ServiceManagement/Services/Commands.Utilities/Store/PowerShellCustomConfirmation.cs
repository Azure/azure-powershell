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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation.Host;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;

namespace Microsoft.WindowsAzure.Commands.Utilities.Store
{
    public class PowerShellCustomConfirmation
    {
        public const int Yes = 0;
        
        public const int No = 1;

        private PSHost host;

        /// <summary>
        /// Parameterless constructor for mock framework
        /// </summary>
        public PowerShellCustomConfirmation()
        {

        }

        public PowerShellCustomConfirmation(PSHost host)
        {
            this.host = host;
        }

        /// <summary>
        /// Asks user for confirming the given  action.
        /// </summary>
        /// <param name="caption">The confirmation caption</param>
        /// <param name="message">The confirmation message</param>
        /// <returns>True if user entered Yes, otherwise false</returns>
        public virtual bool ShouldProcess(string caption, string message)
        {
            int userChoice = host.UI.PromptForChoice(
                caption,
                message,
                new Collection<ChoiceDescription>(
                    new List<ChoiceDescription>(2)
                    {
                        new ChoiceDescription(Resources.Yes, Resources.YesHint),
                        new ChoiceDescription(Resources.No, Resources.NoHint)
                    }), No);

            return userChoice == Yes;
        }
    }
}
