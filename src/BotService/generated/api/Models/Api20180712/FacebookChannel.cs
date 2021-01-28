namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Facebook channel definition</summary>
    public partial class FacebookChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannel,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelInternal,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel __channel = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Channel();

        /// <summary>Facebook application id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string AppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal)Property).AppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal)Property).AppId = value ?? null; }

        /// <summary>
        /// Facebook application secret. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string AppSecret { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal)Property).AppSecret; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal)Property).AppSecret = value ?? null; }

        /// <summary>Callback Url</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string CallbackUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal)Property).CallbackUrl; }

        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? IsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal)Property).IsEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal)Property).IsEnabled = value ?? default(bool); }

        /// <summary>Internal Acessors for CallbackUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelInternal.CallbackUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal)Property).CallbackUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal)Property).CallbackUrl = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelProperties Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.FacebookChannelProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for VerifyToken</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelInternal.VerifyToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal)Property).VerifyToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal)Property).VerifyToken = value; }

        /// <summary>The channel name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name = value ; }

        /// <summary>The list of Facebook pages</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookPage[] Page { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal)Property).Page; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal)Property).Page = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelProperties _property;

        /// <summary>The set of properties specific to bot facebook channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.FacebookChannelProperties()); set => this._property = value; }

        /// <summary>
        /// Verify token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string VerifyToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal)Property).VerifyToken; }

        /// <summary>Creates an new <see cref="FacebookChannel" /> instance.</summary>
        public FacebookChannel()
        {

        }

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
    }
    /// Facebook channel definition
    public partial interface IFacebookChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel
    {
        /// <summary>Facebook application id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Facebook application id",
        SerializedName = @"appId",
        PossibleTypes = new [] { typeof(string) })]
        string AppId { get; set; }
        /// <summary>
        /// Facebook application secret. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Facebook application secret. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"appSecret",
        PossibleTypes = new [] { typeof(string) })]
        string AppSecret { get; set; }
        /// <summary>Callback Url</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Callback Url",
        SerializedName = @"callbackUrl",
        PossibleTypes = new [] { typeof(string) })]
        string CallbackUrl { get;  }
        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether this channel is enabled for the bot",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsEnabled { get; set; }
        /// <summary>The list of Facebook pages</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of Facebook pages",
        SerializedName = @"pages",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookPage) })]
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookPage[] Page { get; set; }
        /// <summary>
        /// Verify token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Verify token. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"verifyToken",
        PossibleTypes = new [] { typeof(string) })]
        string VerifyToken { get;  }

    }
    /// Facebook channel definition
    internal partial interface IFacebookChannelInternal :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal
    {
        /// <summary>Facebook application id</summary>
        string AppId { get; set; }
        /// <summary>
        /// Facebook application secret. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string AppSecret { get; set; }
        /// <summary>Callback Url</summary>
        string CallbackUrl { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        bool? IsEnabled { get; set; }
        /// <summary>The list of Facebook pages</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookPage[] Page { get; set; }
        /// <summary>The set of properties specific to bot facebook channel</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelProperties Property { get; set; }
        /// <summary>
        /// Verify token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string VerifyToken { get; set; }

    }
}