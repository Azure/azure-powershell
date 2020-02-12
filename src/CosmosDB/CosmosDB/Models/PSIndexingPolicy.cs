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
    public class PSIndexingPolicy
    {
        public PSIndexingPolicy()
        {
        }

        public PSIndexingPolicy(IndexingPolicy indexingPolicy)
        {
            Automatic = indexingPolicy.Automatic;
            IndexingMode = indexingPolicy.IndexingMode;

            if (indexingPolicy.IncludedPaths != null)
            {
                IncludedPaths = new List<PSIncludedPath>();
                foreach (IncludedPath includedPath in indexingPolicy.IncludedPaths)
                {
                    IncludedPaths.Add(new PSIncludedPath(includedPath));
                }
            }

            if (indexingPolicy.ExcludedPaths != null)
            {
                ExcludedPaths = new List<PSExcludedPath>();
                foreach (ExcludedPath excludedPath in indexingPolicy.ExcludedPaths)
                {
                    ExcludedPaths.Add(new PSExcludedPath(excludedPath));
                }
            }

            if (indexingPolicy.CompositeIndexes != null)
            {
                CompositeIndexes = new List<IList<PSCompositePath>>();
                foreach (IList<CompositePath> compositePathList in indexingPolicy.CompositeIndexes)
                {
                    List<PSCompositePath> pSCompositePathList = new List<PSCompositePath>();
                    foreach (CompositePath compositePath in compositePathList)
                    {
                        pSCompositePathList.Add(new PSCompositePath(compositePath));
                    }
                    CompositeIndexes.Add(pSCompositePathList);
                }
            }

            if (indexingPolicy.SpatialIndexes != null)
            {
                SpatialIndexes = new List<PSSpatialSpec>();
                foreach (SpatialSpec spatialSpec in indexingPolicy.SpatialIndexes)
                {
                    SpatialIndexes.Add(new PSSpatialSpec(spatialSpec));
                }
            }
        }

        //
        // Summary:
        //     Gets or sets indicates if the indexing policy is automatic
        public bool? Automatic { get; set; }
        //
        // Summary:
        //     Gets or sets indicates the indexing mode. Possible values include: 'Consistent',
        //     'Lazy', 'None'
        public string IndexingMode { get; set; }
        //
        // Summary:
        //     Gets or sets list of paths to include in the indexing
        public IList<PSIncludedPath> IncludedPaths { get; set; }
        //
        // Summary:
        //     Gets or sets list of paths to exclude from indexing
        public IList<PSExcludedPath> ExcludedPaths { get; set; }
        //
        // Summary:
        //     Gets or sets list of composite path list
        public IList<IList<PSCompositePath>> CompositeIndexes { get; set; }
        //
        // Summary:
        //     Gets or sets list of spatial specifics
        public IList<PSSpatialSpec> SpatialIndexes { get; set; }
    }
}