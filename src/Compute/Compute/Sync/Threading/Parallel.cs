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

using System;
using System.Collections.Generic;
using System.Threading;

namespace Microsoft.WindowsAzure.Commands.Sync.Threading
{
    internal class Parallel
    {
        public readonly static int MaxParallellism = Environment.ProcessorCount;

        public static LoopResult ForEach<T, TA>(IEnumerable<T> source, Func<TA> argumentConstructor, Action<T, TA> body)
        {
            return ForEach(source, argumentConstructor, body, MaxParallellism);
        }

        public static LoopResult ForEach<T, TA>(IEnumerable<T> source, Func<TA> argumentConstructor, Action<T, TA> body, int parallelism)
        {
            var loopResult = new InternalLoopResult();
            int numProcs = parallelism;
            int remainingWorkItems = numProcs;
            using (var enumerator = source.GetEnumerator())
            {
                using (var mre = new ManualResetEvent(false))
                {
                    // Create each of the work items.
                    for (int p = 0; p < numProcs; p++)
                    {
                        ThreadPool.QueueUserWorkItem(delegate
                                                         {
                                                             try
                                                             {

                                                                 TA argument = argumentConstructor();
                                                                 // Iterate until there's no more work.
                                                                 while (true)
                                                                 {
                                                                     // Get the next item under a lock,
                                                                     // then process that item.
                                                                     T nextItem;
                                                                     lock (enumerator)
                                                                     {
                                                                         if (!enumerator.MoveNext()) break;
                                                                         nextItem = enumerator.Current;
                                                                     }
                                                                     body(nextItem, argument);
                                                                 }
                                                             }
                                                             catch (Exception e)
                                                             {
                                                                 loopResult.AddException(e);
                                                             }
                                                             if (Interlocked.Decrement(ref remainingWorkItems) == 0)
                                                                 mre.Set();
                                                         });
                    }
                    // Wait for all threads to complete.
                    mre.WaitOne();
                    loopResult.SetCompleted();
                }
            }
            return loopResult;
        }

        public static LoopResult ForEach<T>(IEnumerable<T> source, Action<T> body)
        {
            return ForEach(source, body, MaxParallellism);
        }

        public static LoopResult ForEach<T>(IEnumerable<T> source, Action<T> body, int parallelism)
        {
            var loopResult = new InternalLoopResult();
            int numProcs = parallelism;
            int remainingWorkItems = numProcs;
            using (var enumerator = source.GetEnumerator())
            {
                using (var mre = new ManualResetEvent(false))
                {
                    // Create each of the work items.
                    for (int p = 0; p < numProcs; p++)
                    {
                        ThreadPool.QueueUserWorkItem(delegate
                                                         {
                                                             // Iterate until there's no more work.
                                                             try
                                                             {
                                                                 while (true)
                                                                 {
                                                                     // Get the next item under a lock,
                                                                     // then process that item.
                                                                     T nextItem;
                                                                     lock (enumerator)
                                                                     {
                                                                         if (!enumerator.MoveNext()) break;
                                                                         nextItem = enumerator.Current;
                                                                     }
                                                                     body(nextItem);
                                                                 }
                                                             }
                                                             catch (Exception e)
                                                             {
                                                                 loopResult.AddException(e);
                                                             }
                                                             if (Interlocked.Decrement(ref remainingWorkItems) == 0)
                                                                 mre.Set();
                                                         });
                    }
                    // Wait for all threads to complete.
                    mre.WaitOne();
                    loopResult.SetCompleted();
                }
            }
            return loopResult;
        }

        public static LoopResult ForEach<T, TA>(IEnumerable<T> source, Func<TA> argumentConstructor, Action<T, TA> body, Action<TA> finalize, int parallelism)
        {
            var loopResult = new InternalLoopResult();
            int numProcs = parallelism;
            int remainingWorkItems = numProcs;

            IList<TA> arguments = new List<TA>();
            using (var enumerator = source.GetEnumerator())
            {
                using (var mre = new ManualResetEvent(false))
                {
                    // Create each of the work items.
                    for (int p = 0; p < numProcs; p++)
                    {
                        ThreadPool.QueueUserWorkItem(delegate
                        {
                            try
                            {
                                TA argument = argumentConstructor();
                                lock (arguments)
                                {
                                    arguments.Add(argument);
                                }
                                // Iterate until there's no more work.
                                while (true && !loopResult.IsExceptional)
                                {
                                    // Get the next item under a lock,
                                    // then process that item.
                                    T nextItem;
                                    lock (enumerator)
                                    {
                                        if (!enumerator.MoveNext()) break;
                                        nextItem = enumerator.Current;
                                    }
                                    body(nextItem, argument);
                                }
                            }
                            catch (Exception e)
                            {
                                loopResult.AddException(e);
                            }
                            if (Interlocked.Decrement(ref remainingWorkItems) == 0)
                                mre.Set();
                        });
                    }
                    // Wait for all threads to complete.
                    mre.WaitOne();

                    foreach (var argument in arguments)
                    {
                        finalize(argument);
                    }

                    loopResult.SetCompleted();
                }
            }
            return loopResult;
        }

        private class InternalLoopResult : LoopResult
        {
            private IList<Exception> exceptions;
            private object lockObject = new object();

            public InternalLoopResult()
            {
                this.exceptions = new List<Exception>();
            }

            public override bool IsCompleted
            {
                get; protected set;
            }

            public override IList<Exception> Exceptions
            {
                get { return new List<Exception>(exceptions); }
            }

            public override bool IsExceptional
            {
                get
                {
                    lock (lockObject)
                    {
                        return this.exceptions.Count > 0;
                    }
                }
            }

            public void SetCompleted()
            {
                this.IsCompleted = true;
            }

            public void AddException(Exception exception)
            {
                lock (lockObject)
                {
                    this.exceptions.Add(exception);
                }
            }
        }
    }

    public abstract class LoopResult
    {
        public abstract bool IsCompleted { get; protected set; }
        public abstract IList<Exception> Exceptions { get; }
        public abstract bool IsExceptional { get; }
    }
}