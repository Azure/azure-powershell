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

using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Management.Automation.Remoting;
using System.Management.Automation.Remoting.Internal;
using System.Reflection;
using System.Threading;

namespace Microsoft.Azure.Commands.Common
{
    public class AzureLongRunningJob<T> : Job, ICommandRuntime where T : AzurePSCmdlet
    {
        string _status = "Running";
        T _cmdlet;
        ICommandRuntime _runtime;
        ConcurrentQueue<ShouldMethodStreamItem> _actions = new ConcurrentQueue<ShouldMethodStreamItem>();
        bool _shouldConfirm = false;
        Action<T> _execute;

        /// <summary>
        /// Create a job using the given invoked cmdlet, command name, and task name
        /// </summary>
        /// <param name="cmdlet">The cmdlet to run asynchronously</param>
        /// <param name="command">The name of the command</param>
        /// <param name="name">The name of the task</param>
        protected AzureLongRunningJob(T cmdlet, string command, string name) : this(cmdlet, command, name, (cmd) => cmd.ExecuteCmdlet())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="command"></param>
        /// <param name="name"></param>
        /// <param name="executeCmdlet"></param>
        protected AzureLongRunningJob(T cmdlet, string command, string name, Action<T> executeCmdlet) : base(command, name)
        {
            _cmdlet = CopyCmdlet(cmdlet);
            _shouldConfirm = ShouldConfirm(cmdlet);
            _cmdlet.CommandRuntime = this.GetJobRuntime();
            _runtime = cmdlet.CommandRuntime;
            _execute = executeCmdlet;
            this.PSJobTypeName = this.GetType().Name;
        }

        /// <summary>
        /// Is there additional data in the task that has not been received by the uesr?
        /// </summary>
        public override bool HasMoreData
        {
            get { return Output.Any() || Progress.Any() || Error.Any() || Warning.Any() || Verbose.Any() || Debug.Any(); }
        }

        /// <summary>
        /// The location where the task executes
        /// </summary>
        public override string Location
        {
            get
            {
                return "localhost";
            }
        }

        /// <summary>
        /// Textual representation fo the task status
        /// </summary>
        public override string StatusMessage
        {
            get
            {
                return _status;
            }
        }

        /// <summary>
        /// A queue of actions that must execute on the cmdlet thread
        /// </summary>
        internal ConcurrentQueue<ShouldMethodStreamItem> BlockedActions { get { return _actions; } }

        /// <summary>
        /// Factory method for creating jobs
        /// </summary>
        /// <param name="cmdlet">The invoked cmdlet to run as a job</param>
        /// <param name="command">The name of the command executed</param>
        /// <param name="name">The name of the task</param>
        /// <returns>A job tracking the background execution of the cmdlet</returns>
        public static AzureLongRunningJob<U> Create<U>(U cmdlet, string command, string name) where U : AzurePSCmdlet
        {
            if (cmdlet == null)
            {
                throw new ArgumentNullException(nameof(cmdlet));
            }

            if (string.IsNullOrWhiteSpace(command))
            {
                command = cmdlet.GetType().Name;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Azure Long-Running Job";
            }

            var job = new Common.AzureLongRunningJob<U>(cmdlet, command, name);
            return job;
        }

        /// <summary>
        /// Factory method for creating jobs
        /// </summary>
        /// <typeparam name="U">The type of the cmdlet to create</typeparam>
        /// <param name="cmdlet">The invoked cmdlet to run as a job</param>
        /// <param name="command">The name of the command executed</param>
        /// <param name="name">The name of the task</param>
        /// <param name="executor">The cmdlet method to execute</param>
        /// <returns>A job tracking the background execution of the cmdlet</returns>
        public static AzureLongRunningJob<U> Create<U>(U cmdlet, string command, string name, Action<U> executor) where U : AzurePSCmdlet
        {
            if (null == cmdlet)
            {
                throw new ArgumentNullException(nameof(cmdlet));
            }

            if (null == executor)
            {
                throw new ArgumentNullException(nameof(executor));
            }

            if (string.IsNullOrWhiteSpace(command))
            {
                command = cmdlet.GetType().Name;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Azure Long-Running Job";
            }

            var job = new Common.AzureLongRunningJob<U>(cmdlet, command, name, executor);
            return job;
        }


