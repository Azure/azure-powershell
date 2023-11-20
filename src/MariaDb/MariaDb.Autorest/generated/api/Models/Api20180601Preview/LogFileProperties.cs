namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Extensions;

    /// <summary>The properties of a log file.</summary>
    public partial class LogFileProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ILogFileProperties,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ILogFilePropertiesInternal
    {

        /// <summary>Backing field for <see cref="CreatedTime" /> property.</summary>
        private global::System.DateTime? _createdTime;

        /// <summary>Creation timestamp of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedTime { get => this._createdTime; }

        /// <summary>Backing field for <see cref="LastModifiedTime" /> property.</summary>
        private global::System.DateTime? _lastModifiedTime;

        /// <summary>Last modified timestamp of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public global::System.DateTime? LastModifiedTime { get => this._lastModifiedTime; }

        /// <summary>Internal Acessors for CreatedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ILogFilePropertiesInternal.CreatedTime { get => this._createdTime; set { {_createdTime = value;} } }

        /// <summary>Internal Acessors for LastModifiedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ILogFilePropertiesInternal.LastModifiedTime { get => this._lastModifiedTime; set { {_lastModifiedTime = value;} } }

        /// <summary>Internal Acessors for Url</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ILogFilePropertiesInternal.Url { get => this._url; set { {_url = value;} } }

        /// <summary>Backing field for <see cref="SizeInKb" /> property.</summary>
        private long? _sizeInKb;

        /// <summary>Size of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public long? SizeInKb { get => this._sizeInKb; set => this._sizeInKb = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="Url" /> property.</summary>
        private string _url;

        /// <summary>The url to download the log file from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string Url { get => this._url; }

        /// <summary>Creates an new <see cref="LogFileProperties" /> instance.</summary>
        public LogFileProperties()
        {

        }
    }
    /// The properties of a log file.
    public partial interface ILogFileProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IJsonSerializable
    {
        /// <summary>Creation timestamp of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Creation timestamp of the log file.",
        SerializedName = @"createdTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedTime { get;  }
        /// <summary>Last modified timestamp of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Last modified timestamp of the log file.",
        SerializedName = @"lastModifiedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastModifiedTime { get;  }
        /// <summary>Size of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size of the log file.",
        SerializedName = @"sizeInKB",
        PossibleTypes = new [] { typeof(long) })]
        long? SizeInKb { get; set; }
        /// <summary>Type of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of the log file.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }
        /// <summary>The url to download the log file from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The url to download the log file from.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string Url { get;  }

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