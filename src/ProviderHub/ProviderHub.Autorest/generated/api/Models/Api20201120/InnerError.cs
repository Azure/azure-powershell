namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    /// <summary>Inner error containing list of errors.</summary>
    public partial class InnerError :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IInnerError,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IInnerErrorInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>Specific error code than was provided by the containing error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Code { get => this._code; }

        /// <summary>Backing field for <see cref="InnerError1" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny _innerError1;

        /// <summary>
        /// Object containing more specific information than the current object about the error.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny InnerError1 { get => (this._innerError1 = this._innerError1 ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Any()); }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IInnerErrorInternal.Code { get => this._code; set { {_code = value;} } }

        /// <summary>Internal Acessors for InnerError1</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IInnerErrorInternal.InnerError1 { get => (this._innerError1 = this._innerError1 ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Any()); set { {_innerError1 = value;} } }

        /// <summary>Creates an new <see cref="InnerError" /> instance.</summary>
        public InnerError()
        {

        }
    }
    /// Inner error containing list of errors.
    public partial interface IInnerError :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IAssociativeArray<global::System.Object>
    {
        /// <summary>Specific error code than was provided by the containing error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specific error code than was provided by the containing error.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>
        /// Object containing more specific information than the current object about the error.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Object containing more specific information than the current object about the error.",
        SerializedName = @"innerError",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny InnerError1 { get;  }

    }
    /// Inner error containing list of errors.
    internal partial interface IInnerErrorInternal

    {
        /// <summary>Specific error code than was provided by the containing error.</summary>
        string Code { get; set; }
        /// <summary>
        /// Object containing more specific information than the current object about the error.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny InnerError1 { get; set; }

    }
}