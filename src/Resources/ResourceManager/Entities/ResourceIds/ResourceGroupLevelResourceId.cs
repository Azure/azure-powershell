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
    /// Represents a resource group-level resource Id
    /// </summary>
    public class ResourceGroupLevelResourceId : ResourceId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupLevelResourceId"/> class
        /// </summary>
        /// <param name="subscriptionId">The subscription Id</param>
        /// <param name="resourceGroup">The resource group</param>
        /// <param name="routingScope">The routing scope</param>
        /// <param name="parentScopes">The parent scopes</param>
        private ResourceGroupLevelResourceId(string subscriptionId, string resourceGroup, ResourceIdScope routingScope, IEnumerable<ResourceIdScope> parentScopes)
            : base(routingScope, parentScopes, ResourceGroupLevelResourceId.FormatResourceId(subscriptionId, resourceGroup, routingScope, parentScopes))
        {
            this.SubscriptionId = subscriptionId;
            this.ResourceGroup = resourceGroup;
        }

        /// <summary>
        /// Gets the subscription Id
        /// </summary>
        public string SubscriptionId { get; }

        /// <summary>
        /// Gets the resource group
        /// </summary>
        public string ResourceGroup { get; }

        /// <summary>
        /// Enumerates the parent resource Ids
        /// </summary>
        /// <param name="orderByDepthAscending">Order by depth ascending?</param>
        public IEnumerable<ResourceGroupLevelResourceId> GetParents(bool orderByDepthAscending)
            => this.RoutingScope
            .GetParents(orderByDepthAscending)
            .Select(routingScope => new ResourceGroupLevelResourceId(this.SubscriptionId, this.ResourceGroup, routingScope, this.ParentScopes));

        /// <summary>
        /// Generates a child resource Id
        /// </summary>
        /// <param name="nestedType">The last segment of the child resource type</param>
        /// <param name="nestedName">The last segment of the child resource name</param>
        public ResourceGroupLevelResourceId GetChild(string nestedType, string nestedName)
            => new ResourceGroupLevelResourceId(this.SubscriptionId, this.ResourceGroup, this.RoutingScope.GetChild(nestedType, nestedName), this.ParentScopes);

        /// <summary>
        /// Gets the root resource Id
        /// </summary>
        public ResourceGroupLevelResourceId GetRootResourceId()
            => this.IsRootResource ? this : this.GetParents(orderByDepthAscending: true).First();

        #region Parsing
        /// <summary>
        /// Formats a resource group-level resource Id
        /// </summary>
        /// <param name="subscriptionId">The subscription Id</param>
        /// <param name="resourceGroup">The resource group</param>
        /// <param name="routingScope">The routing scope</param>
        /// <param name="parentScopes">The parent scopes</param>
        private static string FormatResourceId(string subscriptionId, string resourceGroup, ResourceIdScope routingScope, IEnumerable<ResourceIdScope> parentScopes)
            => $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/{ResourceId.FormatUnqualifiedId(routingScope, parentScopes)}";

        /// <summary>
        /// Tries to create a new <see cref="ResourceGroupLevelResourceId"/>
        /// </summary>
        /// <param name="resourceId">The resource Id string</param>
        /// <param name="output">The resource Id output</param>
        public static bool TryParse(string resourceId, out ResourceGroupLevelResourceId output)
        {
            output = null;

            if (resourceId == null)
            {
                return false;
            }

            var segments = resourceId.Trim('/').SplitRemoveEmpty('/');
            if (segments.Length < 5)
            {
                return false;
            }

            if (!"subscriptions".EqualsInsensitively(segments[0]))
            {
                return false;
            }

            if (!"resourceGroups".EqualsInsensitively(segments[2]))
            {
                return false;
            }

            if (!"providers".EqualsInsensitively(segments[4]))
            {
                return false;
            }

            ResourceIdScope routingScope;
            IEnumerable<ResourceIdScope> parentScopes;
            if (!ResourceId.TryParseResourceScopes(
                pathSegments: segments,
                startIndex: 4,
                routingScope: out routingScope,
                parentScopes: out parentScopes))
            {
                return false;
            }

            output = new ResourceGroupLevelResourceId(
                subscriptionId: segments[1],
                resourceGroup: segments[3],
                routingScope: routingScope,
                parentScopes: parentScopes);
            return true;
        }

        /// <summary>
        /// Creates a new <see cref="ResourceGroupLevelResourceId"/>
        /// </summary>
        /// <param name="resourceId">The resource Id string</param>
        public static ResourceGroupLevelResourceId Parse(string resourceId)
        {
            ResourceGroupLevelResourceId output;
            if (!ResourceGroupLevelResourceId.TryParse(resourceId, out output))
            {
                throw new ArgumentException($"Unable to parse fully qualified resource id '{resourceId}'.", nameof(resourceId));
            }

            return output;
        }

        /// <summary>
        /// Creates a new <see cref="TenantLevelResourceId"/>
        /// </summary>
        /// <param name="subscriptionId">The subscription Id</param>
        /// <param name="resourceGroup">The resource group</param>
        /// <param name="routingResourceId">The routing resource Id</param>
        /// <param name="output">The resource Id output</param>
        public static bool TryCreateFromRoutingResourceId(string subscriptionId, string resourceGroup, string routingResourceId, out ResourceGroupLevelResourceId output)
            => TryParse($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/{routingResourceId}", out output);

        /// <summary>
        /// Creates a new <see cref="TenantLevelResourceId"/>
        /// </summary>
        /// <param name="subscriptionId">The subscription Id</param>
        /// <param name="resourceGroup">The resource group</param>
        /// <param name="providerNamespace">The provider namespace</param>
        /// <param name="typeHierarchy">The type hierarchy</param>
        /// <param name="nameHierarchy">The name hierarchy</param>
        public static ResourceGroupLevelResourceId Create(string subscriptionId, string resourceGroup, string providerNamespace, IEnumerable<string> typeHierarchy, IEnumerable<string> nameHierarchy)
            => new ResourceGroupLevelResourceId(subscriptionId, resourceGroup, ResourceIdScope.Create(providerNamespace, typeHierarchy, nameHierarchy), Enumerable.Empty<ResourceIdScope>());
        #endregion

        #region Equality
        /// <summary>
        /// Overload for the == operator
        /// </summary>
        /// <param name="obj1">The first resource Id</param>
        /// <param name="obj2">The second resource Id</param>
        public static bool operator ==(ResourceGroupLevelResourceId obj1, ResourceGroupLevelResourceId obj2)
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
        public static bool operator !=(ResourceGroupLevelResourceId obj1, ResourceGroupLevelResourceId obj2)
            => !(obj1 == obj2);

        /// <summary>
        /// Equality check
        /// </summary>
        /// <param name="obj">The object to compare to</param>
        public override bool Equals(object obj)
            => this == (obj as ResourceGroupLevelResourceId);

        /// <summary>
        /// Gets the HashCode for this resource Id
        /// </summary>
        public override int GetHashCode()
            => StringComparer.OrdinalIgnoreCase.GetHashCode(this.FullyQualifiedId);
        #endregion
    }
}