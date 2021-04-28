namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Protection status details</summary>
    public partial class ProtectionStatusDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IProtectionStatusDetails,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IProtectionStatusDetailsInternal
    {

        /// <summary>Backing field for <see cref="ErrorDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError _errorDetail;

        /// <summary>Specifies the protection status error of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError ErrorDetail { get => (this._errorDetail = this._errorDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.UserFacingError()); set => this._errorDetail = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.Status? _status;

        /// <summary>Specifies the protection status of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.Status? Status { get => this._status; set => this._status = value; }

        /// <summary>Creates an new <see cref="ProtectionStatusDetails" /> instance.</summary>
        public ProtectionStatusDetails()
        {

        }
    }
    /// Protection status details
    public partial interface IProtectionStatusDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Specifies the protection status error of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the protection status error of the resource",
        SerializedName = @"errorDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError ErrorDetail { get; set; }
        /// <summary>Specifies the protection status of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the protection status of the resource",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.Status) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.Status? Status { get; set; }

    }
    /// Protection status details
    internal partial interface IProtectionStatusDetailsInternal

    {
        /// <summary>Specifies the protection status error of the resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError ErrorDetail { get; set; }
        /// <summary>Specifies the protection status of the resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.Status? Status { get; set; }

    }
}