namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Description of a Virtual Network subnet that is useable for private site access.
    /// </summary>
    public partial class PrivateAccessSubnet :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessSubnet,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessSubnetInternal
    {

        /// <summary>Backing field for <see cref="Key" /> property.</summary>
        private int? _key;

        /// <summary>The key (ID) of the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Key { get => this._key; set => this._key = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="PrivateAccessSubnet" /> instance.</summary>
        public PrivateAccessSubnet()
        {

        }
    }
    /// Description of a Virtual Network subnet that is useable for private site access.
    public partial interface IPrivateAccessSubnet :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The key (ID) of the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key (ID) of the subnet.",
        SerializedName = @"key",
        PossibleTypes = new [] { typeof(int) })]
        int? Key { get; set; }
        /// <summary>The name of the subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the subnet.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Description of a Virtual Network subnet that is useable for private site access.
    internal partial interface IPrivateAccessSubnetInternal

    {
        /// <summary>The key (ID) of the subnet.</summary>
        int? Key { get; set; }
        /// <summary>The name of the subnet.</summary>
        string Name { get; set; }

    }
}