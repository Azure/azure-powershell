namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Description of a Virtual Network that is useable for private site access.</summary>
    public partial class PrivateAccessVirtualNetwork :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessVirtualNetwork,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessVirtualNetworkInternal
    {

        /// <summary>Backing field for <see cref="Key" /> property.</summary>
        private int? _key;

        /// <summary>The key (ID) of the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Key { get => this._key; set => this._key = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>The ARM uri of the Virtual Network</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; set => this._resourceId = value; }

        /// <summary>Backing field for <see cref="Subnet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessSubnet[] _subnet;

        /// <summary>
        /// A List of subnets that access is allowed to on this Virtual Network. An empty array (but not null) is interpreted to mean
        /// that all subnets are allowed within this Virtual Network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessSubnet[] Subnet { get => this._subnet; set => this._subnet = value; }

        /// <summary>Creates an new <see cref="PrivateAccessVirtualNetwork" /> instance.</summary>
        public PrivateAccessVirtualNetwork()
        {

        }
    }
    /// Description of a Virtual Network that is useable for private site access.
    public partial interface IPrivateAccessVirtualNetwork :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The key (ID) of the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key (ID) of the Virtual Network.",
        SerializedName = @"key",
        PossibleTypes = new [] { typeof(int) })]
        int? Key { get; set; }
        /// <summary>The name of the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Virtual Network.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The ARM uri of the Virtual Network</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM uri of the Virtual Network",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get; set; }
        /// <summary>
        /// A List of subnets that access is allowed to on this Virtual Network. An empty array (but not null) is interpreted to mean
        /// that all subnets are allowed within this Virtual Network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A List of subnets that access is allowed to on this Virtual Network. An empty array (but not null) is interpreted to mean that all subnets are allowed within this Virtual Network.",
        SerializedName = @"subnets",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessSubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessSubnet[] Subnet { get; set; }

    }
    /// Description of a Virtual Network that is useable for private site access.
    internal partial interface IPrivateAccessVirtualNetworkInternal

    {
        /// <summary>The key (ID) of the Virtual Network.</summary>
        int? Key { get; set; }
        /// <summary>The name of the Virtual Network.</summary>
        string Name { get; set; }
        /// <summary>The ARM uri of the Virtual Network</summary>
        string ResourceId { get; set; }
        /// <summary>
        /// A List of subnets that access is allowed to on this Virtual Network. An empty array (but not null) is interpreted to mean
        /// that all subnets are allowed within this Virtual Network.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessSubnet[] Subnet { get; set; }

    }
}