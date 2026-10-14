// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Network properties of a server.</summary>
    public partial class Network :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetwork,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.INetworkInternal
    {

        /// <summary>Backing field for <see cref="DelegatedSubnetResourceId" /> property.</summary>
        private string _delegatedSubnetResourceId;

        /// <summary>
        /// Resource identifier of the delegated subnet. Required during creation of a new server, in case you want the server to
        /// be integrated into your own virtual network. For an update operation, you only have to provide this property if you want
        /// to change the value assigned for the private DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string DelegatedSubnetResourceId { get => this._delegatedSubnetResourceId; set => this._delegatedSubnetResourceId = value; }

        /// <summary>Backing field for <see cref="PrivateDnsZoneArmResourceId" /> property.</summary>
        private string _privateDnsZoneArmResourceId;

        /// <summary>
        /// Identifier of the private DNS zone. Required during creation of a new server, in case you want the server to be integrated
        /// into your own virtual network. For an update operation, you only have to provide this property if you want to change the
        /// value assigned for the private DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string PrivateDnsZoneArmResourceId { get => this._privateDnsZoneArmResourceId; set => this._privateDnsZoneArmResourceId = value; }

        /// <summary>Backing field for <see cref="PublicNetworkAccess" /> property.</summary>
        private string _publicNetworkAccess;

        /// <summary>
        /// Indicates if public network access is enabled or not. This is only supported for servers that are not integrated into
        /// a virtual network which is owned and provided by customer when server is deployed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string PublicNetworkAccess { get => this._publicNetworkAccess; set => this._publicNetworkAccess = value; }

        /// <summary>Creates an new <see cref="Network" /> instance.</summary>
        public Network()
        {

        }
    }
    /// Network properties of a server.
    public partial interface INetwork :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Resource identifier of the delegated subnet. Required during creation of a new server, in case you want the server to
        /// be integrated into your own virtual network. For an update operation, you only have to provide this property if you want
        /// to change the value assigned for the private DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource identifier of the delegated subnet. Required during creation of a new server, in case you want the server to be integrated into your own virtual network. For an update operation, you only have to provide this property if you want to change the value assigned for the private DNS zone.",
        SerializedName = @"delegatedSubnetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string DelegatedSubnetResourceId { get; set; }
        /// <summary>
        /// Identifier of the private DNS zone. Required during creation of a new server, in case you want the server to be integrated
        /// into your own virtual network. For an update operation, you only have to provide this property if you want to change the
        /// value assigned for the private DNS zone.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the private DNS zone. Required during creation of a new server, in case you want the server to be integrated into your own virtual network. For an update operation, you only have to provide this property if you want to change the value assigned for the private DNS zone.",
        SerializedName = @"privateDnsZoneArmResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateDnsZoneArmResourceId { get; set; }
        /// <summary>
        /// Indicates if public network access is enabled or not. This is only supported for servers that are not integrated into
        /// a virtual network which is owned and provided by customer when server is deployed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if public network access is enabled or not. This is only supported for servers that are not integrated into a virtual network which is owned and provided by customer when server is deployed.",
        SerializedName = @"publicNetworkAccess",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PublicNetworkAccess { get; set; }

    }
    /// Network properties of a server.
    internal partial interface INetworkInternal

    {
        /// <summary>
        /// Resource identifier of the delegated subnet. Required during creation of a new server, in case you want the server to
        /// be integrated into your own virtual network. For an update operation, you only have to provide this property if you want
        /// to change the value assigned for the private DNS zone.
        /// </summary>
        string DelegatedSubnetResourceId { get; set; }
        /// <summary>
        /// Identifier of the private DNS zone. Required during creation of a new server, in case you want the server to be integrated
        /// into your own virtual network. For an update operation, you only have to provide this property if you want to change the
        /// value assigned for the private DNS zone.
        /// </summary>
        string PrivateDnsZoneArmResourceId { get; set; }
        /// <summary>
        /// Indicates if public network access is enabled or not. This is only supported for servers that are not integrated into
        /// a virtual network which is owned and provided by customer when server is deployed.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PublicNetworkAccess { get; set; }

    }
}