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
using System.Collections;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Threading;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class AzureRmLongRunningCmdlet : AzureRMCmdlet
    {
        [Parameter(Mandatory=false, HelpMessage ="Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set;}

        protected override void ProcessRecord()
        {
            if (AsJob.IsPresent)
            {

                var job = new Common.AzureRmLongRunningCmdlet.AzureRmJob(MyInvocation.MyCommand.Name, this.JobName);
                JobRepository.Add(job);
                ThreadPool.QueueUserWorkItem(RunJob, job);
                WriteObject(job);
            }
            else
            {
                base.ProcessRecord();
            }
        }

        protected virtual AzureRmLongRunningCmdlet CopyCmdlet()
        {
            var returnType = this.GetType();
            var returnValue = Activator.CreateInstance(this.GetType());
            foreach (var property in returnType.GetProperties())
            {
                if (property.CanWrite && property.CanRead)
                {
                    property.SetValue(returnValue, property.GetValue(this));
                }
            }

            return returnValue as AzureRmLongRunningCmdlet;
        }

        /// <summary>
        /// Return the name of the PSJob, when the AsJob parameter is specified.
        /// </summary>
        public virtual string JobName { get { return string.Format("Long running operation for '{0}'", MyInvocation.MyCommand); } }

        /// <summary>
        /// Run a cmdlet execuition as a Job - this is intended to run in a background thread
        /// </summary>
        /// <param name="state">The Job record that will track the progress of this job </param>
        public void RunJob(object state)
        {
            AzureRmJob job = state as AzureRmJob;
            if (job != null)
            {
                try
                {
                    job.Start();
                    var cmdletCopy = CopyCmdlet();
                    ReplaceCommandRuntime(cmdletCopy, job);
                    cmdletCopy.ExecuteCmdlet();
                    job.Complete();
                }
                catch (Exception)
                {
                    job.Fail();
                }
            }
        }

        static void ReplaceCommandRuntime(AzureRmLongRunningCmdlet cmdlet, AzureRmJob job)
        {
            cmdlet.CommandRuntime = new JobRuntime(cmdlet.CommandRuntime, job);
        }

        /// <summary>
        /// Internal class implementing the lightweight job
        /// </summary>
        class AzureRmJob : Job
        {
            public AzureRmJob(string command, string name):base(command, name)
            {
                this.PSJobTypeName = this.GetType().Name;
            }

            string _status = "Running";
            public override bool HasMoreData
            {
                get { return Output.Any() || Progress.Any() || Error.Any() || Warning.Any() || Verbose.Any() || Debug.Any();}
            }

            public override string Location
            {
                get
                {
                    return "localhost";
                }
            }

            public override string StatusMessage
            {
                get
                {
                    return _status;
                }
            }

            public override void StopJob()
            {
                SetJobState(JobState.Stopped);

            }

            public void Start()
            {
                _status = "Running";
                SetJobState(JobState.Running);
            }

            public void Fail()
            {
                _status = "Failed";
                SetJobState(JobState.Failed);
            }

            public void Complete()
            {
                _status = "Completed";
                SetJobState(JobState.Completed);
            }

            public void Cancel()
            {
                _status = "Stopped";
                SetJobState(JobState.Stopped);
            }
        }

        /// <summary>
        /// CommandRuntime replacement linking cmdlet execution with a job
        /// </summary>
        class JobRuntime : ICommandRuntime
        {
            public JobRuntime(ICommandRuntime other, Job job)
            {
                _other = other;
                _job = job;
            }

            ICommandRuntime _other;
            Job _job;
            public PSTransactionContext CurrentPSTransaction
            {
                get
                {
                    return _other.CurrentPSTransaction;
                }
            }

            public PSHost Host
            {
                get
                {
                    return _other.Host;
                }
            }

            public bool ShouldContinue(string query, string caption)
            {
                return _other.ShouldContinue(query, caption);
            }

            public bool ShouldContinue(string query, string caption, ref bool yesToAll, ref bool noToAll)
            {
                return _other.ShouldContinue(query, caption, ref yesToAll, ref noToAll);
            }

            public bool ShouldProcess(string target)
            {
                return _other.ShouldProcess(target);
            }

            public bool ShouldProcess(string target, string action)
            {
                return _other.ShouldProcess(target, action);
            }

            public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption)
            {
                return _other.ShouldProcess(verboseDescription, verboseWarning, caption);
            }

            public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption, out ShouldProcessReason shouldProcessReason)
            {
                return _other.ShouldProcess(verboseDescription, verboseWarning, caption, out shouldProcessReason);
            }

            public void ThrowTerminatingError(ErrorRecord errorRecord)
            {
                _job.Error.Add(errorRecord);
            }

            public bool TransactionAvailable()
            {
                return _other.TransactionAvailable();
            }

            public void WriteCommandDetail(string text)
            {
                _job.Verbose.Add(new VerboseRecord(text));
            }

            public void WriteDebug(string text)
            {
                _job.Debug.Add(new DebugRecord(text));
            }

            public void WriteError(ErrorRecord errorRecord)
            {
                _job.Error.Add(errorRecord);
            }

            public void WriteObject(object sendToPipeline)
            {
                _job.Output.Add(new PSObject(sendToPipeline));
            }

            public void WriteObject(object sendToPipeline, bool enumerateCollection)
            {
                IEnumerable enumerable = sendToPipeline as IEnumerable;
                if (enumerateCollection && enumerable != null)
                {
                    foreach (var item in enumerable)
                    {
                        WriteObject(item);
                    }
                }
                else
                {
                    WriteObject(sendToPipeline);
                }
            }

            public void WriteProgress(ProgressRecord progressRecord)
            {
                _job.Progress.Add(progressRecord);
            }

            public void WriteProgress(long sourceId, ProgressRecord progressRecord)
            {
                WriteProgress(progressRecord);
            }

            public void WriteVerbose(string text)
            {
                _job.Verbose.Add(new VerboseRecord(text));
            }

            public void WriteWarning(string text)
            {
                _job.Warning.Add(new WarningRecord(text));
            }
        }
    }
}
