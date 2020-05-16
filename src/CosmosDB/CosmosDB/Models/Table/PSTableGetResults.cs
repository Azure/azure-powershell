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

using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSTableGetResults
    {
        public PSTableGetResults()
        {
        }

        public PSTableGetResults(TableGetResults tableGetResults)
        {
            if (tableGetResults == null)
            {
                return; 
            }

            Name = tableGetResults.Name;
            Id = tableGetResults.Id;
            Location = tableGetResults.Location;
            Tags = tableGetResults.Tags;
            Resource = new PSTableGetPropertiesResource(tableGetResults.Resource);
        }

        /// <summary>
        /// Gets or sets Name of the Cosmos DB Table 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Id of the Cosmos DB Table
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets Location of the Cosmos DB Table
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets Tags of the Cosmos DB Table
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }
        //
        public PSTableGetPropertiesResource Resource { get; set; }
    }
}
