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

using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Management.Internal.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Compute.Strategies.ResourceManager
{
    static class ResourceConfigExtensions
    {
        public static ResourceConfig<TModel> CreateResourceConfig<TModel>(
            this ResourceStrategy<TModel> strategy,
            ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            Func<string, TModel> createModel = null,
            IEnumerable<IEntityConfig> dependencies = null)
            where TModel : class, new()
            => strategy.CreateConfig(
                resourceGroup.Name,
                name,
                createModel,
                dependencies.EmptyIfNull().Where(d => d != null).Concat(new[] { resourceGroup }));
    }
}
