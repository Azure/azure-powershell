namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Effective network security group.</summary>
    public partial class EffectiveNetworkSecurityGroup :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroup,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupInternal
    {

        /// <summary>Backing field for <see cref="Association" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupAssociation _association;

        /// <summary>Associated resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupAssociation Association { get => (this._association = this._association ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.EffectiveNetworkSecurityGroupAssociation()); set => this._association = value; }

        /// <summary>Backing field for <see cref="EffectiveSecurityRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityRule[] _effectiveSecurityRule;

        /// <summary>A collection of effective security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityRule[] EffectiveSecurityRule { get => this._effectiveSecurityRule; set => this._effectiveSecurityRule = value; }

        /// <summary>Internal Acessors for Association</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupAssociation Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupInternal.Association { get => (this._association = this._association ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.EffectiveNetworkSecurityGroupAssociation()); set { {_association = value;} } }

        /// <summary>Internal Acessors for AssociationNetworkInterface</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupInternal.AssociationNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupAssociationInternal)Association).NetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupAssociationInternal)Association).NetworkInterface = value; }

        /// <summary>Internal Acessors for AssociationSubnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupInternal.AssociationSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupAssociationInternal)Association).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupAssociationInternal)Association).Subnet = value; }

        /// <summary>Internal Acessors for Nsg</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupInternal.Nsg { get => (this._nsg = this._nsg ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set { {_nsg = value;} } }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NetworkInterfaceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupAssociationInternal)Association).NetworkInterfaceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupAssociationInternal)Association).NetworkInterfaceId = value; }

        /// <summary>Backing field for <see cref="Nsg" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource _nsg;

        /// <summary>The ID of network security group that is applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Nsg { get => (this._nsg = this._nsg ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set => this._nsg = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)Nsg).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)Nsg).Id = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupAssociationInternal)Association).SubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupAssociationInternal)Association).SubnetId = value; }

        /// <summary>Backing field for <see cref="TagMap" /> property.</summary>
        private string _tagMap;

        /// <summary>Mapping of tags to list of IP Addresses included within the tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TagMap { get => this._tagMap; set => this._tagMap = value; }

        /// <summary>Creates an new <see cref="EffectiveNetworkSecurityGroup" /> instance.</summary>
        public EffectiveNetworkSecurityGroup()
        {

        }
    }
    /// Effective network security group.
    public partial interface IEffectiveNetworkSecurityGroup :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>A collection of effective security rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of effective security rules.",
        SerializedName = @"effectiveSecurityRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityRule[] EffectiveSecurityRule { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkInterfaceId { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string NsgId { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetId { get; set; }
        /// <summary>Mapping of tags to list of IP Addresses included within the tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Mapping of tags to list of IP Addresses included within the tag.",
        SerializedName = @"tagMap",
        PossibleTypes = new [] { typeof(string) })]
        string TagMap { get; set; }

    }
    /// Effective network security group.
    internal partial interface IEffectiveNetworkSecurityGroupInternal

    {
        /// <summary>Associated resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityGroupAssociation Association { get; set; }
        /// <summary>The ID of the network interface if assigned.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource AssociationNetworkInterface { get; set; }
        /// <summary>The ID of the subnet if assigned.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource AssociationSubnet { get; set; }
        /// <summary>A collection of effective security rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IEffectiveNetworkSecurityRule[] EffectiveSecurityRule { get; set; }
        /// <summary>Resource ID.</summary>
        string NetworkInterfaceId { get; set; }
        /// <summary>The ID of network security group that is applied.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Nsg { get; set; }
        /// <summary>Resource ID.</summary>
        string NsgId { get; set; }
        /// <summary>Resource ID.</summary>
        string SubnetId { get; set; }
        /// <summary>Mapping of tags to list of IP Addresses included within the tag.</summary>
        string TagMap { get; set; }

    }
}