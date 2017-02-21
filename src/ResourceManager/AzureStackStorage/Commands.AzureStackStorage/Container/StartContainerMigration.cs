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
    using System.Collections;

    /// <summary>
    /// SYNTAX
    /// Start-ACSContainerMigration  [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///                  [-FarmName] {string} [-ShareName] {string} [-Container] {container} [-DestinationShareName] {string} [{CommonParameters}] 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, Nouns.AdminContainerMigration)]
    public sealed class StartContainerMigration : AdminCmdlet
    {
        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3)]
        [ValidateNotNull]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNull]
        public string FarmName { get; set; }

        /// <summary>
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 5)]
        [ValidateNotNullOrEmpty]
        public Container ContainerToMigrate { get; set; }

        /// <summary>
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 6)]
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
                                            "Input Parameters = ContainerName = {0}, DestinationShareUncPath = {1}, StorageAccountName = {2}",
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

            var response = this.Client.Shares.MigrateContainer(this.ResourceGroupName, this.FarmName, sourceShare, migrationParameters);

            //This should display the jobid from http header
            // use following way to return a hash table. if u want to include any other strings.
            // this.WriteObject(new Hashtable() { { "JobId", jobId }}, true);
            string jobId;
            ExtractShareAndOperationFromLocation(response.Location, out jobId);
            this.WriteObject(jobId, true);
        }

        private void ExtractShareAndOperationFromLocation(string operationUri, out string operationId)
        {
            // Un Escaping %7C to |
            operationUri = Uri.UnescapeDataString(operationUri);

            int indexOfShareNameStart = operationUri.IndexOf('|');
            int indexOfShareNameEnd = operationUri.IndexOf('/', indexOfShareNameStart);
            int indexOfOperationResultStart = operationUri.IndexOf('/', indexOfShareNameEnd + 1);
            int indexOfParameterStart = operationUri.IndexOf('?');

            // shareName = operationUri.Substring(indexOfShareNameStart, indexOfShareNameEnd - indexOfShareNameStart);
            operationId = operationUri.Substring(indexOfOperationResultStart + 1, indexOfParameterStart - indexOfOperationResultStart - 1);
        }

    }
}
 