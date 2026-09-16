// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>The response of a BookshelfPrivateLinkResource list operation.</summary>
    public partial class BookshelfPrivateLinkResourceListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPrivateLinkResourceListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPrivateLinkResourceListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPrivateLinkResource> _value;

        /// <summary>The BookshelfPrivateLinkResource items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPrivateLinkResource> Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="BookshelfPrivateLinkResourceListResult" /> instance.</summary>
        public BookshelfPrivateLinkResourceListResult()
        {

        }
    }
    /// The response of a BookshelfPrivateLinkResource list operation.
    public partial interface IBookshelfPrivateLinkResourceListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The link to the next page of items",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The BookshelfPrivateLinkResource items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The BookshelfPrivateLinkResource items on this page",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPrivateLinkResource) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPrivateLinkResource> Value { get; set; }

    }
    /// The response of a BookshelfPrivateLinkResource list operation.
    internal partial interface IBookshelfPrivateLinkResourceListResultInternal

    {
        /// <summary>The link to the next page of items</summary>
        string NextLink { get; set; }
        /// <summary>The BookshelfPrivateLinkResource items on this page</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPrivateLinkResource> Value { get; set; }

    }
}