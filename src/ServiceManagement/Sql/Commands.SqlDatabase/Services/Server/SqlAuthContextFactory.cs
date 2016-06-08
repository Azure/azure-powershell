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

using Microsoft.WindowsAzure.Commands.SqlDatabase.Properties;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server
{
    public class SqlAuthContextFactory
    {
        /// <summary>
        /// The different sql versions available
        /// </summary>
        internal enum SqlVersion
        {
            /// <summary>
            /// Not set.  Determine by querying the server
            /// </summary>
            None,

            /// <summary>
            /// V2 server
            /// </summary>
            v2,

            /// <summary>
            /// V12 server
            /// </summary>
            v12
        }
        internal static SqlVersion sqlVersion = SqlVersion.None;

        /// <summary>
        /// Gets a sql auth connection context.
        /// </summary>
        /// <param name="cmdlet">The cmdlet requesting the context</param>
        /// <param name="serverName">The name of the server to connect to</param>
        /// <param name="manageUrl">The manage url of the server</param>
        /// <param name="credentials">The credentials to connect to the server</param>
        /// <param name="sessionActivityId">The session activity ID</param>
        /// <param name="managementServiceUri">The URI for management service</param>
        /// <returns>The connection context</returns>
        public static IServerDataServiceContext GetContext(
            PSCmdlet cmdlet,
            string serverName,
            Uri manageUrl,
            SqlAuthenticationCredentials credentials,
            Guid sessionActivityId,
            Uri managementServiceUri)
        {
            Version version;
            
            // If a version was specified (by tests) us it.
            if (sqlVersion == SqlVersion.v2)
            {
                version = new Version(11, 0);
            }
            else if (sqlVersion == SqlVersion.v12)
            {
                version = new Version(12, 0);
            }
            else // If no version specified, determine the version by querying the server.
            {
                version = GetVersion(manageUrl, credentials);
            }
            sqlVersion = SqlVersion.None;

            IServerDataServiceContext context = null;

            if (version.Major >= 12)
            {
                context = new TSqlConnectionContext(
                    sessionActivityId,
                    manageUrl.Host,
                    credentials,
                    serverName);
            }
            else
            {
                context = ServerDataServiceSqlAuth.Create(
                    managementServiceUri,
                    sessionActivityId,
                    credentials,
                    serverName);

                // Retrieve $metadata to verify model version compatibility
                XDocument metadata = ((ServerDataServiceSqlAuth)context).RetrieveMetadata();
                XDocument filteredMetadata = DataConnectionUtility.FilterMetadataDocument(metadata);
                string metadataHash = DataConnectionUtility.GetDocumentHash(filteredMetadata);
                if (!((ServerDataServiceSqlAuth)context).metadataHashes.Any(knownHash => metadataHash == knownHash))
                {
                    cmdlet.WriteWarning(Resources.WarningModelOutOfDate);
                }

                ((ServerDataServiceSqlAuth)context).MergeOption = MergeOption.PreserveChanges;
            }

            return context;
        }

        /// <summary>
        /// Queries the server to get the server version
        /// </summary>
        /// <param name="manageUrl">The manage url of the server. Eg: https://{serverName}.database.windows.net</param>
        /// <param name="credentials">The login credentials</param>
        /// <returns>The server version</returns>
        private static Version GetVersion(Uri manageUrl, SqlAuthenticationCredentials credentials)
        {
            string serverName = manageUrl.Host.Split('.').First();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder["Server"] = manageUrl.Host;
            builder.UserID = credentials.UserName + "@" + serverName;
            builder.Password = credentials.Password;
            builder["Database"] = null;
            builder["Encrypt"] = false;
            builder.ConnectTimeout = 60;

            string commandText = "select serverproperty('ProductVersion')";

            using(SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandText, conn))
                {
                    conn.Open();

                    string val = (string)command.ExecuteScalar();
                    return new Version(val);
                }
            }
        }
    }
}
