namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>IP rule with specific IP or IP range in CIDR format.</summary>
    public partial class IPRule :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRuleInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Action? _action;

        /// <summary>The action of IP ACL rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Action? Action { get => this._action; set => this._action = value; }

        /// <summary>Backing field for <see cref="IPAddressOrRange" /> property.</summary>
        private string _iPAddressOrRange;

        /// <summary>Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string IPAddressOrRange { get => this._iPAddressOrRange; set => this._iPAddressOrRange = value; }

        /// <summary>Creates an new <see cref="IPRule" /> instance.</summary>
        public IPRule()
        {

        }
    }
    /// IP rule with specific IP or IP range in CIDR format.
    public partial interface IIPRule :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The action of IP ACL rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The action of IP ACL rule.",
        SerializedName = @"action",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Action) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Action? Action { get; set; }
        /// <summary>Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddressOrRange { get; set; }

    }
    /// IP rule with specific IP or IP range in CIDR format.
    internal partial interface IIPRuleInternal

    {
        /// <summary>The action of IP ACL rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Action? Action { get; set; }
        /// <summary>Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed.</summary>
        string IPAddressOrRange { get; set; }

    }
}