namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>The properties of a log file.</summary>
    public partial class LogFileProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ILogFileProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ILogFilePropertiesInternal
    {

        /// <summary>Backing field for <see cref="CreatedTime" /> property.</summary>
        private global::System.DateTime? _createdTime;

        /// <summary>Creation timestamp of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedTime { get => this._createdTime; }

        /// <summary>Backing field for <see cref="LastModifiedTime" /> property.</summary>
        private global::System.DateTime? _lastModifiedTime;

        /// <summary>Last modified timestamp of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public global::System.DateTime? LastModifiedTime { get => this._lastModifiedTime; }

        /// <summary>Internal Acessors for CreatedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ILogFilePropertiesInternal.CreatedTime { get => this._createdTime; set { {_createdTime = value;} } }

        /// <summary>Internal Acessors for LastModifiedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ILogFilePropertiesInternal.LastModifiedTime { get => this._lastModifiedTime; set { {_lastModifiedTime = value;} } }

        /// <summary>Backing field for <see cref="SizeInKb" /> property.</summary>
        private long? _sizeInKb;

        /// <summary>Size of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public long? SizeInKb { get => this._sizeInKb; set => this._sizeInKb = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="Url" /> property.</summary>
        private string _url;

        /// <summary>The url to download the log file from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public string Url { get => this._url; set => this._url = value; }

        /// <summary>Creates an new <see cref="LogFileProperties" /> instance.</summary>
        public LogFileProperties()
        {

        }
    }
    /// The properties of a log file.
    public partial interface ILogFileProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable
    {
        /// <summary>Creation timestamp of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Creation timestamp of the log file.",
        SerializedName = @"createdTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedTime { get;  }
        /// <summary>Last modified timestamp of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Last modified timestamp of the log file.",
        SerializedName = @"lastModifiedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastModifiedTime { get;  }
        /// <summary>Size of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size of the log file.",
        SerializedName = @"sizeInKB",
        PossibleTypes = new [] { typeof(long) })]
        long? SizeInKb { get; set; }
        /// <summary>Type of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of the log file.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }
        /// <summary>The url to download the log file from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The url to download the log file from.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string Url { get; set; }

    }
    /// The properties of a log file.
    internal partial interface ILogFilePropertiesInternal

    {
        /// <summary>Creation timestamp of the log file.</summary>
        global::System.DateTime? CreatedTime { get; set; }
        /// <summary>Last modified timestamp of the log file.</summary>
        global::System.DateTime? LastModifiedTime { get; set; }
        /// <summary>Size of the log file.</summary>
        long? SizeInKb { get; set; }
        /// <summary>Type of the log file.</summary>
        string Type { get; set; }
        /// <summary>The url to download the log file from.</summary>
        string Url { get; set; }

    }
}