﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    [Cmdlet("Wait", "AzureRmBackupJob"), OutputType(typeof(List<AzureRmRecoveryServicesJobBase>), typeof(AzureRmRecoveryServicesJobBase))]
    public class WaitAzureRmRecoveryServicesJob : RecoveryServicesBackupCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsg.Job.WaitJobOrListFilter)]
        [ValidateNotNull]
        public object Job { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Job.WaitJobTimeoutFilter)]
        public long? Timeout { get; set; }

        public override void ExecuteCmdlet()
        {
            ARSVault Vault = null;
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                List<string> jobsToWaitOn = new List<string>();
                List<AzureRmRecoveryServicesJobBase> finalJobs = new List<AzureRmRecoveryServicesJobBase>();

                // TODO: Validate the following code
                object castedObj;
                if (GetCastedObjFromPSObj(Job, typeof(AzureRmRecoveryServicesJobBase), out castedObj))
                {
                    AzureRmRecoveryServicesJobBase justJob = castedObj as AzureRmRecoveryServicesJobBase;
                    jobsToWaitOn.Add(justJob.InstanceId);
                }
                else if (GetCastedObjFromPSObj(Job, typeof(List<AzureRmRecoveryServicesJobBase>), out castedObj))
                {
                    List<AzureRmRecoveryServicesJobBase> jobsList = castedObj as List<AzureRmRecoveryServicesJobBase>;
                    foreach (var job in jobsList)
                    {
                        jobsToWaitOn.Add(job.InstanceId);
                    }
                }
                else
                {
                    // not a valid object. throw exception.
                    throw new Exception(CmdletWarningAndErrorMessages.Job.WaitJobInvalidInput + Job.GetType().FullName);
                }

                // now wait until timeout happens or all jobs complete execution
                DateTime waitBeginning = DateTime.UtcNow;

                while (true)
                {
                    if (Timeout.HasValue)
                    {
                        if (DateTime.UtcNow.Subtract(waitBeginning) >= TimeSpan.FromSeconds(Timeout.Value))
                        {
                            break;
                        }
                    }

                    bool hasUnfinishedJob = false;
                    finalJobs.Clear();
                    foreach (string jobId in jobsToWaitOn)
                    {
                        var updatedJob = JobConversions.GetPSJob(
                            HydraAdapter.GetJob(Vault.ResouceGroupName, Vault.Name, jobId)
                            );

                        if (IsJobInProgress(updatedJob))
                        {
                            hasUnfinishedJob = true;
                        }

                        finalJobs.Add(updatedJob);
                    }

                    if (!hasUnfinishedJob)
                    {
                        break;
                    }
                }

                if (finalJobs.Count == 1)
                {
                    WriteObject(finalJobs[0]);
                }
                else
                {
                    WriteObject(finalJobs);
                }
            });
        }

        private bool GetCastedObjFromPSObj(object obj, Type objType, out object castedJob)
        {
            if (obj is PSObject)
            {
                obj = ((PSObject)obj).ImmediateBaseObject;
            }
            // try to cast the immediate object to base object
            try
            {
                castedJob = Convert.ChangeType(obj, objType);
                return true;
            }
            catch (InvalidCastException)
            {
                castedJob = null;
                return false;
            }
        }

        // Move the following function to a common helper file later when
        // more functions of this type are required.
        private bool IsJobInProgress(AzureRmRecoveryServicesJobBase job)
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
