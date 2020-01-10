namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>All security rules associated with the network interface.</summary>
    public partial class SecurityRuleAssociations :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociations,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal
    {

        /// <summary>Backing field for <see cref="DefaultSecurityRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] _defaultSecurityRule;

        /// <summary>Collection of default security rules of the network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] DefaultSecurityRule { get => this._defaultSecurityRule; set => this._defaultSecurityRule = value; }

        /// <summary>Backing field for <see cref="EffectiveSecurityRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule[] _effectiveSecurityRule;

        /// <summary>Collection of effective security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule[] EffectiveSecurityRule { get => this._effectiveSecurityRule; set => this._effectiveSecurityRule = value; }

        /// <summary>Internal Acessors for NetworkInterfaceAssociation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociation Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal.NetworkInterfaceAssociation { get => (this._networkInterfaceAssociation = this._networkInterfaceAssociation ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkInterfaceAssociation()); set { {_networkInterfaceAssociation = value;} } }

        /// <summary>Internal Acessors for NetworkInterfaceAssociationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal.NetworkInterfaceAssociationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociationInternal)NetworkInterfaceAssociation).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociationInternal)NetworkInterfaceAssociation).Id = value; }

        /// <summary>Internal Acessors for SubnetAssociation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetAssociation Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal.SubnetAssociation { get => (this._subnetAssociation = this._subnetAssociation ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubnetAssociation()); set { {_subnetAssociation = value;} } }

        /// <summary>Internal Acessors for SubnetAssociationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal.SubnetAssociationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetAssociationInternal)SubnetAssociation).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetAssociationInternal)SubnetAssociation).Id = value; }

        /// <summary>Backing field for <see cref="NetworkInterfaceAssociation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociation _networkInterfaceAssociation;

        /// <summary>Network interface and it's custom security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociation NetworkInterfaceAssociation { get => (this._networkInterfaceAssociation = this._networkInterfaceAssociation ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkInterfaceAssociation()); set => this._networkInterfaceAssociation = value; }

        /// <summary>Network interface ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NetworkInterfaceAssociationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociationInternal)NetworkInterfaceAssociation).Id; }

        /// <summary>Collection of custom security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] NetworkInterfaceAssociationSecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociationInternal)NetworkInterfaceAssociation).SecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociationInternal)NetworkInterfaceAssociation).SecurityRule = value; }

        /// <summary>Backing field for <see cref="SubnetAssociation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetAssociation _subnetAssociation;

        /// <summary>Subnet and it's custom security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetAssociation SubnetAssociation { get => (this._subnetAssociation = this._subnetAssociation ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubnetAssociation()); set => this._subnetAssociation = value; }

        /// <summary>Subnet ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SubnetAssociationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetAssociationInternal)SubnetAssociation).Id; }

        /// <summary>Collection of custom security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SubnetAssociationSecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetAssociationInternal)SubnetAssociation).SecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetAssociationInternal)SubnetAssociation).SecurityRule = value; }

        /// <summary>Creates an new <see cref="SecurityRuleAssociations" /> instance.</summary>
        public SecurityRuleAssociations()
        {

        }
    }
    /// All security rules associated with the network interface.
    public partial interface ISecurityRuleAssociations :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Collection of default security rules of the network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of default security rules of the network security group.",
        SerializedName = @"defaultSecurityRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] DefaultSecurityRule { get; set; }
        /// <summary>Collection of effective security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of effective security rules.",
        SerializedName = @"effectiveSecurityRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule[] EffectiveSecurityRule { get; set; }
        /// <summary>Network interface ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Network interface ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkInterfaceAssociationId { get;  }
        /// <summary>Collection of custom security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of custom security rules.",
        SerializedName = @"securityRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] NetworkInterfaceAssociationSecurityRule { get; set; }
        /// <summary>Subnet ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Subnet ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetAssociationId { get;  }
        /// <summary>Collection of custom security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of custom security rules.",
        SerializedName = @"securityRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SubnetAssociationSecurityRule { get; set; }

    }
    /// All security rules associated with the network interface.
    internal partial interface ISecurityRuleAssociationsInternal

    {
        /// <summary>Collection of default security rules of the network security group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] DefaultSecurityRule { get; set; }
        /// <summary>Collection of effective security rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule[] EffectiveSecurityRule { get; set; }
        /// <summary>Network interface and it's custom security rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociation NetworkInterfaceAssociation { get; set; }
        /// <summary>Network interface ID.</summary>
        string NetworkInterfaceAssociationId { get; set; }
        /// <summary>Collection of custom security rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] NetworkInterfaceAssociationSecurityRule { get; set; }
        /// <summary>Subnet and it's custom security rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetAssociation SubnetAssociation { get; set; }
        /// <summary>Subnet ID.</summary>
        string SubnetAssociationId { get; set; }
        /// <summary>Collection of custom security rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SubnetAssociationSecurityRule { get; set; }

    }
}