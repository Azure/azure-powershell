// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Virtual network subnet usage parameter</summary>
    public partial class VirtualNetworkSubnetUsageParameter :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualNetworkSubnetUsageParameter,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualNetworkSubnetUsageParameterInternal
    {

        /// <summary>Backing field for <see cref="VirtualNetworkArmResourceId" /> property.</summary>
        private string _virtualNetworkArmResourceId;

        /// <summary>Virtual network resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string VirtualNetworkArmResourceId { get => this._virtualNetworkArmResourceId; set => this._virtualNetworkArmResourceId = value; }

        /// <summary>Creates an new <see cref="VirtualNetworkSubnetUsageParameter" /> instance.</summary>
        public VirtualNetworkSubnetUsageParameter()
        {

        }
    }
    /// Virtual network subnet usage parameter
    public partial interface IVirtualNetworkSubnetUsageParameter :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Virtual network resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Virtual network resource id.",
        SerializedName = @"virtualNetworkArmResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkArmResourceId { get; set; }

    }
    /// Virtual network subnet usage parameter
    internal partial interface IVirtualNetworkSubnetUsageParameterInternal

    {
        /// <summary>Virtual network resource id.</summary>
        string VirtualNetworkArmResourceId { get; set; }

    }
}