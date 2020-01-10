namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Application gateway probe health response match</summary>
    public partial class ApplicationGatewayProbeHealthResponseMatch :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbeHealthResponseMatch,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayProbeHealthResponseMatchInternal
    {

        /// <summary>Backing field for <see cref="Body" /> property.</summary>
        private string _body;

        /// <summary>Body that must be contained in the health response. Default value is empty.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Body { get => this._body; set => this._body = value; }

        /// <summary>Backing field for <see cref="StatusCode" /> property.</summary>
        private string[] _statusCode;

        /// <summary>
        /// Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] StatusCode { get => this._statusCode; set => this._statusCode = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayProbeHealthResponseMatch" /> instance.
        /// </summary>
        public ApplicationGatewayProbeHealthResponseMatch()
        {

        }
    }
    /// Application gateway probe health response match
    public partial interface IApplicationGatewayProbeHealthResponseMatch :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Body that must be contained in the health response. Default value is empty.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Body that must be contained in the health response. Default value is empty.",
        SerializedName = @"body",
        PossibleTypes = new [] { typeof(string) })]
        string Body { get; set; }
        /// <summary>
        /// Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.",
        SerializedName = @"statusCodes",
        PossibleTypes = new [] { typeof(string) })]
        string[] StatusCode { get; set; }

    }
    /// Application gateway probe health response match
    internal partial interface IApplicationGatewayProbeHealthResponseMatchInternal

    {
        /// <summary>Body that must be contained in the health response. Default value is empty.</summary>
        string Body { get; set; }
        /// <summary>
        /// Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.
        /// </summary>
        string[] StatusCode { get; set; }

    }
}