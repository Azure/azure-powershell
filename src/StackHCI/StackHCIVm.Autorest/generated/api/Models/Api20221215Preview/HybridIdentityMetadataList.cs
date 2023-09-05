namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>List of HybridIdentityMetadata.</summary>
    public partial class HybridIdentityMetadataList :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHybridIdentityMetadataList,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHybridIdentityMetadataListInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Url to follow for getting next page of HybridIdentityMetadata.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHybridIdentityMetadata[] _value;

        /// <summary>Array of HybridIdentityMetadata</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHybridIdentityMetadata[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="HybridIdentityMetadataList" /> instance.</summary>
        public HybridIdentityMetadataList()
        {

        }
    }
    /// List of HybridIdentityMetadata.
    public partial interface IHybridIdentityMetadataList :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>Url to follow for getting next page of HybridIdentityMetadata.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Url to follow for getting next page of HybridIdentityMetadata.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>Array of HybridIdentityMetadata</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Array of HybridIdentityMetadata",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHybridIdentityMetadata) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHybridIdentityMetadata[] Value { get; set; }

    }
    /// List of HybridIdentityMetadata.
    internal partial interface IHybridIdentityMetadataListInternal

    {
        /// <summary>Url to follow for getting next page of HybridIdentityMetadata.</summary>
        string NextLink { get; set; }
        /// <summary>Array of HybridIdentityMetadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHybridIdentityMetadata[] Value { get; set; }

    }
}