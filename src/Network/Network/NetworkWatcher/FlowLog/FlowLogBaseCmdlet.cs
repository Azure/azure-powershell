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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Linq;
using System.Management.Automation;
using System.Net;
using MNM = Microsoft.Azure.Management.Network.Models;


namespace Microsoft.Azure.Commands.Network
{
    public abstract class FlowLogBaseCmdlet : NetworkWatcherBaseCmdlet
    {
        public IFlowLogsOperations FlowLogs
        {
            get
            {
                return NetworkClient.NetworkManagementClient.FlowLogs;
            }
        }

        public bool IsFlowLogPresent(string resourceGroupName, string name, string flowLogName)
        {
            try
            {
                this.FlowLogs.Get(resourceGroupName, name, flowLogName);
            }
            catch (MNM.ErrorResponseException exception) when (exception.Response != null && exception.Response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return true;
        }

        public bool IsValidResourceId(ResourceIdentifier id, string expectedResourceType, bool validateParent = false, string expectedParentType = null)
        {
            if (id == null || string.IsNullOrEmpty(id.ResourceName) || string.IsNullOrEmpty(id.ResourceGroupName) || string.IsNullOrEmpty(id.Subscription)
                || !string.Equals(id.ResourceType, expectedResourceType, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (validateParent)
            {
                if (string.IsNullOrEmpty(id.ParentResource))
                {
                    return false;
                }

                string[] tokens = id.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Count() != 2 || (!string.IsNullOrEmpty(expectedParentType) && !string.Equals(tokens[0], expectedParentType, StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }
            }

            return true;
        }

        public void ValidateFlowLogParameters(string targetResourceId, string storageId, string enabledFilteringCriteria, int? formatVersion, string formatType,
            bool enableTrafficAnalytics, string trafficAnalyticsWorkspaceId, int? trafficAnalyticsInterval, int? retentionPolicyDays, string userAssignedIdentityId)
        {
            ResourceIdentifier targetResourceInfo = new ResourceIdentifier(targetResourceId);
            if (!this.IsValidResourceId(targetResourceInfo, "Microsoft.Network/networkSecurityGroups") &&
                !this.IsValidResourceId(targetResourceInfo, "Microsoft.Network/virtualNetworks") &&
                !this.IsValidResourceId(targetResourceInfo, "Microsoft.Network/virtualNetworks/subnets") &&
                !this.IsValidResourceId(targetResourceInfo, "Microsoft.Network/networkInterfaces"))
            {
                throw new PSArgumentException(Properties.Resources.InvalidTargetResourceId);
            }

            ResourceIdentifier storageAccountInfo = new ResourceIdentifier(storageId);
            if (!this.IsValidResourceId(storageAccountInfo, "Microsoft.Storage/storageAccounts"))
            {
                throw new PSArgumentException(Properties.Resources.InvalidStorageId);
            }

            if (formatVersion != null && (formatVersion < 0 || formatVersion > 2))
            {
                throw new PSArgumentException(Properties.Resources.InvalidFlowLogFormatVersion);
            }

            if (!string.IsNullOrEmpty(formatType) && (!string.Equals(formatType, "JSON", StringComparison.OrdinalIgnoreCase) && !string.Equals(formatType, "FlowLogJSON", StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSArgumentException(Properties.Resources.InvalidFlowLogFormatVersion);
            }

            if (enableTrafficAnalytics && string.IsNullOrEmpty(trafficAnalyticsWorkspaceId))
            {
                throw new PSArgumentException(Properties.Resources.TrafficAnalyticsWorkspaceResourceIdIsMissing);
            }

            if (trafficAnalyticsInterval != null && trafficAnalyticsInterval != 10 && trafficAnalyticsInterval != 60)
            {
                throw new PSArgumentException(Properties.Resources.InvalidTrafficAnalyticsInterval);
            }

            if (!string.IsNullOrEmpty(trafficAnalyticsWorkspaceId))
            {
                ResourceIdentifier workspaceInfo = new ResourceIdentifier(trafficAnalyticsWorkspaceId);
                if (!this.IsValidResourceId(workspaceInfo, "Microsoft.OperationalInsights/workspaces"))
                {
                    throw new PSArgumentException(Properties.Resources.InvalidWorkspaceResourceId);
                }
            }

            if (!string.IsNullOrEmpty(enabledFilteringCriteria))
            {
                if (enabledFilteringCriteria.Length > 1000)
                {
                    throw new PSArgumentException(Properties.Resources.FlowLogFilteringCriteriaExceedsLimit);
                }
            }

            if (retentionPolicyDays != null && retentionPolicyDays < 0)
            {
                throw new PSArgumentException(Properties.Resources.InvalidTrafficAnalyticsInterval);
            }

            if (userAssignedIdentityId != null && !string.Equals(userAssignedIdentityId, "none", StringComparison.OrdinalIgnoreCase))
            {
                ResourceIdentifier userAssignedIdentityInfo = new ResourceIdentifier(userAssignedIdentityId);
                if (!this.IsValidResourceId(userAssignedIdentityInfo, "Microsoft.ManagedIdentity/userAssignedIdentities"))
                {
                    throw new PSArgumentException(Properties.Resources.InvalidUserAssignedManagedIdentity);
                }
            }
        }
    }
}
