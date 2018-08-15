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
        public static string GetLocation(this IState state, IResourceConfig config)
            => state.GetDependencyLocationDispatch(config)?.Location;

        static DependencyLocation GetDependencyLocationDispatch(this IState state, IResourceConfig config)
            => config.Accept(new GetDependencyLocationVisitor(), state);

        static DependencyLocation GetDependencyLocation<TModel>(
            this IState state, ResourceConfig<TModel> config)
            where TModel : class
        {
            var info = state.Get(config);
            return info != null
                ? new DependencyLocation(
                    config.Strategy.Location.Get(info),
                    config.Strategy.CompulsoryLocation)
                : config
                    .GetResourceDependencies()
                    .Select(state.GetDependencyLocationDispatch)
                    .Aggregate(null as DependencyLocation, Merge);
        }

        sealed class GetDependencyLocationVisitor : IResourceConfigVisitor<IState, DependencyLocation>
        {
            public DependencyLocation Visit<TModel>(ResourceConfig<TModel> config, IState state)
                where TModel : class
                => state.GetDependencyLocation(config);
        }

        sealed class DependencyLocation
        {
            public string Location { get; }

            /// <summary>
            /// If it's true then all dependant resources should also have this location.
            /// </summary>
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
