namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Inner error details.</summary>
    public partial class InnerError :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInnerError,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInnerErrorInternal
    {

        /// <summary>Backing field for <see cref="Errordetail" /> property.</summary>
        private string _errordetail;

        /// <summary>The internal error message or exception dump.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Errordetail { get => this._errordetail; set => this._errordetail = value; }

        /// <summary>Backing field for <see cref="Exceptiontype" /> property.</summary>
        private string _exceptiontype;

        /// <summary>The exception type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Exceptiontype { get => this._exceptiontype; set => this._exceptiontype = value; }

        /// <summary>Creates an new <see cref="InnerError" /> instance.</summary>
        public InnerError()
        {

        }
    }
    /// Inner error details.
    public partial interface IInnerError :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>The internal error message or exception dump.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The internal error message or exception dump.",
        SerializedName = @"errordetail",
        PossibleTypes = new [] { typeof(string) })]
        string Errordetail { get; set; }
        /// <summary>The exception type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The exception type.",
        SerializedName = @"exceptiontype",
        PossibleTypes = new [] { typeof(string) })]
        string Exceptiontype { get; set; }

    }
    /// Inner error details.
    internal partial interface IInnerErrorInternal

    {
        /// <summary>The internal error message or exception dump.</summary>
        string Errordetail { get; set; }
        /// <summary>The exception type.</summary>
        string Exceptiontype { get; set; }

    }
}