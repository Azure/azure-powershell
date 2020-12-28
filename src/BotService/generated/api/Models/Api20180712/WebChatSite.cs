namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>A site for the Webchat channel</summary>
    public partial class WebChatSite :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSite,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSiteInternal
    {

        /// <summary>Backing field for <see cref="EnablePreview" /> property.</summary>
        private bool _enablePreview;

        /// <summary>Whether this site is enabled for preview versions of Webchat</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool EnablePreview { get => this._enablePreview; set => this._enablePreview = value; }

        /// <summary>Backing field for <see cref="IsEnabled" /> property.</summary>
        private bool _isEnabled;

        /// <summary>Whether this site is enabled for DirectLine channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool IsEnabled { get => this._isEnabled; set => this._isEnabled = value; }

        /// <summary>Backing field for <see cref="Key" /> property.</summary>
        private string _key;

        /// <summary>
        /// Primary key. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Key { get => this._key; }

        /// <summary>Backing field for <see cref="Key2" /> property.</summary>
        private string _key2;

        /// <summary>
        /// Secondary key. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Key2 { get => this._key2; }

        /// <summary>Internal Acessors for Key</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSiteInternal.Key { get => this._key; set { {_key = value;} } }

        /// <summary>Internal Acessors for Key2</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSiteInternal.Key2 { get => this._key2; set { {_key2 = value;} } }

        /// <summary>Internal Acessors for SiteId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSiteInternal.SiteId { get => this._siteId; set { {_siteId = value;} } }

        /// <summary>Backing field for <see cref="SiteId" /> property.</summary>
        private string _siteId;

        /// <summary>Site Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string SiteId { get => this._siteId; }

        /// <summary>Backing field for <see cref="SiteName" /> property.</summary>
        private string _siteName;

        /// <summary>Site name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string SiteName { get => this._siteName; set => this._siteName = value; }

        /// <summary>Creates an new <see cref="WebChatSite" /> instance.</summary>
        public WebChatSite()
        {

        }
    }
    /// A site for the Webchat channel
    public partial interface IWebChatSite :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>Whether this site is enabled for preview versions of Webchat</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether this site is enabled for preview versions of Webchat",
        SerializedName = @"enablePreview",
        PossibleTypes = new [] { typeof(bool) })]
        bool EnablePreview { get; set; }
        /// <summary>Whether this site is enabled for DirectLine channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether this site is enabled for DirectLine channel",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsEnabled { get; set; }
        /// <summary>
        /// Primary key. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Primary key. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"key",
        PossibleTypes = new [] { typeof(string) })]
        string Key { get;  }
        /// <summary>
        /// Secondary key. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Secondary key. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"key2",
        PossibleTypes = new [] { typeof(string) })]
        string Key2 { get;  }
        /// <summary>Site Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Site Id",
        SerializedName = @"siteId",
        PossibleTypes = new [] { typeof(string) })]
        string SiteId { get;  }
        /// <summary>Site name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Site name",
        SerializedName = @"siteName",
        PossibleTypes = new [] { typeof(string) })]
        string SiteName { get; set; }

    }
    /// A site for the Webchat channel
    internal partial interface IWebChatSiteInternal

    {
        /// <summary>Whether this site is enabled for preview versions of Webchat</summary>
        bool EnablePreview { get; set; }
        /// <summary>Whether this site is enabled for DirectLine channel</summary>
        bool IsEnabled { get; set; }
        /// <summary>
        /// Primary key. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string Key { get; set; }
        /// <summary>
        /// Secondary key. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string Key2 { get; set; }
        /// <summary>Site Id</summary>
        string SiteId { get; set; }
        /// <summary>Site name</summary>
        string SiteName { get; set; }

    }
}