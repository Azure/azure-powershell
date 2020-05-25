namespace Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Extensions;

    /// <summary>Payload of the blockchain member properties for a blockchain member.</summary>
    public partial class BlockchainMemberProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Consortium" /> property.</summary>
        private string _consortium;

        /// <summary>Gets or sets the consortium for the blockchain member.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string Consortium { get => this._consortium; set => this._consortium = value; }

        /// <summary>Backing field for <see cref="ConsortiumManagementAccountAddress" /> property.</summary>
        private string _consortiumManagementAccountAddress;

        /// <summary>Gets the managed consortium management account address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string ConsortiumManagementAccountAddress { get => this._consortiumManagementAccountAddress; }

        /// <summary>Backing field for <see cref="ConsortiumManagementAccountPassword" /> property.</summary>
        private string _consortiumManagementAccountPassword;

        /// <summary>Sets the managed consortium management account password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string ConsortiumManagementAccountPassword { get => this._consortiumManagementAccountPassword; set => this._consortiumManagementAccountPassword = value; }

        /// <summary>Backing field for <see cref="ConsortiumMemberDisplayName" /> property.</summary>
        private string _consortiumMemberDisplayName;

        /// <summary>Gets the display name of the member in the consortium.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string ConsortiumMemberDisplayName { get => this._consortiumMemberDisplayName; set => this._consortiumMemberDisplayName = value; }

        /// <summary>Backing field for <see cref="ConsortiumRole" /> property.</summary>
        private string _consortiumRole;

        /// <summary>Gets the role of the member in the consortium.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string ConsortiumRole { get => this._consortiumRole; set => this._consortiumRole = value; }

        /// <summary>Backing field for <see cref="Dns" /> property.</summary>
        private string _dns;

        /// <summary>Gets the dns endpoint of the blockchain member.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string Dns { get => this._dns; }

        /// <summary>Backing field for <see cref="FirewallRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[] _firewallRule;

        /// <summary>Gets or sets firewall rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[] FirewallRule { get => this._firewallRule; set => this._firewallRule = value; }

        /// <summary>Internal Acessors for ConsortiumManagementAccountAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal.ConsortiumManagementAccountAddress { get => this._consortiumManagementAccountAddress; set { {_consortiumManagementAccountAddress = value;} } }

        /// <summary>Internal Acessors for Dns</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal.Dns { get => this._dns; set { {_dns = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainMemberProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for PublicKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal.PublicKey { get => this._publicKey; set { {_publicKey = value;} } }

        /// <summary>Internal Acessors for RootContractAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal.RootContractAddress { get => this._rootContractAddress; set { {_rootContractAddress = value;} } }

        /// <summary>Internal Acessors for UserName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal.UserName { get => this._userName; set { {_userName = value;} } }

        /// <summary>Internal Acessors for ValidatorNodesSku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberNodesSku Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal.ValidatorNodesSku { get => (this._validatorNodesSku = this._validatorNodesSku ?? new Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.BlockchainMemberNodesSku()); set { {_validatorNodesSku = value;} } }

        /// <summary>Backing field for <see cref="Password" /> property.</summary>
        private string _password;

        /// <summary>Sets the basic auth password of the blockchain member.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string Password { get => this._password; set => this._password = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol? _protocol;

        /// <summary>Gets or sets the blockchain protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol? Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainMemberProvisioningState? _provisioningState;

        /// <summary>Gets or sets the blockchain member provision state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainMemberProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="PublicKey" /> property.</summary>
        private string _publicKey;

        /// <summary>Gets the public key of the blockchain member (default transaction node).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string PublicKey { get => this._publicKey; }

        /// <summary>Backing field for <see cref="RootContractAddress" /> property.</summary>
        private string _rootContractAddress;

        /// <summary>Gets the Ethereum root contract address of the blockchain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string RootContractAddress { get => this._rootContractAddress; }

        /// <summary>Backing field for <see cref="UserName" /> property.</summary>
        private string _userName;

        /// <summary>Gets the auth user name of the blockchain member.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string UserName { get => this._userName; }

        /// <summary>Gets or sets the nodes capacity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public int? ValidatorNodeSkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberNodesSkuInternal)ValidatorNodesSku).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberNodesSkuInternal)ValidatorNodesSku).Capacity = value; }

        /// <summary>Backing field for <see cref="ValidatorNodesSku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberNodesSku _validatorNodesSku;

        /// <summary>Gets or sets the blockchain validator nodes Sku.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberNodesSku ValidatorNodesSku { get => (this._validatorNodesSku = this._validatorNodesSku ?? new Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.BlockchainMemberNodesSku()); set => this._validatorNodesSku = value; }

        /// <summary>Creates an new <see cref="BlockchainMemberProperties" /> instance.</summary>
        public BlockchainMemberProperties()
        {

        }
    }
    /// Payload of the blockchain member properties for a blockchain member.
    public partial interface IBlockchainMemberProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the consortium for the blockchain member.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the consortium for the blockchain member.",
        SerializedName = @"consortium",
        PossibleTypes = new [] { typeof(string) })]
        string Consortium { get; set; }
        /// <summary>Gets the managed consortium management account address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the managed consortium management account address.",
        SerializedName = @"consortiumManagementAccountAddress",
        PossibleTypes = new [] { typeof(string) })]
        string ConsortiumManagementAccountAddress { get;  }
        /// <summary>Sets the managed consortium management account password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets the managed consortium management account password.",
        SerializedName = @"consortiumManagementAccountPassword",
        PossibleTypes = new [] { typeof(string) })]
        string ConsortiumManagementAccountPassword { get; set; }
        /// <summary>Gets the display name of the member in the consortium.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the display name of the member in the consortium.",
        SerializedName = @"consortiumMemberDisplayName",
        PossibleTypes = new [] { typeof(string) })]
        string ConsortiumMemberDisplayName { get; set; }
        /// <summary>Gets the role of the member in the consortium.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the role of the member in the consortium.",
        SerializedName = @"consortiumRole",
        PossibleTypes = new [] { typeof(string) })]
        string ConsortiumRole { get; set; }
        /// <summary>Gets the dns endpoint of the blockchain member.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the dns endpoint of the blockchain member.",
        SerializedName = @"dns",
        PossibleTypes = new [] { typeof(string) })]
        string Dns { get;  }
        /// <summary>Gets or sets firewall rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets firewall rules",
        SerializedName = @"firewallRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[] FirewallRule { get; set; }
        /// <summary>Sets the basic auth password of the blockchain member.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets the basic auth password of the blockchain member.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string Password { get; set; }
        /// <summary>Gets or sets the blockchain protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the blockchain protocol.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol? Protocol { get; set; }
        /// <summary>Gets or sets the blockchain member provision state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets or sets the blockchain member provision state.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainMemberProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainMemberProvisioningState? ProvisioningState { get;  }
        /// <summary>Gets the public key of the blockchain member (default transaction node).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the public key of the blockchain member (default transaction node).",
        SerializedName = @"publicKey",
        PossibleTypes = new [] { typeof(string) })]
        string PublicKey { get;  }
        /// <summary>Gets the Ethereum root contract address of the blockchain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the Ethereum root contract address of the blockchain.",
        SerializedName = @"rootContractAddress",
        PossibleTypes = new [] { typeof(string) })]
        string RootContractAddress { get;  }
        /// <summary>Gets the auth user name of the blockchain member.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the auth user name of the blockchain member.",
        SerializedName = @"userName",
        PossibleTypes = new [] { typeof(string) })]
        string UserName { get;  }
        /// <summary>Gets or sets the nodes capacity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the nodes capacity.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? ValidatorNodeSkuCapacity { get; set; }

    }
    /// Payload of the blockchain member properties for a blockchain member.
    internal partial interface IBlockchainMemberPropertiesInternal

    {
        /// <summary>Gets or sets the consortium for the blockchain member.</summary>
        string Consortium { get; set; }
        /// <summary>Gets the managed consortium management account address.</summary>
        string ConsortiumManagementAccountAddress { get; set; }
        /// <summary>Sets the managed consortium management account password.</summary>
        string ConsortiumManagementAccountPassword { get; set; }
        /// <summary>Gets the display name of the member in the consortium.</summary>
        string ConsortiumMemberDisplayName { get; set; }
        /// <summary>Gets the role of the member in the consortium.</summary>
        string ConsortiumRole { get; set; }
        /// <summary>Gets the dns endpoint of the blockchain member.</summary>
        string Dns { get; set; }
        /// <summary>Gets or sets firewall rules</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[] FirewallRule { get; set; }
        /// <summary>Sets the basic auth password of the blockchain member.</summary>
        string Password { get; set; }
        /// <summary>Gets or sets the blockchain protocol.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol? Protocol { get; set; }
        /// <summary>Gets or sets the blockchain member provision state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainMemberProvisioningState? ProvisioningState { get; set; }
        /// <summary>Gets the public key of the blockchain member (default transaction node).</summary>
        string PublicKey { get; set; }
        /// <summary>Gets the Ethereum root contract address of the blockchain.</summary>
        string RootContractAddress { get; set; }
        /// <summary>Gets the auth user name of the blockchain member.</summary>
        string UserName { get; set; }
        /// <summary>Gets or sets the nodes capacity.</summary>
        int? ValidatorNodeSkuCapacity { get; set; }
        /// <summary>Gets or sets the blockchain validator nodes Sku.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberNodesSku ValidatorNodesSku { get; set; }

    }
}