        /// <summary>
        /// Copy the unique properties of a cmdlet - used to capture the properties of a cmdlet during pipeline execution
        /// </summary>
        /// <param name="cmdlet">The cmdlet</param>
        /// <returns>A deep copy fo the cmdlet</returns>
        public static U CopyCmdlet<U>(U cmdlet) where U : AzurePSCmdlet
        {
            if (cmdlet == null)
            {
                throw new ArgumentNullException(nameof(cmdlet));
            }

            var returnType = cmdlet.GetType();
            var returnValue = Activator.CreateInstance(cmdlet.GetType());
            foreach (var property in returnType.GetProperties())
            {
                if (property.CanWrite && property.CanRead)
                {
                    property.SafeCopyValue(source: cmdlet, target: returnValue);
                }
            }
            foreach (var field in returnType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
            {
                    field.SafeCopyValue(source: cmdlet, target: returnValue);
            }

            return returnValue as U;
        }

        /// <summary>
        /// Run a cmdlet execution as a Job - this is intended to run in a background thread
        /// </summary>
        /// <param name="state">The Job record that will track the progress of this job </param>
        public virtual void RunJob(object state)
        {
            try
            {
                Start();
                WriteDebug(string.Format("[AzureLongRunningJob]: Starting cmdlet execution, must confirm: {0}", _shouldConfirm));
                _execute(_cmdlet);
                WriteDebug("[AzureLongRunningJob]: Completing cmdlet execution successfully");
                Complete();
            }
            catch (Exception ex)
            {
                string message = string.Format("The cmdlet failed in background execution.  The returned error was '{0}'.  Please execute the cmdlet again.  You may need to execute this cmdlet synchronously, by omitting the '-AsJob' parameter", ex.Message);
                Error.Add(new ErrorRecord(ex, message, ErrorCategory.InvalidOperation, this));
                WriteDebug("[AzureLongRunningJob]: Error in cmdlet execution");
                Fail();
            }
        }

        /// <summary>
        /// Return cmdlet runtime that will report results to this job
        /// </summary>
        /// <returns>An IcommandRuntime that reports results to this job</returns>
        public virtual ICommandRuntime GetJobRuntime()
        {
            return this as ICommandRuntime;
        }

        /// <summary>
        /// Run any cmdlet actiosn that have to be run on the cmdlet thread
        /// </summary>
        protected void UnblockJob()
        {
            var executor = CopyCmdlet(_cmdlet);
            executor.CommandRuntime = _runtime;
            ShouldMethodStreamItem stream;
            while (_actions.TryDequeue(out stream))
            {
                stream.ExecuteShouldMethod(executor);
            }
        }

        /// <summary>
        /// Mark the task as started
        /// </summary>
        public void Start()
        {
            _status = "Running";
            SetJobState(JobState.Running);
        }

        /// <summary>
        /// Mark the task as blocked
        /// </summary>
        public void Block()
        {
            _status = "Blocked";
            SetJobState(JobState.Blocked);
        }

        /// <summary>
        /// Mark the job as Failed
        /// </summary>
        public void Fail()
        {
            _status = "Failed";
            SetJobState(JobState.Failed);
        }

        /// <summary>
        /// Mark the job as successfully complete
        /// </summary>
        public void Complete()
        {
            _status = "Completed";
            SetJobState(JobState.Completed);
        }

        /// <summary>
        /// Mark the job as cancelled
        /// </summary>
        public void Cancel()
        {
            _status = "Stopped";
            SetJobState(JobState.Stopped);
        }

        // Members for implementing command runtime for this job
        public PSTransactionContext CurrentPSTransaction
        {
            get
            {
                return _runtime.CurrentPSTransaction;
            }
        }

        /// <summary>
        /// The PSHost for execution
        /// </summary>
        public PSHost Host
        {
            get
            {
                return _runtime.Host;
            }
        }

        /// <summary>
        /// Prompt the user to continue
        /// </summary>
        /// <param name="query">The user query</param>
        /// <param name="caption">The dialog caption for the query</param>
        /// <returns>True if the user consented</returns>
        public bool ShouldContinue(string query, string caption)
        {
            Exception thrownException;
            return InvokeShouldMethodAndWaitForResults(cmdlet => cmdlet.ShouldContinue(query, caption), out thrownException);
        }

        /// <summary>
        /// Prompt the user to continue
        /// </summary>
        /// <param name="query">The user query</param>
        /// <param name="caption">The caption for the query dialog</param>
        /// <param name="yesToAll">Did the user respond with Yes to all prompts?</param>
        /// <param name="noToAll">Did the user respond with 'No' to all prompts?</param>
        /// <returns>True if the user wants to continue</returns>
        public bool ShouldContinue(string query, string caption, ref bool yesToAll, ref bool noToAll)
        {
            Exception thrownException;
            bool localYesToAll = yesToAll;
            bool localNoToAll = noToAll;
            bool result = InvokeShouldMethodAndWaitForResults(cmdlet => cmdlet.ShouldContinue(query, caption,
                ref localYesToAll, ref localNoToAll), out thrownException);
            yesToAll = localYesToAll;
            noToAll = localNoToAll;
            return result;
        }

        /// <summary>
        /// Determine if A ShouldProcess prompt should be handled by the calling cmdlet, or can simply return true
        /// </summary>
        /// <param name="cmdlet">The cmdlet to check</param>
        /// <returns>True if ShouldProcess must be called on the cmdlet thread, otherwise false</returns>
        static bool ShouldConfirm(AzurePSCmdlet cmdlet)
        {
            ConfirmImpact confirmPreference = ConfirmImpact.High;
            ConfirmImpact cmdletImpact = ConfirmImpact.Medium;
            var confirmVar = SafeGetVariableValue(cmdlet, "ConfirmPreference", "High");
            if (!string.IsNullOrEmpty(confirmVar))
            {
                Enum.TryParse(confirmVar, out confirmPreference);
            }

            var attribute = cmdlet.GetType().GetTypeInfo().GetCustomAttribute<CmdletAttribute>(true);
            if (attribute != null)
            {
                cmdletImpact = attribute.ConfirmImpact;
            }

            return cmdletImpact >= confirmPreference;
        }

        static string SafeGetVariableValue(PSCmdlet cmdlet, string name, string defaultValue)
        {
            string result;
            try
            {
                result = cmdlet.GetVariableValue(name, defaultValue) as string;
            }
            catch
            {
                result = defaultValue;
            }

            return result;
        }

        /// <summary>
        /// Determine if a call to ShouldProcess would automatically return true, and thus can be handled without executing on the cmdlet thread
        /// </summary>
        /// <returns>True if ShouldProcess does not need to be executed, false otherwise</returns>
        bool CanHandleShouldProcessLocally()
        {
            return !(_cmdlet.MyInvocation.BoundParameters.ContainsKey("Confirm") && (bool)_cmdlet.MyInvocation.BoundParameters["Confirm"]) &&
                !(_cmdlet.MyInvocation.BoundParameters.ContainsKey("WhatIf") && (bool)_cmdlet.MyInvocation.BoundParameters["WhatIf"]) &&
                !_shouldConfirm;
        }

        /// <summary>
        /// Confirm an action with the user, as apppropriate
        /// </summary>
        /// <param name="target">The target of the action to confirm</param>
        /// <returns>True if the action is confirmed (by user or automatically), otherwise false</returns>
        public bool ShouldProcess(string target)
        {
            if (CanHandleShouldProcessLocally())
            {
                return true;
            }

            Exception thrownException;
            return InvokeShouldMethodAndWaitForResults(cmdlet => cmdlet.ShouldProcess(target), out thrownException);
        }

        /// <summary>
        /// Confirm the specified action on the specified target
        /// </summary>
        /// <param name="target">The target of the action</param>
        /// <param name="action">The action</param>
        /// <returns>True if the action is confirmed (automatically, or by user interaction), otherwise false</returns>
        public bool ShouldProcess(string target, string action)
        {
            if (CanHandleShouldProcessLocally())
            {
                return true;
            }

            Exception thrownException;
            return InvokeShouldMethodAndWaitForResults(cmdlet => cmdlet.ShouldProcess(target, action), out thrownException);
        }

        /// <summary>
        /// Confirm the an action on the target
        /// </summary>
        /// <param name="verboseDescription">A description of the action</param>
        /// <param name="verboseWarning">A warnign about side effects</param>
        /// <param name="caption">The caption of the confirmation dialog</param>
        /// <returns>True if the action is confirmed (automatically, or by user interaction), otherwise false</returns>
        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption)
        {
            if (CanHandleShouldProcessLocally())
            {
                return true;
            }

            Exception thrownException;
            return InvokeShouldMethodAndWaitForResults(cmdlet => cmdlet.ShouldProcess(verboseDescription, verboseWarning, caption),
                out thrownException);
        }

