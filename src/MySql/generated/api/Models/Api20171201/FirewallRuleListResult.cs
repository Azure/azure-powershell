namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>A list of firewall rules.</summary>
    public partial class FirewallRuleListResult :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IFirewallRuleListResult,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IFirewallRuleListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IFirewallRule[] _value;

        /// <summary>The list of firewall rules in a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IFirewallRule[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="FirewallRuleListResult" /> instance.</summary>
        public FirewallRuleListResult()
        {

        }
    }
    /// A list of firewall rules.
    public partial interface IFirewallRuleListResult :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>The list of firewall rules in a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of firewall rules in a server.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IFirewallRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IFirewallRule[] Value { get; set; }

    }
    /// A list of firewall rules.
    internal partial interface IFirewallRuleListResultInternal

    {
        /// <summary>The list of firewall rules in a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IFirewallRule[] Value { get; set; }

    }
}