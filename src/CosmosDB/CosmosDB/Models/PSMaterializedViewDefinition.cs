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

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSMaterializedViewDefinition
    {
        public PSMaterializedViewDefinition()
        {
        }

        public PSMaterializedViewDefinition(MaterializedViewDefinition materializedViewDefinition)
        {
            if (materializedViewDefinition == null)
            {
                return;
            }

            this.SourceCollectionId = materializedViewDefinition.SourceCollectionId;
            this.SourceCollectionRid = materializedViewDefinition.SourceCollectionRid;
            this.Definition = materializedViewDefinition.Definition;
        }

        public string SourceCollectionId { get; set; }
        public string SourceCollectionRid { get; set; }
        public string Definition { get; set; }

        public static MaterializedViewDefinition ToSDKModel(PSMaterializedViewDefinition PSMaterializedViewDefinition)
        {
            if(PSMaterializedViewDefinition == null)
            {
                return null;
            }

            MaterializedViewDefinition materializedViewDefinition = new MaterializedViewDefinition
            {
                SourceCollectionId = PSMaterializedViewDefinition.SourceCollectionId,
                Definition = PSMaterializedViewDefinition.Definition
            };

            return materializedViewDefinition;
        }
    }
}
