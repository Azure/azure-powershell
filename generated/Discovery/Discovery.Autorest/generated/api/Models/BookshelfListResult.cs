// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>The response of a Bookshelf list operation.</summary>
    public partial class BookshelfListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link to the next page of items</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelf> _value;

        /// <summary>The Bookshelf items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelf> Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="BookshelfListResult" /> instance.</summary>
        public BookshelfListResult()
        {

        }
    }
    /// The response of a Bookshelf list operation.
    public partial interface IBookshelfListResult :
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
        /// <summary>The Bookshelf items on this page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Bookshelf items on this page",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelf) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelf> Value { get; set; }

    }
    /// The response of a Bookshelf list operation.
    internal partial interface IBookshelfListResultInternal

    {
        /// <summary>The link to the next page of items</summary>
        string NextLink { get; set; }
        /// <summary>The Bookshelf items on this page</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelf> Value { get; set; }

    }
}