namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Describes the error happened when create or update an image template</summary>
    public partial class ProvisioningError :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IProvisioningError,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IProvisioningErrorInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningErrorCode? _code;

        /// <summary>Error code of the provisioning failure</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningErrorCode? Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Verbose error message about the provisioning failure</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Creates an new <see cref="ProvisioningError" /> instance.</summary>
        public ProvisioningError()
        {

        }
    }
    /// Describes the error happened when create or update an image template
    public partial interface IProvisioningError :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable
    {
        /// <summary>Error code of the provisioning failure</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error code of the provisioning failure",
        SerializedName = @"provisioningErrorCode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningErrorCode) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningErrorCode? Code { get; set; }
        /// <summary>Verbose error message about the provisioning failure</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Verbose error message about the provisioning failure",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }

    }
    /// Describes the error happened when create or update an image template
    public partial interface IProvisioningErrorInternal

    {
        /// <summary>Error code of the provisioning failure</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningErrorCode? Code { get; set; }
        /// <summary>Verbose error message about the provisioning failure</summary>
        string Message { get; set; }

    }
}