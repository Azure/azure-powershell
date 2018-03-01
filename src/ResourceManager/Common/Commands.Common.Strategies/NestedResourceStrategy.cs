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
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class NestedResourceStrategy<TModel, TParentModel> : INestedResourceStrategy
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

        public static NestedResourceStrategy<TModel, TParentModel> Create<TModel, TParentModel>(
            string provider,
            Func<TParentModel, IList<TModel>> getList,
            Action<TParentModel, IList<TModel>> setList,
            Func<TModel, string> getName,
            Action<TModel, string> setName)
            where TModel : class
            where TParentModel : class
            => Create<TModel, TParentModel>(
                provider,
                (parentModel, name) => getList(parentModel)
                    ?.FirstOrDefault(model => getName(model) == name),
                (parentModel, name, model) =>
                {
                    setName(model, name);
                    var list = getList(parentModel);
                    if (list == null)
                    {
                        list = new List<TModel> { model };
                        setList(parentModel, list);
                        return;
                    }
                    var modelAndIndex = list
                        .Select((m, i) => new { m, i })
                        .FirstOrDefault(mi => getName(mi.m) == name);
                    if (modelAndIndex != null)
                    {
                        list[modelAndIndex.i] = model;
                        return;
                    }
                    list.Add(model);
                });
    }
}
