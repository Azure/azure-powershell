namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Subnets of the network.</summary>
    public partial class Subnet :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISubnet,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISubnetInternal
    {

        /// <summary>Backing field for <see cref="AddressList" /> property.</summary>
        private string[] _addressList;

        /// <summary>The list of addresses for the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] AddressList { get => this._addressList; set => this._addressList = value; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>The subnet friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The subnet name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="Subnet" /> instance.</summary>
        public Subnet()
        {

        }
    }
    /// Subnets of the network.
    public partial interface ISubnet :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The list of addresses for the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of addresses for the subnet.",
        SerializedName = @"addressList",
        PossibleTypes = new [] { typeof(string) })]
        string[] AddressList { get; set; }
        /// <summary>The subnet friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The subnet friendly name.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>The subnet name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The subnet name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Subnets of the network.
    internal partial interface ISubnetInternal

    {
        /// <summary>The list of addresses for the subnet.</summary>
        string[] AddressList { get; set; }
        /// <summary>The subnet friendly name.</summary>
        string FriendlyName { get; set; }
        /// <summary>The subnet name.</summary>
        string Name { get; set; }

    }
}