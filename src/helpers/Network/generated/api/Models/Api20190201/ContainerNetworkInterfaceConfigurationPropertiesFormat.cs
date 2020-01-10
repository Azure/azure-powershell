namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Container network interface configuration properties.</summary>
    public partial class ContainerNetworkInterfaceConfigurationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="ContainerNetworkInterface" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _containerNetworkInterface;

        /// <summary>
        /// A list of container network interfaces created from this container network interface configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] ContainerNetworkInterface { get => this._containerNetworkInterface; set => this._containerNetworkInterface = value; }

        /// <summary>Backing field for <see cref="IPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile[] _iPConfiguration;

        /// <summary>A list of ip configurations of the container network interface configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile[] IPConfiguration { get => this._iPConfiguration; set => this._iPConfiguration = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceConfigurationPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>
        /// Creates an new <see cref="ContainerNetworkInterfaceConfigurationPropertiesFormat" /> instance.
        /// </summary>
        public ContainerNetworkInterfaceConfigurationPropertiesFormat()
        {

        }
    }
    /// Container network interface configuration properties.
    public partial interface IContainerNetworkInterfaceConfigurationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
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
        /// <summary>A list of ip configurations of the container network interface configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of ip configurations of the container network interface configuration.",
        SerializedName = @"ipConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile[] IPConfiguration { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }

    }
    /// Container network interface configuration properties.
    internal partial interface IContainerNetworkInterfaceConfigurationPropertiesFormatInternal

    {
        /// <summary>
        /// A list of container network interfaces created from this container network interface configuration.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] ContainerNetworkInterface { get; set; }
        /// <summary>A list of ip configurations of the container network interface configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPConfigurationProfile[] IPConfiguration { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        string ProvisioningState { get; set; }

    }
}