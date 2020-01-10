namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Network interface and all its associated security rules.</summary>
    public partial class SecurityGroupNetworkInterface :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterface,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>ID of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Internal Acessors for NetworkInterfaceAssociationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal.NetworkInterfaceAssociationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).NetworkInterfaceAssociationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).NetworkInterfaceAssociationId = value; }

        /// <summary>Internal Acessors for SecurityRuleAssociation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociations Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal.SecurityRuleAssociation { get => (this._securityRuleAssociation = this._securityRuleAssociation ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRuleAssociations()); set { {_securityRuleAssociation = value;} } }

        /// <summary>Internal Acessors for SecurityRuleAssociationNetworkInterfaceAssociation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociation Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal.SecurityRuleAssociationNetworkInterfaceAssociation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).NetworkInterfaceAssociation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).NetworkInterfaceAssociation = value; }

        /// <summary>Internal Acessors for SecurityRuleAssociationSubnetAssociation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetAssociation Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal.SecurityRuleAssociationSubnetAssociation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).SubnetAssociation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).SubnetAssociation = value; }

        /// <summary>Internal Acessors for SubnetAssociationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal.SubnetAssociationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).SubnetAssociationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).SubnetAssociationId = value; }

        /// <summary>Network interface ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NetworkInterfaceAssociationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).NetworkInterfaceAssociationId; }

        /// <summary>Collection of custom security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] NetworkInterfaceAssociationSecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).NetworkInterfaceAssociationSecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).NetworkInterfaceAssociationSecurityRule = value; }

        /// <summary>Backing field for <see cref="SecurityRuleAssociation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociations _securityRuleAssociation;

        /// <summary>All security rules associated with the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociations SecurityRuleAssociation { get => (this._securityRuleAssociation = this._securityRuleAssociation ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRuleAssociations()); set => this._securityRuleAssociation = value; }

        /// <summary>Collection of default security rules of the network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SecurityRuleAssociationDefaultSecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).DefaultSecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).DefaultSecurityRule = value; }

        /// <summary>Collection of effective security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule[] SecurityRuleAssociationEffectiveSecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).EffectiveSecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).EffectiveSecurityRule = value; }

        /// <summary>Subnet ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SubnetAssociationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).SubnetAssociationId; }

        /// <summary>Collection of custom security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SubnetAssociationSecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).SubnetAssociationSecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociationsInternal)SecurityRuleAssociation).SubnetAssociationSecurityRule = value; }

        /// <summary>Creates an new <see cref="SecurityGroupNetworkInterface" /> instance.</summary>
        public SecurityGroupNetworkInterface()
        {

        }
    }
    /// Network interface and all its associated security rules.
    public partial interface ISecurityGroupNetworkInterface :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>ID of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ID of the network interface.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
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
        /// <summary>Collection of default security rules of the network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of default security rules of the network security group.",
        SerializedName = @"defaultSecurityRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SecurityRuleAssociationDefaultSecurityRule { get; set; }
        /// <summary>Collection of effective security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of effective security rules.",
        SerializedName = @"effectiveSecurityRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule[] SecurityRuleAssociationEffectiveSecurityRule { get; set; }
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
    /// Network interface and all its associated security rules.
    internal partial interface ISecurityGroupNetworkInterfaceInternal

    {
        /// <summary>ID of the network interface.</summary>
        string Id { get; set; }
        /// <summary>Network interface ID.</summary>
        string NetworkInterfaceAssociationId { get; set; }
        /// <summary>Collection of custom security rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] NetworkInterfaceAssociationSecurityRule { get; set; }
        /// <summary>All security rules associated with the network interface.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociations SecurityRuleAssociation { get; set; }
        /// <summary>Collection of default security rules of the network security group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SecurityRuleAssociationDefaultSecurityRule { get; set; }
        /// <summary>Collection of effective security rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule[] SecurityRuleAssociationEffectiveSecurityRule { get; set; }
        /// <summary>Network interface and it's custom security rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociation SecurityRuleAssociationNetworkInterfaceAssociation { get; set; }
        /// <summary>Subnet and it's custom security rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetAssociation SecurityRuleAssociationSubnetAssociation { get; set; }
        /// <summary>Subnet ID.</summary>
        string SubnetAssociationId { get; set; }
        /// <summary>Collection of custom security rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SubnetAssociationSecurityRule { get; set; }

    }
}