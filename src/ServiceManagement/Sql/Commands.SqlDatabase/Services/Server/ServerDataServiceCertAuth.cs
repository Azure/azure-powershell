// ----------------------------------------------------------------------------------
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Properties;
using Microsoft.WindowsAzure.Management.Sql;
using Microsoft.WindowsAzure.Management.Sql.Models;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server
{
    using DatabaseCopyModel = Model.DatabaseCopy;
    using WamlDatabaseCopy = Management.Sql.Models.DatabaseCopy;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure;

    /// <summary>
    /// Implementation of the <see cref="IServerDataServiceContext"/> with Certificate authentication.
    /// </summary>
    public partial class ServerDataServiceCertAuth : IServerDataServiceContext
    {
        #region Private Fields

        /// <summary>
        /// The previous request's client request ID
        /// </summary>
        private string clientRequestId;

        /// <summary>
        /// The name of the server we are connected to.
        /// </summary>
        private readonly string serverName;

        /// <summary>
        /// The subscription used to connect and authenticate.
        /// </summary>
        private readonly AzureSubscription subscription;

        private AzureSMProfile profile;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerDataServiceCertAuth"/> class
        /// </summary>
        /// <param name="subscription">The subscription used to connect and authenticate.</param>
        /// <param name="serverName">The name of the server to connect to.</param>
        private ServerDataServiceCertAuth(
            AzureSMProfile profile,
            AzureSubscription subscription,
            string serverName)
        {
            this.profile = profile;
            this.serverName = serverName;
            this.subscription = subscription;
        }

        #region Public Properties

        /// <summary>
        /// Gets the client per-session tracing ID.
        /// </summary>
        public string ClientSessionId
        {
            get
            {
                return SqlDatabaseCmdletBase.clientSessionId;
            }
        }

        /// <summary>
        /// Gets the previous request's client request ID.
        /// </summary>
        public string ClientRequestId
        {
            get
            {
                return this.clientRequestId;
            }
        }

        /// <summary>
        /// Gets the name of the server for this context.
        /// </summary>
        public string ServerName
        {
            get
            {
                return this.serverName;
            }
        }

        #endregion

        /// <summary>
        /// Creates and returns a new instance of the <see cref="ServerDataServiceCertAuth"/> class
        /// which connects to the specified server using the specified subscription credentials.
        /// </summary>
        /// <param name="subscription">The subscription used to connect and authenticate.</param>
        /// <param name="serverName">The name of the server to connect to.</param>
        /// <returns>An instance of <see cref="ServerDataServiceCertAuth"/> class.</returns>
        public static ServerDataServiceCertAuth Create(
            string serverName,
            AzureSMProfile profile,
            AzureSubscription subscription)
        {
            if (string.IsNullOrEmpty(serverName))
            {
                throw new ArgumentException("serverName");
            }

            SqlDatabaseCmdletBase.ValidateSubscription(subscription);

            // Create a new ServerDataServiceCertAuth object to be used
            return new ServerDataServiceCertAuth(
                profile,
                subscription,
                serverName);
        }

        #region IServerDataServiceContext Members

        /// <summary>
        /// Ensures any extra property on the given <paramref name="obj"/> is loaded.
        /// </summary>
        /// <param name="obj">The object that needs the extra properties.</param>
        public void LoadExtraProperties(object obj)
        {
            try
            {
                Database database = obj as Database;
                if (database != null)
                {
                    this.LoadExtraProperties(database);
                    return;
                }

                RestorableDroppedDatabase restorableDroppedDatabase = obj as RestorableDroppedDatabase;
                if (restorableDroppedDatabase != null)
                {
                    this.LoadExtraProperties(restorableDroppedDatabase);
                    return;
                }
            }
            catch
            {
                // Ignore exceptions when loading extra properties, for backward compatibility.
            }
        }

        #endregion

        #region Database Operations

        /// <summary>
        /// Gets a list of all the databases in the current context.
        /// </summary>
        /// <returns>An array of databases in the current context</returns>
        public Database[] GetDatabases()
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            // Retrieve the list of databases
            DatabaseListResponse response = sqlManagementClient.Databases.List(this.serverName);

            // Construct the resulting Database objects
            Database[] databases = CreateDatabaseFromResponse(response);
            return databases;
        }

        /// <summary>
        /// Retrieve a specific database from the current context
        /// </summary>
        /// <param name="databaseName">The name of the database to retrieve</param>
        /// <returns>A database object</returns>
        public Database GetDatabase(string databaseName)
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            // Retrieve the specified database
            DatabaseGetResponse response = sqlManagementClient.Databases.Get(
                this.serverName,
                databaseName);

            // Construct the resulting Database object
            Database database = CreateDatabaseFromResponse(response);
            return database;
        }


        /// <summary>
        /// Retrieve a specific database from the current context
        /// </summary>
        /// <param name="databaseName">The name of the database to retrieve</param>
        /// <returns>A database object</returns>
        public IEnumerable<DatabaseUsageMetric> GetDatabaseUsages(string databaseName)
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            // Retrieve the specified database
            DatabaseUsagesListResponse response = sqlManagementClient.Databases.GetUsages(
                this.serverName,
                databaseName);

            // Construct the resulting Database object
            IEnumerable<DatabaseUsageMetric> metrics = CreateMetricsFromResponse(response);
            return metrics;
        }

        /// <summary>
        /// Converts a DatabaseUsagesListResponse into IEnumerable<DatabaseUsageMetric>
        /// </summary>
        /// <param name="response">The response to convert</param>
        /// <returns></returns>
        private IEnumerable<DatabaseUsageMetric> CreateMetricsFromResponse(DatabaseUsagesListResponse response)
        {
            List<DatabaseUsageMetric> list = new List<DatabaseUsageMetric>();

            foreach (var usage in response.Usages)
            {
                list.Add(new DatabaseUsageMetric()
                    {
                        CurrentValue = usage.CurrentValue,
                        Limit = usage.Limit,
                        Name = usage.Name,
                        NextResetTime = usage.NextResetTime,
                        ResourceName = usage.ResourceName,
                        Unit = usage.Unit,
                    });
            }

            return list;
        }

        /// <summary>
        /// Creates a new sql database.
        /// </summary>
        /// <param name="databaseName">The name for the new database</param>
        /// <param name="databaseMaxSizeInGB">The maximum size of the new database</param>
        /// <param name="databaseCollation">The collation for the new database</param>
        /// <param name="databaseEdition">The edition for the new database</param>
        /// <returns>The newly created Sql Database</returns>
        public Database CreateNewDatabase(
            string databaseName,
            int? databaseMaxSizeInGB,
            long? databaseMaxSizeInBytes,
            string databaseCollation,
            DatabaseEdition databaseEdition,
            ServiceObjective serviceObjective)
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            DatabaseCreateParameters parameters = new DatabaseCreateParameters()
            {
                Name = databaseName,
                Edition = databaseEdition != DatabaseEdition.None ?
                    databaseEdition.ToString() : null,
                CollationName = databaseCollation ?? string.Empty,
                MaximumDatabaseSizeInGB = databaseMaxSizeInGB,
                MaximumDatabaseSizeInBytes = databaseMaxSizeInBytes,
                ServiceObjectiveId = serviceObjective != null ? serviceObjective.Id.ToString() : null,
            };

            // Create the database
            DatabaseCreateResponse response = sqlManagementClient.Databases.Create(
                this.serverName,
                parameters);

            // Construct the resulting Database object
            Database database = CreateDatabaseFromResponse(response);
            return database;
        }

        /// <summary>
        /// Update a database on the server.
        /// </summary>
        /// <param name="databaseName">The name of the database to modify.</param>
        /// <param name="newDatabaseName">The new name of the database.</param>
        /// <param name="databaseMaxSizeInGB">The new maximum size of the database.</param>
        /// <param name="databaseEdition">The new edition of the database.</param>
        /// <param name="serviceObjective">The new service objective of the database.</param>
        /// <returns>The updated database.</returns>
        public Database UpdateDatabase(
            string databaseName,
            string newDatabaseName,
            int? databaseMaxSizeInGB,
            long? databaseMaxSizeInBytes,
            DatabaseEdition? databaseEdition,
            ServiceObjective serviceObjective)
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            // Retrieve the specified database
            DatabaseGetResponse database = sqlManagementClient.Databases.Get(
                this.serverName,
                databaseName);

            DatabaseUpdateParameters parameters = new DatabaseUpdateParameters()
            {
                Name = !string.IsNullOrEmpty(newDatabaseName) ? newDatabaseName : database.Database.Name,
                MaximumDatabaseSizeInGB = databaseMaxSizeInGB,
                MaximumDatabaseSizeInBytes = databaseMaxSizeInBytes,
            };
            parameters.Edition = (database.Database.Edition ?? string.Empty);
            if (databaseEdition.HasValue)
            {
                if (databaseEdition != DatabaseEdition.None)
                {
                    parameters.Edition = databaseEdition.ToString();
                }
            }
            parameters.ServiceObjectiveId = database.Database.ServiceObjectiveId;
            if (serviceObjective != null)
            {
                parameters.ServiceObjectiveId = serviceObjective.Id.ToString();
            }

            // Update the database with the new properties
            DatabaseUpdateResponse response = sqlManagementClient.Databases.Update(
                this.serverName,
                databaseName,
                parameters
                );

            // Construct the resulting Database object
            Database updatedDatabase = CreateDatabaseFromResponse(response);
            return updatedDatabase;
        }

        /// <summary>
        /// Remove a database from a server
        /// </summary>
        /// <param name="databaseName">The name of the database to delete</param>
        public void RemoveDatabase(string databaseName)
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            // Retrieve the list of databases
            AzureOperationResponse response = sqlManagementClient.Databases.Delete(
                this.serverName,
                databaseName);
        }

        #endregion

        #region Service Objective Operations

        private ServiceObjective[] objectivesCache;
        private ServiceObjective[] Objectives
        {
            get
            {
                if (objectivesCache == null)
                {
                    PopulateSloCache();
                }
                return objectivesCache;
            }
        }

        private void PopulateSloCache()
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            // Retrieve the specified database
            ServiceObjectiveListResponse response = sqlManagementClient.ServiceObjectives.List(this.serverName);

            // Populate the cache;
            objectivesCache = response.Select(serviceObjective => CreateServiceObjectiveFromResponse(serviceObjective)).ToArray();
        }

        /// <summary>
        /// Retrieves the list of all service objectives on the server.
        /// </summary>
        /// <returns>An array of all service objectives on the server.</returns>
        public ServiceObjective[] GetServiceObjectives()
        {
            return Objectives;
        }

        /// <summary>
        /// Retrieve information on service objective with the specified name
        /// </summary>
        /// <param name="serviceObjectiveName">The service objective to retrieve.</param>
        /// <returns>
        /// An object containing the information about the specific service objective.
        /// </returns>
        public ServiceObjective GetServiceObjective(string serviceObjectiveName)
        {
            var serviceObjective = Objectives.Where(s => s.Name == serviceObjectiveName).FirstOrDefault();

            if (serviceObjective == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.ServiceObjectiveNotFound,
                        this.ServerName,
                        serviceObjectiveName));
            }
            return serviceObjective;
        }

        /// <summary>
        /// Retrieve information on latest service objective with service objective
        /// </summary>
        /// <param name="serviceObjectiveToRefresh">The service objective to refresh.</param>
        /// <returns>
        /// An object containing the information about the specific service objective.
        /// </returns>
        public ServiceObjective GetServiceObjective(ServiceObjective serviceObjectiveToRefresh)
        {
            var serviceObjective = Objectives.Where(s => s.Id == serviceObjectiveToRefresh.Id).FirstOrDefault();

            if (serviceObjective == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.ServiceObjectiveNotFound,
                        this.ServerName,
                        serviceObjectiveToRefresh.Id));
            }

            return serviceObjective;
        }

        /// <summary>
        /// Get a specific quota for a server
        /// </summary>
        /// <param name="quotaName">The name of the quota to retrieve</param>
        /// <returns>A quota object.</returns>
        public ServerQuota GetQuota(string quotaName)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get a list of all quotas for a server
        /// </summary>
        /// <returns>An array of server quota objects</returns>
        public ServerQuota[] GetQuotas()
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Database Operation Functions

        /// <summary>
        /// Retrieve information on operation with the guid 
        /// </summary>
        /// <param name="OperationGuid">The Guid of the operation to retrieve.</param>
        /// <returns>An object containing the information about the specific operation.</returns>
        public DatabaseOperation GetDatabaseOperation(Guid OperationGuid)
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            // Retrieve the specified Operation
            DatabaseOperationGetResponse response = sqlManagementClient.DatabaseOperations.Get(
                this.serverName,
                OperationGuid.ToString());

            // Construct the resulting Operation object
            DatabaseOperation operation = CreateDatabaseOperationFromResponse(response);
            return operation;
        }

        /// <summary>
        /// Retrieves the list of all operations on the database.
        /// </summary>
        /// <param name="databaseName">The name of database to retrieve operations.</param>
        /// <returns>An array of all operations on the database.</returns>
        public DatabaseOperation[] GetDatabaseOperations(string databaseName)
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            // Retrieve all operations on specified database
            DatabaseOperationListResponse response = sqlManagementClient.DatabaseOperations.ListByDatabase(
                this.serverName,
                databaseName);

            // For any database which has ever been created, there should be at least one operation
            if (response.Count() == 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.DatabaseOperationNotFoundOnDatabase,
                        this.ServerName,
                        databaseName));
            }

            // Construct the resulting database operations
            DatabaseOperation[] operations = CreateDatabaseOperationsFromResponse(response);
            return operations;
        }

        /// <summary>
        /// Retrieves the list of all databases' operations on the server.
        /// </summary>
        /// <returns>An array of all operations on the server.</returns>
        public DatabaseOperation[] GetDatabasesOperations()
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            // Retrieve the operations on specified server 
            // We do not validate the number of operations returned since it's possible that there is no 
            // database operations on a new created server.
            DatabaseOperationListResponse response = sqlManagementClient.DatabaseOperations.ListByServer(
                this.serverName);

            // Construct the resulting database operations array
            DatabaseOperation[] operations = CreateDatabaseOperationsFromResponse(response);
            return operations;
        }

        #endregion

        #region Database copy operations

        /// <summary>
        /// Retrieve all database copy objects with matching parameters.
        /// </summary>
        /// <param name="databaseName">The name of the database to copy.</param>
        /// <param name="partnerServer">The name for the partner server.</param>
        /// <param name="partnerDatabaseName">The name of the database on the partner server.</param>
        /// <returns>All database copy objects with matching parameters.</returns>
        public DatabaseCopyModel[] GetDatabaseCopy(
            string databaseName,
            string partnerServer,
            string partnerDatabaseName)
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            IEnumerable<WamlDatabaseCopy> copyResponses = null;
            if (databaseName != null)
            {
                copyResponses = sqlManagementClient.DatabaseCopies.List(this.ServerName, databaseName);
            }
            else
            {
                // We want to list all of the copies on the server. Currently, the server-side API doesn't
                // directly support that. It may at some time in the future, but until then we're doing the
                // following to avoid breaking compatibility.
                copyResponses = Enumerable.Empty<WamlDatabaseCopy>();

                DatabaseListResponse dbListResponse = sqlManagementClient.Databases.List(this.ServerName);

                // Iterate through the server's databases and add each set of copies to our list.
                foreach (var database in dbListResponse)
                {
                    copyResponses = copyResponses.Concat(
                        sqlManagementClient.DatabaseCopies.List(this.ServerName, database.Name));
                }
            }

            // Filter the copies by the specified criteria.
            DatabaseCopyModel[] databaseCopies = copyResponses.Where(copy =>
                {
                    if (copy.IsLocalDatabaseReplicationTarget)
                    {
                        return (partnerServer ?? copy.SourceServerName) == copy.SourceServerName
                               && (partnerDatabaseName ?? copy.SourceDatabaseName) == copy.SourceDatabaseName;
                    }
                    else
                    {
                        return (partnerServer ?? copy.DestinationServerName) == copy.DestinationServerName
                               && (partnerDatabaseName ?? copy.DestinationDatabaseName) == copy.DestinationDatabaseName;
                    }
                })
                .Select(CreateDatabaseCopyFromResponse)
                .ToArray();

            return databaseCopies;
        }

        /// <summary>
        /// Refreshes the given database copy object.
        /// </summary>
        /// <param name="databaseCopy">The object to refresh.</param>
        /// <returns>The refreshed database copy object.</returns>
        public DatabaseCopyModel GetDatabaseCopy(DatabaseCopyModel databaseCopy)
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            // Figure out which database is local, as that's the one we need to pass in.
            string localDatabaseName =
                databaseCopy.IsLocalDatabaseReplicationTarget
                    ? databaseCopy.DestinationDatabaseName
                    : databaseCopy.SourceDatabaseName;

            DatabaseCopyModel refreshedDatabaseCopy = CreateDatabaseCopyFromResponse(
                sqlManagementClient.DatabaseCopies.Get(
                    this.ServerName,
                    localDatabaseName,
                    databaseCopy.EntityId.ToString())
                    .DatabaseCopy);

            return refreshedDatabaseCopy;
        }

        /// <summary>
        /// Start database copy on the database with the name <paramref name="databaseName"/>.
        /// </summary>
        /// <param name="databaseName">The name of the database to copy.</param>
        /// <param name="partnerServer">The name for the partner server.</param>
        /// <param name="partnerDatabaseName">The name of the database on the partner server.</param>
        /// <param name="continuousCopy"><c>true</c> to make this a continuous copy.</param>
        /// <param name="isOfflineSecondary"><c>true</c> to make this an offline secondary copy.</param>
        /// <returns>The new instance of database copy operation.</returns>
        public DatabaseCopyModel StartDatabaseCopy(
            string databaseName,
            string partnerServer,
            string partnerDatabaseName,
            bool continuousCopy,
            bool isOfflineSecondary)
        {
            // Create a new request Id for this operation
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            DatabaseCopyCreateResponse response = sqlManagementClient.DatabaseCopies.Create(
                this.ServerName,
                databaseName,
                new DatabaseCopyCreateParameters()
                    {
                        PartnerServer = partnerServer,
                        PartnerDatabase = partnerDatabaseName,
                        IsContinuous = continuousCopy,
                        IsOfflineSecondary = isOfflineSecondary,
                    });

            return CreateDatabaseCopyFromResponse(response.DatabaseCopy);
        }

        /// <summary>
        /// Terminate an ongoing database copy operation.
        /// </summary>
        /// <param name="databaseCopy">The database copy to terminate.</param>
        /// <param name="forcedTermination"><c>true</c> to forcefully terminate the copy.</param>
        public void StopDatabaseCopy(
            DatabaseCopyModel databaseCopy,
            bool forcedTermination)
        {
            // Create a new request Id for this operation
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            // Get the local database, as it's the one we need to pass in.
            string localDatabaseName =
                databaseCopy.IsLocalDatabaseReplicationTarget
                    ? databaseCopy.DestinationDatabaseName
                    : databaseCopy.SourceDatabaseName;

            // Update forced termination so that the terminate happens
            // the way it should.
            sqlManagementClient.DatabaseCopies.Update(
                this.ServerName,
                localDatabaseName,
                databaseCopy.EntityId,
                new DatabaseCopyUpdateParameters() { IsForcedTerminate = forcedTermination });

            sqlManagementClient.DatabaseCopies.Delete(
                this.ServerName,
                localDatabaseName,
                databaseCopy.EntityId);
        }

        #endregion

        #region Restorable Dropped Database Operations

        /// <summary>
        /// Gets a list of all the restorable dropped databases in the current context.
        /// </summary>
        /// <returns>An array of databases in the current context</returns>
        public RestorableDroppedDatabase[] GetRestorableDroppedDatabases()
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            // Retrieve the list of databases
            RestorableDroppedDatabaseListResponse response = sqlManagementClient.RestorableDroppedDatabases.List(this.serverName);

            // Construct the resulting RestorableDroppedDatabase objects
            RestorableDroppedDatabase[] databases = CreateRestorableDroppedDatabaseFromResponse(response);
            return databases;
        }

        /// <summary>
        /// Retrieve information on the restorable dropped database with the name
        /// <paramref name="databaseName"/> and deletion date <paramref name="deletionDate"/>.
        /// </summary>
        /// <param name="databaseName">The name of the restorable dropped database to retrieve.</param>
        /// <param name="deletionDate">The deletion date of the restorable dropped database to retrieve.</param>
        /// <returns>An object containing the information about the specific restorable dropped database.</returns>
        public RestorableDroppedDatabase GetRestorableDroppedDatabase(
            string databaseName, DateTime deletionDate)
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            // Retrieve the specified database
            RestorableDroppedDatabaseGetResponse response = sqlManagementClient.RestorableDroppedDatabases.Get(
                this.serverName,
                databaseName + "," + deletionDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));

            // Construct the resulting RestorableDroppedDatabase object
            RestorableDroppedDatabase database = CreateRestorableDroppedDatabaseFromResponse(response);
            return database;
        }

        #endregion

        #region Restore Database Operations

        /// <summary>
        /// Issues a restore request for the given source database to the given target database.
        /// </summary>
        /// <param name="sourceDatabaseName">The name of the source database.</param>
        /// <param name="sourceDatabaseDeletionDate">The deletion date of the source database, in case it is a dropped database.</param>
        /// <param name="targetServerName">The name of the server to create the restored database on.</param>
        /// <param name="targetDatabaseName">The name of the database to be created with the restored contents.</param>
        /// <param name="pointInTime">The point in time to restore the source database to.</param>
        /// <returns>An object containing the information about the restore request.</returns>
        public RestoreDatabaseOperation RestoreDatabase(
            string sourceDatabaseName,
            DateTime? sourceDatabaseDeletionDate,
            string targetServerName,
            string targetDatabaseName,
            DateTime? pointInTime)
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();

            // Get the SQL management client
            SqlManagementClient sqlManagementClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(this.profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            this.AddTracingHeaders(sqlManagementClient);

            // Create the restore operation
            RestoreDatabaseOperationCreateResponse response = sqlManagementClient.RestoreDatabaseOperations.Create(
                this.serverName,
                new RestoreDatabaseOperationCreateParameters()
                {
                    SourceDatabaseName = sourceDatabaseName,
                    SourceDatabaseDeletionDate = sourceDatabaseDeletionDate,
                    TargetServerName = targetServerName,
                    TargetDatabaseName = targetDatabaseName,
                    PointInTime = pointInTime
                });

            RestoreDatabaseOperation restoreDatabaseOperation = CreateRestoreDatabaseOperationFromResponse(response);
            return restoreDatabaseOperation;
        }

        #endregion

        #region Helper functions

        private DimensionSetting CreateDimensionSettings(string name, string id, string description, byte ordinal, bool isDefault)
        {
            return new DimensionSetting()
            {
                Name = name,
                Id = Guid.Parse(id),
                Description = description,
                Ordinal = ordinal,
                IsDefault = isDefault
            };
        }

        private Collection<DimensionSetting> CreateDimensionSettingsFromResponse(IList<Management.Sql.Models.ServiceObjective.DimensionSettingResponse> dimensionSettingsList)
        {
            Collection<DimensionSetting> result = new Collection<DimensionSetting>();
            foreach (var response in dimensionSettingsList)
            {
                result.Add(CreateDimensionSettings(
                    response.Name,
                    response.Id,
                    response.Description,
                    response.Ordinal,
                    response.IsDefault
                    ));
            }
            return result;
        }

        private ServiceObjective CreateServiceObjectiveFromResponse(Management.Sql.Models.ServiceObjective response)
        {
            return new ServiceObjective()
            {
                Name = response.Name,
                Id = Guid.Parse(response.Id),
                IsDefault = response.IsDefault,
                IsSystem = response.IsSystem,
                Enabled = response.Enabled,
                Description = response.Description,
                Context = this,
                DimensionSettings = CreateDimensionSettingsFromResponse(response.DimensionSettings)
            };
        }

        private DatabaseOperation CreateDatabaseOperation(string name, string state, string id, int stateId, string sessionActivityId, string databaseName, int percentComplete, int errorCode, string error, int errorSeverity, int errorState, DateTime startTime, DateTime lastModifyTime)
        {
            return new DatabaseOperation()
            {
                Name = name,
                State = state,
                Id = Guid.Parse(id),
                StateId = stateId,
                SessionActivityId = Guid.Parse(sessionActivityId),
                DatabaseName = databaseName,
                PercentComplete = percentComplete,
                ErrorCode = errorCode,
                Error = error,
                ErrorSeverity = errorSeverity,
                ErrorState = errorState,
                StartTime = startTime,
                LastModifyTime = lastModifyTime,
            };
        }

        private DatabaseOperation CreateDatabaseOperationFromResponse(DatabaseOperationGetResponse response)
        {
            return CreateDatabaseOperation(
                    response.DatabaseOperation.Name,
                    response.DatabaseOperation.State,
                    response.DatabaseOperation.Id,
                    response.DatabaseOperation.StateId,
                    response.DatabaseOperation.SessionActivityId,
                    response.DatabaseOperation.DatabaseName,
                    response.DatabaseOperation.PercentComplete,
                    response.DatabaseOperation.ErrorCode,
                    response.DatabaseOperation.Error,
                    response.DatabaseOperation.ErrorSeverity,
                    response.DatabaseOperation.ErrorState,
                    response.DatabaseOperation.StartTime,
                    response.DatabaseOperation.LastModifyTime
                    );
        }

        private DatabaseOperation[] CreateDatabaseOperationsFromResponse(DatabaseOperationListResponse response)
        {
            return response.DatabaseOperations.Select(dbOperation => CreateDatabaseOperation(
                    dbOperation.Name,
                    dbOperation.State,
                    dbOperation.Id,
                    dbOperation.StateId,
                    dbOperation.SessionActivityId,
                    dbOperation.DatabaseName,
                    dbOperation.PercentComplete,
                    dbOperation.ErrorCode,
                    dbOperation.Error,
                    dbOperation.ErrorSeverity,
                    dbOperation.ErrorState,
                    dbOperation.StartTime,
                    dbOperation.LastModifyTime)).ToArray();
        }


        /// <summary>
        /// Given a <see cref="DatabaseGetResponse"/> this will create and return a <see cref="Database"/>
        /// object with the fields filled in.
        /// </summary>
        /// <param name="response">The response to turn into a <see cref="Database"/></param>
        /// <returns>A <see cref="Database"/> object.</returns>
        private Database CreateDatabaseFromResponse(DatabaseGetResponse response)
        {
            return this.CreateDatabaseFromResponse(
                response.Database.Id,
                response.Database.Name,
                response.Database.CreationDate,
                response.Database.Edition,
                response.Database.CollationName,
                response.Database.MaximumDatabaseSizeInGB,
                response.Database.MaximumDatabaseSizeInBytes,
                response.Database.IsFederationRoot,
                response.Database.IsSystemObject,
                response.Database.SizeMB,
                response.Database.ServiceObjectiveAssignmentErrorCode,
                response.Database.ServiceObjectiveAssignmentErrorDescription,
                response.Database.ServiceObjectiveAssignmentState,
                response.Database.ServiceObjectiveAssignmentStateDescription,
                response.Database.ServiceObjectiveAssignmentSuccessDate,
                response.Database.ServiceObjectiveId,
                response.Database.AssignedServiceObjectiveId,
                response.Database.RecoveryPeriodStartDate,
                response.Database.State);
        }

        /// <summary>
        /// Given a <see cref="DatabaseListResponse"/> this will create and return an array of <see cref="Database"/>
        /// objects with the fields filled in.
        /// </summary>
        /// <param name="response">The response to turn into an array of <see cref="Database"/> objects</param>
        /// <returns>An array of <see cref="Database"/> objects.</returns>
        private Database[] CreateDatabaseFromResponse(DatabaseListResponse response)
        {
            return response.Databases.Select(db => this.CreateDatabaseFromResponse(
                db.Id,
                db.Name,
                db.CreationDate,
                db.Edition,
                db.CollationName,
                db.MaximumDatabaseSizeInGB,
                db.MaximumDatabaseSizeInBytes,
                db.IsFederationRoot,
                db.IsSystemObject,
                db.SizeMB,
                db.ServiceObjectiveAssignmentErrorCode,
                db.ServiceObjectiveAssignmentErrorDescription,
                db.ServiceObjectiveAssignmentState,
                db.ServiceObjectiveAssignmentStateDescription,
                db.ServiceObjectiveAssignmentSuccessDate,
                db.ServiceObjectiveId,
                db.AssignedServiceObjectiveId,
                db.RecoveryPeriodStartDate,
                db.State)).ToArray();
        }

        /// <summary>
        /// Given a <see cref="DatabaseCreateResponse"/> this will create and return a <see cref="Database"/>
        /// object with the fields filled in.
        /// </summary>
        /// <param name="response">The response to turn into a <see cref="Database"/></param>
        /// <returns>A <see cref="Database"/> object.</returns>
        private Database CreateDatabaseFromResponse(DatabaseCreateResponse response)
        {
            return this.CreateDatabaseFromResponse(
               response.Database.Id,
               response.Database.Name,
               response.Database.CreationDate,
               response.Database.Edition,
               response.Database.CollationName,
               response.Database.MaximumDatabaseSizeInGB,
               response.Database.MaximumDatabaseSizeInBytes,
               response.Database.IsFederationRoot,
               response.Database.IsSystemObject,
               response.Database.SizeMB,
               response.Database.ServiceObjectiveAssignmentErrorCode,
               response.Database.ServiceObjectiveAssignmentErrorDescription,
               response.Database.ServiceObjectiveAssignmentState,
               response.Database.ServiceObjectiveAssignmentStateDescription,
               response.Database.ServiceObjectiveAssignmentSuccessDate,
               response.Database.ServiceObjectiveId,
               response.Database.AssignedServiceObjectiveId,
               response.Database.RecoveryPeriodStartDate,
               response.Database.State);
        }

        /// <summary>
        /// Given a <see cref="DatabaseUpdateResponse"/> this will create and return a <see cref="Database"/>
        /// object with the fields filled in.
        /// </summary>
        /// <param name="response">The response to turn into a <see cref="Database"/></param>
        /// <returns>A <see cref="Database"/> object.</returns>
        private Database CreateDatabaseFromResponse(DatabaseUpdateResponse response)
        {
            return this.CreateDatabaseFromResponse(
                response.Database.Id,
                response.Database.Name,
                response.Database.CreationDate,
                response.Database.Edition,
                response.Database.CollationName,
                response.Database.MaximumDatabaseSizeInGB,
                response.Database.MaximumDatabaseSizeInBytes,
                response.Database.IsFederationRoot,
                response.Database.IsSystemObject,
                response.Database.SizeMB,
                response.Database.ServiceObjectiveAssignmentErrorCode,
                response.Database.ServiceObjectiveAssignmentErrorDescription,
                response.Database.ServiceObjectiveAssignmentState,
                response.Database.ServiceObjectiveAssignmentStateDescription,
                response.Database.ServiceObjectiveAssignmentSuccessDate,
                response.Database.ServiceObjectiveId,
                response.Database.AssignedServiceObjectiveId,
                response.Database.RecoveryPeriodStartDate,
                response.Database.State);
        }

        /// <summary>
        /// Given a set of database properties this will create and return a <see cref="Database"/>
        /// object with the fields filled in.
        /// </summary>
        /// <param name="id">The database Id.</param>
        /// <param name="name">The database name.</param>
        /// <param name="creationDate">The database creation date.</param>
        /// <param name="edition">The database edition.</param>
        /// <param name="collationName">The database collation name.</param>
        /// <param name="maximumDatabaseSizeInGB">The database maximum size.</param>
        /// <param name="maximumDatabaseSizeInBytes">The database maximum size.</param>
        /// <param name="isFederationRoot">Whether or not the database is a federation root.</param>
        /// <param name="isSystemObject">Whether or not the database is a system object.</param>
        /// <param name="sizeMB">The current database size.</param>
        /// <param name="serviceObjectiveAssignmentErrorCode">
        /// The last error code received for service objective assignment change.
        /// </param>
        /// <param name="serviceObjectiveAssignmentErrorDescription">
        /// The last error received for service objective assignment change.
        /// </param>
        /// <param name="serviceObjectiveAssignmentState">
        /// The state of the current service objective assignment.
        /// </param>
        /// <param name="serviceObjectiveAssignmentStateDescription">
        /// The state description for the current service objective assignment.
        /// </param>
        /// <param name="serviceObjectiveAssignmentSuccessDate">
        /// The last success date for a service objective assignment on this database.
        /// </param>
        /// <param name="serviceObjectiveId">The service objective Id for this database.</param>
        /// <param name="assignedServiceObjectiveId">The assigned service object Id for this database.</param>
        /// <param name="recoveryPeriodStartDate">The start date of the recovery period for this database.</param>
        /// <returns>A <see cref="Database"/> object.</returns>
        private Database CreateDatabaseFromResponse(
            int id,
            string name,
            DateTime creationDate,
            string edition,
            string collationName,
            long maximumDatabaseSizeInGB,
            long maximumDatabaseSizeInBytes,
            bool isFederationRoot,
            bool isSystemObject,
            string sizeMB,
            string serviceObjectiveAssignmentErrorCode,
            string serviceObjectiveAssignmentErrorDescription,
            string serviceObjectiveAssignmentState,
            string serviceObjectiveAssignmentStateDescription,
            string serviceObjectiveAssignmentSuccessDate,
            string serviceObjectiveId,
            string assignedServiceObjectiveId,
            DateTime? recoveryPeriodStartDate,
            string state)
        {
            Database result = new Database()
            {
                Id = id,
                Name = name,
                CollationName = collationName,
                CreationDate = creationDate,
                Edition = edition,
                MaxSizeGB = (int)maximumDatabaseSizeInGB,
                MaxSizeBytes = maximumDatabaseSizeInBytes,
                IsFederationRoot = isFederationRoot,
                IsSystemObject = isSystemObject,
                RecoveryPeriodStartDate = recoveryPeriodStartDate,
            };

            // Parse any additional database information
            if (!string.IsNullOrEmpty(sizeMB))
            {
                result.SizeMB = decimal.Parse(sizeMB, CultureInfo.InvariantCulture);
            }

            // Parse the service objective information
            if (!string.IsNullOrEmpty(assignedServiceObjectiveId))
            {
                Guid guid = Guid.Empty;
                if (Guid.TryParse(assignedServiceObjectiveId, out guid))
                {
                    result.AssignedServiceObjectiveId = guid;
                }
            }
            if (!string.IsNullOrEmpty(serviceObjectiveAssignmentErrorCode))
            {
                result.ServiceObjectiveAssignmentErrorCode = int.Parse(serviceObjectiveAssignmentErrorCode);
            }
            if (!string.IsNullOrEmpty(serviceObjectiveAssignmentErrorDescription))
            {
                result.ServiceObjectiveAssignmentErrorDescription = serviceObjectiveAssignmentErrorDescription;
            }
            if (!string.IsNullOrEmpty(serviceObjectiveAssignmentState))
            {
                result.ServiceObjectiveAssignmentState = byte.Parse(serviceObjectiveAssignmentState);
            }
            if (!string.IsNullOrEmpty(serviceObjectiveAssignmentStateDescription))
            {
                result.ServiceObjectiveAssignmentStateDescription = serviceObjectiveAssignmentStateDescription;
            }
            if (!string.IsNullOrEmpty(serviceObjectiveAssignmentSuccessDate))
            {
                result.ServiceObjectiveAssignmentSuccessDate = DateTime.Parse(serviceObjectiveAssignmentSuccessDate, CultureInfo.InvariantCulture);
            }
            if (!string.IsNullOrEmpty(serviceObjectiveId))
            {
                result.ServiceObjectiveId = Guid.Parse(serviceObjectiveId);
                Guid sloId = Guid.Empty;
                if (Guid.TryParse(serviceObjectiveId, out sloId))
                {
                    result.ServiceObjective = GetServiceObjective(new ServiceObjective() { Id = sloId });
                    if (result.ServiceObjective != null)
                    {
                        result.ServiceObjectiveName = result.ServiceObjective.Name;
                    }
                }
            }
            if (!string.IsNullOrEmpty(state))
            {
                DatabaseStatus status;
                if (Enum.TryParse<DatabaseStatus>(state, true, out status))
                {
                    result.Status = (int)status;
                }
            }

            this.LoadExtraProperties(result);

            return result;
        }

        private static DatabaseCopyModel CreateDatabaseCopyFromResponse(WamlDatabaseCopy response)
        {
            DateTime startDate, modifyDate;
            DateTime.TryParse(response.StartDate, out startDate);
            DateTime.TryParse(response.StartDate, out modifyDate);

            return new DatabaseCopyModel()
                {
                    EntityId = Guid.Parse(response.Name),
                    SourceServerName = response.SourceServerName,
                    SourceDatabaseName = response.SourceDatabaseName,
                    DestinationServerName = response.DestinationServerName,
                    DestinationDatabaseName = response.DestinationDatabaseName,
                    IsContinuous = response.IsContinuous,
                    ReplicationState = response.ReplicationState,
                    ReplicationStateDescription = response.ReplicationStateDescription,
                    LocalDatabaseId = response.LocalDatabaseId,
                    IsLocalDatabaseReplicationTarget = response.IsLocalDatabaseReplicationTarget,
                    IsInterlinkConnected = response.IsInterlinkConnected,
                    StartDate = startDate,
                    ModifyDate = modifyDate,
                    PercentComplete = response.PercentComplete,
                    IsOfflineSecondary = response.IsOfflineSecondary,
                    IsTerminationAllowed = response.IsTerminationAllowed
                };
        }

        /// <summary>
        /// Given a <see cref="RestorableDroppedDatabaseGetResponse"/> this will create and return a <see cref="RestorableDroppedDatabase"/>
        /// object with the fields filled in.
        /// </summary>
        /// <param name="response">The response to turn into a <see cref="RestorableDroppedDatabase"/></param>
        /// <returns>A <see cref="RestorableDroppedDatabase"/> object.</returns>
        private RestorableDroppedDatabase CreateRestorableDroppedDatabaseFromResponse(RestorableDroppedDatabaseGetResponse response)
        {
            return this.CreateRestorableDroppedDatabaseFromResponse(
                response.Database.EntityId,
                response.Database.Name,
                response.Database.ServerName,
                response.Database.Edition,
                response.Database.MaximumDatabaseSizeInBytes,
                response.Database.CreationDate,
                response.Database.DeletionDate,
                response.Database.RecoveryPeriodStartDate);
        }

        /// <summary>
        /// Given a <see cref="RestorableDroppedDatabaseListResponse"/> this will create and return an array of <see cref="RestorableDroppedDatabase"/>
        /// object with the fields filled in.
        /// </summary>
        /// <param name="response">The response to turn into an array of <see cref="RestorableDroppedDatabase"/> objects</param>
        /// <returns>An array of <see cref="RestorableDroppedDatabase"/> objects.</returns>
        private RestorableDroppedDatabase[] CreateRestorableDroppedDatabaseFromResponse(RestorableDroppedDatabaseListResponse response)
        {
            return response.Databases.Select(db => this.CreateRestorableDroppedDatabaseFromResponse(
                db.EntityId,
                db.Name,
                db.ServerName,
                db.Edition,
                db.MaximumDatabaseSizeInBytes,
                db.CreationDate,
                db.DeletionDate,
                db.RecoveryPeriodStartDate)).ToArray();
        }

        /// <summary>
        /// Given a set of restorable dropped database properties this will create and return a <see cref="RestorableDroppedDatabase"/>
        /// object with the fields filled in.
        /// </summary>
        /// <param name="entityId">The entity ID of the database.</param>
        /// <param name="name">The name of the database.</param>
        /// <param name="serverName">The name of the server that contained the database.</param>
        /// <param name="edition">The edition of the database.</param>
        /// <param name="maximumDatabaseSizeInBytes">The maximum size of the database.</param>
        /// <param name="creationDate">The creation date of the database.</param>
        /// <param name="deletionDate">The deletion date of the database.</param>
        /// <param name="recoveryPeriodStartDate">The start date of the recovery period for this database.</param>
        /// <returns>A <see cref="RestorableDroppedDatabase"/> object.</returns>
        private RestorableDroppedDatabase CreateRestorableDroppedDatabaseFromResponse(
            string entityId,
            string name,
            string serverName,
            string edition,
            long maximumDatabaseSizeInBytes,
            DateTime creationDate,
            DateTime deletionDate,
            DateTime? recoveryPeriodStartDate)
        {
            var result = new RestorableDroppedDatabase()
            {
                EntityId = entityId,
                Name = name,
                ServerName = serverName,
                Edition = edition,
                MaxSizeBytes = maximumDatabaseSizeInBytes,
                CreationDate = creationDate,
                DeletionDate = deletionDate,
                RecoveryPeriodStartDate = recoveryPeriodStartDate,
            };

            this.LoadExtraProperties(result);

            return result;
        }

        /// <summary>
        /// Given a <see cref="RestoreDatabaseOperationCreateResponse"/> this will create and return a <see cref="RestoreDatabaseOperation"/>
        /// object with the fields filled in.
        /// </summary>
        /// <param name="response">The response to turn into a <see cref="RestoreDatabaseOperation"/></param>
        /// <returns>A <see cref="RestoreDatabaseOperation"/> object.</returns>
        private RestoreDatabaseOperation CreateRestoreDatabaseOperationFromResponse(RestoreDatabaseOperationCreateResponse response)
        {
            return new RestoreDatabaseOperation()
            {
                RequestID = Guid.Parse(response.Operation.Id),
                SourceDatabaseName = response.Operation.SourceDatabaseName,
                SourceDatabaseDeletionDate = response.Operation.SourceDatabaseDeletionDate,
                TargetServerName = response.Operation.TargetServerName,
                TargetDatabaseName = response.Operation.TargetDatabaseName,
                TargetUtcPointInTime = response.Operation.PointInTime,
            };
        }

        /// <summary>
        /// Add the tracing session and request headers to the client.
        /// </summary>
        /// <param name="sqlManagementClient">The client to add the headers on.</param>
        private void AddTracingHeaders(SqlManagementClient sqlManagementClient)
        {
            sqlManagementClient.HttpClient.DefaultRequestHeaders.Add(
                Constants.ClientSessionIdHeaderName,
                this.ClientSessionId);
            sqlManagementClient.HttpClient.DefaultRequestHeaders.Add(
                Constants.ClientRequestIdHeaderName,
                this.ClientRequestId);
        }

        /// <summary>
        /// Ensures any extra property on the given <paramref name="database"/> is loaded.
        /// </summary>
        /// <param name="database">The database that needs the extra properties.</param>
        private void LoadExtraProperties(Database database)
        {
            // Fill in the context property
            database.Context = this;
        }

        /// <summary>
        /// Ensures any extra property on the given <paramref name="database"/> is loaded.
        /// </summary>
        /// <param name="database">The database that needs the extra properties.</param>
        private void LoadExtraProperties(RestorableDroppedDatabase database)
        {
            // Fill in the context property
            database.Context = this;
        }

        #endregion
    }
}
