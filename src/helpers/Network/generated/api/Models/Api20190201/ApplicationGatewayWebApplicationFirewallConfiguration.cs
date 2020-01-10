namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Application gateway web application firewall configuration.</summary>
    public partial class ApplicationGatewayWebApplicationFirewallConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayWebApplicationFirewallConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayWebApplicationFirewallConfigurationInternal
    {

        /// <summary>Backing field for <see cref="DisabledRuleGroup" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallDisabledRuleGroup[] _disabledRuleGroup;

        /// <summary>The disabled rule groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallDisabledRuleGroup[] DisabledRuleGroup { get => this._disabledRuleGroup; set => this._disabledRuleGroup = value; }

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool _enabled;

        /// <summary>Whether the web application firewall is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Backing field for <see cref="Exclusion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallExclusion[] _exclusion;

        /// <summary>The exclusion list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallExclusion[] Exclusion { get => this._exclusion; set => this._exclusion = value; }

        /// <summary>Backing field for <see cref="FileUploadLimitInMb" /> property.</summary>
        private int? _fileUploadLimitInMb;

        /// <summary>Maximum file upload size in Mb for WAF.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? FileUploadLimitInMb { get => this._fileUploadLimitInMb; set => this._fileUploadLimitInMb = value; }

        /// <summary>Backing field for <see cref="FirewallMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode _firewallMode;

        /// <summary>Web application firewall mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode FirewallMode { get => this._firewallMode; set => this._firewallMode = value; }

        /// <summary>Backing field for <see cref="MaxRequestBodySize" /> property.</summary>
        private int? _maxRequestBodySize;

        /// <summary>Maximum request body size for WAF.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? MaxRequestBodySize { get => this._maxRequestBodySize; set => this._maxRequestBodySize = value; }

        /// <summary>Backing field for <see cref="MaxRequestBodySizeInKb" /> property.</summary>
        private int? _maxRequestBodySizeInKb;

        /// <summary>Maximum request body size in Kb for WAF.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? MaxRequestBodySizeInKb { get => this._maxRequestBodySizeInKb; set => this._maxRequestBodySizeInKb = value; }

        /// <summary>Backing field for <see cref="RequestBodyCheck" /> property.</summary>
        private bool? _requestBodyCheck;

        /// <summary>Whether allow WAF to check request Body.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? RequestBodyCheck { get => this._requestBodyCheck; set => this._requestBodyCheck = value; }

        /// <summary>Backing field for <see cref="RuleSetType" /> property.</summary>
        private string _ruleSetType;

        /// <summary>
        /// The type of the web application firewall rule set. Possible values are: 'OWASP'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RuleSetType { get => this._ruleSetType; set => this._ruleSetType = value; }

        /// <summary>Backing field for <see cref="RuleSetVersion" /> property.</summary>
        private string _ruleSetVersion;

        /// <summary>The version of the rule set type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RuleSetVersion { get => this._ruleSetVersion; set => this._ruleSetVersion = value; }

        /// <summary>
        /// Creates an new <see cref="ApplicationGatewayWebApplicationFirewallConfiguration" /> instance.
        /// </summary>
        public ApplicationGatewayWebApplicationFirewallConfiguration()
        {

        }
    }
    /// Application gateway web application firewall configuration.
    public partial interface IApplicationGatewayWebApplicationFirewallConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The disabled rule groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The disabled rule groups.",
        SerializedName = @"disabledRuleGroups",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallDisabledRuleGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallDisabledRuleGroup[] DisabledRuleGroup { get; set; }
        /// <summary>Whether the web application firewall is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether the web application firewall is enabled or not.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool Enabled { get; set; }
        /// <summary>The exclusion list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The exclusion list.",
        SerializedName = @"exclusions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallExclusion) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallExclusion[] Exclusion { get; set; }
        /// <summary>Maximum file upload size in Mb for WAF.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum file upload size in Mb for WAF.",
        SerializedName = @"fileUploadLimitInMb",
        PossibleTypes = new [] { typeof(int) })]
        int? FileUploadLimitInMb { get; set; }
        /// <summary>Web application firewall mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Web application firewall mode.",
        SerializedName = @"firewallMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode FirewallMode { get; set; }
        /// <summary>Maximum request body size for WAF.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum request body size for WAF.",
        SerializedName = @"maxRequestBodySize",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxRequestBodySize { get; set; }
        /// <summary>Maximum request body size in Kb for WAF.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum request body size in Kb for WAF.",
        SerializedName = @"maxRequestBodySizeInKb",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxRequestBodySizeInKb { get; set; }
        /// <summary>Whether allow WAF to check request Body.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether allow WAF to check request Body.",
        SerializedName = @"requestBodyCheck",
        PossibleTypes = new [] { typeof(bool) })]
        bool? RequestBodyCheck { get; set; }
        /// <summary>
        /// The type of the web application firewall rule set. Possible values are: 'OWASP'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The type of the web application firewall rule set. Possible values are: 'OWASP'.",
        SerializedName = @"ruleSetType",
        PossibleTypes = new [] { typeof(string) })]
        string RuleSetType { get; set; }
        /// <summary>The version of the rule set type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The version of the rule set type.",
        SerializedName = @"ruleSetVersion",
        PossibleTypes = new [] { typeof(string) })]
        string RuleSetVersion { get; set; }

    }
    /// Application gateway web application firewall configuration.
    internal partial interface IApplicationGatewayWebApplicationFirewallConfigurationInternal

    {
        /// <summary>The disabled rule groups.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallDisabledRuleGroup[] DisabledRuleGroup { get; set; }
        /// <summary>Whether the web application firewall is enabled or not.</summary>
        bool Enabled { get; set; }
        /// <summary>The exclusion list.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayFirewallExclusion[] Exclusion { get; set; }
        /// <summary>Maximum file upload size in Mb for WAF.</summary>
        int? FileUploadLimitInMb { get; set; }
        /// <summary>Web application firewall mode.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayFirewallMode FirewallMode { get; set; }
        /// <summary>Maximum request body size for WAF.</summary>
        int? MaxRequestBodySize { get; set; }
        /// <summary>Maximum request body size in Kb for WAF.</summary>
        int? MaxRequestBodySizeInKb { get; set; }
        /// <summary>Whether allow WAF to check request Body.</summary>
        bool? RequestBodyCheck { get; set; }
        /// <summary>
        /// The type of the web application firewall rule set. Possible values are: 'OWASP'.
        /// </summary>
        string RuleSetType { get; set; }
        /// <summary>The version of the rule set type.</summary>
        string RuleSetVersion { get; set; }

    }
}