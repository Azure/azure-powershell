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

using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.Internal.Network.Common;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSWorkspace : IOperationalInsightWorkspace
    {
        public PSWorkspace()
        {
        }

        public PSWorkspace(Workspace workspace, string resourceGroupName)
        {
            if (workspace == null)
            {
                throw new ArgumentNullException("workspace");
            }

            this.ResourceGroupName = resourceGroupName;
            this.Name = workspace.Name;
            this.ResourceId = workspace.Id;
            this.Location = workspace.Location;
            this.Tags = workspace.Tags;

            this.Sku = workspace.Sku.Name;
            this.CapacityReservationLevel = workspace?.Sku?.CapacityReservationLevel;
            this.LastSkuUpdate = workspace?.Sku?.LastSkuUpdate;

            this.retentionInDays = workspace.RetentionInDays;
            this.CustomerId = new Guid(workspace.CustomerId);
            this.ProvisioningState = workspace.ProvisioningState;

            this.PublicNetworkAccessForIngestion = workspace.PublicNetworkAccessForIngestion;
            this.PublicNetworkAccessForQuery = workspace.PublicNetworkAccessForQuery;
            this.PrivateLinkScopedResources = workspace.PrivateLinkScopedResources;
            this.WorkspaceCapping = workspace.WorkspaceCapping;
            this.CreatedDate = workspace.CreatedDate;
            this.ModifiedDate = workspace.ModifiedDate;
            this.ForceCmkForQuery = workspace.ForceCmkForQuery;
            this.WorkspaceFeatures = new PSWorkspaceFeatures(workspace.Features);
            this.DefaultDataCollectionRuleResourceId = workspace.DefaultDataCollectionRuleResourceId;
        }

        public string Name { get; set; }

        public string ResourceId { get; set; }

        public string ResourceGroupName { get; set; }

        public string Location { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public string Sku { get; set; }

        public int? CapacityReservationLevel { get; set; }

        public string LastSkuUpdate { get; }

        public int? retentionInDays { get; set; }

        public Guid? CustomerId { get; set; }

        public string ProvisioningState { get; set; }

        public string PublicNetworkAccessForIngestion { get; set; }

        public string PublicNetworkAccessForQuery { get; set; }

        public IList<PrivateLinkScopedResource> PrivateLinkScopedResources { get; private set; }

        public WorkspaceCapping WorkspaceCapping { get; private set; }

        public string CreatedDate { get; set; }

        public string ModifiedDate { get; set; }

        public bool? ForceCmkForQuery { get; set; }

        public PSWorkspaceFeatures WorkspaceFeatures { get; set; }

        public string DefaultDataCollectionRuleResourceId { get; set; }
    }
}
