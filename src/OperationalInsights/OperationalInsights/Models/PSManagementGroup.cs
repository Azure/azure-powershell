﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSManagementGroup
    {
        public PSManagementGroup()
        {
        }

        public PSManagementGroup(ManagementGroup managementGroup)
        {
            if (managementGroup == null)
            {
                throw new ArgumentNullException("managementGroup");
            }

            if (managementGroup != null)
            {
                this.CreatedDate = managementGroup.Created;
                this.LastDataReceived = managementGroup.DataReceived;
                this.Id = new Guid(managementGroup.Id);
                this.IsGateway = managementGroup.IsGateway.Value;
                this.Name = managementGroup.Name;
                this.ServerCount = managementGroup.ServerCount.Value;
                this.Sku = managementGroup.Sku;
                this.Version = managementGroup.Version;
            }
        }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastDataReceived { get; set; }

        public Guid? Id { get; set; }

        public bool IsGateway { get; set; }

        public string Name { get; set; }

        public int ServerCount { get; set; }

        public string Sku { get; set; }

        public string Version { get; set; }
    }
}