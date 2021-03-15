namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Web Chat channel definition</summary>
    public partial class WebChatChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannel,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelInternal,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel __channel = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Channel();

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelProperties Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.WebChatChannelProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for WebChatEmbedCode</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelInternal.WebChatEmbedCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelPropertiesInternal)Property).WebChatEmbedCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelPropertiesInternal)Property).WebChatEmbedCode = value; }

        /// <summary>The channel name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name = value ; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelProperties _property;

        /// <summary>The set of properties specific to Web Chat channel resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.WebChatChannelProperties()); set => this._property = value; }

        /// <summary>The list of Web Chat sites</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSite[] Site { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelPropertiesInternal)Property).Site; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelPropertiesInternal)Property).Site = value ?? null /* arrayOf */; }

        /// <summary>Web chat control embed code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string WebChatEmbedCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelPropertiesInternal)Property).WebChatEmbedCode; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__channel), __channel);
            await eventListener.AssertObjectIsValid(nameof(__channel), __channel);
        }

        /// <summary>Creates an new <see cref="WebChatChannel" /> instance.</summary>
        public WebChatChannel()
        {

        }
    }
    /// Web Chat channel definition
    public partial interface IWebChatChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel
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
    /// Web Chat channel definition
    internal partial interface IWebChatChannelInternal :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal
    {
        /// <summary>The set of properties specific to Web Chat channel resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelProperties Property { get; set; }
        /// <summary>The list of Web Chat sites</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSite[] Site { get; set; }
        /// <summary>Web chat control embed code</summary>
        string WebChatEmbedCode { get; set; }

    }
}