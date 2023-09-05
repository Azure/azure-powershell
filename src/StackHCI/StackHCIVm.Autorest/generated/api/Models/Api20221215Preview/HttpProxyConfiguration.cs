namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>HTTP Proxy configuration for the VM.</summary>
    public partial class HttpProxyConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHttpProxyConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHttpProxyConfigurationInternal
    {

        /// <summary>Backing field for <see cref="HttpsProxy" /> property.</summary>
        private string _httpsProxy;

        /// <summary>The httpsProxy url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string HttpsProxy { get => this._httpsProxy; set => this._httpsProxy = value; }

        /// <summary>Creates an new <see cref="HttpProxyConfiguration" /> instance.</summary>
        public HttpProxyConfiguration()
        {

        }
    }
    /// HTTP Proxy configuration for the VM.
    public partial interface IHttpProxyConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>The httpsProxy url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The httpsProxy url.",
        SerializedName = @"httpsProxy",
        PossibleTypes = new [] { typeof(string) })]
        string HttpsProxy { get; set; }

    }
    /// HTTP Proxy configuration for the VM.
    internal partial interface IHttpProxyConfigurationInternal

    {
        /// <summary>The httpsProxy url.</summary>
        string HttpsProxy { get; set; }

    }
}