        /// <summary>
        /// Confirm the specified action on the specified target
        /// </summary>
        /// <param name="verboseDescription">A description of the action</param>
        /// <param name="verboseWarning">A warnign about side effects</param>
        /// <param name="caption">The caption of the confirmation dialog</param>
        /// <param name="shouldProcessReason">The reason a confirmation is printed</param>
        /// <returns>True if the action is confirmed (automatically, or by user interaction), otherwise false</returns>
        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption, out ShouldProcessReason shouldProcessReason)
        {
            if (CanHandleShouldProcessLocally())
            {
                shouldProcessReason = ShouldProcessReason.None;
                return true;
            }

            ShouldProcessReason closureShouldProcessReason = ShouldProcessReason.None;
            Exception thrownException;
            bool result = InvokeShouldMethodAndWaitForResults(cmdlet => cmdlet.ShouldProcess(verboseDescription, verboseWarning, caption, out closureShouldProcessReason),
                out thrownException);
            shouldProcessReason = closureShouldProcessReason;
            return result;
        }

        /// <summary>
        /// Throw an error that terminates the current pipeline
        /// </summary>
        /// <param name="errorRecord">The error to throw</param>
        public void ThrowTerminatingError(ErrorRecord errorRecord)
        {
            Error.Add(errorRecord);
        }

