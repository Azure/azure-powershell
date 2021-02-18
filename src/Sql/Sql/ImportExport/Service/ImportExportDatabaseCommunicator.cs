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

<<<<<<< HEAD
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
=======
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;

using Newtonsoft.Json;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

namespace Microsoft.Azure.Commands.Sql.Database.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the import/export REST endpoints
    /// </summary>
    public class ImportExportDatabaseCommunicator
    {
        /// <summary>
<<<<<<< HEAD
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }

        /// <summary>
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
<<<<<<< HEAD
=======
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// The response header handler
        /// </summary>
        private ImportExportResponseHeaderHandler ResponseHeaderHandler { get; set; }

        private static Uri LastLocationHeader { get; set; }

        private ManualResetEvent LocationHeaderResetEvent = new ManualResetEvent(false);

        /// <summary>
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        /// Creates a communicator for Azure Sql Databases
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="subscription"></param>
        public ImportExportDatabaseCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
<<<<<<< HEAD
=======
                ResponseHeaderHandler = new ImportExportResponseHeaderHandler();

                ImportExportResponseHeaderHandler.OnHttpResponseEvent += ImportExportResponseHeaderHandler_OnHttpResponseEvent;
            }
        }

        private void ImportExportResponseHeaderHandler_OnHttpResponseEvent(HttpResponseHeaders headers)
        {
            if (headers.Location != null && headers.Location.ToString().Contains("importExportOperationResults"))
            {
                LastLocationHeader = headers.Location;
                LocationHeaderResetEvent.Set();
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }
        }

        /// <summary>
        /// Creates new export request
        /// </summary>
<<<<<<< HEAD
        public Management.Sql.LegacySdk.Models.ImportExportResponse Export(string resourceGroupName, string serverName, string databaseName, ExportRequestParameters parameters)
        {
            return GetCurrentSqlClient().ImportExport.Export(resourceGroupName, serverName, databaseName, parameters);
=======
        public ImportExportOperationResult BeginExport(string resourceGroupName, string serverName, string databaseName, ExportDatabaseDefinition parameters, out Uri operationStatusLink)
        {
            LastLocationHeader = null;
            LocationHeaderResetEvent.Reset();
            ImportExportOperationResult result = GetCurrentSqlClient().Databases.BeginExport(resourceGroupName, serverName, databaseName, parameters);
            LocationHeaderResetEvent.WaitOne(3000);
            operationStatusLink = LastLocationHeader;
            return result;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        /// <summary>
        /// Creates new import request
        /// </summary>
<<<<<<< HEAD
        public Management.Sql.LegacySdk.Models.ImportExportResponse Import(string resourceGroupName, string serverName, ImportRequestParameters parameters)
        {
            return GetCurrentSqlClient().ImportExport.Import(resourceGroupName, serverName, parameters);
        }

        /// <summary>
        /// Gets the status of an import/export operations
        /// </summary>
        public Management.Sql.LegacySdk.Models.ImportExportOperationStatusResponse GetStatus(string operationStatusLink)
        {
            return GetCurrentSqlClient().ImportExport.GetImportExportOperationStatus(operationStatusLink);
=======
        public ImportExportOperationResult BeginImportNewDatabase(string resourceGroupName, string serverName, ImportNewDatabaseDefinition parameters, out Uri operationStatusLink)
        {
            LastLocationHeader = null;
            LocationHeaderResetEvent.Reset();
            ImportExportOperationResult result = GetCurrentSqlClient().Servers.BeginImportDatabase(resourceGroupName, serverName, parameters);
            LocationHeaderResetEvent.WaitOne(3000);
            operationStatusLink = LastLocationHeader;
            return result;
        }

        /// <summary>
        /// Get the status of an operation given a raw Operation Status Link
        /// </summary>
        /// <param name="operationStatusLink">Status link as returned by the import or export commandlet</param>
        /// <param name="rawHttpResponse">Out parameter for the raw HTTP response for further inspection</param>
        /// <returns></returns>
        public ImportExportOperationResult GetOperationStatus(string operationStatusLink, out HttpResponseMessage rawHttpResponse)
        {
            var client = GetCurrentSqlClient();

            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(operationStatusLink)
            };

            client.Credentials.ProcessHttpRequestAsync(httpRequest, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            var response = client.HttpClient.SendAsync(httpRequest, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();

            response.EnsureSuccessStatusCode();

            rawHttpResponse = response;
            string responseString = response.Content.ReadAsStringAsync().Result;

            ImportExportOperationResult operationResult = JsonConvert.DeserializeObject<ImportExportOperationResult>(responseString, new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>() { new Rest.Serialization.TransformationJsonConverter() },
                NullValueHandling = NullValueHandling.Ignore
            });

            return operationResult;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
<<<<<<< HEAD
                SqlClient = AzureSession.Instance.ClientFactory.CreateClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return SqlClient;
        }
    }
=======
                AzureSession.Instance.ClientFactory.AddHandler(ResponseHeaderHandler);
                SqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }

            return SqlClient;
        }
    }

    public class ImportExportResponseHeaderHandler : DelegatingHandler, ICloneable
    {
        public delegate void HttpResponseEventHandler(HttpResponseHeaders headers);

        public static event HttpResponseEventHandler OnHttpResponseEvent;

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            OnHttpResponseEvent?.Invoke(response.Headers);

            return response;
        }

        public object Clone()
        {
            return new ImportExportResponseHeaderHandler();
        }
    }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}
