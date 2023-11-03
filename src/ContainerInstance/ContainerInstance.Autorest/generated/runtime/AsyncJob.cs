/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell
{
    using System.Management.Automation;
    using System.Management.Automation.Host;
    using System.Threading;

    using System.Threading.Tasks;

    public class LongRunningJobCancelledException : System.Exception
    {
        public LongRunningJobCancelledException(string message) : base(message)
        {

        }
    }

    public class AsyncJob : Job, System.Management.Automation.ICommandRuntime2
    {
        const int MaxRecords = 1000;

        private string _statusMessage = string.Empty;

        public override string StatusMessage => _statusMessage;

        public override bool HasMoreData => Output.Count > 0 || Progress.Count > 0 || Error.Count > 0 || Warning.Count > 0 || Verbose.Count > 0 || Debug.Count > 0;

        public override string Location => "localhost";

        public PSHost Host => originalCommandRuntime.Host;

        public PSTransactionContext CurrentPSTransaction => originalCommandRuntime.CurrentPSTransaction;

        public override void StopJob()
        {
            Cancel();
        }

        private readonly PSCmdlet cmdlet;
        private readonly ICommandRuntime2 originalCommandRuntime;
        private readonly System.Threading.Thread originalThread;

        private void CheckForInteractive()
        {
            // This is an interactive call -- We should never allow interactivity in AsnycJob cmdlets.
            throw new System.Exception("Cmdlets in AsyncJob; interactive calls are not permitted.");
        }
        private bool IsJobDone => CancellationToken.IsCancellationRequested || this.JobStateInfo.State == JobState.Failed || this.JobStateInfo.State == JobState.Stopped || this.JobStateInfo.State == JobState.Stopping || this.JobStateInfo.State == JobState.Completed;

        private readonly System.Action Cancel;
        private readonly CancellationToken CancellationToken;

        internal AsyncJob(PSCmdlet cmdlet, string line, string name, CancellationToken cancellationToken, System.Action cancelMethod) : base(line, name)
        {
            SetJobState(JobState.NotStarted);
            // know how to cancel/check for cancelation
            this.CancellationToken = cancellationToken;
            this.Cancel = cancelMethod;

            // we might need these.
            this.originalCommandRuntime = cmdlet.CommandRuntime as ICommandRuntime2;
            this.originalThread = System.Threading.Thread.CurrentThread;

            // the instance of the cmdlet we're going to run
            this.cmdlet = cmdlet;

            // set the command runtime to the AsyncJob
            cmdlet.CommandRuntime = this;
        }

        /// <summary>
        /// Monitors the task (which should be ProcessRecordAsync) to control 
        /// the lifetime of the job itself
        /// </summary>
        /// <param name="task"></param>
        public void Monitor(Task task)
        {
            SetJobState(JobState.Running);
            task.ContinueWith(antecedent =>
            {
                if (antecedent.IsCanceled)
                {
                    // if the task was canceled, we're just going to call it completed.
                    SetJobState(JobState.Completed);
                }
                else if (antecedent.IsFaulted)
                {
                    foreach (var innerException in antecedent.Exception.Flatten().InnerExceptions)
                    {
                        WriteError(new System.Management.Automation.ErrorRecord(innerException, string.Empty, System.Management.Automation.ErrorCategory.NotSpecified, null));
                    }

                    // a fault indicates an actual failure
                    SetJobState(JobState.Failed);
                }
                else
                {
                    // otherwiser it's a completed state. 
                    SetJobState(JobState.Completed);
                }
            }, CancellationToken);
        }

        private void CheckForCancellation()
        {
            if (IsJobDone)
            {
                throw new LongRunningJobCancelledException("Long running job is canceled or stopping, continuation of the cmdlet is not permitted.");
            }
        }

        public void WriteInformation(InformationRecord informationRecord)
        {
            CheckForCancellation();

            this.Information.Add(informationRecord);
        }

        public bool ShouldContinue(string query, string caption, bool hasSecurityImpact, ref bool yesToAll, ref bool noToAll)
        {
            CheckForInteractive();
            return false;
        }

        public void WriteDebug(string text)
        {
            _statusMessage = text;
            CheckForCancellation();

            if (Debug.IsOpen && Debug.Count < MaxRecords)
            {
                Debug.Add(new DebugRecord(text));
            }
        }

        public void WriteError(ErrorRecord errorRecord)
        {
            if (Error.IsOpen)
            {
                Error.Add(errorRecord);
            }
        }

        public void WriteObject(object sendToPipeline)
        {
            CheckForCancellation();

            if (Output.IsOpen)
            {
                Output.Add(new PSObject(sendToPipeline));
            }
        }

        public void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            CheckForCancellation();

            if (enumerateCollection && sendToPipeline is System.Collections.IEnumerable enumerable)
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
            CheckForCancellation();

            if (Progress.IsOpen && Progress.Count < MaxRecords)
            {
                Progress.Add(progressRecord);
            }
        }

        public void WriteProgress(long sourceId, ProgressRecord progressRecord)
        {
            CheckForCancellation();

            if (Progress.IsOpen && Progress.Count < MaxRecords)
            {
                Progress.Add(progressRecord);
            }
        }

        public void WriteVerbose(string text)
        {
            CheckForCancellation();

            if (Verbose.IsOpen && Verbose.Count < MaxRecords)
            {
                Verbose.Add(new VerboseRecord(text));
            }
        }

        public void WriteWarning(string text)
        {
            CheckForCancellation();

            if (Warning.IsOpen && Warning.Count < MaxRecords)
            {
                Warning.Add(new WarningRecord(text));
            }
        }

        public void WriteCommandDetail(string text)
        {
            WriteVerbose(text);
        }

        public bool ShouldProcess(string target)
        {
            CheckForInteractive();
            return false;
        }

        public bool ShouldProcess(string target, string action)
        {
            CheckForInteractive();
            return false;
        }

        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption)
        {
            CheckForInteractive();
            return false;
        }

        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption, out ShouldProcessReason shouldProcessReason)
        {
            CheckForInteractive();
            shouldProcessReason = ShouldProcessReason.None;
            return false;
        }

        public bool ShouldContinue(string query, string caption)
        {
            CheckForInteractive();
            return false;
        }

        public bool ShouldContinue(string query, string caption, ref bool yesToAll, ref bool noToAll)
        {
            CheckForInteractive();
            return false;
        }

        public bool TransactionAvailable()
        {
            // interactivity required? 
            return false;
        }

        public void ThrowTerminatingError(ErrorRecord errorRecord)
        {
            if (Error.IsOpen)
            {
                Error.Add(errorRecord);
            }
        }
    }
}