namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the virtual network subnets resource settings.</summary>
    public partial class SubnetResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISubnetResourceSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISubnetResourceSettingsInternal
    {

        /// <summary>Backing field for <see cref="AddressPrefix" /> property.</summary>
        private string _addressPrefix;

        /// <summary>Gets or sets address prefix for the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string AddressPrefix { get => this._addressPrefix; set => this._addressPrefix = value; }

        /// <summary>Internal Acessors for NetworkSecurityGroup</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReference Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ISubnetResourceSettingsInternal.NetworkSecurityGroup { get => (this._networkSecurityGroup = this._networkSecurityGroup ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.AzureResourceReference()); set { {_networkSecurityGroup = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Gets or sets the Subnet name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="NetworkSecurityGroup" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReference _networkSecurityGroup;

        /// <summary>Defines reference to an Azure resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReference NetworkSecurityGroup { get => (this._networkSecurityGroup = this._networkSecurityGroup ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.AzureResourceReference()); set => this._networkSecurityGroup = value; }

        /// <summary>Gets the ARM resource ID of the tracked resource being referenced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string NetworkSecurityGroupSourceArmResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReferenceInternal)NetworkSecurityGroup).SourceArmResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReferenceInternal)NetworkSecurityGroup).SourceArmResourceId = value ?? null; }

        /// <summary>Creates an new <see cref="SubnetResourceSettings" /> instance.</summary>
        public SubnetResourceSettings()
        {

        }
    }
    /// Defines the virtual network subnets resource settings.
    public partial interface ISubnetResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets address prefix for the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets address prefix for the subnet.",
        SerializedName = @"addressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string AddressPrefix { get; set; }
        /// <summary>Gets or sets the Subnet name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the Subnet name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Gets the ARM resource ID of the tracked resource being referenced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the ARM resource ID of the tracked resource being referenced.",
        SerializedName = @"sourceArmResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkSecurityGroupSourceArmResourceId { get; set; }

    }
    /// Defines the virtual network subnets resource settings.
    internal partial interface ISubnetResourceSettingsInternal

    {
        /// <summary>Gets or sets address prefix for the subnet.</summary>
        string AddressPrefix { get; set; }
        /// <summary>Gets or sets the Subnet name.</summary>
        string Name { get; set; }
        /// <summary>Defines reference to an Azure resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReference NetworkSecurityGroup { get; set; }
        /// <summary>Gets the ARM resource ID of the tracked resource being referenced.</summary>
        string NetworkSecurityGroupSourceArmResourceId { get; set; }

    }
}