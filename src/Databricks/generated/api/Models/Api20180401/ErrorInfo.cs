namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>The code and message for an error.</summary>
    public partial class ErrorInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorInfoInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>A machine readable error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorDetail[] _detail;

        /// <summary>error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorDetail[] Detail { get => this._detail; set => this._detail = value; }

        /// <summary>Backing field for <see cref="Innererror" /> property.</summary>
        private string _innererror;

        /// <summary>Inner error details if they exist.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string Innererror { get => this._innererror; set => this._innererror = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>A human readable error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Creates an new <see cref="ErrorInfo" /> instance.</summary>
        public ErrorInfo()
        {

        }
    }
    /// The code and message for an error.
    public partial interface IErrorInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IJsonSerializable
    {
        /// <summary>A machine readable error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A machine readable error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"error details.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorDetail) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorDetail[] Detail { get; set; }
        /// <summary>Inner error details if they exist.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Inner error details if they exist.",
        SerializedName = @"innererror",
        PossibleTypes = new [] { typeof(string) })]
        string Innererror { get; set; }
        /// <summary>A human readable error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A human readable error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }

    }
    /// The code and message for an error.
    internal partial interface IErrorInfoInternal

    {
        /// <summary>A machine readable error code.</summary>
        string Code { get; set; }
        /// <summary>error details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorDetail[] Detail { get; set; }
        /// <summary>Inner error details if they exist.</summary>
        string Innererror { get; set; }
        /// <summary>A human readable error message.</summary>
        string Message { get; set; }

    }
}