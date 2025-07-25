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
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Services
{
    internal class DataClassificationEndpointsCommunicator
    {
        private SqlManagementClient SqlManagementClient { get; set; }

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

        internal void PatchSensitivityLabels(string resourceGroupName, string serverName, string databaseName,
            PatchOperations operations)
        {
            PatchOperations(resourceGroupName, serverName, databaseName, operations,
                isManagedInstance: false, currentOrRecommended: "current");
        }

        internal void PatchManagedDatabaseSensitivityLabels(string resourceGroupName, string managedInstanceName, string databaseName,
            PatchOperations operations)
        {
            PatchOperations(resourceGroupName, managedInstanceName, databaseName, operations,
                isManagedInstance: true, currentOrRecommended: "current");
        }

        internal void PatchSensitivityRecommendations(string resourceGroupName, string serverName, string databaseName,
            PatchOperations operations)
        {
            PatchOperations(resourceGroupName, serverName, databaseName, operations,
                isManagedInstance: false, currentOrRecommended: "recommended");
        }

        internal void PatchManagedDatabaseSensitivityRecommendations(string resourceGroupName, string managedInstanceName, string databaseName,
            PatchOperations operations)
        {
            PatchOperations(resourceGroupName, managedInstanceName, databaseName, operations,
                isManagedInstance: true, currentOrRecommended: "recommended");
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
            SensitivityLabel sensitivityLabel = GetSensitivityLabel(() =>
                GetCurrentSqlManagementClient().SensitivityLabels.Get(
                    resourceGroupName, serverName, databaseName, schemaName, tableName, columnName,
                    SensitivityLabelSource.Current));

            return ToList(sensitivityLabel);
        }

        internal List<SensitivityLabel> GetManagedDatabaseSensitivityLabel(string resourceGroupName, string managedInstanceName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            SensitivityLabel sensitivityLabel = GetSensitivityLabel(() =>
                GetCurrentSqlManagementClient().ManagedDatabaseSensitivityLabels.Get(
                    resourceGroupName, managedInstanceName, databaseName, schemaName, tableName, columnName,
                    SensitivityLabelSource.Current));

            return ToList(sensitivityLabel);
        }

        private SensitivityLabel GetSensitivityLabel(Func<SensitivityLabel> getSensitivityLabelFromServer)
        {
            SensitivityLabel sensitivityLabel = null;
            try
            {
                sensitivityLabel = getSensitivityLabelFromServer();
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

        internal void EnableSensitivityRecommendation(string resourceGroupName, string serverName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            GetCurrentSqlManagementClient().SensitivityLabels.EnableRecommendation(resourceGroupName, serverName, databaseName,
                schemaName, tableName, columnName);
        }

        internal void DisableSensitivityRecommendation(string resourceGroupName, string serverName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            GetCurrentSqlManagementClient().SensitivityLabels.DisableRecommendation(resourceGroupName, serverName, databaseName,
                schemaName, tableName, columnName);
        }

        internal void EnableManagedDatabaseSensitivityRecommendation(string resourceGroupName, string managedInstanceName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            GetCurrentSqlManagementClient().ManagedDatabaseSensitivityLabels.EnableRecommendation(resourceGroupName, managedInstanceName, databaseName,
                schemaName, tableName, columnName);
        }

        internal void DisableManagedDatabaseSensitivityRecommendation(string resourceGroupName, string managedInstanceName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            GetCurrentSqlManagementClient().ManagedDatabaseSensitivityLabels.DisableRecommendation(resourceGroupName, managedInstanceName, databaseName,
                schemaName, tableName, columnName);
        }

        private void PatchOperations(string resourceGroupName, string serverName, string databaseName,
            PatchOperations operations, bool isManagedInstance, string currentOrRecommended)
        {
            Uri endpoint = Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager);
            string uri = $"{endpoint}/subscriptions/{Subscription.Id}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/{(isManagedInstance ? "managedInstances" : "servers")}/{serverName}/databases/{databaseName}/{currentOrRecommended}SensitivityLabels?api-version={(isManagedInstance ? "2018-06-01-preview" : "2017-03-01-preview")}";
            string content = JsonConvert.SerializeObject(operations, new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>() { new Rest.Serialization.TransformationJsonConverter() },
                NullValueHandling = NullValueHandling.Ignore
            });

            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                Method = new HttpMethod("Patch"),
                RequestUri = new Uri(uri),
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };

            SqlManagementClient client = GetCurrentSqlManagementClient();
            client.Credentials.ProcessHttpRequestAsync(httpRequest, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            HttpResponseMessage response = client.HttpClient.SendAsync(httpRequest, CancellationToken.None).Result;
            response.EnsureSuccessStatusCode();
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

        private SqlManagementClient GetCurrentSqlManagementClient()
        {
            if (SqlManagementClient == null)
            {
                SqlManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }

            return SqlManagementClient;
        }
    }
}
