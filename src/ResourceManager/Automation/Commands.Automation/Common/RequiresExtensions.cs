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
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Automation.Properties;

namespace Microsoft.Azure.Commands.Automation.Common
{
    internal static class RequiresExtensions
    {
        #region Constants

        private const string AccountNameValidator = "^[A-Za-z][-A-Za-z0-9]{4,48}[A-Za-z0-9]$";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Validates that the provided automation account name is valid.
        /// </summary>
        /// <param name="argument">
        /// The argument.
        /// </param>
        /// <returns>
        /// The <see cref="Requires.ArgumentRequirements{T}"/>.
        /// </returns>
        public static Requires.ArgumentRequirements<string> ValidAutomationAccountName(this Requires.ArgumentRequirements<string> argument)
        {
            Requires.Argument(argument.Name, argument.Value).NotNull();

            string stringValue = argument.Value;

            if (!new Regex(AccountNameValidator).IsMatch(stringValue))
            {
                // CDM TFS 665994 - we decided to display AutomationAccountNotFound even if the account name is invalid.
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.AutomationAccountNotFound));
            }

            return argument;
        }

        #endregion
    }
}
