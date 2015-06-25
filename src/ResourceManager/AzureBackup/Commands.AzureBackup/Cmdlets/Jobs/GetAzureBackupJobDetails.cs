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
using System.Management.Automation;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using Mgmt = Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Commands.AzureBackup.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get full details of a job
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureBackupJobDetails", DefaultParameterSetName = "IdFiltersSet"), OutputType(typeof(Mgmt.JobProperties))]
    public class GetAzureBackupJobDetils : AzureBackupCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.Vault, ParameterSetName = "IdFiltersSet")]
        [ValidateNotNull]
        public AzurePSBackupVault Vault { get; set; }

        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.JobDetailsFilterJobIdHelpMessage, ParameterSetName = "IdFiltersSet")]
        [ValidateNotNullOrEmpty]
        public string JobID { get; set; }

        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.JobDetailsFilterJobHelpMessage, ParameterSetName = "JobsFiltersSet")]
        [ValidateNotNull]
        public AzureBackupJob Job { get; set; }

        public override void ExecuteCmdlet()
        {
            if (Job != null)
            {
                Vault = new AzurePSBackupVault(Job.ResourceGroupName, Job.ResourceName, Job.Location);
            }
            InitializeAzureBackupCmdlet(Vault);

            ExecutionBlock(() =>
            {
                if (Job != null)
                {
                    JobID = Job.InstanceId;
                }

                WriteDebug("JobID filter is: " + JobID);

                Mgmt.JobProperties serviceJobProperties = AzureBackupClient.GetJobDetails(JobID).Job;
                AzureBackupJobDetails jobDetails = new AzureBackupJobDetails(Vault, serviceJobProperties);

                WriteDebug("Retrieved JobDetails from service.");
                WriteObject(jobDetails);
            });
        }
    }
}