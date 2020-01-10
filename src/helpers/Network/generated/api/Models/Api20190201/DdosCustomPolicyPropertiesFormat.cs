namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>DDoS custom policy properties.</summary>
    public partial class DdosCustomPolicyPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosCustomPolicyPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosCustomPolicyPropertiesFormatInternal
    {

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosCustomPolicyPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for PublicIPAddress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosCustomPolicyPropertiesFormatInternal.PublicIPAddress { get => this._publicIPAddress; set { {_publicIPAddress = value;} } }

        /// <summary>Internal Acessors for ResourceGuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosCustomPolicyPropertiesFormatInternal.ResourceGuid { get => this._resourceGuid; set { {_resourceGuid = value;} } }

        /// <summary>Backing field for <see cref="ProtocolCustomSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolCustomSettingsFormat[] _protocolCustomSetting;

        /// <summary>The protocol-specific DDoS policy customization parameters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolCustomSettingsFormat[] ProtocolCustomSetting { get => this._protocolCustomSetting; set => this._protocolCustomSetting = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the DDoS custom policy resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and
        /// 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="PublicIPAddress" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _publicIPAddress;

        /// <summary>
        /// The list of public IPs associated with the DDoS custom policy resource. This list is read-only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] PublicIPAddress { get => this._publicIPAddress; }

        /// <summary>Backing field for <see cref="ResourceGuid" /> property.</summary>
        private string _resourceGuid;

        /// <summary>
        /// The resource GUID property of the DDoS custom policy resource. It uniquely identifies the resource, even if the user changes
        /// its name or migrate the resource across subscriptions or resource groups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceGuid { get => this._resourceGuid; }

        /// <summary>Creates an new <see cref="DdosCustomPolicyPropertiesFormat" /> instance.</summary>
        public DdosCustomPolicyPropertiesFormat()
        {

        }
    }
    /// DDoS custom policy properties.
    public partial interface IDdosCustomPolicyPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The protocol-specific DDoS policy customization parameters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protocol-specific DDoS policy customization parameters.",
        SerializedName = @"protocolCustomSettings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolCustomSettingsFormat) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolCustomSettingsFormat[] ProtocolCustomSetting { get; set; }
        /// <summary>
        /// The provisioning state of the DDoS custom policy resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and
        /// 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the DDoS custom policy resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>
        /// The list of public IPs associated with the DDoS custom policy resource. This list is read-only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The list of public IPs associated with the DDoS custom policy resource. This list is read-only.",
        SerializedName = @"publicIPAddresses",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] PublicIPAddress { get;  }
        /// <summary>
        /// The resource GUID property of the DDoS custom policy resource. It uniquely identifies the resource, even if the user changes
        /// its name or migrate the resource across subscriptions or resource groups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource GUID property of the DDoS custom policy resource. It uniquely identifies the resource, even if the user changes its name or migrate the resource across subscriptions or resource groups.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get;  }

    }
    /// DDoS custom policy properties.
    internal partial interface IDdosCustomPolicyPropertiesFormatInternal

    {
        /// <summary>The protocol-specific DDoS policy customization parameters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolCustomSettingsFormat[] ProtocolCustomSetting { get; set; }
        /// <summary>
        /// The provisioning state of the DDoS custom policy resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and
        /// 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// The list of public IPs associated with the DDoS custom policy resource. This list is read-only.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] PublicIPAddress { get; set; }
        /// <summary>
        /// The resource GUID property of the DDoS custom policy resource. It uniquely identifies the resource, even if the user changes
        /// its name or migrate the resource across subscriptions or resource groups.
        /// </summary>
        string ResourceGuid { get; set; }

    }
}