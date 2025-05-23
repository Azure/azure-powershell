// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Runtime.Extensions;

    /// <summary>Request payload used to update an existing resource's tags.</summary>
    public partial class TagUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Models.ITagUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Models.ITagUpdateInternal
    {

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Models.ITagUpdateTags _tag;

        /// <summary>
        /// List of key value pairs that describe the resource. This will overwrite the existing tags.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.GraphServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Models.ITagUpdateTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Models.TagUpdateTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="TagUpdate" /> instance.</summary>
        public TagUpdate()
        {

        }
    }
    /// Request payload used to update an existing resource's tags.
    public partial interface ITagUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Runtime.IJsonSerializable
    {
        /// <summary>
        /// List of key value pairs that describe the resource. This will overwrite the existing tags.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of key value pairs that describe the resource. This will overwrite the existing tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Models.ITagUpdateTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Models.ITagUpdateTags Tag { get; set; }

    }
    /// Request payload used to update an existing resource's tags.
    internal partial interface ITagUpdateInternal

    {
        /// <summary>
        /// List of key value pairs that describe the resource. This will overwrite the existing tags.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Models.ITagUpdateTags Tag { get; set; }

    }
}