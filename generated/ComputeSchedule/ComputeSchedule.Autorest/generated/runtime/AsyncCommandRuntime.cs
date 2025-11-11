/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.PowerShell
{
    using System.Management.Automation;
    using System.Management.Automation.Host;
    using System.Threading;
    using System.Linq;

    internal interface IAsyncCommandRuntimeExtensions
    {
        Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.SendAsyncStep Wrap(Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.SendAsyncStep func);
        System.Collections.Generic.IEnumerable<Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.SendAsyncStep> Wrap(System.Collections.Generic.IEnumerable<Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.SendAsyncStep> funcs);

        T ExecuteSync<T>(System.Func<T> step);
    }

    public class AsyncCommandRuntime : System.Management.Automation.ICommandRuntime2, IAsyncCommandRuntimeExtensions, System.IDisposable
    {
        private ICommandRuntime2 originalCommandRuntime;
        private System.Threading.Thread originalThread;
        public bool AllowInteractive { get; set; } = false;

        public CancellationToken cancellationToken;
        SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        ManualResetEventSlim readyToRun = new ManualResetEventSlim(false);
        ManualResetEventSlim completed = new ManualResetEventSlim(false);

        System.Action runOnMainThread;

        private System.Management.Automation.PSCmdlet cmdlet;

        internal AsyncCommandRuntime(System.Management.Automation.PSCmdlet cmdlet, CancellationToken cancellationToken)
        {
            this.originalCommandRuntime = cmdlet.CommandRuntime as ICommandRuntime2;
            this.originalThread = System.Threading.Thread.CurrentThread;
            this.cancellationToken = cancellationToken;
            this.cmdlet = cmdlet;
            if (cmdlet.PagingParameters != null)
            {
                WriteDebug("Client side pagination is enabled for this cmdlet");
            }
            cmdlet.CommandRuntime = this;
        }

        public PSHost Host => this.originalCommandRuntime.Host;

        public PSTransactionContext CurrentPSTransaction => this.originalCommandRuntime.CurrentPSTransaction;

        private void CheckForInteractive()
        {
            // This is an interactive call -- if we are not on the original thread, this will only work if this was done at ACR creation time;
            if (!AllowInteractive)
            {
                throw new System.Exception("AsyncCommandRuntime is not configured for interactive calls");
            }
        }
        private void WaitOurTurn()
        {
            // wait for our turn to play
            semaphore?.Wait(cancellationToken);

            // ensure that completed is not set
            completed.Reset();
        }

        private void WaitForCompletion()
        {
            // wait for the result (or cancellation!)
            WaitHandle.WaitAny(new[] { cancellationToken.WaitHandle, completed?.WaitHandle });

            // let go of the semaphore
            semaphore?.Release();

        }

        public bool ShouldContinue(string query, string caption, bool hasSecurityImpact, ref bool yesToAll, ref bool noToAll)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                return originalCommandRuntime.ShouldContinue(query, caption, hasSecurityImpact, ref yesToAll, ref noToAll);
            }

            CheckForInteractive();

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                bool yta = yesToAll;
                bool nta = noToAll;
                bool result = false;

                // set the function to run
                runOnMainThread = () => result = originalCommandRuntime.ShouldContinue(query, caption, hasSecurityImpact, ref yta, ref nta);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // set the output variables
                yesToAll = yta;
                noToAll = nta;
                return result;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public bool ShouldContinue(string query, string caption)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                return originalCommandRuntime.ShouldContinue(query, caption);
            }

            CheckForInteractive();

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                bool result = false;

                // set the function to run
                runOnMainThread = () => result = originalCommandRuntime.ShouldContinue(query, caption);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // set the output variables
                return result;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public bool ShouldContinue(string query, string caption, ref bool yesToAll, ref bool noToAll)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                return originalCommandRuntime.ShouldContinue(query, caption, ref yesToAll, ref noToAll);
            }

            CheckForInteractive();

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                bool yta = yesToAll;
                bool nta = noToAll;
                bool result = false;

                // set the function to run
                runOnMainThread = () => result = originalCommandRuntime.ShouldContinue(query, caption, ref yta, ref nta);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // set the output variables
                yesToAll = yta;
                noToAll = nta;
                return result;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public bool ShouldProcess(string target)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                return originalCommandRuntime.ShouldProcess(target);
            }

            CheckForInteractive();

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                bool result = false;

                // set the function to run
                runOnMainThread = () => result = originalCommandRuntime.ShouldProcess(target);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // set the output variables
                return result;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public bool ShouldProcess(string target, string action)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                return originalCommandRuntime.ShouldProcess(target, action);
            }

            CheckForInteractive();

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                bool result = false;

                // set the function to run
                runOnMainThread = () => result = originalCommandRuntime.ShouldProcess(target, action);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // set the output variables
                return result;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                return originalCommandRuntime.ShouldProcess(verboseDescription, verboseWarning, caption);
            }

            CheckForInteractive();

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                bool result = false;

                // set the function to run
                runOnMainThread = () => result = originalCommandRuntime.ShouldProcess(verboseDescription, verboseWarning, caption);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // set the output variables
                return result;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption, out ShouldProcessReason shouldProcessReason)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                return originalCommandRuntime.ShouldProcess(verboseDescription, verboseWarning, caption, out shouldProcessReason);
            }

            CheckForInteractive();

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                bool result = false;
                ShouldProcessReason reason = ShouldProcessReason.None;

                // set the function to run
                runOnMainThread = () => result = originalCommandRuntime.ShouldProcess(verboseDescription, verboseWarning, caption, out reason);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // set the output variables
                shouldProcessReason = reason;
                return result;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public void ThrowTerminatingError(ErrorRecord errorRecord)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                originalCommandRuntime.ThrowTerminatingError(errorRecord);
                return;
            }

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                // set the function to run
                runOnMainThread = () => originalCommandRuntime.ThrowTerminatingError(errorRecord);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // return
                return;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public bool TransactionAvailable()
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                return originalCommandRuntime.TransactionAvailable();
            }

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                bool result = false;

                // set the function to run
                runOnMainThread = () => result = originalCommandRuntime.TransactionAvailable();

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // set the output variables
                return result;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public void WriteCommandDetail(string text)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                originalCommandRuntime.WriteCommandDetail(text);
                return;
            }

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                // set the function to run
                runOnMainThread = () => originalCommandRuntime.WriteCommandDetail(text);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // return
                return;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public void WriteDebug(string text)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                originalCommandRuntime.WriteDebug(text);
                return;
            }

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                // set the function to run
                runOnMainThread = () => originalCommandRuntime.WriteDebug(text);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // return
                return;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public void WriteError(ErrorRecord errorRecord)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                originalCommandRuntime.WriteError(errorRecord);
                return;
            }

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                // set the function to run
                runOnMainThread = () => originalCommandRuntime.WriteError(errorRecord);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // return
                return;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public void WriteInformation(InformationRecord informationRecord)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                originalCommandRuntime.WriteInformation(informationRecord);
                return;
            }

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                // set the function to run
                runOnMainThread = () => originalCommandRuntime.WriteInformation(informationRecord);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // return
                return;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public void WriteObject(object sendToPipeline)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                originalCommandRuntime.WriteObject(sendToPipeline);
                return;
            }

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                // set the function to run
                runOnMainThread = () => originalCommandRuntime.WriteObject(sendToPipeline);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // return
                return;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                originalCommandRuntime.WriteObject(sendToPipeline, enumerateCollection);
                return;
            }

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                // set the function to run
                runOnMainThread = () => originalCommandRuntime.WriteObject(sendToPipeline, enumerateCollection);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // return
                return;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public void WriteProgress(ProgressRecord progressRecord)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                originalCommandRuntime.WriteProgress(progressRecord);
                return;
            }

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                // set the function to run
                runOnMainThread = () => originalCommandRuntime.WriteProgress(progressRecord);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // return
                return;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public void WriteProgress(long sourceId, ProgressRecord progressRecord)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                originalCommandRuntime.WriteProgress(sourceId, progressRecord);
                return;
            }

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                // set the function to run
                runOnMainThread = () => originalCommandRuntime.WriteProgress(sourceId, progressRecord);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // return
                return;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public void WriteVerbose(string text)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                originalCommandRuntime.WriteVerbose(text);
                return;
            }

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                // set the function to run
                runOnMainThread = () => originalCommandRuntime.WriteVerbose(text);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // return
                return;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public void WriteWarning(string text)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                originalCommandRuntime.WriteWarning(text);
                return;
            }

            // otherwise, queue up the request and wait for the main thread to do the right thing. 
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();

                // set the function to run
                runOnMainThread = () => originalCommandRuntime.WriteWarning(text);

                // tell the main thread to go ahead
                readyToRun.Set();

                // wait for the result (or cancellation!)
                WaitForCompletion();

                // return
                return;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public void Wait(System.Threading.Tasks.Task ProcessRecordAsyncTask, System.Threading.CancellationToken cancellationToken)
        {
            do
            {
                WaitHandle.WaitAny(new[] { readyToRun.WaitHandle, ((System.IAsyncResult)ProcessRecordAsyncTask).AsyncWaitHandle });
                if (readyToRun.IsSet)
                {
                    // reset the request for the next time
                    readyToRun.Reset();

                    // run the delegate on this thread
                    runOnMainThread();

                    // tell the originator everything is complete
                    completed.Set();
                }
            }
            while (!ProcessRecordAsyncTask.IsCompleted);
            if (ProcessRecordAsyncTask.IsFaulted)
            {
                // don't unwrap a Aggregate Exception -- we'll lose the stack trace of the actual exception.
                // if(  ProcessRecordAsyncTask.Exception is System.AggregateException aggregate ) {
                //   throw aggregate.InnerException;
                // }
                throw ProcessRecordAsyncTask.Exception;
            }
        }
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.SendAsyncStep Wrap(Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.SendAsyncStep func) => func.Target.GetType().Name != "Closure" ? func : (p1, p2, p3) => ExecuteSync<System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>(() => func(p1, p2, p3));
        public System.Collections.Generic.IEnumerable<Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.SendAsyncStep> Wrap(System.Collections.Generic.IEnumerable<Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.SendAsyncStep> funcs) => funcs?.Select(Wrap);

        public T ExecuteSync<T>(System.Func<T> step)
        {
            // if we are on the original thread, just call straight thru.
            if (this.originalThread == System.Threading.Thread.CurrentThread)
            {
                return step();
            }

            T result = default(T);
            try
            {
                // wait for our turn to talk to the main thread
                WaitOurTurn();
                // set the function to run
                runOnMainThread = () => { result = step(); };
                // tell the main thread to go ahead
                readyToRun.Set();
                // wait for the result (or cancellation!)
                WaitForCompletion();
                // return
                return result;
            }
            catch (System.OperationCanceledException exception)
            {
                // maybe don't even worry?
                throw exception;
            }
        }

        public void Dispose()
        {
            if (cmdlet != null)
            {
                cmdlet.CommandRuntime = this.originalCommandRuntime;
                cmdlet = null;
            }

            semaphore?.Dispose();
            semaphore = null;
            readyToRun?.Dispose();
            readyToRun = null;
            completed?.Dispose();
            completed = null;
        }
    }
}