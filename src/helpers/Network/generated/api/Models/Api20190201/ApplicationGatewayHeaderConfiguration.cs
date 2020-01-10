namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Header configuration of the Actions set in Application Gateway.</summary>
    public partial class ApplicationGatewayHeaderConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayHeaderConfigurationInternal
    {

        /// <summary>Backing field for <see cref="HeaderName" /> property.</summary>
        private string _headerName;

        /// <summary>Header name of the header configuration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string HeaderName { get => this._headerName; set => this._headerName = value; }

        /// <summary>Backing field for <see cref="HeaderValue" /> property.</summary>
        private string _headerValue;

        /// <summary>Header value of the header configuration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string HeaderValue { get => this._headerValue; set => this._headerValue = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayHeaderConfiguration" /> instance.</summary>
        public ApplicationGatewayHeaderConfiguration()
        {

        }
    }
    /// Header configuration of the Actions set in Application Gateway.
    public partial interface IApplicationGatewayHeaderConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Header name of the header configuration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Header name of the header configuration",
        SerializedName = @"headerName",
        PossibleTypes = new [] { typeof(string) })]
        string HeaderName { get; set; }
        /// <summary>Header value of the header configuration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Header value of the header configuration",
        SerializedName = @"headerValue",
        PossibleTypes = new [] { typeof(string) })]
        string HeaderValue { get; set; }

    }
    /// Header configuration of the Actions set in Application Gateway.
    internal partial interface IApplicationGatewayHeaderConfigurationInternal

    {
        /// <summary>Header name of the header configuration</summary>
        string HeaderName { get; set; }
        /// <summary>Header value of the header configuration</summary>
        string HeaderValue { get; set; }

    }
}