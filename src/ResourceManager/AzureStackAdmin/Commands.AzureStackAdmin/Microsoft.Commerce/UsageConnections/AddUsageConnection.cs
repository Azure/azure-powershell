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

namespace Microsoft.AzureStack.Commands
{
    using System;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// Add Usage Connection Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Add, Nouns.UsageConnection)]
    [OutputType(typeof(UsageConnectionModel))]
    public class AddUsageConnection : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateNotNull]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateLength(1, 90)]
        [ValidateNotNull]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the resource manager location.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public string ArmLocation { get; set; }

        /// <summary>
        /// Gets or sets the provider location.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateNotNull]
        public string ProviderLocation { get; set; }

        /// <summary>
        /// Gets or sets the provider namespace.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateNotNull]
        public string ProviderNamespace { get; set; }

        /// <summary>
        /// Gets or sets the usage storage connection string.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateNotNull]
        public string UsageStorageConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the usage reporting queue name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateNotNull]
        public string UsageReportingQueue { get; set; }

        /// <summary>
        /// Gets or sets the reporting table.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateNotNull]
        public string UsageReportingTable { get; set; }

        /// <summary>
        /// Gets or sets the error reporting queue.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateNotNull]
        public string ErrorReportingQueue { get; set; }

        /// <summary>
        /// Gets or sets the error reporting table.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateNotNull]
        public string ErrorReportingTable { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override object ExecuteCore()
        {
            this.ApiVersion = UsageApiVersion;
            this.WriteVerbose(Resources.AddingUsageConnection.FormatArgs(this.Name));
            using (var client = this.GetAzureStackClient())
            {
                var usageConnectionModel = new UsageConnectionModel()
                {
                    Location = this.ArmLocation,
                    Name = this.Name,
                    Properties = new UsageConnection()
                                 {
                                     ProviderLocation = this.ProviderLocation,
                                     ProviderNamespace = this.ProviderNamespace,
                                     UsageStorageConnectionString = this.UsageStorageConnectionString,
                                     UsageReportingTable = this.UsageReportingTable,
                                     UsageReportingQueue = this.UsageReportingQueue,
                                     ErrorReportingTable = this.ErrorReportingTable,
                                     ErrorReportingQueue = this.ErrorReportingQueue
                                 }
                };

                var usageConnectionParameters = new UsageConnectionsCreateOrUpdateParameters() { UsageConnections = usageConnectionModel };
                return client.UsageConnections.CreateOrUpdate(this.ResourceGroup, this.Name, usageConnectionParameters).UsageConnection;
            }
        }
    }
}
