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

using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies.Network
{
    static class NetworkStrategy
    {
        public static ResourceStrategy<TModel> Create<TModel, TOperations>(
            string type,
            string provider,
            Func<NetworkManagementClient, TOperations> getOperations,
            Func<TOperations, GetAsyncParams, Task<TModel>> getAsync,
            Func<TOperations, CreateOrUpdateAsyncParams<TModel>, Task<TModel>> createOrUpdateAsync,
            Func<TModel, int> createTime)
            where TModel : Resource
            => ResourceStrategy.Create(
                type,
                new [] { "Microsoft.Network", provider },
                getOperations,
                getAsync,
                createOrUpdateAsync, 
                model => model.Location, 
                (model, location) => model.Location = location,
                createTime,
                true);
    }
}
