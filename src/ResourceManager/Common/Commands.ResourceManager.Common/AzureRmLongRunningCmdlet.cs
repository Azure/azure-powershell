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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class AzureRmLongRunningCmdlet : AzureRMCmdlet
    {
        [Parameter(Mandatory=false, HelpMessage ="Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set;}

        AzureRmJob _job;

        protected override void ProcessRecord()
        {
            if (AsJob.IsPresent)
            {
                _job = new Common.AzureRmLongRunningCmdlet.AzureRmJob("LongRunningCmdlet", "AzureRmLongRunningCmdlet");
                JobRepository.Add(_job);
                
                WriteObject(_job);
                ThreadPool.QueueUserWorkItem(RunJob);
            }
            else
            {
                base.ProcessRecord();
            }
        }

        public void RunJob(object state)
        {
            try
            {
                ReplaceCommandRuntime();
                _job.Start();
                Thread.Sleep(TimeSpan.FromSeconds(30));
                ExecuteCmdlet();
                _job.Complete();
            }
            catch (Exception)
            {
                _job.Fail();
            }
        }

        void ReplaceCommandRuntime()
        {
            this.CommandRuntime = new JobRuntime(this.CommandRuntime, _job);
        }

        class AzureRmJob : Job
        {
            public AzureRmJob(string command, string name):base(command, name)
            {
                this.PSJobTypeName = "AzureRmJob";
            }

            bool _processingCompleted = false;
            string _status = "Running";
            public override bool HasMoreData
            {
                get { return !_processingCompleted || Output.Any();}
            }

            public override string Location
            {
                get
                {
                    return "Process";
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
                _processingCompleted = true;
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
                _processingCompleted = true;
            }

            public void Complete()
            {
                _status = "Completed";
                SetJobState(JobState.Completed);
                _processingCompleted = true;
            }

            public void Cancel()
            {
                _status = "Stopped";
                SetJobState(JobState.Stopped);
                _processingCompleted = true;
            }
        }

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
