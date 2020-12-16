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
using System.Collections.Concurrent;
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
            SplitSensitivityLabelsIntoListsAndPatch(model.SensitivityLabels,
                list => Communicator.PatchSensitivityLabels(
                    model.ResourceGroupName,
                    model.ServerName,
                    model.DatabaseName,
                    new PatchOperations
                    {
                        Operations = list.Select(sensitivityLabelModel => new PatchOperation
                        {
                            OperationKind = PatchOperationKind.Set,
                            Schema = sensitivityLabelModel.SchemaName,
                            Table = sensitivityLabelModel.TableName,
                            Column = sensitivityLabelModel.ColumnName,
                            SensitivityLabel = ToSensitivityLabel(sensitivityLabelModel)
                        }).ToList()
                    }));
        }

        internal void SetSensitivityLabels(ManagedDatabaseSensitivityClassificationModel model)
        {
            SplitSensitivityLabelsIntoListsAndPatch(model.SensitivityLabels,
                list => Communicator.PatchManagedDatabaseSensitivityLabels(
                    model.ResourceGroupName,
                    model.InstanceName,
                    model.DatabaseName,
                    new PatchOperations
                    {
                        Operations = list.Select(sensitivityLabelModel => new PatchOperation
                        {
                            OperationKind = PatchOperationKind.Set,
                            Schema = sensitivityLabelModel.SchemaName,
                            Table = sensitivityLabelModel.TableName,
                            Column = sensitivityLabelModel.ColumnName,
                            SensitivityLabel = ToSensitivityLabel(sensitivityLabelModel)
                        }).ToList()
                    }));
        }

        internal void RemoveSensitivityLabels(SqlDatabaseSensitivityClassificationModel model)
        {
            SplitSensitivityLabelsIntoListsAndPatch(model.SensitivityLabels,
                list => Communicator.PatchSensitivityLabels(
                    model.ResourceGroupName,
                    model.ServerName,
                    model.DatabaseName,
                    new PatchOperations
                    {
                        Operations = list.Select(sensitivityLabelModel => new PatchOperation
                        {
                            OperationKind = PatchOperationKind.Remove,
                            Schema = sensitivityLabelModel.SchemaName,
                            Table = sensitivityLabelModel.TableName,
                            Column = sensitivityLabelModel.ColumnName,
                        }).ToList()
                    }));
        }

        internal void RemoveSensitivityLabels(ManagedDatabaseSensitivityClassificationModel model)
        {
            SplitSensitivityLabelsIntoListsAndPatch(model.SensitivityLabels,
                list => Communicator.PatchManagedDatabaseSensitivityLabels(
                    model.ResourceGroupName,
                    model.InstanceName,
                    model.DatabaseName,
                    new PatchOperations
                    {
                        Operations = list.Select(sensitivityLabelModel => new PatchOperation
                        {
                            OperationKind = PatchOperationKind.Remove,
                            Schema = sensitivityLabelModel.SchemaName,
                            Table = sensitivityLabelModel.TableName,
                            Column = sensitivityLabelModel.ColumnName,
                        }).ToList()
                    }));
        }

        internal void EnableSensitivityRecommendations(SqlDatabaseSensitivityClassificationModel model)
        {
            SplitSensitivityLabelsIntoListsAndPatch(model.SensitivityLabels,
                list => Communicator.PatchSensitivityRecommendations(
                    model.ResourceGroupName,
                    model.ServerName,
                    model.DatabaseName,
                    new PatchOperations
                    {
                        Operations = list.Select(sensitivityLabelModel => new PatchOperation
                        {
                            OperationKind = PatchOperationKind.Enable,
                            Schema = sensitivityLabelModel.SchemaName,
                            Table = sensitivityLabelModel.TableName,
                            Column = sensitivityLabelModel.ColumnName,
                        }).ToList()
                    }));
        }

        internal void EnableSensitivityRecommendations(ManagedDatabaseSensitivityClassificationModel model)
        {
            SplitSensitivityLabelsIntoListsAndPatch(model.SensitivityLabels,
                list => Communicator.PatchManagedDatabaseSensitivityRecommendations(
                    model.ResourceGroupName,
                    model.InstanceName,
                    model.DatabaseName,
                    new PatchOperations
                    {
                        Operations = list.Select(sensitivityLabelModel => new PatchOperation
                        {
                            OperationKind = PatchOperationKind.Enable,
                            Schema = sensitivityLabelModel.SchemaName,
                            Table = sensitivityLabelModel.TableName,
                            Column = sensitivityLabelModel.ColumnName,
                        }).ToList()
                    }));
        }

        internal void DisableSensitivityRecommendations(SqlDatabaseSensitivityClassificationModel model)
        {
            SplitSensitivityLabelsIntoListsAndPatch(model.SensitivityLabels,
                list => Communicator.PatchSensitivityRecommendations(
                    model.ResourceGroupName,
                    model.ServerName,
                    model.DatabaseName,
                    new PatchOperations
                    {
                        Operations = list.Select(sensitivityLabelModel => new PatchOperation
                        {
                            OperationKind = PatchOperationKind.Disable,
                            Schema = sensitivityLabelModel.SchemaName,
                            Table = sensitivityLabelModel.TableName,
                            Column = sensitivityLabelModel.ColumnName,
                        }).ToList()
                    }));
        }
        internal void DisableSensitivityRecommendations(ManagedDatabaseSensitivityClassificationModel model)
        {
            SplitSensitivityLabelsIntoListsAndPatch(model.SensitivityLabels,
                list => Communicator.PatchManagedDatabaseSensitivityRecommendations(
                    model.ResourceGroupName,
                    model.InstanceName,
                    model.DatabaseName,
                    new PatchOperations
                    {
                        Operations = list.Select(sensitivityLabelModel => new PatchOperation
                        {
                            OperationKind = PatchOperationKind.Disable,
                            Schema = sensitivityLabelModel.SchemaName,
                            Table = sensitivityLabelModel.TableName,
                            Column = sensitivityLabelModel.ColumnName,
                        }).ToList()
                    }));
        }

        internal void SplitSensitivityLabelsIntoListsAndPatch(List<SensitivityLabelModel> sensitivityLabelsToModify,
            Action<List<SensitivityLabelModel>> patchSensitivityLabels)
        {
            ConcurrentQueue<Exception> exceptions = new ConcurrentQueue<Exception>();
            Parallel.ForEach<List<SensitivityLabelModel>>(SplitList(sensitivityLabelsToModify),
                sensitivityLabelsList =>
                {
                    try
                    {
                        patchSensitivityLabels(sensitivityLabelsList);
                    }
                    catch (Exception e)
                    {
                        exceptions.Enqueue(e);
                    }
                });

            if (!exceptions.IsEmpty)
            {
                int exceptionsCount = exceptions.Count;
                Exception lastException = exceptions.Last();
                throw (exceptionsCount == 1) ? lastException :
                    new Exception($"Operation failed for {exceptionsCount} sensitivity classifications", lastException);
            }
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
            return Context.Environment.Name == EnvironmentName.AzureCloud ||
                Context.Environment.Name == EnvironmentName.AzureUSGovernment
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
                InformationTypeId = sensitivityLabelModel.InformationTypeId,
                Rank = ToSensitivityLabelRank(sensitivityLabelModel.Rank)
            };
        }

        private static SensitivityLabelModel ToSensitivityLabelModel(SensitivityLabel sensitivityLabel)
        {
            var match = new global::System.Text.RegularExpressions.Regex("/schemas/(?<schemaName>.*)/tables/(?<tableName>.*)/columns/(?<columnName>.*)/sensitivityLabels/",
                global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(sensitivityLabel.Id);

            return new SensitivityLabelModel
            {
                SchemaName = match.Groups["schemaName"].Value,
                TableName = match.Groups["tableName"].Value,
                ColumnName = match.Groups["columnName"].Value,
                SensitivityLabel = NullifyStringIfEmpty(sensitivityLabel.LabelName),
                SensitivityLabelId = NullifyStringIfEmpty(sensitivityLabel.LabelId),
                InformationType = NullifyStringIfEmpty(sensitivityLabel.InformationType),
                InformationTypeId = NullifyStringIfEmpty(sensitivityLabel.InformationTypeId),
                Rank = ToSensitivityRank(sensitivityLabel.Rank)
            };
        }

        private static string NullifyStringIfEmpty(string s)
        {
            return string.IsNullOrEmpty(s) ? null : s;
        }

        private static SensitivityRank? ToSensitivityRank(SensitivityLabelRank? rank)
        {
            SensitivityRank? sensitivityRank = null;
            if (rank.HasValue)
            {
                switch (rank.Value)
                {
                    case SensitivityLabelRank.None:
                        sensitivityRank = SensitivityRank.None;
                        break;
                    case SensitivityLabelRank.Low:
                        sensitivityRank = SensitivityRank.Low;
                        break;
                    case SensitivityLabelRank.Medium:
                        sensitivityRank = SensitivityRank.Medium;
                        break;
                    case SensitivityLabelRank.High:
                        sensitivityRank = SensitivityRank.High;
                        break;
                    case SensitivityLabelRank.Critical:
                        sensitivityRank = SensitivityRank.Critical;
                        break;
                }
            }

            return sensitivityRank;
        }

        private static SensitivityLabelRank? ToSensitivityLabelRank(SensitivityRank? rank)
        {
            SensitivityLabelRank? sensitivityLabelRank = null;
            if (rank.HasValue)
            {
                switch (rank.Value)
                {
                    case SensitivityRank.None:
                        sensitivityLabelRank = SensitivityLabelRank.None;
                        break;
                    case SensitivityRank.Low:
                        sensitivityLabelRank = SensitivityLabelRank.Low;
                        break;
                    case SensitivityRank.Medium:
                        sensitivityLabelRank = SensitivityLabelRank.Medium;
                        break;
                    case SensitivityRank.High:
                        sensitivityLabelRank = SensitivityLabelRank.High;
                        break;
                    case SensitivityRank.Critical:
                        sensitivityLabelRank = SensitivityLabelRank.Critical;
                        break;
                }
            }

            return sensitivityLabelRank;
        }

        private static IEnumerable<List<T>> SplitList<T>(List<T> elements)
        {
            const int ListSize = 5000;
            for (int i = 0; i < elements.Count; i += ListSize)
            {
                yield return elements.GetRange(i, Math.Min(ListSize, elements.Count - i));
            }
        }
    }
}
