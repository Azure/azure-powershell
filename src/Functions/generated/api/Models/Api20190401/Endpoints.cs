namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// The URIs that are used to perform a retrieval of a public blob, queue, table, web or dfs object.
    /// </summary>
    public partial class Endpoints :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal
    {

        /// <summary>Backing field for <see cref="Blob" /> property.</summary>
        private string _blob;

        /// <summary>Gets the blob endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Blob { get => this._blob; }

        /// <summary>Backing field for <see cref="Df" /> property.</summary>
        private string _df;

        /// <summary>Gets the dfs endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Df { get => this._df; }

        /// <summary>Backing field for <see cref="File" /> property.</summary>
        private string _file;

        /// <summary>Gets the file endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string File { get => this._file; }

        /// <summary>Internal Acessors for Blob</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal.Blob { get => this._blob; set { {_blob = value;} } }

        /// <summary>Internal Acessors for Df</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal.Df { get => this._df; set { {_df = value;} } }

        /// <summary>Internal Acessors for File</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal.File { get => this._file; set { {_file = value;} } }

        /// <summary>Internal Acessors for Queue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal.Queue { get => this._queue; set { {_queue = value;} } }

        /// <summary>Internal Acessors for Table</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal.Table { get => this._table; set { {_table = value;} } }

        /// <summary>Internal Acessors for Web</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal.Web { get => this._web; set { {_web = value;} } }

        /// <summary>Backing field for <see cref="Queue" /> property.</summary>
        private string _queue;

        /// <summary>Gets the queue endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Queue { get => this._queue; }

        /// <summary>Backing field for <see cref="Table" /> property.</summary>
        private string _table;

        /// <summary>Gets the table endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Table { get => this._table; }

        /// <summary>Backing field for <see cref="Web" /> property.</summary>
        private string _web;

        /// <summary>Gets the web endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Web { get => this._web; }

        /// <summary>Creates an new <see cref="Endpoints" /> instance.</summary>
        public Endpoints()
        {

        }
    }
    /// The URIs that are used to perform a retrieval of a public blob, queue, table, web or dfs object.
    public partial interface IEndpoints :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Gets the blob endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the blob endpoint.",
        SerializedName = @"blob",
        PossibleTypes = new [] { typeof(string) })]
        string Blob { get;  }
        /// <summary>Gets the dfs endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the dfs endpoint.",
        SerializedName = @"dfs",
        PossibleTypes = new [] { typeof(string) })]
        string Df { get;  }
        /// <summary>Gets the file endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the file endpoint.",
        SerializedName = @"file",
        PossibleTypes = new [] { typeof(string) })]
        string File { get;  }
        /// <summary>Gets the queue endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the queue endpoint.",
        SerializedName = @"queue",
        PossibleTypes = new [] { typeof(string) })]
        string Queue { get;  }
        /// <summary>Gets the table endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the table endpoint.",
        SerializedName = @"table",
        PossibleTypes = new [] { typeof(string) })]
        string Table { get;  }
        /// <summary>Gets the web endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the web endpoint.",
        SerializedName = @"web",
        PossibleTypes = new [] { typeof(string) })]
        string Web { get;  }

    }
    /// The URIs that are used to perform a retrieval of a public blob, queue, table, web or dfs object.
    internal partial interface IEndpointsInternal

    {
        /// <summary>Gets the blob endpoint.</summary>
        string Blob { get; set; }
        /// <summary>Gets the dfs endpoint.</summary>
        string Df { get; set; }
        /// <summary>Gets the file endpoint.</summary>
        string File { get; set; }
        /// <summary>Gets the queue endpoint.</summary>
        string Queue { get; set; }
        /// <summary>Gets the table endpoint.</summary>
        string Table { get; set; }
        /// <summary>Gets the web endpoint.</summary>
        string Web { get; set; }

    }
}