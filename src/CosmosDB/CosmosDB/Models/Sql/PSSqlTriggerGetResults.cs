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

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    using Microsoft.Azure.Management.CosmosDB.Models;
    using System.Collections.Generic;

    public class PSSqlTriggerGetResults 
    {
        public PSSqlTriggerGetResults()
        {
        }        
        
        public PSSqlTriggerGetResults(SqlTriggerGetResults sqlTriggerGetResults)
        {
            if (sqlTriggerGetResults == null)
            {
                return;
            }

            Name = sqlTriggerGetResults.Name;
            Id = sqlTriggerGetResults.Id;
            Location = sqlTriggerGetResults.Location;
            Tags = sqlTriggerGetResults.Tags;
            Resource = new PSSqlTriggerGetPropertiesResource(sqlTriggerGetResults.Resource);
        }

        /// <summary>
        /// Gets or sets Name the Cosmos DB SQL Trigger
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Id of the Cosmos DB SQL Trigger
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets Location of the Cosmos DB SQL Trigger
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets Tags of the Cosmos DB SQL Trigger
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }
        //
        public PSSqlTriggerGetPropertiesResource Resource { get; set; }
    }
}
