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

using Microsoft.Azure.Management.SqlVirtualMachine.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model
{
    /// <summary>
    /// Represents the core properties of an Azure Sql Virtual Machine. It mirrors the .NET client object 
    /// Microsoft.Azure.Management.SqlVirtualMachine.Models.SqlVirtualMachine
    /// </summary>
    public class AzureSqlVMModel
    {
        public AzureSqlVMModel()
        {
        }

        public AzureSqlVMModel(string resourceGroupName)
        {
            ResourceGroupName = resourceGroupName;
        }

        /// <summary>
        /// Gets or sets the name of the resource group the sql virtual machine is in
        /// </summary>
        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 1)]
        public string ResourceGroupName { get; }

        /// <summary>
        /// Gets or sets the name of the sql virtual machine
        /// </summary>
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, Position = 0)]
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the id of the virtual machine
        /// </summary>
        public string VirtualMachineId { get; set; }

        /// <summary>
        /// Gets or sets the location the sql virtual machine is in
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the sql virtual machine offer
        /// </summary>
        [Ps1Xml(Label = "Offer", Target = ViewControl.Table, Position = 4)]
        public string Offer { get; set; }

        /// <summary>
        /// Gets or sets the sql virtual machine sku
        /// </summary>
        [Ps1Xml(Label = "Sku", Target = ViewControl.Table, Position = 3)]
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets the sql virtual machine license type
        /// </summary>
        [Ps1Xml(Label = "LicenseType", Target = ViewControl.Table, Position = 2)]
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets the sql virtual machine management type
        /// </summary>
        [Ps1Xml(Label = "SqlManagementType", Target = ViewControl.Table, Position = 5)]
        public string SqlManagementType { get; set; }

        /// <summary>
        /// Gets or sets domain credentials for setting up Windows Server Failover Cluster for SQL availability group.
        /// </summary>
        public WsfcDomainCredentials WsfcDomainCredentials { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the sql virtual machine.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the sql virtual machine
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the group the sql virtual machine is part of
        /// </summary>
        public AzureSqlVMGroupModel SqlVirtualMachineGroup { get; set; }
    }
}
