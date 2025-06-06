// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20250501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>The response of a listSkusForScaling operation.</summary>
    public partial class SkuDetailsList :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20250501Preview.ISkuDetailsList,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20250501Preview.ISkuDetailsListInternal
    {

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20250501Preview.ISkuDetails[] _sku;

        /// <summary>List of SKUS available to scale up or scale down.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20250501Preview.ISkuDetails[] Sku { get => this._sku; set => this._sku = value; }

        /// <summary>Creates an new <see cref="SkuDetailsList" /> instance.</summary>
        public SkuDetailsList()
        {

        }
    }
    /// The response of a listSkusForScaling operation.
    public partial interface ISkuDetailsList :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IJsonSerializable
    {
        /// <summary>List of SKUS available to scale up or scale down.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of SKUS available to scale up or scale down.",
        SerializedName = @"skus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20250501Preview.ISkuDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20250501Preview.ISkuDetails[] Sku { get; set; }

    }
    /// The response of a listSkusForScaling operation.
    internal partial interface ISkuDetailsListInternal

    {
        /// <summary>List of SKUS available to scale up or scale down.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20250501Preview.ISkuDetails[] Sku { get; set; }

    }
}