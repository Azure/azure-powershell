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

namespace Microsoft.Azure.Commands.Common.Strategies
{
    /// <summary>
    /// The map keeps information about relation between a task progress and a progress of all tasks.
    /// </summary>
    class ProgressMap
    {
        readonly Dictionary<IResourceConfig, Tuple<TimeSlot, int>> _Map 
            = new Dictionary<IResourceConfig, Tuple<TimeSlot, int>>();

        /// <summary>
        /// duration of all tasks (in seconds).
        /// </summary>
        public int Duration { get; }

        /// <summary>
        /// Constructs ProgressMap
        /// </summary>
        /// <param name="map">a map between a resource config and a time slot and task duration.</param>
        /// <param name="duration">a duration of all tasks</param>
        public ProgressMap(Dictionary<IResourceConfig, Tuple<TimeSlot, int>> map, int duration)
        {
            _Map = map;
            Duration = duration;
        }

        /// <summary>
        /// Returns TimeSlon and a duration of a task related to the given config.
        /// </summary>
        /// <param name="config">a resource config</param>
        /// <returns></returns>
        public Tuple<TimeSlot, int> Get(IResourceConfig config)
            => _Map.GetOrNull(config);
    }
}
