// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>Details about the location requested and the available skus in the location</summary>
    public partial class RegionSkuDetail :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.IRegionSkuDetail,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.IRegionSkuDetailInternal
    {

        /// <summary>Backing field for <see cref="LocationInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ILocationInfo _locationInfo;

        /// <summary>Details about location and its capabilities</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ILocationInfo LocationInfo { get => (this._locationInfo = this._locationInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.LocationInfo()); set => this._locationInfo = value; }

        /// <summary>List of capabilities</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ICapability[] LocationInfoCapability { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ILocationInfoInternal)LocationInfo).Capability; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ILocationInfoInternal)LocationInfo).Capability = value ?? null /* arrayOf */; }

        /// <summary>Location name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public string LocationInfoLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ILocationInfoInternal)LocationInfo).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ILocationInfoInternal)LocationInfo).Location = value ?? null; }

        /// <summary>Internal Acessors for LocationInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ILocationInfo Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.IRegionSkuDetailInternal.LocationInfo { get => (this._locationInfo = this._locationInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.LocationInfo()); set { {_locationInfo = value;} } }

        /// <summary>Internal Acessors for SkuDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ISkuDetail Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.IRegionSkuDetailInternal.SkuDetail { get => (this._skuDetail = this._skuDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.SkuDetail()); set { {_skuDetail = value;} } }

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private string _resourceType;

        /// <summary>Resource type which has the SKU, such as Microsoft.Cache/redisEnterprise</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public string ResourceType { get => this._resourceType; set => this._resourceType = value; }

        /// <summary>Backing field for <see cref="SkuDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ISkuDetail _skuDetail;

        /// <summary>Details about available skus</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ISkuDetail SkuDetail { get => (this._skuDetail = this._skuDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.SkuDetail()); set => this._skuDetail = value; }

        /// <summary>
        /// The type of RedisEnterprise cluster to deploy. Possible values: (Enterprise_E10, EnterpriseFlash_F300 etc.)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.SkuName? SkuDetailName { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ISkuDetailInternal)SkuDetail).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ISkuDetailInternal)SkuDetail).Name = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.SkuName)""); }

        /// <summary>Creates an new <see cref="RegionSkuDetail" /> instance.</summary>
        public RegionSkuDetail()
        {

        }
    }
    /// Details about the location requested and the available skus in the location
    public partial interface IRegionSkuDetail :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IJsonSerializable
    {
        /// <summary>List of capabilities</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of capabilities",
        SerializedName = @"capabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ICapability) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ICapability[] LocationInfoCapability { get; set; }
        /// <summary>Location name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Location name",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string LocationInfoLocation { get; set; }
        /// <summary>Resource type which has the SKU, such as Microsoft.Cache/redisEnterprise</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource type which has the SKU, such as Microsoft.Cache/redisEnterprise",
        SerializedName = @"resourceType",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceType { get; set; }
        /// <summary>
        /// The type of RedisEnterprise cluster to deploy. Possible values: (Enterprise_E10, EnterpriseFlash_F300 etc.)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of RedisEnterprise cluster to deploy. Possible values: (Enterprise_E10, EnterpriseFlash_F300 etc.)",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.SkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.SkuName? SkuDetailName { get; set; }

    }
    /// Details about the location requested and the available skus in the location
    internal partial interface IRegionSkuDetailInternal

    {
        /// <summary>Details about location and its capabilities</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ILocationInfo LocationInfo { get; set; }
        /// <summary>List of capabilities</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ICapability[] LocationInfoCapability { get; set; }
        /// <summary>Location name</summary>
        string LocationInfoLocation { get; set; }
        /// <summary>Resource type which has the SKU, such as Microsoft.Cache/redisEnterprise</summary>
        string ResourceType { get; set; }
        /// <summary>Details about available skus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20230301Preview.ISkuDetail SkuDetail { get; set; }
        /// <summary>
        /// The type of RedisEnterprise cluster to deploy. Possible values: (Enterprise_E10, EnterpriseFlash_F300 etc.)
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.SkuName? SkuDetailName { get; set; }

    }
}