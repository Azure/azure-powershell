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
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Synapse.Models.DataClassification
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

        internal void SetSensitivityLabels(SqlPoolSensitivityClassificationModel model)
        {
            SplitSensitivityLabelsIntoListsAndPatch(model.SensitivityLabels,
                list => list.ForEach(sensitivityLabelModel => Communicator.SetSensitivityLabel(
                    model.ResourceGroupName,
                    model.WorkspaceName,
                    model.SqlPoolName,
                    sensitivityLabelModel.SchemaName,
                    sensitivityLabelModel.TableName,
                    sensitivityLabelModel.ColumnName,
                    ToSensitivityLabel(sensitivityLabelModel)
                    )));
        }

        internal void EnableSensitivityRecommendations(SqlPoolSensitivityClassificationModel model)
        {
            SplitSensitivityLabelsIntoListsAndPatch(model.SensitivityLabels,
                list => list.ForEach(sensitivityLabelModel => Communicator.EnableSensitivityRecommendation(
                    model.ResourceGroupName,
                    model.WorkspaceName,
                    model.SqlPoolName,
                    sensitivityLabelModel.SchemaName,
                    sensitivityLabelModel.TableName,
                    sensitivityLabelModel.ColumnName
                    )));
        }

        internal void DisableSensitivityRecommendations(SqlPoolSensitivityClassificationModel model)
        {
            SplitSensitivityLabelsIntoListsAndPatch(model.SensitivityLabels,
                list => list.ForEach(sensitivityLabelModel => Communicator.DisableSensitivityRecommendation(
                    model.ResourceGroupName,
                    model.WorkspaceName,
                    model.SqlPoolName,
                    sensitivityLabelModel.SchemaName,
                    sensitivityLabelModel.TableName,
                    sensitivityLabelModel.ColumnName
                    )));
        }

        internal List<SensitivityLabelModel> GetCurrentSensitivityLabel(
            string resourceGroupName, string workspaceName, string sqlPoolName,
            string schemaName, string tableName, string columnName)
        {
            return ToSensitivityLabelModelList(Communicator.GetSensitivityLabel(resourceGroupName, workspaceName, sqlPoolName,
                schemaName, tableName, columnName));
        }

        internal List<SensitivityLabelModel> GetCurrentSensitivityLabels(
            string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            return ToSensitivityLabelModelList(Communicator.GetCurrentSensitivityLabels(resourceGroupName, workspaceName, sqlPoolName));
        }

        internal void RemoveSensitivityLabels(SqlPoolSensitivityClassificationModel model)
        {
            SplitSensitivityLabelsIntoListsAndPatch(model.SensitivityLabels,
                list => list.ForEach(sensitivityLabelModel => Communicator.DeleteSensitivityLabel(
                    model.ResourceGroupName,
                    model.WorkspaceName,
                    model.SqlPoolName,
                    sensitivityLabelModel.SchemaName,
                    sensitivityLabelModel.TableName,
                    sensitivityLabelModel.ColumnName
                    )));
        }

        internal async Task<InformationProtectionPolicy> RetrieveInformationProtectionPolicyAsync()
        {
            return Context.Environment.Name == EnvironmentName.AzureCloud ||
                Context.Environment.Name == EnvironmentName.AzureUSGovernment
                ? await AzureCommunicator.RetrieveInformationProtectionPolicyAsync(Context.Tenant.GetId())
                : InformationProtectionPolicy.DefaultInformationProtectionPolicy;
        }

        internal void SplitSensitivityLabelsIntoListsAndPatch(List<SensitivityLabelModel> sensitivityLabelsToModify,
            Action<List<SensitivityLabelModel>> patchSensitivityLabels)
        {
            ConcurrentQueue<Exception> exceptions = new ConcurrentQueue<Exception>();
            Parallel.ForEach(SplitList(sensitivityLabelsToModify),
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

        internal List<SensitivityLabelModel> GetRecommendedSensitivityLabels(
            string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            return ToSensitivityLabelModelList(Communicator.GetRecommendedSensitivityLabels(resourceGroupName, workspaceName, sqlPoolName));
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
                SensitivityLabel = NullifyStringIfEmpty(sensitivityLabel.LabelName),
                SensitivityLabelId = NullifyStringIfEmpty(sensitivityLabel.LabelId),
                InformationType = NullifyStringIfEmpty(sensitivityLabel.InformationType),
                InformationTypeId = NullifyStringIfEmpty(sensitivityLabel.InformationTypeId)
            };
        }

        private static string NullifyStringIfEmpty(string s)
        {
            return string.IsNullOrEmpty(s) ? null : s;
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
