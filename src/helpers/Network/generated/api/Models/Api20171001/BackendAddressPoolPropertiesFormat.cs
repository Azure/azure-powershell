namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the backend address pool.</summary>
    public partial class BackendAddressPoolPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPoolPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPoolPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="BackendIPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration[] _backendIPConfiguration;

        /// <summary>Gets collection of references to IP addresses defined in network interfaces.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration[] BackendIPConfiguration { get => this._backendIPConfiguration; }

        /// <summary>Backing field for <see cref="LoadBalancingRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] _loadBalancingRule;

        /// <summary>Gets load balancing rules that use this backend address pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] LoadBalancingRule { get => this._loadBalancingRule; }

        /// <summary>Internal Acessors for BackendIPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPoolPropertiesFormatInternal.BackendIPConfiguration { get => this._backendIPConfiguration; set { {_backendIPConfiguration = value;} } }

        /// <summary>Internal Acessors for LoadBalancingRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPoolPropertiesFormatInternal.LoadBalancingRule { get => this._loadBalancingRule; set { {_loadBalancingRule = value;} } }

        /// <summary>Internal Acessors for OutboundNatRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPoolPropertiesFormatInternal.OutboundNatRule { get => (this._outboundNatRule = this._outboundNatRule ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set { {_outboundNatRule = value;} } }

        /// <summary>Backing field for <see cref="OutboundNatRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource _outboundNatRule;

        /// <summary>Gets outbound rules that use this backend address pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource OutboundNatRule { get => (this._outboundNatRule = this._outboundNatRule ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string OutboundNatRuleId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)OutboundNatRule).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)OutboundNatRule).Id = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Creates an new <see cref="BackendAddressPoolPropertiesFormat" /> instance.</summary>
        public BackendAddressPoolPropertiesFormat()
        {

        }
    }
    /// Properties of the backend address pool.
    public partial interface IBackendAddressPoolPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Gets collection of references to IP addresses defined in network interfaces.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets collection of references to IP addresses defined in network interfaces.",
        SerializedName = @"backendIPConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration[] BackendIPConfiguration { get;  }
        /// <summary>Gets load balancing rules that use this backend address pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets load balancing rules that use this backend address pool.",
        SerializedName = @"loadBalancingRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] LoadBalancingRule { get;  }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string OutboundNatRuleId { get; set; }
        /// <summary>
        /// Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }

    }
    /// Properties of the backend address pool.
    internal partial interface IBackendAddressPoolPropertiesFormatInternal

    {
        /// <summary>Gets collection of references to IP addresses defined in network interfaces.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration[] BackendIPConfiguration { get; set; }
        /// <summary>Gets load balancing rules that use this backend address pool.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource[] LoadBalancingRule { get; set; }
        /// <summary>Gets outbound rules that use this backend address pool.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource OutboundNatRule { get; set; }
        /// <summary>Resource ID.</summary>
        string OutboundNatRuleId { get; set; }
        /// <summary>
        /// Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }

    }
}