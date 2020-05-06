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
    using System.Collections;
    using Microsoft.Azure.Management.CosmosDB.Models;

    public class PSDatabaseAccountListKeys 
    {
        public PSDatabaseAccountListKeys()
        {
        }        
        
        public PSDatabaseAccountListKeys(DatabaseAccountListReadOnlyKeysResult databaseAccountListReadOnlyKeysResult)
        {
            Keys.Add("PrimaryReadonlyMasterKey", databaseAccountListReadOnlyKeysResult.PrimaryReadonlyMasterKey);
            Keys.Add("SecondaryReadonlyMasterKey", databaseAccountListReadOnlyKeysResult.SecondaryReadonlyMasterKey);
        }

        public PSDatabaseAccountListKeys(DatabaseAccountListConnectionStringsResult databaseAccountConnectionString)
        {
            foreach (DatabaseAccountConnectionString connectionString in databaseAccountConnectionString.ConnectionStrings)
            {
                Keys.Add(connectionString.Description, connectionString.ConnectionString);
            }
        }

        public PSDatabaseAccountListKeys(DatabaseAccountListKeysResult databaseAccountListKeysResult)
        {
            Keys.Add("PrimaryMasterKey", databaseAccountListKeysResult.PrimaryMasterKey);
            Keys.Add("SecondaryMasterKey", databaseAccountListKeysResult.SecondaryMasterKey);
            Keys.Add("PrimaryReadonlyMasterKey", databaseAccountListKeysResult.PrimaryReadonlyMasterKey);
            Keys.Add("SecondaryReadonlyMasterKey", databaseAccountListKeysResult.SecondaryReadonlyMasterKey);
        }

        public Hashtable Keys { get; set; } = new Hashtable();
    }
}
