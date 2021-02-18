namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>Error details.</summary>
    public partial class ErrorDetail :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorDetail,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorDetailInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>The error's code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>A human readable error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="Target" /> property.</summary>
        private string _target;

        /// <summary>Indicates which property in the request is responsible for the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string Target { get => this._target; set => this._target = value; }

        /// <summary>Creates an new <see cref="ErrorDetail" /> instance.</summary>
        public ErrorDetail()
        {

        }
    }
    /// Error details.
    public partial interface IErrorDetail :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IJsonSerializable
    {
        /// <summary>The error's code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The error's code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>A human readable error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A human readable error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Indicates which property in the request is responsible for the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates which property in the request is responsible for the error.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get; set; }

    }
    /// Error details.
    internal partial interface IErrorDetailInternal

    {
        /// <summary>The error's code.</summary>
        string Code { get; set; }
        /// <summary>A human readable error message.</summary>
        string Message { get; set; }
        /// <summary>Indicates which property in the request is responsible for the error.</summary>
        string Target { get; set; }

    }
}