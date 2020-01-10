namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of redirect configuration of the application gateway.</summary>
    public partial class ApplicationGatewayRedirectConfigurationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="IncludePath" /> property.</summary>
        private bool? _includePath;

        /// <summary>Include path in the redirected url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? IncludePath { get => this._includePath; set => this._includePath = value; }

        /// <summary>Backing field for <see cref="IncludeQueryString" /> property.</summary>
        private bool? _includeQueryString;

        /// <summary>Include query string in the redirected url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? IncludeQueryString { get => this._includeQueryString; set => this._includeQueryString = value; }

        /// <summary>Internal Acessors for TargetListener</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayRedirectConfigurationPropertiesFormatInternal.TargetListener { get => (this._targetListener = this._targetListener ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_targetListener = value;} } }

        /// <summary>Backing field for <see cref="PathRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _pathRule;

        /// <summary>Path rules specifying redirect configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] PathRule { get => this._pathRule; set => this._pathRule = value; }

        /// <summary>Backing field for <see cref="RedirectType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType? _redirectType;

        /// <summary>HTTP redirection type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType? RedirectType { get => this._redirectType; set => this._redirectType = value; }

        /// <summary>Backing field for <see cref="RequestRoutingRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _requestRoutingRule;

        /// <summary>Request routing specifying redirect configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] RequestRoutingRule { get => this._requestRoutingRule; set => this._requestRoutingRule = value; }

        /// <summary>Backing field for <see cref="TargetListener" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _targetListener;

        /// <summary>Reference to a listener to redirect the request to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource TargetListener { get => (this._targetListener = this._targetListener ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._targetListener = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string TargetListenerId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)TargetListener).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)TargetListener).Id = value; }

        /// <summary>Backing field for <see cref="TargetUrl" /> property.</summary>
        private string _targetUrl;

        /// <summary>Url to redirect the request to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TargetUrl { get => this._targetUrl; set => this._targetUrl = value; }

        /// <summary>Backing field for <see cref="UrlPathMap" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _urlPathMap;

        /// <summary>Url path maps specifying default redirect configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] UrlPathMap { get => this._urlPathMap; set => this._urlPathMap = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayRedirectConfigurationPropertiesFormat" /> instance.
        /// </summary>
        public ApplicationGatewayRedirectConfigurationPropertiesFormat()
        {

        }
    }
    /// Properties of redirect configuration of the application gateway.
    public partial interface IApplicationGatewayRedirectConfigurationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Include path in the redirected url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Include path in the redirected url.",
        SerializedName = @"includePath",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IncludePath { get; set; }
        /// <summary>Include query string in the redirected url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Include query string in the redirected url.",
        SerializedName = @"includeQueryString",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IncludeQueryString { get; set; }
        /// <summary>Path rules specifying redirect configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Path rules specifying redirect configuration.",
        SerializedName = @"pathRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] PathRule { get; set; }
        /// <summary>HTTP redirection type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"HTTP redirection type.",
        SerializedName = @"redirectType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType? RedirectType { get; set; }
        /// <summary>Request routing specifying redirect configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Request routing specifying redirect configuration.",
        SerializedName = @"requestRoutingRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] RequestRoutingRule { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string TargetListenerId { get; set; }
        /// <summary>Url to redirect the request to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Url to redirect the request to.",
        SerializedName = @"targetUrl",
        PossibleTypes = new [] { typeof(string) })]
        string TargetUrl { get; set; }
        /// <summary>Url path maps specifying default redirect configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Url path maps specifying default redirect configuration.",
        SerializedName = @"urlPathMaps",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] UrlPathMap { get; set; }

    }
    /// Properties of redirect configuration of the application gateway.
    internal partial interface IApplicationGatewayRedirectConfigurationPropertiesFormatInternal

    {
        /// <summary>Include path in the redirected url.</summary>
        bool? IncludePath { get; set; }
        /// <summary>Include query string in the redirected url.</summary>
        bool? IncludeQueryString { get; set; }
        /// <summary>Path rules specifying redirect configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] PathRule { get; set; }
        /// <summary>HTTP redirection type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayRedirectType? RedirectType { get; set; }
        /// <summary>Request routing specifying redirect configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] RequestRoutingRule { get; set; }
        /// <summary>Reference to a listener to redirect the request to.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource TargetListener { get; set; }
        /// <summary>Resource ID.</summary>
        string TargetListenerId { get; set; }
        /// <summary>Url to redirect the request to.</summary>
        string TargetUrl { get; set; }
        /// <summary>Url path maps specifying default redirect configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] UrlPathMap { get; set; }

    }
}