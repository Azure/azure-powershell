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

using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Sql.Database.Model;

namespace Microsoft.Azure.Commands.Sql.ElasticPoolRecommendation.Model
{
    /// <summary>
    /// Represents an Azure Sql Elastic Pool Recommendation
    /// </summary>
    public class AzureSqlElasticPoolRecommendationModel
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
        /// Gets or sets the name of the recommended elastic pool
        /// </summary>
        public string RecommendedElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the database edition of the recommended elastic pool
        /// </summary>
        public DatabaseEdition? DatabaseEdition { get; set; }

        /// <summary>
        /// Gets or sets the Dtu for the recommended elastic pool
        /// </summary>
        public double Dtu { get; set; }

        /// <summary>
        /// Gets or sets the min Dtu per database in the recommended elastic pool
        /// </summary>
        public double DatabaseDtuMin { get; set; }

        /// <summary>
        /// Gets or sets the max Dtu per database in the recommended elastic pool
        /// </summary>
        public double DatabaseDtuMax { get; set; }

        /// <summary>
        /// Gets or sets the amount of storage the recommended elastic pool has
        /// </summary>
        public double StorageMB { get; set; }

        /// <summary>
        /// Gets or sets the observation period start
        /// </summary>
        public DateTime ObservationPeriodStart { get; set; }

        /// <summary>
        /// Gets or sets the observation period end
        /// </summary>
        public DateTime ObservationPeriodEnd { get; set; }

        /// <summary>
        /// Gets or sets the maximum observed Dtu
        /// </summary>
        public double MaxObservedDtu { get; set; }

        /// <summary>
        /// Gets or sets the maximum observed storage in MB
        /// </summary>
        public double MaxObservedStorageMB { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the Recommended Elastic Pool.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }
    }
}
