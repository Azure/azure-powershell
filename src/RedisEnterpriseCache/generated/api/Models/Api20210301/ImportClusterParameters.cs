namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>Parameters for a Redis Enterprise import operation.</summary>
    public partial class ImportClusterParameters :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IImportClusterParameters,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IImportClusterParametersInternal
    {

        /// <summary>Backing field for <see cref="SasUri" /> property.</summary>
        private string _sasUri;

        /// <summary>SAS URI for the target blob to import from</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public string SasUri { get => this._sasUri; set => this._sasUri = value; }

        /// <summary>Creates an new <see cref="ImportClusterParameters" /> instance.</summary>
        public ImportClusterParameters()
        {

        }
    }
    /// Parameters for a Redis Enterprise import operation.
    public partial interface IImportClusterParameters :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IJsonSerializable
    {
        /// <summary>SAS URI for the target blob to import from</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"SAS URI for the target blob to import from",
        SerializedName = @"sasUri",
        PossibleTypes = new [] { typeof(string) })]
        string SasUri { get; set; }

    }
    /// Parameters for a Redis Enterprise import operation.
    internal partial interface IImportClusterParametersInternal

    {
        /// <summary>SAS URI for the target blob to import from</summary>
        string SasUri { get; set; }

    }
}