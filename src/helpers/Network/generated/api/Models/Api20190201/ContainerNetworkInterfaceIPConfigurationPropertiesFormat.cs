namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the container network interface IP configuration.</summary>
    public partial class ContainerNetworkInterfaceIPConfigurationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceIPConfigurationPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceIPConfigurationPropertiesFormatInternal
    {

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IContainerNetworkInterfaceIPConfigurationPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>
        /// Creates an new <see cref="ContainerNetworkInterfaceIPConfigurationPropertiesFormat" /> instance.
        /// </summary>
        public ContainerNetworkInterfaceIPConfigurationPropertiesFormat()
        {

        }
    }
    /// Properties of the container network interface IP configuration.
    public partial interface IContainerNetworkInterfaceIPConfigurationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }

    }
    /// Properties of the container network interface IP configuration.
    internal partial interface IContainerNetworkInterfaceIPConfigurationPropertiesFormatInternal

    {
        /// <summary>The provisioning state of the resource.</summary>
        string ProvisioningState { get; set; }

    }
}