// ----------------------------------------------------------------------------------
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
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.ImportExport
{
    /// <summary>
    /// Represents the result of querying the status of an import or export database operation
    /// </summary>
    [Serializable]
    [DataContract(Name = "StatusInfo",
        Namespace = "http://schemas.datacontract.org/2004/07/Microsoft.SqlServer.Management.Dac.ServiceTypes")]
    public class StatusInfo : IExtensibleDataObject
    {
        /// <summary>
        /// Gets or sets the blob uri
        /// </summary>
        [DataMember]
        public string BlobUri { get; set; }

        /// <summary>
        /// Gets or sets the name of the database
        /// </summary>
        [DataMember]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the error message if any
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets date the database was last modified
        /// </summary>
        [DataMember]
        public DateTime LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets how long the operation has been queued
        /// </summary>
        [DataMember]
        public DateTime QueuedTime { get; set; }

        /// <summary>
        /// Gets or sets the import/export request id
        /// </summary>
        [DataMember]
        public string RequestId { get; set; }

        /// <summary>
        /// Gets or sets the type of the request
        /// </summary>
        [DataMember]
        public string RequestType { get; set; }

        /// <summary>
        /// Gets or sets the name of the server the database resides in
        /// </summary>
        [DataMember]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the status of the import/export operation
        /// </summary>
        [DataMember]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the import/export status info extension data
        /// </summary>
        [Browsable(false)]
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
