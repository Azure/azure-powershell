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

using Microsoft.Azure.Commands.Common.Strategies.Rm.Meta;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies.Rm.Config
{
    /// <summary>
    /// Resource configuration. It contains information to create a resource,
    /// including name, resource group name, dependencies, model creation function, etc.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    sealed class ResourceConfig<TModel> : IResourceConfig<TModel>
        where TModel : class
    {
        public IResourceStrategy<TModel> Strategy { get; }

        // It has to be ResourceConfig<ResourceGroup>.
        public IResourceConfig ResourceGroup { get; }

        public string Name { get; }

        public Func<IEngine, TModel> CreateModel { get; }

        IEnumerable<IEntityConfig> IEntityConfig.Dependencies => _Dependencies;

        readonly IEnumerable<IEntityConfig> _Dependencies;

        IEntityStrategy IEntityConfig.Strategy => Strategy;

        IResourceStrategy IResourceConfig.Strategy => Strategy;

        IResourceConfig IEntityConfig.Resource => this;

        readonly IList<INestedResourceConfig<TModel>> _NestedResources
            = new List<INestedResourceConfig<TModel>>();

        public IEnumerable<INestedResourceConfig<TModel>> NestedResources
            => _NestedResources;

        IEnumerable<INestedResourceConfig> IEntityConfig.NestedResources
            => _NestedResources;

        public ResourceConfig(
            IResourceStrategy<TModel> strategy,
            IResourceConfig resourceGroup,
            string name,
            Func<IEngine, TModel> createModel,
            IEnumerable<IEntityConfig> dependencies)
        {
            Strategy = strategy;
            ResourceGroup = resourceGroup;
            Name = name;
            CreateModel = createModel;
            _Dependencies = dependencies;
        }

        public IEnumerable<string> GetIdFromResourceGroup()
            => ResourceGroup == null 
                ? Enumerable.Empty<string>()
                : new[] { Strategy.Type.Namespace, Strategy.Type.Provider, Name };

        TResult IEntityConfig.Accept<TContext, TResult>(
            IEntityConfigVisitor<TContext, TResult> visitor, TContext context)
            => visitor.Visit(this, context);

        TResult IEntityConfig<TModel>.Accept<TContext, TResult>(
            IEntityConfigVisitor<TModel, TContext, TResult> visitor, TContext context)
            => visitor.Visit(this, context);

        TResult IResourceConfig.Accept<TContext, TResult>(
            IResourceConfigVisitor<TContext, TResult> visitor, TContext context)
            => visitor.Visit(this, context);

        void IEntityConfig<TModel>.AddNested<TNestedModel>(
            INestedResourceConfig<TNestedModel, TModel> config)
            => _NestedResources.Add(config);
    }
}
