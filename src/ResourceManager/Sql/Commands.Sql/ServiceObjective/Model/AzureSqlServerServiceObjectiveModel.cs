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
    }
}
