namespace Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Extensions;

    /// <summary>Update the payload of the blockchain member properties for a blockchain member.</summary>
    public partial class BlockchainMemberPropertiesUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesUpdateInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodePropertiesUpdate"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodePropertiesUpdate __transactionNodePropertiesUpdate = new Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.TransactionNodePropertiesUpdate();

        /// <summary>Backing field for <see cref="ConsortiumManagementAccountPassword" /> property.</summary>
        private string _consortiumManagementAccountPassword;

        /// <summary>Sets the managed consortium management account password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string ConsortiumManagementAccountPassword { get => this._consortiumManagementAccountPassword; set => this._consortiumManagementAccountPassword = value; }

        /// <summary>Gets or sets the firewall rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[] FirewallRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodePropertiesUpdateInternal)__transactionNodePropertiesUpdate).FirewallRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodePropertiesUpdateInternal)__transactionNodePropertiesUpdate).FirewallRule = value; }

        /// <summary>Sets the transaction node dns endpoint basic auth password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Inherited)]
        public string Password { get => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodePropertiesUpdateInternal)__transactionNodePropertiesUpdate).Password; set => ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodePropertiesUpdateInternal)__transactionNodePropertiesUpdate).Password = value; }

        /// <summary>Creates an new <see cref="BlockchainMemberPropertiesUpdate" /> instance.</summary>
        public BlockchainMemberPropertiesUpdate()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__transactionNodePropertiesUpdate), __transactionNodePropertiesUpdate);
            await eventListener.AssertObjectIsValid(nameof(__transactionNodePropertiesUpdate), __transactionNodePropertiesUpdate);
        }
    }
    /// Update the payload of the blockchain member properties for a blockchain member.
    public partial interface IBlockchainMemberPropertiesUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodePropertiesUpdate
    {
        /// <summary>Sets the managed consortium management account password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets the managed consortium management account password.",
        SerializedName = @"consortiumManagementAccountPassword",
        PossibleTypes = new [] { typeof(string) })]
        string ConsortiumManagementAccountPassword { get; set; }

    }
    /// Update the payload of the blockchain member properties for a blockchain member.
    internal partial interface IBlockchainMemberPropertiesUpdateInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.ITransactionNodePropertiesUpdateInternal
    {
        /// <summary>Sets the managed consortium management account password.</summary>
        string ConsortiumManagementAccountPassword { get; set; }

    }
}