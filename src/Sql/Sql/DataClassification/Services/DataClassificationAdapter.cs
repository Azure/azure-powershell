using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataClassification.Model;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            InformationProtectionPolicy policy =
                AzureCommunicator.RetrieveInformationProtectionPolicyAsync(Context.Tenant.GetId()).Result;

            foreach (SensitivityLabelModel sensitivityLabelModel in model.SensitivityLabels)
            {
                Communicator.SetSensitivityLabel(model.ResourceGroupName, model.ServerName, model.DatabaseName,
                    sensitivityLabelModel.SchemaName, sensitivityLabelModel.TableName, sensitivityLabelModel.ColumnName,
                    ToSensitivityLabel(sensitivityLabelModel));
            }
        }

        internal void SetManagedDatabaseSensitivityLabels(ManagedDatabaseSensitivityClassificationModel model)
        {
            foreach (SensitivityLabelModel sensitivityLabelModel in model.SensitivityLabels)
            {
                Communicator.SetManagedDatabaseSensitivityLabel(model.ResourceGroupName, model.InstanceName, model.DatabaseName,
                    sensitivityLabelModel.SchemaName, sensitivityLabelModel.TableName, sensitivityLabelModel.ColumnName,
                    ToSensitivityLabel(sensitivityLabelModel));
            }
        }

        internal void DeleteSensitivityLabels(SqlDatabaseSensitivityClassificationModel model)
        {
            foreach (SensitivityLabelModel sensitivityLabelModel in model.SensitivityLabels)
            {
                Communicator.DeleteSensitivityLabel(model.ResourceGroupName, model.ServerName, model.DatabaseName,
                    sensitivityLabelModel.SchemaName, sensitivityLabelModel.TableName, sensitivityLabelModel.ColumnName);
            }
        }

        internal void DeleteManagedDatabaseSensitivityLabels(ManagedDatabaseSensitivityClassificationModel model)
        {
            foreach (SensitivityLabelModel sensitivityLabelModel in model.SensitivityLabels)
            {
                Communicator.DeleteManagedDatabaseSensitivityLabel(model.ResourceGroupName, model.InstanceName, model.DatabaseName,
                    sensitivityLabelModel.SchemaName, sensitivityLabelModel.TableName, sensitivityLabelModel.ColumnName);
            }
        }

        internal IList<SensitivityLabelModel> GetCurrentSensitivityLabel(
            string resourceGroupName, string serverName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            return ToSensitivityLabelModelList(Communicator.GetSensitivityLabel(resourceGroupName, serverName, databaseName,
                schemaName, tableName, columnName));
        }

        internal IList<SensitivityLabelModel> GetCurrentSensitivityLabels(
            string resourceGroupName, string serverName, string databaseName)
        {
            return ToSensitivityLabelModelList(Communicator.GetCurrentSensitivityLabels(resourceGroupName, serverName, databaseName));
        }

        internal IList<SensitivityLabelModel> GetManagedDatabaseCurrentSensitivityLabel(
            string resourceGroupName, string managedInstanceName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            return ToSensitivityLabelModelList(Communicator.GetManagedDatabaseSensitivityLabel(
                resourceGroupName, managedInstanceName, databaseName,
                schemaName, tableName, columnName));
        }

        internal IList<SensitivityLabelModel> GetManagedDatabaseCurrentSensitivityLabels(
            string resourceGroupName, string managedInstanceName, string databaseName)
        {
            return ToSensitivityLabelModelList(Communicator.GetManagedDatabaseCurrentSensitivityLabels(
                resourceGroupName, managedInstanceName, databaseName));
        }

        internal IList<SensitivityLabelModel> GetRecommendedSensitivityLabels(
            string resourceGroupName, string serverName, string databaseName)
        {
            return ToSensitivityLabelModelList(Communicator.GetRecommendedSensitivityLabels(resourceGroupName, serverName, databaseName));
        }

        internal IList<SensitivityLabelModel> GetManagedDatabaseRecommendedSensitivityLabels(
            string resourceGroupName, string managedInstanceName, string databaseName)
        {
            return ToSensitivityLabelModelList(Communicator.GetManagedDatabaseRecommendedSensitivityLabels(
                resourceGroupName, managedInstanceName, databaseName));
        }

        private IList<SensitivityLabelModel> ToSensitivityLabelModelList(IList<SensitivityLabel> sensitivityLabels)
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
                SensitivityLabelId = sensitivityLabel.LabelId,
                SensitivityLabel = sensitivityLabel.LabelName,
                InformationType = sensitivityLabel.InformationType,
                InformationTypeId = sensitivityLabel.InformationTypeId
            };
        }
    }
}
