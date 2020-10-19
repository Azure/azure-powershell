namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>An error response from the service.</summary>
    public partial class CloudError :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudError,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorInternal
    {

        /// <summary>
        /// An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBodyInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBodyInternal)Error).Code = value; }

        /// <summary>A list of additional details about the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBody[] Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBodyInternal)Error).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBodyInternal)Error).Detail = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBody _error;

        /// <summary>An error response from the service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBody Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.CloudErrorBody()); set => this._error = value; }

        /// <summary>
        /// A message describing the error, intended to be suitable for display in a user interface.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBodyInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBodyInternal)Error).Message = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBody Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.CloudErrorBody()); set { {_error = value;} } }

        /// <summary>
        /// The target of the particular error. For example, the name of the property in error.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBodyInternal)Error).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBodyInternal)Error).Target = value; }

        /// <summary>Creates an new <see cref="CloudError" /> instance.</summary>
        public CloudError()
        {

        }
    }
    /// An error response from the service.
    public partial interface ICloudError :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>
        /// An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An identifier for the error. Codes are invariant and are intended to be consumed programmatically.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>A list of additional details about the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of additional details about the error.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBody) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBody[] Detail { get; set; }
        /// <summary>
        /// A message describing the error, intended to be suitable for display in a user interface.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A message describing the error, intended to be suitable for display in a user interface.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>
        /// The target of the particular error. For example, the name of the property in error.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target of the particular error. For example, the name of the property in error.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get; set; }

    }
    /// An error response from the service.
    public partial interface ICloudErrorInternal

    {
        /// <summary>
        /// An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
        /// </summary>
        string Code { get; set; }
        /// <summary>A list of additional details about the error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBody[] Detail { get; set; }
        /// <summary>An error response from the service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICloudErrorBody Error { get; set; }
        /// <summary>
        /// A message describing the error, intended to be suitable for display in a user interface.
        /// </summary>
        string Message { get; set; }
        /// <summary>
        /// The target of the particular error. For example, the name of the property in error.
        /// </summary>
        string Target { get; set; }

    }
}