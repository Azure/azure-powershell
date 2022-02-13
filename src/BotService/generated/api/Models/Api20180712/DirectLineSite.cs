namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>A site for the Direct Line channel</summary>
    public partial class DirectLineSite :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal
    {

        /// <summary>Backing field for <see cref="IsEnabled" /> property.</summary>
        private bool _isEnabled;

        /// <summary>Whether this site is enabled for DirectLine channel.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool IsEnabled { get => this._isEnabled; set => this._isEnabled = value; }

        /// <summary>Backing field for <see cref="IsSecureSiteEnabled" /> property.</summary>
        private bool? _isSecureSiteEnabled;

        /// <summary>Whether this site is enabled for authentication with Bot Framework.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool? IsSecureSiteEnabled { get => this._isSecureSiteEnabled; set => this._isSecureSiteEnabled = value; }

        /// <summary>Backing field for <see cref="IsV1Enabled" /> property.</summary>
        private bool _isV1Enabled;

        /// <summary>Whether this site is enabled for Bot Framework V1 protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool IsV1Enabled { get => this._isV1Enabled; set => this._isV1Enabled = value; }

        /// <summary>Backing field for <see cref="IsV3Enabled" /> property.</summary>
        private bool _isV3Enabled;

        /// <summary>Whether this site is enabled for Bot Framework V1 protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool IsV3Enabled { get => this._isV3Enabled; set => this._isV3Enabled = value; }

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
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal.Key { get => this._key; set { {_key = value;} } }

        /// <summary>Internal Acessors for Key2</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal.Key2 { get => this._key2; set { {_key2 = value;} } }

        /// <summary>Internal Acessors for SiteId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal.SiteId { get => this._siteId; set { {_siteId = value;} } }

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

        /// <summary>Backing field for <see cref="TrustedOrigin" /> property.</summary>
        private string[] _trustedOrigin;

        /// <summary>
        /// List of Trusted Origin URLs for this site. This field is applicable only if isSecureSiteEnabled is True.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string[] TrustedOrigin { get => this._trustedOrigin; set => this._trustedOrigin = value; }

        /// <summary>Creates an new <see cref="DirectLineSite" /> instance.</summary>
        public DirectLineSite()
        {

        }
    }
    /// A site for the Direct Line channel
    public partial interface IDirectLineSite :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>Whether this site is enabled for DirectLine channel.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether this site is enabled for DirectLine channel.",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsEnabled { get; set; }
        /// <summary>Whether this site is enabled for authentication with Bot Framework.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether this site is enabled for authentication with Bot Framework.",
        SerializedName = @"isSecureSiteEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsSecureSiteEnabled { get; set; }
        /// <summary>Whether this site is enabled for Bot Framework V1 protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether this site is enabled for Bot Framework V1 protocol.",
        SerializedName = @"isV1Enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsV1Enabled { get; set; }
        /// <summary>Whether this site is enabled for Bot Framework V1 protocol.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether this site is enabled for Bot Framework V1 protocol.",
        SerializedName = @"isV3Enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsV3Enabled { get; set; }
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
        /// <summary>
        /// List of Trusted Origin URLs for this site. This field is applicable only if isSecureSiteEnabled is True.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of Trusted Origin URLs for this site. This field is applicable only if isSecureSiteEnabled is True.",
        SerializedName = @"trustedOrigins",
        PossibleTypes = new [] { typeof(string) })]
        string[] TrustedOrigin { get; set; }

    }
    /// A site for the Direct Line channel
    internal partial interface IDirectLineSiteInternal

    {
        /// <summary>Whether this site is enabled for DirectLine channel.</summary>
        bool IsEnabled { get; set; }
        /// <summary>Whether this site is enabled for authentication with Bot Framework.</summary>
        bool? IsSecureSiteEnabled { get; set; }
        /// <summary>Whether this site is enabled for Bot Framework V1 protocol.</summary>
        bool IsV1Enabled { get; set; }
        /// <summary>Whether this site is enabled for Bot Framework V1 protocol.</summary>
        bool IsV3Enabled { get; set; }
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
        /// <summary>
        /// List of Trusted Origin URLs for this site. This field is applicable only if isSecureSiteEnabled is True.
        /// </summary>
        string[] TrustedOrigin { get; set; }

    }
}