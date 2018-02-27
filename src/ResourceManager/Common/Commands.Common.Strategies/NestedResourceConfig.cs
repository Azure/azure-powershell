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
    /// Nested resource configuration. Fro example, Subnet.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TParenModel"></typeparam>
    public sealed class NestedResourceConfig<TModel, TParenModel> : 
        INestedResourceConfig<TParenModel>,
        IEntityConfig<TModel>
        where TModel : class
        where TParenModel : class
    {
        public NestedResourceStrategy<TModel, TParenModel> Strategy { get; }

        public string Name { get; }

        /// <summary>
        /// Parent. For example, VirtualNetwork is a parent of Subnet.
        /// </summary>
        public IEntityConfig<TParenModel> Parent { get; }

        public Func<IEngine, TModel> CreateModel { get; }

        public IResourceConfig Resource => Parent.Resource;

        IEntityStrategy IEntityConfig.Strategy => Strategy;

        IEntityConfig INestedResourceConfig.Parent => Parent;

        INestedResourceStrategy INestedResourceConfig.Strategy => Strategy;

        IList<INestedResourceConfig<TModel>> _NestedResources { get; }
            = new List<INestedResourceConfig<TModel>>();

        public IResourceConfig ResourceGroup 
            => Resource.ResourceGroup;

        public IEnumerable<INestedResourceConfig<TModel>> NestedResources
            => _NestedResources;

        IEnumerable<IEntityConfig> IEntityConfig.Dependencies => _Dependencies;

        readonly IEnumerable<IEntityConfig> _Dependencies;

        IEnumerable<INestedResourceConfig> IEntityConfig.NestedResources
            => _NestedResources;

        public NestedResourceConfig(
            IEntityConfig<TParenModel> parent,
            NestedResourceStrategy<TModel, TParenModel> strategy,
            string name,
            Func<IEngine, TModel> createModel,
            IEnumerable<IEntityConfig> dependencies)
        {
            Parent = parent;
            Strategy = strategy;
            Name = name;
            CreateModel = createModel;
            _Dependencies = dependencies;

            parent.AddNested(this);
        }

        public IEnumerable<string> GetIdFromResourceGroup()
            => Parent.GetIdFromResourceGroup().Concat(Strategy.GetId(Name)); 

        TResult IEntityConfig.Accept<TContext, TResult>(
            IEntityConfigVisitor<TContext, TResult> visitor, TContext context)
            => visitor.Visit(this, context);

        TResult IEntityConfig<TModel>.Accept<TContext, TResult>(
            IEntityConfigVisitor<TModel, TContext, TResult> visitor, TContext context)
            => visitor.Visit(this, context);

        TResult INestedResourceConfig<TParenModel>.Accept<TContext, TResult>(
            INestedResourceConfigVisitor<TParenModel, TContext, TResult> visitor, TContext context)
            => visitor.Visit(this, context);

        void IEntityConfig<TModel>.AddNested<TNestedModel>(NestedResourceConfig<TNestedModel, TModel> config)
            => _NestedResources.Add(config);
    }
}
