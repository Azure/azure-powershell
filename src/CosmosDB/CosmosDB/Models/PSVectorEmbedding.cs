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

    public class PSVectorEmbedding
    {
        public PSVectorEmbedding()
        {
        }

        public PSVectorEmbedding(VectorEmbedding vectorEmbedding )
        {
            if(vectorEmbedding == null)
            {
                return;
            }

            Path = vectorEmbedding.Path;
            DataType = vectorEmbedding.DataType;
            DistanceFunction = vectorEmbedding.DistanceFunction;
            DataType = vectorEmbedding.DataType;
        }
        //
        // Summary:
        //     Gets or sets the path for which the indexing behavior applies to. Index paths
        //     typically start with root and end with wildcard (/path/*)
        public string Path { get; set; }

        //
        // Summary:
        //      Indicates the data type of vector.
        //      Possible values include: float32, uint8, int8
        public string DataType { get; set; }

        //
        // Summary:
        //      The distance function to use for distance calculation in between vectors.
        //      Possible values include: euclidean, cosine, dotproduct
        public string DistanceFunction { get; set; }

        //
        // Summary:
        //     The number of dimensions in the vector.
        public int Dimensions { get; set; }

        static public VectorEmbedding ToSDKModel(PSVectorEmbedding pSVectorEmbedding)
        {
            if (pSVectorEmbedding == null)
            {
                return null;
            }

            return new VectorEmbedding
            {
                Path = pSVectorEmbedding.Path,
                DataType = pSVectorEmbedding.DataType,
                DistanceFunction = pSVectorEmbedding.DistanceFunction,
                Dimensions = pSVectorEmbedding.Dimensions
            };
        }
    }
}