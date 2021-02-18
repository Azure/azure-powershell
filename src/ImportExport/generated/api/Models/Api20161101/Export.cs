namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>
    /// A property containing information about the blobs to be exported for an export job. This property is required for export
    /// jobs, but must not be specified for import jobs.
    /// </summary>
    public partial class Export :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExport,
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportInternal
    {

        /// <summary>Backing field for <see cref="BlobList" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportBlobList _blobList;

        /// <summary>A list of the blobs to be exported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportBlobList BlobList { get => (this._blobList = this._blobList ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ExportBlobList()); set => this._blobList = value; }

        /// <summary>A collection of blob-path strings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string[] BlobListBlobPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportBlobListInternal)BlobList).BlobPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportBlobListInternal)BlobList).BlobPath = value; }

        /// <summary>A collection of blob-prefix strings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string[] BlobListBlobPathPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportBlobListInternal)BlobList).BlobPathPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportBlobListInternal)BlobList).BlobPathPrefix = value; }

        /// <summary>Backing field for <see cref="BlobListblobPath" /> property.</summary>
        private string _blobListblobPath;

        /// <summary>
        /// The relative URI to the block blob that contains the list of blob paths or blob path prefixes as defined above, beginning
        /// with the container name. If the blob is in root container, the URI must begin with $root.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string BlobListblobPath { get => this._blobListblobPath; set => this._blobListblobPath = value; }

        /// <summary>Internal Acessors for BlobList</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportBlobList Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportInternal.BlobList { get => (this._blobList = this._blobList ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ExportBlobList()); set { {_blobList = value;} } }

        /// <summary>Creates an new <see cref="Export" /> instance.</summary>
        public Export()
        {

        }
    }
    /// A property containing information about the blobs to be exported for an export job. This property is required for export
    /// jobs, but must not be specified for import jobs.
    public partial interface IExport :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.IJsonSerializable
    {
        /// <summary>A collection of blob-path strings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of blob-path strings.",
        SerializedName = @"blobPath",
        PossibleTypes = new [] { typeof(string) })]
        string[] BlobListBlobPath { get; set; }
        /// <summary>A collection of blob-prefix strings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of blob-prefix strings.",
        SerializedName = @"blobPathPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string[] BlobListBlobPathPrefix { get; set; }
        /// <summary>
        /// The relative URI to the block blob that contains the list of blob paths or blob path prefixes as defined above, beginning
        /// with the container name. If the blob is in root container, the URI must begin with $root.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The relative URI to the block blob that contains the list of blob paths or blob path prefixes as defined above, beginning with the container name. If the blob is in root container, the URI must begin with $root. ",
        SerializedName = @"blobListblobPath",
        PossibleTypes = new [] { typeof(string) })]
        string BlobListblobPath { get; set; }

    }
    /// A property containing information about the blobs to be exported for an export job. This property is required for export
    /// jobs, but must not be specified for import jobs.
    internal partial interface IExportInternal

    {
        /// <summary>A list of the blobs to be exported.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IExportBlobList BlobList { get; set; }
        /// <summary>A collection of blob-path strings.</summary>
        string[] BlobListBlobPath { get; set; }
        /// <summary>A collection of blob-prefix strings.</summary>
        string[] BlobListBlobPathPrefix { get; set; }
        /// <summary>
        /// The relative URI to the block blob that contains the list of blob paths or blob path prefixes as defined above, beginning
        /// with the container name. If the blob is in root container, the URI must begin with $root.
        /// </summary>
        string BlobListblobPath { get; set; }

    }
}