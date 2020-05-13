namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>MSDeploy log entry</summary>
    public partial class MSDeployLogEntry :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployLogEntry,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployLogEntryInternal
    {

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Log entry message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployLogEntryInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Internal Acessors for Time</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployLogEntryInternal.Time { get => this._time; set { {_time = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MSDeployLogEntryType? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployLogEntryInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Time" /> property.</summary>
        private global::System.DateTime? _time;

        /// <summary>Timestamp of log entry</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? Time { get => this._time; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MSDeployLogEntryType? _type;

        /// <summary>Log entry type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MSDeployLogEntryType? Type { get => this._type; }

        /// <summary>Creates an new <see cref="MSDeployLogEntry" /> instance.</summary>
        public MSDeployLogEntry()
        {

        }
    }
    /// MSDeploy log entry
    public partial interface IMSDeployLogEntry :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Log entry message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Log entry message",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>Timestamp of log entry</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp of log entry",
        SerializedName = @"time",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? Time { get;  }
        /// <summary>Log entry type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Log entry type",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MSDeployLogEntryType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MSDeployLogEntryType? Type { get;  }

    }
    /// MSDeploy log entry
    internal partial interface IMSDeployLogEntryInternal

    {
        /// <summary>Log entry message</summary>
        string Message { get; set; }
        /// <summary>Timestamp of log entry</summary>
        global::System.DateTime? Time { get; set; }
        /// <summary>Log entry type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MSDeployLogEntryType? Type { get; set; }

    }
}