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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.TSql
{
    /// <summary>
    /// Mock sql command for recording sessions for test playback
    /// </summary>
    internal class MockSqlCommand : DbCommand
    {
        /// <summary>
        /// A dictionary that stores results for both scalar and reader queries.
        /// The dictionary maps query text -> list of candidate results.
        /// </summary>
        private static Dictionary<string, List<MockQueryResult>> mockResults = new Dictionary<string, List<MockQueryResult>>();

        /// <summary>
        /// Regular expression to be used in normalizing the query white spaces
        /// </summary>
        private static readonly Regex WhiteSpaceRegex = new Regex(@"\s+");

        /// <summary>
        /// The SQL provider creates temp tables with random names to unify the query if
        /// it spans multiple databases. The regex below matches the temp table name so that
        /// we can replace it with a masked table name.
        /// </summary>
        private static readonly Regex TempTableNameRegex = new Regex(@"\[\#unify_temptbl_[0-9a-fA-F]{8}\]");
        private static readonly string TempTableName = "[#unify_temptbl_XXXXXXXX]";

        /// <summary>
        /// Settings for the mock session
        /// </summary>
        private readonly MockSettings settings;

        /// <summary>
        /// Collection of parameters for the command
        /// </summary>
        private readonly MockSqlParameterCollection parameterCollection;

        /// <summary>
        /// Static C'tor.  Initializes the mock results
        /// </summary>
        static MockSqlCommand()
        {
            InitializeMockResults();
        }

        /// <summary>
        /// C'tor.
        /// </summary>
        /// <param name="connection">The connection information</param>
        /// <param name="settings">The mock settings</param>
        internal MockSqlCommand(DbConnection connection, MockSettings settings)
        {
            Assert.IsTrue(connection != null);
            Assert.IsTrue(settings != null);

            this.DbConnection = connection;
            this.parameterCollection = new MockSqlParameterCollection();
            this.settings = settings;
        }

        /// <summary>
        /// No-op
        /// </summary>
        public override void Cancel()
        {
        }

        /// <summary>
        /// Gets or sets the command text
        /// </summary>
        public override string CommandText
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the command timeout
        /// </summary>
        public override int CommandTimeout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the command type
        /// </summary>
        public override CommandType CommandType
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a new database parameter than can be used
        /// </summary>
        /// <returns>A db parameter instance</returns>
        protected override DbParameter CreateDbParameter()
        {
            return new MockSqlParameter();
        }

        /// <summary>
        /// Gets or sets the database connection
        /// </summary>
        protected override DbConnection DbConnection
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the parameter collection
        /// </summary>
        protected override DbParameterCollection DbParameterCollection
        {
            get
            {
                return this.parameterCollection;
            }
        }

        /// <summary>
        /// Gets or sets the database transaction
        /// </summary>
        protected override DbTransaction DbTransaction
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this is design time visible
        /// </summary>
        public override bool DesignTimeVisible
        {
            get;
            set;
        }

        /// <summary>
        /// Executes the database data reader command using mock framework
        /// </summary>
        /// <param name="behavior">The command behaviour</param>
        /// <returns>A database data reader</returns>
        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            Assert.IsTrue((this.Connection.State & ConnectionState.Open) == ConnectionState.Open, "Connection has to be opened when executing a command");
            
            MockQueryResult mockResult = null;

            if (this.settings.RecordingMode)
            {
                mockResult = this.RecordExecuteDbDataReader();
            }
            else
            {
                string commandKey = this.GetCommandKey();
                mockResult = FindMockResult(this.settings.MockId, this.Connection.Database, commandKey, this.settings.IsolatedQueries);

                if (mockResult == null || mockResult.DataSetResult == null)
                {
                    if (mockResult != null && mockResult.ExceptionResult != null)
                    {
                        throw mockResult.ExceptionResult.Exception;
                    }
                    else
                    {
                        throw new NotSupportedException(string.Format("Mock SqlConnection does not know how to handle query: '{0}'", commandKey));
                    }
                }
            }

            return mockResult.DataSetResult.DataSet.CreateDataReader();
        }

        /// <summary>
        /// Executes a non query command
        /// </summary>
        /// <returns>0</returns>
        public override int ExecuteNonQuery()
        {
            Assert.IsTrue((this.Connection.State & ConnectionState.Open) == ConnectionState.Open, "Connection has to be opened when executing command");

            if (this.CommandText.StartsWith("USE ", StringComparison.OrdinalIgnoreCase))
            {
                string databaseName = this.CommandText.Substring(4).Trim();

                if (databaseName.StartsWith("[", StringComparison.OrdinalIgnoreCase) && databaseName.EndsWith("]", StringComparison.OrdinalIgnoreCase))
                {
                    databaseName = databaseName.Substring(1, databaseName.Length - 2).Replace("]]", "]");
                }

                this.Connection.ChangeDatabase(databaseName);
            }

            //If recording actually run the command to affect the db
            if(this.settings.RecordingMode)
            {
                using (SqlConnection connection = this.CreateSqlConnection())
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandTimeout = 300;
                    cmd.CommandType = this.CommandType;
                    cmd.CommandText = this.CommandText;
                    
                    cmd.ExecuteNonQuery();
                }
            }

            return 0;
        }

        /// <summary>
        /// Executes a scalar command against the mock framework
        /// </summary>
        /// <returns>The scalar result of the query, or null if none exist</returns>
        public override object ExecuteScalar()
        {
            Assert.IsTrue((this.Connection.State & ConnectionState.Open) == ConnectionState.Open, "Connection has to be opened when executing command");

            MockQueryResult mockResult = null;

            if (this.settings.RecordingMode)
            {
                mockResult = this.RecordExecuteScalar();
            }
            else
            {
                string commandKey = this.GetCommandKey();
                FindMockResult(this.settings.MockId, this.Connection.Database, commandKey, this.settings.IsolatedQueries);
            }

            return mockResult != null ? mockResult.ScalarResult : null;
        }
        
        /// <summary>
        /// No-op
        /// </summary>
        public override void Prepare()
        {
        }

        /// <summary>
        /// Gets or sets the UpdateRowSource
        /// </summary>
        public override UpdateRowSource UpdatedRowSource
        {
            get;
            set;
        }

        #region Query Recording

        /// <summary>
        /// Creates a sql connection
        /// </summary>
        /// <returns></returns>
        private SqlConnection CreateSqlConnection()
        {
            //SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(this.settings.SqlConnectionString);
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(this.Connection.ConnectionString);
            csb.InitialCatalog = this.Connection.Database;
            csb["Encrypt"] = false;
            string connectionString = csb.ToString();

            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Records the results of calling execute scalar on the command
        /// </summary>
        /// <returns>The result of executing the command</returns>
        private MockQueryResult RecordExecuteScalar()
        {
            MockQueryResult mockResult = new MockQueryResult();

            using (SqlConnection connection = this.CreateSqlConnection())
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandTimeout = 120;
                cmd.CommandType = this.CommandType;
                cmd.CommandText = this.CommandText;

                foreach (DbParameter param in this.Parameters)
                {
                    SqlParameter sqlParam = new SqlParameter(param.ParameterName, param.DbType);
                    sqlParam.Value = param.Value;
                    cmd.Parameters.Add(sqlParam);
                }

                mockResult.ScalarResult = cmd.ExecuteScalar();

                mockResult.CommandText = this.GetCommandKey();
                mockResult.DatabaseName = this.DbConnection.Database;
                mockResult.MockId = this.settings.MockId;
            }

            this.SaveMockResult(mockResult);

            return mockResult;
        }

        /// <summary>
        /// Record the result of calling Execute database data reader
        /// </summary>
        /// <returns>The mock query results</returns>
        private MockQueryResult RecordExecuteDbDataReader()
        {
            MockQueryResult mockResult = new MockQueryResult();

            mockResult.CommandText = this.GetCommandKey();
            mockResult.DatabaseName = this.DbConnection.Database;
            mockResult.MockId = this.settings.MockId;

            try
            {
                using (SqlConnection connection = this.CreateSqlConnection())
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = this.CommandType;
                    cmd.CommandText = this.CommandText;

                    foreach (DbParameter param in this.Parameters)
                    {
                        SqlParameter sqlParam = new SqlParameter(param.ParameterName, param.DbType);
                        if (param.Value == null)
                        {
                            sqlParam.Value = DBNull.Value;
                        }
                        else
                        {
                            sqlParam.Value = param.Value;
                        }
                        cmd.Parameters.Add(sqlParam);
                    }

                    DataSet dataSet = new DataSet();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataSet);

                    mockResult.DataSetResult = new MockDataSet(dataSet);
                }

                this.SaveMockResult(mockResult);

                return mockResult;
            }
            catch (SqlException e)
            {
                // Record any exceptions generated
                mockResult.ExceptionResult = new MockException(e);
                this.SaveMockResult(mockResult);

                // Rethrow exception to caller
                throw;
            }
        }

        /// <summary>
        /// Save the mock results to a file.
        /// </summary>
        /// <param name="mockResult">The results to save</param>
        private void SaveMockResult(MockQueryResult mockResult)
        {
            string[] parts = mockResult.MockId.Split(new char[] { '.' });

            string fileName = Path.Combine(this.settings.OutputPath, parts[0] + ".xml");

            MockQueryResultSet mockResultSet = null;
            if (File.Exists(fileName))
            {
                string fileText = File.ReadAllText(fileName).Trim();

                if (fileText != String.Empty)
                {
                    using (Stream stream = new MemoryStream(System.Text.UnicodeEncoding.UTF8.GetBytes(fileText)))
                    {
                        mockResultSet = MockQueryResultSet.Deserialize(stream);
                    }
                }
            }

            if (mockResultSet == null)
            {
                mockResultSet = new MockQueryResultSet();
            }

            string mockResultKey = NormalizeCommandText(mockResult.CommandText);

            int matchIdx = -1;
            for (int idx = 0; idx < mockResultSet.CommandResults.Count; idx++)
            {
                MockQueryResult currentResult = mockResultSet.CommandResults[idx];

                if (NormalizeCommandText(currentResult.CommandText) == mockResultKey &&
                    currentResult.DatabaseName == mockResult.DatabaseName &&
                    currentResult.MockId == mockResult.MockId)
                {
                    matchIdx = idx;
                    break;
                }
            }

            if (matchIdx >= 0)
            {
                mockResultSet.CommandResults[matchIdx] = mockResult;
            }
            else
            {
                mockResultSet.CommandResults.Add(mockResult);
            }

            using (Stream stream = File.Open(fileName, FileMode.Create, FileAccess.Write))
            {
                MockQueryResultSet.Serialize(stream, mockResultSet);
            }

            AddMockResult(mockResult);
        }

        /// <summary>
        /// Get a key based on the command text
        /// </summary>
        /// <returns>The command key</returns>
        private string GetCommandKey()
        {
            string key = this.CommandText;

            // substitue parameter names by their values
            foreach (DbParameter parameter in this.parameterCollection)
            {
                string value;

                if (parameter.Value == DBNull.Value)
                {
                    value = string.Empty;
                }
                else
                {
                    switch (parameter.DbType)
                    {
                        case DbType.AnsiString:
                        case DbType.AnsiStringFixedLength:
                            value = (string)parameter.Value;
                            break;
                        case DbType.String:
                        case DbType.StringFixedLength:
                            value = (string)parameter.Value;
                            break;
                        case DbType.Boolean:
                            value = (bool)parameter.Value ? "1" : "0";
                            break;
                        default:
                            value = parameter.Value.ToString();
                            break;
                    }
                }

                key = key.Replace(parameter.ParameterName, value);
            }

            key = TempTableNameRegex.Replace(key, TempTableName);

            return key;
        }

        #endregion

        #region Query Execution Results

        /// <summary>
        /// Normalizes the command text by removing excess white spaces
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        private static string NormalizeCommandText(string commandText)
        {
            return WhiteSpaceRegex.Replace(commandText, " ").Trim();
        }

        /// <summary>
        /// Adds a mock result to this list of results.
        /// </summary>
        /// <param name="mockResult">the mock result to add</param>
        private static void AddMockResult(MockQueryResult mockResult)
        {
            List<MockQueryResult> list;

            string key = NormalizeCommandText(mockResult.CommandText);
            if (!mockResults.TryGetValue(key, out list))
            {
                list = new List<MockQueryResult>();
                mockResults.Add(key, list);
            }

            list.Add(mockResult);
        }

        /// <summary>
        /// Find the rank of a match.
        /// </summary>
        /// <param name="candidateId">The id of the candidate matcj</param>
        /// <param name="mockId">The id of the mock to compare.</param>
        /// <param name="isolatedQuery">whether or not is an isolated query</param>
        /// <returns>-1 for bad match, number of parts matched otherwize.</returns>
        private static int GetMatchRank(string candidateId, string mockId, bool isolatedQuery)
        {
            if ((candidateId == null) || (mockId == null))
                return isolatedQuery ? -1 : 0;

            string[] mockParts = mockId.Split(new char[] { '.' });
            string[] candidateParts = candidateId.Split(new char[] { '.' });

            if (candidateParts.Length > mockParts.Length)
            {
                return -1;
            }

            for (int idx = 0; idx < candidateParts.Length; idx++)
            {
                if (candidateParts[idx] != mockParts[idx])
                {
                    return -1;
                }
            }

            return candidateParts.Length;
        }

        /// <summary>
        /// Find the mock results for the given input
        /// </summary>
        /// <param name="mockId">The mock id of the command</param>
        /// <param name="databaseName">The database name being used</param>
        /// <param name="commandText">The command text being used</param>
        /// <param name="isolatedQuery">Whether or not it is an isolated query</param>
        /// <returns>null, or the matching query results</returns>
        private static MockQueryResult FindMockResult(string mockId, string databaseName, string commandText, bool isolatedQuery)
        {
            Assert.IsNotNull(databaseName);
            Assert.IsNotNull(commandText);

            string key = NormalizeCommandText(commandText);

            if (!mockResults.ContainsKey(key))
            {
                return null;
            }

            // Find all candidates, with matching mockId and databaseName.
            // We prefer the candidate with exact match on mockId in first place and with exact match on databaseName in second place.
            var candidates =
                (from MockQueryResult mr in mockResults[key]
                 where (GetMatchRank(mr.MockId, mockId, isolatedQuery) >= 0) &&
                   (mr.DatabaseName == databaseName || mr.DatabaseName == null)
                 orderby GetMatchRank(mr.MockId, mockId, isolatedQuery) descending, mr.DatabaseName == databaseName descending
                 select mr).ToArray();

            // Return the best candidate.
            return candidates.Length > 0 ? candidates[0] : null;
        }

        /// <summary>
        /// Used to initialize the mock results
        /// </summary>
        private static void InitializeMockResults()
        {
            string path = "./TSqlMockSessions".AsAbsoluteLocation();

            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                using (FileStream stream = new FileStream(file, FileMode.Open))
                {
                    MockQueryResultSet mockResultSet = MockQueryResultSet.Deserialize(stream);

                    if (mockResultSet.CommandResults != null)
                    {
                        foreach (MockQueryResult mockResult in mockResultSet.CommandResults)
                        {
                            AddMockResult(mockResult);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
