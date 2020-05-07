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
    public class PSIndexingPolicy
    {
        public PSIndexingPolicy()
        {
        }

        public PSIndexingPolicy(IndexingPolicy indexingPolicy)
        {
            if (indexingPolicy == null)
            {
                return;
            }

            Automatic = indexingPolicy.Automatic;
            IndexingMode = indexingPolicy.IndexingMode;

            if (ModelHelper.IsNotNullOrEmpty(indexingPolicy.IncludedPaths))
            {
                IncludedPaths = new List<PSIncludedPath>();
                foreach (IncludedPath includedPath in indexingPolicy.IncludedPaths)
                {
                    IncludedPaths.Add(new PSIncludedPath(includedPath));
                }
            }

            if (ModelHelper.IsNotNullOrEmpty(indexingPolicy.ExcludedPaths))
            {
                ExcludedPaths = new List<PSExcludedPath>();
                foreach (ExcludedPath excludedPath in indexingPolicy.ExcludedPaths)
                {
                    ExcludedPaths.Add(new PSExcludedPath(excludedPath));
                }
            }

            if (ModelHelper.IsNotNullOrEmpty(indexingPolicy.CompositeIndexes))
            {
                CompositeIndexes = new List<IList<PSCompositePath>>();
                foreach (IList<CompositePath> compositePathList in indexingPolicy.CompositeIndexes)
                {
                    if (ModelHelper.IsNotNullOrEmpty(compositePathList))
                    {
                        List<PSCompositePath> pSCompositePathList = new List<PSCompositePath>();
                        foreach (CompositePath compositePath in compositePathList)
                        {
                            pSCompositePathList.Add(new PSCompositePath(compositePath));
                        }
                        CompositeIndexes.Add(pSCompositePathList);
                    }
                }
            }

            if (ModelHelper.IsNotNullOrEmpty(indexingPolicy.SpatialIndexes))
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

        public static IndexingPolicy ToSDKModel(PSIndexingPolicy pSIndexingPolicy)
        {
            if (pSIndexingPolicy == null)
            {
                return null;
            }

            IndexingPolicy indexingPolicy = new IndexingPolicy
            {
                Automatic = pSIndexingPolicy.Automatic,
            };

            if (pSIndexingPolicy.IndexingMode != null)
            {
                indexingPolicy.IndexingMode = pSIndexingPolicy.IndexingMode;
            }

            if (ModelHelper.IsNotNullOrEmpty(pSIndexingPolicy.IncludedPaths))
            {
                IList<IncludedPath> includedPaths = new List<IncludedPath>();
                foreach (PSIncludedPath pSIncludedPath in pSIndexingPolicy.IncludedPaths)
                {
                    includedPaths.Add(PSIncludedPath.ToSDKModel(pSIncludedPath));
                }
                indexingPolicy.IncludedPaths = includedPaths;
            }

            if (ModelHelper.IsNotNullOrEmpty(pSIndexingPolicy.ExcludedPaths))
            {
                IList<ExcludedPath> excludedPaths = new List<ExcludedPath>();
                foreach (PSExcludedPath pSExcludedPath in pSIndexingPolicy.ExcludedPaths)
                {
                    excludedPaths.Add(PSExcludedPath.ToSDKModel(pSExcludedPath));
                }
                indexingPolicy.ExcludedPaths = excludedPaths;
            }

            if (ModelHelper.IsNotNullOrEmpty(pSIndexingPolicy.CompositeIndexes))
            {
                IList<IList<CompositePath>> compositeIndexes = new List<IList<CompositePath>>();
                foreach (IList<PSCompositePath> pSCompositePathList in pSIndexingPolicy.CompositeIndexes)
                {
                    if (ModelHelper.IsNotNullOrEmpty(pSCompositePathList))
                    {
                        IList<CompositePath> compositePathList = new List<CompositePath>();
                        foreach (PSCompositePath pSCompositePath in pSCompositePathList)
                        {
                            compositePathList.Add(PSCompositePath.ToSDKModel(pSCompositePath));
                        }
                        compositeIndexes.Add(compositePathList);
                    }
                }
                indexingPolicy.CompositeIndexes = compositeIndexes;
            }

            if (ModelHelper.IsNotNullOrEmpty(pSIndexingPolicy.SpatialIndexes))
            {
                IList<SpatialSpec> spatialIndexes = new List<SpatialSpec>();
                foreach (PSSpatialSpec pSSpatialSpec in pSIndexingPolicy.SpatialIndexes)
                {
                    spatialIndexes.Add(PSSpatialSpec.ToSDKModel(pSSpatialSpec));
                }
                indexingPolicy.SpatialIndexes = new List<SpatialSpec>(spatialIndexes);
            }

            return indexingPolicy;
        }
    }
}