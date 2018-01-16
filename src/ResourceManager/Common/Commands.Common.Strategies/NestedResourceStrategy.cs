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

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class NestedResourceStrategy<TModel, TParentModel> : IEntityStrategy
    {
        public Func<string, IEnumerable<string>> GetId { get; }

        public Func<TParentModel, string, TModel> Get { get; }

        public Action<TParentModel, string, TModel> CreateOrUpdate { get; }

        public NestedResourceStrategy(
            Func<string, IEnumerable<string>> getId,
            Func<TParentModel, string, TModel> get,
            Action<TParentModel, string, TModel> createOrUpdate)
        {
            GetId = getId;
            Get = get;
            CreateOrUpdate = createOrUpdate;
        }
    }

    public static class NestedResourceStrategy
    {
        public static NestedResourceStrategy<TModel, TParentModel> Create<TModel, TParentModel>(
            string provider,
            Func<TParentModel, string, TModel> get,
            Action<TParentModel, string, TModel> createOrUpdate)
            where TModel : class
            where TParentModel : class
            => new NestedResourceStrategy<TModel, TParentModel>(
                name => new[] { provider, name},
                get,
                createOrUpdate);
    }
}
