namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The container Http Get settings, for liveness or readiness probe</summary>
    public partial class ContainerHttpGet :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGet,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGetInternal
    {

        /// <summary>Backing field for <see cref="HttpHeader" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeaders _httpHeader;

        /// <summary>The HTTP headers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeaders HttpHeader { get => (this._httpHeader = this._httpHeader ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.HttpHeaders()); set => this._httpHeader = value; }

        /// <summary>The header name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string HttpHeaderName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeadersInternal)HttpHeader).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeadersInternal)HttpHeader).Name = value ?? null; }

        /// <summary>The header value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string HttpHeaderValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeadersInternal)HttpHeader).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeadersInternal)HttpHeader).Value = value ?? null; }

        /// <summary>Internal Acessors for HttpHeader</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeaders Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerHttpGetInternal.HttpHeader { get => (this._httpHeader = this._httpHeader ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.HttpHeaders()); set { {_httpHeader = value;} } }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string _path;

        /// <summary>The path to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Path { get => this._path; set => this._path = value; }

        /// <summary>Backing field for <see cref="Port" /> property.</summary>
        private int _port;

        /// <summary>The port number to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int Port { get => this._port; set => this._port = value; }

        /// <summary>Backing field for <see cref="Scheme" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? _scheme;

        /// <summary>The scheme.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? Scheme { get => this._scheme; set => this._scheme = value; }

        /// <summary>Creates an new <see cref="ContainerHttpGet" /> instance.</summary>
        public ContainerHttpGet()
        {

        }
    }
    /// The container Http Get settings, for liveness or readiness probe
    public partial interface IContainerHttpGet :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The header name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The header name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string HttpHeaderName { get; set; }
        /// <summary>The header value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The header value.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string HttpHeaderValue { get; set; }
        /// <summary>The path to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The path to probe.",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get; set; }
        /// <summary>The port number to probe.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The port number to probe.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int Port { get; set; }
        /// <summary>The scheme.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The scheme.",
        SerializedName = @"scheme",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? Scheme { get; set; }

    }
    /// The container Http Get settings, for liveness or readiness probe
    internal partial interface IContainerHttpGetInternal

    {
        /// <summary>The HTTP headers.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IHttpHeaders HttpHeader { get; set; }
        /// <summary>The header name.</summary>
        string HttpHeaderName { get; set; }
        /// <summary>The header value.</summary>
        string HttpHeaderValue { get; set; }
        /// <summary>The path to probe.</summary>
        string Path { get; set; }
        /// <summary>The port number to probe.</summary>
        int Port { get; set; }
        /// <summary>The scheme.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme? Scheme { get; set; }

    }
}