using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.ScheduledQueryRules
{
    internal static class ScheduledQueryRuleUtilities
    {

        public static void ProcessPipeObject(PSScheduledQueryRuleResource inputObject, out string resourceGroupName, out string ruleName)
        {
            if (string.IsNullOrWhiteSpace(inputObject.Id))
            {
                throw new PSArgumentException(message: "Log alert resource Id cannot be null", paramName: "LogAlert");
            }

            if (string.IsNullOrWhiteSpace(inputObject.Name))
            {
                throw new PSArgumentException(message: "Log alert Name cannot be null", paramName: "LogAlert");
            }

            ruleName = inputObject.Name;

            try
            {
                Management.Internal.Resources.Utilities.Models.ResourceIdentifier resourceIdentifier = new Management.Internal.Resources.Utilities.Models.ResourceIdentifier(inputObject.Id);
                // Retrieve only the resource group name from the Id
                resourceGroupName = resourceIdentifier.ResourceGroupName;
            }
            catch (System.ArgumentException ex)
            {
                throw new PSArgumentException(message: "Invalid log alert resource Id: " + ex.Message, paramName: "LogAlert");
            }
        }

        public static void ProcessPipeObject(string resourceId, out string resourceGroupName, out string ruleName)
        {
            if (string.IsNullOrWhiteSpace(resourceId))
            {
                throw new PSArgumentException(message: "Log alert Id cannot be null", paramName: "LogAlert");
            }

            try
            {
                Management.Internal.Resources.Utilities.Models.ResourceIdentifier resourceIdentifier = new Management.Internal.Resources.Utilities.Models.ResourceIdentifier(resourceId);
                resourceGroupName = resourceIdentifier.ResourceGroupName;
                ruleName = resourceIdentifier.ResourceName;
            }
            catch (System.ArgumentException ex)
            {
                throw new PSArgumentException(message: "Invalid log alert resource Id: " + ex.Message, paramName: "LogAlert");
            }
        }
    }
}
