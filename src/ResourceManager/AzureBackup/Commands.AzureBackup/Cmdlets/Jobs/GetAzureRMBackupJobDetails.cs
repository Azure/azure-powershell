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

using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using System;
using System.Management.Automation;
using Mgmt = Microsoft.Azure.Management.BackupServices.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get full details of a job
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmBackupJobDetails", DefaultParameterSetName = "JobsFiltersSet"), OutputType(typeof(AzureRMBackupJobDetails))]
    public class GetAzureRMBackupJobDetils : AzureBackupCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.Vault, ParameterSetName = "IdFiltersSet")]
        [ValidateNotNull]
        public AzureRMBackupVault Vault { get; set; }

        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.JobDetailsFilterJobIdHelpMessage, ParameterSetName = "IdFiltersSet")]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.JobDetailsFilterJobHelpMessage, ParameterSetName = "JobsFiltersSet", ValueFromPipeline = true)]
        [ValidateNotNull]
        public AzureRMBackupJob Job { get; set; }

        public override void ExecuteCmdlet()
        {
            if (Job != null)
            {
                Vault = new AzureRMBackupVault(Job.ResourceGroupName, Job.ResourceName, Job.Location);
            }
            InitializeAzureBackupCmdlet(Vault);

            ExecutionBlock(() =>
            {
                if (Job != null)
                {
                    JobId = Job.InstanceId;
                }

                WriteDebug(String.Format(Resources.JobIdFilter, JobId));

                Mgmt.CSMJobDetailsResponse serviceJobProperties = AzureBackupClient.GetJobDetails(Vault.ResourceGroupName, Vault.Name, JobId);
                AzureRMBackupJobDetails jobDetails = new AzureRMBackupJobDetails(Vault, serviceJobProperties.JobDetailedProperties, serviceJobProperties.Name);

                WriteDebug(Resources.JobResponse);
                WriteObject(jobDetails);
            });
        }
    }
}