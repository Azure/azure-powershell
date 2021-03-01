namespace Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Extensions;

    /// <summary>Error response.</summary>
    public partial class ErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IErrorResponse,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IErrorResponseInternal
    {

        /// <summary>
        /// Service specific error code which serves as the substatus for the HTTP error code.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IErrorDefinitionInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IErrorDefinitionInternal)Error).Code = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IErrorDefinition _error;

        /// <summary>Error definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IErrorDefinition Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ErrorDefinition()); }

        /// <summary>Description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IErrorDefinitionInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IErrorDefinitionInternal)Error).Message = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IErrorDefinition Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IErrorResponseInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ErrorDefinition()); set { {_error = value;} } }

        /// <summary>Creates an new <see cref="ErrorResponse" /> instance.</summary>
        public ErrorResponse()
        {

        }
    }
    /// Error response.
    public partial interface IErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Service specific error code which serves as the substatus for the HTTP error code.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Service specific error code which serves as the substatus for the HTTP error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>Description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Description of the error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }

    }
    /// Error response.
    internal partial interface IErrorResponseInternal

    {
        /// <summary>
        /// Service specific error code which serves as the substatus for the HTTP error code.
        /// </summary>
        string Code { get; set; }
        /// <summary>Error definition.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IErrorDefinition Error { get; set; }
        /// <summary>Description of the error.</summary>
        string Message { get; set; }

    }
}