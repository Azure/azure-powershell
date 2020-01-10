namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the application rule collection.</summary>
    public partial class AzureFirewallApplicationRuleCollectionPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleCollectionPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleCollectionPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallRcAction _action;

        /// <summary>The action type of a rule collection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallRcAction Action { get => (this._action = this._action ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureFirewallRcAction()); set => this._action = value; }

        /// <summary>The type of action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallRcActionType? ActionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallRcActionInternal)Action).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallRcActionInternal)Action).Type = value; }

        /// <summary>Internal Acessors for Action</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallRcAction Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleCollectionPropertiesFormatInternal.Action { get => (this._action = this._action ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureFirewallRcAction()); set { {_action = value;} } }

        /// <summary>Backing field for <see cref="Priority" /> property.</summary>
        private int? _priority;

        /// <summary>Priority of the application rule collection resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Priority { get => this._priority; set => this._priority = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="Rule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRule[] _rule;

        /// <summary>Collection of rules used by a application rule collection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRule[] Rule { get => this._rule; set => this._rule = value; }

        /// <summary>
        /// Creates an new <see cref="AzureFirewallApplicationRuleCollectionPropertiesFormat" /> instance.
        /// </summary>
        public AzureFirewallApplicationRuleCollectionPropertiesFormat()
        {

        }
    }
    /// Properties of the application rule collection.
    public partial interface IAzureFirewallApplicationRuleCollectionPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The type of action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of action.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallRcActionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallRcActionType? ActionType { get; set; }
        /// <summary>Priority of the application rule collection resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Priority of the application rule collection resource.",
        SerializedName = @"priority",
        PossibleTypes = new [] { typeof(int) })]
        int? Priority { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Collection of rules used by a application rule collection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of rules used by a application rule collection.",
        SerializedName = @"rules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRule[] Rule { get; set; }

    }
    /// Properties of the application rule collection.
    internal partial interface IAzureFirewallApplicationRuleCollectionPropertiesFormatInternal

    {
        /// <summary>The action type of a rule collection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallRcAction Action { get; set; }
        /// <summary>The type of action.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallRcActionType? ActionType { get; set; }
        /// <summary>Priority of the application rule collection resource.</summary>
        int? Priority { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Collection of rules used by a application rule collection.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRule[] Rule { get; set; }

    }
}