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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.TSql
{
    public class MockSqlConnection : DbConnection
    {
        private int connectionCount = 0;
        private readonly object syncRoot = new object();
        private readonly MockSettings settings;

        /// <summary>
        /// Constructor for the mock sql connection
        /// </summary>
        public MockSqlConnection()
        {
            this.settings = MockSettings.RetrieveSettings();
        }

        public static DbConnection CreateConnection(string connectionString)
        {
            MockSqlConnection conn = new MockSqlConnection();
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(connectionString);
            csb["Encrypt"] = false;
            conn.ConnectionString = csb.ConnectionString;
            return conn;
        }

        /// <summary>
        /// Initializes the mock environment
        /// </summary>
        private void InitializeMockEnvironment()
        {
        }

        /// <summary>
        /// Cleans up the mock environment.
        /// </summary>
        private void CleanupMockEnvironment()
        {
        }

        /// <summary>
        /// Not supported
        /// </summary>
        /// <param name="isolationLevel">Not used</param>
        /// <returns>Not Used</returns>
        protected override DbTransaction BeginDbTransaction(System.Data.IsolationLevel isolationLevel)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Used to change which database is being queried
        /// </summary>
        /// <param name="databaseName">The name of the database to run the queries against</param>
        public override void ChangeDatabase(string databaseName)
        {
            if (!string.IsNullOrEmpty(this.ConnectionString))
            {
                SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(this.ConnectionString);
                csb.InitialCatalog = databaseName;

                this.ConnectionString = csb.ToString();
            }
        }

        /// <summary>
        /// Close the connection
        /// </summary>
        public override void Close()
        {
            lock (this.syncRoot)
            {
                this.connectionCount--;

                Assert.IsTrue(this.connectionCount >= 0, "Connection has been closed more times than opened. Check for correct pairing of Open/Close methods.");

                if (this.connectionCount == 0)
                {
                    this.CleanupMockEnvironment();
                }
            }
        }

        /// <summary>
        /// Gets or sets the sql connection string
        /// </summary>
        public override string ConnectionString
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a DB command for querying the database
        /// </summary>
        /// <returns></returns>
        protected override DbCommand CreateDbCommand()
        {
            return new MockSqlCommand(this, this.settings);
        }

        /// <summary>
        /// Gets the data source being queried
        /// </summary>
        public override string DataSource
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ConnectionString))
                {
                    SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(this.ConnectionString);
                    return csb.DataSource;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets the name of the database being queried
        /// </summary>
        public override string Database
        {
            get
            {
                string database;
                if (!string.IsNullOrEmpty(this.ConnectionString))
                {
                    SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(this.ConnectionString);
                    database = csb.InitialCatalog;
                }
                else
                {
                    database = null;
                }

                return !String.IsNullOrEmpty(database) ? database : "master";
            }
        }

        /// <summary>
        /// Opens a connection
        /// </summary>
        public override void Open()
        {
            lock (this.syncRoot)
            {
                if (this.connectionCount == 0)
                {
                    this.InitializeMockEnvironment();
                }

                this.connectionCount++;
            }
        }

        /// <summary>
        /// Returns the server version
        /// </summary>
        public override string ServerVersion
        {
            get
            {
                return "10.00.1600";
            }
        }

        /// <summary>
        /// Returns the state of the connection
        /// </summary>
        public override System.Data.ConnectionState State
        {
            get
            {
                return (0 < this.connectionCount) ? ConnectionState.Open : ConnectionState.Closed;
            }
        }
    }
}
