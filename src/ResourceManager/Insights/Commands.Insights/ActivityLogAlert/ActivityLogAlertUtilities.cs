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

using Microsoft.Azure.Commands.Insights.OutputClasses;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.ActivityLogAlert
{
    internal static class ActivityLogAlertUtilities
    {
        public static void ProcessPipeObject(PSActivityLogAlertResource inputObject, out string resourceGroupName, out string activityLogAlertName)
        {
            if (string.IsNullOrWhiteSpace(inputObject.Id))
            {
                throw new PSArgumentException(message: "Activity log alert Id cannot be null", paramName: "ActivityLogAlert");
            }

            if (string.IsNullOrWhiteSpace(inputObject.Name))
            {
                throw new PSArgumentException(message: "Activity log alert Name cannot be null", paramName: "ActivityLogAlert");
            }

            activityLogAlertName = inputObject.Name;

            try
            {
                Management.Internal.Resources.Utilities.Models.ResourceIdentifier resourceIdentifier = new Management.Internal.Resources.Utilities.Models.ResourceIdentifier(inputObject.Id);

                // Retrieve only the resource group name from the Id
                resourceGroupName = resourceIdentifier.ResourceGroupName;
            }
            catch (System.ArgumentException ex)
            {
                throw new PSArgumentException(message: "Invalid activity log alert resource Id: " + ex.Message, paramName: "ActivityLogAlert");
            }
        }

        public static void ProcessPipeObject(string resourceId, out string resourceGroupName, out string activityLogAlertName)
        {
            if (string.IsNullOrWhiteSpace(resourceId))
            {
                throw new PSArgumentException(message: "Activity log alert Id cannot be null", paramName: "ActivityLogAlert");
            }

            try
            {
                Management.Internal.Resources.Utilities.Models.ResourceIdentifier resourceIdentifier = new Management.Internal.Resources.Utilities.Models.ResourceIdentifier(resourceId);

                // Retrieve only the resource group name from the Id
                resourceGroupName = resourceIdentifier.ResourceGroupName;
                activityLogAlertName = resourceIdentifier.ResourceName;
            }
            catch (System.ArgumentException ex)
            {
                throw new PSArgumentException(message: "Invalid activity log alert resource Id: " + ex.Message, paramName: "ActivityLogAlert");
            }
        }
    }
}
