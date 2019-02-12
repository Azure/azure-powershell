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

        internal IList<SensitivityLabel> GetSensitivityLabel(string resourceGroupName, string serverName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            SensitivityLabel sensitivityLabel =
                GetCurrentSqlManagementClient().SensitivityLabels.Get(
                    resourceGroupName, serverName, databaseName, schemaName, tableName, columnName,
                    SensitivityLabelSource.Current);
            return ToList(sensitivityLabel);
        }

        internal IList<SensitivityLabel> GetManagedDatabaseSensitivityLabel(string resourceGroupName, string managedInstanceName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            SensitivityLabel sensitivityLabel =
                GetCurrentSqlManagementClient().ManagedDatabaseSensitivityLabels.Get(
                    resourceGroupName, managedInstanceName, databaseName, schemaName, tableName, columnName,
                    SensitivityLabelSource.Current);
            return ToList(sensitivityLabel);
        }

        internal IList<SensitivityLabel> GetCurrentSensitivityLabels(string resourceGroupName,
            string serverName, string databaseName)
        {
            return IterateOverPages(
                () => GetCurrentSqlManagementClient().SensitivityLabels.ListCurrentByDatabase(
                    resourceGroupName, serverName, databaseName),
                nextPageLink => GetCurrentSqlManagementClient().SensitivityLabels.ListCurrentByDatabaseNext(nextPageLink));
        }

        internal IList<SensitivityLabel> GetRecommendedSensitivityLabels(string resourceGroupName,
            string serverName, string databaseName)
        {
            return IterateOverPages(
                () => GetCurrentSqlManagementClient().SensitivityLabels.ListRecommendedByDatabase(
                    resourceGroupName, serverName, databaseName),
                nextPageLink => GetCurrentSqlManagementClient().SensitivityLabels.ListRecommendedByDatabaseNext(nextPageLink));
        }

        internal IList<SensitivityLabel> GetManagedDatabaseCurrentSensitivityLabels(string resourceGroupName,
            string managedInstanceName, string databaseName)
        {
            return IterateOverPages(
                () => GetCurrentSqlManagementClient().ManagedDatabaseSensitivityLabels.ListCurrentByDatabase(
                    resourceGroupName, managedInstanceName, databaseName),
                nextPageLink => GetCurrentSqlManagementClient().ManagedDatabaseSensitivityLabels.ListCurrentByDatabaseNext(nextPageLink));
        }

        internal IList<SensitivityLabel> GetManagedDatabaseRecommendedSensitivityLabels(string resourceGroupName,
            string managedInstanceName, string databaseName)
        {
            return IterateOverPages(
                () => GetCurrentSqlManagementClient().ManagedDatabaseSensitivityLabels.ListRecommendedByDatabase(
                    resourceGroupName, managedInstanceName, databaseName),
                nextPageLink => GetCurrentSqlManagementClient().ManagedDatabaseSensitivityLabels.ListRecommendedByDatabaseNext(nextPageLink));
        }

        private IList<SensitivityLabel> IterateOverPages(
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
