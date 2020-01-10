namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of container network interface.</summary>
    public partial class ContainerNetworkInterfacePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="Container" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainer _container;

        /// <summary>
        /// Reference to the container to which this container network interface is attached.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainer Container { get => (this._container = this._container ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Container()); set => this._container = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ContainerId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)Container).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)Container).Id = value; }

        /// <summary>
        /// A list of container network interfaces created from this container network interface configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] ContainerNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).ContainerNetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).ContainerNetworkInterface = value; }

        /// <summary>
        /// Backing field for <see cref="ContainerNetworkInterfaceConfiguration" /> property.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfiguration _containerNetworkInterfaceConfiguration;

        /// <summary>
        /// Container network interface configuration from which this container network interface is created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfiguration ContainerNetworkInterfaceConfiguration { get => (this._containerNetworkInterfaceConfiguration = this._containerNetworkInterfaceConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ContainerNetworkInterfaceConfiguration()); set => this._containerNetworkInterfaceConfiguration = value; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ContainerNetworkInterfaceConfigurationEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).Etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ContainerNetworkInterfaceConfigurationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)ContainerNetworkInterfaceConfiguration).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)ContainerNetworkInterfaceConfiguration).Id = value; }

        /// <summary>The name of the resource. This name can be used to access the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ContainerNetworkInterfaceConfigurationName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).Name = value; }

        /// <summary>A list of ip configurations of the container network interface configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile[] ContainerNetworkInterfaceConfigurationPropertiesIPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).IPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).IPConfiguration = value; }

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ContainerNetworkInterfaceConfigurationPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).ProvisioningState; }

        /// <summary>Sub Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ContainerNetworkInterfaceConfigurationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).Type; }

        /// <summary>Backing field for <see cref="IPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceIPConfiguration[] _iPConfiguration;

        /// <summary>Reference to the ip configuration on this container nic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceIPConfiguration[] IPConfiguration { get => this._iPConfiguration; set => this._iPConfiguration = value; }

        /// <summary>Internal Acessors for Container</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainer Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal.Container { get => (this._container = this._container ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Container()); set { {_container = value;} } }

        /// <summary>Internal Acessors for ContainerNetworkInterfaceConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfiguration Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal.ContainerNetworkInterfaceConfiguration { get => (this._containerNetworkInterfaceConfiguration = this._containerNetworkInterfaceConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ContainerNetworkInterfaceConfiguration()); set { {_containerNetworkInterfaceConfiguration = value;} } }

        /// <summary>
        /// Internal Acessors for ContainerNetworkInterfaceConfigurationPropertiesProvisioningState
        /// </summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal.ContainerNetworkInterfaceConfigurationPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).ProvisioningState = value; }

        /// <summary>Internal Acessors for ContainerNetworkInterfaceConfigurationProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal.ContainerNetworkInterfaceConfigurationProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).Property = value; }

        /// <summary>Internal Acessors for ContainerNetworkInterfaceConfigurationType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal.ContainerNetworkInterfaceConfigurationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationInternal)ContainerNetworkInterfaceConfiguration).Type = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfacePropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>
        /// Creates an new <see cref="ContainerNetworkInterfacePropertiesFormat" /> instance.
        /// </summary>
        public ContainerNetworkInterfacePropertiesFormat()
        {

        }
    }
    /// Properties of container network interface.
    public partial interface IContainerNetworkInterfacePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerId { get; set; }
        /// <summary>
        /// A list of container network interfaces created from this container network interface configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of container network interfaces created from this container network interface configuration.",
        SerializedName = @"containerNetworkInterfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] ContainerNetworkInterface { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerNetworkInterfaceConfigurationEtag { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerNetworkInterfaceConfigurationId { get; set; }
        /// <summary>The name of the resource. This name can be used to access the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the resource. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerNetworkInterfaceConfigurationName { get; set; }
        /// <summary>A list of ip configurations of the container network interface configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of ip configurations of the container network interface configuration.",
        SerializedName = @"ipConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile[] ContainerNetworkInterfaceConfigurationPropertiesIPConfiguration { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerNetworkInterfaceConfigurationPropertiesProvisioningState { get;  }
        /// <summary>Sub Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Sub Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerNetworkInterfaceConfigurationType { get;  }
        /// <summary>Reference to the ip configuration on this container nic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Reference to the ip configuration on this container nic.",
        SerializedName = @"ipConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }

    }
    /// Properties of container network interface.
    internal partial interface IContainerNetworkInterfacePropertiesFormatInternal

    {
        /// <summary>
        /// Reference to the container to which this container network interface is attached.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainer Container { get; set; }
        /// <summary>Resource ID.</summary>
        string ContainerId { get; set; }
        /// <summary>
        /// A list of container network interfaces created from this container network interface configuration.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] ContainerNetworkInterface { get; set; }
        /// <summary>
        /// Container network interface configuration from which this container network interface is created.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfiguration ContainerNetworkInterfaceConfiguration { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string ContainerNetworkInterfaceConfigurationEtag { get; set; }
        /// <summary>Resource ID.</summary>
        string ContainerNetworkInterfaceConfigurationId { get; set; }
        /// <summary>The name of the resource. This name can be used to access the resource.</summary>
        string ContainerNetworkInterfaceConfigurationName { get; set; }
        /// <summary>A list of ip configurations of the container network interface configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile[] ContainerNetworkInterfaceConfigurationPropertiesIPConfiguration { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        string ContainerNetworkInterfaceConfigurationPropertiesProvisioningState { get; set; }
        /// <summary>Container network interface configuration properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationPropertiesFormat ContainerNetworkInterfaceConfigurationProperty { get; set; }
        /// <summary>Sub Resource type.</summary>
        string ContainerNetworkInterfaceConfigurationType { get; set; }
        /// <summary>Reference to the ip configuration on this container nic.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        string ProvisioningState { get; set; }

    }
}