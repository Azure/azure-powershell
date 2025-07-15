// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Extensions;

    /// <summary>The type used for updating tags in MapsResource resources.</summary>
    public partial class MapsResourceTagsUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IMapsResourceTagsUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IMapsResourceTagsUpdateInternal
    {

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.ITags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.ITags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.Tags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="MapsResourceTagsUpdate" /> instance.</summary>
        public MapsResourceTagsUpdate()
        {

        }
    }
    /// The type used for updating tags in MapsResource resources.
    public partial interface IMapsResourceTagsUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.IJsonSerializable
    {
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.ITags) })]
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.ITags Tag { get; set; }

    }
    /// The type used for updating tags in MapsResource resources.
    internal partial interface IMapsResourceTagsUpdateInternal

    {
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.ITags Tag { get; set; }

    }
}