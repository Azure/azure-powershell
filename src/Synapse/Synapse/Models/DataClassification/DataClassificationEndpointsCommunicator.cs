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
using Microsoft.Azure.Management.Synapse;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Synapse.Models.DataClassification
{
    internal class DataClassificationEndpointsCommunicator
    {
        private SynapseManagementClient SynapseManagementClient { get; set; }

        private IAzureSubscription Subscription { get; set; }

        private IAzureContext Context { get; set; }

        internal DataClassificationEndpointsCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SynapseManagementClient = GetCurrentSynapseManagementClient();
            }
        }

        internal void SetSensitivityLabel(string resourceGroupName, string workspaceName, string sqlPoolName,
            string schemaName, string tableName, string columnName, SensitivityLabel sensitivityLabel)
        {
            GetCurrentSynapseManagementClient().SqlPoolSensitivityLabels.CreateOrUpdate(resourceGroupName, workspaceName, sqlPoolName,
                schemaName, tableName, columnName, sensitivityLabel);
        }

        internal void DeleteSensitivityLabel(string resourceGroupName, string workspaceName, string sqlPoolName,
            string schemaName, string tableName, string columnName)
        {
            GetCurrentSynapseManagementClient().SqlPoolSensitivityLabels.Delete(resourceGroupName, workspaceName, sqlPoolName,
                schemaName, tableName, columnName);
        }

        internal List<SensitivityLabel> GetRecommendedSensitivityLabels(string resourceGroupName,
            string workspaceName, string sqlPoolName)
        {
            return IterateOverPages(
                () => GetCurrentSynapseManagementClient().SqlPoolSensitivityLabels.ListRecommended(
                    resourceGroupName, workspaceName, sqlPoolName),
                nextPageLink => GetCurrentSynapseManagementClient().SqlPoolSensitivityLabels.ListRecommendedNext(nextPageLink));
        }

        internal void EnableSensitivityRecommendation(string resourceGroupName, string workspaceName, string sqlPoolName,
            string schemaName, string tableName, string columnName)
        {
            GetCurrentSynapseManagementClient().SqlPoolSensitivityLabels.EnableRecommendation(resourceGroupName, workspaceName, sqlPoolName,
                schemaName, tableName, columnName);
        }

        internal void DisableSensitivityRecommendation(string resourceGroupName, string workspaceName, string sqlPoolName,
            string schemaName, string tableName, string columnName)
        {
            GetCurrentSynapseManagementClient().SqlPoolSensitivityLabels.DisableRecommendation(resourceGroupName, workspaceName, sqlPoolName,
                schemaName, tableName, columnName);
        }

        internal List<SensitivityLabel> GetSensitivityLabel(string resourceGroupName, string workspaceName, string sqlPoolName,
            string schemaName, string tableName, string columnName)
        {
            SensitivityLabel sensitivityLabel = GetSensitivityLabel(() =>
                GetCurrentSynapseManagementClient().SqlPoolSensitivityLabels.Get(
                    resourceGroupName, workspaceName, sqlPoolName, schemaName, tableName, columnName,
                    SensitivityLabelSource.Current));

            return ToList(sensitivityLabel);
        }

        private SensitivityLabel GetSensitivityLabel(Func<SensitivityLabel> getSensitivityLabelFromWorkspace)
        {
            SensitivityLabel sensitivityLabel = null;
            try
            {
                sensitivityLabel = getSensitivityLabelFromWorkspace();
            }
            catch (CloudException e)
            {
                if (!(e.Body.Code == "SensitivityLabelsLabelNotFound" &&
                    e.Body.Message == "The specified sensitivity label could not be found"))
                {
                    throw;
                }
            }

            return sensitivityLabel;
        }

        internal List<SensitivityLabel> GetCurrentSensitivityLabels(string resourceGroupName,
            string workspaceName, string sqlPoolName)
        {
            return IterateOverPages(
                () => GetCurrentSynapseManagementClient().SqlPoolSensitivityLabels.ListCurrent(
                    resourceGroupName, workspaceName, sqlPoolName),
                nextPageLink => GetCurrentSynapseManagementClient().SqlPoolSensitivityLabels.ListCurrentNext(nextPageLink));
        }

        private List<SensitivityLabel> IterateOverPages(
            Func<IPage<SensitivityLabel>> listByPool,
            Func<string, IPage<SensitivityLabel>> listByNextPageLink)
        {
            IPage<SensitivityLabel> sensitivityLabelsPage = listByPool();
            List<SensitivityLabel> sensitivityLabelsList = ToList(sensitivityLabelsPage);

            string nextPageLink = sensitivityLabelsPage?.NextPageLink;
            while (!string.IsNullOrEmpty(nextPageLink))
            {
                sensitivityLabelsPage = listByNextPageLink(nextPageLink);
                nextPageLink = sensitivityLabelsPage?.NextPageLink;
                sensitivityLabelsList.AddRange(ToList(sensitivityLabelsPage));
            }

            return sensitivityLabelsList;
        }

        private static List<SensitivityLabel> ToList(IPage<SensitivityLabel> sensitivityLabelsPage)
        {
            return sensitivityLabelsPage == null ?
                new List<SensitivityLabel>() :
                sensitivityLabelsPage.ToList();
        }

        private static List<SensitivityLabel> ToList(SensitivityLabel sensitivityLabel)
        {
            return sensitivityLabel == null ?
                new List<SensitivityLabel>() :
                new List<SensitivityLabel> { sensitivityLabel };
        }

        private SynapseManagementClient GetCurrentSynapseManagementClient()
        {
            if (SynapseManagementClient == null)
            {
                SynapseManagementClient = SynapseCmdletBase.CreateSynapseClient<SynapseManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }

            return SynapseManagementClient;
        }
    }
}
