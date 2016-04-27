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
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    [Cmdlet("Wait", "AzureRmRecoveryServicesBackupJob"), OutputType(typeof(JobBase), typeof(IList<JobBase>))]
    public class WaitAzureRmRecoveryServicesBackupJob : RecoveryServicesBackupCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsgs.Job.WaitJobOrListFilter, 
            ValueFromPipeline = true, Position = 1)]
        [ValidateNotNull]
        public object Job { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Job.WaitJobTimeoutFilter, Position = 2)]
        public long? Timeout { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

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
                else if (Job.GetType() == typeof(System.Object[]))
                {
                    System.Object[] castedJobsList = Job as System.Object[];
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
                            ServiceClientAdapter.GetJob(jobId)
                            );

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
                    TestMockSupport.Delay(30 * 1000);
                }

                WriteObject(finalJobs, enumerateCollection: true);
            });
        }

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

        // Move the following function to a common helper file later when
        // more functions of this type are required.
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
