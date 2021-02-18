namespace Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Extensions;

    /// <summary>Payload of the blockchain member nodes Sku for a blockchain member.</summary>
    public partial class BlockchainMemberNodesSku :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberNodesSku,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberNodesSkuInternal
    {

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private int? _capacity;

        /// <summary>Gets or sets the nodes capacity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public int? Capacity { get => this._capacity; set => this._capacity = value; }

        /// <summary>Creates an new <see cref="BlockchainMemberNodesSku" /> instance.</summary>
        public BlockchainMemberNodesSku()
        {

        }
    }
    /// Payload of the blockchain member nodes Sku for a blockchain member.
    public partial interface IBlockchainMemberNodesSku :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the nodes capacity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the nodes capacity.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? Capacity { get; set; }

    }
    /// Payload of the blockchain member nodes Sku for a blockchain member.
    internal partial interface IBlockchainMemberNodesSkuInternal

    {
        /// <summary>Gets or sets the nodes capacity.</summary>
        int? Capacity { get; set; }

    }
}