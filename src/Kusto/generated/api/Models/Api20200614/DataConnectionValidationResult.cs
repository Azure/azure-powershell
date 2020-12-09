namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The result returned from a data connection validation request.</summary>
    public partial class DataConnectionValidationResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionValidationResult,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionValidationResultInternal
    {

        /// <summary>Backing field for <see cref="ErrorMessage" /> property.</summary>
        private string _errorMessage;

        /// <summary>A message which indicates a problem in data connection validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string ErrorMessage { get => this._errorMessage; set => this._errorMessage = value; }

        /// <summary>Creates an new <see cref="DataConnectionValidationResult" /> instance.</summary>
        public DataConnectionValidationResult()
        {

        }
    }
    /// The result returned from a data connection validation request.
    public partial interface IDataConnectionValidationResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>A message which indicates a problem in data connection validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A message which indicates a problem in data connection validation.",
        SerializedName = @"errorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorMessage { get; set; }

    }
    /// The result returned from a data connection validation request.
    internal partial interface IDataConnectionValidationResultInternal

    {
        /// <summary>A message which indicates a problem in data connection validation.</summary>
        string ErrorMessage { get; set; }

    }
}