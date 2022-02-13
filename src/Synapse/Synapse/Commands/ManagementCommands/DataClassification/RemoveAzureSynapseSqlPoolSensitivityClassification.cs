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

using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.DataClassification;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + DataClassificationCommon.SqlPoolSensitivityClassification,
        DefaultParameterSetName = DataClassificationCommon.ClassificationObjectParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveAzureSynapseSqlPoolSensitivityClassification : ModifyAzureSqlPoolSensitivityClassificationCmdlet
    {
        protected override SqlPoolSensitivityClassificationModel GetEntity()
        {
            if (ClassificationObject != null)
            {
                return ClassificationObject;
            }
            else if (SqlPoolObject != null)
            {
                var resourceIdentifier = new ResourceIdentifier(SqlPoolObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.SqlPoolName = resourceIdentifier.ResourceName;
            }

            return new SqlPoolSensitivityClassificationModel
            {
                ResourceGroupName = ResourceGroupName,
                WorkspaceName = WorkspaceName,
                SqlPoolName = SqlPoolName,
                SensitivityLabels = new List<SensitivityLabelModel>()
                {
                    new SensitivityLabelModel
                    {
                        SchemaName = SchemaName,
                        TableName = TableName,
                        ColumnName = ColumnName
                    }
                }
            };
        }

        protected override SqlPoolSensitivityClassificationModel PersistChanges(SqlPoolSensitivityClassificationModel entity)
        {
            ModelAdapter.RemoveSensitivityLabels(entity);
            return null;
        }
    }
}
