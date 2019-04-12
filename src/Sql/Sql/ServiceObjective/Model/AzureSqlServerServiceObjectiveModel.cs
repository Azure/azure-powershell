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


using Microsoft.Azure.Commands.Sql.Database.Cmdlet;

namespace Microsoft.Azure.Commands.Sql.ServiceObjective.Model
{
    /// <summary>
    /// Represents the core properties of an Azure Sql Server
    /// </summary>
    public class AzureSqlServerServiceObjectiveModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the service objective
        /// </summary>
        /// <remarks>
        /// Can be used as input to <see cref="NewAzureSqlDatabase.RequestedServiceObjectiveName"/>
        /// </remarks>
        public string ServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the description for the Service Objective
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets whether or not the Service Objective is enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets Whether or no the Service Objective is the default one
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets Whether or no the Service Objective is a system value
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the edition
        /// </summary>
        /// <remarks>
        /// Can be used as input to <see cref="NewAzureSqlDatabase.Edition"/>
        /// </remarks>
        public string Edition { get; set; }

        /// <summary>
        /// Gets or sets the sku name
        /// </summary>
        /// <remarks>
        /// Not used as input to another cmdlet, but useful to help document the available sku names.
        /// </remarks>
        public string SkuName { get; set; }

        /// <summary>
        /// Gets or sets the family
        /// </summary>
        /// <remarks>
        /// Can be used as input to <see cref="NewAzureSqlDatabase.ComputeGeneration"/> (which has "Family" alias)
        /// </remarks>
        public string Family { get; set; }

        /// <summary>
        /// Gets or sets the capacity (e.g. in DTU or vcores).
        /// </summary>
        /// <remarks>
        /// Can be used as input to <see cref="NewAzureSqlDatabase.VCore"/> (which has "Capacity" alias).
        /// </remarks>
        public int? Capacity { get; set; }

        /// <summary>
        /// Gets or sets the capacity unit (e.g. DTU or vcores).
        /// </summary>
        /// <remarks>
        /// Not used as input to another cmdlet, but useful to help document the capacity.
        /// </remarks>
        public string CapacityUnit { get; set; }
    }
}
