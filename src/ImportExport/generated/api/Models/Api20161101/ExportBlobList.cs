namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>A list of the blobs to be exported.</summary>
    public partial class ExportBlobList :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportBlobList,
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportBlobListInternal
    {

        /// <summary>Backing field for <see cref="BlobPath" /> property.</summary>
        private string[] _blobPath;

        /// <summary>A collection of blob-path strings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string[] BlobPath { get => this._blobPath; set => this._blobPath = value; }

        /// <summary>Backing field for <see cref="BlobPathPrefix" /> property.</summary>
        private string[] _blobPathPrefix;

        /// <summary>A collection of blob-prefix strings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string[] BlobPathPrefix { get => this._blobPathPrefix; set => this._blobPathPrefix = value; }

        /// <summary>Creates an new <see cref="ExportBlobList" /> instance.</summary>
        public ExportBlobList()
        {

        }
    }
    /// A list of the blobs to be exported.
    public partial interface IExportBlobList :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.IJsonSerializable
    {
        /// <summary>A collection of blob-path strings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of blob-path strings.",
        SerializedName = @"blobPath",
        PossibleTypes = new [] { typeof(string) })]
        string[] BlobPath { get; set; }
        /// <summary>A collection of blob-prefix strings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of blob-prefix strings.",
        SerializedName = @"blobPathPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string[] BlobPathPrefix { get; set; }

    }
    /// A list of the blobs to be exported.
    internal partial interface IExportBlobListInternal

    {
        /// <summary>A collection of blob-path strings.</summary>
        string[] BlobPath { get; set; }
        /// <summary>A collection of blob-prefix strings.</summary>
        string[] BlobPathPrefix { get; set; }

    }
}