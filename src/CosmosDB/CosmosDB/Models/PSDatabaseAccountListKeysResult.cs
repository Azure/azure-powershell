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
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;

    public class PSDatabaseAccountListKeysResult : PSResource
    {
        public PSDatabaseAccountListKeysResult()
        {
        }        
        
        public PSDatabaseAccountListKeysResult(DatabaseAccountListKeysResultInner databaseAccountListKeysResultInner)
        {
            PrimaryMasterKey = databaseAccountListKeysResultInner.PrimaryMasterKey;
            SecondaryMasterKey = databaseAccountListKeysResultInner.SecondaryMasterKey;
            PrimaryReadonlyMasterKey = databaseAccountListKeysResultInner.PrimaryReadonlyMasterKey;
            SecondaryReadonlyMasterKey = databaseAccountListKeysResultInner.SecondaryReadonlyMasterKey;
        }

        //
        // Summary:
        //     Gets base 64 encoded value of the primary read-write key.
        public string PrimaryMasterKey { get; set; }
        //
        // Summary:
        //     Gets base 64 encoded value of the secondary read-write key.
         public string SecondaryMasterKey { get; set; }
        //
        // Summary:
        //     Gets base 64 encoded value of the primary read-only key.
        public string PrimaryReadonlyMasterKey { get; set; }
        //
        // Summary:
        //     Gets base 64 encoded value of the secondary read-only key.
        public string SecondaryReadonlyMasterKey { get; set; }

    }
}
