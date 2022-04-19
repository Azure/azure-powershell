using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Cdn.Helpers
{
    internal static class CdnMessageHelper
    {        
        private const string SuppressEnvVar = BreakingChangeAttributeHelper.SUPPRESS_ERROR_OR_WARNING_MESSAGE_ENV_VARIABLE_NAME;
       
        private static bool IsMessageSuppressed =>
            bool.TryParse(Environment.GetEnvironmentVariable(SuppressEnvVar), out bool result) && result;

        internal static void WriteMessage(Cmdlet cmdlet, string message)
        {
            if (!IsMessageSuppressed)
            {
                cmdlet.WriteWarning(message);
            }
        }
    }
}
