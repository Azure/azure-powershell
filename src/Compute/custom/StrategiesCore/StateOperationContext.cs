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
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    /// <summary>
    /// Context for asyncronous operations, such as GetAsync or CreateOrUpdateAsync.
    /// </summary>
    public sealed class StateOperationContext
    {
        public IClient Client { get; }

        public CancellationToken CancellationToken { get; }

        public IState Result => _Result;

        readonly State _Result = new State();

        readonly ConcurrentDictionary<string, Task> _TaskMap
            = new ConcurrentDictionary<string, Task>();

        public StateOperationContext(IClient client, CancellationToken cancellationToken)
        {
            Client = client;
            CancellationToken = cancellationToken;
        }

        public async Task<TModel> GetOrAdd<TModel>(
            ResourceConfig<TModel> config, Func<Task<TModel>> operation)
            where TModel : class
            => await _TaskMap.GetOrAddWithCast(
                config.DefaultIdStr(),
                async () =>
                {
                    var model = await operation();
                    if (model != null)
                    {
                        // add the operation result to a result.
                        _Result.GetOrAdd(config, () => model);
                    }
                    return model;
                });
    }
}
