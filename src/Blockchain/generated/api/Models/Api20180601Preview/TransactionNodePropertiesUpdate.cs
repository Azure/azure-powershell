namespace Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Extensions;

    /// <summary>
    /// Update the payload of the transaction node properties in the transaction node payload.
    /// </summary>
    public partial class TransactionNodePropertiesUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodePropertiesUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodePropertiesUpdateInternal
    {

        /// <summary>Backing field for <see cref="FirewallRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[] _firewallRule;

        /// <summary>Gets or sets the firewall rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[] FirewallRule { get => this._firewallRule; set => this._firewallRule = value; }

        /// <summary>Backing field for <see cref="Password" /> property.</summary>
        private string _password;

        /// <summary>Sets the transaction node dns endpoint basic auth password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string Password { get => this._password; set => this._password = value; }

        /// <summary>Creates an new <see cref="TransactionNodePropertiesUpdate" /> instance.</summary>
        public TransactionNodePropertiesUpdate()
        {

        }
    }
    /// Update the payload of the transaction node properties in the transaction node payload.
    public partial interface ITransactionNodePropertiesUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the firewall rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the firewall rules.",
        SerializedName = @"firewallRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[] FirewallRule { get; set; }
        /// <summary>Sets the transaction node dns endpoint basic auth password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets the transaction node dns endpoint basic auth password.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string Password { get; set; }

    }
    /// Update the payload of the transaction node properties in the transaction node payload.
    internal partial interface ITransactionNodePropertiesUpdateInternal

    {
        /// <summary>Gets or sets the firewall rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[] FirewallRule { get; set; }
        /// <summary>Sets the transaction node dns endpoint basic auth password.</summary>
        string Password { get; set; }

    }
}