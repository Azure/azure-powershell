namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Operation result error properties</summary>
    public partial class OperationResultErrorProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultErrorProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultErrorPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>The code of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Creates an new <see cref="OperationResultErrorProperties" /> instance.</summary>
        public OperationResultErrorProperties()
        {

        }
    }
    /// Operation result error properties
    public partial interface IOperationResultErrorProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The code of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The code of the error.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }

    }
    /// Operation result error properties
    internal partial interface IOperationResultErrorPropertiesInternal

    {
        /// <summary>The code of the error.</summary>
        string Code { get; set; }
        /// <summary>The error message.</summary>
        string Message { get; set; }

    }
}