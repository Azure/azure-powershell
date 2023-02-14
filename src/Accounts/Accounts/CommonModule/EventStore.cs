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

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Common;

namespace Microsoft.Azure.Commands.Profile.CommonModule
{
    public class EventStore : IEventStore
    {
        ConcurrentQueue<EventData> _store = new ConcurrentQueue<EventData>();
        public void AddEvent(EventData data)
        {
            _store.CheckAndEnqueue(data);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public IEnumerator<EventData> GetEnumerator()
        {
            return _store?.GetEnumerator();
        }

        public bool TryGetEvent(out EventData data)
        {
            return _store.TryDequeueIfNotNull(out data);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _store?.GetEnumerator();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                EventData data;
                while (_store.TryDequeueIfNotNull(out data));
                _store = null;
            }
        }
    }
}
