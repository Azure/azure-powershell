namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Inner Error</summary>
    public partial class InnerError :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerError,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerErrorInternal
    {

        /// <summary>Backing field for <see cref="AdditionalInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerErrorAdditionalInfo _additionalInfo;

        /// <summary>
        /// Any Key value pairs that can be provided to the client for additional verbose information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerErrorAdditionalInfo AdditionalInfo { get => (this._additionalInfo = this._additionalInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.InnerErrorAdditionalInfo()); set => this._additionalInfo = value; }

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>Unique code for this error</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="EmbeddedInnerError" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerError _embeddedInnerError;

        /// <summary>Child Inner Error, to allow Nesting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerError EmbeddedInnerError { get => (this._embeddedInnerError = this._embeddedInnerError ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.InnerError()); set => this._embeddedInnerError = value; }

        /// <summary>Creates an new <see cref="InnerError" /> instance.</summary>
        public InnerError()
        {

        }
    }
    /// Inner Error
    public partial interface IInnerError :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Any Key value pairs that can be provided to the client for additional verbose information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Any Key value pairs that can be provided to the client for additional  verbose information.",
        SerializedName = @"additionalInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerErrorAdditionalInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerErrorAdditionalInfo AdditionalInfo { get; set; }
        /// <summary>Unique code for this error</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Unique code for this error",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>Child Inner Error, to allow Nesting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Child Inner Error, to allow Nesting.",
        SerializedName = @"embeddedInnerError",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerError) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerError EmbeddedInnerError { get; set; }

    }
    /// Inner Error
    internal partial interface IInnerErrorInternal

    {
        /// <summary>
        /// Any Key value pairs that can be provided to the client for additional verbose information.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerErrorAdditionalInfo AdditionalInfo { get; set; }
        /// <summary>Unique code for this error</summary>
        string Code { get; set; }
        /// <summary>Child Inner Error, to allow Nesting.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerError EmbeddedInnerError { get; set; }

    }
}