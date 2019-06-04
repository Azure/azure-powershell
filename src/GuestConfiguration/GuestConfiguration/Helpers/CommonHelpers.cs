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

namespace Microsoft.Azure.Commands.GuestConfiguration.Helpers
{
    using System;

    public class CommonHelpers
    {
        private const string _subscriptionsString = "/subscriptions/";
        private const string _resourceGroupsString = "/resourceGroups/";
        private const string _guestConfigurationAssignmentsString = "/guestConfigurationAssignments/";
        private const string _virtualMachinesString = "/virtualMachines/";
        private const string _reportsString = "/reports/";

        public static GCURLParameters GetGCURLParameters(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }

            var subscriptionsStringIndex = url.IndexOf(_subscriptionsString, StringComparison.CurrentCultureIgnoreCase);
            string subscriptionId = null;
            int subscriptionIdEndIndex = -1;
            if (subscriptionsStringIndex >= 0)
            {
                var subscriptionIdStartIndex = subscriptionsStringIndex + _subscriptionsString.Length;
                subscriptionIdEndIndex = url.IndexOf("/", subscriptionIdStartIndex);
                if (subscriptionIdEndIndex > 0)
                {
                    subscriptionId = url.Substring(subscriptionIdStartIndex, subscriptionIdEndIndex - subscriptionIdStartIndex);
                }
            }

            var resourceGroupsStringIndex = url.IndexOf(_resourceGroupsString, StringComparison.CurrentCultureIgnoreCase);
            string resourceGroupName = null;
            int resourceGroupNameEndIndex = -1;
            if (resourceGroupsStringIndex >= subscriptionIdEndIndex)
            {
                var resourceGroupNameStartIndex = resourceGroupsStringIndex + _resourceGroupsString.Length;
                resourceGroupNameEndIndex = url.IndexOf("/", resourceGroupNameStartIndex);
                if (resourceGroupNameEndIndex > 0)
                {
                    resourceGroupName = url.Substring(resourceGroupNameStartIndex, resourceGroupNameEndIndex - resourceGroupNameStartIndex);
                }
            }

            var virtualMachinesStringIndex = url.IndexOf(_virtualMachinesString, StringComparison.CurrentCultureIgnoreCase);
            string vmName = null;
            int vmNameEndIndex = -1;
            if (virtualMachinesStringIndex >= resourceGroupNameEndIndex)
            {
                var vmNameStartIndex = virtualMachinesStringIndex + _virtualMachinesString.Length;
                vmNameEndIndex = url.IndexOf("/", vmNameStartIndex);
                if (vmNameEndIndex > 0)
                {
                    vmName = url.Substring(vmNameStartIndex, vmNameEndIndex - vmNameStartIndex);
                }
            }

            var guestConfigurationAssignmentsStringIndex = url.IndexOf(_guestConfigurationAssignmentsString, StringComparison.CurrentCultureIgnoreCase);
            string assignmentName = null;
            int assignmentNameEndIndex;
            if (guestConfigurationAssignmentsStringIndex > vmNameEndIndex)
            {
                var assignmentNameStartIndex = guestConfigurationAssignmentsStringIndex + _guestConfigurationAssignmentsString.Length;
                assignmentNameEndIndex = url.IndexOf("/", assignmentNameStartIndex);
                if (assignmentNameEndIndex > 0)
                {
                    assignmentName = url.Substring(assignmentNameStartIndex, assignmentNameEndIndex - assignmentNameStartIndex);
                }
            }

            return new GCURLParameters()
            {
                SubscriptionId = subscriptionId,
                ResourceGroupName = resourceGroupName,
                VMName = vmName,
                AssignmentName = assignmentName,
            };
        }

        public static string GetReportGUIDFromID(string reportId)
        {
            if(string.IsNullOrEmpty(reportId))
            {
                return null;
            }
            var reportsStringIndex = reportId.IndexOf(_reportsString, StringComparison.CurrentCultureIgnoreCase);
            if(reportsStringIndex < 0)
            {
                return null;
            }
            string reportGuid = null;

            var reportGuidStartIndex = reportsStringIndex + _reportsString.Length;
            reportGuid = reportId.Substring(reportGuidStartIndex);
            if(string.IsNullOrEmpty(reportGuid) || reportGuid.Length != 36)
            {
                return null;
            }
            return reportGuid;
        }

        public class GCURLParameters
        {

            public string SubscriptionId { get; set; }

            public string ResourceGroupName { get; set; }

            public string VMName { get; set; }

            public string AssignmentName { get; set; }

            public bool AreParametersNotNullOrEmpty()
            {
                return !string.IsNullOrEmpty(SubscriptionId) &&
                    !string.IsNullOrEmpty(ResourceGroupName) &&
                    !string.IsNullOrEmpty(VMName) &&
                    !string.IsNullOrEmpty(AssignmentName);
            }
        }
    }
}
