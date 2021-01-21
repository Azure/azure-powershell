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
    public class PSDatabaseToRestore
    {
        public PSDatabaseToRestore()
        {
        }

        public PSDatabaseToRestore(string name, string[] collections)
        {
            DatabaseName = name;
            CollectionNames = collections;
        }

        public PSDatabaseToRestore(DatabaseRestoreResource databaseRestoreResource)
        {
            DatabaseName = databaseRestoreResource.DatabaseName;
            if (databaseRestoreResource.CollectionNames != null && databaseRestoreResource.CollectionNames.Count > 0)
            {
                CollectionNames = new string[databaseRestoreResource.CollectionNames.Count];
                databaseRestoreResource.CollectionNames.CopyTo(CollectionNames, 0);
            }
        }

        //
        // Summary:
        //     Gets or sets the name of the database available for restore.
        public string DatabaseName;

        //
        // Summary:
        //     Gets or sets the names of the collections available for restore.
        public string[] CollectionNames;

        public DatabaseRestoreResource ToSDKModel()
        {
            DatabaseRestoreResource databaseRestoreResource = new DatabaseRestoreResource()
            {
                DatabaseName = DatabaseName
            };

            if (CollectionNames != null)
            {
                List<string> collectionNames = new List<string>();
                collectionNames.AddRange(CollectionNames);
                databaseRestoreResource.CollectionNames = collectionNames;
            }

            return databaseRestoreResource;
        }
    }
}
