using Microsoft.Azure.Management.ResourceManager.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class StateLocation
    {
        /// <summary>
        /// Get the best location for the given entity from the given state.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static string GetLocation(this IState state, IEntityConfig config)
            => config.Accept(new GetLocationVisitor(), state)?.Location;

        sealed class GetLocationVisitor : IEntityConfigVisitor<IState, DependencyLocation>
        {
            public DependencyLocation Visit<TModel>(ResourceConfig<TModel> config, IState state)
                where TModel : class
            {
                var info = state.Get(config);
                return info != null
                    ? new DependencyLocation(
                        config.Strategy.GetLocation(info),
                        typeof(TModel) != typeof(ResourceGroup))
                    : config
                        .Dependencies
                        .Select(c => c.Accept(this, state))
                        .Aggregate(null as DependencyLocation, Merge);
            }

            public DependencyLocation Visit<TModel, TParentModel>(
                NestedResourceConfig<TModel, TParentModel> config, IState state)
                where TModel : class
                where TParentModel : class
                => config.Parent.Accept(this, state);
        }

        sealed class DependencyLocation
        {
            public string Location { get; }

            public bool IsCompulsory { get; }

            public DependencyLocation(string location, bool isCompulsory)
            {
                Location = location;
                IsCompulsory = isCompulsory;
            }
        }

        static DependencyLocation Merge(this DependencyLocation a, DependencyLocation b)
        {
            if (a == null)
            {
                return b;
            }
            if (b == null)
            {
                return a;
            }

            if (a.IsCompulsory != b.IsCompulsory)
            {
                return a.IsCompulsory ? b : a;
            }

            // a.IsCompulsory == b.IsCompulsory
            return a.Location == b.Location ? a : new DependencyLocation(null, a.IsCompulsory);
        }
    }
}
