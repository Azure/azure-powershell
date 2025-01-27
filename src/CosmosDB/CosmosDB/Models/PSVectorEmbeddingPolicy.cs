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
    public class PSVectorEmbeddingPolicy
    {
        public PSVectorEmbeddingPolicy()
        {
        }

        public PSVectorEmbeddingPolicy(VectorEmbeddingPolicy vectorEmbeddingPolicy)
        {
            if (vectorEmbeddingPolicy == null)
            {
                return;
            }

            if (ModelHelper.IsNotNullOrEmpty(vectorEmbeddingPolicy.VectorEmbeddings))
            {
                VectorEmbeddings = new List<PSVectorEmbedding>();
                foreach (VectorEmbedding vectorEmbedding in vectorEmbeddingPolicy.VectorEmbeddings)
                {
                    VectorEmbeddings.Add(new PSVectorEmbedding(vectorEmbedding));
                }
            }

        }

        //
        // Summary:
        //     List of vector embeddings
        public IList<PSVectorEmbedding> VectorEmbeddings { get; set; }

        public static VectorEmbeddingPolicy ToSDKModel(PSVectorEmbeddingPolicy pSVectorEmbeddingPolicy)
        {
            if (pSVectorEmbeddingPolicy == null)
            {
                return null;
            }

            VectorEmbeddingPolicy vectorEmbeddingPolicy = new VectorEmbeddingPolicy();

            if (ModelHelper.IsNotNullOrEmpty(pSVectorEmbeddingPolicy.VectorEmbeddings))
            {
                IList<VectorEmbedding> vectorEmbeddings = new List<VectorEmbedding>();
                foreach (PSVectorEmbedding pSVectorEmbedding in pSVectorEmbeddingPolicy.VectorEmbeddings)
                {
                    vectorEmbeddings.Add(PSVectorEmbedding.ToSDKModel(pSVectorEmbedding));
                }
                vectorEmbeddingPolicy.VectorEmbeddings = vectorEmbeddings;
            }

            return vectorEmbeddingPolicy;
        }
    }
}