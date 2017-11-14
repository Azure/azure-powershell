using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Experiments
{
    public sealed class CreateOperation
    {
        public IEnumerable<CreateOperation> Dependencies { get; }

        public CreateOperation(IEnumerable<CreateOperation> dependencies)
        {
            Dependencies = dependencies;
        }

        public static CreateOperation Create<Config>(IState state, IResourceConfig<Config> config)
            where Config : class
            => new Visitor(state).Get(config);

        sealed class Visitor : IResourceConfigVisitor<CreateOperation>
        {
            public CreateOperation Get(IResourceConfig config)
                => Map.GetOrAdd(config, _ => config.Apply(this));

            public CreateOperation Visit<Config>(ResourceConfig<Config> config) where Config : class
            {
                var info = State.Get(config);
                return info == null 
                    ? new CreateOperation(config.Dependencies.Select(d => Get(d)))
                    : null;
            }

            public CreateOperation Visit<Config, ParentConfig>(
                NestedResourceConfig<Config, ParentConfig> config)
                where Config : class
                where ParentConfig : class
                => Get(config.Parent);

            public Visitor(IState state)
            {
                State = state;
            }

            IState State { get; }

            ConcurrentDictionary<IResourceConfig, CreateOperation> Map { get; }
                = new ConcurrentDictionary<IResourceConfig, CreateOperation>();
        }
    }
}
