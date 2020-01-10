namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Network interface and its custom security rules.</summary>
    public partial class NetworkInterfaceAssociation :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociation,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociationInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Network interface ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociationInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Backing field for <see cref="SecurityRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] _securityRule;

        /// <summary>Collection of custom security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SecurityRule { get => this._securityRule; set => this._securityRule = value; }

        /// <summary>Creates an new <see cref="NetworkInterfaceAssociation" /> instance.</summary>
        public NetworkInterfaceAssociation()
        {

        }
    }
    /// Network interface and its custom security rules.
    public partial interface INetworkInterfaceAssociation :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Network interface ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Network interface ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Collection of custom security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of custom security rules.",
        SerializedName = @"securityRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SecurityRule { get; set; }

    }
    /// Network interface and its custom security rules.
    internal partial interface INetworkInterfaceAssociationInternal

    {
        /// <summary>Network interface ID.</summary>
        string Id { get; set; }
        /// <summary>Collection of custom security rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SecurityRule { get; set; }

    }
}