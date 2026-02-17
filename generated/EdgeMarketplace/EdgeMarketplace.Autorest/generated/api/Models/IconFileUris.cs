// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>Icon files</summary>
    public partial class IconFileUris :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUris,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUrisInternal
    {

        /// <summary>Backing field for <see cref="Large" /> property.</summary>
        private string _large;

        /// <summary>uri of large icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Large { get => this._large; set => this._large = value; }

        /// <summary>Backing field for <see cref="Medium" /> property.</summary>
        private string _medium;

        /// <summary>uri of medium icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Medium { get => this._medium; set => this._medium = value; }

        /// <summary>Backing field for <see cref="Small" /> property.</summary>
        private string _small;

        /// <summary>uri of small icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Small { get => this._small; set => this._small = value; }

        /// <summary>Backing field for <see cref="Wide" /> property.</summary>
        private string _wide;

        /// <summary>uri of wide icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Wide { get => this._wide; set => this._wide = value; }

        /// <summary>Creates an new <see cref="IconFileUris" /> instance.</summary>
        public IconFileUris()
        {

        }
    }
    /// Icon files
    public partial interface IIconFileUris :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IJsonSerializable
    {
        /// <summary>uri of large icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"uri of large icon",
        SerializedName = @"large",
        PossibleTypes = new [] { typeof(string) })]
        string Large { get; set; }
        /// <summary>uri of medium icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"uri of medium icon",
        SerializedName = @"medium",
        PossibleTypes = new [] { typeof(string) })]
        string Medium { get; set; }
        /// <summary>uri of small icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"uri of small icon",
        SerializedName = @"small",
        PossibleTypes = new [] { typeof(string) })]
        string Small { get; set; }
        /// <summary>uri of wide icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"uri of wide icon",
        SerializedName = @"wide",
        PossibleTypes = new [] { typeof(string) })]
        string Wide { get; set; }

    }
    /// Icon files
    internal partial interface IIconFileUrisInternal

    {
        /// <summary>uri of large icon</summary>
        string Large { get; set; }
        /// <summary>uri of medium icon</summary>
        string Medium { get; set; }
        /// <summary>uri of small icon</summary>
        string Small { get; set; }
        /// <summary>uri of wide icon</summary>
        string Wide { get; set; }

    }
}