        /// <summary>
        /// Determine if an ambient transaction is available
        /// </summary>
        /// <returns>True if an ambient transaction is available, otherwise false</returns>
        public bool TransactionAvailable()
        {
            Exception thrownException;
            return InvokeShouldMethodAndWaitForResults(cmdlet => cmdlet.TransactionAvailable(),
                out thrownException);
        }

        /// <summary>
        /// Write details about a command
        /// </summary>
        /// <param name="text">The text to write</param>
        public void WriteCommandDetail(string text)
        {
            Verbose.Add(new VerboseRecord(text));
        }

        /// <summary>
        /// Write to the debug log
        /// </summary>
        /// <param name="text">The message to write</param>
        public void WriteDebug(string text)
        {
            Debug.Add(new DebugRecord(text));
        }

        /// <summary>
        /// Write to the eeror stream
        /// </summary>
        /// <param name="errorRecord">The error to write</param>
        public void WriteError(ErrorRecord errorRecord)
        {
            Error.Add(errorRecord);
        }

        /// <summary>
        /// Write an output object to the pipeline
        /// </summary>
        /// <param name="sendToPipeline">The putput object</param>
        public void WriteObject(object sendToPipeline)
        {
            Output.Add(new PSObject(sendToPipeline));
        }

        /// <summary>
        /// Write an output object to the pipeline
        /// </summary>
        /// <param name="sendToPipeline">The putput object</param>
        /// <param name="enumerateCollection">If the output object is an enumeration, should each object be written to the pipeline?</param>
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

        /// <summary>
        /// Write information to the progress stream
        /// </summary>
        /// <param name="progressRecord">The progress to write</param>
        public void WriteProgress(ProgressRecord progressRecord)
        {
            Progress.Add(progressRecord);
        }

        /// <summary>
        /// Write information to the progress stream
        /// </summary>
        /// <param name="sourceId">The id of the task source</param>
        /// <param name="progressRecord">The progress info to write</param>
        public void WriteProgress(long sourceId, ProgressRecord progressRecord)
        {
            WriteProgress(progressRecord);
        }

        /// <summary>
        /// Write verbose logging information
        /// </summary>
        /// <param name="text">The verbose message to add</param>
        public void WriteVerbose(string text)
        {
            Verbose.Add(new VerboseRecord(text));
        }

