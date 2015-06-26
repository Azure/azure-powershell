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

using Microsoft.WindowsAzure.Commands.RemoteApp;
using System;
using System.Management.Automation;
using System.Threading;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    internal class LongRunningTask<T> : Job where T : RdsCmdlet
    {
        private string statusMessage;
        
        private string joblocation;

        private JobStateInfo jobstate;

        private string description;

        private delegate void WaitCallback(Action task);

        private T cmdlet;

        public LongRunningTask(T command, string JobName, string Description)
        {
            Error = new PSDataCollection<ErrorRecord>();
            Debug = new PSDataCollection<DebugRecord>();
            Output = new PSDataCollection<PSObject>();
            Progress = new PSDataCollection<ProgressRecord>();
            Verbose = new PSDataCollection<VerboseRecord>();
            Warning = new PSDataCollection<WarningRecord>();

            statusMessage = null;
            joblocation = null;
            jobstate = null;
            Name = JobName;
            description = Description;
            SetState(JobState.NotStarted, null);
            SetStatus(Commands_RemoteApp.TemplateImageUploadPendingMessage);
            SetLocation("localhost");
            cmdlet = command;
        }

        public override string StatusMessage
        {
            get
            {
                return statusMessage;
            }
        }

        public override bool HasMoreData
        {
            get
            {
                return Output.Count > 0 || Warning.Count > 0 || Error.Count > 0 || Verbose.Count > 0;
            }
        }

        public override string Location
        {
            get
            {
                return joblocation;
            }
        }

        public new JobStateInfo JobStateInfo
        {
            get
            {
                return jobstate;
            }
        }

        public override void StopJob()
        {
            throw new NotImplementedException();
        }

        internal void SetLocation(string location)
        {
            joblocation = location;
        }

        internal void SetStatus(string status)
        {
            statusMessage = status;
        }

        internal void SetState(JobState state, Exception reason)
        {
            SetJobState(state);
            jobstate = new JobStateInfo(state, reason);
        }

        internal void ProcessJob(Action task)
        {
            cmdlet.JobRepository.Add(this);

            if (ThreadPool.QueueUserWorkItem(t => DoProcessLogic((Action)t), task) == false)
            {
                throw new RemoteAppServiceException(Commands_RemoteApp.CreateJobFailedError, ErrorCategory.InvalidOperation);
            }
        }

        protected virtual void DoProcessLogic(Action task)
        {
            JobState state = JobState.Running;
            string title = cmdlet.Host.UI.RawUI.WindowTitle;
            cmdlet.Host.UI.RawUI.WindowTitle = description;
            SetState(state, null);
            RdsCmdlet.theJob = this;

            try
            {
                task.Invoke();
                
                state = Error.Count > 0 ? JobState.Failed : JobState.Completed;

                if (state == JobState.Completed)
                {
                    SetStatus(Commands_RemoteApp.TemplateImageUploadSuccessMessage);
                    cmdlet.WriteVerbose(Commands_RemoteApp.TemplateImageUploadSuccessMessage);
                }

                SetState(state, null);
            }
            catch (Exception e)
            {
                SetState(JobState.Failed, e);
                ErrorRecord er = new ErrorRecord(e, Name, ErrorCategory.InvalidOperation, null);
                cmdlet.WriteError(er);

                SetStatus(Commands_RemoteApp.TemplateImageUploadFailedMessage);
            }

            cmdlet.Host.UI.RawUI.WindowTitle = title;

            RdsCmdlet.theJob = null;
        }
    } 
}