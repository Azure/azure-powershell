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
    /// Represents an abstract resource Id
    /// </summary>
    public abstract class ResourceId
    {
        /// <summary>
        /// Represents a resource Id scope
        /// </summary>
        protected class ResourceIdScope
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ResourceIdScope"/> class
            /// </summary>
            /// <param name="providerNamespace">The provider namespace</param>
            /// <param name="typeHierarchy">The type hierarchy</param>
            /// <param name="nameHierarchy">The name hierarchy</param>
            private ResourceIdScope(string providerNamespace, IReadOnlyList<string> typeHierarchy, IReadOnlyList<string> nameHierarchy)
            {
                this.ProviderNamespace = providerNamespace;
                this.TypeHierarchy = typeHierarchy;
                this.NameHierarchy = nameHierarchy;
            }

            /// <summary>
            /// Creates a new <see cref="ResourceIdScope"/>
            /// </summary>
            /// <param name="pathSegments">The scope path segments</param>
            /// <param name="output">The scope output</param>
            public static bool TryParse(IEnumerable<string> pathSegments, out ResourceIdScope output)
            {
                output = null;

                var segmentLength = pathSegments.Count();
                if (segmentLength < 3 || segmentLength % 2 != 1)
                {
                    return false;
                }

                output = ResourceIdScope.Create(
                    pathSegments.First(),
                    pathSegments.Skip(1).Where((_, i) => i % 2 == 0),
                    pathSegments.Skip(1).Where((_, i) => i % 2 == 1));
                return true;
            }

            /// <summary>
            /// Creates a new <see cref="ResourceIdScope"/>
            /// </summary>
            /// <param name="providerNamespace">The provider namespace</param>
            /// <param name="typeHierarchy">The type hierarchy</param>
            /// <param name="nameHierarchy">The name hierarchy</param>
            public static ResourceIdScope Create(string providerNamespace, IEnumerable<string> typeHierarchy, IEnumerable<string> nameHierarchy)
                => new ResourceIdScope(
                    providerNamespace: providerNamespace,
                    typeHierarchy: typeHierarchy.ToList(),
                    nameHierarchy: nameHierarchy.ToList());

            /// <summary>
            /// Gets the provider namespace
            /// </summary>
            public string ProviderNamespace { get; }

            /// <summary>
            /// Gets the type hierarchy
            /// </summary>
            public IReadOnlyList<string> TypeHierarchy { get; }

            /// <summary>
            /// Gets the name hierarchy
            /// </summary>
            public IReadOnlyList<string> NameHierarchy { get; }

            /// <summary>
            /// Gets whether this is a root resource Id
            /// </summary>
            public bool IsRootResource => this.TypeHierarchy.Count == 1;

            /// <summary>
            /// Formats the unqualified resource Id string
            /// </summary>
            public string FormatUnqualifiedId()
                => $"{this.ProviderNamespace}/{FormatTypeName(this.TypeHierarchy, this.NameHierarchy)}";

            /// <summary>
            /// Formats the fully qualified resource type string
            /// </summary>
            public string FormatFullyQualifiedType()
                => $"{this.ProviderNamespace}/{this.FormatType()}";

            /// <summary>
            /// Formats the resource name string
            /// </summary>
            public string FormatName()
                => this.NameHierarchy.ConcatStrings("/");

            /// <summary>
            /// Formats the resource type string
            /// </summary>
            public string FormatType()
                => this.TypeHierarchy.ConcatStrings("/");

            /// <summary>
            /// Generates the string of type/name pairs
            /// </summary>
            /// <param name="typeHierarchy">The resource type hierarchy</param>
            /// <param name="nameHierarchy">The resource name hierarchy</param>
            private static string FormatTypeName(IEnumerable<string> typeHierarchy, IEnumerable<string> nameHierarchy)
                => typeHierarchy.Zip(nameHierarchy, (type, name) => $"{type}/{name}").ConcatStrings("/");

            /// <summary>
            /// Enumerates the parent resource Ids
            /// </summary>
            /// <param name="orderByDepthAscending">Order by depth ascending?</param>
            public IEnumerable<ResourceIdScope> GetParents(bool orderByDepthAscending)
            {
                if (orderByDepthAscending)
                {
                    for (var i = 1; i < this.TypeHierarchy.Count; i++)
                    {
                        yield return ResourceIdScope.Create(
                            providerNamespace: this.ProviderNamespace,
                            typeHierarchy: this.TypeHierarchy.Take(i),
                            nameHierarchy: this.NameHierarchy.Take(i));
                    }
                }
                else
                {
                    for (var i = this.TypeHierarchy.Count - 1; i > 0; i--)
                    {
                        yield return ResourceIdScope.Create(
                            providerNamespace: this.ProviderNamespace,
                            typeHierarchy: this.TypeHierarchy.Take(i),
                            nameHierarchy: this.NameHierarchy.Take(i));
                    }
                }
            }

            /// <summary>
            /// Generates a child resource Id
            /// </summary>
            /// <param name="nestedType">The last segment of the child resource type</param>
            /// <param name="nestedName">The last segment of the child resource name</param>
            public ResourceIdScope GetChild(string nestedType, string nestedName)
                => ResourceIdScope.Create(
                    providerNamespace: this.ProviderNamespace,
                    typeHierarchy: this.TypeHierarchy.Concat(new[] { nestedType }),
                    nameHierarchy: this.NameHierarchy.Concat(new[] { nestedName }));

            /// <summary>
            /// Overrides <see cref="ToString"/>.
            /// </summary>
            public override string ToString() => this.FormatUnqualifiedId();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceId"/> class
        /// </summary>
        /// <param name="routingScope">The routing scope</param>
        /// <param name="parentScopes">The parent scopes</param>
        /// <param name="fullyQualifiedId">The fully-qualified resource Id</param>
        protected ResourceId(ResourceIdScope routingScope, IEnumerable<ResourceIdScope> parentScopes, string fullyQualifiedId)
        {
            this.RoutingScope = routingScope;
            this.ParentScopes = parentScopes;
            this.FullyQualifiedId = fullyQualifiedId;
        }

        /// <summary>
        /// Gets the parent scopes
        /// </summary>
        protected IEnumerable<ResourceIdScope> ParentScopes { get; }

        /// <summary>
        /// Gets the routing scope
        /// </summary>
        protected ResourceIdScope RoutingScope { get; }

        /// <summary>
        /// Gets the fully-qualified resource Id
        /// </summary>
        public string FullyQualifiedId { get; }

        /// <summary>
        /// Gets whether this is an extension resource Id
        /// </summary>
        public bool IsExtensionResource => this.ParentScopes.Any();

        /// <summary>
        /// Gets whether this is a root resource Id
        /// </summary>
        public bool IsRootResource => this.RoutingScope.IsRootResource;

        /// <summary>
        /// Gets the provider namespace
        /// </summary>
        public string ProviderNamespace => this.RoutingScope.ProviderNamespace;

        /// <summary>
        /// Gets the name hierarchy
        /// </summary>
        public IEnumerable<string> NameHierarchy => this.RoutingScope.NameHierarchy;

        /// <summary>
        /// Gets the type hierarchy
        /// </summary>
        public IEnumerable<string> TypeHierarchy => this.RoutingScope.TypeHierarchy;

        /// <summary>
        /// Gets the fully-qualified type
        /// </summary>
        public string FormatFullyQualifiedType() => this.RoutingScope.FormatFullyQualifiedType();

        /// <summary>
        /// Gets the fully-qualified type
        /// </summary>
        public string FormatName() => this.RoutingScope.FormatName();

        /// <summary>
        /// Gets the fully-qualified type
        /// </summary>
        public string FormatType() => this.RoutingScope.FormatType();

        /// <summary>
        /// Overrides <see cref="ToString"/>.
        /// </summary>
        public override string ToString() => this.FullyQualifiedId;

        #region Parsing
        /// <summary>
        /// Formats the unqualified id string
        /// </summary>
        /// <param name="routingScope">The routing scope</param>
        /// <param name="parentScopes">The parent scopes</param>
        protected static string FormatUnqualifiedId(ResourceIdScope routingScope, IEnumerable<ResourceIdScope> parentScopes)
            => parentScopes.Select(s => s.FormatUnqualifiedId()).Concat(new[] { routingScope.FormatUnqualifiedId() }).ConcatStrings("/providers/");

        /// <summary>
        /// Creates a new <see cref="ResourceId"/>
        /// </summary>
        /// <param name="resourceId">The fully-qualified resource Id</param>
        /// <param name="output">The resource Id</param>
        public static bool TryParse(string resourceId, out ResourceId output)
        {
            ResourceGroupLevelResourceId groupLevelResourceId;
            if (ResourceGroupLevelResourceId.TryParse(resourceId, out groupLevelResourceId))
            {
                output = groupLevelResourceId;
                return true;
            }

            SubscriptionLevelResourceId subscriptionLevelResourceId;
            if (SubscriptionLevelResourceId.TryParse(resourceId, out subscriptionLevelResourceId))
            {
                output = subscriptionLevelResourceId;
                return true;
            }

            TenantLevelResourceId tenantLevelResourceId;
            if (TenantLevelResourceId.TryParse(resourceId, out tenantLevelResourceId))
            {
                output = tenantLevelResourceId;
                return true;
            }

            output = null;
            return false;
        }

        /// <summary>
        /// Parses resource scopes from a list of path segments
        /// </summary>
        /// <param name="pathSegments">The scope path segments</param>
        /// <param name="startIndex">The scope start index</param>
        /// <param name="routingScope">The scope</param>
        /// <param name="parentScopes">The parent scopes</param>
        protected static bool TryParseResourceScopes(IReadOnlyList<string> pathSegments, int startIndex, out ResourceIdScope routingScope, out IEnumerable<ResourceIdScope> parentScopes)
        {
            routingScope = null;
            parentScopes = null;

            var segmentLength = pathSegments.Count - startIndex;
            if (segmentLength < 2 || segmentLength % 2 != 0)
            {
                return false;
            }

            var providerIndices = Enumerable.Range(startIndex, segmentLength).Where(i => i % 2 == 0 && StringComparer.OrdinalIgnoreCase.Equals(pathSegments[i], "providers"));
            if (!providerIndices.Any())
            {
                return false;
            }

            var allScopes = providerIndices.Zip(
                providerIndices.Skip(1).Concat(new[] { pathSegments.Count }),
                (start, end) =>
                {
                    var scopeSegments = pathSegments.Skip(start + 1).Take(end - start - 1);
                    ResourceIdScope scope;
                    if (!ResourceIdScope.TryParse(scopeSegments, out scope))
                    {
                        return null;
                    }

                    return scope;
                });

            if (allScopes.Any(scope => scope == null))
            {
                return false;
            }

            routingScope = allScopes.Last();
            parentScopes = allScopes.Take(allScopes.Count() - 1);
            return true;
        }
        #endregion
    }
}