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

using System;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server
{
    using Microsoft.WindowsAzure.Management.Sql.Models;
    using DatabaseCopyModel = Model.DatabaseCopy;

    /// <summary>
    /// Common interface for all server based operations.
    /// </summary>
    public interface IServerDataServiceContext
    {
        /// <summary>
        /// Gets the per session tracing Id.
        /// </summary>
        string ClientSessionId { get; }

        /// <summary>
        /// Gets the previous request's client request Id.
        /// </summary>
        string ClientRequestId { get; }

        /// <summary>
        /// Gets the name of the server for this context.
        /// </summary>
        string ServerName { get; }

        /// <summary>
        /// Ensures any extra property on the given <paramref name="obj"/> is loaded.
        /// </summary>
        /// <param name="obj">The object that needs the extra properties.</param>
        void LoadExtraProperties(object obj);

        #region Database Operations

        /// <summary>
        /// Retrieves the list of all databases on the server.
        /// </summary>
        /// <returns>An array of all databases on the server.</returns>
        Database[] GetDatabases();

        /// <summary>
        /// Retrieve information on database with the name <paramref name="databaseName"/>.
        /// </summary>
        /// <param name="databaseName">The database to retrieve.</param>
        /// <returns>An object containing the information about the specific database.</returns>
        Database GetDatabase(string databaseName);

        /// <summary>
        /// Creates a new Sql Database.
        /// </summary>
        /// <param name="databaseName">The name for the new database.</param>
        /// <param name="databaseMaxSize">The max size for the database.</param>
        /// <param name="databaseCollation">The collation for the database.</param>
        /// <param name="databaseEdition">The edition for the database.</param>
        /// <param name="serviceObjective">The SLO for the premium database.</param>
        /// <returns>The newly created Sql Database.</returns>
        Database CreateNewDatabase(
            string databaseName,
            int? databaseMaxSizeGb,
            long? databaseMaxSizeBytes,
            string databaseCollation,
            DatabaseEdition databaseEdition,
            ServiceObjective serviceObjective);

        /// <summary>
        /// Updates the property on the database with the name <paramref name="databaseName"/>.
        /// </summary>
        /// <param name="databaseName">The database to update.</param>
        /// <param name="newDatabaseName">
        /// The new database name, or <c>null</c> to not update.
        /// </param>
        /// <param name="databaseMaxSize">
        /// The new database max size, or <c>null</c> to not update.
        /// </param>
        /// <param name="databaseEdition">
        /// The new database edition, or <c>null</c> to not update.
        /// </param>
        /// <param name="serviceObjective">
        /// The new service objective, or <c>null</c> to not update.
        /// </param>
        /// <returns>The updated database object.</returns>
        Database UpdateDatabase(
            string databaseName,
            string newDatabaseName,
            int? databaseMaxSizeGb,
            long? databaseMaxSizeBytes,
            DatabaseEdition? databaseEdition,
            ServiceObjective serviceObjective);

        /// <summary>
        /// Removes the database with the name <paramref name="databaseName"/>.
        /// </summary>
        /// <param name="databaseName">The database to remove.</param>
        void RemoveDatabase(string databaseName);

        #endregion

        #region Database Copy Operations
        
        /// <summary>
        /// Retrieve all database copy objects with matching parameters.
        /// </summary>
        /// <param name="databaseName">The name of the database to copy.</param>
        /// <param name="partnerServer">The name for the partner server.</param>
        /// <param name="partnerDatabaseName">The name of the database on the partner server.</param>
        /// <returns>All database copy objects with matching parameters.</returns>
        DatabaseCopyModel[] GetDatabaseCopy(
            string databaseName,
            string partnerServer,
            string partnerDatabaseName);

        /// <summary>
        /// Refreshes the given database copy object.
        /// </summary>
        /// <param name="databaseCopy">The object to refresh.</param>
        /// <returns>The refreshed database copy object.</returns>
        DatabaseCopyModel GetDatabaseCopy(DatabaseCopyModel databaseCopy);

        /// <summary>
        /// Start database copy on the database with the name <paramref name="databaseName"/>.
        /// </summary>
        /// <param name="databaseName">The database to copy.</param>
        /// <param name="partnerServer">The database to copy.</param>
        /// <param name="partnerDatabaseName">The database to copy.</param>
        /// <param name="continuousCopy"><c>true</c> to make this a continuous copy.</param>
        /// <param name="isOfflineSecondary"><c>true</c> to make this an offline secondary copy.</param>
        /// <returns>The new instance of database copy operation.</returns>
        DatabaseCopyModel StartDatabaseCopy(
            string databaseName,
            string partnerServer,
            string partnerDatabaseName,
            bool continuousCopy,
            bool isOfflineSecondary);

        /// <summary>
        /// Terminate an ongoing database copy operation.
        /// </summary>
        /// <param name="databaseCopy">The database copy to terminate.</param>
        /// <param name="forcedTermination"><c>true</c> to forcefully terminate the copy.</param>
        void StopDatabaseCopy(
            DatabaseCopyModel databaseCopy,
            bool forcedTermination);

        #endregion

        #region Service Objective Operations

        /// <summary>
        /// Retrieves the list of all service objectives on the server.
        /// </summary>
        /// <returns>An array of all service objectives on the server.</returns>
        ServiceObjective[] GetServiceObjectives();

        /// <summary>
        /// Retrieve information on service objective with the specified name
        /// </summary>
        /// <param name="serviceObjectiveName">The service objective to retrieve.</param>
        /// <returns>
        /// An object containing the information about the specific service objective.
        /// </returns>
        ServiceObjective GetServiceObjective(string serviceObjectiveName);

        /// <summary>
        /// Retrieve information on latest service objective with service objective
        /// </summary>
        /// <param name="serviceObjective">The service objective to refresh.</param>
        /// <returns>
        /// An object containing the information about the specific service objective.
        /// </returns>        
        ServiceObjective GetServiceObjective(ServiceObjective serviceObjective);

        /// <summary>
        /// Get a specific quota for a server
        /// </summary>
        /// <param name="quotaName">The name of the quota to retrieve</param>
        /// <returns>A quota object.</returns>
        ServerQuota GetQuota(string quotaName);

        /// <summary>
        /// Get a list of all quotas for a server
        /// </summary>
        /// <returns>An array of server quota objects</returns>
        ServerQuota[] GetQuotas();

        #endregion

        #region Get/Stop Database Operation

        /// <summary>
        /// Retrieve information on operation with the guid 
        /// </summary>
        /// <param name="OperationGuid">The Guid of the operation to retrieve.</param>
        /// <returns>An object containing the information about the specific operation.</returns>
        DatabaseOperation GetDatabaseOperation(Guid OperationGuid);

        /// <summary>
        /// Retrieves the list of all operations on the database.
        /// </summary>
        /// <param name="databaseName">The name of database to retrieve operations.</param>
        /// <returns>An array of all operations on the database.</returns>
        DatabaseOperation[] GetDatabaseOperations(string databaseName);

        /// <summary>
        /// Retrieves the list of all databases' operations on the server.
        /// </summary>
        /// <returns>An array of all operations on the server.</returns>
        DatabaseOperation[] GetDatabasesOperations();

        #endregion

        #region Restorable Dropped Database Operations

        /// <summary>
        /// Retrieves the list of all restorable dropped databases on the server.
        /// </summary>
        /// <returns>An array of all restorable dropped databases on the server.</returns>
        RestorableDroppedDatabase[] GetRestorableDroppedDatabases();

        /// <summary>
        /// Retrieve information on the restorable dropped database with the name
        /// <paramref name="databaseName"/> and deletion date <paramref name="deletionDate"/>.
        /// </summary>
        /// <param name="databaseName">The name of the restorable dropped database to retrieve.</param>
        /// <param name="deletionDate">The deletion date of the restorable dropped database to retrieve.</param>
        /// <returns>An object containing the information about the specific restorable dropped database.</returns>
        RestorableDroppedDatabase GetRestorableDroppedDatabase(
            string databaseName, DateTime deletionDate);

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
        RestoreDatabaseOperation RestoreDatabase(
            string sourceDatabaseName,
            DateTime? sourceDatabaseDeletionDate,
            string targetServerName,
            string targetDatabaseName,
            DateTime? pointInTime);

        #endregion
    }
}
