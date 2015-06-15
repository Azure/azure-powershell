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

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get full details of a job
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureBackupJobDetails"), OutputType(typeof(Mgmt.JobProperties))]
    public class GetAzureBackupJobDetils : AzureBackupVaultCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.JobDetailsFilterJobIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string JobID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.JobDetailsFilterJobHelpMessage)]
        [ValidateNotNull]
        public AzureBackupJob Job { get; set; }

        public override void ExecuteCmdlet()
        {
            if (Job != null)
            {
                this.ResourceGroupName = Job.ResourceGroupName;
                this.ResourceName = Job.ResourceName;
            }

            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                //if (Job != null && JobID != null)
                //{
                //    throw new Exception("Please use either JobID filter or Job filter but not both.");
                //}

                if (Job != null)
                {
                    JobID = Job.InstanceId;
                }

                WriteDebug("JobID filter is: " + JobID);

                Mgmt.JobProperties serviceJobProperties = AzureBackupClient.Job.GetAsync(JobID, GetCustomRequestHeaders(), CmdletCancellationToken).Result.Job;
                AzureBackupJobDetails jobDetails = new AzureBackupJobDetails(serviceJobProperties, ResourceGroupName, ResourceName, Location);

                WriteDebug("Retrieved JobDetails from service.");
                WriteObject(jobDetails);
            });
        }
    }
}