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

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Management.Automation;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Task output stream in multithread environment
    /// It's the multithread version of WriteOuput/WriterVerbose/WriteError and etc.
    /// </summary>
    internal class TaskOutputStream
    {
        /// <summary>
        /// Ouput Stream which store all the output from sub-thread.
        /// Both the object and exception are the valid output.
        /// Key: Output id
        /// Value: OutputUnit object which store the output data
        /// It's thread safe to access the value even it's a Queue.
        /// Don't use ConcurrentQueue for value since it'll cause a huge perfomance downgrade.
        /// </summary>
        private ConcurrentDictionary<long, Queue<OutputUnit>> OutputStream;

        /// <summary>
        /// Current output id
        /// </summary>
        private long CurrentOutputId;

        /// <summary>
        /// Main thread output writer. WriteObject is a good candidate for it.
        /// </summary>
        public Action<object> OutputWriter;

        /// <summary>
        /// Main thread error writer. WriteError is a goog candidate for it.
        /// </summary>
        public Action<Exception> ErrorWriter;

        public Action<string> VerboseWriter;

        public Action<ProgressRecord> ProgressWriter;

        public Action<string> DebugWriter;

        public Func<string, string, string, bool> ConfirmWriter;

        public Func<long, bool> TaskStatusQueryer;

        /// <summary>
        /// is progress bard disabled
        /// </summary>
        private bool isProgressDisabled = false;

        /// <summary>
        /// Progress bar is harm for performance.
        /// </summary>
        public bool DisableProgressBar
        {
            get
            {
                return isProgressDisabled;
            }
            set
            {
                isProgressDisabled = value;
            }
        }

        /// <summary>
        /// The operation that should be confirmed by user.
        /// </summary>
        private Lazy<ConcurrentQueue<ConfirmTaskCompletionSource>> ConfirmQueue;

        private ConcurrentQueue<string> DebugMessages;


        private int DefaultProgressCount = 4;
        private ConcurrentDictionary<int, ProgressRecord> Progress;

        private CancellationToken cancellationToken;

        /// <summary>
        /// Confirmation lock
        /// </summary>
        private object confirmTaskLock = new object();

        /// <summary>
        /// Current ConfirmTaskCompletionSource
        /// </summary>
        private ConfirmTaskCompletionSource currentTaskSource = null;

        /// <summary>
        /// Create an Task output stream
        /// </summary>
        public TaskOutputStream(CancellationToken token)
        {
            OutputStream = new ConcurrentDictionary<long, Queue<OutputUnit>>();
            CurrentOutputId = 0;
            ConfirmQueue = new Lazy<ConcurrentQueue<ConfirmTaskCompletionSource>>(
                () => new ConcurrentQueue<ConfirmTaskCompletionSource>(), true);
            DebugMessages = new ConcurrentQueue<string>();
            Progress = new ConcurrentDictionary<int, ProgressRecord>();
            cancellationToken = token;
        }

        /// <summary>
        /// Write output unit into OutputStream
        /// </summary>
        /// <param name="id">Output id</param>
        /// <param name="unit">Output unit</param>
        private void WriteOutputUnit(long id, OutputUnit unit)
        {
            //It's thread for the specified id
            Queue<OutputUnit> outputQueue = null;
            bool found = OutputStream.TryGetValue(id, out outputQueue);
            if (!found || outputQueue == null)
            {
                outputQueue = new Queue<OutputUnit>();
                OutputStream.TryAdd(id, outputQueue);
            }

            outputQueue.Enqueue(unit);
        }

        /// <summary>
        /// Write object into OutputStream
        /// </summary>
        /// <param name="taskId">Output id</param>
        /// <param name="data">Output data</param>
        public void WriteObject(long taskId, object data)
        {
            OutputUnit unit = new OutputUnit(data, OutputType.Object);
            WriteOutputUnit(taskId, unit);
        }

        /// <summary>
        /// Write error into OutputStream
        /// </summary>
        /// <param name="taskId">Output id</param>
        /// <param name="e">Exception object</param>
        public void WriteError(long taskId, Exception e)
        {
            OutputUnit unit = new OutputUnit(e, OutputType.Error);
            WriteOutputUnit(taskId, unit);
        }

        /// <summary>
        /// Write verbose into output stream
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="message">Verbose message</param>
        public void WriteVerbose(long taskId, string message)
        {
            OutputUnit unit = new OutputUnit(message, OutputType.Verbose);
            WriteOutputUnit(taskId, unit);
        }

        /// <summary>
        /// Write progress into the output stream
        /// </summary>
        /// <param name="record">Progress record</param>
        public void WriteProgress(ProgressRecord record)
        {
            if (isProgressDisabled)
            {
                return;
            }

            int activityId = record.ActivityId; //Activity 0 is reserved for summary
            Progress.AddOrUpdate(activityId, record, (id, oldRecord) =>
            {
                return record;
            });
        }

        public int GetProgressId(long taskId)
        {
            return (int)taskId % DefaultProgressCount + 1;
        }

        /// <summary>
        /// Write debug message into the output stream.
        /// </summary>
        /// <param name="message">Debug message</param>
        public void WriteDebug(string message)
        {
            DebugMessages.Enqueue(message);
        }

        /// <summary>
        /// Is the specified task done
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <returns>True if the task is done, otherwise false</returns>
        private bool IsTaskDone(long taskId)
        {
            if (TaskStatusQueryer == null)
            {
                return true;
            }
            else
            {
                return TaskStatusQueryer(taskId);
            }
        }

        /// <summary>
        /// Async confirmation.
        /// *****Please note*****
        /// Dead lock will happen if the main thread is blocked.
        /// </summary>
        /// <param name="message">Confirm message</param>
        public Task<bool> ConfirmAsync(string message)
        {
            ConfirmTaskCompletionSource tcs = new ConfirmTaskCompletionSource(message);
            ConfirmQueue.Value.Enqueue(tcs);
            return tcs.Task;
        }

        /// <summary>
        /// Confirm the request
        /// </summary>
        /// <param name="tcs">Confirm task completion source</param>
        internal void ConfirmRequest(ConfirmTaskCompletionSource tcs)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                tcs.SetCanceled();
            }

            lock (confirmTaskLock)
            {
                currentTaskSource = tcs;
            }

            try
            {
                bool result = ConfirmWriter(string.Empty, tcs.Message, Resources.ConfirmCaption);
                tcs.SetResult(result);
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }

            lock (confirmTaskLock)
            {
                currentTaskSource = null;
            }
        }

        /// <summary>
        /// Cancel the confirmation request
        /// </summary>
        public void CancelConfirmRequest()
        {
            ConfirmTaskCompletionSource tcs = null;

            while (ConfirmQueue.Value.TryDequeue(out tcs))
            {
                tcs.SetCanceled();
            }

            lock (confirmTaskLock)
            {
                if (currentTaskSource != null)
                {
                    currentTaskSource.SetCanceled();
                }

                currentTaskSource = null;
            }
        }

        /// <summary>
        /// Process all the confirmation request
        /// </summary>
        protected void ProcessConfirmRequest()
        {
            if (ConfirmQueue.IsValueCreated)
            {
                ConfirmTaskCompletionSource tcs = null;
                while (ConfirmQueue.Value.TryDequeue(out tcs))
                {
                    ConfirmRequest(tcs);
                }
            }
        }

        /// <summary>
        /// Process all the debug messages
        /// </summary>
        protected void ProcessDebugMessages()
        {
            ProcessUnorderedOutputStream<string>(DebugMessages, DebugWriter);
        }

        /// <summary>
        /// Process all the progress information.
        /// </summary>
        protected void ProcessProgress()
        {
            ProgressRecord record = null;
            bool removed = false;

            for (var i = 0; i < DefaultProgressCount; i++)
            {
                removed = Progress.TryRemove(i + 1, out record);
                if (removed && record != null)
                {
                    if (isProgressDisabled)
                    {
                        //Close the progress bar
                        record.RecordType = ProgressRecordType.Completed;
                    }

                    ProgressWriter(record);
                }
            }
        }

        /// <summary>
        /// Process all the data without any predefined order.
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="data">Data queue</param>
        /// <param name="Writer">Output writer</param>
        protected void ProcessUnorderedOutputStream<T>(ConcurrentQueue<T> data, Action<T> Writer)
        {
            int count = data.Count;
            T message = default(T);
            bool removed = false;

            while (count > 0)
            {
                removed = data.TryDequeue(out message);
                count--;

                if (removed)
                {
                    try
                    {
                        Writer(message);
                    }
                    catch (Exception e)
                    {
                        Debug.Fail(e.Message);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Process all the data output
        /// </summary>
        protected void ProcessDataOutput()
        {
            Queue<OutputUnit> outputQueue = null;
            bool removed = false;
            bool taskDone = false;

            do
            {
                taskDone = IsTaskDone(CurrentOutputId);

                if (taskDone)
                {
                    removed = OutputStream.TryRemove(CurrentOutputId, out outputQueue);

                    if (removed && outputQueue != null)
                    {
                        try
                        {
                            foreach (OutputUnit unit in outputQueue)
                            {
                                switch (unit.Type)
                                {
                                    case OutputType.Object:
                                        OutputWriter(unit.Data);
                                        break;
                                    case OutputType.Error:
                                        ErrorWriter(unit.Data as Exception);
                                        break;
                                    case OutputType.Verbose:
                                        VerboseWriter(unit.Data as string);
                                        break;
                                }
                            }
                        }
                        catch (PipelineStoppedException)
                        {
                            //Directly stop the output stream when throw an exception.
                            //If so, we could quickly response for ctrl + c and etc.
                            break;
                        }
                        catch (Exception e)
                        {
                            Debug.Fail(String.Format("{0}", e));
                            break;
                        }
                    }

                    CurrentOutputId++;
                }   //Otherwise wait for the task completion
            }
            while (taskDone);//We could skip checking the cancellationToken
                             //since the inner loop would throw an exception when it's cancelled.
        }

        /// <summary>
        /// Output data into main thread
        /// There is no concurrent call on this method since it should be only called in main thread of the powershell instance.
        /// </summary>
        public void Output()
        {
            ProcessConfirmRequest();
            ProcessDebugMessages();
            ProcessProgress();
            ProcessDataOutput();
        }

        /// <summary>
        /// Output type
        /// </summary>
        private enum OutputType
        {
            Object,
            Error,
            Verbose
        };

        /// <summary>
        /// Output unit
        /// </summary>
        private class OutputUnit
        {
            /// <summary>
            /// Output type
            /// </summary>
            public OutputType Type;

            /// <summary>
            /// Output list
            /// All the output unit which has the same output key will be merged in the OutputStream
            /// </summary>
            public object Data;

            /// <summary>
            /// Create an OutputUnit
            /// </summary>
            /// <param name="type">Output type</param>
            /// <param name="data">Output data</param>
            public OutputUnit(object data, OutputType type)
            {
                Data = data;
                Type = type;
            }
        }
    }
}
