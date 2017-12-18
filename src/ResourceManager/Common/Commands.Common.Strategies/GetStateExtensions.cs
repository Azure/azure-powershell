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
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class GetStateExtensions
    {
        /// <summary>
        /// Returns a current Azure state for the given resource (config).
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="config"></param>
        /// <param name="client"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IState> GetStateAsync<TModel>(
            this ResourceConfig<TModel> config,
            IClient client,
            CancellationToken cancellationToken)
            where TModel : class
        {
            var context = new StateOperationContext(client, cancellationToken);
            await context.GetStateAsyncDispatch(config);
            return context.Result;
        }

        static Task GetStateAsyncDispatch(
            this StateOperationContext context, IResourceConfig config)
            => config.Accept(new GetStateAsyncVisitor(), context);

        static async Task GetStateAsync<TModel>(
            this StateOperationContext context, ResourceConfig<TModel> config)
            where TModel : class
            => await context.GetOrAdd(
                    config,
                    async () =>
                    {
                        var info = await config.GetAsync(context.Client, context.CancellationToken);
                        // Get state of dependencies if the resource doesn't exist
                        if (info == null)
                        {
                            var tasks = config
                                .GetResourceDependencies()
                                .Select(context.GetStateAsyncDispatch);
                            await Task.WhenAll(tasks);
                        }
                        return info;
                    });

        sealed class GetStateAsyncVisitor : IResourceConfigVisitor<StateOperationContext, Task>
        {
            public Task Visit<TModel>(
                ResourceConfig<TModel> config, StateOperationContext context)
                where TModel : class
                => context.GetStateAsync(config);                
        }
    }
}
