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
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Reflection;
using System.Threading;

namespace Microsoft.Azure.Commands.Common
{
    /// <summary>
    /// Abstract class for uniform processing of jobs
    /// </summary>
    public abstract class AzureLongRunningJob : Job
    {
        protected AzureLongRunningJob(string command, string name) : base(command, name)
        {
        }

        /// <summary>
        /// Run a cmdlet execution as a Job - this is intended to run in a background thread
        /// </summary>
        /// <param name="state">The Job record that will track the progress of this job </param>
        public abstract void RunJob(object state);

        /// <summary>
        /// Return cmdlet runtime that will report results to this job
        /// </summary>
        /// <returns>An IcommandRuntime that reports results to this job</returns>
        public abstract ICommandRuntime GetJobRuntime();

        /// <summary>
        /// Mark the job as started
        /// </summary>
        public abstract bool TryStart();

        /// <summary>
        /// Mark the job as Blocked
        /// </summary>
        public abstract bool TryBlock();


        /// <summary>
        /// Complete the job (will mark job as Completed or Failed, depending on the execution details)
        /// </summary>
        public abstract void Complete();

        /// <summary>
        /// Mark the Job as Failed
        /// </summary>
        public abstract void Fail();

        /// <summary>
        /// Stop the job
        /// </summary>
        public abstract void Cancel();
    }

    /// <summary>
    /// Cmdlet-specific Implementation class for long running jobs
    /// </summary>
    /// <typeparam name="T">The type of the cmdlet being executed</typeparam>
    public class AzureLongRunningJob<T> : AzureLongRunningJob, ICommandRuntime where T : AzurePSCmdlet
    {
        const int MaxRecords = 1000;
        string _status = "Running";
        T _cmdlet;
        ICommandRuntime _runtime;
        ConcurrentQueue<ShouldMethodStreamItem> _actions = new ConcurrentQueue<ShouldMethodStreamItem>();
        bool _shouldConfirm = false;
        Action<T> _execute;
        bool _failedOnUnblock = false;
        object _lockObject = new object();

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
            _cmdlet.CommandRuntime = this;
            _runtime = cmdlet.CommandRuntime;
            _execute = executeCmdlet;
            this.PSJobTypeName = this.GetType().Name;
        }

        /// <summary>
        /// Is there additional data in the task that has not been received by the uesr?
        /// </summary>
        public override bool HasMoreData
        {
            get { return Output.Any() || Progress.Any() || Error.Any() 
                    || Warning.Any() || Verbose.Any() || Debug.Any(); }
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
                name = Resources.LROJobName;
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
                name = Resources.LROJobName;
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

            Type returnType = cmdlet.GetType();
            U returnValue = Activator.CreateInstance(returnType) as U;
            foreach (var property in returnType.GetProperties())
            {
                if (property.CanWrite && property.CanRead)
                {
                    property.SafeCopyValue(source: cmdlet, target: returnValue);
                }
            }

            foreach (var parameter in cmdlet.MyInvocation.BoundParameters)
            {
                returnValue.MyInvocation.BoundParameters.Add(parameter.Key, parameter.Value);
            }

            foreach (var field in returnType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
            {
                field.SafeCopyValue(source: cmdlet, target: returnValue);
            }

            cmdlet.SafeCopyParameterSet(returnValue);
            return returnValue as U;
        }

        /// <summary>
        /// Run a cmdlet execution as a Job - this is intended to run in a background thread
        /// </summary>
        /// <param name="state">The Job record that will track the progress of this job </param>
        public override void RunJob(object state)
        {
            if (TryStart())
            {
                try
                {
                    WriteDebug(string.Format(Resources.TraceBeginLROJob, _shouldConfirm));
                    _execute(_cmdlet);
                    WriteDebug(Resources.TraceEndLROJob);
                }
                catch (LongRunningJobCancelledException)
                {
                    // swallow exceptions wcaused by job stopping
                }
                catch (PSInvalidOperationException) when (IsFailedOrCancelled(JobStateInfo.State))
                {
                    // do not attempt to write exceptions when a job is stopped 
                }
                catch (Exception ex) when (!IsFailedOrCancelled(JobStateInfo.State))
                {
                    string message = string.Format(Resources.LROTaskExceptionMessage, ex.Message);
                    WriteError(new ErrorRecord(ex, message, ErrorCategory.InvalidOperation, this));
                    WriteDebug(Resources.TraceLROJobException);
                    _failedOnUnblock = true;
                }
                finally
                {
                    Complete();
                }
            }
        }

        /// <summary>
        /// Return cmdlet runtime that will report results to this job
        /// </summary>
        /// <returns>An IcommandRuntime that reports results to this job</returns>
        public override ICommandRuntime GetJobRuntime()
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
            while (!IsFailedOrCancelled(JobStateInfo.State) && _actions.TryDequeue(out stream))
            {
                try
                {
                    stream.ExecuteShouldMethod(executor);
                }
                catch (InvalidOperationException exception)
                {
                    _failedOnUnblock = true;
                    WriteError(new ErrorRecord(new InvalidOperationException(GetShouldMethodFailureReaon(_cmdlet, stream), exception), "InvalidBackgroundOperation", ErrorCategory.InvalidOperation, this));
                }
                finally
                {
                    lock (stream.MethodInvoker.SyncObject)
                    {
                        stream?.MethodInvoker?.Finished?.Set();
                    }
                }
            }
        }

