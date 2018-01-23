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
    /// Returns the job ID of the operation to migrate specified containers to a specified destination share.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, Nouns.AdminContainerMigration)]
    [Alias("Start-ACSContainerMigration")]
    public sealed class StartContainerMigration : AdminCmdletDefaultFarm
    {
        /// <summary>
        /// Container to migrate
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Container ContainerToMigrate { get; set; }

        /// <summary>
        /// Destination share where the container needs to be migrated
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string DestinationShareUncPath { get; set;}

        protected override void Execute()
        {
            MigrationParameters migrationParameters = new MigrationParameters
                                                      {
                                                          ContainerName = this.ContainerToMigrate.ContainerName,
                                                          DestinationShareUncPath = this.DestinationShareUncPath,
                                                          StorageAccountName = this.ContainerToMigrate.StorageAccountName
                                                      };
            this.WriteVerbose(String.Format(
                                            "Input Parameters : ContainerName = {0}, DestinationShareUncPath = {1}, StorageAccountName = {2}",
                                            this.ContainerToMigrate.ContainerName,
                                            this.DestinationShareUncPath,
                                            this.ContainerToMigrate.StorageAccountName));
            this.WriteVerbose(String.Format("Container Source share name = {0}", this.ContainerToMigrate.ShareName));
            // Workaround, replace \\server\share to ||server|share
            string sourceShare = this.ContainerToMigrate.ShareName;
            if (sourceShare.Contains('\\'))
            {
                sourceShare = sourceShare.Replace('\\', '|');
                this.WriteVerbose(String.Format("Container Source share name After Replacing = {0}", sourceShare));
            }

            MigrateContainerResponse response = this.Client.Shares.MigrateContainer(this.ResourceGroupName, this.FarmName, sourceShare, migrationParameters);

            //This should display the jobid from http header
            // use following way to return a hash table. if u want to include any other strings.
            // this.WriteObject(new Hashtable() { { "JobId", jobId }}, true);
            string jobId;
            ExtractOperationIdFromLocationUri(response.Location, out jobId);
            this.WriteObject(jobId, true);
        }
    }
}
 