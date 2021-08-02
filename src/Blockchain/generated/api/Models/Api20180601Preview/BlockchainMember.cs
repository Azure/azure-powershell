namespace Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Extensions;

    /// <summary>
    /// Payload of the blockchain member which is exposed in the request/response of the resource provider.
    /// </summary>
    public partial class BlockchainMember :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMember,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.TrackedResource();

        /// <summary>Gets or sets the consortium for the blockchain member.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public string Consortium { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).Consortium; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).Consortium = value; }

        /// <summary>Gets the managed consortium management account address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public string ConsortiumManagementAccountAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ConsortiumManagementAccountAddress; }

        /// <summary>Sets the managed consortium management account password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public string ConsortiumManagementAccountPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ConsortiumManagementAccountPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ConsortiumManagementAccountPassword = value; }

        /// <summary>Gets the display name of the member in the consortium.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public string ConsortiumMemberDisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ConsortiumMemberDisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ConsortiumMemberDisplayName = value; }

        /// <summary>Gets the role of the member in the consortium.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public string ConsortiumRole { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ConsortiumRole; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ConsortiumRole = value; }

        /// <summary>Gets the dns endpoint of the blockchain member.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public string Dns { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).Dns; }

        /// <summary>Gets or sets firewall rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[] FirewallRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).FirewallRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).FirewallRule = value; }

        /// <summary>Fully qualified resource Id of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IResourceInternal)__trackedResource).Id; }

        /// <summary>The GEO location of the blockchain service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITrackedResourceInternal)__trackedResource).Location = value; }

        /// <summary>Internal Acessors for ConsortiumManagementAccountAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberInternal.ConsortiumManagementAccountAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ConsortiumManagementAccountAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ConsortiumManagementAccountAddress = value; }

        /// <summary>Internal Acessors for Dns</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberInternal.Dns { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).Dns; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).Dns = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberProperties Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.BlockchainMemberProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainMemberProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for PublicKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberInternal.PublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).PublicKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).PublicKey = value; }

        /// <summary>Internal Acessors for RootContractAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberInternal.RootContractAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).RootContractAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).RootContractAddress = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ISku Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.Sku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for UserName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberInternal.UserName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).UserName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).UserName = value; }

        /// <summary>Internal Acessors for ValidatorNodesSku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberNodesSku Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberInternal.ValidatorNodesSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ValidatorNodesSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ValidatorNodesSku = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>The name of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IResourceInternal)__trackedResource).Name; }

        /// <summary>Sets the basic auth password of the blockchain member.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public string Password { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).Password; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).Password = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberProperties _property;

        /// <summary>Gets or sets the blockchain member properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.BlockchainMemberProperties()); set => this._property = value; }

        /// <summary>Gets or sets the blockchain protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol? Protocol { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).Protocol; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).Protocol = value; }

        /// <summary>Gets or sets the blockchain member provision state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainMemberProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Gets the public key of the blockchain member (default transaction node).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public string PublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).PublicKey; }

        /// <summary>Gets the Ethereum root contract address of the blockchain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public string RootContractAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).RootContractAddress; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ISku _sku;

        /// <summary>Gets or sets the blockchain member Sku.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.Sku()); set => this._sku = value; }

        /// <summary>Gets or sets Sku name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ISkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ISkuInternal)Sku).Name = value; }

        /// <summary>Gets or sets Sku tier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public string SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ISkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ISkuInternal)Sku).Tier = value; }

        /// <summary>
        /// Tags of the service which is a list of key value pairs that describes the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITrackedResourceInternal)__trackedResource).Tag = value; }

        /// <summary>The type of the service - e.g. "Microsoft.Blockchain"</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IResourceInternal)__trackedResource).Type; }

        /// <summary>Gets the auth user name of the blockchain member.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public string UserName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).UserName; }

        /// <summary>Gets or sets the nodes capacity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inlined)]
        public int? ValidatorNodeSkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ValidatorNodeSkuCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)Property).ValidatorNodeSkuCapacity = value; }

        /// <summary>Creates an new <see cref="BlockchainMember" /> instance.</summary>
        public BlockchainMember()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// Payload of the blockchain member which is exposed in the request/response of the resource provider.
    public partial interface IBlockchainMember :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITrackedResource
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
        /// <summary>Gets or sets Sku name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets Sku name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }
        /// <summary>Gets or sets Sku tier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets Sku tier",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string SkuTier { get; set; }
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
    /// Payload of the blockchain member which is exposed in the request/response of the resource provider.
    internal partial interface IBlockchainMemberInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITrackedResourceInternal
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
        /// <summary>Gets or sets the blockchain member properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberProperties Property { get; set; }
        /// <summary>Gets or sets the blockchain protocol.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol? Protocol { get; set; }
        /// <summary>Gets or sets the blockchain member provision state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainMemberProvisioningState? ProvisioningState { get; set; }
        /// <summary>Gets the public key of the blockchain member (default transaction node).</summary>
        string PublicKey { get; set; }
        /// <summary>Gets the Ethereum root contract address of the blockchain.</summary>
        string RootContractAddress { get; set; }
        /// <summary>Gets or sets the blockchain member Sku.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ISku Sku { get; set; }
        /// <summary>Gets or sets Sku name</summary>
        string SkuName { get; set; }
        /// <summary>Gets or sets Sku tier</summary>
        string SkuTier { get; set; }
        /// <summary>Gets the auth user name of the blockchain member.</summary>
        string UserName { get; set; }
        /// <summary>Gets or sets the nodes capacity.</summary>
        int? ValidatorNodeSkuCapacity { get; set; }
        /// <summary>Gets or sets the blockchain validator nodes Sku.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberNodesSku ValidatorNodesSku { get; set; }

    }
}