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

using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server
{
    public class TSqlConnectionContext : IServerDataServiceContext, ISqlServerConnectionInformation
    {
        /// <summary>
        /// Timeout duration for commands
        /// </summary>
        private static int commandTimeout = 300;

        /// <summary>
        /// Timeout duration for connections
        /// </summary>
        private static int connectionTimeout = 30;

        /// <summary>
        /// Set this to override the SQL Connection with a mock version
        /// </summary>
        public static object MockSqlConnection = null;

        /// <summary>
        /// Query for retrieving database info
        /// </summary>
        private const string getDatabaseQuery = @"
                SELECT 
                    [db].[name], 
                    [db].[database_id], 
                    [db].[create_date], 
                    [db].[collation_name], 
                    [db].[is_read_only],
                    [db].[is_query_store_on], 
                    [db].[is_recursive_triggers_on],
                    [db].[is_federation_member],
                    CONVERT (bit, CASE WHEN [db].[name] in ('master') THEN 1 ELSE [db].[is_distributor] END) AS [is_system_object],
                    CONVERT (int,
                        CASE
                            WHEN [db].[is_in_standby] = 1 THEN 0x0040
                            ELSE 0
                        END |
                        CASE
                            WHEN [db].[is_cleanly_shutdown] = 1 THEN 0x0080
                            ELSE 0
                        END |
                        CASE [db].[state]
                            WHEN 0 THEN 0x0001  -- NORMAL
                            WHEN 1 THEN 0x0002  -- RESTORING
                            WHEN 2 THEN 0x0008  -- RECOVERING
                            WHEN 3 THEN 0x0004  -- RECOVERY_PENDING
                            WHEN 4 THEN 0x0010  -- SUSPECT
                            WHEN 5 THEN 0x0100  -- EMERGENCY
                            WHEN 6 THEN 0x0020  -- OFFLINE
                            WHEN 7 THEN 0x0400  -- COPYING
                            WHEN 9 THEN 0x0800  -- CREATING
                            WHEN 10 THEN 0x1000 -- OFFLINE_SECONDARY
                            ELSE 0x0010         -- SUSPECT
                        END) AS [status]
                    FROM [sys].[databases] AS [db]
                    WHERE ([db].[name] = @name OR @name IS NULL)";

        /// <summary>
        /// Gets the session activity Id associated with this context.
        /// </summary>
        public Guid SessionActivityId
        {
            get
            {
                return this.sessionActivityId;
            }
        }

        /// <summary>
        /// Gets the client per session tracing Id.
        /// </summary>
        public string ClientSessionId
        {
            get
            {
                return SqlDatabaseCmdletBase.clientSessionId;
            }
        }

        /// <summary>
        /// Gets the previous request's client request Id.
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

        /// <summary>
        /// Gets the SQL credentials for connecting to the server.
        /// </summary>
        public SqlAuthenticationCredentials SqlCredentials
        {
            get
            {
                return credentials;
            }
        }

        /// <summary>
        /// Contains the connection string necessary to connect to the server
        /// </summary>
        private SqlConnectionStringBuilder builder;

        /// <summary>
        /// Unique session ID
        /// </summary>
        private Guid sessionActivityId;

        /// <summary>
        /// Unique client request ID
        /// </summary>
        private string clientRequestId;

        /// <summary>
        /// Server name for the context
        /// </summary>
        private string serverName;

        /// <summary>
        /// The sql connection credetials
        /// </summary>
        private SqlAuthenticationCredentials credentials;

        /// <summary>
        /// Helper function to generate the SqlConnectionStringBuilder
        /// </summary>
        /// <param name="fullyQualifiedServerName">The fully qualified server name (eg: server1.database.windows.net)</param>
        /// <param name="username">The login username</param>
        /// <param name="password">The login password</param>
        /// <returns>A connection string builder</returns>
        private SqlConnectionStringBuilder GenerateSqlConnectionBuilder(string fullyQualifiedServerName, string username, string password)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder["Server"] = fullyQualifiedServerName;
            builder.UserID = username + "@" + serverName;
            builder.Password = password;
            builder["Database"] = null;
            builder["Encrypt"] = true;
            builder.ConnectTimeout = connectionTimeout;

            return builder;
        }

        /// <summary>
        /// Creates a sql connection using the sql connection string builder.
        /// </summary>
        /// <returns></returns>
        private DbConnection CreateConnection()
        {
            if (MockSqlConnection != null)
            {
                ((DbConnection)MockSqlConnection).ConnectionString = builder.ConnectionString;
                return (DbConnection)MockSqlConnection;
            }
            else
            {
                return new SqlConnection(builder.ConnectionString);
            }
        }

        /// <summary>
        /// Creates an instance of a SQLAuth to TSql class
        /// </summary>
        /// <param name="fullyQualifiedServerName">The full server name</param>
        /// <param name="credentials">The login credentials for the server</param>
        public TSqlConnectionContext(Guid sessionActivityId, string fullyQualifiedServerName, SqlAuthenticationCredentials credentials, string serverName)
        {
            this.serverName = serverName;
            this.sessionActivityId = sessionActivityId;
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();
            this.credentials = credentials;
            builder = GenerateSqlConnectionBuilder(fullyQualifiedServerName, credentials.UserName, credentials.Password);
        }

        /// <summary>
        /// Retrieves the list of all databases on the server.
        /// </summary>
        /// <returns>An array of all databases on the server.</returns>
        public Database[] GetDatabases()
        {
            List<Database> databases = new List<Database>();

            builder["Database"] = null;
            using (var connection = CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandTimeout = connectionTimeout;
                    command.CommandText = getDatabaseQuery;
                    DbParameter param = command.CreateParameter();
                    param.ParameterName = "@name";
                    param.Value = DBNull.Value;

                    command.Parameters.Add(param);

                    connection.Open();

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                databases.Add(PopulateDatabaseFromReader(reader));
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }

            databases.ForEach(db => GetDatabaseProperties(db));
            databases.ForEach(db => db.ServiceObjective = GetServiceObjective(db.ServiceObjectiveName));

            databases.ForEach(db => db.Context = this);

            return databases.ToArray();
        }

        /// <summary>
        /// Retrieve information on database with the name <paramref name="databaseName"/>.
        /// </summary>
        /// <param name="databaseName">The database to retrieve.</param>
        /// <returns>An object containing the information about the specific database.</returns>
        public Database GetDatabase(string databaseName)
        {
            Database db = null;

            builder["Database"] = null;
            using (var connection = CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandTimeout = connectionTimeout;
                    command.CommandText = getDatabaseQuery;
                    DbParameter param = command.CreateParameter();
                    param.ParameterName = "@name";
                    param.Value = databaseName;
                    command.Parameters.Add(param);

                    connection.Open();

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                db = PopulateDatabaseFromReader(reader);
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }

            GetDatabaseProperties(db);
            db.ServiceObjective = GetServiceObjective(db.ServiceObjectiveName);
            db.Context = this;

            return db;
        }

        /// <summary>
        /// Creates a new Sql Database.
        /// </summary>
        /// <param name="databaseName">The name for the new database.</param>
        /// <param name="databaseMaxSizeGb">The max size for the database in GB.</param>
        /// <param name="databaseMaxSizeBytes">The max size for the database in bytes.</param>
        /// <param name="databaseCollation">The collation for the database.</param>
        /// <param name="databaseEdition">The edition for the database.</param>
        /// <param name="serviceObjective">The service object to assign to the database</param>
        /// <returns>The newly created Sql Database.</returns>
        public Database CreateNewDatabase(
            string databaseName,
            int? databaseMaxSizeGb,
            long? databaseMaxSizeBytes,
            string databaseCollation,
            DatabaseEdition databaseEdition,
            ServiceObjective serviceObjective)
        {
            return CreateNewDatabase(
                databaseName,
                databaseMaxSizeGb,
                databaseMaxSizeBytes,
                databaseCollation,
                databaseEdition,
                serviceObjective == null ? null : serviceObjective.Name);
        }

        /// <summary>
        /// Creates a new Sql Database.
        /// </summary>
        /// <param name="databaseName">The name for the new database.</param>
        /// <param name="databaseMaxSizeGb">The max size for the database in GB.</param>
        /// <param name="databaseMaxSizeBytes">The max size for the database in bytes.</param>
        /// <param name="databaseCollation">The collation for the database.</param>
        /// <param name="databaseEdition">The edition for the database.</param>
        /// <param name="serviceObjective">The service object to assign to the database</param>
        /// <returns>The newly created Sql Database.</returns>
        public Database CreateNewDatabase(
            string databaseName,
            int? databaseMaxSizeGb,
            long? databaseMaxSizeBytes,
            string databaseCollation,
            DatabaseEdition databaseEdition,
            string serviceObjectiveName)
        {
            builder["Database"] = null;

            string commandText = "CREATE DATABASE [{0}] ";

            if (!string.IsNullOrEmpty(databaseCollation))
            {
                commandText += " COLLATE {1} ";
            }

            List<string> arguments = new List<string>();

            if (databaseMaxSizeGb != null || databaseMaxSizeBytes != null)
            {
                arguments.Add(" MAXSIZE={2} ");
            }

            if (databaseEdition != DatabaseEdition.None)
            {
                arguments.Add(" EDITION='{3}' ");
            }

            if (!string.IsNullOrEmpty(serviceObjectiveName))
            {
                arguments.Add(" SERVICE_OBJECTIVE='{4}' ");
            }

            if (arguments.Count > 0)
            {
                commandText += "(" + string.Join(", ", arguments.ToArray()) + ")";
            }

            string maxSizeVal = string.Empty;
            if (databaseMaxSizeGb != null)
            {
                maxSizeVal = databaseMaxSizeGb.Value.ToString() + "GB";
            }
            else if (databaseMaxSizeBytes != null)
            {
                if (databaseMaxSizeBytes > (500 * 1024 * 1024))
                {
                    maxSizeVal = (databaseMaxSizeBytes / (1024 * 1024 * 1024)).ToString() + "GB";
                }
                else
                {
                    maxSizeVal = (databaseMaxSizeBytes / (1024 * 1024)).ToString() + "MB";
                }
            }

            SqlCollationCheck(databaseCollation);

            commandText = string.Format(
                commandText,
                SqlEscape(databaseName),
                databaseCollation,
                SqlEscape(maxSizeVal),
                SqlEscape(databaseEdition.ToString()),
                SqlEscape(serviceObjectiveName));

            builder["Database"] = null;
            using (var connection = CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandTimeout = commandTimeout;
                    command.CommandText = commandText;
                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }

            return GetDatabase(databaseName);
        }

        /// <summary>
        /// Checks to make sure the collation only contains alphanumeric characters and '_'
        /// </summary>
        /// <param name="databaseCollation">The string to verify</param>
        private void SqlCollationCheck(string databaseCollation)
        {
            if (string.IsNullOrEmpty(databaseCollation))
            {
                return;
            }

            bool isValid = databaseCollation.All((c) =>
                {
                    if (!char.IsLetterOrDigit(c) && c != '_')
                    {
                        return false;
                    }
                    return true;
                });

            if (!isValid)
            {
                throw new ArgumentException("Invalid Collation", "Collation");
            }
        }

        /// <summary>
        /// Updates the property on the database with the name <paramref name="databaseName"/>.
        /// </summary>
        /// <param name="builder">The sql connection string information</param>
        /// <param name="databaseName">The database to update.</param>
        /// <param name="newDatabaseName">The new database name, or <c>null</c> to not update.</param>
        /// <param name="databaseMaxSizeGb">The max size for the database in GB.</param>
        /// <param name="databaseMaxSizeBytes">The max size for the database in bytes.</param>
        /// <param name="databaseEdition">The new database edition, or <c>null</c> to not update.</param>
        /// <param name="serviceObjective">The new service objective, or <c>null</c> to not update.</param>
        /// <returns>The updated database object.</returns>
        public Database UpdateDatabase(
            string databaseName,
            string newDatabaseName,
            int? databaseMaxSizeGb,
            long? databaseMaxSizeBytes,
            DatabaseEdition? databaseEdition,
            ServiceObjective serviceObjective)
        {
            return UpdateDatabase(
                databaseName,
                newDatabaseName,
                databaseMaxSizeGb,
                databaseMaxSizeBytes,
                databaseEdition,
                serviceObjective == null ? null : serviceObjective.Name);
        }

        /// <summary>
        /// Updates the property on the database with the name <paramref name="databaseName"/>.
        /// </summary>
        /// <param name="builder">The sql connection string information</param>
        /// <param name="databaseName">The database to update.</param>
        /// <param name="newDatabaseName">The new database name, or <c>null</c> to not update.</param>
        /// <param name="databaseMaxSizeGb">The max size for the database in GB.</param>
        /// <param name="databaseMaxSizeBytes">The max size for the database in bytes.</param>
        /// <param name="databaseEdition">The new database edition, or <c>null</c> to not update.</param>
        /// <param name="serviceObjective">The new service objective name, or <c>null</c> to not update.</param>
        /// <returns>The updated database object.</returns>
        public Database UpdateDatabase(
            string databaseName,
            string newDatabaseName,
            int? databaseMaxSizeGb,
            long? databaseMaxSizeBytes,
            DatabaseEdition? databaseEdition,
            string serviceObjectiveName)
        {
            Database result = null;

            if (!string.IsNullOrEmpty(newDatabaseName))
            {
                result = AlterDatabaseName(databaseName, newDatabaseName);
                databaseName = newDatabaseName;
            }

            if (databaseMaxSizeBytes.HasValue ||
                databaseMaxSizeGb.HasValue ||
                databaseEdition.HasValue ||
                !string.IsNullOrEmpty(serviceObjectiveName))
            {
                string sizeVal = null;
                if (databaseMaxSizeGb.HasValue)
                {
                    sizeVal = databaseMaxSizeGb.Value.ToString() + "GB";
                }
                else if (databaseMaxSizeBytes.HasValue)
                {
                    if (databaseMaxSizeBytes.Value > 500 * 1024 * 1024)
                    {
                        sizeVal = (databaseMaxSizeBytes.Value / (1024 * 1024 * 1024)).ToString() + "GB";
                    }
                    else
                    {
                        sizeVal = (databaseMaxSizeBytes.Value / (1024 * 1024)).ToString() + "MB";
                    }
                }

                result = AlterDatabaseProperties(databaseName, sizeVal, databaseEdition, serviceObjectiveName);
            }

            result.Context = this;

            return result;
        }

        /// <summary>
        /// Removes the database with the name <paramref name="databaseName"/>.
        /// </summary>
        /// <param name="builder">The sql connection string information</param>
        /// <param name="databaseName">The database to remove.</param>
        public void RemoveDatabase(string databaseName)
        {
            string commandText = "DROP DATABASE [{0}]";

            commandText = string.Format(commandText, SqlEscape(databaseName));

            builder["Database"] = null;
            using (var connection = CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = commandText;
                    command.CommandTimeout = commandTimeout;

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Gets a list of all the available service objectives
        /// </summary>
        /// <returns>An array of service objectives</returns>
        public ServiceObjective[] GetServiceObjectives()
        {
            ServiceObjective[] list = new[]
            {
                new ServiceObjective()
                {
                    Context = this,
                    Enabled = true,
                    Id = new Guid("26E021DB-F1F9-4C98-84C6-92AF8EF433D7"),
                    IsDefault = false,
                    IsSystem = true,
                    Name = "System"
                }, 
                new ServiceObjective()
                {
                    Context = this,
                    Enabled = true,
                    Id = new Guid("620323BF-2879-4807-B30D-C2E6D7B3B3AA"),
                    IsDefault = false,
                    IsSystem = true,
                    Name = "System2"
                },
                new ServiceObjective()
                {
                    Context = this,
                    Enabled = true,
                    Id = new Guid("dd6d99bb-f193-4ec1-86f2-43d3bccbc49c"),
                    IsDefault = false,
                    IsSystem = false,
                    Name = "Basic"
                }, 
                new ServiceObjective()
                {
                    Context = this,
                    Enabled = true,
                    Id = new Guid("f1173c43-91bd-4aaa-973c-54e79e15235b"),
                    IsDefault = true,
                    IsSystem = false,
                    Name = "S0"
                },
                new ServiceObjective()
                {
                    Context = this,
                    Enabled = true,
                    Id = new Guid("1b1ebd4d-d903-4baa-97f9-4ea675f5e928"),
                    IsDefault = false,
                    IsSystem = false,
                    Name = "S1"
                },
                new ServiceObjective()
                {
                    Context = this,
                    Enabled = true,
                    Id = new Guid("455330e1-00cd-488b-b5fa-177c226f28b7"),
                    IsDefault = false,
                    IsSystem = false,
                    Name = "S2"
                },
                new ServiceObjective()
                {
                    Context = this,
                    Enabled = true,
                    Id = new Guid("789681B8-CA10-4EB0-BDF2-E0B050601B40"),
                    IsDefault = false,
                    IsSystem = false,
                    Name = "S3"
                },
                new ServiceObjective()
                {
                    Context = this,
                    Enabled = true,
                    Id = new Guid("7203483a-c4fb-4304-9e9f-17c71c904f5d"),
                    IsDefault = false,
                    IsSystem = false,
                    Name = "P1"
                },
                new ServiceObjective()
                {
                    Context = this,
                    Enabled = true,
                    Id = new Guid("a7d1b92d-c987-4375-b54d-2b1d0e0f5bb0"),
                    IsDefault = false,
                    IsSystem = false,
                    Name = "P2"
                },
                new ServiceObjective()
                {
                    Context = this,
                    Enabled = true,
                    Id = new Guid("a7c4c615-cfb1-464b-b252-925be0a19446"),
                    IsDefault = false,
                    IsSystem = false,
                    Name = "P3"
                },
                new ServiceObjective()
                {
                    Context = this,
                    Enabled = true,
                    Id = new Guid("afe1eee1-1f12-4e5f-9ad6-2de9c12cb4dc"),
                    IsDefault = false,
                    IsSystem = false,
                    Name = "P4"
                },
                new ServiceObjective()
                {
                    Context = this,
                    Enabled = true,
                    Id = new Guid("43940481-9191-475a-9dba-6b505615b9aa"),
                    IsDefault = false,
                    IsSystem = false,
                    Name = "P6"
                },
                new ServiceObjective()
                {
                    Context = this,
                    Enabled = true,
                    Id = new Guid("dd00d544-bbc0-4f61-ba60-cdce0c410288"),
                    IsDefault = false,
                    IsSystem = false,
                    Name = "P11"
                },
                new ServiceObjective()
                {
                    Context = this,
                    Enabled = true,
                    Id = new Guid("D1737D22-A8EA-4DE7-9BD0-33395D2A7419"),
                    IsDefault = false,
                    IsSystem = false,
                    Name = "ElasticPool"
                },
            };

            return list;
        }

        /// <summary>
        /// Gets a service objective by name
        /// </summary>
        /// <param name="serviceObjectiveName">The name of the service objective to retrieve</param>
        /// <returns>A service objective</returns>
        public ServiceObjective GetServiceObjective(string serviceObjectiveName)
        {
            return GetServiceObjectives().Where((slo) => slo.Name == serviceObjectiveName).FirstOrDefault();
        }

        public ServiceObjective GetServiceObjective(ServiceObjective serviceObjective)
        {
            return GetServiceObjective(serviceObjective.Name);
        }

        public ServerQuota GetQuota(string quotaName)
        {
            return null;
        }

        public ServerQuota[] GetQuotas()
        {
            return null;
        }

        public DatabaseOperation GetDatabaseOperation(Guid OperationGuid)
        {
            throw new NotImplementedException();
        }

        public DatabaseOperation[] GetDatabaseOperations(string databaseName)
        {
            throw new NotImplementedException();
        }

        public DatabaseOperation[] GetDatabasesOperations()
        {
            throw new NotImplementedException();
        }

        public Model.DatabaseCopy[] GetDatabaseCopy(string databaseName, string partnerServer, string partnerDatabaseName)
        {
            throw new NotSupportedException();
        }

        public Model.DatabaseCopy GetDatabaseCopy(Model.DatabaseCopy databaseCopy)
        {
            throw new NotSupportedException();
        }

        public Model.DatabaseCopy StartDatabaseCopy(string databaseName, string partnerServer, string partnerDatabaseName, bool continuousCopy, bool isOfflineSecondary)
        {
            throw new NotSupportedException();
        }

        public void StopDatabaseCopy(Model.DatabaseCopy databaseCopy, bool forcedTermination)
        {
            throw new NotSupportedException();
        }

        public RestorableDroppedDatabase[] GetRestorableDroppedDatabases()
        {
            throw new NotSupportedException();
        }

        public RestorableDroppedDatabase GetRestorableDroppedDatabase(string databaseName, DateTime deletionDate)
        {
            throw new NotSupportedException();
        }

        public RestoreDatabaseOperation RestoreDatabase(string sourceDatabaseName, DateTime? sourceDatabaseDeletionDate, string targetServerName, string targetDatabaseName, DateTime? pointInTime)
        {
            throw new NotSupportedException();
        }

        #region Helpers

        /// <summary>
        /// Checks if a value is null or DBNull and returns default(T).  Otherwise returns the value
        /// casted to the desired type.
        /// </summary>
        /// <typeparam name="T">The type to cast to</typeparam>
        /// <param name="obj">The object to cast</param>
        /// <returns>The result</returns>
        private T ConvertFromDbValue<T>(object obj)
        {
            if (obj == null || Convert.IsDBNull(obj))
            {
                return default(T);
            }
            else
            {
                return (T)obj;
            }
        }

        /// <summary>
        /// Given a SqlDataReader extracts the necessary information to populate a database object
        /// </summary>
        /// <param name="reader">The reader created from the GetDatabaseQuery</param>
        /// <returns>The new database</returns>
        private Database PopulateDatabaseFromReader(DbDataReader reader)
        {
            Database db = new Database();
            db.Name = ConvertFromDbValue<string>(reader["name"]);
            db.CollationName = ConvertFromDbValue<string>(reader["collation_name"]);
            db.CreationDate = ConvertFromDbValue<DateTime>(reader["create_date"]);
            db.Id = ConvertFromDbValue<int>(reader["database_id"]);
            db.IsFederationMember = ConvertFromDbValue<bool>(reader["is_federation_member"]);
            db.IsFederationRoot = false;
            db.IsQueryStoreOn = ConvertFromDbValue<bool>(reader["is_query_store_on"]);
            db.IsQueryStoreReadOnly = false;
            db.IsReadOnly = ConvertFromDbValue<bool>(reader["is_read_only"]);
            db.IsRecursiveTriggersOn = ConvertFromDbValue<bool?>(reader["is_recursive_triggers_on"]);
            db.IsSuspended = false;
            db.IsSystemObject = ConvertFromDbValue<bool>(reader["is_system_object"]);
            db.QueryStoreClearAll = null;
            db.QueryStoreFlushPeriodSeconds = null;
            db.QueryStoreIntervalLengthMinutes = null;
            db.QueryStoreMaxSizeMB = null;
            db.QueryStoreStaleQueryThresholdDays = null;
            db.RecoveryPeriodStartDate = null;
            db.Status = ConvertFromDbValue<int>(reader["status"]);
            return db;
        }

        /// <summary>
        /// Gets some additional database properties (edition, maxsizebytes, ...) from the database
        /// </summary>
        /// <param name="db"></param>
        private void GetDatabaseProperties(Database db)
        {
            if (!string.IsNullOrEmpty(db.Name))
            {
                string commandText =
                    "SELECT " +
                    "DatabasePropertyEx(@name, 'Edition') as edition,  " +
                    "DatabasePropertyEx(@name, 'ServiceObjective') as serviceObjective,  " +
                    "DatabasePropertyEx(@name, 'MaxSizeInBytes') as maxSizeBytes";

                builder["Database"] = db.Name;
                using (var connection = CreateConnection())
                {
                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandTimeout = commandTimeout;
                        command.CommandText = commandText;
                        DbParameter param = command.CreateParameter();
                        param.ParameterName = "@name";
                        param.Value = db.Name;
                        command.Parameters.Add(param);

                        connection.Open();
                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                db.MaxSizeBytes = ConvertFromDbValue<long>(reader["maxSizeBytes"]);
                                db.Edition = ConvertFromDbValue<string>(reader["edition"]);
                                db.ServiceObjectiveName = ConvertFromDbValue<string>(reader["serviceObjective"]);
                            }
                        }
                    }
                }
            }

            if (db.MaxSizeBytes.HasValue)
            {
                db.MaxSizeGB = (int)(db.MaxSizeBytes / (1024 * 1024 * 1024));
            }

            if (!string.IsNullOrEmpty(db.ServiceObjectiveName))
            {
                db.ServiceObjective = GetServiceObjective(db.ServiceObjectiveName);
                if (db.ServiceObjective != null)
                {
                    db.ServiceObjectiveId = db.ServiceObjective.Id;
                }
            }


            builder["Database"] = null;
        }

        /// <summary>
        /// Escape all the occurances of ']' in the input string.
        /// </summary>
        /// <param name="input">The input string to sanitize</param>
        /// <returns>The escaped string</returns>
        string SqlEscape(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            else
                return input.Replace("]", "]]").Replace("'", "''");
        }

        /// <summary>
        /// Alter the database properties
        /// </summary>
        /// <param name="databaseName">The name of the database to alter</param>
        /// <param name="sizeVal">The new size of the database (format: ##{GB|MB})</param>
        /// <param name="databaseEdition">The new edition for the database</param>
        /// <param name="serviceObjectiveName">The new service objective name</param>
        /// <returns>The altered database</returns>
        private Database AlterDatabaseProperties(string databaseName, string sizeVal, DatabaseEdition? databaseEdition, string serviceObjectiveName)
        {
            string commandText =
                  "ALTER DATABASE [{0}] MODIFY ";

            List<string> arguments = new List<string>();

            if (!string.IsNullOrEmpty(sizeVal))
            {
                arguments.Add(" MAXSIZE={1} ");
            }

            string edition = string.Empty;
            if (databaseEdition.HasValue &&
                databaseEdition.Value != DatabaseEdition.None)
            {
                arguments.Add(" EDITION='{2}' ");
                edition = databaseEdition.Value.ToString();
            }

            if (!string.IsNullOrEmpty(serviceObjectiveName))
            {
                arguments.Add(" SERVICE_OBJECTIVE='{3}' ");
            }

            if (arguments.Count > 0)
            {
                commandText += " (" + string.Join(", ", arguments.ToArray()) + ")";
            }

            commandText = string.Format(
                commandText,
                SqlEscape(databaseName),
                SqlEscape(sizeVal),
                SqlEscape(edition),
                SqlEscape(serviceObjectiveName));

            builder["Database"] = null;
            using (var connection = CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandTimeout = commandTimeout;
                    command.CommandText = commandText;
                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }

            return GetDatabase(databaseName);
        }

        /// <summary>
        /// Used to alter the name of a databse.
        /// </summary>
        /// <param name="databaseName">Current database name</param>
        /// <param name="newDatabaseName">Desired new name</param>
        /// <returns>The resultant database object</returns>
        private Database AlterDatabaseName(string databaseName, string newDatabaseName)
        {
            string commandText =
                "ALTER DATABASE [{0}] MODIFY NAME = [{1}]";

            commandText = string.Format(
                commandText,
                SqlEscape(databaseName),
                SqlEscape(newDatabaseName));

            builder["Database"] = null;
            using (var connection = CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandTimeout = commandTimeout;
                    command.CommandText = commandText;
                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }

            return GetDatabase(newDatabaseName);
        }

        /// <summary>
        /// Used to load extra properties
        /// </summary>
        /// <param name="obj"></param>
        public void LoadExtraProperties(object obj)
        {
        }

        #endregion
    }
}
