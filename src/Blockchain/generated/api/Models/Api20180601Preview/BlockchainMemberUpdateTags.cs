namespace Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Extensions;

    /// <summary>
    /// Tags of the service which is a list of key value pairs that describes the resource.
    /// </summary>
    public partial class BlockchainMemberUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberUpdateTags,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberUpdateTagsInternal
    {

        /// <summary>Creates an new <see cref="BlockchainMemberUpdateTags" /> instance.</summary>
        public BlockchainMemberUpdateTags()
        {

        }
    }
    /// Tags of the service which is a list of key value pairs that describes the resource.
    public partial interface IBlockchainMemberUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IAssociativeArray<string>
    {

    }
    /// Tags of the service which is a list of key value pairs that describes the resource.
    internal partial interface IBlockchainMemberUpdateTagsInternal

    {

    }
}