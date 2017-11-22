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
        protected AzureRmLongRunningJob(AzurePSCmdlet cmdlet, string command, string name) : base(command, name)
        {
            _cmdlet = CopyCmdlet(cmdlet);
            _shouldConfirm = ShouldConfirm(cmdlet);
            _cmdlet.CommandRuntime = this.GetJobRuntime();
            _runtime = cmdlet.CommandRuntime;
            this.PSJobTypeName = this.GetType().Name;
        }

        public override bool HasMoreData
        {
            get { return Output.Any() || Progress.Any() || Error.Any() || Warning.Any() || Verbose.Any() || Debug.Any(); }
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

        protected ConcurrentQueue<PSStreamObject> BlockedActions { get { return _actions; } }
        public static AzureRmLongRunningJob Create(AzurePSCmdlet cmdlet, string command, string name)
        {
            var job = new Common.AzureRmLongRunningJob(cmdlet, command, name);
            return job;
        }


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
            catch (Exception)
            {
                Fail();
            }
        }



        public virtual ICommandRuntime GetJobRuntime()
        {
            return this as ICommandRuntime;
        }

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

        public override void StopJob()
        {
            SetJobState(JobState.Stopped);
        }

        public void Start()
        {
            _status = "Running";
            SetJobState(JobState.Running);
        }

        public void Block()
        {
            _status = "Blocked";
            SetJobState(JobState.Blocked);
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

        // Members for implementing command runtime for this jon
        public PSTransactionContext CurrentPSTransaction
        {
            get
            {
                return _runtime.CurrentPSTransaction;
            }
        }

        public PSHost Host
        {
            get
            {
                return _runtime.Host;
            }
        }

        public bool ShouldContinue(string query, string caption)
        {
            Exception thrownException;
            return InvokeCmdletMethodAndWaitForResults(cmdlet => cmdlet.ShouldContinue(query, caption), out thrownException);
        }

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

        static bool ShouldConfirm(AzurePSCmdlet cmdlet)
        {
            ConfirmImpact confirmPreference = ConfirmImpact.Medium;
            ConfirmImpact cmdletImpact = ConfirmImpact.Medium;
            var confirmVar = cmdlet.GetVariableValue("ConfirmPreference", "Medium") as string;
            if (!string.IsNullOrEmpty(confirmVar))
            {
                Enum.TryParse(cmdlet.GetVariableValue("ConfirmPreference", "Medium") as string, out confirmPreference);
            }

            var attribute = cmdlet.GetType().GetTypeInfo().GetCustomAttribute<CmdletAttribute>(true);
            if (attribute != null)
            {
                cmdletImpact = attribute.ConfirmImpact;
            }

            return cmdletImpact > confirmPreference;
        }

        bool CanHandleShouldProcessLocally()
        {
            return !(_cmdlet.MyInvocation.BoundParameters.ContainsKey("Confirm") && (bool)_cmdlet.MyInvocation.BoundParameters["Confirm"]) &&
                !(_cmdlet.MyInvocation.BoundParameters.ContainsKey("WhatIf") && (bool)_cmdlet.MyInvocation.BoundParameters["WhatIf"]) &&
                !_shouldConfirm;
        }

        public bool ShouldProcess(string target)
        {
            if (CanHandleShouldProcessLocally())
            {
                return true;
            }

            Exception thrownException;
            return InvokeCmdletMethodAndWaitForResults(cmdlet => cmdlet.ShouldProcess(target), out thrownException);
        }

        public bool ShouldProcess(string target, string action)
        {
            if (CanHandleShouldProcessLocally())
            {
                return true;
            }

            Exception thrownException;
            return InvokeCmdletMethodAndWaitForResults(cmdlet => cmdlet.ShouldProcess(target, action), out thrownException);
        }

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

        public void ThrowTerminatingError(ErrorRecord errorRecord)
        {
            Error.Add(errorRecord);
        }

        public bool TransactionAvailable()
        {
            Exception thrownException;
            return InvokeCmdletMethodAndWaitForResults(cmdlet => cmdlet.TransactionAvailable(),
                out thrownException);
        }

        public void WriteCommandDetail(string text)
        {
            Verbose.Add(new VerboseRecord(text));
        }

        public void WriteDebug(string text)
        {
            Debug.Add(new DebugRecord(text));
        }

        public void WriteError(ErrorRecord errorRecord)
        {
            Error.Add(errorRecord);
        }

        public void WriteObject(object sendToPipeline)
        {
            Output.Add(new PSObject(sendToPipeline));
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
            Progress.Add(progressRecord);
        }

        public void WriteProgress(long sourceId, ProgressRecord progressRecord)
        {
            WriteProgress(progressRecord);
        }

        public void WriteVerbose(string text)
        {
            Verbose.Add(new VerboseRecord(text));
        }

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

    }
}
