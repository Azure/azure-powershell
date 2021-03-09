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
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Waits for the given job to finish its operation and returns the corresponding job object.
    /// </summary>
    [Cmdlet("Wait", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupJob"), OutputType(typeof(JobBase))]
    public class WaitAzureRmRecoveryServicesBackupJob : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// Job or List of jobs until end of which the cmdlet should wait.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsgs.Job.WaitJobOrListFilter,
            ValueFromPipeline = true, Position = 1)]
        [ValidateNotNull]
        public object Job { get; set; }

        /// <summary>
        /// Maximum time to wait before aborting wait in seconds.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Job.WaitJobTimeoutFilter, Position = 2)]
        public long? Timeout { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                List<string> jobsToWaitOn = new List<string>();
                List<JobBase> finalJobs = new List<JobBase>();

                object castedObj;
                if (GetCastedObjFromPSObj<JobBase>(Job, out castedObj))
                {
                    JobBase justJob = castedObj as JobBase;
                    jobsToWaitOn.Add(justJob.JobId);
                }
                else if (GetCastedObjFromPSObj<List<JobBase>>(Job, out castedObj))
                {
                    List<JobBase> jobsList = castedObj as List<JobBase>;
                    foreach (var job in jobsList)
                    {
                        jobsToWaitOn.Add(job.JobId);
                    }
                }
                else if (Job.GetType() == typeof(object[]))
                {
                    object[] castedJobsList = Job as object[];
                    object castedJob;
                    foreach (var job in castedJobsList)
                    {
                        if (GetCastedObjFromPSObj<JobBase>(job, out castedJob))
                        {
                            jobsToWaitOn.Add((castedJob as JobBase).JobId);
                        }
                        else
                        {
                            throw new Exception(string.Format(Resources.JobWaitJobInvalidInput,
                                Job.GetType().FullName));
                        }
                    }
                }
                else
                {
                    // not a valid object. throw exception.
                    throw new Exception(string.Format(Resources.JobWaitJobInvalidInput,
                        Job.GetType().FullName));
                }

                // now wait until timeout happens or all jobs complete execution
                DateTime waitBeginning = DateTime.UtcNow;

                while (true)
                {
                    if (Timeout.HasValue)
                    {
                        if (DateTime.UtcNow.Subtract(waitBeginning) >=
                            TimeSpan.FromSeconds(Timeout.Value))
                        {
                            break;
                        }
                    }

                    bool hasUnfinishedJob = false;
                    finalJobs.Clear();
                    for (int i = 0; i < jobsToWaitOn.Count; i++)
                    {
                        string jobId = jobsToWaitOn[i];
                        var updatedJob = JobConversions.GetPSJob(
                            ServiceClientAdapter.GetJob(
                                jobId,
                                vaultName: vaultName,
                                resourceGroupName: resourceGroupName));

                        if (IsJobInProgress(updatedJob))
                        {
                            hasUnfinishedJob = true;
                        }
                        else
                        {
                            // removing finished job from list
                            jobsToWaitOn.RemoveAt(i);
                            i--;
                        }

                        finalJobs.Add(updatedJob);
                    }

                    if (!hasUnfinishedJob)
                    {
                        break;
                    }

                    // sleep for 30 seconds before checking again                    
                    string testMode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");

                    if (!TestMockSupport.RunningMocked)
                    {
                        TestMockSupport.Delay(30 * 1000);                        
                    }
                    if (String.Compare(testMode, "Record", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        Thread.Sleep(30000);
                    }

                }

                WriteObject(finalJobs, enumerateCollection: true);
            });
        }

        /// <summary>
        /// Gets casted object of type T from the input object obj if possible.
        /// </summary>
        /// <typeparam name="T">Type into which the object has to be casted.</typeparam>
        /// <param name="obj">Object to be casted.</param>
        /// <param name="castedJob">Object after casting.</param>
        /// <returns></returns>
        private bool GetCastedObjFromPSObj<T>(object obj, out object castedJob) where T : class
        {
            if (obj is PSObject)
            {
                obj = ((PSObject)obj).ImmediateBaseObject;
            }

            castedJob = obj as T;

            if (castedJob == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the job is already in progress.
        /// TODO: Move the following function to a common helper file later when
        ///       more functions of this type are required.
        /// </summary>
        /// <param name="job">Job to check if it is in progress.</param>
        /// <returns></returns>
        private bool IsJobInProgress(JobBase job)
        {
            if (job.Status.CompareTo("InProgress") == 0 ||
                job.Status.CompareTo("Cancelling") == 0)
            {
                return true;
            }
            return false;
        }
    }
}
