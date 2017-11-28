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

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class StateExtensions
    {
        /// <summary>
        /// Get a model of the given nested resource config from the given state.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TParentModel"></typeparam>
        /// <param name="state"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static TModel Get<TModel, TParentModel>(
            this IState state, NestedResourceConfig<TModel, TParentModel> config)
            where TModel : class
            where TParentModel : class
        {
            var parentModel = state.GetDispatch(config.Parent);
            return parentModel == null ? null : config.Strategy.Get(parentModel, config.Name);
        }

        /// <summary>
        /// Get a model of the given entity model from the given state.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="state"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static TModel GetDispatch<TModel>(
            this IState state, IEntityConfig<TModel> config)
            where TModel : class
            => config.Accept(new GetVisitor<TModel>(), state);

        public static bool Contains<TModel, TParentModel>(
            this IState state, NestedResourceConfig<TModel, TParentModel> config)
            where TModel : class
            where TParentModel : class
            => state.Get(config) != null;

        public static bool ContainsDispatch(this IState state, IEntityConfig config)
            => config.Accept(new ContainsDispatchVisitor(), state);

        sealed class GetVisitor<TModel> : IEntityConfigVisitor<TModel, IState, TModel>
            where TModel : class
        {
            public TModel Visit(ResourceConfig<TModel> config, IState state)
                => state.Get(config);

            public TModel Visit<TParentModel>(
                NestedResourceConfig<TModel, TParentModel> config, IState state)
                where TParentModel : class
                => state.Get(config);
        }

        sealed class ContainsDispatchVisitor : IEntityConfigVisitor<IState, bool>
        {
            public bool Visit<TModel>(ResourceConfig<TModel> config, IState context)
                where TModel : class
                => context.Contains(config);

            public bool Visit<TModel, TParentModel>(
                NestedResourceConfig<TModel, TParentModel> config, IState context)
                where TModel : class
                where TParentModel : class
                => context.Contains(config);
        }
    }
}
