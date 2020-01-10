namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Configuration of the protocol.</summary>
    public partial class ProtocolConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal
    {

        /// <summary>Backing field for <see cref="HttpConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfiguration _httpConfiguration;

        /// <summary>HTTP configuration of the connectivity check.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfiguration HttpConfiguration { get => (this._httpConfiguration = this._httpConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.HttpConfiguration()); set => this._httpConfiguration = value; }

        /// <summary>List of HTTP headers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader[] HttpConfigurationHeader { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfigurationInternal)HttpConfiguration).Header; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfigurationInternal)HttpConfiguration).Header = value; }

        /// <summary>HTTP method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod? HttpConfigurationMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfigurationInternal)HttpConfiguration).Method; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfigurationInternal)HttpConfiguration).Method = value; }

        /// <summary>Valid status codes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int[] HttpConfigurationValidStatusCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfigurationInternal)HttpConfiguration).ValidStatusCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfigurationInternal)HttpConfiguration).ValidStatusCode = value; }

        /// <summary>Internal Acessors for HttpConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfiguration Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal.HttpConfiguration { get => (this._httpConfiguration = this._httpConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.HttpConfiguration()); set { {_httpConfiguration = value;} } }

        /// <summary>Creates an new <see cref="ProtocolConfiguration" /> instance.</summary>
        public ProtocolConfiguration()
        {

        }
    }
    /// Configuration of the protocol.
    public partial interface IProtocolConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of HTTP headers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of HTTP headers.",
        SerializedName = @"headers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader[] HttpConfigurationHeader { get; set; }
        /// <summary>HTTP method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"HTTP method.",
        SerializedName = @"method",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod? HttpConfigurationMethod { get; set; }
        /// <summary>Valid status codes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Valid status codes.",
        SerializedName = @"validStatusCodes",
        PossibleTypes = new [] { typeof(int) })]
        int[] HttpConfigurationValidStatusCode { get; set; }

    }
    /// Configuration of the protocol.
    internal partial interface IProtocolConfigurationInternal

    {
        /// <summary>HTTP configuration of the connectivity check.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfiguration HttpConfiguration { get; set; }
        /// <summary>List of HTTP headers.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader[] HttpConfigurationHeader { get; set; }
        /// <summary>HTTP method.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod? HttpConfigurationMethod { get; set; }
        /// <summary>Valid status codes.</summary>
        int[] HttpConfigurationValidStatusCode { get; set; }

    }
}