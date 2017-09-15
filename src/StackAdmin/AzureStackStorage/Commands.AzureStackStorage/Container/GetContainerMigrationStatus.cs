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
using System.Linq;
using System.Threading;
using System.Management.Automation;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    /// Gets the status of the specified migration job ID. 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminContainerMigrationStatus)]
    [Alias("Get-ACSContainerMigrationStatus")]
    public sealed class GetContainerMigrationStatus : AdminCmdletDefaultFarm
    {
        /// <summary>
        /// JobId of the Containter Migration Job
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true )]
        public string JobId { get; set; }

        protected override void Execute()
        {
            MigrationResult response = this.Client.Shares.GetMigrationStatus(this.ResourceGroupName, this.FarmName, this.JobId);
            this.WriteVerbose(String.Format(
                                            "migration result = ContainerName = {0}, DestinationShareName = {1}, FailureReason = {2} " +
                                            "\nJobId = {3}, MigrationStatus = {4}, SourceShareName = {5} StorageAccountName = {6}",
                                            response.ContainerName,
                                            response.DestinationShareName,
                                            response.FailureReason,
                                            response.JobId,
                                            response.MigrationStatus,
                                            response.SourceShareName,
                                            response.StorageAccountName));
            this.WriteObject(response, true);
        }
    }
}
