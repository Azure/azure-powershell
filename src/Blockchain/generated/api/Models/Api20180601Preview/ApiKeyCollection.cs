namespace Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Extensions;

    /// <summary>
    /// Collection of the API key payload which is exposed in the response of the resource provider.
    /// </summary>
    public partial class ApiKeyCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IApiKeyCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IApiKeyCollectionInternal
    {

        /// <summary>Backing field for <see cref="Key" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IApiKey[] _key;

        /// <summary>Gets or sets the collection of API key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Origin(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IApiKey[] Key { get => this._key; set => this._key = value; }

        /// <summary>Creates an new <see cref="ApiKeyCollection" /> instance.</summary>
        public ApiKeyCollection()
        {

        }
    }
    /// Collection of the API key payload which is exposed in the response of the resource provider.
    public partial interface IApiKeyCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the collection of API key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the collection of API key.",
        SerializedName = @"keys",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IApiKey) })]
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IApiKey[] Key { get; set; }

    }
    /// Collection of the API key payload which is exposed in the response of the resource provider.
    internal partial interface IApiKeyCollectionInternal

    {
        /// <summary>Gets or sets the collection of API key.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IApiKey[] Key { get; set; }

    }
}