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

using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSColumn
    {
        public PSColumn()
        {
        }

        public PSColumn(Column column)
        {
            Name = column.Name;
            Type = column.Type;
        }

        static public Column ConvertPSColumnToColumn(PSColumn psColumn)
        {
            return new Column
            {
                Name = psColumn.Name,
                Type = psColumn.Type
            };
        }
        //
        // Summary:
        //     Gets or sets name of the Cosmos DB Cassandra table column
        public string Name { get; set; }
        //
        // Summary:
        //     Gets or sets type of the Cosmos DB Cassandra table column
        public string Type { get; set; }
    }
}