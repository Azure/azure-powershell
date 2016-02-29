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
using System.Data.Services.Client;
using System.Linq;
using System.Management.Automation;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Properties;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using System.IO;
using Microsoft.Azure.ServiceManagemenet.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Database.Cmdlet
{
    /// <summary>
    /// A cmdlet to Connect to a SQL server administration data service.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureSqlDatabaseServerContext", ConfirmImpact = ConfirmImpact.None,
        DefaultParameterSetName = ServerNameWithSqlAuthParamSet)]
    public class NewAzureSqlDatabaseServerContext : AzureSMCmdlet
    {
        #region ParameterSet Names

        /// <summary>
        /// The name of the parameter set for creating a context with SQL authentication by Server Name
        /// </summary>
        internal const string ServerNameWithSqlAuthParamSet =
            "ByServerNameWithSqlAuth";

        /// <summary>
        /// The name of the parameter set for creating a context with SQL authentication by FQSN
        /// </summary>
        internal const string FullyQualifiedServerNameWithSqlAuthParamSet =
            "ByFullyQualifiedServerNameWithSqlAuth";

        /// <summary>
        /// The name of the parameter set for creating a context with SQL authentication by Manage Url
        /// </summary>
        internal const string ManageUrlWithSqlAuthParamSet =
            "ByManageUrlWithSqlAuth";

        /// <summary>
        /// The name of the parameter set for creating a context with certificate
        /// authentication by Server Name
        /// </summary>
        internal const string ServerNameWithCertAuthParamSet =
            "ByServerNameWithCertAuth";

        /// <summary>
        /// The name of the parameter set for creating a context with certificate
        /// authentication by FQSN
        /// </summary>
        internal const string FullyQualifiedServerNameWithCertAuthParamSet =
            "ByFullyQualifiedServerNameWithCertAuth";

        #endregion

        #region Parameters

        /// <summary>
        /// Gets or sets the management site data connection server name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            ParameterSetName = ServerNameWithSqlAuthParamSet,
            HelpMessage = "The short server name")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            ParameterSetName = ManageUrlWithSqlAuthParamSet,
            HelpMessage = "The short server name")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            ParameterSetName = ServerNameWithCertAuthParamSet,
            HelpMessage = "The short server name")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the management site data connection fully qualified server name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0,
            ParameterSetName = FullyQualifiedServerNameWithSqlAuthParamSet,
            HelpMessage = "The fully qualified server name")]
        [Parameter(Mandatory = true, Position = 0,
            ParameterSetName = FullyQualifiedServerNameWithCertAuthParamSet,
            HelpMessage = "The fully qualified server name")]
        [ValidateNotNull]
        public string FullyQualifiedServerName { get; set; }

        /// <summary>
        /// Gets or sets the management <see cref="Uri"/>.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ManageUrlWithSqlAuthParamSet,
            HelpMessage = "The full management Url for the server")]
        [ValidateNotNullOrEmpty]
        public Uri ManageUrl { get; set; }

        /// <summary>
        /// Gets or sets the server credentials
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            ParameterSetName = ServerNameWithSqlAuthParamSet,
            HelpMessage = "The credentials for the server")]
        [Parameter(Mandatory = true, Position = 1,
            ParameterSetName = FullyQualifiedServerNameWithSqlAuthParamSet,
            HelpMessage = "The credentials for the server")]
        [Parameter(Mandatory = true, Position = 1,
            ParameterSetName = ManageUrlWithSqlAuthParamSet,
            HelpMessage = "The credentials for the server")]
        [ValidateNotNull]
        public PSCredential Credential { get; set; }

        /// <summary>
        /// Gets or sets whether or not the current subscription should be used for authentication
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            ParameterSetName = ServerNameWithCertAuthParamSet,
            HelpMessage = "Use certificate authentication")]
        [Parameter(Mandatory = true, Position = 1,
            ParameterSetName = FullyQualifiedServerNameWithCertAuthParamSet,
            HelpMessage = "Use certificate authentication")]
        public SwitchParameter UseSubscription { get; set; }

        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true,
            ParameterSetName = ServerNameWithCertAuthParamSet,
            HelpMessage = "The subscription to use, or uses the current subscription if not specified")]
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true,
             ParameterSetName = FullyQualifiedServerNameWithCertAuthParamSet,
             HelpMessage = "The subscription to use, or uses the current subscription if not specified")]
        public string SubscriptionName { get; set; }

        #endregion

        #region Current Subscription Management

        private AzureSubscription CurrentSubscription
        {
            get
            {
                if (string.IsNullOrEmpty(SubscriptionName))
                {
                    return Profile.Context.Subscription;
                }

                ProfileClient client = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));

                return client.Profile.Subscriptions.Values.First(
                        s => SubscriptionName == s.Name);
            }
        }

        #endregion

        /// <summary>
        /// Connect to a Azure SQL Server with the given ManagementService Uri using
        /// SQL authentication credentials.
        /// </summary>
        /// <param name="serverName">The server name.</param>
        /// <param name="managementServiceUri">The server's ManagementService Uri.</param>
        /// <param name="credentials">The SQL Authentication credentials for the server.</param>
        /// <returns>A new <see cref="ServerDataServiceSqlAuth"/> context,
        /// or <c>null</c> if an error occurred.</returns>
        internal IServerDataServiceContext GetServerDataServiceBySqlAuth(
            string serverName,
            Uri managementServiceUri,
            SqlAuthenticationCredentials credentials,
            Uri manageUrl)
        {
            IServerDataServiceContext context = null;
            Guid sessionActivityId = Guid.NewGuid();

            try
            {
                context = SqlAuthContextFactory.GetContext(this, serverName, manageUrl, credentials, sessionActivityId, managementServiceUri);
            }
            catch (Exception ex)
            {
                SqlDatabaseExceptionHandler.WriteErrorDetails(
                    this,
                    sessionActivityId.ToString(),
                    ex);

                // The context is not in an valid state because of the error, set the context 
                // back to null.
                context = null;
            }

            return context;
        }

        /// <summary>
        /// Connect to Azure SQL Server using certificate authentication.
        /// </summary>
        /// <param name="serverName">The name of the server to connect to</param>
        /// <param name="subscription">The subscription data to use for authentication</param>
        /// <returns>A new <see cref="ServerDataServiceCertAuth"/> context,
        /// or <c>null</c> if an error occurred.</returns>
        internal ServerDataServiceCertAuth GetServerDataServiceByCertAuth(
            string serverName,
            AzureSubscription subscription)
        {
            ServerDataServiceCertAuth context = null;
            SqlDatabaseCmdletBase.ValidateSubscription(subscription);

            try
            {
                context = ServerDataServiceCertAuth.Create(serverName, Profile, subscription);
            }
            catch (ArgumentException e)
            {
                SqlDatabaseExceptionHandler.WriteErrorDetails(this, string.Empty, e);

                context = null;
            }

            return context;
        }

        /// <summary>
        /// Creates a new operation context based on the Cmdlet's parameter set and the manageUrl.
        /// </summary>
        /// <param name="serverName">The server name.</param>
        /// <param name="managementServiceUri">The server's ManagementService Uri.</param>
        /// <returns>A new operation context for the server.</returns>
        internal IServerDataServiceContext CreateServerDataServiceContext(
            string serverName,
            Uri managementServiceUri,
            Uri manageUrl)
        {
            switch (this.ParameterSetName)
            {
                case ServerNameWithSqlAuthParamSet:
                case FullyQualifiedServerNameWithSqlAuthParamSet:
                case ManageUrlWithSqlAuthParamSet:
                    // Obtain the Server DataService Context by Sql Authentication
                    SqlAuthenticationCredentials credentials = this.GetSqlAuthCredentials();
                    return this.GetServerDataServiceBySqlAuth(
                        serverName,
                        managementServiceUri,
                        credentials,
                        manageUrl);

                case FullyQualifiedServerNameWithCertAuthParamSet:
                case ServerNameWithCertAuthParamSet:
                    // Get the current subscription data.
                    AzureSubscription subscription = CurrentSubscription;

                    // Create a context using the subscription datat
                    return this.GetServerDataServiceByCertAuth(
                       serverName,
                       subscription);

                default:
                    throw new InvalidOperationException(Resources.UnknownParameterSet);
            }
        }

        /// <summary>
        /// Process the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                // First obtain the Management Service Uri and the ServerName
                Uri manageUrl = this.GetManageUrl(this.ParameterSetName);
                Uri managementServiceUri = DataConnectionUtility.GetManagementServiceUri(manageUrl);
                string serverName = this.GetServerName(manageUrl);

                // Creates a new Server Data Service Context for the service
                IServerDataServiceContext operationContext =
                    this.CreateServerDataServiceContext(serverName, managementServiceUri, manageUrl);

                if (operationContext != null)
                {
                    this.WriteObject(operationContext);
                }
            }
            catch (Exception ex)
            {
                this.WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
            }
        }

        #region Parameter Parsing Helpers

        /// <summary>
        /// Obtain the ManageUrl based on the Cmdlet's parameter set.
        /// </summary>
        /// <param name="parameterSetName">The name of the invoking parameter set.</param>
        /// <returns>The ManageUrl based on the Cmdlet's parameter set.</returns>
        private Uri GetManageUrl(string parameterSetName)
        {
            switch (parameterSetName)
            {
                case ServerNameWithSqlAuthParamSet:
                case ServerNameWithCertAuthParamSet:
                    // Only the server name was specified, eg. 'server001'. Prepend the Uri schema
                    // and append the azure database DNS suffix.
                    return new Uri(
                        Uri.UriSchemeHttps + Uri.SchemeDelimiter +
                        this.ServerName + Profile.Context.Environment.GetEndpoint(AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix));
                case FullyQualifiedServerNameWithSqlAuthParamSet:
                case FullyQualifiedServerNameWithCertAuthParamSet:
                    // The fully qualified server name was specified, 
                    // eg. 'server001.database.windows.net'. Prepend the Uri schema.
                    return new Uri(
                        Uri.UriSchemeHttps + Uri.SchemeDelimiter +
                        this.FullyQualifiedServerName);
                case ManageUrlWithSqlAuthParamSet:
                    // The full ManageUrl was specified, 
                    // eg. 'https://server001.database.windows.net'. Return as is.
                    return this.ManageUrl;
                default:
                    // Should never get to here, this is an invalid parameter set
                    throw new InvalidOperationException(Resources.UnknownParameterSet);
            }
        }

        /// <summary>
        /// Obtain the ServerName based on the Cmdlet's parameter set.
        /// </summary>
        /// <param name="manageUrl">The server's manageUrl.</param>
        /// <returns>The ServerName based on the Cmdlet's parameter set.</returns>
        private string GetServerName(Uri manageUrl)
        {
            if (this.MyInvocation.BoundParameters.ContainsKey("ServerName"))
            {
                // Server name is specified, return as is.
                return this.ServerName;
            }
            else
            {
                // Server name is not specified, use the first subdomain name in the manageUrl.
                return manageUrl.Host.Split('.').First();
            }
        }

        /// <summary>
        /// Obtain the SQL Authentication Credentials based on the Cmdlet's parameter set.
        /// </summary>
        /// <returns>The Credentials based on the Cmdlet's parameter set.</returns>
        private SqlAuthenticationCredentials GetSqlAuthCredentials()
        {
            if (this.MyInvocation.BoundParameters.ContainsKey("Credential"))
            {
                return new SqlAuthenticationCredentials(
                    this.Credential.UserName,
                    this.Credential.Password);
            }
            else
            {
                throw new ArgumentException(Resources.CredentialNotSpecified);
            }
        }

        #endregion
    }
}
