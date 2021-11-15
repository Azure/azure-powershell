namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The parameters to provide for the Web Chat channel.</summary>
    public partial class WebChatChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelProperties,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelPropertiesInternal
    {

        /// <summary>Internal Acessors for WebChatEmbedCode</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelPropertiesInternal.WebChatEmbedCode { get => this._webChatEmbedCode; set { {_webChatEmbedCode = value;} } }

        /// <summary>Backing field for <see cref="Site" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSite[] _site;

        /// <summary>The list of Web Chat sites</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSite[] Site { get => this._site; set => this._site = value; }

        /// <summary>Backing field for <see cref="WebChatEmbedCode" /> property.</summary>
        private string _webChatEmbedCode;

        /// <summary>Web chat control embed code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string WebChatEmbedCode { get => this._webChatEmbedCode; }

        /// <summary>Creates an new <see cref="WebChatChannelProperties" /> instance.</summary>
        public WebChatChannelProperties()
        {

        }
    }
    /// The parameters to provide for the Web Chat channel.
    public partial interface IWebChatChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>The list of Web Chat sites</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of Web Chat sites",
        SerializedName = @"sites",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSite) })]
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSite[] Site { get; set; }
        /// <summary>Web chat control embed code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Web chat control embed code",
        SerializedName = @"webChatEmbedCode",
        PossibleTypes = new [] { typeof(string) })]
        string WebChatEmbedCode { get;  }

    }
    /// The parameters to provide for the Web Chat channel.
    internal partial interface IWebChatChannelPropertiesInternal

    {
        /// <summary>The list of Web Chat sites</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSite[] Site { get; set; }
        /// <summary>Web chat control embed code</summary>
        string WebChatEmbedCode { get; set; }

    }
}