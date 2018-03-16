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

        public PSCmdletAdapter(AzurePSCmdlet cmdlet, SessionState state)
        {
            this.CommandRuntime = cmdlet.CommandRuntime;
            _sessionState = state;
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

        struct CmdletOutput
        {
            public object Output { get; set; }
            public bool Enumerate { get; set; }
        }

        SessionState _sessionState;
        ConcurrentQueue<CmdletOutput> _output = new ConcurrentQueue<CmdletOutput>();

        ConcurrentQueue<string> _debug = new ConcurrentQueue<string>();

        ConcurrentQueue<string> _warning = new ConcurrentQueue<string>();

        ConcurrentQueue<string> _verbose = new ConcurrentQueue<string>();

        ConcurrentQueue<ErrorRecord> _error = new ConcurrentQueue<ErrorRecord>();

        ConcurrentQueue<ShouldProcessPrompt> _process = new ConcurrentQueue<ShouldProcessPrompt>();

        ConcurrentQueue<ShouldContinuePrompt> _continue = new ConcurrentQueue<ShouldContinuePrompt>();

        ConcurrentQueue<ProgressRecord> _progress = new ConcurrentQueue<ProgressRecord>();

        ConcurrentDictionary<string, double> _activity = new ConcurrentDictionary<string, double>();

        object _lock = new object();

        ConcurrentDictionary<ITaskProgress, double> _progressTasks = new ConcurrentDictionary<ITaskProgress, double>();

        //int _hasMessages = 0;

        protected int Retries { get; set; }

        public TimeSpan RetryInterval { get; set; }

        public SessionState SessionState { get { return _sessionState; } }

        public Task<bool> ShouldChangeAsync(string target, string action)
        {
            var process = new ShouldProcessPrompt { Target = target, Message = action, Completer = new TaskCompletionSource<bool>() };
            _process.Enqueue(process);
            //_hasMessages = 1;
            return process.Completer.Task;
        }

        public Task<bool> ShouldContinueChangeAsync(string query, string caption)
        {
            var process = new ShouldContinuePrompt { Query = query, Caption = caption, Completer = new TaskCompletionSource<bool>() };
            _continue.Enqueue(process);
            //_hasMessages = 1;
            return process.Completer.Task;
        }

        public void WriteExceptionAsync(Exception exception)
        {
            var error = new ErrorRecord(exception, "ExecutionException", ErrorCategory.InvalidOperation, exception.TargetSite);
            _error.Enqueue(error);
            //_hasMessages = 1;
        }

        public void WriteVerboseAsync(string verboseMessage)
        {
            _verbose.Enqueue(verboseMessage);
            //_hasMessages = 1;
        }

        public void WriteDebugAsync(string debugMessage)
        {
            _debug.Enqueue(debugMessage);
            //_hasMessages = 1;
        }

        public void WriteWarningAsync(string warningMessage)
        {
            _warning.Enqueue(warningMessage);
            //_hasMessages = 1;
        }

        void WriteProgressAsync(ProgressRecord progress)
        {
            _progress.Enqueue(progress);
            //_hasMessages = 1;
        }

        public void ReportTaskProgress(ITaskProgress taskProgress)
        {
            var progress = taskProgress.GetProgress();
            var config = taskProgress.Config;
            string key = config.Name + " " + config.Strategy.Type.Provider;
            bool reportProgress = true;
            if (_progressTasks.ContainsKey(taskProgress))
            {
                progress += _progressTasks[taskProgress];
                reportProgress =  progress > _progressTasks[taskProgress];
            }

            _progressTasks[taskProgress] = progress;
            if (reportProgress && progress <= 1)
            {
                var percent = (int)(progress * 100.0);
                var r = new[] { "|", "/", "-", "\\" };
                var x = r[DateTime.Now.Second % 4];
                WriteProgressAsync(
                    new ProgressRecord(
                        0,
                        "Creating Azure resources",
                        percent + "% " + x)
                    {
                        CurrentOperation = !taskProgress.IsDone
                            ? $"Creating resource '{taskProgress.Config.Name}' of type  '{taskProgress.Config?.Strategy?.Type?.Namespace}/{taskProgress.Config?.Strategy?.Type?.Provider}'"
                            : null,
                        PercentComplete = percent,
                    });
            }
        }

        public void Complete()
        {
        }

        void PollForResults(bool drainQueues = false)
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

            CmdletOutput output;
            while (_output.TryDequeue(out output))
            {
                CommandRuntime.WriteObject(output.Output, output.Enumerate);
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

            foreach(var progressItem in _progressTasks.Keys)
            {
                ReportTaskProgress(progressItem);
            }

        }

        public void WaitForCompletion(Func<ICmdletAdapter, Task> taskFactory)
        {
            var task = taskFactory(this);
            while (!task.IsCompleted)
            {
                PollForResults();
                Thread.Yield();
            }

            PollForResults(true);
        }

        public Task<bool> ShouldCreate<TModel>(ResourceConfig<TModel> config, TModel model) where TModel : class
        {
            return ShouldChangeAsync(config.Name, $"Create {config.Strategy.Type}");
        }

        public void WriteObjectAsync(object output)
        {
            WriteObjectAsync(output, false);
        }

        public void WriteObjectAsync(object output, bool enumerateCollection)
        {
            _output.Enqueue(new CmdletOutput { Output = output, Enumerate = enumerateCollection });
            //_hasMessages = 1;

        }

        protected ICommandRuntime CommandRuntime { get; set; }
    }
}
