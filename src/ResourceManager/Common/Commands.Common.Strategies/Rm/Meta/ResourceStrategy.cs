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
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies.Rm.Meta
{
    public static class ResourceStrategy
    {
        public static bool IsLocationCompulsory(this IResourceStrategy strategy)
            => strategy.Type.Namespace != ResourceType.ResourceGroup.Namespace;

        public static IResourceStrategy<TModel> Create<TModel, TClient, TOperation>(
            ResourceType type,
            Func<TClient, string> getApiVersion,
            Func<TClient, TOperation> getOperations,
            Func<TOperation, GetAsyncParams, Task<TModel>> getAsync,
            Func<TOperation, CreateOrUpdateAsyncParams<TModel>, Task<TModel>> createOrUpdateAsync,
            Func<TModel, string> getLocation,
            Action<TModel, string> setLocation,
            Func<TModel, int> createTime)
            where TModel : class
            where TClient : ServiceClient<TClient>
        {
            Func<IClient, TOperation> toOperations = 
                client => getOperations(client.GetClient<TClient>());
            return new Implementation<TModel>(
                type,
                client => getApiVersion(client.GetClient<TClient>()),
                (client, p) => getAsync(toOperations(client), p),
                (client, p) => createOrUpdateAsync(toOperations(client), p),
                Property.Create(getLocation, setLocation),
                createTime);
        }

        public static string GetResourceType(this IResourceStrategy strategy)
            => strategy.Type == null ? null : strategy.Type.Namespace + "/" + strategy.Type.Provider;

        sealed class Implementation<TModel> : IResourceStrategy<TModel>
        {
            public ResourceType Type { get; }

            public Func<IClient, string> GetApiVersion { get; }

            public Func<IClient, GetAsyncParams, Task<TModel>> GetAsync { get; }

            public Func<IClient, CreateOrUpdateAsyncParams<TModel>, Task<TModel>> CreateOrUpdateAsync
            { get; }

            public Property<TModel, string> Location { get; }

            public Func<TModel, int> CreateTime { get; }

            public Implementation(
                ResourceType type,
                Func<IClient, string> getApiVersion,
                Func<IClient, GetAsyncParams, Task<TModel>> getAsync,
                Func<IClient, CreateOrUpdateAsyncParams<TModel>, Task<TModel>> createOrUpdateAsync,
                Property<TModel, string> location,
                Func<TModel, int> createTime)
            {
                Type = type;
                GetApiVersion = getApiVersion;
                GetAsync = getAsync;
                CreateOrUpdateAsync = createOrUpdateAsync;
                Location = location;
                CreateTime = createTime;
            }
        }
    }
}
