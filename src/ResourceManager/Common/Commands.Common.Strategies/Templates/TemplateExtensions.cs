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

using Microsoft.Azure.Commands.Common.Strategies.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies.Templates
{
    public static class TemplateExtensions
    {
        /// <summary>
        /// Create a template from the given resource dependency DAG.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="config">Resource configuration.</param>
        /// <param name="client">Generic REST API client.</param>
        /// <param name="target">Target models.</param>
        /// <param name="subscriptionId">subscription id</param>
        /// <returns></returns>
        public static Template CreateTemplate<TModel>(
            this ResourceConfig<TModel> config,
            IClient client,
            IState target,
            TemplateEngine engine)
            where TModel : class
        {
            var context = new Context(client, target, engine);
            context.CreateResource(config);
            return new Template
            {
                contentVersion = "1.0.0.0",
                resources = context.Map.Values.ToArray()
            };
        }

        sealed class Context
        {
            public IClient Client { get; }

            public IState Target { get; }

            public TemplateEngine Engine { get; }

            public ConcurrentDictionary<string, Resource> Map { get; }
                = new ConcurrentDictionary<string, Resource>();

            public Context(IClient client, IState target, TemplateEngine engine)
            {
                Client = client;
                Target = target;
                Engine = engine;
            }

            public void CreateResource<TModel>(ResourceConfig<TModel> config)
                where TModel : class
            {
                // ignore a resource group
                if (config.ResourceGroup != null)
                {
                    Map.GetOrAdd(
                        config.DefaultIdStr(),
                        _ =>
                        {
                            var dependencies = config.GetTargetDependencies(Target);
                            foreach (var d in dependencies)
                            {
                                d.Accept(new CreateResourceVisitor(), this);
                            }
                            var model = Target.Get(config);
                            var jsonModel = new Converters().Serialize(model) as JObject;
                            return new Resource
                            {
                                name = config.Name,
                                type = config.Strategy.GetResourceType(),
                                apiVersion = config.Strategy.GetApiVersion(Client),
                                location = config.Strategy.Location.Get(model),
                                sku = new Converters().Deserialize<Dictionary<string, object>>(jsonModel["sku"]),
                                properties = jsonModel["properties"] as JObject,
                                dependsOn = dependencies
                                    .Where(d => d.ResourceGroup != null)
                                    .Select(Engine.GetId)
                                    .ToArray()
                            };
                        });
                }
            }
        }

        sealed class CreateResourceVisitor : IResourceConfigVisitor<Context, Void>
        {
            public Void Visit<TModel>(ResourceConfig<TModel> config, Context context)
                where TModel : class
            {
                context.CreateResource(config);
                return new Void();
            }
        }
    }
}
