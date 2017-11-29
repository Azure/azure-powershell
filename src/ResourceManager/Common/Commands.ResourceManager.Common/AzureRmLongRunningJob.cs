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
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Management.Automation.Remoting;
using System.Management.Automation.Remoting.Internal;
using System.Reflection;
using System.Threading;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class AzureRmLongRunningJob : Job, ICommandRuntime
    {
        string _status = "Running";
        AzurePSCmdlet _cmdlet;
        ICommandRuntime _runtime;
        ConcurrentQueue<PSStreamObject> _actions = new ConcurrentQueue<PSStreamObject>();
        bool _shouldConfirm = false;

        /// <summary>
        /// Create a job using the given invoked cmdlet, command name, and task name
        /// </summary>
        /// <param name="cmdlet">The cmdlet to run asynchronously</param>
        /// <param name="command">The name of the command</param>
        /// <param name="name">The name of the task</param>
        protected AzureRmLongRunningJob(AzurePSCmdlet cmdlet, string command, string name) : base(command, name)
        {
            _cmdlet = CopyCmdlet(cmdlet);
            _shouldConfirm = ShouldConfirm(cmdlet);
            _cmdlet.CommandRuntime = this.GetJobRuntime();
            _runtime = cmdlet.CommandRuntime;
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
        protected ConcurrentQueue<PSStreamObject> BlockedActions { get { return _actions; } }

        /// <summary>
        /// Factory method for creating jobs
        /// </summary>
        /// <param name="cmdlet">The invoked cmdlet to run as a job</param>
        /// <param name="command">The name of the command executed</param>
        /// <param name="name">The name of the task</param>
        /// <returns>A job racking the background execution of the cmdlet</returns>
        public static AzureRmLongRunningJob Create(AzurePSCmdlet cmdlet, string command, string name)
        {
            var job = new Common.AzureRmLongRunningJob(cmdlet, command, name);
            return job;
        }

        /// <summary>
        /// Copy the unique properties of a cmdlet - used to capture the properties of a cmdlet during pipeline execution
        /// </summary>
        /// <param name="cmdlet">The cmdlet</param>
        /// <returns>A deep copy fo the cmdlet</returns>
        public static AzurePSCmdlet CopyCmdlet(AzurePSCmdlet cmdlet)
        {
            var returnType = cmdlet.GetType();
            var returnValue = Activator.CreateInstance(cmdlet.GetType());
            foreach (var property in returnType.GetProperties())
            {
                if (property.CanWrite && property.CanRead)
                {
                    property.SetValue(returnValue, property.GetValue(cmdlet));
                }
            }

            return returnValue as AzurePSCmdlet;
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
                _cmdlet.ExecuteCmdlet();
                Complete();
            }
            catch (Exception ex)
            {
                Error.Add(new ErrorRecord(ex, ex.Message, ErrorCategory.InvalidOperation, this));
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
            PSStreamObject stream;
            while (_actions.TryDequeue(out stream))
            {
                stream.WriteStreamObject(executor);
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
            return InvokeCmdletMethodAndWaitForResults(cmdlet => cmdlet.ShouldContinue(query, caption), out thrownException);
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
            bool result = InvokeCmdletMethodAndWaitForResults(cmdlet => cmdlet.ShouldContinue(query, caption,
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
            ConfirmImpact confirmPreference = ConfirmImpact.Medium;
            ConfirmImpact cmdletImpact = ConfirmImpact.Medium;
            var confirmVar = SafeGetVariableValue(cmdlet, "ConfirmPreference", "Medium");
            if (!string.IsNullOrEmpty(confirmVar))
            {
                Enum.TryParse(confirmVar, out confirmPreference);
            }

            var attribute = cmdlet.GetType().GetTypeInfo().GetCustomAttribute<CmdletAttribute>(true);
            if (attribute != null)
            {
                cmdletImpact = attribute.ConfirmImpact;
            }

            return cmdletImpact > confirmPreference;
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
            return InvokeCmdletMethodAndWaitForResults(cmdlet => cmdlet.ShouldProcess(target), out thrownException);
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
            return InvokeCmdletMethodAndWaitForResults(cmdlet => cmdlet.ShouldProcess(target, action), out thrownException);
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
            return InvokeCmdletMethodAndWaitForResults(cmdlet => cmdlet.ShouldProcess(verboseDescription, verboseWarning, caption),
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
            bool result = InvokeCmdletMethodAndWaitForResults(cmdlet => cmdlet.ShouldProcess(verboseDescription, verboseWarning, caption, out closureShouldProcessReason),
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
            return InvokeCmdletMethodAndWaitForResults(cmdlet => cmdlet.TransactionAvailable(),
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
        internal bool IsTerminalState(JobState state)
        {
            return (state == JobState.Completed || state == JobState.Failed || state == JobState.Stopped);
        }

        /// <summary>
        /// Queue actions that must occur on the cmdlet thread, and block the current thread until they are completed
        /// </summary>
        /// <typeparam name="T">The output type of the called cmdlet action</typeparam>
        /// <param name="invokeCmdletMethodAndReturnResult">The action to invoke</param>
        /// <param name="exceptionThrownOnCmdletThread">Any exception that results</param>
        /// <returns>The result of executing the action on the cmdlet thread</returns>
        private T InvokeCmdletMethodAndWaitForResults<T>(Func<Cmdlet, T> invokeCmdletMethodAndReturnResult, out Exception exceptionThrownOnCmdletThread)
        {

            T methodResult = default(T);
            Exception closureSafeExceptionThrownOnCmdletThread = null;
            object resultsLock = new object();
            using (var gotResultEvent = new ManualResetEventSlim(false))
            {
                EventHandler<JobStateEventArgs> stateChangedEventHandler =
                    delegate (object sender, JobStateEventArgs eventArgs)
                    {
                        if (IsTerminalState(eventArgs.JobStateInfo.State) || eventArgs.JobStateInfo.State == JobState.Stopping)
                        {
                            lock (resultsLock)
                            {
                                closureSafeExceptionThrownOnCmdletThread = new OperationCanceledException();
                            }
                            gotResultEvent.Set();
                        }
                        else if (eventArgs?.JobStateInfo?.State == JobState.Running && eventArgs?.PreviousJobStateInfo?.State == JobState.Blocked)
                        {
                            // if receive-job is called, unblock by executing delayed powershell actions
                            UnblockJob();
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
                        // addition to results column happens here
                        CmdletMethodInvoker<T> methodInvoker = new CmdletMethodInvoker<T>
                        {
                            Action = invokeCmdletMethodAndReturnResult,
                            Finished = gotResultEvent,
                            SyncObject = resultsLock
                        };
                        PSStreamObjectType objectType = PSStreamObjectType.ShouldMethod;
                        if (typeof(T) == typeof(object))
                        {
                            objectType = PSStreamObjectType.BlockingError;
                        }

                        BlockedActions.Enqueue(new PSStreamObject(objectType, methodInvoker));
                        gotResultEvent.Wait();
                        this.Start();

                        lock (resultsLock)
                        {
                            if (closureSafeExceptionThrownOnCmdletThread == null) // stateChangedEventHandler didn't set the results?  = ok to clobber results?
                            {
                                closureSafeExceptionThrownOnCmdletThread = methodInvoker.ExceptionThrownOnCmdletThread;
                                methodResult = methodInvoker.MethodResult;
                            }
                        }
                    }
                }
                finally
                {
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
            throw new NotImplementedException();
        }
    }
}