        internal string GetShouldMethodFailureReaon(T cmdlet, ShouldMethodStreamItem method)
        {
            string result = Resources.BaseShouldMethodFailureReason;
            var boundParameters = cmdlet?.MyInvocation?.BoundParameters;
            var methodType = method?.MethodInvoker?.MethodType ?? ShouldMethodType.ShouldContinue;
            switch (methodType)
            {
                case ShouldMethodType.ShouldProcess:
                    if (boundParameters != null && boundParameters.ContainsKey("Confirm") && (bool)boundParameters["Confirm"])
                    {
                        result += Resources.ShouldProcessFailConfirm;
                    }
                    else if (boundParameters != null && boundParameters.ContainsKey("WhatIf") && (bool)boundParameters["WhatIf"])
                    {
                        result += Resources.ShouldProcessFailWhatIf;
                    }
                    else
                    {
                        result += Resources.ShouldProcessFailImpact;
                    }
                    break;
                case ShouldMethodType.ShouldContinue:
                    result += Resources.ShouldContinueFail;
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// Mark the task as started
        /// </summary>
        public override bool TryStart()
        {
            bool result = false;
            lock (_lockObject)
            {
                if (!IsFailedOrCancelled(JobStateInfo.State))
                {
                    _status = "Running";
                    SetJobState(JobState.Running);
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Mark the task as blocked
        /// </summary>
        public override bool TryBlock()
        {
            bool result = false;
            lock (_lockObject)
            {
                if (!IsFailedOrCancelled(JobStateInfo.State))
                {
                    _status = "Blocked";
                    SetJobState(JobState.Blocked);
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Mark the job as Failed
        /// </summary>
        public override void Fail()
        {
            lock (_lockObject)
            {
                _status = "Failed";
                SetJobState(JobState.Failed);
            }
        }

        /// <summary>
        /// Mark the job as successfully complete
        /// </summary>
        public override void Complete()
        {
            lock (_lockObject)
            {
                if (_failedOnUnblock)
                {
                    _status = "Failed";
                    SetJobState(JobState.Failed);
                }

                if (JobStateInfo != null && !IsFailedOrCancelled(JobStateInfo.State))
                {
                    _status = "Completed";
                    SetJobState(JobState.Completed);
                }
            }
        }

        /// <summary>
        /// Mark the job as cancelled
        /// </summary>
        public override void Cancel()
        {
            lock (_lockObject)
            {
                _status = "Stopped";
                SetJobState(JobState.Stopped);
            }
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
            return InvokeShouldMethodAndWaitForResults(cmdlet => cmdlet.ShouldContinue(query, caption),
                ShouldMethodType.ShouldContinue, out thrownException);
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
                ref localYesToAll, ref localNoToAll), ShouldMethodType.ShouldContinue, out thrownException);
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
        /// Throw if the job was terminated by failure or cancellation
        /// </summary>
        /// <param name="runtimeAction"></param>
        protected void ThrowIfJobFailedOrCancelled()
        {
            lock (_lockObject)
            {
                if (IsFailedOrCancelled(JobStateInfo.State))
                {
                    throw new LongRunningJobCancelledException("Azure Long running job is stopping, cnanot perform any action");
                }
            }
        }

        /// <summary>
        /// Confirm an action with the user, as apppropriate
        /// </summary>
        /// <param name="target">The target of the action to confirm</param>
        /// <returns>True if the action is confirmed (by user or automatically), otherwise false</returns>
        public bool ShouldProcess(string target)
        {
            ThrowIfJobFailedOrCancelled();
            if (CanHandleShouldProcessLocally())
            {
                return true;
            }

            Exception thrownException;
            return InvokeShouldMethodAndWaitForResults(cmdlet => cmdlet.ShouldProcess(target),
                ShouldMethodType.ShouldProcess, out thrownException);
        }

        /// <summary>
        /// Confirm the specified action on the specified target
        /// </summary>
        /// <param name="target">The target of the action</param>
        /// <param name="action">The action</param>
        /// <returns>True if the action is confirmed (automatically, or by user interaction), otherwise false</returns>
        public bool ShouldProcess(string target, string action)
        {
            ThrowIfJobFailedOrCancelled();
            if (CanHandleShouldProcessLocally())
            {
                return true;
            }

            Exception thrownException;
            return InvokeShouldMethodAndWaitForResults(cmdlet => cmdlet.ShouldProcess(target, action),
                ShouldMethodType.ShouldProcess, out thrownException);
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
            ThrowIfJobFailedOrCancelled();
            if (CanHandleShouldProcessLocally())
            {
                return true;
            }

            Exception thrownException;
            return InvokeShouldMethodAndWaitForResults(cmdlet => cmdlet.ShouldProcess(verboseDescription, verboseWarning, caption),
                ShouldMethodType.ShouldProcess, out thrownException);
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
            ThrowIfJobFailedOrCancelled();
            if (CanHandleShouldProcessLocally())
            {
                shouldProcessReason = ShouldProcessReason.None;
                return true;
            }

            ShouldProcessReason closureShouldProcessReason = ShouldProcessReason.None;
            Exception thrownException;
            bool result = InvokeShouldMethodAndWaitForResults(cmdlet => cmdlet.ShouldProcess(verboseDescription, verboseWarning, caption, out closureShouldProcessReason),
                ShouldMethodType.ShouldProcess, out thrownException);
            shouldProcessReason = closureShouldProcessReason;
            return result;
        }

        /// <summary>
        /// Throw an error that terminates the current pipeline
        /// </summary>
        /// <param name="errorRecord">The error to throw</param>
        public void ThrowTerminatingError(ErrorRecord errorRecord)
        {
            if (Error.IsOpen)
            {
                Error.Add(errorRecord);
            }
        }

        /// <summary>
        /// Determine if an ambient transaction is available
        /// </summary>
        /// <returns>True if an ambient transaction is available, otherwise false</returns>
        public bool TransactionAvailable()
        {
            ThrowIfJobFailedOrCancelled();
            Exception thrownException;
            return InvokeShouldMethodAndWaitForResults(cmdlet => cmdlet.TransactionAvailable(),
                ShouldMethodType.HasTransaction, out thrownException);
        }

        /// <summary>
        /// Write details about a command
        /// </summary>
        /// <param name="text">The text to write</param>
        public void WriteCommandDetail(string text)
        {
            ThrowIfJobFailedOrCancelled();
            if (Verbose.IsOpen && Verbose.Count < MaxRecords)
            {
                Verbose.Add(new VerboseRecord(text));
            }
        }

        /// <summary>
        /// Write to the debug log
        /// </summary>
        /// <param name="text">The message to write</param>
        public void WriteDebug(string text)
        {
            ThrowIfJobFailedOrCancelled();
            if (Debug.IsOpen && Debug.Count < MaxRecords)
            {
                Debug.Add(new DebugRecord(text));
            }
        }

        /// <summary>
        /// Write to the eeror stream
        /// </summary>
        /// <param name="errorRecord">The error to write</param>
        public void WriteError(ErrorRecord errorRecord)
        {
            ThrowIfJobFailedOrCancelled();
            if (Error.IsOpen)
            {
                Error.Add(errorRecord);
            }
        }

        /// <summary>
        /// Write an output object to the pipeline
        /// </summary>
        /// <param name="sendToPipeline">The putput object</param>
        public void WriteObject(object sendToPipeline)
        {
            ThrowIfJobFailedOrCancelled();
            if (Output.IsOpen)
            {
                Output.Add(new PSObject(sendToPipeline));
            }
        }

        /// <summary>
        /// Write an output object to the pipeline
        /// </summary>
        /// <param name="sendToPipeline">The putput object</param>
        /// <param name="enumerateCollection">If the output object is an enumeration, should each object be written to the pipeline?</param>
        public void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            ThrowIfJobFailedOrCancelled();
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
            ThrowIfJobFailedOrCancelled();
            if (Progress.IsOpen && Progress.Count < MaxRecords)
            {
                Progress.Add(progressRecord);
            }
        }

        /// <summary>
        /// Write information to the progress stream
        /// </summary>
        /// <param name="sourceId">The id of the task source</param>
        /// <param name="progressRecord">The progress info to write</param>
        public void WriteProgress(long sourceId, ProgressRecord progressRecord)
        {
            ThrowIfJobFailedOrCancelled();
            WriteProgress(progressRecord);
        }

        /// <summary>
        /// Write verbose logging information
        /// </summary>
        /// <param name="text">The verbose message to add</param>
        public void WriteVerbose(string text)
        {
            ThrowIfJobFailedOrCancelled();
            if (Verbose.IsOpen && Verbose.Count < MaxRecords)
            {
                Verbose.Add(new VerboseRecord(text));
            }
        }

        /// <summary>
        /// Write a wrning
        /// </summary>
        /// <param name="text">The warning to write</param>
        public void WriteWarning(string text)
        {
            ThrowIfJobFailedOrCancelled();
            if (Warning.IsOpen)
            {
                Warning.Add(new WarningRecord(text));
            }
        }

        /// <summary>
        /// Helper function to check if job is finished
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        internal bool IsFailedOrCancelled(JobState state)
        {
            return (state == JobState.Failed || state == JobState.Stopped || state == JobState.Stopping);
        }

        /// <summary>
        /// Queue actions that must occur on the cmdlet thread, and block the current thread until they are completed
        /// </summary>
        /// <param name="shouldMethod">The action to invoke</param>
        /// <param name="exceptionThrownOnCmdletThread">Any exception that results</param>
        /// <returns>The result of executing the action on the cmdlet thread</returns>
        private bool InvokeShouldMethodAndWaitForResults(Func<Cmdlet, bool> shouldMethod, ShouldMethodType methodType, out Exception exceptionThrownOnCmdletThread)
        {

            bool methodResult = false;
            Exception closureSafeExceptionThrownOnCmdletThread = null;
            object resultsLock = new object();
            using (var gotResultEvent = new ManualResetEventSlim(false))
            {
                EventHandler<JobStateEventArgs> stateChangedEventHandler =
                    delegate (object sender, JobStateEventArgs eventArgs)
                    {
                        WriteDebug(string.Format(Resources.TraceHandleLROStateChange, eventArgs?.PreviousJobStateInfo?.State,
                            eventArgs?.JobStateInfo?.State, eventArgs?.PreviousJobStateInfo?.Reason));
                        if (eventArgs?.JobStateInfo?.State != JobState.Blocked && eventArgs?.PreviousJobStateInfo?.State == JobState.Blocked)
                        {
                            WriteDebug(Resources.TraceHandlerUnblockJob);
                            // if receive-job is called, unblock by executing delayed powershell actions
                            UnblockJob();
                        }

                        if (IsFailedOrCancelled(eventArgs.JobStateInfo.State) || eventArgs.JobStateInfo.State == JobState.Stopping)
                        {
                            WriteDebug(Resources.TraceHandlerUnblockJob);
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
                        WriteDebug(string.Format(Resources.TraceBlockLROThread, methodType));
                        ShouldMethodInvoker methodInvoker = new ShouldMethodInvoker
                        {
                            ShouldMethod = shouldMethod,
                            Finished = gotResultEvent,
                            SyncObject = resultsLock,
                            MethodType = methodType
                        };

                        BlockedActions.Enqueue(new ShouldMethodStreamItem(methodInvoker));
                        if (this.TryBlock())
                        {
                            gotResultEvent.Wait();
                            WriteDebug(string.Format(Resources.TraceUnblockLROThread, shouldMethod));
                            TryStart();
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
                }
                finally
                {
                    WriteDebug(string.Format(Resources.TraceRemoveLROEventHandler,
                        closureSafeExceptionThrownOnCmdletThread?.Message));
                    this.StateChanged -= stateChangedEventHandler;
                }
            }

            lock (resultsLock)
            {
                exceptionThrownOnCmdletThread = closureSafeExceptionThrownOnCmdletThread;
                return methodResult;
            }
        }

        /// <summary>
        /// Stop job execution
        /// </summary>
        public override void StopJob()
        {
            ShouldMethodStreamItem stream;
            while (_actions.TryDequeue(out stream)) ;
            this.Cancel();
        }
    }
}
