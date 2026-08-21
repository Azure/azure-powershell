// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>The sku operating system</summary>
    public partial class SkuOperatingSystem :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ISkuOperatingSystem,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ISkuOperatingSystemInternal
    {

        /// <summary>Backing field for <see cref="Family" /> property.</summary>
        private string _family;

        /// <summary>The family of the operating system</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Family { get => this._family; set => this._family = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the operating system</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The type of the operating system</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="SkuOperatingSystem" /> instance.</summary>
        public SkuOperatingSystem()
        {

        }
    }
    /// The sku operating system
    public partial interface ISkuOperatingSystem :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IJsonSerializable
    {
        /// <summary>The family of the operating system</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The family of the operating system",
        SerializedName = @"family",
        PossibleTypes = new [] { typeof(string) })]
        string Family { get; set; }
        /// <summary>The name of the operating system</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the operating system",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The type of the operating system</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of the operating system",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// The sku operating system
    internal partial interface ISkuOperatingSystemInternal

    {
        /// <summary>The family of the operating system</summary>
        string Family { get; set; }
        /// <summary>The name of the operating system</summary>
        string Name { get; set; }
        /// <summary>The type of the operating system</summary>
        string Type { get; set; }

    }
}