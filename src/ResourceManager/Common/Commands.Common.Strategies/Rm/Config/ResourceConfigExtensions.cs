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

using Microsoft.Azure.Commands.Common.Strategies.Rm.Meta;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies.Rm.Config
{
    public static class ResourceConfigExtensions
    {
        public static IResourceConfig<TModel> CreateResourceConfig<TModel>(
            this IResourceStrategy<TModel> strategy,
            IResourceConfig resourceGroup,
            string name,
            Func<IEngine, TModel> createModel,
            IEnumerable<IEntityConfig> dependencies)
            where TModel : class
            => new ResourceConfig<TModel>(
                strategy,
                resourceGroup,
                name,
                createModel,
                new[] { resourceGroup }                
                    .Concat(dependencies)
                    .Where(v => v != null));

        public static IResourceConfig<TModel> CreateResourceConfig<TModel>(
            this IResourceStrategy<TModel> strategy,
            IResourceConfig resourceGroup,
            string name,
            Func<IEngine, TModel> createModel = null)
            where TModel : class, new()
        {
            // update dependencies
            createModel = createModel ?? (_ => new TModel());
            var engine = new DependencyEngine();
            createModel(engine);
            //
            return strategy.CreateResourceConfig(
                resourceGroup,
                name,
                createModel,
                engine
                    .Dependencies
                    .Values);
        }

        internal static async Task<TModel> GetAsync<TModel>(
            this IResourceConfig<TModel> config,
            IClient client,
            CancellationToken cancellationToken)
            where TModel : class
        {
            try
            {
                return await config.Strategy.GetAsync(
                    client,
                    new GetAsyncParams(config.GetResourceGroupName(), config.Name, cancellationToken));
            }
            catch (CloudException e)
                when (e.Response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        internal static Task<TModel> CreateOrUpdateAsync<TModel>(
            this IResourceConfig<TModel> config,
            IClient client,
            TModel model,
            CancellationToken cancellationToken)
            where TModel : class
            => config.Strategy.CreateOrUpdateAsync(
                client,
                CreateOrUpdateAsyncParams.Create(
                    config.GetResourceGroupName(),
                    config.Name,
                    model,
                    cancellationToken));

        internal static IEnumerable<IResourceConfig> GetResourceDependencies(
            this IEntityConfig config)
            => config
                .Dependencies
                .Select(d => d.Resource)                
                .Concat(config.NestedResources.SelectMany(GetResourceDependencies))
                .Where(r => r != config);

        internal static string GetFullName(this IResourceConfig config)
            => config.Strategy.Type.Provider + "/" + config.Name;

        public static INestedResourceConfig<TNestedModel, TModel> CreateNested<TModel, TNestedModel>(
            this IResourceConfig<TModel> config,
            INestedResourceStrategy<TNestedModel, TModel> strategy,
            string name,
            Func<IEngine, TNestedModel> createModel = null)
            where TModel : class
            where TNestedModel : class, new()
        {
            // update dependencies
            createModel = createModel ?? (_ => new TNestedModel());
            var engine = new DependencyEngine();
            createModel(engine);
            //
            return new NestedResourceConfig<TNestedModel, TModel>(
                config,
                strategy,
                name,
                createModel,
                engine.Dependencies.Values);
        }
    }
}
