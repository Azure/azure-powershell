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

using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBGremlinIndexingPolicy"), OutputType(typeof(PSIndexingPolicy))]
    public class NewAzCosmosDBGremlinIndexingPolicy : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = Constants.IndexingPolicyIncludedPathHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSIncludedPath[] IncludedPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.IndexingPolicySpatialIndexHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSSpatialSpec[] SpatialSpec { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.IndexingPolicyCompositePathHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSCompositePath[][] CompositePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.IndexingPolicyExcludedPathHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string[] ExcludedPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.IndexingPolicyAutomaticHelpMessage)]
        public bool? Automatic { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.IndexingPolicyIndexingModeIndexHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string IndexingMode { get; set; }

        public override void ExecuteCmdlet()
        {
            PSIndexingPolicy indexingPolicy = new PSIndexingPolicy();

            if (IncludedPath != null && IncludedPath.Length > 0)
            {
                indexingPolicy.IncludedPaths = new List<PSIncludedPath>(IncludedPath);
            }

            if (ExcludedPath != null && ExcludedPath.Length > 0)
            {
                indexingPolicy.ExcludedPaths = new List<PSExcludedPath>();
                foreach (string path in ExcludedPath)
                {
                    indexingPolicy.ExcludedPaths.Add(new PSExcludedPath{ Path = path });
                }
            }

            if(SpatialSpec != null)
            {
                indexingPolicy.SpatialIndexes = SpatialSpec;
            }

            if(CompositePath != null)
            {
                indexingPolicy.CompositeIndexes = CompositePath;
            }

            indexingPolicy.Automatic = Automatic;

            if (IndexingMode != null)
                indexingPolicy.IndexingMode = IndexingMode;

            WriteObject(indexingPolicy);
            return;
        }
    }
}