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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Strategies;

namespace Microsoft.Azure.Commands.WebApps.Strategies
{
    public class PSCmdletAdapter : ICmdletAdapter
    {

        public PSCmdletAdapter(AzurePSCmdlet cmdlet)
        {
            this.CommandRuntime = cmdlet.CommandRuntime;
        }
        struct ShouldProcessPrompt
        {
            public string Target { get; set; }
            public string Message { get; set; }
            public TaskCompletionSource<bool> Completer { get; set; }
        }

        struct ShouldContinuePrompt
        {
            public string Query { get; set; }
            public string Caption { get; set; }
            public TaskCompletionSource<bool> Completer { get; set; }
        }

        class PSCmdletActivity : IActivity
        {
            static int ActivityId = 0;
            PSCmdletAdapter _adapter;
            IActivity _parent;

            public PSCmdletActivity(string description, string initialStatus, PSCmdletAdapter adapter)
            {
                _adapter = adapter;
                Description = description;
                Id =GetNextActivityId();
                StatusDescription = initialStatus;
            }

            public static int GetNextActivityId()
            {
                return Interlocked.Increment(ref ActivityId);
            }

            public string Description
            {
                get; private set;
            }

            public int Id
            {
                get; private set;
            }

            public string StatusDescription
            {
                get; private set;
            }

            ProgressRecord Progress
            {
                get
                {
                    var progress = new ProgressRecord(Id, Description, StatusDescription);
                    if (_parent != null)
                    {
                        progress.ParentActivityId = _parent.Id;
                        progress.PercentComplete = 0;
                        progress.SecondsRemaining = 0;
                        progress.RecordType = ProgressRecordType.Processing;
                    }

                    return progress;
                }
            }

            public void CompleteAsync()
            {
                var progress = Progress;
                progress.PercentComplete = 100;
                progress.RecordType = ProgressRecordType.Completed;
                _adapter.WriteProgressAsync(progress);
            }

            public void ReportProgress(ITaskProgress progress)
            {
                if (progress.IsDone)
                {
                    CompleteAsync();
                }
                else
                {
                    ReportProgress(Progress.StatusDescription, Progress.SecondsRemaining, (int)(progress.GetProgress() * 100));
                }
            }

            public void ReportProgress(string statusDesscription, int secondsRemaining, int percentComplete)
            {
                var progress = Progress;
                progress.StatusDescription = statusDesscription;
                progress.SecondsRemaining = secondsRemaining;
                progress.PercentComplete = percentComplete;
                _adapter.WriteProgressAsync(progress);
            }

            public IActivity StartChildActivity()
            {
                var child = new PSCmdletActivity(this.Description, this.StatusDescription, _adapter);
                child._parent = this;
                return child;
            }

        }


        ConcurrentQueue<string> _debug = new ConcurrentQueue<string>();

        ConcurrentQueue<string> _warning = new ConcurrentQueue<string>();

        ConcurrentQueue<string> _verbose = new ConcurrentQueue<string>();

        ConcurrentQueue<ErrorRecord> _error = new ConcurrentQueue<ErrorRecord>();

        ConcurrentQueue<ShouldProcessPrompt> _process = new ConcurrentQueue<ShouldProcessPrompt>();

        ConcurrentQueue<ShouldContinuePrompt> _continue = new ConcurrentQueue<ShouldContinuePrompt>();

        ConcurrentQueue<ProgressRecord> _progress = new ConcurrentQueue<ProgressRecord>();

        object _lock = new object();

        int _complete = 0, _hasMessages = 0, iterations = 0, activityId = 0;

        protected int Retries { get; set; }

        public TimeSpan RetryInterval { get; set; }

        public Task<bool> ShouldChangeAsync(string target, string action)
        {
            var process = new ShouldProcessPrompt { Target = target, Message = action, Completer = new TaskCompletionSource<bool>() };
            return process.Completer.Task;
        }

        public Task<bool> SHouldContinueChangeAsync(string query, string caption)
        {
            var process = new ShouldContinuePrompt { Query = query, Caption = caption, Completer = new TaskCompletionSource<bool>() };
            return process.Completer.Task;
        }

        public void WriteExceptionAsync(Exception exception)
        {
            var error = new ErrorRecord(exception, "ExecutionException", ErrorCategory.InvalidOperation, exception.TargetSite);
            _error.Enqueue(error);
        }

        public void WriteVerboseAsync(string verboseMessage)
        {
            _verbose.Enqueue(verboseMessage);
            _hasMessages = 1;
        }

        public void WriteDebugAsync(string debugMessage)
        {
            _debug.Enqueue(debugMessage);
            _hasMessages = 1;
        }

        public void WriteWarningAsync(string warningMessage)
        {
            _warning.Enqueue(warningMessage);
            _hasMessages = 1;
        }

        void WriteProgressAsync(ProgressRecord progress)
        {
            _progress.Enqueue(progress);
            _hasMessages = 1;
        }

        public IActivity StartActivity(string description, string initialStatus, int seconds)
        {
            var activity = new PSCmdletActivity(description: description, initialStatus: initialStatus, adapter: this);
            activity.ReportProgress(initialStatus, seconds, 0);
            _hasMessages = 1;
            return activity;
        }

        public void Complete()
        {
            _complete = 1;
        }

        public void WaitForCompletion()
        {
            while (Interlocked.Exchange(ref _complete, 0) != 1 && Interlocked.Increment(ref iterations) <= Retries)
            {
                if (Interlocked.Exchange(ref _hasMessages, 0) == 1)
                {
                    ShouldProcessPrompt process;
                    while (_process.TryDequeue(out process))
                    {
                        process.Completer.TrySetResult(CommandRuntime.ShouldProcess(process.Target, process.Message));
                    }

                    ShouldContinuePrompt shouldContinue;
                    while (_continue.TryDequeue(out shouldContinue))
                    {
                        shouldContinue.Completer.TrySetResult(CommandRuntime.ShouldContinue(shouldContinue.Query, shouldContinue.Caption));
                    }

                    ErrorRecord exception;
                    while (_error.TryDequeue(out exception))
                    {
                        CommandRuntime.WriteError(exception);
                    }

                    string logMessage;
                    while (_warning.TryDequeue(out logMessage))
                    {
                        CommandRuntime.WriteWarning(logMessage);
                    }

                    while (_verbose.TryDequeue(out logMessage))
                    {
                        CommandRuntime.WriteVerbose(logMessage);
                    }

                    while (_debug.TryDequeue(out logMessage))
                    {
                        CommandRuntime.WriteDebug(logMessage);
                    }

                    ProgressRecord progress;
                    while (_progress.TryDequeue(out progress))
                    {
                        CommandRuntime.WriteProgress(progress);
                    }

                }

                Thread.Sleep(RetryInterval);
            }
        }

        protected ICommandRuntime CommandRuntime { get; set; }
    }
}
