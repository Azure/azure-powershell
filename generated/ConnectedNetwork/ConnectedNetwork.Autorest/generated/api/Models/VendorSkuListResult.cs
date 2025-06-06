// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Runtime.Extensions;

    /// <summary>Response for list vendor sku API service call.</summary>
    public partial class VendorSkuListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IVendorSkuListResult,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IVendorSkuListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IVendorSkuListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URI to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IVendorSku> _value;

        /// <summary>A list of vendor skus offered by the vendor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IVendorSku> Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="VendorSkuListResult" /> instance.</summary>
        public VendorSkuListResult()
        {

        }
    }
    /// Response for list vendor sku API service call.
    public partial interface IVendorSkuListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Runtime.IJsonSerializable
    {
        /// <summary>The URI to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The URI to get the next set of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>A list of vendor skus offered by the vendor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A list of vendor skus offered by the vendor.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IVendorSku) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IVendorSku> Value { get; set; }

    }
    /// Response for list vendor sku API service call.
    internal partial interface IVendorSkuListResultInternal

    {
        /// <summary>The URI to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>A list of vendor skus offered by the vendor.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IVendorSku> Value { get; set; }

    }
}