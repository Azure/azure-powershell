namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Customer error of an application gateway.</summary>
    public partial class ApplicationGatewayCustomError :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayCustomError,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayCustomErrorInternal
    {

        /// <summary>Backing field for <see cref="CustomErrorPageUrl" /> property.</summary>
        private string _customErrorPageUrl;

        /// <summary>Error page URL of the application gateway customer error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string CustomErrorPageUrl { get => this._customErrorPageUrl; set => this._customErrorPageUrl = value; }

        /// <summary>Backing field for <see cref="StatusCode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCustomErrorStatusCode? _statusCode;

        /// <summary>Status code of the application gateway customer error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCustomErrorStatusCode? StatusCode { get => this._statusCode; set => this._statusCode = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayCustomError" /> instance.</summary>
        public ApplicationGatewayCustomError()
        {

        }
    }
    /// Customer error of an application gateway.
    public partial interface IApplicationGatewayCustomError :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Error page URL of the application gateway customer error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error page URL of the application gateway customer error.",
        SerializedName = @"customErrorPageUrl",
        PossibleTypes = new [] { typeof(string) })]
        string CustomErrorPageUrl { get; set; }
        /// <summary>Status code of the application gateway customer error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Status code of the application gateway customer error.",
        SerializedName = @"statusCode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCustomErrorStatusCode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCustomErrorStatusCode? StatusCode { get; set; }

    }
    /// Customer error of an application gateway.
    internal partial interface IApplicationGatewayCustomErrorInternal

    {
        /// <summary>Error page URL of the application gateway customer error.</summary>
        string CustomErrorPageUrl { get; set; }
        /// <summary>Status code of the application gateway customer error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayCustomErrorStatusCode? StatusCode { get; set; }

    }
}