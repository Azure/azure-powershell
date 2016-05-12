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

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSWorkspace
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

            if (workspace.Properties != null)
            {
                this.Sku = workspace.Properties.Sku != null ? workspace.Properties.Sku.Name : null;
                this.CustomerId = workspace.Properties.CustomerId;
                this.PortalUrl = workspace.Properties.PortalUrl;
                this.ProvisioningState = workspace.Properties.ProvisioningState;
            }
        }

        public string Name { get; set; }

        public string ResourceId { get; set; }

        public string ResourceGroupName { get; set; }

        public string Location { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public string Sku { get; set; }

        public Guid? CustomerId { get; set; }

        public string PortalUrl { get; set; }

        public string ProvisioningState { get; set; }
    }
}
