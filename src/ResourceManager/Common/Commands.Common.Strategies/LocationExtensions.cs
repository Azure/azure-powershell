using Microsoft.Azure.Management.ResourceManager.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class LocationExtensions
    {
        /// <summary>
        /// Get the best location for the given entity from the given state.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static string GetLocation(this IState state, IEntityConfig config)
            => state.GetDependencyLocationDispatch(config)?.Location;

        static DependencyLocation GetDependencyLocationDispatch(this IState state, IEntityConfig config)
            => config.Accept(new GetDependencyLocationVisitor(), state);

        static DependencyLocation GetDependencyLocation<TModel>(
            this IState state, ResourceConfig<TModel> config)
            where TModel : class
        {
            var info = state.Get(config);
            return info != null
                ? new DependencyLocation(
                    config.Strategy.GetLocation(info),
                    typeof(TModel) != typeof(ResourceGroup))
                : config
                    .Dependencies
                    .Select(state.GetDependencyLocationDispatch)
                    .Aggregate(null as DependencyLocation, Merge);
        }

        static DependencyLocation GetDependencyLocation<TModel, TParentModel>(
            this IState state, NestedResourceConfig<TModel, TParentModel> config)
            where TModel : class
            where TParentModel : class
            => config.Parent.Accept(new GetDependencyLocationVisitor(), state);

        sealed class GetDependencyLocationVisitor : IEntityConfigVisitor<IState, DependencyLocation>
        {
            public DependencyLocation Visit<TModel>(ResourceConfig<TModel> config, IState state)
                where TModel : class
                => state.GetDependencyLocation(config);

            public DependencyLocation Visit<TModel, TParentModel>(
                NestedResourceConfig<TModel, TParentModel> config, IState state)
                where TModel : class
                where TParentModel : class
                => state.GetDependencyLocation(config);
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
