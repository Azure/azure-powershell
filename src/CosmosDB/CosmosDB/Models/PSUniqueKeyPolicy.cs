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
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{

    public class PSUniqueKeyPolicy
    {
        public PSUniqueKeyPolicy()
        {
        }        

        public PSUniqueKeyPolicy(UniqueKeyPolicy uniqueKey)
        {
            if (uniqueKey == null)
            {
                return;
            }

            if (ModelHelper.IsNotNullOrEmpty(uniqueKey.UniqueKeys))
            {
                UniqueKeys = new List<PSUniqueKey>();
                foreach (UniqueKey key in uniqueKey.UniqueKeys)
                {
                    UniqueKeys.Add(new PSUniqueKey(key));
                }
            }
        }

        //
        // Summary:
        //     Gets or sets list of unique keys on that enforces uniqueness constraint on documents
        //     in the collection in the Azure Cosmos DB service.
        public IList<PSUniqueKey> UniqueKeys { get; set; }

        public static UniqueKeyPolicy ToSDKModel(PSUniqueKeyPolicy pSUniqueKeyPolicy)
        {
            if (pSUniqueKeyPolicy == null)
            {
                return null;
            }

            UniqueKeyPolicy uniqueKeyPolicy = new UniqueKeyPolicy
            {
                UniqueKeys = new List<UniqueKey>()
            };

            if (ModelHelper.IsNotNullOrEmpty(pSUniqueKeyPolicy.UniqueKeys))
            {
                foreach (PSUniqueKey uniqueKey in pSUniqueKeyPolicy.UniqueKeys)
                {
                    UniqueKey key = new UniqueKey
                    {
                        Paths = new List<string>(uniqueKey?.Paths)
                    };
                    uniqueKeyPolicy.UniqueKeys.Add(key);
                }
            }

            return uniqueKeyPolicy;
        }
    }
}