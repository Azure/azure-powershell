namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>The result for export jobs containing blob details.</summary>
    public partial class ExportJobsResult :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IExportJobsResult,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IExportJobsResultInternal
    {

        /// <summary>Backing field for <see cref="BlobSasKey" /> property.</summary>
        private string _blobSasKey;

        /// <summary>SAS key to access the blob.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string BlobSasKey { get => this._blobSasKey; }

        /// <summary>Backing field for <see cref="BlobUrl" /> property.</summary>
        private string _blobUrl;

        /// <summary>URL of the blob into which the serialized string of list of jobs is exported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string BlobUrl { get => this._blobUrl; }

        /// <summary>Backing field for <see cref="ExcelFileBlobSasKey" /> property.</summary>
        private string _excelFileBlobSasKey;

        /// <summary>SAS key to access the ExcelFile blob.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ExcelFileBlobSasKey { get => this._excelFileBlobSasKey; }

        /// <summary>Backing field for <see cref="ExcelFileBlobUrl" /> property.</summary>
        private string _excelFileBlobUrl;

        /// <summary>URL of the blob into which the ExcelFile is uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ExcelFileBlobUrl { get => this._excelFileBlobUrl; }

        /// <summary>Internal Acessors for BlobSasKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IExportJobsResultInternal.BlobSasKey { get => this._blobSasKey; set { {_blobSasKey = value;} } }

        /// <summary>Internal Acessors for BlobUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IExportJobsResultInternal.BlobUrl { get => this._blobUrl; set { {_blobUrl = value;} } }

        /// <summary>Internal Acessors for ExcelFileBlobSasKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IExportJobsResultInternal.ExcelFileBlobSasKey { get => this._excelFileBlobSasKey; set { {_excelFileBlobSasKey = value;} } }

        /// <summary>Internal Acessors for ExcelFileBlobUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IExportJobsResultInternal.ExcelFileBlobUrl { get => this._excelFileBlobUrl; set { {_excelFileBlobUrl = value;} } }

        /// <summary>Creates an new <see cref="ExportJobsResult" /> instance.</summary>
        public ExportJobsResult()
        {

        }
    }
    /// The result for export jobs containing blob details.
    public partial interface IExportJobsResult :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>SAS key to access the blob.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"SAS key to access the blob.",
        SerializedName = @"blobSasKey",
        PossibleTypes = new [] { typeof(string) })]
        string BlobSasKey { get;  }
        /// <summary>URL of the blob into which the serialized string of list of jobs is exported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"URL of the blob into which the serialized string of list of jobs is exported.",
        SerializedName = @"blobUrl",
        PossibleTypes = new [] { typeof(string) })]
        string BlobUrl { get;  }
        /// <summary>SAS key to access the ExcelFile blob.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"SAS key to access the ExcelFile blob.",
        SerializedName = @"excelFileBlobSasKey",
        PossibleTypes = new [] { typeof(string) })]
        string ExcelFileBlobSasKey { get;  }
        /// <summary>URL of the blob into which the ExcelFile is uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"URL of the blob into which the ExcelFile is uploaded.",
        SerializedName = @"excelFileBlobUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ExcelFileBlobUrl { get;  }

    }
    /// The result for export jobs containing blob details.
    internal partial interface IExportJobsResultInternal

    {
        /// <summary>SAS key to access the blob.</summary>
        string BlobSasKey { get; set; }
        /// <summary>URL of the blob into which the serialized string of list of jobs is exported.</summary>
        string BlobUrl { get; set; }
        /// <summary>SAS key to access the ExcelFile blob.</summary>
        string ExcelFileBlobSasKey { get; set; }
        /// <summary>URL of the blob into which the ExcelFile is uploaded.</summary>
        string ExcelFileBlobUrl { get; set; }

    }
}