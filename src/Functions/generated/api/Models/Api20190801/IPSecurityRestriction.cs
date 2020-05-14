namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>IP security restriction on an app.</summary>
    public partial class IPSecurityRestriction :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private string _action;

        /// <summary>Allow or Deny access for this IP range.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Action { get => this._action; set => this._action = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>IP restriction rule description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string _iPAddress;

        /// <summary>
        /// IP address the security restriction is valid for.
        /// It can be in form of pure ipv4 address (required SubnetMask property) or
        /// CIDR notation such as ipv4/mask (leading bit match). For CIDR,
        /// SubnetMask property must not be specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string IPAddress { get => this._iPAddress; set => this._iPAddress = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>IP restriction rule name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Priority" /> property.</summary>
        private int? _priority;

        /// <summary>Priority of IP restriction rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Priority { get => this._priority; set => this._priority = value; }

        /// <summary>Backing field for <see cref="SubnetMask" /> property.</summary>
        private string _subnetMask;

        /// <summary>Subnet mask for the range of IP addresses the restriction is valid for.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SubnetMask { get => this._subnetMask; set => this._subnetMask = value; }

        /// <summary>Backing field for <see cref="SubnetTrafficTag" /> property.</summary>
        private int? _subnetTrafficTag;

        /// <summary>(internal) Subnet traffic tag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? SubnetTrafficTag { get => this._subnetTrafficTag; set => this._subnetTrafficTag = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.IPFilterTag? _tag;

        /// <summary>
        /// Defines what this IP filter will be used for. This is to support IP filtering on proxies.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.IPFilterTag? Tag { get => this._tag; set => this._tag = value; }

        /// <summary>Backing field for <see cref="VnetSubnetResourceId" /> property.</summary>
        private string _vnetSubnetResourceId;

        /// <summary>Virtual network resource id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VnetSubnetResourceId { get => this._vnetSubnetResourceId; set => this._vnetSubnetResourceId = value; }

        /// <summary>Backing field for <see cref="VnetTrafficTag" /> property.</summary>
        private int? _vnetTrafficTag;

        /// <summary>(internal) Vnet traffic tag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? VnetTrafficTag { get => this._vnetTrafficTag; set => this._vnetTrafficTag = value; }

        /// <summary>Creates an new <see cref="IPSecurityRestriction" /> instance.</summary>
        public IPSecurityRestriction()
        {

        }
    }
    /// IP security restriction on an app.
    public partial interface IIPSecurityRestriction :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Allow or Deny access for this IP range.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allow or Deny access for this IP range.",
        SerializedName = @"action",
        PossibleTypes = new [] { typeof(string) })]
        string Action { get; set; }
        /// <summary>IP restriction rule description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP restriction rule description.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>
        /// IP address the security restriction is valid for.
        /// It can be in form of pure ipv4 address (required SubnetMask property) or
        /// CIDR notation such as ipv4/mask (leading bit match). For CIDR,
        /// SubnetMask property must not be specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP address the security restriction is valid for.
        It can be in form of pure ipv4 address (required SubnetMask property) or
        CIDR notation such as ipv4/mask (leading bit match). For CIDR,
        SubnetMask property must not be specified.",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }
        /// <summary>IP restriction rule name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP restriction rule name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Priority of IP restriction rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Priority of IP restriction rule.",
        SerializedName = @"priority",
        PossibleTypes = new [] { typeof(int) })]
        int? Priority { get; set; }
        /// <summary>Subnet mask for the range of IP addresses the restriction is valid for.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Subnet mask for the range of IP addresses the restriction is valid for.",
        SerializedName = @"subnetMask",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetMask { get; set; }
        /// <summary>(internal) Subnet traffic tag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"(internal) Subnet traffic tag",
        SerializedName = @"subnetTrafficTag",
        PossibleTypes = new [] { typeof(int) })]
        int? SubnetTrafficTag { get; set; }
        /// <summary>
        /// Defines what this IP filter will be used for. This is to support IP filtering on proxies.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Defines what this IP filter will be used for. This is to support IP filtering on proxies.",
        SerializedName = @"tag",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.IPFilterTag) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.IPFilterTag? Tag { get; set; }
        /// <summary>Virtual network resource id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Virtual network resource id",
        SerializedName = @"vnetSubnetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string VnetSubnetResourceId { get; set; }
        /// <summary>(internal) Vnet traffic tag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"(internal) Vnet traffic tag",
        SerializedName = @"vnetTrafficTag",
        PossibleTypes = new [] { typeof(int) })]
        int? VnetTrafficTag { get; set; }

    }
    /// IP security restriction on an app.
    internal partial interface IIPSecurityRestrictionInternal

    {
        /// <summary>Allow or Deny access for this IP range.</summary>
        string Action { get; set; }
        /// <summary>IP restriction rule description.</summary>
        string Description { get; set; }
        /// <summary>
        /// IP address the security restriction is valid for.
        /// It can be in form of pure ipv4 address (required SubnetMask property) or
        /// CIDR notation such as ipv4/mask (leading bit match). For CIDR,
        /// SubnetMask property must not be specified.
        /// </summary>
        string IPAddress { get; set; }
        /// <summary>IP restriction rule name.</summary>
        string Name { get; set; }
        /// <summary>Priority of IP restriction rule.</summary>
        int? Priority { get; set; }
        /// <summary>Subnet mask for the range of IP addresses the restriction is valid for.</summary>
        string SubnetMask { get; set; }
        /// <summary>(internal) Subnet traffic tag</summary>
        int? SubnetTrafficTag { get; set; }
        /// <summary>
        /// Defines what this IP filter will be used for. This is to support IP filtering on proxies.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.IPFilterTag? Tag { get; set; }
        /// <summary>Virtual network resource id</summary>
        string VnetSubnetResourceId { get; set; }
        /// <summary>(internal) Vnet traffic tag</summary>
        int? VnetTrafficTag { get; set; }

    }
}