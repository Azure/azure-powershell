using System.Linq;

namespace Microsoft.Azure.Experiments
{
    public static class Parameters
    {
        public static IState GetParameters<Config>(
            this IResourceConfig<Config> config,
            string subscription, 
            string location)
            where Config : class
        {
            var visitor = new Visitor(subscription, location);
            visitor.Get(config);
            return visitor.Result;
        }

        sealed class Visitor : IResourceConfigVisitor<object>
        {
            public Visitor(string subscription, string location)
            {
                Subscription = subscription;
                Location = location;
            }

            public object GetUntyped(IResourceConfig config)
                => Result.GetOrAddUntyped(config, () => config.Apply(this));

            public Config Get<Config>(IResourceConfig<Config> config)
                where Config : class
                => GetUntyped(config) as Config;

            public object Visit<Config>(ResourceConfig<Config> config) where Config : class
            {
                foreach (var d in config.Dependencies)
                {
                    GetUntyped(d);
                }
                var p = config.CreateConfig(Subscription);
                config.Policy.SetLocation(p, Location);
                return p;
            }

            public object Visit<Config, ParentConfig>(
                NestedResourceConfig<Config, ParentConfig> config)
                where Config : class
                where ParentConfig : class
            {
                var result = config.Create();
                config.Policy.Set(Get(config.Parent), result);
                return result;
            }

            string Subscription { get; }

            string Location { get; }

            public State Result { get; } = new State();
        }
    }
}
