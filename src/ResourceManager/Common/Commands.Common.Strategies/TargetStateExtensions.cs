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
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class TargetStateExtensions
    {
        public static IEnumerable<IResourceConfig> GetTargetDependencies(
            this IResourceConfig config, IState target)
            => config.GetResourceDependencies().Where(target.Contains);

        public static IState GetTargetState<TModel>(
            this ResourceConfig<TModel> config,
            IState current,
            IEngine engine,
            string location)
            where TModel : class
        {
            var context = new Context(current, engine, location);
            context.AddIfRequired(config);
            return context.Target;
        }

        sealed class Context
        {
            public State Target { get; } = new State();

            public IState Current { get; }

            public IEngine Engine { get; }

            public string Location { get; }

            public Context(IState current, IEngine engine, string location)
            {
                Current = current;
                Engine = engine;
                Location = location;
            }

            public bool CurrentMatch(IEntityConfig config)
                => Current.ContainsDispatch(config) &&
                    config.NestedResources.All(CurrentMatch);

            public void AddIfRequired(IResourceConfig config)
            {
                if (!CurrentMatch(config))
                {
                    config.Accept(new AddVisitor(), this);
                }
            }

            public void UpdateNested<TModel>(IEntityConfig<TModel> config, TModel model)
                where TModel : class
            {
                var nestedResourceContext = new NestedResourceContext<TModel>(this, model);
                foreach (var nestedConfig in config.NestedResources)
                {
                    nestedConfig.Accept(
                        new SetNestedModelVisitor<TModel>(), nestedResourceContext);
                }
            }

            public TModel GetOrAdd<TModel>(ResourceConfig<TModel> config)
                where TModel : class
                => Target.GetOrAdd(
                    config,
                    () =>
                    {
                        foreach (var dependency in config.GetResourceDependencies())
                        {
                            AddIfRequired(dependency);
                        }
                        var model = config.CreateModel(Engine);
                        config.Strategy.Location.Set(model, Location);
                        UpdateNested(config, model);
                        return model;
                    });
        }

        sealed class AddVisitor : IResourceConfigVisitor<Context, Void>
        {
            public Void Visit<TModel>(ResourceConfig<TModel> config, Context context)
                where TModel : class
            {
                context.GetOrAdd(config);
                return new Void();
            }
        }

        sealed class NestedResourceContext<TParentModel>
            where TParentModel : class
        {
            public Context Context { get; }

            public TParentModel ParentModel { get; }

            public NestedResourceContext(Context context, TParentModel parentModel)
            {
                Context = context;
                ParentModel = parentModel;
            }

            public void SetNestedModel<TModel>(
                NestedResourceConfig<TModel, TParentModel> config)
                where TModel : class
            {
                var model = config.CreateModel(Context.Engine);
                config.Strategy.CreateOrUpdate(ParentModel, config.Name, model);
            }
        }

        sealed class SetNestedModelVisitor<TParentModel> :
            INestedResourceConfigVisitor<TParentModel, NestedResourceContext<TParentModel>, Void>
            where TParentModel : class
        {
            public Void Visit<TModel>(
                NestedResourceConfig<TModel, TParentModel> config,
                NestedResourceContext<TParentModel> context)
                where TModel : class
            {
                context.SetNestedModel(config);
                return new Void();
            }
        }
    }
}
