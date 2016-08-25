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
using System.Text;

namespace Microsoft.Azure.Commands.Sql.SecureConnection.Model
{
    /// <summary>
    /// A class representing the secure connection strings
    /// </summary>
    public class ConnectionStrings
    {
        public ConnectionStrings(string proxyDnsName, string port, string serverName, string dbName)
        {
            AdoNetConnectionString = ConstructAdoNetConnectionString(proxyDnsName, port, serverName, dbName);
            OdbcConnectionString = ConstructOdbcConnectionString(proxyDnsName, port, serverName, dbName);
            PhpConnectionString = ConstructPhpConnectionString(proxyDnsName, port, serverName, dbName);
            JdbcConnectionString = ConstructJdbcConnectionString(proxyDnsName, port, serverName, dbName);
        }

        /// <summary>
        /// Gets the Ado.Net connection string
        /// </summary>
        public string AdoNetConnectionString { get; internal set; }

        /// <summary>
        /// Gets the ODBC connection string
        /// </summary>
        public string OdbcConnectionString { get; internal set; }

        /// <summary>
        /// Gets the PhP connection string
        /// </summary>
        public string PhpConnectionString { get; internal set; }

        /// <summary>
        /// Gets the JDBC connection string
        /// </summary>
        public string JdbcConnectionString { get; internal set; }

        /// <summary>
        /// Constructs the PhP connection string
        /// </summary>
        private string ConstructPhpConnectionString(string proxyDnsName, string port, string serverName, string databaseName)
        {
            string enterUser = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterUserId;
            string enterPassword = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterPassword;
            string pdoTitle = Microsoft.Azure.Commands.Sql.Properties.Resources.PdoTitle;
            string sqlServerSampleTitle = Microsoft.Azure.Commands.Sql.Properties.Resources.sqlSampleTitle;
            string connectionError = Microsoft.Azure.Commands.Sql.Properties.Resources.PhpConnectionError;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Server: {0}, {1}", proxyDnsName, port)).Append(Environment.NewLine);
            sb.Append(string.Format("SQL Database: {0}", databaseName)).Append(Environment.NewLine);
            sb.Append(string.Format("User Name: {0}", enterUser)).Append(Environment.NewLine).Append(Environment.NewLine);
            sb.Append(pdoTitle).Append(Environment.NewLine);
            sb.Append("try{").Append(Environment.NewLine);
            sb.Append(string.Format("$conn = new PDO ( \"sqlsrv:server = tcp:{0},{1}; Database = \"{2}\", \"{3}\", \"{4}\");",
                                                proxyDnsName, port, databaseName, enterUser, enterPassword)).Append(Environment.NewLine);
            sb.Append("$conn->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION );").Append(Environment.NewLine);
            sb.Append("}").Append(Environment.NewLine);
            sb.Append("catch ( PDOException $e ) {").Append(Environment.NewLine);
            sb.Append(string.Format("print( \"{0}\" );", connectionError)).Append(Environment.NewLine);
            sb.Append("die(print_r($e));").Append(Environment.NewLine);
            sb.Append("}").Append(Environment.NewLine);
            sb.Append(sqlServerSampleTitle).Append(Environment.NewLine).Append(Environment.NewLine);
            sb.Append(string.Format("connectionInfo = array(\"UID\" => \"{0}@{1}\", \"pwd\" => \"{2}\", \"Database\" => \"{3}\", \"LoginTimeout\" => 30, \"Encrypt\" => 1);",
                                                enterUser, serverName, enterPassword, databaseName)).Append(Environment.NewLine);
            sb.Append(string.Format("$serverName = \"tcp:{0},{1}\";", proxyDnsName, port)).Append(Environment.NewLine);
            sb.Append("$conn = sqlsrv_connect($serverName, $connectionInfo);");
            return sb.ToString();
        }

        /// <summary>
        /// Constructs the ODBC connection string
        /// </summary>
        private string ConstructOdbcConnectionString(string proxyDnsName, string port, string serverName, string databaseName)
        {
            string enterUser = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterUserId;
            string enterPassword = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterPassword;
            StringBuilder sb = new StringBuilder();
            sb.Append("Driver={SQL Server Native Client 11.0};");
            sb.Append(string.Format("Server=tcp:{0},{1};", proxyDnsName, port));
            sb.Append(string.Format("Database={0};", databaseName));
            sb.Append(string.Format("Uid={0}@{1};", enterUser, serverName));
            sb.Append(string.Format("Pwd={0};", enterPassword));
            sb.Append("Encrypt=yes;Connection Timeout=30;");
            return sb.ToString();
        }

        /// <summary>
        /// Constructs the JDBC connection string
        /// </summary>
        private string ConstructJdbcConnectionString(string proxyDnsName, string port, string serverName, string databaseName)
        {
            string enterUser = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterUserId;
            string enterPassword = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterPassword;
            return string.Format("jdbc:sqlserver://{0}:{1};database={2};user={3}@{4};password={5};encrypt=true;hostNameInCertificate=*.database.secure.windows.net;loginTimeout=30;",
                proxyDnsName, port, databaseName, enterUser, serverName, enterPassword);
        }

        /// <summary>
        /// Constructs the ADO.NET connection string
        /// </summary>
        private string ConstructAdoNetConnectionString(string proxyDnsName, string port, string serverName, string databaseName)
        {
            string enterUser = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterUserId;
            string enterPassword = Microsoft.Azure.Commands.Sql.Properties.Resources.EnterPassword;
            return string.Format("Server=tcp:{0},{1};Database={2};User ID={3}@{4};Password={5};Trusted_Connection=False;Encrypt=True;Connection Timeout=30",
                proxyDnsName, port, databaseName, enterUser, serverName, enterPassword);
        }
    }
}