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
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(
        VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + DataClassificationCommon.SqlPoolSensitivityClassification,
        DefaultParameterSetName = DataClassificationCommon.ClassificationObjectParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class SetAzureSynapseSqlPoolSensitivityClassification : ModifyAzureSqlPoolSensitivityClassificationCmdlet
    {
        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.LabelNameHelpMessage)]
        [Parameter(
            ParameterSetName = DataClassificationCommon.SqlPoolObjectColumnParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.LabelNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string SensitivityLabel { get; set; }

        [Parameter(
            ParameterSetName = DataClassificationCommon.ColumnParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.InformationTypeHelpMessage)]
        [Parameter(
            ParameterSetName = DataClassificationCommon.SqlPoolObjectColumnParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DataClassificationCommon.InformationTypeHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string InformationType { get; set; }

        protected override SqlPoolSensitivityClassificationModel GetEntity()
        {
            if (ClassificationObject != null)
            {
                ResourceGroupName = ClassificationObject.ResourceGroupName;
                WorkspaceName = ClassificationObject.WorkspaceName;
                SqlPoolName = ClassificationObject.SqlPoolName;
            }
            else if (SqlPoolObject != null)
            {
                var resourceIdentifier = new ResourceIdentifier(SqlPoolObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.SqlPoolName = resourceIdentifier.ResourceName;
            }

            List<SensitivityLabelModel> sensitivityLabels = null;
            try
            {
                sensitivityLabels = ParameterSetName == DataClassificationCommon.ColumnParameterSet
                    || ParameterSetName == DataClassificationCommon.SqlPoolObjectColumnParameterSet
                    ? ModelAdapter.GetCurrentSensitivityLabel(ResourceGroupName, WorkspaceName, SqlPoolName, SchemaName, TableName, ColumnName)
                    : ModelAdapter.GetCurrentSensitivityLabels(ResourceGroupName, WorkspaceName, SqlPoolName);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != HttpStatusCode.NotFound || e.Message != "The specified sensitivity label could not be found")
                {
                    throw;
                }
            }

            return new SqlPoolSensitivityClassificationModel
            {
                ResourceGroupName = ResourceGroupName,
                WorkspaceName = WorkspaceName,
                SqlPoolName = SqlPoolName,
                SensitivityLabels = sensitivityLabels ?? new List<SensitivityLabelModel>()
            };
        }

        protected override SqlPoolSensitivityClassificationModel ApplyUserInputToModel(SqlPoolSensitivityClassificationModel model)
        {
            InformationProtectionPolicy informationProtectionPolicy = ModelAdapter.RetrieveInformationProtectionPolicyAsync().Result;
            if (ParameterSetName == DataClassificationCommon.ColumnParameterSet ||
                ParameterSetName == DataClassificationCommon.SqlPoolObjectColumnParameterSet)
            {
                SensitivityLabelModel sensitivityLabelModel = model.SensitivityLabels.FirstOrDefault();
                if (sensitivityLabelModel == null)
                {
                    sensitivityLabelModel = new SensitivityLabelModel
                    {
                        SchemaName = SchemaName,
                        TableName = TableName,
                        ColumnName = ColumnName,
                    };

                    model.SensitivityLabels.Add(sensitivityLabelModel);
                }

                sensitivityLabelModel.ApplyInput(InformationType, SensitivityLabel, informationProtectionPolicy);
            }
            else
            {
                model.ApplyModel(ClassificationObject, informationProtectionPolicy);
            }

            return model;
        }

        protected override SqlPoolSensitivityClassificationModel PersistChanges(SqlPoolSensitivityClassificationModel entity)
        {
            ModelAdapter.SetSensitivityLabels(entity);
            return null;
        }
    }
}
