using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class TimeSlotExtensions
    {
        public static Tuple<Dictionary<IResourceConfig, TimeSlot>, int> GetTimeSlonAndDuration<TModel>(
            this ResourceConfig<TModel> config, IState state)
            where TModel : class
        {
            var context = new Context(state);
            return Tuple.Create(context.BeginMap, context.GetTimeSlotAndDuration(config).Item2);
        }            

        sealed class Context
        {
            public TimeSlot Begin { get; } = new TimeSlot();

            public Dictionary<IResourceConfig, TimeSlot> BeginMap { get; }
                = new Dictionary<IResourceConfig, TimeSlot>();

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
                        BeginMap.Add(config, tupleBegin.Item1);
                        var duration = config.Strategy.CreateTime(_State.Get(config));
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
