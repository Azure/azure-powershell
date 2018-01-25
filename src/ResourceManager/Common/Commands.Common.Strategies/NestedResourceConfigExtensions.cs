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

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class NestedResourceConfigExtensions
    {
        public static NestedResourceConfig<TModel, TParenModel> CreateConfig<TModel, TParenModel>(
            this NestedResourceStrategy<TModel, TParenModel> strategy,
            IEntityConfig<TParenModel> parent,
            string name,
            Func<string, TModel> createModel)
            where TModel : class
            where TParenModel : class
            => new NestedResourceConfig<TModel, TParenModel>(strategy, parent, name, createModel);
    }
}
