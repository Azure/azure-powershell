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

using Microsoft.Azure.Commands.Common;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Profile.CommonModule
{
    /// <summary>
    /// Implements a FIFO store of events
    /// </summary>
    public interface IEventStore : IEnumerable<EventData>, IDisposable
    {
        /// <summary>
        /// Add an event to the store
        /// </summary>
        /// <param name="data"></param>
        void AddEvent(EventData data);

        /// <summary>
        /// Try to get the next event from the store
        /// </summary>
        /// <param name="data">The next event in the store</param>
        /// <returns>True if there is an event remainign in the store, otherwise false</returns>
        bool TryGetEvent(out EventData data);
    }
}
