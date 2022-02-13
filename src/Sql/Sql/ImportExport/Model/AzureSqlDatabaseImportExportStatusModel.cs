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


namespace Microsoft.Azure.Commands.Sql.ImportExport.Model
{
    /// <summary>
    /// Represents an Azure Sql Database Import/Export Operation Status
    /// </summary>
    public class AzureSqlDatabaseImportExportStatusModel
    {
        /// <summary>
        /// Gets or sets the authentication type
        /// </summary>
        public string OperationStatusLink
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the error message returned from the server.
        /// </summary>
        public string ErrorMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the operation status last modified time.
        /// </summary>
        public string LastModifiedTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the operation queue time.
        /// </summary>
        public string QueuedTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the operation request type
        /// </summary>
        public string RequestType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the status message returned from the server.
        ///
        /// Ensure that this retains compatibility with the old Powershell versions since lots of customers use this for
        /// their automation.
        /// Compare to <see cref="Azure.Management.Sql.LegacySdk.ImportExportOperations.GetImportExportOperationStatusAsync"/>
        /// </summary>
        public string Status
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the status message returned from the server.
        /// </summary>
        public string StatusMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the private endpoint status(es)
        /// </summary>
        public PrivateEndpointRequestStatus[] PrivateEndpointRequestStatus
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Represents private endpoint connection status
    /// </summary>
    public class PrivateEndpointRequestStatus
    {
        /// <summary>
        /// Gets the resource id for private endpoint connection
        /// </summary>
        public string PrivateLinkServiceId { get; set; }

        /// <summary>
        /// Gets the private endpoint connection name
        /// </summary>
        public string PrivateEndpointConnectionName { get; set; }

        /// <summary>
        /// Gets the status of the private endpoint connection
        /// </summary>
        public string Status { get; set; }
    }
}
