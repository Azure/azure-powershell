using Microsoft.Azure.Commands.Insights.OutputClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.Utils
{
    class PrivateLinkScopeUtils
    {
        internal static PSMonitorPrivateLinkScope getPSMonitorPrivateLinkScope(AzureMonitorPrivateLinkScope privateLinkScope)
        {
            return new PSMonitorPrivateLinkScope(privateLinkScope.Location,
                                                 privateLinkScope.Id,
                                                 privateLinkScope.Name,
                                                 privateLinkScope.Type,
                                                 privateLinkScope.Tags,
                                                 privateLinkScope.ProvisioningState);
        }
    }
}
