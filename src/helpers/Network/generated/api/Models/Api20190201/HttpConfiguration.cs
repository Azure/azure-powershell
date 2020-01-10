namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>HTTP configuration of the connectivity check.</summary>
    public partial class HttpConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfigurationInternal
    {

        /// <summary>Backing field for <see cref="Header" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader[] _header;

        /// <summary>List of HTTP headers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader[] Header { get => this._header; set => this._header = value; }

        /// <summary>Backing field for <see cref="Method" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod? _method;

        /// <summary>HTTP method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod? Method { get => this._method; set => this._method = value; }

        /// <summary>Backing field for <see cref="ValidStatusCode" /> property.</summary>
        private int[] _validStatusCode;

        /// <summary>Valid status codes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int[] ValidStatusCode { get => this._validStatusCode; set => this._validStatusCode = value; }

        /// <summary>Creates an new <see cref="HttpConfiguration" /> instance.</summary>
        public HttpConfiguration()
        {

        }
    }
    /// HTTP configuration of the connectivity check.
    public partial interface IHttpConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of HTTP headers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of HTTP headers.",
        SerializedName = @"headers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader[] Header { get; set; }
        /// <summary>HTTP method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"HTTP method.",
        SerializedName = @"method",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod? Method { get; set; }
        /// <summary>Valid status codes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Valid status codes.",
        SerializedName = @"validStatusCodes",
        PossibleTypes = new [] { typeof(int) })]
        int[] ValidStatusCode { get; set; }

    }
    /// HTTP configuration of the connectivity check.
    internal partial interface IHttpConfigurationInternal

    {
        /// <summary>List of HTTP headers.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader[] Header { get; set; }
        /// <summary>HTTP method.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod? Method { get; set; }
        /// <summary>Valid status codes.</summary>
        int[] ValidStatusCode { get; set; }

    }
}