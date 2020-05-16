namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>A list of log files.</summary>
    public partial class LogFileListResult :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ILogFileListResult,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ILogFileListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ILogFile[] _value;

        /// <summary>The list of log files.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ILogFile[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="LogFileListResult" /> instance.</summary>
        public LogFileListResult()
        {

        }
    }
    /// A list of log files.
    public partial interface ILogFileListResult :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable
    {
        /// <summary>The list of log files.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of log files.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ILogFile) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ILogFile[] Value { get; set; }

    }
    /// A list of log files.
    internal partial interface ILogFileListResultInternal

    {
        /// <summary>The list of log files.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ILogFile[] Value { get; set; }

    }
}