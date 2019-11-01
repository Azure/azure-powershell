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
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;

    public class PSDatabaseAccountListKeys 
    {
        public PSDatabaseAccountListKeys()
        {
        }        
        
        public PSDatabaseAccountListKeys(DatabaseAccountListReadOnlyKeysResultInner databaseAccountListReadOnlyKeysResultInner)
        {
            Keys.Add("PrimaryReadonlyMasterKey", databaseAccountListReadOnlyKeysResultInner.PrimaryReadonlyMasterKey);
            Keys.Add("SecondaryReadonlyMasterKey", databaseAccountListReadOnlyKeysResultInner.SecondaryReadonlyMasterKey);
        }

        public PSDatabaseAccountListKeys(DatabaseAccountListConnectionStringsResultInner databaseAccountConnectionString)
        {
            foreach (DatabaseAccountConnectionString connectionString in databaseAccountConnectionString.ConnectionStrings)
            {
                Keys.Add(connectionString.Description, connectionString.ConnectionString);
            }
        }

        public PSDatabaseAccountListKeys(DatabaseAccountListKeysResultInner databaseAccountListKeysResultInner)
        {
            Keys.Add("PrimaryMasterKey", databaseAccountListKeysResultInner.PrimaryMasterKey);
            Keys.Add("SecondaryMasterKey", databaseAccountListKeysResultInner.SecondaryMasterKey);
            Keys.Add("PrimaryReadonlyMasterKey", databaseAccountListKeysResultInner.PrimaryReadonlyMasterKey);
            Keys.Add("SecondaryReadonlyMasterKey", databaseAccountListKeysResultInner.SecondaryReadonlyMasterKey);
        }

        public Hashtable Keys { get; set; } = new Hashtable();
    }
}
