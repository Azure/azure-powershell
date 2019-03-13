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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataClassification.Model;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Services
{
    public class DataClassificationAdapter
    {
        private readonly IAzureContext Context;
        private readonly DataClassificationEndpointsCommunicator Communicator;
        private readonly AzureEndpointsCommunicator AzureCommunicator;

        public DataClassificationAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new DataClassificationEndpointsCommunicator(context);
            AzureCommunicator = new AzureEndpointsCommunicator(Context);
        }

        internal void SetSensitivityLabels(SqlDatabaseSensitivityClassificationModel model)
        {
            ModifySensitivityLabels(model, sensitivityLabelModel => Communicator.SetSensitivityLabel(
                    model.ResourceGroupName,
                    model.ServerName,
                    model.DatabaseName,
                    sensitivityLabelModel.SchemaName,
                    sensitivityLabelModel.TableName,
                    sensitivityLabelModel.ColumnName,
                    ToSensitivityLabel(sensitivityLabelModel)));
        }

        internal void SetSensitivityLabels(ManagedDatabaseSensitivityClassificationModel model)
        {
            ModifySensitivityLabels(model, sensitivityLabelModel => Communicator.SetManagedDatabaseSensitivityLabel(
                    model.ResourceGroupName,
                    model.InstanceName,
                    model.DatabaseName,
                    sensitivityLabelModel.SchemaName,
                    sensitivityLabelModel.TableName,
                    sensitivityLabelModel.ColumnName,
                    ToSensitivityLabel(sensitivityLabelModel)));
        }

        internal void ModifySensitivityLabels(SensitivityClassificationModel model,
            Action<SensitivityLabelModel> modifySensitivityLabel)
        {
            int failuresNumber = 0;
            Exception exception = null;
            foreach (SensitivityLabelModel sensitivityLabelModel in model.SensitivityLabels)
            {
                try
                {
                    modifySensitivityLabel(sensitivityLabelModel);
                }
                catch (Exception e)
                {
                    exception = e;
                    failuresNumber++;
                }
            }

            if (failuresNumber > 0)
            {
                throw (failuresNumber == 1) ? exception :
                    new Exception($"Operation failed for {failuresNumber} sensitivity classifications", exception);
            }
        }

        internal void RemoveSensitivityLabels(SqlDatabaseSensitivityClassificationModel model)
        {
            ModifySensitivityLabels(model, sensitivityLabelModel => Communicator.DeleteSensitivityLabel(
                model.ResourceGroupName,
                model.ServerName,
                model.DatabaseName,
                sensitivityLabelModel.SchemaName,
                sensitivityLabelModel.TableName,
                sensitivityLabelModel.ColumnName));
        }

        internal void RemoveManagedDatabaseSensitivityLabels(ManagedDatabaseSensitivityClassificationModel model)
        {
            ModifySensitivityLabels(model, sensitivityLabelModel => Communicator.DeleteManagedDatabaseSensitivityLabel(
                model.ResourceGroupName,
                model.InstanceName,
                model.DatabaseName,
                sensitivityLabelModel.SchemaName,
                sensitivityLabelModel.TableName,
                sensitivityLabelModel.ColumnName));
        }

        internal List<SensitivityLabelModel> GetCurrentSensitivityLabel(
            string resourceGroupName, string serverName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            return ToSensitivityLabelModelList(Communicator.GetSensitivityLabel(resourceGroupName, serverName, databaseName,
                schemaName, tableName, columnName));
        }

        internal List<SensitivityLabelModel> GetCurrentSensitivityLabels(
            string resourceGroupName, string serverName, string databaseName)
        {
            var n = Context.Environment.Name;
            return ToSensitivityLabelModelList(Communicator.GetCurrentSensitivityLabels(resourceGroupName, serverName, databaseName));
        }

        internal List<SensitivityLabelModel> GetManagedDatabaseCurrentSensitivityLabel(
            string resourceGroupName, string managedInstanceName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            return ToSensitivityLabelModelList(Communicator.GetManagedDatabaseSensitivityLabel(
                resourceGroupName, managedInstanceName, databaseName,
                schemaName, tableName, columnName));
        }

        internal List<SensitivityLabelModel> GetManagedDatabaseCurrentSensitivityLabels(
            string resourceGroupName, string managedInstanceName, string databaseName)
        {
            return ToSensitivityLabelModelList(Communicator.GetManagedDatabaseCurrentSensitivityLabels(
                resourceGroupName, managedInstanceName, databaseName));
        }

        internal List<SensitivityLabelModel> GetRecommendedSensitivityLabels(
            string resourceGroupName, string serverName, string databaseName)
        {
            return ToSensitivityLabelModelList(Communicator.GetRecommendedSensitivityLabels(resourceGroupName, serverName, databaseName));
        }

        internal List<SensitivityLabelModel> GetManagedDatabaseRecommendedSensitivityLabels(
            string resourceGroupName, string managedInstanceName, string databaseName)
        {
            return ToSensitivityLabelModelList(Communicator.GetManagedDatabaseRecommendedSensitivityLabels(
                resourceGroupName, managedInstanceName, databaseName));
        }

        internal async Task<InformationProtectionPolicy> RetrieveInformationProtectionPolicyAsync()
        {
            return Context.Environment.Name == EnvironmentName.AzureCloud
                ? await AzureCommunicator.RetrieveInformationProtectionPolicyAsync(Context.Tenant.GetId())
                : InformationProtectionPolicy.DefaultInformationProtectionPolicy;
        }

        private List<SensitivityLabelModel> ToSensitivityLabelModelList(List<SensitivityLabel> sensitivityLabels)
        {
            return sensitivityLabels.Select(l => ToSensitivityLabelModel(l)).ToList();
        }

        private static SensitivityLabel ToSensitivityLabel(SensitivityLabelModel sensitivityLabelModel)
        {
            return new SensitivityLabel
            {
                LabelName = sensitivityLabelModel.SensitivityLabel,
                LabelId = sensitivityLabelModel.SensitivityLabelId,
                InformationType = sensitivityLabelModel.InformationType,
                InformationTypeId = sensitivityLabelModel.InformationTypeId
            };
        }

        private static SensitivityLabelModel ToSensitivityLabelModel(SensitivityLabel sensitivityLabel)
        {
            string[] idComponents = sensitivityLabel.Id.Split('/');
            return new SensitivityLabelModel
            {
                SchemaName = idComponents[12],
                TableName = idComponents[14],
                ColumnName = idComponents[16],
                SensitivityLabel = sensitivityLabel.LabelName,
                SensitivityLabelId = sensitivityLabel.LabelId,
                InformationType = sensitivityLabel.InformationType,
                InformationTypeId = sensitivityLabel.InformationTypeId
            };
        }
    }
}
