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
using System.Data.Services.Client;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common
{
    /// <summary>
    /// Extension methods for <see cref="DataServiceContext" /> objects.
    /// </summary>
    public static class DataServiceExtensions
    {
        /// <summary>
        /// Detach the tracked entity and related links from the <see cref="DataServiceContext"/>.
        /// </summary>
        /// <param name="context">The <see cref="DataServiceContext"/> containing the entity.</param>
        /// <param name="entity">The entity to detach.</param>
        public static void ClearTrackedEntity(this DataServiceContext context, object entity)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            foreach (LinkDescriptor linkDescriptor in context.Links)
            {
                if (linkDescriptor.Source == entity || linkDescriptor.Target == entity)
                {
                    context.DetachLink(linkDescriptor.Source, linkDescriptor.SourceProperty, linkDescriptor.Target);
                }
            }

            foreach (EntityDescriptor entityDescriptor in context.Entities)
            {
                if (entityDescriptor.Entity == entity)
                {
                    context.Detach(entity);
                    break;
                }
            }
        }
    }
}
