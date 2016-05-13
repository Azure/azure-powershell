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
using System.Globalization;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Sql;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase
{
    /// <summary>
    /// The base class for all Microsoft Azure Sql Database Management Cmdlets
    /// </summary>
    public abstract class SqlDatabaseCmdletBase : AzureSMCmdlet
    {
        /// <summary>
        /// Stores the session Id for all the request made in this session.
        /// </summary>
        internal static string clientSessionId;

        static SqlDatabaseCmdletBase()
        {
            clientSessionId = SqlDatabaseCmdletBase.GenerateClientTracingId();
        }

        /// <summary>
        /// Generates a client side tracing Id of the format:
        /// [Guid]-[Time in UTC]
        /// </summary>
        /// <returns>A string representation of the client side tracing Id.</returns>
        public static string GenerateClientTracingId()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}-{1}",
                Guid.NewGuid().ToString(),
                DateTime.UtcNow.ToString("u"));
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        protected SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            AzureSubscription subscription = Profile.Context.Subscription;
            SqlDatabaseCmdletBase.ValidateSubscription(subscription);
            SqlManagementClient client = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(Profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            client.HttpClient.DefaultRequestHeaders.Add(Constants.ClientSessionIdHeaderName, clientSessionId);
            client.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, clientRequestId);
            return client;
        }

        /// <summary>
        /// Validates that the given subscription is valid.
        /// </summary>
        /// <param name="subscription">The <see cref="AzureSubscription"/> to validate.</param>
        public static void ValidateSubscription(AzureSubscription subscription)
        {
            if (subscription == null)
            {
                throw new ArgumentException(
                    Common.Properties.Resources.InvalidDefaultSubscription);
            }
        }

        /// <summary>
        /// Stores the per request session Id for all request made in this cmdlet call.
        /// </summary>
        protected string clientRequestId;

        internal SqlDatabaseCmdletBase()
        {
            this.clientRequestId = SqlDatabaseCmdletBase.GenerateClientTracingId();
        }

        protected void WriteErrorDetails(Exception exception)
        {
            // Call the handler to parse and write error details.
            SqlDatabaseExceptionHandler.WriteErrorDetails(this, this.clientRequestId, exception);
        }
    }
}