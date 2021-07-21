using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public IList<PSAvailableServiceTiers> ListPSAvailableServiceTiers(string resourceGroupName, string workspaceName)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new ArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
            }

            if (string.IsNullOrWhiteSpace(workspaceName))
            {
                throw new ArgumentException(Resources.WorkspaceDetailsCannotBeEmpty);
            }

            IList<AvailableServiceTier> availableServiceTiers =  this.OperationalInsightsManagementClient.AvailableServiceTiers.ListByWorkspace(resourceGroupName, workspaceName);
            return availableServiceTiers.Select(item => new PSAvailableServiceTiers(item)).ToList();
        }
    }
}
