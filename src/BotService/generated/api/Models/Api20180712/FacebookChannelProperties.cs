namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The parameters to provide for the Facebook channel.</summary>
    public partial class FacebookChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelProperties,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AppId" /> property.</summary>
        private string _appId;

        /// <summary>Facebook application id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string AppId { get => this._appId; set => this._appId = value; }

        /// <summary>Backing field for <see cref="AppSecret" /> property.</summary>
        private string _appSecret;

        /// <summary>
        /// Facebook application secret. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string AppSecret { get => this._appSecret; set => this._appSecret = value; }

        /// <summary>Backing field for <see cref="CallbackUrl" /> property.</summary>
        private string _callbackUrl;

        /// <summary>Callback Url</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string CallbackUrl { get => this._callbackUrl; }

        /// <summary>Backing field for <see cref="IsEnabled" /> property.</summary>
        private bool _isEnabled;

        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool IsEnabled { get => this._isEnabled; set => this._isEnabled = value; }

        /// <summary>Internal Acessors for CallbackUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal.CallbackUrl { get => this._callbackUrl; set { {_callbackUrl = value;} } }

        /// <summary>Internal Acessors for VerifyToken</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookChannelPropertiesInternal.VerifyToken { get => this._verifyToken; set { {_verifyToken = value;} } }

        /// <summary>Backing field for <see cref="Page" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookPage[] _page;

        /// <summary>The list of Facebook pages</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookPage[] Page { get => this._page; set => this._page = value; }

        /// <summary>Backing field for <see cref="VerifyToken" /> property.</summary>
        private string _verifyToken;

        /// <summary>
        /// Verify token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string VerifyToken { get => this._verifyToken; }

        /// <summary>Creates an new <see cref="FacebookChannelProperties" /> instance.</summary>
        public FacebookChannelProperties()
        {

        }
    }
    /// The parameters to provide for the Facebook channel.
    public partial interface IFacebookChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>Facebook application id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Facebook application id",
        SerializedName = @"appId",
        PossibleTypes = new [] { typeof(string) })]
        string AppId { get; set; }
        /// <summary>
        /// Facebook application secret. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
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
        Required = true,
        ReadOnly = false,
        Description = @"Whether this channel is enabled for the bot",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsEnabled { get; set; }
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
    /// The parameters to provide for the Facebook channel.
    internal partial interface IFacebookChannelPropertiesInternal

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
        bool IsEnabled { get; set; }
        /// <summary>The list of Facebook pages</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IFacebookPage[] Page { get; set; }
        /// <summary>
        /// Verify token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string VerifyToken { get; set; }

    }
}