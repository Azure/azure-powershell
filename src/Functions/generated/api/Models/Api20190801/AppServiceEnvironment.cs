namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Description of an App Service Environment.</summary>
    public partial class AppServiceEnvironment :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironment,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal
    {

        /// <summary>Backing field for <see cref="AllowedMultiSize" /> property.</summary>
        private string _allowedMultiSize;

        /// <summary>
        /// List of comma separated strings describing which VM sizes are allowed for front-ends.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AllowedMultiSize { get => this._allowedMultiSize; }

        /// <summary>Backing field for <see cref="AllowedWorkerSize" /> property.</summary>
        private string _allowedWorkerSize;

        /// <summary>
        /// List of comma separated strings describing which VM sizes are allowed for workers.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AllowedWorkerSize { get => this._allowedWorkerSize; }

        /// <summary>Backing field for <see cref="ApiManagementAccountId" /> property.</summary>
        private string _apiManagementAccountId;

        /// <summary>API Management Account associated with the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ApiManagementAccountId { get => this._apiManagementAccountId; set => this._apiManagementAccountId = value; }

        /// <summary>Backing field for <see cref="ClusterSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] _clusterSetting;

        /// <summary>Custom settings for changing the behavior of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] ClusterSetting { get => this._clusterSetting; set => this._clusterSetting = value; }

        /// <summary>Backing field for <see cref="DatabaseEdition" /> property.</summary>
        private string _databaseEdition;

        /// <summary>
        /// Edition of the metadata database for the App Service Environment, e.g. "Standard".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DatabaseEdition { get => this._databaseEdition; }

        /// <summary>Backing field for <see cref="DatabaseServiceObjective" /> property.</summary>
        private string _databaseServiceObjective;

        /// <summary>
        /// Service objective of the metadata database for the App Service Environment, e.g. "S0".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DatabaseServiceObjective { get => this._databaseServiceObjective; }

        /// <summary>Backing field for <see cref="DefaultFrontEndScaleFactor" /> property.</summary>
        private int? _defaultFrontEndScaleFactor;

        /// <summary>Default Scale Factor for FrontEnds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? DefaultFrontEndScaleFactor { get => this._defaultFrontEndScaleFactor; }

        /// <summary>Backing field for <see cref="DnsSuffix" /> property.</summary>
        private string _dnsSuffix;

        /// <summary>DNS suffix of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DnsSuffix { get => this._dnsSuffix; set => this._dnsSuffix = value; }

        /// <summary>Backing field for <see cref="DynamicCacheEnabled" /> property.</summary>
        private bool? _dynamicCacheEnabled;

        /// <summary>
        /// True/false indicating whether the App Service Environment is suspended. The environment can be suspended e.g. when the
        /// management endpoint is no longer available
        /// (most likely because NSG blocked the incoming traffic).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? DynamicCacheEnabled { get => this._dynamicCacheEnabled; set => this._dynamicCacheEnabled = value; }

        /// <summary>Backing field for <see cref="EnvironmentCapacity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity[] _environmentCapacity;

        /// <summary>Current total, used, and available worker capacities.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity[] EnvironmentCapacity { get => this._environmentCapacity; }

        /// <summary>Backing field for <see cref="EnvironmentIsHealthy" /> property.</summary>
        private bool? _environmentIsHealthy;

        /// <summary>True/false indicating whether the App Service Environment is healthy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? EnvironmentIsHealthy { get => this._environmentIsHealthy; }

        /// <summary>Backing field for <see cref="EnvironmentStatus" /> property.</summary>
        private string _environmentStatus;

        /// <summary>
        /// Detailed message about with results of the last check of the App Service Environment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string EnvironmentStatus { get => this._environmentStatus; }

        /// <summary>Backing field for <see cref="FrontEndScaleFactor" /> property.</summary>
        private int? _frontEndScaleFactor;

        /// <summary>Scale factor for front-ends.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? FrontEndScaleFactor { get => this._frontEndScaleFactor; set => this._frontEndScaleFactor = value; }

        /// <summary>Backing field for <see cref="HasLinuxWorker" /> property.</summary>
        private bool? _hasLinuxWorker;

        /// <summary>Flag that displays whether an ASE has linux workers or not</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? HasLinuxWorker { get => this._hasLinuxWorker; set => this._hasLinuxWorker = value; }

        /// <summary>Backing field for <see cref="InternalLoadBalancingMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.InternalLoadBalancingMode? _internalLoadBalancingMode;

        /// <summary>
        /// Specifies which endpoints to serve internally in the Virtual Network for the App Service Environment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.InternalLoadBalancingMode? InternalLoadBalancingMode { get => this._internalLoadBalancingMode; set => this._internalLoadBalancingMode = value; }

        /// <summary>Backing field for <see cref="IpsslAddressCount" /> property.</summary>
        private int? _ipsslAddressCount;

        /// <summary>Number of IP SSL addresses reserved for the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? IpsslAddressCount { get => this._ipsslAddressCount; set => this._ipsslAddressCount = value; }

        /// <summary>Backing field for <see cref="LastAction" /> property.</summary>
        private string _lastAction;

        /// <summary>Last deployment action on the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string LastAction { get => this._lastAction; }

        /// <summary>Backing field for <see cref="LastActionResult" /> property.</summary>
        private string _lastActionResult;

        /// <summary>Result of the last deployment action on the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string LastActionResult { get => this._lastActionResult; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Location of the App Service Environment, e.g. "West US".</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Backing field for <see cref="MaximumNumberOfMachine" /> property.</summary>
        private int? _maximumNumberOfMachine;

        /// <summary>Maximum number of VMs in the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? MaximumNumberOfMachine { get => this._maximumNumberOfMachine; }

        /// <summary>Internal Acessors for AllowedMultiSize</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.AllowedMultiSize { get => this._allowedMultiSize; set { {_allowedMultiSize = value;} } }

        /// <summary>Internal Acessors for AllowedWorkerSize</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.AllowedWorkerSize { get => this._allowedWorkerSize; set { {_allowedWorkerSize = value;} } }

        /// <summary>Internal Acessors for DatabaseEdition</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.DatabaseEdition { get => this._databaseEdition; set { {_databaseEdition = value;} } }

        /// <summary>Internal Acessors for DatabaseServiceObjective</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.DatabaseServiceObjective { get => this._databaseServiceObjective; set { {_databaseServiceObjective = value;} } }

        /// <summary>Internal Acessors for DefaultFrontEndScaleFactor</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.DefaultFrontEndScaleFactor { get => this._defaultFrontEndScaleFactor; set { {_defaultFrontEndScaleFactor = value;} } }

        /// <summary>Internal Acessors for EnvironmentCapacity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.EnvironmentCapacity { get => this._environmentCapacity; set { {_environmentCapacity = value;} } }

        /// <summary>Internal Acessors for EnvironmentIsHealthy</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.EnvironmentIsHealthy { get => this._environmentIsHealthy; set { {_environmentIsHealthy = value;} } }

        /// <summary>Internal Acessors for EnvironmentStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.EnvironmentStatus { get => this._environmentStatus; set { {_environmentStatus = value;} } }

        /// <summary>Internal Acessors for LastAction</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.LastAction { get => this._lastAction; set { {_lastAction = value;} } }

        /// <summary>Internal Acessors for LastActionResult</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.LastActionResult { get => this._lastActionResult; set { {_lastActionResult = value;} } }

        /// <summary>Internal Acessors for MaximumNumberOfMachine</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.MaximumNumberOfMachine { get => this._maximumNumberOfMachine; set { {_maximumNumberOfMachine = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for ResourceGroup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.ResourceGroup { get => this._resourceGroup; set { {_resourceGroup = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostingEnvironmentStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Internal Acessors for SubscriptionId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.SubscriptionId { get => this._subscriptionId; set { {_subscriptionId = value;} } }

        /// <summary>Internal Acessors for UpgradeDomain</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.UpgradeDomain { get => this._upgradeDomain; set { {_upgradeDomain = value;} } }

        /// <summary>Internal Acessors for VipMapping</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.VipMapping { get => this._vipMapping; set { {_vipMapping = value;} } }

        /// <summary>Internal Acessors for VirtualNetwork</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfile Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.VirtualNetwork { get => (this._virtualNetwork = this._virtualNetwork ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VirtualNetworkProfile()); set { {_virtualNetwork = value;} } }

        /// <summary>Internal Acessors for VirtualNetworkName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.VirtualNetworkName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfileInternal)VirtualNetwork).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfileInternal)VirtualNetwork).Name = value; }

        /// <summary>Internal Acessors for VirtualNetworkType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal.VirtualNetworkType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfileInternal)VirtualNetwork).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfileInternal)VirtualNetwork).Type = value; }

        /// <summary>Backing field for <see cref="MultiRoleCount" /> property.</summary>
        private int? _multiRoleCount;

        /// <summary>Number of front-end instances.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? MultiRoleCount { get => this._multiRoleCount; set => this._multiRoleCount = value; }

        /// <summary>Backing field for <see cref="MultiSize" /> property.</summary>
        private string _multiSize;

        /// <summary>Front-end VM size, e.g. "Medium", "Large".</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string MultiSize { get => this._multiSize; set => this._multiSize = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="NetworkAccessControlList" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkAccessControlEntry[] _networkAccessControlList;

        /// <summary>Access control list for controlling traffic to the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkAccessControlEntry[] NetworkAccessControlList { get => this._networkAccessControlList; set => this._networkAccessControlList = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? _provisioningState;

        /// <summary>Provisioning state of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ResourceGroup" /> property.</summary>
        private string _resourceGroup;

        /// <summary>Resource group of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ResourceGroup { get => this._resourceGroup; }

        /// <summary>Backing field for <see cref="SslCertKeyVaultId" /> property.</summary>
        private string _sslCertKeyVaultId;

        /// <summary>Key Vault ID for ILB App Service Environment default SSL certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SslCertKeyVaultId { get => this._sslCertKeyVaultId; set => this._sslCertKeyVaultId = value; }

        /// <summary>Backing field for <see cref="SslCertKeyVaultSecretName" /> property.</summary>
        private string _sslCertKeyVaultSecretName;

        /// <summary>Key Vault Secret Name for ILB App Service Environment default SSL certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SslCertKeyVaultSecretName { get => this._sslCertKeyVaultSecretName; set => this._sslCertKeyVaultSecretName = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostingEnvironmentStatus? _status;

        /// <summary>Current status of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostingEnvironmentStatus? Status { get => this._status; }

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        /// <summary>Subscription of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SubscriptionId { get => this._subscriptionId; }

        /// <summary>Backing field for <see cref="Suspended" /> property.</summary>
        private bool? _suspended;

        /// <summary>
        /// <code>true</code> if the App Service Environment is suspended; otherwise, <code>false</code>. The environment can be suspended,
        /// e.g. when the management endpoint is no longer available
        /// (most likely because NSG blocked the incoming traffic).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Suspended { get => this._suspended; set => this._suspended = value; }

        /// <summary>Backing field for <see cref="UpgradeDomain" /> property.</summary>
        private int? _upgradeDomain;

        /// <summary>Number of upgrade domains of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? UpgradeDomain { get => this._upgradeDomain; }

        /// <summary>Backing field for <see cref="UserWhitelistedIPRange" /> property.</summary>
        private string[] _userWhitelistedIPRange;

        /// <summary>User added ip ranges to whitelist on ASE db</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] UserWhitelistedIPRange { get => this._userWhitelistedIPRange; set => this._userWhitelistedIPRange = value; }

        /// <summary>Backing field for <see cref="VipMapping" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[] _vipMapping;

        /// <summary>Description of IP SSL mapping for the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[] VipMapping { get => this._vipMapping; }

        /// <summary>Backing field for <see cref="VirtualNetwork" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfile _virtualNetwork;

        /// <summary>Description of the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfile VirtualNetwork { get => (this._virtualNetwork = this._virtualNetwork ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VirtualNetworkProfile()); set => this._virtualNetwork = value; }

        /// <summary>Resource id of the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfileInternal)VirtualNetwork).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfileInternal)VirtualNetwork).Id = value; }

        /// <summary>Name of the Virtual Network (read-only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfileInternal)VirtualNetwork).Name; }

        /// <summary>Subnet within the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfileInternal)VirtualNetwork).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfileInternal)VirtualNetwork).Subnet = value; }

        /// <summary>Resource type of the Virtual Network (read-only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfileInternal)VirtualNetwork).Type; }

        /// <summary>Backing field for <see cref="VnetName" /> property.</summary>
        private string _vnetName;

        /// <summary>Name of the Virtual Network for the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VnetName { get => this._vnetName; set => this._vnetName = value; }

        /// <summary>Backing field for <see cref="VnetResourceGroupName" /> property.</summary>
        private string _vnetResourceGroupName;

        /// <summary>Resource group of the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VnetResourceGroupName { get => this._vnetResourceGroupName; set => this._vnetResourceGroupName = value; }

        /// <summary>Backing field for <see cref="VnetSubnetName" /> property.</summary>
        private string _vnetSubnetName;

        /// <summary>Subnet of the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VnetSubnetName { get => this._vnetSubnetName; set => this._vnetSubnetName = value; }

        /// <summary>Backing field for <see cref="WorkerPool" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool[] _workerPool;

        /// <summary>
        /// Description of worker pools with worker size IDs, VM sizes, and number of workers in each pool.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool[] WorkerPool { get => this._workerPool; set => this._workerPool = value; }

        /// <summary>Creates an new <see cref="AppServiceEnvironment" /> instance.</summary>
        public AppServiceEnvironment()
        {

        }
    }
    /// Description of an App Service Environment.
    public partial interface IAppServiceEnvironment :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// List of comma separated strings describing which VM sizes are allowed for front-ends.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of comma separated strings describing which VM sizes are allowed for front-ends.",
        SerializedName = @"allowedMultiSizes",
        PossibleTypes = new [] { typeof(string) })]
        string AllowedMultiSize { get;  }
        /// <summary>
        /// List of comma separated strings describing which VM sizes are allowed for workers.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of comma separated strings describing which VM sizes are allowed for workers.",
        SerializedName = @"allowedWorkerSizes",
        PossibleTypes = new [] { typeof(string) })]
        string AllowedWorkerSize { get;  }
        /// <summary>API Management Account associated with the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"API Management Account associated with the App Service Environment.",
        SerializedName = @"apiManagementAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string ApiManagementAccountId { get; set; }
        /// <summary>Custom settings for changing the behavior of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Custom settings for changing the behavior of the App Service Environment.",
        SerializedName = @"clusterSettings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] ClusterSetting { get; set; }
        /// <summary>
        /// Edition of the metadata database for the App Service Environment, e.g. "Standard".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Edition of the metadata database for the App Service Environment, e.g. ""Standard"".",
        SerializedName = @"databaseEdition",
        PossibleTypes = new [] { typeof(string) })]
        string DatabaseEdition { get;  }
        /// <summary>
        /// Service objective of the metadata database for the App Service Environment, e.g. "S0".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Service objective of the metadata database for the App Service Environment, e.g. ""S0"".",
        SerializedName = @"databaseServiceObjective",
        PossibleTypes = new [] { typeof(string) })]
        string DatabaseServiceObjective { get;  }
        /// <summary>Default Scale Factor for FrontEnds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Default Scale Factor for FrontEnds.",
        SerializedName = @"defaultFrontEndScaleFactor",
        PossibleTypes = new [] { typeof(int) })]
        int? DefaultFrontEndScaleFactor { get;  }
        /// <summary>DNS suffix of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"DNS suffix of the App Service Environment.",
        SerializedName = @"dnsSuffix",
        PossibleTypes = new [] { typeof(string) })]
        string DnsSuffix { get; set; }
        /// <summary>
        /// True/false indicating whether the App Service Environment is suspended. The environment can be suspended e.g. when the
        /// management endpoint is no longer available
        /// (most likely because NSG blocked the incoming traffic).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"True/false indicating whether the App Service Environment is suspended. The environment can be suspended e.g. when the management endpoint is no longer available
        (most likely because NSG blocked the incoming traffic).",
        SerializedName = @"dynamicCacheEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DynamicCacheEnabled { get; set; }
        /// <summary>Current total, used, and available worker capacities.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Current total, used, and available worker capacities.",
        SerializedName = @"environmentCapacities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity[] EnvironmentCapacity { get;  }
        /// <summary>True/false indicating whether the App Service Environment is healthy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"True/false indicating whether the App Service Environment is healthy.",
        SerializedName = @"environmentIsHealthy",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnvironmentIsHealthy { get;  }
        /// <summary>
        /// Detailed message about with results of the last check of the App Service Environment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Detailed message about with results of the last check of the App Service Environment.",
        SerializedName = @"environmentStatus",
        PossibleTypes = new [] { typeof(string) })]
        string EnvironmentStatus { get;  }
        /// <summary>Scale factor for front-ends.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Scale factor for front-ends.",
        SerializedName = @"frontEndScaleFactor",
        PossibleTypes = new [] { typeof(int) })]
        int? FrontEndScaleFactor { get; set; }
        /// <summary>Flag that displays whether an ASE has linux workers or not</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag that displays whether an ASE has linux workers or not",
        SerializedName = @"hasLinuxWorkers",
        PossibleTypes = new [] { typeof(bool) })]
        bool? HasLinuxWorker { get; set; }
        /// <summary>
        /// Specifies which endpoints to serve internally in the Virtual Network for the App Service Environment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies which endpoints to serve internally in the Virtual Network for the App Service Environment.",
        SerializedName = @"internalLoadBalancingMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.InternalLoadBalancingMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.InternalLoadBalancingMode? InternalLoadBalancingMode { get; set; }
        /// <summary>Number of IP SSL addresses reserved for the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of IP SSL addresses reserved for the App Service Environment.",
        SerializedName = @"ipsslAddressCount",
        PossibleTypes = new [] { typeof(int) })]
        int? IpsslAddressCount { get; set; }
        /// <summary>Last deployment action on the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Last deployment action on the App Service Environment.",
        SerializedName = @"lastAction",
        PossibleTypes = new [] { typeof(string) })]
        string LastAction { get;  }
        /// <summary>Result of the last deployment action on the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Result of the last deployment action on the App Service Environment.",
        SerializedName = @"lastActionResult",
        PossibleTypes = new [] { typeof(string) })]
        string LastActionResult { get;  }
        /// <summary>Location of the App Service Environment, e.g. "West US".</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Location of the App Service Environment, e.g. ""West US"".",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>Maximum number of VMs in the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Maximum number of VMs in the App Service Environment.",
        SerializedName = @"maximumNumberOfMachines",
        PossibleTypes = new [] { typeof(int) })]
        int? MaximumNumberOfMachine { get;  }
        /// <summary>Number of front-end instances.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of front-end instances.",
        SerializedName = @"multiRoleCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MultiRoleCount { get; set; }
        /// <summary>Front-end VM size, e.g. "Medium", "Large".</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Front-end VM size, e.g. ""Medium"", ""Large"".",
        SerializedName = @"multiSize",
        PossibleTypes = new [] { typeof(string) })]
        string MultiSize { get; set; }
        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Name of the App Service Environment.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Access control list for controlling traffic to the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Access control list for controlling traffic to the App Service Environment.",
        SerializedName = @"networkAccessControlList",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkAccessControlEntry) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkAccessControlEntry[] NetworkAccessControlList { get; set; }
        /// <summary>Provisioning state of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the App Service Environment.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>Resource group of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource group of the App Service Environment.",
        SerializedName = @"resourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGroup { get;  }
        /// <summary>Key Vault ID for ILB App Service Environment default SSL certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key Vault ID for ILB App Service Environment default SSL certificate",
        SerializedName = @"sslCertKeyVaultId",
        PossibleTypes = new [] { typeof(string) })]
        string SslCertKeyVaultId { get; set; }
        /// <summary>Key Vault Secret Name for ILB App Service Environment default SSL certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key Vault Secret Name for ILB App Service Environment default SSL certificate",
        SerializedName = @"sslCertKeyVaultSecretName",
        PossibleTypes = new [] { typeof(string) })]
        string SslCertKeyVaultSecretName { get; set; }
        /// <summary>Current status of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Current status of the App Service Environment.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostingEnvironmentStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostingEnvironmentStatus? Status { get;  }
        /// <summary>Subscription of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Subscription of the App Service Environment.",
        SerializedName = @"subscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        string SubscriptionId { get;  }
        /// <summary>
        /// <code>true</code> if the App Service Environment is suspended; otherwise, <code>false</code>. The environment can be suspended,
        /// e.g. when the management endpoint is no longer available
        /// (most likely because NSG blocked the incoming traffic).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if the App Service Environment is suspended; otherwise, <code>false</code>. The environment can be suspended, e.g. when the management endpoint is no longer available
         (most likely because NSG blocked the incoming traffic).",
        SerializedName = @"suspended",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Suspended { get; set; }
        /// <summary>Number of upgrade domains of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Number of upgrade domains of the App Service Environment.",
        SerializedName = @"upgradeDomains",
        PossibleTypes = new [] { typeof(int) })]
        int? UpgradeDomain { get;  }
        /// <summary>User added ip ranges to whitelist on ASE db</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"User added ip ranges to whitelist on ASE db",
        SerializedName = @"userWhitelistedIpRanges",
        PossibleTypes = new [] { typeof(string) })]
        string[] UserWhitelistedIPRange { get; set; }
        /// <summary>Description of IP SSL mapping for the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Description of IP SSL mapping for the App Service Environment.",
        SerializedName = @"vipMappings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[] VipMapping { get;  }
        /// <summary>Resource id of the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource id of the Virtual Network.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkId { get; set; }
        /// <summary>Name of the Virtual Network (read-only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the Virtual Network (read-only).",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkName { get;  }
        /// <summary>Subnet within the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Subnet within the Virtual Network.",
        SerializedName = @"subnet",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkSubnet { get; set; }
        /// <summary>Resource type of the Virtual Network (read-only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type of the Virtual Network (read-only).",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkType { get;  }
        /// <summary>Name of the Virtual Network for the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the Virtual Network for the App Service Environment.",
        SerializedName = @"vnetName",
        PossibleTypes = new [] { typeof(string) })]
        string VnetName { get; set; }
        /// <summary>Resource group of the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource group of the Virtual Network.",
        SerializedName = @"vnetResourceGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string VnetResourceGroupName { get; set; }
        /// <summary>Subnet of the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Subnet of the Virtual Network.",
        SerializedName = @"vnetSubnetName",
        PossibleTypes = new [] { typeof(string) })]
        string VnetSubnetName { get; set; }
        /// <summary>
        /// Description of worker pools with worker size IDs, VM sizes, and number of workers in each pool.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Description of worker pools with worker size IDs, VM sizes, and number of workers in each pool.",
        SerializedName = @"workerPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool[] WorkerPool { get; set; }

    }
    /// Description of an App Service Environment.
    internal partial interface IAppServiceEnvironmentInternal

    {
        /// <summary>
        /// List of comma separated strings describing which VM sizes are allowed for front-ends.
        /// </summary>
        string AllowedMultiSize { get; set; }
        /// <summary>
        /// List of comma separated strings describing which VM sizes are allowed for workers.
        /// </summary>
        string AllowedWorkerSize { get; set; }
        /// <summary>API Management Account associated with the App Service Environment.</summary>
        string ApiManagementAccountId { get; set; }
        /// <summary>Custom settings for changing the behavior of the App Service Environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] ClusterSetting { get; set; }
        /// <summary>
        /// Edition of the metadata database for the App Service Environment, e.g. "Standard".
        /// </summary>
        string DatabaseEdition { get; set; }
        /// <summary>
        /// Service objective of the metadata database for the App Service Environment, e.g. "S0".
        /// </summary>
        string DatabaseServiceObjective { get; set; }
        /// <summary>Default Scale Factor for FrontEnds.</summary>
        int? DefaultFrontEndScaleFactor { get; set; }
        /// <summary>DNS suffix of the App Service Environment.</summary>
        string DnsSuffix { get; set; }
        /// <summary>
        /// True/false indicating whether the App Service Environment is suspended. The environment can be suspended e.g. when the
        /// management endpoint is no longer available
        /// (most likely because NSG blocked the incoming traffic).
        /// </summary>
        bool? DynamicCacheEnabled { get; set; }
        /// <summary>Current total, used, and available worker capacities.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity[] EnvironmentCapacity { get; set; }
        /// <summary>True/false indicating whether the App Service Environment is healthy.</summary>
        bool? EnvironmentIsHealthy { get; set; }
        /// <summary>
        /// Detailed message about with results of the last check of the App Service Environment.
        /// </summary>
        string EnvironmentStatus { get; set; }
        /// <summary>Scale factor for front-ends.</summary>
        int? FrontEndScaleFactor { get; set; }
        /// <summary>Flag that displays whether an ASE has linux workers or not</summary>
        bool? HasLinuxWorker { get; set; }
        /// <summary>
        /// Specifies which endpoints to serve internally in the Virtual Network for the App Service Environment.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.InternalLoadBalancingMode? InternalLoadBalancingMode { get; set; }
        /// <summary>Number of IP SSL addresses reserved for the App Service Environment.</summary>
        int? IpsslAddressCount { get; set; }
        /// <summary>Last deployment action on the App Service Environment.</summary>
        string LastAction { get; set; }
        /// <summary>Result of the last deployment action on the App Service Environment.</summary>
        string LastActionResult { get; set; }
        /// <summary>Location of the App Service Environment, e.g. "West US".</summary>
        string Location { get; set; }
        /// <summary>Maximum number of VMs in the App Service Environment.</summary>
        int? MaximumNumberOfMachine { get; set; }
        /// <summary>Number of front-end instances.</summary>
        int? MultiRoleCount { get; set; }
        /// <summary>Front-end VM size, e.g. "Medium", "Large".</summary>
        string MultiSize { get; set; }
        /// <summary>Name of the App Service Environment.</summary>
        string Name { get; set; }
        /// <summary>Access control list for controlling traffic to the App Service Environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkAccessControlEntry[] NetworkAccessControlList { get; set; }
        /// <summary>Provisioning state of the App Service Environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Resource group of the App Service Environment.</summary>
        string ResourceGroup { get; set; }
        /// <summary>Key Vault ID for ILB App Service Environment default SSL certificate</summary>
        string SslCertKeyVaultId { get; set; }
        /// <summary>Key Vault Secret Name for ILB App Service Environment default SSL certificate</summary>
        string SslCertKeyVaultSecretName { get; set; }
        /// <summary>Current status of the App Service Environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostingEnvironmentStatus? Status { get; set; }
        /// <summary>Subscription of the App Service Environment.</summary>
        string SubscriptionId { get; set; }
        /// <summary>
        /// <code>true</code> if the App Service Environment is suspended; otherwise, <code>false</code>. The environment can be suspended,
        /// e.g. when the management endpoint is no longer available
        /// (most likely because NSG blocked the incoming traffic).
        /// </summary>
        bool? Suspended { get; set; }
        /// <summary>Number of upgrade domains of the App Service Environment.</summary>
        int? UpgradeDomain { get; set; }
        /// <summary>User added ip ranges to whitelist on ASE db</summary>
        string[] UserWhitelistedIPRange { get; set; }
        /// <summary>Description of IP SSL mapping for the App Service Environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[] VipMapping { get; set; }
        /// <summary>Description of the Virtual Network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfile VirtualNetwork { get; set; }
        /// <summary>Resource id of the Virtual Network.</summary>
        string VirtualNetworkId { get; set; }
        /// <summary>Name of the Virtual Network (read-only).</summary>
        string VirtualNetworkName { get; set; }
        /// <summary>Subnet within the Virtual Network.</summary>
        string VirtualNetworkSubnet { get; set; }
        /// <summary>Resource type of the Virtual Network (read-only).</summary>
        string VirtualNetworkType { get; set; }
        /// <summary>Name of the Virtual Network for the App Service Environment.</summary>
        string VnetName { get; set; }
        /// <summary>Resource group of the Virtual Network.</summary>
        string VnetResourceGroupName { get; set; }
        /// <summary>Subnet of the Virtual Network.</summary>
        string VnetSubnetName { get; set; }
        /// <summary>
        /// Description of worker pools with worker size IDs, VM sizes, and number of workers in each pool.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool[] WorkerPool { get; set; }

    }
}