namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>ARM resource for a app service environment.</summary>
    public partial class AppServiceEnvironmentPatchResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResource,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>
        /// List of comma separated strings describing which VM sizes are allowed for front-ends.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AllowedMultiSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).AllowedMultiSize; }

        /// <summary>
        /// List of comma separated strings describing which VM sizes are allowed for workers.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AllowedWorkerSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).AllowedWorkerSize; }

        /// <summary>API Management Account associated with the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ApiManagementAccountId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).ApiManagementAccountId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).ApiManagementAccountId = value; }

        /// <summary>Custom settings for changing the behavior of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] ClusterSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).ClusterSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).ClusterSetting = value; }

        /// <summary>
        /// Edition of the metadata database for the App Service Environment, e.g. "Standard".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DatabaseEdition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).DatabaseEdition; }

        /// <summary>
        /// Service objective of the metadata database for the App Service Environment, e.g. "S0".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DatabaseServiceObjective { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).DatabaseServiceObjective; }

        /// <summary>Default Scale Factor for FrontEnds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? DefaultFrontEndScaleFactor { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).DefaultFrontEndScaleFactor; }

        /// <summary>DNS suffix of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DnsSuffix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).DnsSuffix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).DnsSuffix = value; }

        /// <summary>
        /// True/false indicating whether the App Service Environment is suspended. The environment can be suspended e.g. when the
        /// management endpoint is no longer available
        /// (most likely because NSG blocked the incoming traffic).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? DynamicCacheEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).DynamicCacheEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).DynamicCacheEnabled = value; }

        /// <summary>Current total, used, and available worker capacities.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity[] EnvironmentCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).EnvironmentCapacity; }

        /// <summary>True/false indicating whether the App Service Environment is healthy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? EnvironmentIsHealthy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).EnvironmentIsHealthy; }

        /// <summary>
        /// Detailed message about with results of the last check of the App Service Environment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string EnvironmentStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).EnvironmentStatus; }

        /// <summary>Scale factor for front-ends.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? FrontEndScaleFactor { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).FrontEndScaleFactor; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).FrontEndScaleFactor = value; }

        /// <summary>Flag that displays whether an ASE has linux workers or not</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? HasLinuxWorker { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).HasLinuxWorker; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).HasLinuxWorker = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>
        /// Specifies which endpoints to serve internally in the Virtual Network for the App Service Environment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.InternalLoadBalancingMode? InternalLoadBalancingMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).InternalLoadBalancingMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).InternalLoadBalancingMode = value; }

        /// <summary>Number of IP SSL addresses reserved for the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? IpsslAddressCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).IpsslAddressCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).IpsslAddressCount = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Last deployment action on the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LastAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).LastAction; }

        /// <summary>Result of the last deployment action on the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LastActionResult { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).LastActionResult; }

        /// <summary>Location of the App Service Environment, e.g. "West US".</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).Location = value; }

        /// <summary>Maximum number of VMs in the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? MaximumNumberOfMachine { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).MaximumNumberOfMachine; }

        /// <summary>Internal Acessors for AllowedMultiSize</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.AllowedMultiSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).AllowedMultiSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).AllowedMultiSize = value; }

        /// <summary>Internal Acessors for AllowedWorkerSize</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.AllowedWorkerSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).AllowedWorkerSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).AllowedWorkerSize = value; }

        /// <summary>Internal Acessors for DatabaseEdition</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.DatabaseEdition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).DatabaseEdition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).DatabaseEdition = value; }

        /// <summary>Internal Acessors for DatabaseServiceObjective</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.DatabaseServiceObjective { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).DatabaseServiceObjective; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).DatabaseServiceObjective = value; }

        /// <summary>Internal Acessors for DefaultFrontEndScaleFactor</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.DefaultFrontEndScaleFactor { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).DefaultFrontEndScaleFactor; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).DefaultFrontEndScaleFactor = value; }

        /// <summary>Internal Acessors for EnvironmentCapacity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.EnvironmentCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).EnvironmentCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).EnvironmentCapacity = value; }

        /// <summary>Internal Acessors for EnvironmentIsHealthy</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.EnvironmentIsHealthy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).EnvironmentIsHealthy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).EnvironmentIsHealthy = value; }

        /// <summary>Internal Acessors for EnvironmentStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.EnvironmentStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).EnvironmentStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).EnvironmentStatus = value; }

        /// <summary>Internal Acessors for LastAction</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.LastAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).LastAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).LastAction = value; }

        /// <summary>Internal Acessors for LastActionResult</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.LastActionResult { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).LastActionResult; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).LastActionResult = value; }

        /// <summary>Internal Acessors for MaximumNumberOfMachine</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.MaximumNumberOfMachine { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).MaximumNumberOfMachine; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).MaximumNumberOfMachine = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironment Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServiceEnvironment()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for ResourceGroup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.ResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).ResourceGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).ResourceGroup = value; }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostingEnvironmentStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).Status = value; }

        /// <summary>Internal Acessors for SubscriptionId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.SubscriptionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).SubscriptionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).SubscriptionId = value; }

        /// <summary>Internal Acessors for UpgradeDomain</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.UpgradeDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).UpgradeDomain; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).UpgradeDomain = value; }

        /// <summary>Internal Acessors for VipMapping</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.VipMapping { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VipMapping; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VipMapping = value; }

        /// <summary>Internal Acessors for VirtualNetwork</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfile Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.VirtualNetwork { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VirtualNetwork; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VirtualNetwork = value; }

        /// <summary>Internal Acessors for VirtualNetworkName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.VirtualNetworkName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VirtualNetworkName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VirtualNetworkName = value; }

        /// <summary>Internal Acessors for VirtualNetworkType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentPatchResourceInternal.VirtualNetworkType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VirtualNetworkType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VirtualNetworkType = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Number of front-end instances.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? MultiRoleCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).MultiRoleCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).MultiRoleCount = value; }

        /// <summary>Front-end VM size, e.g. "Medium", "Large".</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MultiSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).MultiSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).MultiSize = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Access control list for controlling traffic to the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkAccessControlEntry[] NetworkAccessControlList { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).NetworkAccessControlList; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).NetworkAccessControlList = value; }

        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PropertiesName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).Name = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironment _property;

        /// <summary>Core resource properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironment Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServiceEnvironment()); set => this._property = value; }

        /// <summary>Provisioning state of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).ProvisioningState; }

        /// <summary>Resource group of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).ResourceGroup; }

        /// <summary>Key Vault ID for ILB App Service Environment default SSL certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SslCertKeyVaultId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).SslCertKeyVaultId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).SslCertKeyVaultId = value; }

        /// <summary>Key Vault Secret Name for ILB App Service Environment default SSL certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SslCertKeyVaultSecretName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).SslCertKeyVaultSecretName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).SslCertKeyVaultSecretName = value; }

        /// <summary>Current status of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostingEnvironmentStatus? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).Status; }

        /// <summary>Subscription of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SubscriptionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).SubscriptionId; }

        /// <summary>
        /// <code>true</code> if the App Service Environment is suspended; otherwise, <code>false</code>. The environment can be suspended,
        /// e.g. when the management endpoint is no longer available
        /// (most likely because NSG blocked the incoming traffic).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? Suspended { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).Suspended; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).Suspended = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Number of upgrade domains of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? UpgradeDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).UpgradeDomain; }

        /// <summary>User added ip ranges to whitelist on ASE db</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] UserWhitelistedIPRange { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).UserWhitelistedIPRange; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).UserWhitelistedIPRange = value; }

        /// <summary>Description of IP SSL mapping for the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[] VipMapping { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VipMapping; }

        /// <summary>Resource id of the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VirtualNetworkId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VirtualNetworkId = value; }

        /// <summary>Name of the Virtual Network (read-only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VirtualNetworkName; }

        /// <summary>Subnet within the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VirtualNetworkSubnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VirtualNetworkSubnet = value; }

        /// <summary>Resource type of the Virtual Network (read-only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VirtualNetworkType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VirtualNetworkType; }

        /// <summary>Name of the Virtual Network for the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VnetName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VnetName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VnetName = value; }

        /// <summary>Resource group of the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VnetResourceGroupName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VnetResourceGroupName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VnetResourceGroupName = value; }

        /// <summary>Subnet of the Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VnetSubnetName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VnetSubnetName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).VnetSubnetName = value; }

        /// <summary>
        /// Description of worker pools with worker size IDs, VM sizes, and number of workers in each pool.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool[] WorkerPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).WorkerPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)Property).WorkerPool = value; }

        /// <summary>Creates an new <see cref="AppServiceEnvironmentPatchResource" /> instance.</summary>
        public AppServiceEnvironmentPatchResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// ARM resource for a app service environment.
    public partial interface IAppServiceEnvironmentPatchResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
        /// <summary>Access control list for controlling traffic to the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Access control list for controlling traffic to the App Service Environment.",
        SerializedName = @"networkAccessControlList",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkAccessControlEntry) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkAccessControlEntry[] NetworkAccessControlList { get; set; }
        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Name of the App Service Environment.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string PropertiesName { get; set; }
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
    /// ARM resource for a app service environment.
    internal partial interface IAppServiceEnvironmentPatchResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
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
        /// <summary>Access control list for controlling traffic to the App Service Environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkAccessControlEntry[] NetworkAccessControlList { get; set; }
        /// <summary>Name of the App Service Environment.</summary>
        string PropertiesName { get; set; }
        /// <summary>Core resource properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironment Property { get; set; }
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