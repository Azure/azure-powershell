namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>The properties of a private cloud resource</summary>
    public partial class PrivateCloudProperties :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudProperties,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdateProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdateProperties __privateCloudUpdateProperties = new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.PrivateCloudUpdateProperties();

        /// <summary>Backing field for <see cref="Circuit" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuit _circuit;

        /// <summary>An ExpressRoute Circuit</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuit Circuit { get => (this._circuit = this._circuit ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.Circuit()); set => this._circuit = value; }

        /// <summary>Identifier of the ExpressRoute Circuit (Microsoft Colo only)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public string CircuitExpressRouteId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal)Circuit).ExpressRouteId; }

        /// <summary>ExpressRoute Circuit private peering identifier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public string CircuitExpressRoutePrivatePeeringId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal)Circuit).ExpressRoutePrivatePeeringId; }

        /// <summary>CIDR of primary subnet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public string CircuitPrimarySubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal)Circuit).PrimarySubnet; }

        /// <summary>CIDR of secondary subnet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public string CircuitSecondarySubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal)Circuit).SecondarySubnet; }

        /// <summary>Backing field for <see cref="Endpoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpoints _endpoint;

        /// <summary>The endpoints</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpoints Endpoint { get => (this._endpoint = this._endpoint ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.Endpoints()); }

        /// <summary>Endpoint for the HCX Cloud Manager</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public string EndpointHcxCloudManager { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpointsInternal)Endpoint).HcxCloudManager; }

        /// <summary>Endpoint for the NSX-T Data Center manager</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public string EndpointNsxtManager { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpointsInternal)Endpoint).NsxtManager; }

        /// <summary>Endpoint for Virtual Center Server Appliance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public string EndpointVcsa { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpointsInternal)Endpoint).Vcsa; }

        /// <summary>vCenter Single Sign On Identity Sources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IIdentitySource[] IdentitySource { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).IdentitySource; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).IdentitySource = value ?? null /* arrayOf */; }

        /// <summary>Connectivity to internet is enabled or disabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.InternetEnum? Internet { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).Internet; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).Internet = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.InternetEnum)""); }

        /// <summary>The default cluster used for management</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IManagementCluster ManagementCluster { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).ManagementCluster; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).ManagementCluster = value ?? null /* model class */; }

        /// <summary>The hosts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public string[] ManagementClusterHost { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).ManagementClusterHost; }

        /// <summary>The identity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public int? ManagementClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).ManagementClusterId; }

        /// <summary>The state of the cluster provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState? ManagementClusterProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).ManagementClusterProvisioningState; }

        /// <summary>The cluster size</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public int? ManagementClusterSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).ManagementClusterSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).ManagementClusterSize = value ?? default(int); }

        /// <summary>Backing field for <see cref="ManagementNetwork" /> property.</summary>
        private string _managementNetwork;

        /// <summary>Network used to access vCenter Server and NSX-T Manager</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string ManagementNetwork { get => this._managementNetwork; }

        /// <summary>Internal Acessors for Circuit</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuit Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal.Circuit { get => (this._circuit = this._circuit ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.Circuit()); set { {_circuit = value;} } }

        /// <summary>Internal Acessors for CircuitExpressRouteId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal.CircuitExpressRouteId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal)Circuit).ExpressRouteId; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal)Circuit).ExpressRouteId = value; }

        /// <summary>Internal Acessors for CircuitExpressRoutePrivatePeeringId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal.CircuitExpressRoutePrivatePeeringId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal)Circuit).ExpressRoutePrivatePeeringId; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal)Circuit).ExpressRoutePrivatePeeringId = value; }

        /// <summary>Internal Acessors for CircuitPrimarySubnet</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal.CircuitPrimarySubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal)Circuit).PrimarySubnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal)Circuit).PrimarySubnet = value; }

        /// <summary>Internal Acessors for CircuitSecondarySubnet</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal.CircuitSecondarySubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal)Circuit).SecondarySubnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal)Circuit).SecondarySubnet = value; }

        /// <summary>Internal Acessors for Endpoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpoints Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal.Endpoint { get => (this._endpoint = this._endpoint ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.Endpoints()); set { {_endpoint = value;} } }

        /// <summary>Internal Acessors for EndpointHcxCloudManager</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal.EndpointHcxCloudManager { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpointsInternal)Endpoint).HcxCloudManager; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpointsInternal)Endpoint).HcxCloudManager = value; }

        /// <summary>Internal Acessors for EndpointNsxtManager</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal.EndpointNsxtManager { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpointsInternal)Endpoint).NsxtManager; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpointsInternal)Endpoint).NsxtManager = value; }

        /// <summary>Internal Acessors for EndpointVcsa</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal.EndpointVcsa { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpointsInternal)Endpoint).Vcsa; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpointsInternal)Endpoint).Vcsa = value; }

        /// <summary>Internal Acessors for ManagementNetwork</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal.ManagementNetwork { get => this._managementNetwork; set { {_managementNetwork = value;} } }

        /// <summary>Internal Acessors for NsxtCertificateThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal.NsxtCertificateThumbprint { get => this._nsxtCertificateThumbprint; set { {_nsxtCertificateThumbprint = value;} } }

        /// <summary>Internal Acessors for ProvisioningNetwork</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal.ProvisioningNetwork { get => this._provisioningNetwork; set { {_provisioningNetwork = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.PrivateCloudProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for VcenterCertificateThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal.VcenterCertificateThumbprint { get => this._vcenterCertificateThumbprint; set { {_vcenterCertificateThumbprint = value;} } }

        /// <summary>Internal Acessors for VmotionNetwork</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudPropertiesInternal.VmotionNetwork { get => this._vmotionNetwork; set { {_vmotionNetwork = value;} } }

        /// <summary>Internal Acessors for ManagementClusterHost</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal.ManagementClusterHost { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).ManagementClusterHost; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).ManagementClusterHost = value; }

        /// <summary>Internal Acessors for ManagementClusterId</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal.ManagementClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).ManagementClusterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).ManagementClusterId = value; }

        /// <summary>Internal Acessors for ManagementClusterProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ClusterProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal.ManagementClusterProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).ManagementClusterProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal)__privateCloudUpdateProperties).ManagementClusterProvisioningState = value; }

        /// <summary>Backing field for <see cref="NetworkBlock" /> property.</summary>
        private string _networkBlock;

        /// <summary>
        /// The block of addresses should be unique across VNet in your subscription as well as on-premise. Make sure the CIDR format
        /// is conformed to (A.B.C.D/X) where A,B,C,D are between 0 and 255, and X is between 0 and 22
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string NetworkBlock { get => this._networkBlock; set => this._networkBlock = value; }

        /// <summary>Backing field for <see cref="NsxtCertificateThumbprint" /> property.</summary>
        private string _nsxtCertificateThumbprint;

        /// <summary>Thumbprint of the NSX-T Manager SSL certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string NsxtCertificateThumbprint { get => this._nsxtCertificateThumbprint; }

        /// <summary>Backing field for <see cref="NsxtPassword" /> property.</summary>
        private string _nsxtPassword;

        /// <summary>Optionally, set the NSX-T Manager password when the private cloud is created</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string NsxtPassword { get => this._nsxtPassword; set => this._nsxtPassword = value; }

        /// <summary>Backing field for <see cref="ProvisioningNetwork" /> property.</summary>
        private string _provisioningNetwork;

        /// <summary>Used for virtual machine cold migration, cloning, and snapshot migration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string ProvisioningNetwork { get => this._provisioningNetwork; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.PrivateCloudProvisioningState? _provisioningState;

        /// <summary>The provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.PrivateCloudProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="VcenterCertificateThumbprint" /> property.</summary>
        private string _vcenterCertificateThumbprint;

        /// <summary>Thumbprint of the vCenter Server SSL certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string VcenterCertificateThumbprint { get => this._vcenterCertificateThumbprint; }

        /// <summary>Backing field for <see cref="VcenterPassword" /> property.</summary>
        private string _vcenterPassword;

        /// <summary>Optionally, set the vCenter admin password when the private cloud is created</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string VcenterPassword { get => this._vcenterPassword; set => this._vcenterPassword = value; }

        /// <summary>Backing field for <see cref="VmotionNetwork" /> property.</summary>
        private string _vmotionNetwork;

        /// <summary>Used for live migration of virtual machines</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string VmotionNetwork { get => this._vmotionNetwork; }

        /// <summary>Creates an new <see cref="PrivateCloudProperties" /> instance.</summary>
        public PrivateCloudProperties()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__privateCloudUpdateProperties), __privateCloudUpdateProperties);
            await eventListener.AssertObjectIsValid(nameof(__privateCloudUpdateProperties), __privateCloudUpdateProperties);
        }
    }
    /// The properties of a private cloud resource
    public partial interface IPrivateCloudProperties :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdateProperties
    {
        /// <summary>Identifier of the ExpressRoute Circuit (Microsoft Colo only)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Identifier of the ExpressRoute Circuit (Microsoft Colo only)",
        SerializedName = @"expressRouteID",
        PossibleTypes = new [] { typeof(string) })]
        string CircuitExpressRouteId { get;  }
        /// <summary>ExpressRoute Circuit private peering identifier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ExpressRoute Circuit private peering identifier",
        SerializedName = @"expressRoutePrivatePeeringID",
        PossibleTypes = new [] { typeof(string) })]
        string CircuitExpressRoutePrivatePeeringId { get;  }
        /// <summary>CIDR of primary subnet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"CIDR of primary subnet",
        SerializedName = @"primarySubnet",
        PossibleTypes = new [] { typeof(string) })]
        string CircuitPrimarySubnet { get;  }
        /// <summary>CIDR of secondary subnet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"CIDR of secondary subnet",
        SerializedName = @"secondarySubnet",
        PossibleTypes = new [] { typeof(string) })]
        string CircuitSecondarySubnet { get;  }
        /// <summary>Endpoint for the HCX Cloud Manager</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Endpoint for the HCX Cloud Manager",
        SerializedName = @"hcxCloudManager",
        PossibleTypes = new [] { typeof(string) })]
        string EndpointHcxCloudManager { get;  }
        /// <summary>Endpoint for the NSX-T Data Center manager</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Endpoint for the NSX-T Data Center manager",
        SerializedName = @"nsxtManager",
        PossibleTypes = new [] { typeof(string) })]
        string EndpointNsxtManager { get;  }
        /// <summary>Endpoint for Virtual Center Server Appliance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Endpoint for Virtual Center Server Appliance",
        SerializedName = @"vcsa",
        PossibleTypes = new [] { typeof(string) })]
        string EndpointVcsa { get;  }
        /// <summary>Network used to access vCenter Server and NSX-T Manager</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Network used to access vCenter Server and NSX-T Manager",
        SerializedName = @"managementNetwork",
        PossibleTypes = new [] { typeof(string) })]
        string ManagementNetwork { get;  }
        /// <summary>
        /// The block of addresses should be unique across VNet in your subscription as well as on-premise. Make sure the CIDR format
        /// is conformed to (A.B.C.D/X) where A,B,C,D are between 0 and 255, and X is between 0 and 22
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The block of addresses should be unique across VNet in your subscription as well as on-premise. Make sure the CIDR format is conformed to (A.B.C.D/X) where A,B,C,D are between 0 and 255, and X is between 0 and 22",
        SerializedName = @"networkBlock",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkBlock { get; set; }
        /// <summary>Thumbprint of the NSX-T Manager SSL certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Thumbprint of the NSX-T Manager SSL certificate",
        SerializedName = @"nsxtCertificateThumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string NsxtCertificateThumbprint { get;  }
        /// <summary>Optionally, set the NSX-T Manager password when the private cloud is created</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optionally, set the NSX-T Manager password when the private cloud is created",
        SerializedName = @"nsxtPassword",
        PossibleTypes = new [] { typeof(string) })]
        string NsxtPassword { get; set; }
        /// <summary>Used for virtual machine cold migration, cloning, and snapshot migration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Used for virtual machine cold migration, cloning, and snapshot migration",
        SerializedName = @"provisioningNetwork",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningNetwork { get;  }
        /// <summary>The provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.PrivateCloudProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.PrivateCloudProvisioningState? ProvisioningState { get;  }
        /// <summary>Thumbprint of the vCenter Server SSL certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Thumbprint of the vCenter Server SSL certificate",
        SerializedName = @"vcenterCertificateThumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string VcenterCertificateThumbprint { get;  }
        /// <summary>Optionally, set the vCenter admin password when the private cloud is created</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optionally, set the vCenter admin password when the private cloud is created",
        SerializedName = @"vcenterPassword",
        PossibleTypes = new [] { typeof(string) })]
        string VcenterPassword { get; set; }
        /// <summary>Used for live migration of virtual machines</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Used for live migration of virtual machines",
        SerializedName = @"vmotionNetwork",
        PossibleTypes = new [] { typeof(string) })]
        string VmotionNetwork { get;  }

    }
    /// The properties of a private cloud resource
    internal partial interface IPrivateCloudPropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdatePropertiesInternal
    {
        /// <summary>An ExpressRoute Circuit</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuit Circuit { get; set; }
        /// <summary>Identifier of the ExpressRoute Circuit (Microsoft Colo only)</summary>
        string CircuitExpressRouteId { get; set; }
        /// <summary>ExpressRoute Circuit private peering identifier</summary>
        string CircuitExpressRoutePrivatePeeringId { get; set; }
        /// <summary>CIDR of primary subnet</summary>
        string CircuitPrimarySubnet { get; set; }
        /// <summary>CIDR of secondary subnet</summary>
        string CircuitSecondarySubnet { get; set; }
        /// <summary>The endpoints</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IEndpoints Endpoint { get; set; }
        /// <summary>Endpoint for the HCX Cloud Manager</summary>
        string EndpointHcxCloudManager { get; set; }
        /// <summary>Endpoint for the NSX-T Data Center manager</summary>
        string EndpointNsxtManager { get; set; }
        /// <summary>Endpoint for Virtual Center Server Appliance</summary>
        string EndpointVcsa { get; set; }
        /// <summary>Network used to access vCenter Server and NSX-T Manager</summary>
        string ManagementNetwork { get; set; }
        /// <summary>
        /// The block of addresses should be unique across VNet in your subscription as well as on-premise. Make sure the CIDR format
        /// is conformed to (A.B.C.D/X) where A,B,C,D are between 0 and 255, and X is between 0 and 22
        /// </summary>
        string NetworkBlock { get; set; }
        /// <summary>Thumbprint of the NSX-T Manager SSL certificate</summary>
        string NsxtCertificateThumbprint { get; set; }
        /// <summary>Optionally, set the NSX-T Manager password when the private cloud is created</summary>
        string NsxtPassword { get; set; }
        /// <summary>Used for virtual machine cold migration, cloning, and snapshot migration</summary>
        string ProvisioningNetwork { get; set; }
        /// <summary>The provisioning state</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.PrivateCloudProvisioningState? ProvisioningState { get; set; }
        /// <summary>Thumbprint of the vCenter Server SSL certificate</summary>
        string VcenterCertificateThumbprint { get; set; }
        /// <summary>Optionally, set the vCenter admin password when the private cloud is created</summary>
        string VcenterPassword { get; set; }
        /// <summary>Used for live migration of virtual machines</summary>
        string VmotionNetwork { get; set; }

    }
}