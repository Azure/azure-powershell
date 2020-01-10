namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Route Filter Rule Resource</summary>
    public partial class RouteFilterRulePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRulePropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRulePropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="Access" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access _access;

        /// <summary>The access type of the rule. Valid values are: 'Allow', 'Deny'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access Access { get => this._access; set => this._access = value; }

        /// <summary>Backing field for <see cref="Community" /> property.</summary>
        private string[] _community;

        /// <summary>
        /// The collection for bgp community values to filter on. e.g. ['12076:5010','12076:5020']
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] Community { get => this._community; set => this._community = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRulePropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for RouteFilterRuleType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRulePropertiesFormatInternal.RouteFilterRuleType { get => this._routeFilterRuleType; set { {_routeFilterRuleType = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="RouteFilterRuleType" /> property.</summary>
        private string _routeFilterRuleType= @"Community";

        /// <summary>The rule type of the rule. Valid value is: 'Community'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RouteFilterRuleType { get => this._routeFilterRuleType; }

        /// <summary>Creates an new <see cref="RouteFilterRulePropertiesFormat" /> instance.</summary>
        public RouteFilterRulePropertiesFormat()
        {

        }
    }
    /// Route Filter Rule Resource
    public partial interface IRouteFilterRulePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The access type of the rule. Valid values are: 'Allow', 'Deny'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The access type of the rule. Valid values are: 'Allow', 'Deny'",
        SerializedName = @"access",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access Access { get; set; }
        /// <summary>
        /// The collection for bgp community values to filter on. e.g. ['12076:5010','12076:5020']
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The collection for bgp community values to filter on. e.g. ['12076:5010','12076:5020']",
        SerializedName = @"communities",
        PossibleTypes = new [] { typeof(string) })]
        string[] Community { get; set; }
        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The rule type of the rule. Valid value is: 'Community'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"The rule type of the rule. Valid value is: 'Community'",
        SerializedName = @"routeFilterRuleType",
        PossibleTypes = new [] { typeof(string) })]
        string RouteFilterRuleType { get;  }

    }
    /// Route Filter Rule Resource
    internal partial interface IRouteFilterRulePropertiesFormatInternal

    {
        /// <summary>The access type of the rule. Valid values are: 'Allow', 'Deny'</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access Access { get; set; }
        /// <summary>
        /// The collection for bgp community values to filter on. e.g. ['12076:5010','12076:5020']
        /// </summary>
        string[] Community { get; set; }
        /// <summary>
        /// The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', 'Succeeded' and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The rule type of the rule. Valid value is: 'Community'</summary>
        string RouteFilterRuleType { get; set; }

    }
}