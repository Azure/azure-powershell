// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>The marketplace sku version</summary>
    public partial class MarketplaceSkuVersion :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSkuVersion,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSkuVersionInternal
    {

        /// <summary>Backing field for <see cref="LaunchType" /> property.</summary>
        private string _launchType;

        /// <summary>The launch type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string LaunchType { get => this._launchType; set => this._launchType = value; }

        /// <summary>Backing field for <see cref="MinimumDownloadSizeInMb" /> property.</summary>
        private int? _minimumDownloadSizeInMb;

        /// <summary>The size of the download</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public int? MinimumDownloadSizeInMb { get => this._minimumDownloadSizeInMb; set => this._minimumDownloadSizeInMb = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of sku version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="SizeOnDiskInMb" /> property.</summary>
        private int? _sizeOnDiskInMb;

        /// <summary>The size of the image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public int? SizeOnDiskInMb { get => this._sizeOnDiskInMb; set => this._sizeOnDiskInMb = value; }

        /// <summary>Backing field for <see cref="StageName" /> property.</summary>
        private string _stageName;

        /// <summary>The stage name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string StageName { get => this._stageName; set => this._stageName = value; }

        /// <summary>Creates an new <see cref="MarketplaceSkuVersion" /> instance.</summary>
        public MarketplaceSkuVersion()
        {

        }
    }
    /// The marketplace sku version
    public partial interface IMarketplaceSkuVersion :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IJsonSerializable
    {
        /// <summary>The launch type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The launch type",
        SerializedName = @"launchType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PSArgumentCompleterAttribute("Trusted", "Unknown")]
        string LaunchType { get; set; }
        /// <summary>The size of the download</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The size of the download",
        SerializedName = @"minimumDownloadSizeInMb",
        PossibleTypes = new [] { typeof(int) })]
        int? MinimumDownloadSizeInMb { get; set; }
        /// <summary>The name of sku version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of sku version",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The size of the image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The size of the image",
        SerializedName = @"sizeOnDiskInMb",
        PossibleTypes = new [] { typeof(int) })]
        int? SizeOnDiskInMb { get; set; }
        /// <summary>The stage name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The stage name",
        SerializedName = @"stageName",
        PossibleTypes = new [] { typeof(string) })]
        string StageName { get; set; }

    }
    /// The marketplace sku version
    internal partial interface IMarketplaceSkuVersionInternal

    {
        /// <summary>The launch type</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PSArgumentCompleterAttribute("Trusted", "Unknown")]
        string LaunchType { get; set; }
        /// <summary>The size of the download</summary>
        int? MinimumDownloadSizeInMb { get; set; }
        /// <summary>The name of sku version</summary>
        string Name { get; set; }
        /// <summary>The size of the image</summary>
        int? SizeOnDiskInMb { get; set; }
        /// <summary>The stage name</summary>
        string StageName { get; set; }

    }
}