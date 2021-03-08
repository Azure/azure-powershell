namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the virtual network subnets resource settings.</summary>
    public partial class SubnetResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetResourceSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetResourceSettingsInternal
    {

        /// <summary>Backing field for <see cref="AddressPrefix" /> property.</summary>
        private string _addressPrefix;

        /// <summary>Gets or sets address prefix for the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string AddressPrefix { get => this._addressPrefix; set => this._addressPrefix = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Gets or sets the Subnet name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

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

    }
    /// Defines the virtual network subnets resource settings.
    internal partial interface ISubnetResourceSettingsInternal

    {
        /// <summary>Gets or sets address prefix for the subnet.</summary>
        string AddressPrefix { get; set; }
        /// <summary>Gets or sets the Subnet name.</summary>
        string Name { get; set; }

    }
}