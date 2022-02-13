using System;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.Common
{
    /// <summary>
    /// Helper for handling maintenance configurations
    /// </summary>
    internal static class MaintenanceConfigurationHelper
    {
        /// <summary>
        /// Template for public maintenance configuration ids
        /// </summary>
        public const string PublicMaintenanceConfigurationTemplate = "/subscriptions/{0}/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/{1}";

        /// <summary>
        /// Converts user input to MaintenanceConfigurationId argument to proper form
        /// Expands public maintenance configuration names to full resource id
        /// </summary>
        /// <param name="input">User input</param>
        /// <param name="subscriptionId">Current subscription id</param>
        /// <returns></returns>
        public static string ConvertMaintenanceConfigurationIdArgument(string input, string subscriptionId)
        {
            // if there is no input or customer explicitly specified full resource id we pass as it is
            return string.IsNullOrWhiteSpace(input) || input.StartsWith("/") ? input : PublicMaintenanceConfigurationTemplate.FormatInvariant(subscriptionId, input);
        }
    }
}
