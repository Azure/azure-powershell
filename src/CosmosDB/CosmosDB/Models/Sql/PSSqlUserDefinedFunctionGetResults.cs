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

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.CosmosDB.Models;

    public class PSSqlUserDefinedFunctionGetResults 
    {
        public PSSqlUserDefinedFunctionGetResults()
        {
        }        
        
        public PSSqlUserDefinedFunctionGetResults(SqlUserDefinedFunctionGetResults sqlUserDefinedFunctionGetResults)
        {
            if (sqlUserDefinedFunctionGetResults == null)
            {
                return;
            }

            Name = sqlUserDefinedFunctionGetResults.Name;
            Id = sqlUserDefinedFunctionGetResults.Id;
            Location = sqlUserDefinedFunctionGetResults.Location;
            Tags = sqlUserDefinedFunctionGetResults.Tags;
            Resource = new PSSqlUserDefinedFunctionGetPropertiesResource(sqlUserDefinedFunctionGetResults.Resource);
        }

        /// <summary>
        /// Gets or sets Id of the User Defined Function
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Id of the User Defined Function
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets Location of the Cosmos DB SQL User Defined Function
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets Tags of the Cosmos DB SQL User Defined Function
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }
        //
        public PSSqlUserDefinedFunctionGetPropertiesResource Resource { get; set; }

    }
}
