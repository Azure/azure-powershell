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
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites
{
    public class LogStreamWaitHandle : IDisposable
    {
        private const int WaitInterval = 1000;
        Stream stream;
        List<string> lines;
        Semaphore sem;
        ManualResetEvent readCompleted = new ManualResetEvent(false);

        /// <summary>
        /// Parameterless constructor for mocking.
        /// </summary>
        public LogStreamWaitHandle()
        {

        }

        public LogStreamWaitHandle(Stream stream)
        {
            this.stream = stream;
            this.lines = new List<string>();
            this.sem = new Semaphore(0, Int32.MaxValue);
            object thisLock = new Object();
            Task.Factory.StartNew(() =>
            {
                try
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        bool initial = true;
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            if (line != null)
                            {
                                if (initial)
                                {
                                    // accommodate for gap between first welcome and event hookup
                                    Thread.Sleep(WaitInterval);
                                    initial = false;
                                }

                                lock (thisLock)
                                {
                                    lines.Add(line);
                                    this.sem.Release();
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
                finally
                {
                    lock (thisLock)
                    {
                        lines.Add(null);
                        this.sem.Release();
                    }

                    readCompleted.Set();
                }
            });
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.stream.Close();
                this.readCompleted.WaitOne(WaitInterval);
                this.readCompleted.Dispose();
                this.sem.Dispose();
            }
        }

        public virtual string WaitNextLine(int millisecs)
        {
            try
            {
                if (this.sem.WaitOne(millisecs))
                {
                    lock (lines)
                    {
                        string result = lines[0];
                        lines.RemoveAt(0);
                        return result;
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                // This handle in case we are racing with Dispose call
            }

            return null;
        }
    }
}
