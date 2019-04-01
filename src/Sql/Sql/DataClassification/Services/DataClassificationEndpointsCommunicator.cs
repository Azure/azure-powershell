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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Services
{
    internal class DataClassificationEndpointsCommunicator
    {
        private ISqlManagementClient SqlManagementClient { get; set; }

        private IAzureSubscription Subscription { get; set; }

        private IAzureContext Context { get; set; }

        internal DataClassificationEndpointsCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlManagementClient = null;
            }
        }

        internal void SetSensitivityLabel(string resourceGroupName, string serverName, string databaseName,
            string schemaName, string tableName, string columnName, SensitivityLabel sensitivityLabel)
        {
            GetCurrentSqlManagementClient().SensitivityLabels.CreateOrUpdate(resourceGroupName, serverName, databaseName,
                schemaName, tableName, columnName, sensitivityLabel);
        }

        internal void SetManagedDatabaseSensitivityLabel(string resourceGroupName, string managedInstanceName, string databaseName,
            string schemaName, string tableName, string columnName, SensitivityLabel sensitivityLabel)
        {
            GetCurrentSqlManagementClient().ManagedDatabaseSensitivityLabels.CreateOrUpdate(resourceGroupName,
                managedInstanceName, databaseName, schemaName, tableName, columnName, sensitivityLabel);
        }

        internal void DeleteSensitivityLabel(string resourceGroupName, string serverName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            GetCurrentSqlManagementClient().SensitivityLabels.Delete(resourceGroupName, serverName, databaseName,
                schemaName, tableName, columnName);
        }

        internal void DeleteManagedDatabaseSensitivityLabel(string resourceGroupName, string managedInstanceName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            GetCurrentSqlManagementClient().ManagedDatabaseSensitivityLabels.Delete(resourceGroupName, managedInstanceName, databaseName,
                schemaName, tableName, columnName);
        }

        internal List<SensitivityLabel> GetSensitivityLabel(string resourceGroupName, string serverName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            SensitivityLabel sensitivityLabel =
                GetCurrentSqlManagementClient().SensitivityLabels.Get(
                    resourceGroupName, serverName, databaseName, schemaName, tableName, columnName,
                    SensitivityLabelSource.Current);
            return ToList(sensitivityLabel);
        }

        internal List<SensitivityLabel> GetManagedDatabaseSensitivityLabel(string resourceGroupName, string managedInstanceName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            SensitivityLabel sensitivityLabel =
                GetCurrentSqlManagementClient().ManagedDatabaseSensitivityLabels.Get(
                    resourceGroupName, managedInstanceName, databaseName, schemaName, tableName, columnName,
                    SensitivityLabelSource.Current);
            return ToList(sensitivityLabel);
        }

        internal List<SensitivityLabel> GetCurrentSensitivityLabels(string resourceGroupName,
            string serverName, string databaseName)
        {
            return IterateOverPages(
                () => GetCurrentSqlManagementClient().SensitivityLabels.ListCurrentByDatabase(
                    resourceGroupName, serverName, databaseName),
                nextPageLink => GetCurrentSqlManagementClient().SensitivityLabels.ListCurrentByDatabaseNext(nextPageLink));
        }

        internal List<SensitivityLabel> GetRecommendedSensitivityLabels(string resourceGroupName,
            string serverName, string databaseName)
        {
            return IterateOverPages(
                () => GetCurrentSqlManagementClient().SensitivityLabels.ListRecommendedByDatabase(
                    resourceGroupName, serverName, databaseName),
                nextPageLink => GetCurrentSqlManagementClient().SensitivityLabels.ListRecommendedByDatabaseNext(nextPageLink));
        }

        internal List<SensitivityLabel> GetManagedDatabaseCurrentSensitivityLabels(string resourceGroupName,
            string managedInstanceName, string databaseName)
        {
            return IterateOverPages(
                () => GetCurrentSqlManagementClient().ManagedDatabaseSensitivityLabels.ListCurrentByDatabase(
                    resourceGroupName, managedInstanceName, databaseName),
                nextPageLink => GetCurrentSqlManagementClient().ManagedDatabaseSensitivityLabels.ListCurrentByDatabaseNext(nextPageLink));
        }

        internal List<SensitivityLabel> GetManagedDatabaseRecommendedSensitivityLabels(string resourceGroupName,
            string managedInstanceName, string databaseName)
        {
            return IterateOverPages(
                () => GetCurrentSqlManagementClient().ManagedDatabaseSensitivityLabels.ListRecommendedByDatabase(
                    resourceGroupName, managedInstanceName, databaseName),
                nextPageLink => GetCurrentSqlManagementClient().ManagedDatabaseSensitivityLabels.ListRecommendedByDatabaseNext(nextPageLink));
        }

        private List<SensitivityLabel> IterateOverPages(
            Func<IPage<SensitivityLabel>> listByDatabase,
            Func<string, IPage<SensitivityLabel>> listByNextPageLink)
        {
            IPage<SensitivityLabel> sensitivityLabelsPage = listByDatabase();
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

        private ISqlManagementClient GetCurrentSqlManagementClient()
        {
            if (SqlManagementClient == null)
            {
                SqlManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }

            return SqlManagementClient;
        }
    }
}
