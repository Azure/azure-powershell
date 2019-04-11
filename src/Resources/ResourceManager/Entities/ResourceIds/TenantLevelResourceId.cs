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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ResourceIds
{
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a tenant-level resource Id
    /// </summary>
    public class TenantLevelResourceId : ResourceId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantLevelResourceId"/> class
        /// </summary>
        /// <param name="routingScope">The routing scope</param>
        /// <param name="parentScopes">The parent scopes</param>
        private TenantLevelResourceId(ResourceIdScope routingScope, IEnumerable<ResourceIdScope> parentScopes)
            : base(routingScope, parentScopes, TenantLevelResourceId.FormatResourceId(routingScope, parentScopes))
        {
        }

        /// <summary>
        /// Enumerates the parent resource Ids
        /// </summary>
        /// <param name="orderByDepthAscending">Order by depth ascending?</param>
        public IEnumerable<TenantLevelResourceId> GetParents(bool orderByDepthAscending)
            => this.RoutingScope
            .GetParents(orderByDepthAscending)
            .Select(routingScope => new TenantLevelResourceId(routingScope, this.ParentScopes));

        /// <summary>
        /// Generates a child resource Id
        /// </summary>
        /// <param name="nestedType">The last segment of the child resource type</param>
        /// <param name="nestedName">The last segment of the child resource name</param>
        public TenantLevelResourceId GetChild(string nestedType, string nestedName)
            => new TenantLevelResourceId(this.RoutingScope.GetChild(nestedType, nestedName), this.ParentScopes);

        /// <summary>
        /// Gets the root resource Id
        /// </summary>
        public TenantLevelResourceId GetRootResourceId()
            => this.IsRootResource ? this : this.GetParents(orderByDepthAscending: true).First();

        #region Parsing
        /// <summary>
        /// Formats a tenant-level resource Id
        /// </summary>
        /// <param name="routingScope">The routing scope</param>
        /// <param name="parentScopes">The parent scopes</param>        
        private static string FormatResourceId(ResourceIdScope routingScope, IEnumerable<ResourceIdScope> parentScopes)
            => $"/providers/{ResourceId.FormatUnqualifiedId(routingScope, parentScopes)}";

        /// <summary>
        /// Tries to create a new <see cref="TenantLevelResourceId"/>
        /// </summary>
        /// <param name="resourceId">The resource Id string</param>
        /// <param name="output">The resource Id output</param>
        public static bool TryParse(string resourceId, out TenantLevelResourceId output)
        {
            output = null;

            if (resourceId == null)
            {
                return false;
            }

            var segments = resourceId.Trim('/').SplitRemoveEmpty('/');
            if (segments.Length < 1)
            {
                return false;
            }

            if (!"providers".EqualsInsensitively(segments[0]))
            {
                return false;
            }

            ResourceIdScope routingScope;
            IEnumerable<ResourceIdScope> parentScopes;
            if (!ResourceId.TryParseResourceScopes(
                pathSegments: segments,
                startIndex: 0,
                routingScope: out routingScope,
                parentScopes: out parentScopes))
            {
                return false;
            }

            output = new TenantLevelResourceId(
                routingScope: routingScope,
                parentScopes: parentScopes);
            return true;
        }

        /// <summary>
        /// Creates a new <see cref="TenantLevelResourceId"/>
        /// </summary>
        /// <param name="resourceId">The resource Id string</param>
        public static TenantLevelResourceId Parse(string resourceId)
        {
            TenantLevelResourceId output;
            if (!TenantLevelResourceId.TryParse(resourceId, out output))
            {
                throw new ArgumentException($"Unable to parse fully qualified resource id '{resourceId}'.", nameof(resourceId));
            }

            return output;
        }
        #endregion

        #region Equality
        /// <summary>
        /// Overload for the == operator
        /// </summary>
        /// <param name="obj1">The first resource Id</param>
        /// <param name="obj2">The second resource Id</param>
        public static bool operator ==(TenantLevelResourceId obj1, TenantLevelResourceId obj2)
        {
            if (object.ReferenceEquals(obj1, obj2))
            {
                return true;
            }

            if (object.ReferenceEquals(obj1, null) || object.ReferenceEquals(obj2, null))
            {
                return false;
            }

            return StringComparer.OrdinalIgnoreCase.Equals(obj1.FullyQualifiedId, obj2.FullyQualifiedId);
        }

        /// <summary>
        /// Overload for the != operator
        /// </summary>
        /// <param name="obj1">The first resource Id</param>
        /// <param name="obj2">The second resource Id</param>
        public static bool operator !=(TenantLevelResourceId obj1, TenantLevelResourceId obj2)
            => !(obj1 == obj2);

        /// <summary>
        /// Equality check
        /// </summary>
        /// <param name="obj">The object to compare to</param>
        public override bool Equals(object obj)
            => this == (obj as TenantLevelResourceId);

        /// <summary>
        /// Gets the HashCode for this resource Id
        /// </summary>
        public override int GetHashCode()
            => StringComparer.OrdinalIgnoreCase.GetHashCode(this.FullyQualifiedId);
        #endregion
    }
}