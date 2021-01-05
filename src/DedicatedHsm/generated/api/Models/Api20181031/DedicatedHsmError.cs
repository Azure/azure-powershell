namespace Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Extensions;

    /// <summary>The error exception.</summary>
    public partial class DedicatedHsmError :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmError,
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmErrorInternal
    {

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IError _error;

        /// <summary>The key vault server error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.Error()); }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IError Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmErrorInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.Error()); set { {_error = value;} } }

        /// <summary>Creates an new <see cref="DedicatedHsmError" /> instance.</summary>
        public DedicatedHsmError()
        {

        }
    }
    /// The error exception.
    public partial interface IDedicatedHsmError :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.IJsonSerializable
    {
        /// <summary>The key vault server error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The key vault server error.",
        SerializedName = @"error",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IError) })]
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IError Error { get;  }

    }
    /// The error exception.
    internal partial interface IDedicatedHsmErrorInternal

    {
        /// <summary>The key vault server error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IError Error { get; set; }

    }
}