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

using System.Collections.Generic;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSGremlinDatabaseToRestore
    {
        public PSGremlinDatabaseToRestore()
        {
        }

        public PSGremlinDatabaseToRestore(string databaseName, string[] graphNames)
        {
            DatabaseName = databaseName;
            GraphNames = graphNames;
        }

        public PSGremlinDatabaseToRestore(GremlinDatabaseRestoreResource databaseRestoreResource)
        {
            DatabaseName = databaseRestoreResource.DatabaseName;
            if (databaseRestoreResource.GraphNames != null && databaseRestoreResource.GraphNames.Count > 0)
            {
                GraphNames = new string[databaseRestoreResource.GraphNames.Count];
                databaseRestoreResource.GraphNames.CopyTo(GraphNames, 0);
            }
        }

        //
        // Summary:
        //     Gets or sets the name of the database available for restore.
        public string DatabaseName;

        //
        // Summary:
        //     Gets or sets the names of the graphs available for restore.
        public string[] GraphNames;

        public GremlinDatabaseRestoreResource ToSDKModel()
        {
            GremlinDatabaseRestoreResource gremlinDatabaseRestoreResource = new GremlinDatabaseRestoreResource()
            {
                DatabaseName = DatabaseName
            };

            if (GraphNames != null)
            {
                List<string> graphNames = new List<string>();
                graphNames.AddRange(GraphNames);
                gremlinDatabaseRestoreResource.GraphNames = graphNames;
            }

            return gremlinDatabaseRestoreResource;
        }
    }
}
