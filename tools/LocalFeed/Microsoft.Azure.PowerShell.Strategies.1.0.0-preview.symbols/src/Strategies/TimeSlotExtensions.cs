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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    static class TimeSlotExtensions
    {
        public static ProgressMap GetProgressMap<TModel>(
            this ResourceConfig<TModel> config, IState state)
            where TModel : class
        {
            var context = new Context(state);
            var duration = context.GetTimeSlotAndDuration(config).Item2;
            return new ProgressMap(context.BeginMap, duration);
        }            

        sealed class Context
        {
            public TimeSlot Begin { get; } = new TimeSlot();

            public Dictionary<IResourceConfig, Tuple<TimeSlot, int>> BeginMap { get; }
                = new Dictionary<IResourceConfig, Tuple<TimeSlot, int>>();

            readonly IState _State;

            readonly ConcurrentDictionary<IResourceConfig, Tuple<TimeSlot, int>> _Map
                = new ConcurrentDictionary<IResourceConfig, Tuple<TimeSlot, int>>();

            public Context(IState state)
            {
                _State = state;
            }

            public Tuple<TimeSlot, int> GetTimeSlotAndDuration<TModel>(
                ResourceConfig<TModel> config)
                where TModel : class
                => _Map.GetOrAdd(
                    config,
                    _ =>
                    {
                        var tupleBegin = config
                            .GetTargetDependencies(_State)
                            .Select(GetTimeSlotAndDurationDispatch)
                            .Aggregate(Tuple.Create(Begin, 0), (a, b) => a.Item2 > b.Item2 ? a : b);
                        var duration = config.Strategy.CreateTime(_State.Get(config));
                        BeginMap.Add(config, Tuple.Create(tupleBegin.Item1, duration));
                        return Tuple.Create(
                            tupleBegin.Item1.AddTask(duration), tupleBegin.Item2 + duration);
                    });

            Tuple<TimeSlot, int> GetTimeSlotAndDurationDispatch(IResourceConfig config)
                => config.Accept(new GetTimeSlotAndDurationVisitor(), this);
        }

        sealed class GetTimeSlotAndDurationVisitor :
            IResourceConfigVisitor<Context, Tuple<TimeSlot, int>>
        {
            public Tuple<TimeSlot, int> Visit<TModel>(
                ResourceConfig<TModel> config, Context context)
                where TModel : class
                => context.GetTimeSlotAndDuration(config);
        }
    }
}
