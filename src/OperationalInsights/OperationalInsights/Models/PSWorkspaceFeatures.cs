// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Management.OperationalInsights.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSWorkspaceFeatures
    {
        public PSWorkspaceFeatures(WorkspaceFeatures featues)
        {
            AdditionalProperties = featues.AdditionalProperties;
            ClusterResourceId = featues.ClusterResourceId;
            DisableLocalAuth = featues.DisableLocalAuth;
            EnableDataExport = featues.EnableDataExport;
            EnableLogAccessUsingOnlyResourcePermissions = featues.EnableLogAccessUsingOnlyResourcePermissions;
            ImmediatePurgeDataOn30Days = featues.ImmediatePurgeDataOn30Days;
        }

        public PSWorkspaceFeatures(bool? disableLocalAuth = null)
        {
            AdditionalProperties = null;
            ClusterResourceId = null;
            DisableLocalAuth = disableLocalAuth;
            EnableDataExport = null;
            EnableLogAccessUsingOnlyResourcePermissions = null;
            ImmediatePurgeDataOn30Days = null;
        }

        public WorkspaceFeatures GetWorkspaceFeatures()
        {
            return new WorkspaceFeatures(
                additionalProperties: AdditionalProperties,
                enableDataExport: EnableDataExport,
                immediatePurgeDataOn30Days: ImmediatePurgeDataOn30Days,
                enableLogAccessUsingOnlyResourcePermissions: EnableLogAccessUsingOnlyResourcePermissions,
                clusterResourceId: ClusterResourceId,
                disableLocalAuth: DisableLocalAuth);
        }

        public IDictionary<string, object> AdditionalProperties { get; set; }
        public string ClusterResourceId { get; set; }
        public bool? DisableLocalAuth { get; set; }
        public bool? EnableDataExport  { get; set; }
        public bool? EnableLogAccessUsingOnlyResourcePermissions  { get; set; }
        public bool? ImmediatePurgeDataOn30Days { get; set; }
    }
}
