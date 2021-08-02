namespace Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Extensions;

    /// <summary>Payload of transaction node properties payload in the transaction node payload.</summary>
    public partial class TransactionNodeProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodeProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Dns" /> property.</summary>
        private string _dns;

        /// <summary>Gets or sets the transaction node dns endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string Dns { get => this._dns; }

        /// <summary>Backing field for <see cref="FirewallRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[] _firewallRule;

        /// <summary>Gets or sets the firewall rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[] FirewallRule { get => this._firewallRule; set => this._firewallRule = value; }

        /// <summary>Internal Acessors for Dns</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodePropertiesInternal.Dns { get => this._dns; set { {_dns = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.NodeProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for PublicKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodePropertiesInternal.PublicKey { get => this._publicKey; set { {_publicKey = value;} } }

        /// <summary>Internal Acessors for UserName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodePropertiesInternal.UserName { get => this._userName; set { {_userName = value;} } }

        /// <summary>Backing field for <see cref="Password" /> property.</summary>
        private string _password;

        /// <summary>Sets the transaction node dns endpoint basic auth password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string Password { get => this._password; set => this._password = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.NodeProvisioningState? _provisioningState;

        /// <summary>Gets or sets the blockchain member provision state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.NodeProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="PublicKey" /> property.</summary>
        private string _publicKey;

        /// <summary>Gets or sets the transaction node public key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string PublicKey { get => this._publicKey; }

        /// <summary>Backing field for <see cref="UserName" /> property.</summary>
        private string _userName;

        /// <summary>Gets or sets the transaction node dns endpoint basic auth user name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string UserName { get => this._userName; }

        /// <summary>Creates an new <see cref="TransactionNodeProperties" /> instance.</summary>
        public TransactionNodeProperties()
        {

        }
    }
    /// Payload of transaction node properties payload in the transaction node payload.
    public partial interface ITransactionNodeProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the transaction node dns endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets or sets the transaction node dns endpoint.",
        SerializedName = @"dns",
        PossibleTypes = new [] { typeof(string) })]
        string Dns { get;  }
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
        /// <summary>Gets or sets the blockchain member provision state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets or sets the blockchain member provision state.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.NodeProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.NodeProvisioningState? ProvisioningState { get;  }
        /// <summary>Gets or sets the transaction node public key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets or sets the transaction node public key.",
        SerializedName = @"publicKey",
        PossibleTypes = new [] { typeof(string) })]
        string PublicKey { get;  }
        /// <summary>Gets or sets the transaction node dns endpoint basic auth user name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets or sets the transaction node dns endpoint basic auth user name.",
        SerializedName = @"userName",
        PossibleTypes = new [] { typeof(string) })]
        string UserName { get;  }

    }
    /// Payload of transaction node properties payload in the transaction node payload.
    internal partial interface ITransactionNodePropertiesInternal

    {
        /// <summary>Gets or sets the transaction node dns endpoint.</summary>
        string Dns { get; set; }
        /// <summary>Gets or sets the firewall rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[] FirewallRule { get; set; }
        /// <summary>Sets the transaction node dns endpoint basic auth password.</summary>
        string Password { get; set; }
        /// <summary>Gets or sets the blockchain member provision state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.NodeProvisioningState? ProvisioningState { get; set; }
        /// <summary>Gets or sets the transaction node public key.</summary>
        string PublicKey { get; set; }
        /// <summary>Gets or sets the transaction node dns endpoint basic auth user name.</summary>
        string UserName { get; set; }

    }
}