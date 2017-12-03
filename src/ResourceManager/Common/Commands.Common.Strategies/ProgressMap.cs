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
    public class ProgressMap
    {
        readonly Dictionary<IResourceConfig, Tuple<TimeSlot, int>> _Map 
            = new Dictionary<IResourceConfig, Tuple<TimeSlot, int>>();

        readonly int _Duration;

        public ProgressMap(Dictionary<IResourceConfig, Tuple<TimeSlot, int>> map, int duration)
        {
            _Map = map;
            _Duration = duration;
        }

        public double Get(IResourceConfig config)
        {
            var x = _Map.GetOrNull(config);
            return x.Item1.GetTaskProgress(x.Item2) / _Duration;
        }
    }
}
