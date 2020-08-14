namespace Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Extensions;

    /// <summary>Ip range for firewall rules</summary>
    public partial class FirewallRule :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRuleInternal
    {

        /// <summary>Backing field for <see cref="EndIPAddress" /> property.</summary>
        private string _endIPAddress;

        /// <summary>Gets or sets the end IP address of the firewall rule range.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string EndIPAddress { get => this._endIPAddress; set => this._endIPAddress = value; }

        /// <summary>Backing field for <see cref="RuleName" /> property.</summary>
        private string _ruleName;

        /// <summary>Gets or sets the name of the firewall rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string RuleName { get => this._ruleName; set => this._ruleName = value; }

        /// <summary>Backing field for <see cref="StartIPAddress" /> property.</summary>
        private string _startIPAddress;

        /// <summary>Gets or sets the start IP address of the firewall rule range.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string StartIPAddress { get => this._startIPAddress; set => this._startIPAddress = value; }

        /// <summary>Creates an new <see cref="FirewallRule" /> instance.</summary>
        public FirewallRule()
        {

        }
    }
    /// Ip range for firewall rules
    public partial interface IFirewallRule :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the end IP address of the firewall rule range.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the end IP address of the firewall rule range.",
        SerializedName = @"endIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string EndIPAddress { get; set; }
        /// <summary>Gets or sets the name of the firewall rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the name of the firewall rules.",
        SerializedName = @"ruleName",
        PossibleTypes = new [] { typeof(string) })]
        string RuleName { get; set; }
        /// <summary>Gets or sets the start IP address of the firewall rule range.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the start IP address of the firewall rule range.",
        SerializedName = @"startIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string StartIPAddress { get; set; }

    }
    /// Ip range for firewall rules
    internal partial interface IFirewallRuleInternal

    {
        /// <summary>Gets or sets the end IP address of the firewall rule range.</summary>
        string EndIPAddress { get; set; }
        /// <summary>Gets or sets the name of the firewall rules.</summary>
        string RuleName { get; set; }
        /// <summary>Gets or sets the start IP address of the firewall rule range.</summary>
        string StartIPAddress { get; set; }

    }
}