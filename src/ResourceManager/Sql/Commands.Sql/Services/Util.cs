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

using Microsoft.Azure.Commands.Sql.Common;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Sql.Services
{
    public class Util
    {
        /// <summary>
        /// Generates a client side tracing Id of the format:
        /// [Guid]
        /// </summary>
        /// <returns>A string representation of the client side tracing Id.</returns>
        public static string GenerateTracingId()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}",
                Guid.NewGuid().ToString()
            );
        }

        /// <summary>
        /// In cases where the user decided to use one of the shortcuts (ALL or NONE), this method sets the value of the EventType property to reflect the correct values.
        /// In addition the is a deprecated audit events validity check.
        /// </summary>
        internal static string[] ProcessAuditEvents(string[] eventTypes)
        {
            if (eventTypes == null || eventTypes.Length == 0)
            {
                return eventTypes;
            }


            string[] auditEvents =
            {
                SecurityConstants.PlainSQL_Success,
                SecurityConstants.PlainSQL_Failure,
                SecurityConstants.ParameterizedSQL_Success,
                SecurityConstants.ParameterizedSQL_Failure,
                SecurityConstants.StoredProcedure_Success,
                SecurityConstants.StoredProcedure_Failure,
                SecurityConstants.Login_Success,
                SecurityConstants.Login_Failure,
                SecurityConstants.TransactionManagement_Success,
                SecurityConstants.TransactionManagement_Failure
            };


            if (eventTypes.Length == 1)
            {
                if (eventTypes[0] == SecurityConstants.None)
                {
                    return new string[] { };
                }
                if (eventTypes[0] == SecurityConstants.All)
                {
                    return auditEvents;
                }
            }
            else
            {
                if (eventTypes.Contains(SecurityConstants.All))
                {
                    throw new Exception(string.Format(Properties.Resources.InvalidEventTypeSet, SecurityConstants.All));
                }
                if (eventTypes.Contains(SecurityConstants.None))
                {
                    throw new Exception(string.Format(Properties.Resources.InvalidEventTypeSet, SecurityConstants.None));
                }
            }
            return eventTypes;
        }

        /// <summary>
        /// Checks if email addresses are in a correct format
        /// </summary>
        /// <param name="emailAddresses">The email addresses</param>
        /// <param name="seperator">The character that seperates different emails in the emailAddresses string</param>
        /// <returns>Returns whether the email addresses are in a correct format</returns>
        public static bool AreEmailAddressesInCorrectFormat(string emailAddresses, char seperator)
        {
            if (string.IsNullOrEmpty(emailAddresses))
            {
                return true;
            }

            string[] emailAddressesArray = emailAddresses.Split(seperator).Where(s => !string.IsNullOrEmpty(s)).ToArray();
            var emailRegex =
                new Regex(string.Format("{0}{1}",
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))",
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"));
            return !emailAddressesArray.Any(e => !emailRegex.IsMatch(e));
        }
    }
}
