namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>RouteTable for the subnet</summary>
    public partial class ComponentsI4F0MhSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetable :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IComponentsI4F0MhSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetable,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IComponentsI4F0MhSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetableInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>
        /// Etag - Gets a unique read-only string that changes whenever the resource is updated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IComponents3Iu67JSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetableProperties Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IComponentsI4F0MhSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetableInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.Components3Iu67JSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetableProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name - READ-ONLY; Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IComponents3Iu67JSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetableProperties _property;

        /// <summary>RouteTablePropertiesFormat route Table resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IComponents3Iu67JSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetableProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.Components3Iu67JSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetableProperties()); set => this._property = value; }

        /// <summary>Routes - Collection of routes contained within a route table.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsPropertiesItemsItem[] Route { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IComponents3Iu67JSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetablePropertiesInternal)Property).Route; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IComponents3Iu67JSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetablePropertiesInternal)Property).Route = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type - READ-ONLY; Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>
        /// Creates an new <see cref="ComponentsI4F0MhSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetable" />
        /// instance.
        /// </summary>
        public ComponentsI4F0MhSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetable()
        {

        }
    }
    /// RouteTable for the subnet
    public partial interface IComponentsI4F0MhSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetable :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Etag - Gets a unique read-only string that changes whenever the resource is updated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Etag - Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Name - READ-ONLY; Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name - READ-ONLY; Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Routes - Collection of routes contained within a route table.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Routes - Collection of routes contained within a route table.",
        SerializedName = @"routes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsPropertiesItemsItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsPropertiesItemsItem[] Route { get; set; }
        /// <summary>Type - READ-ONLY; Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type - READ-ONLY; Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// RouteTable for the subnet
    internal partial interface IComponentsI4F0MhSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetableInternal

    {
        /// <summary>
        /// Etag - Gets a unique read-only string that changes whenever the resource is updated.
        /// </summary>
        string Id { get; set; }
        /// <summary>Name - READ-ONLY; Resource name.</summary>
        string Name { get; set; }
        /// <summary>RouteTablePropertiesFormat route Table resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IComponents3Iu67JSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesRoutetableProperties Property { get; set; }
        /// <summary>Routes - Collection of routes contained within a route table.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkPropertiesSubnetsPropertiesItemsItem[] Route { get; set; }
        /// <summary>Type - READ-ONLY; Resource type.</summary>
        string Type { get; set; }

    }
}