        /// <summary>
        /// Write a wrning
        /// </summary>
        /// <param name="text">The warning to write</param>
        public void WriteWarning(string text)
        {
            Warning.Add(new WarningRecord(text));
        }

        /// <summary>
        /// Helper function to check if job is finished
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        internal bool IsFailedOrCancelled(JobState state)
        {
            return (state == JobState.Failed || state == JobState.Stopped);
        }

        /// <summary>
        /// Queue actions that must occur on the cmdlet thread, and block the current thread until they are completed
        /// </summary>
        /// <param name="shouldMethod">The action to invoke</param>
        /// <param name="exceptionThrownOnCmdletThread">Any exception that results</param>
        /// <returns>The result of executing the action on the cmdlet thread</returns>
        private bool InvokeShouldMethodAndWaitForResults(Func<Cmdlet, bool> shouldMethod, out Exception exceptionThrownOnCmdletThread)
        {

            bool methodResult = false;
            Exception closureSafeExceptionThrownOnCmdletThread = null;
            object resultsLock = new object();
            using (var gotResultEvent = new ManualResetEventSlim(false))
            {
                EventHandler<JobStateEventArgs> stateChangedEventHandler =
                    delegate (object sender, JobStateEventArgs eventArgs)
                    {
                        WriteDebug(string.Format("[AzureLongRunningJob]: State change from {0} to {1} because {2}", eventArgs?.PreviousJobStateInfo?.State, eventArgs?.JobStateInfo?.State, eventArgs?.PreviousJobStateInfo?.Reason));
                        if (eventArgs?.JobStateInfo?.State != JobState.Blocked && eventArgs?.PreviousJobStateInfo?.State == JobState.Blocked)
                        {
                            WriteDebug("[AzureLongRunningJob]: Unblocking job that was previously blocked");
                            // if receive-job is called, unblock by executing delayed powershell actions
                            UnblockJob();
                        }

                        if (IsFailedOrCancelled(eventArgs.JobStateInfo.State) || eventArgs.JobStateInfo.State == JobState.Stopping)
                        {
                            WriteDebug("[AzureLongRunningJob]: Unblocking job due to stoppage or failure");
                            lock (resultsLock)
                            {
                                closureSafeExceptionThrownOnCmdletThread = new OperationCanceledException();
                            }
                            gotResultEvent.Set();
                        }
                    };
                this.StateChanged += stateChangedEventHandler;
                Interlocked.MemoryBarrier();
                try
                {
                    stateChangedEventHandler(null, new JobStateEventArgs(this.JobStateInfo));

                    if (!gotResultEvent.IsSet)
                    {
                        this.Block();
                        WriteDebug("[AzureLongRunningJob]: Blocking job for ShouldMethod");
                        ShouldMethodInvoker methodInvoker = new ShouldMethodInvoker
                        {
                            ShouldMethod = shouldMethod,
                            Finished = gotResultEvent,
                            SyncObject = resultsLock
                        };

                        BlockedActions.Enqueue(new ShouldMethodStreamItem(methodInvoker));
                        gotResultEvent.Wait();
                        WriteDebug("[AzureLongRunningJob]: ShouldMethod unblocked");
                        this.Start();

                        lock (resultsLock)
                        {
                            if (closureSafeExceptionThrownOnCmdletThread == null) // stateChangedEventHandler didn't set the results?  = ok to clobber results?
                            {
                                closureSafeExceptionThrownOnCmdletThread = methodInvoker.ThrownException;
                                methodResult = methodInvoker.MethodResult;
                            }
                        }
                    }
                }
                finally
                {
                    WriteDebug(string.Format("[AzureLongRunningJob]: Removing state changed event handler, exception {0}", closureSafeExceptionThrownOnCmdletThread?.Message));
                    this.StateChanged -= stateChangedEventHandler;
                }
            }

            lock (resultsLock)
            {
                exceptionThrownOnCmdletThread = closureSafeExceptionThrownOnCmdletThread;
                return methodResult;
            }
        }

        public override void StopJob()
        {
            ShouldMethodStreamItem stream;
            while (_actions.TryDequeue(out stream));
            this.Cancel();
        }
    }
}
