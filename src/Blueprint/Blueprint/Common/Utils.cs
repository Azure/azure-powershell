using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.Common.Authentication;
using AzureSession = Microsoft.Azure.Common.Authentication.AzureSession;

namespace Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Common
{
    class Utils
    {
        /// <summary>
        /// Get definition location. Either a subcscription or a management group.
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static string GetDefinitionLocationId(string scope)
        {
            if (string.IsNullOrEmpty(scope))
                return null;

            //check if it's a sub level or mg level scope
            string[] tokens = scope.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            string locationId = null;

            if (tokens != null && tokens.Length == 2)
            {
                locationId = tokens[0] == "subscriptions" ? tokens[1] : null;      
            }

            if (tokens != null && tokens.Length == 4)
            {
                locationId = tokens[2] == "managementGroups" ? tokens[3] : null;
            }

            return locationId;
        }
    }
}
