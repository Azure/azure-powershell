namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>The properties of a server firewall rule.</summary>
    public partial class FirewallRuleProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IFirewallRuleProperties,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IFirewallRulePropertiesInternal
    {

        /// <summary>Backing field for <see cref="EndIPAddress" /> property.</summary>
        private string _endIPAddress;

        /// <summary>The end IP address of the server firewall rule. Must be IPv4 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string EndIPAddress { get => this._endIPAddress; set => this._endIPAddress = value; }

        /// <summary>Backing field for <see cref="StartIPAddress" /> property.</summary>
        private string _startIPAddress;

        /// <summary>The start IP address of the server firewall rule. Must be IPv4 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string StartIPAddress { get => this._startIPAddress; set => this._startIPAddress = value; }

        /// <summary>Creates an new <see cref="FirewallRuleProperties" /> instance.</summary>
        public FirewallRuleProperties()
        {

        }
    }
    /// The properties of a server firewall rule.
    public partial interface IFirewallRuleProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>The end IP address of the server firewall rule. Must be IPv4 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The end IP address of the server firewall rule. Must be IPv4 format.",
        SerializedName = @"endIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string EndIPAddress { get; set; }
        /// <summary>The start IP address of the server firewall rule. Must be IPv4 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The start IP address of the server firewall rule. Must be IPv4 format.",
        SerializedName = @"startIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string StartIPAddress { get; set; }

    }
    /// The properties of a server firewall rule.
    internal partial interface IFirewallRulePropertiesInternal

    {
        /// <summary>The end IP address of the server firewall rule. Must be IPv4 format.</summary>
        string EndIPAddress { get; set; }
        /// <summary>The start IP address of the server firewall rule. Must be IPv4 format.</summary>
        string StartIPAddress { get; set; }

    }
}