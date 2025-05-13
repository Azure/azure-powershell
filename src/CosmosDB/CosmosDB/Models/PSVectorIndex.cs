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

    public class PSVectorIndex
    {
        public PSVectorIndex()
        {
        }

        public PSVectorIndex(VectorIndex vectorIndex )
        {
            if(vectorIndex == null)
            {
                return;
            }

            Path = vectorIndex.Path;
            Type = vectorIndex.Type;
        }
        //
        // Summary:
        //     Gets or sets the path for which the indexing behavior applies to. Index paths
        //     typically start with root and end with wildcard (/path/*)
        public string Path { get; set; }
        // Summary:
        //      The index type of the vector. 
        //      Currently, flat, diskANN, and quantizedFlat are supported.
         public string Type { get; set; }

        static public VectorIndex ToSDKModel(PSVectorIndex pSVectorIndex)
        {
            if (pSVectorIndex == null)
            {
                return null;
            }

            return new VectorIndex
            {
                Path = pSVectorIndex.Path,
                Type = pSVectorIndex.Type
            };
        }
    }
}