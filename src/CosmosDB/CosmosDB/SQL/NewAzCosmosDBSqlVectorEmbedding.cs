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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlVectorEmbedding", SupportsShouldProcess = true), OutputType(typeof(PSVectorEmbedding))]
    public class NewAzCosmosDBSqlVectorEmbedding : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = Constants.VectorEmbeddingPathHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.VectorEmbeddingDataTypeHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DataType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.VectorEmbeddingDistanceFunctionHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DistanceFunction { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.VectorEmbeddingDimensionsHelpMessage)]
        [ValidateNotNullOrEmpty]
        public int Dimensions { get; set; }

        public override void ExecuteCmdlet()
        {
            PSVectorEmbedding pSVectorEmbedding = new PSVectorEmbedding();

            if (Path != null)
            {
                pSVectorEmbedding.Path = Path;
            }

            if (DataType != null)
            {
                pSVectorEmbedding.DataType = DataType;
            }

            if (DistanceFunction != null)
            {
                pSVectorEmbedding.DistanceFunction = DistanceFunction;
            }

            pSVectorEmbedding.Dimensions = Dimensions;

            WriteObject(pSVectorEmbedding);
            return;
        }
    }
}
