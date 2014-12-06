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
        public static IServerDataServiceContext GetContext(
            PSCmdlet cmdlet,
            string serverName,
            Uri manageUrl,
            SqlAuthenticationCredentials credentials,
            Guid sessionActivityId,
            Uri managementServiceUri)
        {
            Version version = GetVersion(manageUrl, credentials);

            IServerDataServiceContext context = null;

            if (version.Major >= 12)
            {
                context = new TSqlConnectionContext(
                    sessionActivityId,
                    manageUrl.Host,
                    credentials.UserName,
                    credentials.Password);
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
