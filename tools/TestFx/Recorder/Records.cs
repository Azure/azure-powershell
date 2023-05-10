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
using System.Linq;
using System.Runtime.CompilerServices;

namespace Microsoft.Azure.Commands.TestFx.Recorder
{
    public class Records
    {
        private readonly Dictionary<string, Queue<RecordEntry>> _sessionRecords;

        private readonly IRecordMatcher _matcher;

        public Records(IRecordMatcher matcher) : this(new Dictionary<string, Queue<RecordEntry>>(), matcher)
        {

        }

        public Records(Dictionary<string, Queue<RecordEntry>> records, IRecordMatcher matcher)
        {
            _sessionRecords = new Dictionary<string, Queue<RecordEntry>>(records);
            _matcher = matcher;
        }

        public void Enqueue(RecordEntry record)
        {
            string recordKey = _matcher.GetMatchingKey(record);
            if (!_sessionRecords.ContainsKey(recordKey))
            {
                _sessionRecords[recordKey] = new Queue<RecordEntry>();
            }
            _sessionRecords[recordKey].Enqueue(record);
        }

        public Queue<RecordEntry> this[string key]
        {
            get
            {
                if (!_sessionRecords.ContainsKey(key))
                    throw new KeyNotFoundException($"Unable to find a matching HTTP request for URL '{RecorderUtilities.DecodeBase64AsUri(key)}'. Calling method {GetCallingMethodName()}().");

                return _sessionRecords[key];
            }
            set { _sessionRecords[key] = value; }
        }

        private string GetCallingMethodName([CallerMemberName]string methodName="Getting_CallingMethodName_Failed_Your_Test_Will_Fail")
        {
            return methodName;
        }

        public IEnumerable<RecordEntry> GetAllEntities()
        {
            foreach (var queues in _sessionRecords.Values)
            {
                while (queues.Count > 0)
                {
                    yield return queues.Dequeue();
                }
            }
        }

        public int Count
        {
            get { return _sessionRecords.Values.Select(q => q.Count).Sum(); }
        }

        public void EnqueueRange(List<RecordEntry> records)
        {
            foreach (RecordEntry recordEntry in records)
            {
                Enqueue(recordEntry);
            }
        }
    }
}
