namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties specific to ExpressRouteLink resources.</summary>
    public partial class ExpressRouteLinkPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="AdminState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkAdminState? _adminState;

        /// <summary>Administrative state of the physical port</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkAdminState? AdminState { get => this._adminState; set => this._adminState = value; }

        /// <summary>Backing field for <see cref="ConnectorType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType? _connectorType;

        /// <summary>Physical fiber port type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType? ConnectorType { get => this._connectorType; }

        /// <summary>Backing field for <see cref="InterfaceName" /> property.</summary>
        private string _interfaceName;

        /// <summary>Name of Azure router interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string InterfaceName { get => this._interfaceName; }

        /// <summary>Internal Acessors for ConnectorType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal.ConnectorType { get => this._connectorType; set { {_connectorType = value;} } }

        /// <summary>Internal Acessors for InterfaceName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal.InterfaceName { get => this._interfaceName; set { {_interfaceName = value;} } }

        /// <summary>Internal Acessors for PatchPanelId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal.PatchPanelId { get => this._patchPanelId; set { {_patchPanelId = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for RackId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal.RackId { get => this._rackId; set { {_rackId = value;} } }

        /// <summary>Internal Acessors for RouterName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal.RouterName { get => this._routerName; set { {_routerName = value;} } }

        /// <summary>Backing field for <see cref="PatchPanelId" /> property.</summary>
        private string _patchPanelId;

        /// <summary>Mapping between physical port to patch panel port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PatchPanelId { get => this._patchPanelId; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the ExpressRouteLink resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and
        /// 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="RackId" /> property.</summary>
        private string _rackId;

        /// <summary>Mapping of physical patch panel to rack.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RackId { get => this._rackId; }

        /// <summary>Backing field for <see cref="RouterName" /> property.</summary>
        private string _routerName;

        /// <summary>Name of Azure router associated with physical port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RouterName { get => this._routerName; }

        /// <summary>Creates an new <see cref="ExpressRouteLinkPropertiesFormat" /> instance.</summary>
        public ExpressRouteLinkPropertiesFormat()
        {

        }
    }
    /// Properties specific to ExpressRouteLink resources.
    public partial interface IExpressRouteLinkPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Administrative state of the physical port</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Administrative state of the physical port",
        SerializedName = @"adminState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkAdminState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkAdminState? AdminState { get; set; }
        /// <summary>Physical fiber port type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Physical fiber port type.",
        SerializedName = @"connectorType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType? ConnectorType { get;  }
        /// <summary>Name of Azure router interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of Azure router interface.",
        SerializedName = @"interfaceName",
        PossibleTypes = new [] { typeof(string) })]
        string InterfaceName { get;  }
        /// <summary>Mapping between physical port to patch panel port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Mapping between physical port to patch panel port.",
        SerializedName = @"patchPanelId",
        PossibleTypes = new [] { typeof(string) })]
        string PatchPanelId { get;  }
        /// <summary>
        /// The provisioning state of the ExpressRouteLink resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and
        /// 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the ExpressRouteLink resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>Mapping of physical patch panel to rack.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Mapping of physical patch panel to rack.",
        SerializedName = @"rackId",
        PossibleTypes = new [] { typeof(string) })]
        string RackId { get;  }
        /// <summary>Name of Azure router associated with physical port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of Azure router associated with physical port.",
        SerializedName = @"routerName",
        PossibleTypes = new [] { typeof(string) })]
        string RouterName { get;  }

    }
    /// Properties specific to ExpressRouteLink resources.
    internal partial interface IExpressRouteLinkPropertiesFormatInternal

    {
        /// <summary>Administrative state of the physical port</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkAdminState? AdminState { get; set; }
        /// <summary>Physical fiber port type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType? ConnectorType { get; set; }
        /// <summary>Name of Azure router interface.</summary>
        string InterfaceName { get; set; }
        /// <summary>Mapping between physical port to patch panel port.</summary>
        string PatchPanelId { get; set; }
        /// <summary>
        /// The provisioning state of the ExpressRouteLink resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and
        /// 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>Mapping of physical patch panel to rack.</summary>
        string RackId { get; set; }
        /// <summary>Name of Azure router associated with physical port.</summary>
        string RouterName { get; set; }

    }
}