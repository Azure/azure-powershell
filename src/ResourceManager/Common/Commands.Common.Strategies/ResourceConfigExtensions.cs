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

using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class ResourceConfigExtensions
    {
        public static ResourceConfig<TModel> CreateConfig<TModel>(
            this ResourceStrategy<TModel> strategy,
            string resourceGroupName,
            string name,
            Func<string, TModel> createModel = null,
            IEnumerable<IEntityConfig> dependencies = null)
            where TModel : class, new()
            => new ResourceConfig<TModel>(
                strategy,
                resourceGroupName,
                name,
                createModel ?? (_ => new TModel()),
                dependencies.EmptyIfNull());

        public static async Task<TModel> GetAsync<TModel>(
            this ResourceConfig<TModel> config,
            IClient client,
            CancellationToken cancellationToken)
            where TModel : class
        {
            try
            {
                return await config.Strategy.GetAsync(
                    client,
                    new GetAsyncParams(config.ResourceGroupName, config.Name, cancellationToken));
            }
            catch (CloudException e)
                when (e.Response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public static Task<TModel> CreateOrUpdateAsync<TModel>(
            this ResourceConfig<TModel> config,
            IClient client,
            TModel model,
            CancellationToken cancellationToken)
            where TModel : class
            => config.Strategy.CreateOrUpdateAsync(
                client,
                CreateOrUpdateAsyncParams.Create(
                    config.ResourceGroupName,
                    config.Name,
                    model,
                    cancellationToken));

        public static IEnumerable<IResourceConfig> GetResourceDependencies(
            this IResourceConfig config)
            => config.Dependencies.Select(d => d.Resource);
    }
}
