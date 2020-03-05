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

    public class PSIncludedPath
    {
        public PSIncludedPath()
        {
        }

        public PSIncludedPath(IncludedPath includedPath )
        {
            Path = includedPath.Path;
            if (includedPath.Indexes != null)
            {
                Indexes = new List<PSIndexes>();
                foreach (Indexes indexes in includedPath.Indexes)
                {
                    Indexes.Add(new PSIndexes(indexes));
                }
            }
        }
        //
        // Summary:
        //     Gets or sets the path for which the indexing behavior applies to. Index paths
        //     typically start with root and end with wildcard (/path/*)
        public string Path { get; set; }
        //
        // Summary:
        //     Gets or sets list of indexes for this path
        public IList<PSIndexes> Indexes { get; set; }

        static public List<Indexes> ConvertPSIndexesToIndexes(IList<PSIndexes> pSIndexes)
        {
            List<Indexes> indexes = new List<Indexes>();
            foreach(PSIndexes pSIndex in pSIndexes)
            {
                indexes.Add(PSIndexes.ConvertPSIndexesToIndexes(pSIndex));
            }

            return indexes;
        }
    }
}