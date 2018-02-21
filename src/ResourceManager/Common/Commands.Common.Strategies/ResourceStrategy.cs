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

using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class ResourceStrategy<TModel> : IResourceStrategy
    {
        public ResourceType Type { get; }

        public Func<IClient, GetAsyncParams, Task<TModel>> GetAsync { get; }

        public Func<IClient, CreateOrUpdateAsyncParams<TModel>, Task<TModel>> CreateOrUpdateAsync
        { get; }

        public Property<TModel, string> Location { get; }

        public Func<TModel, int> CreateTime { get; }

        public bool CompulsoryLocation { get; }

        public ResourceStrategy(
            ResourceType type,
            Func<IClient, GetAsyncParams, Task<TModel>> getAsync,
            Func<IClient, CreateOrUpdateAsyncParams<TModel>, Task<TModel>> createOrUpdateAsync,
            Property<TModel, string> location,
            Func<TModel, int> createTime,
            bool compulsoryLocation)
        {
            Type = type;
            GetAsync = getAsync;
            CreateOrUpdateAsync = createOrUpdateAsync;
            Location = location;
            CreateTime = createTime;
            CompulsoryLocation = compulsoryLocation;
        }
    }

    public static class ResourceStrategy
    {
        public static ResourceStrategy<TModel> Create<TModel, TClient, TOperation>(
            ResourceType type,
            Func<TClient, TOperation> getOperations,
            Func<TOperation, GetAsyncParams, Task<TModel>> getAsync,
            Func<TOperation, CreateOrUpdateAsyncParams<TModel>, Task<TModel>> createOrUpdateAsync,
            Func<TModel, string> getLocation,
            Action<TModel, string> setLocation,
            Func<TModel, int> createTime,
            bool compulsoryLocation)
            where TModel : class
            where TClient : ServiceClient<TClient>
        {
            Func<IClient, TOperation> toOperations = client => getOperations(client.GetClient<TClient>());
            return new ResourceStrategy<TModel>(
                type,
                (client, p) => getAsync(toOperations(client), p),
                (client, p) => createOrUpdateAsync(toOperations(client), p),
                Property.Create(getLocation, setLocation),
                createTime,
                compulsoryLocation);
        }
    }
}
