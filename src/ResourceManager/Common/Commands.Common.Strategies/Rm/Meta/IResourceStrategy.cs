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
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies.Rm.Meta
{
    /// <summary>
    /// Base interface for ResourceStrategy[].
    /// </summary>
    public interface IResourceStrategy : IEntityStrategy
    {
        ResourceType Type { get; }

        /// <summary>
        /// Returns an API version.
        /// </summary>
        Func<IClient, string> GetApiVersion { get; }
    }

    public interface IResourceStrategy<TModel> : IResourceStrategy
    {
        Func<IClient, GetAsyncParams, Task<TModel>> GetAsync { get; }

        Func<IClient, CreateOrUpdateAsyncParams<TModel>, Task<TModel>> CreateOrUpdateAsync { get; }

        Property<TModel, string> Location { get; }

        Func<TModel, int> CreateTime { get; }
    }
}
