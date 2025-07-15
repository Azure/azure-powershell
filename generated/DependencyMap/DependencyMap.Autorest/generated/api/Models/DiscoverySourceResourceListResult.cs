// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Extensions;

    /// <summary>The response of a DiscoverySourceResource list operation.</summary>
    public partial class DiscoverySourceResourceListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourceListResult,
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResourceListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResource> _value;

        /// <summary>The DiscoverySourceResource items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResource> Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="DiscoverySourceResourceListResult" /> instance.</summary>
        public DiscoverySourceResourceListResult()
        {

        }
    }
    /// The response of a DiscoverySourceResource list operation.
    public partial interface IDiscoverySourceResourceListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.IJsonSerializable
    {
        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The link to the next page of items",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The DiscoverySourceResource items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The DiscoverySourceResource items on this page",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResource) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResource> Value { get; set; }

    }
    /// The response of a DiscoverySourceResource list operation.
    internal partial interface IDiscoverySourceResourceListResultInternal

    {
        /// <summary>The link to the next page of items</summary>
        string NextLink { get; set; }
        /// <summary>The DiscoverySourceResource items on this page</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDiscoverySourceResource> Value { get; set; }

    }
}