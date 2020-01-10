namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>ExpressRouteLink child resource definition.</summary>
    public partial class ExpressRouteLink :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLink,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource();

        /// <summary>Administrative state of the physical port</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkAdminState? AdminState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).AdminState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).AdminState = value; }

        /// <summary>Physical fiber port type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType? ConnectorType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).ConnectorType; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>Name of Azure router interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string InterfaceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).InterfaceName; }

        /// <summary>Internal Acessors for ConnectorType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkInternal.ConnectorType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).ConnectorType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).ConnectorType = value; }

        /// <summary>Internal Acessors for Etag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkInternal.Etag { get => this._etag; set { {_etag = value;} } }

        /// <summary>Internal Acessors for InterfaceName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkInternal.InterfaceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).InterfaceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).InterfaceName = value; }

        /// <summary>Internal Acessors for PatchPanelId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkInternal.PatchPanelId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).PatchPanelId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).PatchPanelId = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteLinkPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for RackId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkInternal.RackId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).RackId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).RackId = value; }

        /// <summary>Internal Acessors for RouterName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkInternal.RouterName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).RouterName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).RouterName = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Name of child port resource that is unique among child port resources of the parent.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Mapping between physical port to patch panel port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PatchPanelId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).PatchPanelId; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormat _property;

        /// <summary>ExpressRouteLink properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteLinkPropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// The provisioning state of the ExpressRouteLink resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and
        /// 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).ProvisioningState; }

        /// <summary>Mapping of physical patch panel to rack.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RackId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).RackId; }

        /// <summary>Name of Azure router associated with physical port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RouterName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormatInternal)Property).RouterName; }

        /// <summary>Creates an new <see cref="ExpressRouteLink" /> instance.</summary>
        public ExpressRouteLink()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__subResource), __subResource);
            await eventListener.AssertObjectIsValid(nameof(__subResource), __subResource);
        }
    }
    /// ExpressRouteLink child resource definition.
    public partial interface IExpressRouteLink :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource
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
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get;  }
        /// <summary>Name of Azure router interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of Azure router interface.",
        SerializedName = @"interfaceName",
        PossibleTypes = new [] { typeof(string) })]
        string InterfaceName { get;  }
        /// <summary>
        /// Name of child port resource that is unique among child port resources of the parent.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of child port resource that is unique among child port resources of the parent.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
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
    /// ExpressRouteLink child resource definition.
    internal partial interface IExpressRouteLinkInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal
    {
        /// <summary>Administrative state of the physical port</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkAdminState? AdminState { get; set; }
        /// <summary>Physical fiber port type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteLinkConnectorType? ConnectorType { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>Name of Azure router interface.</summary>
        string InterfaceName { get; set; }
        /// <summary>
        /// Name of child port resource that is unique among child port resources of the parent.
        /// </summary>
        string Name { get; set; }
        /// <summary>Mapping between physical port to patch panel port.</summary>
        string PatchPanelId { get; set; }
        /// <summary>ExpressRouteLink properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLinkPropertiesFormat Property { get; set; }
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