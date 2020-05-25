namespace Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Extensions;

    /// <summary>Consortium payload</summary>
    public partial class Consortium :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IConsortium,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IConsortiumInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Gets or sets the blockchain member name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol? _protocol;

        /// <summary>Gets or sets the protocol for the consortium.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol? Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Creates an new <see cref="Consortium" /> instance.</summary>
        public Consortium()
        {

        }
    }
    /// Consortium payload
    public partial interface IConsortium :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the blockchain member name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the blockchain member name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Gets or sets the protocol for the consortium.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the protocol for the consortium.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol? Protocol { get; set; }

    }
    /// Consortium payload
    internal partial interface IConsortiumInternal

    {
        /// <summary>Gets or sets the blockchain member name.</summary>
        string Name { get; set; }
        /// <summary>Gets or sets the protocol for the consortium.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol? Protocol { get; set; }

    }
}