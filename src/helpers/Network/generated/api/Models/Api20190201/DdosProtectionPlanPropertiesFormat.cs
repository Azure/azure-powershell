namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>DDoS protection plan properties.</summary>
    public partial class DdosProtectionPlanPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosProtectionPlanPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosProtectionPlanPropertiesFormatInternal
    {

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosProtectionPlanPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for ResourceGuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosProtectionPlanPropertiesFormatInternal.ResourceGuid { get => this._resourceGuid; set { {_resourceGuid = value;} } }

        /// <summary>Internal Acessors for Vnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosProtectionPlanPropertiesFormatInternal.Vnet { get => this._vnet; set { {_vnet = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the DDoS protection plan resource. Possible values are: 'Succeeded', 'Updating', 'Deleting',
        /// and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ResourceGuid" /> property.</summary>
        private string _resourceGuid;

        /// <summary>
        /// The resource GUID property of the DDoS protection plan resource. It uniquely identifies the resource, even if the user
        /// changes its name or migrate the resource across subscriptions or resource groups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceGuid { get => this._resourceGuid; }

        /// <summary>Backing field for <see cref="Vnet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _vnet;

        /// <summary>
        /// The list of virtual networks associated with the DDoS protection plan resource. This list is read-only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Vnet { get => this._vnet; }

        /// <summary>Creates an new <see cref="DdosProtectionPlanPropertiesFormat" /> instance.</summary>
        public DdosProtectionPlanPropertiesFormat()
        {

        }
    }
    /// DDoS protection plan properties.
    public partial interface IDdosProtectionPlanPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The provisioning state of the DDoS protection plan resource. Possible values are: 'Succeeded', 'Updating', 'Deleting',
        /// and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the DDoS protection plan resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>
        /// The resource GUID property of the DDoS protection plan resource. It uniquely identifies the resource, even if the user
        /// changes its name or migrate the resource across subscriptions or resource groups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource GUID property of the DDoS protection plan resource. It uniquely identifies the resource, even if the user changes its name or migrate the resource across subscriptions or resource groups.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get;  }
        /// <summary>
        /// The list of virtual networks associated with the DDoS protection plan resource. This list is read-only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The list of virtual networks associated with the DDoS protection plan resource. This list is read-only.",
        SerializedName = @"virtualNetworks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Vnet { get;  }

    }
    /// DDoS protection plan properties.
    internal partial interface IDdosProtectionPlanPropertiesFormatInternal

    {
        /// <summary>
        /// The provisioning state of the DDoS protection plan resource. Possible values are: 'Succeeded', 'Updating', 'Deleting',
        /// and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// The resource GUID property of the DDoS protection plan resource. It uniquely identifies the resource, even if the user
        /// changes its name or migrate the resource across subscriptions or resource groups.
        /// </summary>
        string ResourceGuid { get; set; }
        /// <summary>
        /// The list of virtual networks associated with the DDoS protection plan resource. This list is read-only.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Vnet { get; set; }

    }
}