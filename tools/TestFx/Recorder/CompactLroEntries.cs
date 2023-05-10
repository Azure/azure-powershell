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

namespace Microsoft.Azure.Commands.TestFx.Recorder
{
    public class CompactLroEntries
    {
        private readonly Queue<RecordEntry> _entryPackCloneQueue;
        private readonly Stack<RecordEntry> _lroStack;

        RecordEntryPack _processedEntryPack;

        public CompactLroEntries()
        {
            _entryPackCloneQueue = new Queue<RecordEntry>();
            _lroStack = new Stack<RecordEntry>();
        }

        public string ProcessorName { get => "CompactLroEntries"; protected set => ProcessorName = value; }

        public RecordEntryPack ProcessedEntryPack
        {
            get
            {
                if (_processedEntryPack == null)
                {
                    _processedEntryPack = new RecordEntryPack();
                }

                return _processedEntryPack;
            }
        }

        public void Process(RecordEntryPack recordEntryPack)
        {
            foreach (RecordEntry rec in recordEntryPack.Entries)
            {
                if (IsLroEntry(rec))
                {
                    _lroStack.Push(rec);
                }
                else
                {
                    if (_lroStack.Any())
                    {
                        UpdateCloneQueueFromStack();
                    }

                    _entryPackCloneQueue.Enqueue(rec);
                }
            }

            if (_lroStack.Any())
            {
                UpdateCloneQueueFromStack();
            }

            if (_entryPackCloneQueue.Any())
            {
                ProcessedEntryPack.Entries = _entryPackCloneQueue.ToList();
            }
        }

        private void UpdateCloneQueueFromStack()
        {
            int takeLastCount = 2;
            if (_lroStack.Any())
            {
                Stack<RecordEntry> tempStack = new Stack<RecordEntry>();
                int popCount = 1;

                while (_lroStack.Count > 0)
                {
                    if (popCount <= takeLastCount)
                    {
                        tempStack.Push(_lroStack.Pop());
                        popCount++;
                    }
                    else
                    {
                        _lroStack.Clear();
                        break;
                    }
                }

                while (tempStack.Count > 0)
                {
                    _entryPackCloneQueue.Enqueue(tempStack.Pop());
                }
            }
        }

        internal bool IsLroEntry(RecordEntry re)
        {
            return re.RequestHeaders.ContainsKey("RecordPlaybackPerfImpact");
        }
    }

    public interface IRecordingProcessor
    {
        string ProcessorName { get; }

        void Process(RecordEntryPack recordEntryPack);

        RecordEntryPack ProcessedEntryPack { get; }
    }
}
