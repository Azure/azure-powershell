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

using System.Collections.Generic;
using System.Globalization;
using Microsoft.WindowsAzure.Management.HDInsight.Logging;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Logging
{
    internal class PowershellLogWriter : IBufferingLogWriter
    {
        private readonly List<string> buffer = new List<string>();
        private readonly Queue<string> messageLines = new Queue<string>();

        public IEnumerable<string> Buffer
        {
            get { return this.buffer; }
        }

        public IEnumerable<string> DequeueBuffer()
        {
            var results = new List<string>();
            lock (this.messageLines)
            {
                while (this.messageLines.Count > 0)
                {
                    results.Add(this.messageLines.Dequeue());
                }
            }
            return results;
        }

        public void Log(Severity severity, Verbosity verbosity, string content)
        {
            string msg = string.Format(CultureInfo.InvariantCulture, "Severity: {0}\r\n{1}", severity, content);
            this.Write(msg);
        }

        protected void Write(string content)
        {
            lock (this.messageLines)
            {
                this.messageLines.Enqueue(content);
                this.buffer.Add(content);
            }
        }
    }
}
