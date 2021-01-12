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

using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Gets detailed information about a particular job.
    /// </summary>
    [GenericBreakingChange(" Please use singular alias Get-AzRecoveryServicesBackupJobDetail, as Get-AzRecoveryServicesBackupJobDetails plural alias will be removed in an upcoming breaking change release", "4.0.0")]
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupJobDetail", DefaultParameterSetName = JobFilterSet), OutputType(typeof(JobBase))]
    [Alias("Get-AzRecoveryServicesBackupJobDetails")]
    public class GetAzureRmRecoveryServicesBackupJobDetails : RSBackupVaultCmdletBase
    {
        protected const string IdFilterSet = "IdFilterSet";
        protected const string JobFilterSet = "JobFilterSet";

        /// <summary>
        /// Job whose details are to be fetched.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsgs.Job.JobFilter,
            ParameterSetName = JobFilterSet, Position = 1)]
        [ValidateNotNull]
        public JobBase Job { get; set; }

        /// <summary>
        /// ID of job whose details are to be fetched.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsgs.Job.JobIdFilter,
            ParameterSetName = IdFilterSet, Position = 2)]
        [ValidateNotNullOrEmpty]
        public string JobId { get; set; }

        /// <summary>
        /// Switch param to filter job based on secondary region (Cross Region Restore).
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Common.UseSecondaryReg)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter UseSecondaryRegion { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                if (ParameterSetName == JobFilterSet)
                {
                    JobId = Job.JobId;
                }

                WriteDebug("Fetching job with ID: " + JobId);

                JobResource jobDetails;
                if (UseSecondaryRegion.IsPresent) {
                    CrrJobRequest jobRequest = new CrrJobRequest();
                    jobRequest.JobName = JobId;
                    jobRequest.ResourceId = VaultId;

                    ARSVault vault = ServiceClientAdapter.GetVault(resourceGroupName, vaultName);
                    string secondaryRegion = BackupUtils.regionMap[vault.Location];
                    
                    jobDetails = ServiceClientAdapter.GetCRRJobDetails(secondaryRegion, jobRequest);
                }
                else
                {
                    jobDetails = ServiceClientAdapter.GetJob(
                    JobId,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName);
                }
                
                WriteObject(JobConversions.GetPSJob(jobDetails));
            });
        }
    }
}
