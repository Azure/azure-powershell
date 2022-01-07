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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Helpers
{
    internal static class MSGraphMessageHelper
    {
        private const string MessageForCmdletsSwallowException = @"We have migrated the API calls for this cmdlet from Azure Active Directory Graph to Microsoft Graph.
Visit https://go.microsoft.com/fwlink/?linkid=2181475 for any permission issues.";
        private const string MessageForCmdletsThrowException = @"We have migrated the API calls for this cmdlet from Azure Active Directory Graph to Microsoft Graph.
Visit https://go.microsoft.com/fwlink/?linkid=2181475 for troubleshooting information.";
        private const string SuppressEnvVar = "SuppressAzurePowerShellBreakingChangeWarnings";
        private static bool IsMessageSuppressed =>
            bool.TryParse(Environment.GetEnvironmentVariable(SuppressEnvVar), out bool result) && result;

        /// <summary>
        /// Write a warning message that informs the user that the cmdlet has been migrated from AAD Graph to MS Graph.
        /// This message applies to those cmdlets that *swallow* MSGraph exceptions.
        /// </summary>
        internal static void WriteMessageForCmdletsSwallowException(System.Management.Automation.Cmdlet cmdlet) =>
            WriteMessage(cmdlet, MessageForCmdletsSwallowException);

        /// <summary>
        /// Write a warning message that informs the user that the cmdlet has been migrated from AAD Graph to MS Graph.
        /// This message applies to those cmdlets that *throw* MSGraph exceptions.
        /// </summary>
        internal static void WriteMessageForCmdletsThrowException(System.Management.Automation.Cmdlet cmdlet) =>
            WriteMessage(cmdlet, MessageForCmdletsThrowException);

        private static void WriteMessage(System.Management.Automation.Cmdlet cmdlet, string message)
        {
            if (!IsMessageSuppressed)
            {
                cmdlet.WriteWarning(message);
            }
        }
    }
}