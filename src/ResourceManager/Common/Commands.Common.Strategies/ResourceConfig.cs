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
    /// <summary>
    /// Resource configuration. It contains information to create a resource,
    /// including name, resource group name, dependencies, model creation function, etc.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public sealed class ResourceConfig<TModel> : IEntityConfig<TModel>, IResourceConfig
        where TModel : class
    {
        public ResourceStrategy<TModel> Strategy { get; }

        public string ResourceGroupName { get; }

        public string Name { get; }

        public Func<string, TModel> CreateModel { get; }

        public IEnumerable<IEntityConfig> Dependencies { get; }

        IEntityStrategy IEntityConfig.Strategy => Strategy;

        IResourceStrategy IResourceConfig.Strategy => Strategy;

        IResourceConfig IEntityConfig.Resource => this;

        public ResourceConfig(
            ResourceStrategy<TModel> strategy,
            string resourceGroupName,
            string name,
            Func<string, TModel> createModel,
            IEnumerable<IEntityConfig> dependencies)
        {
            Strategy = strategy;
            ResourceGroupName = resourceGroupName;
            Name = name;
            CreateModel = createModel;
            Dependencies = dependencies;
        }

        public IEnumerable<string> GetId(string subscription)
            => new[]
                {
                    "subscriptions",
                    subscription,
                    "resourceGroups",
                    ResourceGroupName
                }
                .Concat(Strategy.GetId(Name));

        TResult IEntityConfig.Accept<TContext, TResult>(
            IEntityConfigVisitor<TContext, TResult> visitor, TContext context)
            => visitor.Visit(this, context);

        TResult IEntityConfig<TModel>.Accept<TContext, TResult>(
            IEntityConfigVisitor<TModel, TContext, TResult> visitor, TContext context)
            => visitor.Visit(this, context);

        TResult IResourceConfig.Accept<TContext, TResult>(
            IResourceConfigVisitor<TContext, TResult> visitor, TContext context)
            => visitor.Visit(this, context);
    }
}
