namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Service resource</summary>
    public partial class ServiceResource :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResource,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.TrackedResource();

        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string ConfigServerPropertiesErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ConfigServerPropertiesErrorCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ConfigServerPropertiesErrorCode = value; }

        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string ConfigServerPropertiesErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ConfigServerPropertiesErrorMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ConfigServerPropertiesErrorMessage = value; }

        /// <summary>State of the config server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState? ConfigServerPropertyState { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ConfigServerPropertyState; }

        /// <summary>Public sshKey of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyHostKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyHostKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyHostKey = value; }

        /// <summary>SshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyHostKeyAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyHostKeyAlgorithm; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyHostKeyAlgorithm = value; }

        /// <summary>Label of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyLabel; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyLabel = value; }

        /// <summary>Password of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyPassword = value; }

        /// <summary>Private sshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyPrivateKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyPrivateKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyPrivateKey = value; }

        /// <summary>Repositories of git.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository[] GitPropertyRepository { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyRepository; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyRepository = value; }

        /// <summary>Searching path of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string[] GitPropertySearchPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertySearchPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertySearchPath = value; }

        /// <summary>Strict host key checking or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public bool? GitPropertyStrictHostKeyChecking { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyStrictHostKeyChecking; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyStrictHostKeyChecking = value; }

        /// <summary>URI of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyUri = value; }

        /// <summary>Username of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).GitPropertyUsername = value; }

        /// <summary>Fully qualified resource Id for the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__trackedResource).Id; }

        /// <summary>The GEO location of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITrackedResourceInternal)__trackedResource).Location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>Internal Acessors for ConfigServerGitProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerGitProperty Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResourceInternal.ConfigServerGitProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ConfigServerGitProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ConfigServerGitProperty = value; }

        /// <summary>Internal Acessors for ConfigServerProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerProperties Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResourceInternal.ConfigServerProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ConfigServerProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ConfigServerProperty = value; }

        /// <summary>Internal Acessors for ConfigServerPropertyConfigServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettings Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResourceInternal.ConfigServerPropertyConfigServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ConfigServerPropertyConfigServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ConfigServerPropertyConfigServer = value; }

        /// <summary>Internal Acessors for ConfigServerPropertyError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResourceInternal.ConfigServerPropertyError { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ConfigServerPropertyError; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ConfigServerPropertyError = value; }

        /// <summary>Internal Acessors for ConfigServerPropertyState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResourceInternal.ConfigServerPropertyState { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ConfigServerPropertyState; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ConfigServerPropertyState = value; }

        /// <summary>Internal Acessors for NetworkProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfile Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResourceInternal.NetworkProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).NetworkProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).NetworkProfile = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourceProperties Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ClusterResourceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResourceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for ServiceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResourceInternal.ServiceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ServiceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ServiceId = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ISku Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResourceInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.Sku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for Trace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITraceProperties Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResourceInternal.Trace { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).Trace; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).Trace = value; }

        /// <summary>Internal Acessors for TraceError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResourceInternal.TraceError { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).TraceError; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).TraceError = value; }

        /// <summary>Internal Acessors for TraceState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResourceInternal.TraceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).TraceState; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).TraceState = value; }

        /// <summary>Internal Acessors for Version</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IServiceResourceInternal.Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).Version = value; }

        /// <summary>The name of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__trackedResource).Name; }

        /// <summary>
        /// Name of the resource group containing network resources of Azure Spring Cloud Apps
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string NetworkProfileAppNetworkResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).NetworkProfileAppNetworkResourceGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).NetworkProfileAppNetworkResourceGroup = value; }

        /// <summary>Fully qualified resource Id of the subnet to host Azure Spring Cloud Apps</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string NetworkProfileAppSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).NetworkProfileAppSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).NetworkProfileAppSubnetId = value; }

        /// <summary>Azure Spring Cloud service reserved CIDR</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string NetworkProfileServiceCidr { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).NetworkProfileServiceCidr; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).NetworkProfileServiceCidr = value; }

        /// <summary>
        /// Name of the resource group containing network resources of Azure Spring Cloud Service Runtime
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string NetworkProfileServiceRuntimeNetworkResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).NetworkProfileServiceRuntimeNetworkResourceGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).NetworkProfileServiceRuntimeNetworkResourceGroup = value; }

        /// <summary>
        /// Fully qualified resource Id of the subnet to host Azure Spring Cloud Service Runtime
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string NetworkProfileServiceRuntimeSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).NetworkProfileServiceRuntimeSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).NetworkProfileServiceRuntimeSubnetId = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourceProperties _property;

        /// <summary>Properties of the Service resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ClusterResourceProperties()); set => this._property = value; }

        /// <summary>Provisioning state of the Service</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ProvisioningState; }

        /// <summary>ServiceInstanceEntity GUID which uniquely identifies a created resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string ServiceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).ServiceId; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ISku _sku;

        /// <summary>Sku of the Service resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.Sku()); set => this._sku = value; }

        /// <summary>Current capacity of the target resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public int? SkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ISkuInternal)Sku).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ISkuInternal)Sku).Capacity = value; }

        /// <summary>Name of the Sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ISkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ISkuInternal)Sku).Name = value; }

        /// <summary>Tier of the Sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ISkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ISkuInternal)Sku).Tier = value; }

        /// <summary>
        /// Tags of the service which is a list of key value pairs that describe the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITrackedResourceInternal)__trackedResource).Tag = value; }

        /// <summary>Target application insight instrumentation key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string TraceAppInsightInstrumentationKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).TraceAppInsightInstrumentationKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).TraceAppInsightInstrumentationKey = value; }

        /// <summary>Indicates whether enable the tracing functionality</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public bool? TraceEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).TraceEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).TraceEnabled = value; }

        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string TraceErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).TraceErrorCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).TraceErrorCode = value; }

        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string TraceErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).TraceErrorMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).TraceErrorMessage = value; }

        /// <summary>State of the trace proxy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState? TraceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).TraceState; }

        /// <summary>The type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceInternal)__trackedResource).Type; }

        /// <summary>Version of the Service</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public int? Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal)Property).Version; }

        /// <summary>Creates an new <see cref="ServiceResource" /> instance.</summary>
        public ServiceResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// Service resource
    public partial interface IServiceResource :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITrackedResource
    {
        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The code of error.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string ConfigServerPropertiesErrorCode { get; set; }
        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The message of error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string ConfigServerPropertiesErrorMessage { get; set; }
        /// <summary>State of the config server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of the config server.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState? ConfigServerPropertyState { get;  }
        /// <summary>Public sshKey of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Public sshKey of git repository.",
        SerializedName = @"hostKey",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyHostKey { get; set; }
        /// <summary>SshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SshKey algorithm of git repository.",
        SerializedName = @"hostKeyAlgorithm",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyHostKeyAlgorithm { get; set; }
        /// <summary>Label of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Label of the repository",
        SerializedName = @"label",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyLabel { get; set; }
        /// <summary>Password of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Password of git repository basic auth.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyPassword { get; set; }
        /// <summary>Private sshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Private sshKey algorithm of git repository.",
        SerializedName = @"privateKey",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyPrivateKey { get; set; }
        /// <summary>Repositories of git.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Repositories of git.",
        SerializedName = @"repositories",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository[] GitPropertyRepository { get; set; }
        /// <summary>Searching path of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Searching path of the repository",
        SerializedName = @"searchPaths",
        PossibleTypes = new [] { typeof(string) })]
        string[] GitPropertySearchPath { get; set; }
        /// <summary>Strict host key checking or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Strict host key checking or not.",
        SerializedName = @"strictHostKeyChecking",
        PossibleTypes = new [] { typeof(bool) })]
        bool? GitPropertyStrictHostKeyChecking { get; set; }
        /// <summary>URI of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"URI of the repository",
        SerializedName = @"uri",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyUri { get; set; }
        /// <summary>Username of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Username of git repository basic auth.",
        SerializedName = @"username",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyUsername { get; set; }
        /// <summary>
        /// Name of the resource group containing network resources of Azure Spring Cloud Apps
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the resource group containing network resources of Azure Spring Cloud Apps",
        SerializedName = @"appNetworkResourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileAppNetworkResourceGroup { get; set; }
        /// <summary>Fully qualified resource Id of the subnet to host Azure Spring Cloud Apps</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fully qualified resource Id of the subnet to host Azure Spring Cloud Apps",
        SerializedName = @"appSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileAppSubnetId { get; set; }
        /// <summary>Azure Spring Cloud service reserved CIDR</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Azure Spring Cloud service reserved CIDR",
        SerializedName = @"serviceCidr",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileServiceCidr { get; set; }
        /// <summary>
        /// Name of the resource group containing network resources of Azure Spring Cloud Service Runtime
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the resource group containing network resources of Azure Spring Cloud Service Runtime",
        SerializedName = @"serviceRuntimeNetworkResourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileServiceRuntimeNetworkResourceGroup { get; set; }
        /// <summary>
        /// Fully qualified resource Id of the subnet to host Azure Spring Cloud Service Runtime
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fully qualified resource Id of the subnet to host Azure Spring Cloud Service Runtime",
        SerializedName = @"serviceRuntimeSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileServiceRuntimeSubnetId { get; set; }
        /// <summary>Provisioning state of the Service</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the Service",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>ServiceInstanceEntity GUID which uniquely identifies a created resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ServiceInstanceEntity GUID which uniquely identifies a created resource",
        SerializedName = @"serviceId",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceId { get;  }
        /// <summary>Current capacity of the target resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Current capacity of the target resource",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? SkuCapacity { get; set; }
        /// <summary>Name of the Sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the Sku",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }
        /// <summary>Tier of the Sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tier of the Sku",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string SkuTier { get; set; }
        /// <summary>Target application insight instrumentation key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target application insight instrumentation key",
        SerializedName = @"appInsightInstrumentationKey",
        PossibleTypes = new [] { typeof(string) })]
        string TraceAppInsightInstrumentationKey { get; set; }
        /// <summary>Indicates whether enable the tracing functionality</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether enable the tracing functionality",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? TraceEnabled { get; set; }
        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The code of error.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string TraceErrorCode { get; set; }
        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The message of error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string TraceErrorMessage { get; set; }
        /// <summary>State of the trace proxy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of the trace proxy.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState? TraceState { get;  }
        /// <summary>Version of the Service</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the Service",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(int) })]
        int? Version { get;  }

    }
    /// Service resource
    public partial interface IServiceResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITrackedResourceInternal
    {
        /// <summary>Property of git environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerGitProperty ConfigServerGitProperty { get; set; }
        /// <summary>The code of error.</summary>
        string ConfigServerPropertiesErrorCode { get; set; }
        /// <summary>The message of error.</summary>
        string ConfigServerPropertiesErrorMessage { get; set; }
        /// <summary>Config server git properties of the Service</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerProperties ConfigServerProperty { get; set; }
        /// <summary>Settings of config server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettings ConfigServerPropertyConfigServer { get; set; }
        /// <summary>Error when apply config server settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError ConfigServerPropertyError { get; set; }
        /// <summary>State of the config server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState? ConfigServerPropertyState { get; set; }
        /// <summary>Public sshKey of git repository.</summary>
        string GitPropertyHostKey { get; set; }
        /// <summary>SshKey algorithm of git repository.</summary>
        string GitPropertyHostKeyAlgorithm { get; set; }
        /// <summary>Label of the repository</summary>
        string GitPropertyLabel { get; set; }
        /// <summary>Password of git repository basic auth.</summary>
        string GitPropertyPassword { get; set; }
        /// <summary>Private sshKey algorithm of git repository.</summary>
        string GitPropertyPrivateKey { get; set; }
        /// <summary>Repositories of git.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository[] GitPropertyRepository { get; set; }
        /// <summary>Searching path of the repository</summary>
        string[] GitPropertySearchPath { get; set; }
        /// <summary>Strict host key checking or not.</summary>
        bool? GitPropertyStrictHostKeyChecking { get; set; }
        /// <summary>URI of the repository</summary>
        string GitPropertyUri { get; set; }
        /// <summary>Username of git repository basic auth.</summary>
        string GitPropertyUsername { get; set; }
        /// <summary>Network profile of the Service</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfile NetworkProfile { get; set; }
        /// <summary>
        /// Name of the resource group containing network resources of Azure Spring Cloud Apps
        /// </summary>
        string NetworkProfileAppNetworkResourceGroup { get; set; }
        /// <summary>Fully qualified resource Id of the subnet to host Azure Spring Cloud Apps</summary>
        string NetworkProfileAppSubnetId { get; set; }
        /// <summary>Azure Spring Cloud service reserved CIDR</summary>
        string NetworkProfileServiceCidr { get; set; }
        /// <summary>
        /// Name of the resource group containing network resources of Azure Spring Cloud Service Runtime
        /// </summary>
        string NetworkProfileServiceRuntimeNetworkResourceGroup { get; set; }
        /// <summary>
        /// Fully qualified resource Id of the subnet to host Azure Spring Cloud Service Runtime
        /// </summary>
        string NetworkProfileServiceRuntimeSubnetId { get; set; }
        /// <summary>Properties of the Service resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourceProperties Property { get; set; }
        /// <summary>Provisioning state of the Service</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>ServiceInstanceEntity GUID which uniquely identifies a created resource</summary>
        string ServiceId { get; set; }
        /// <summary>Sku of the Service resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ISku Sku { get; set; }
        /// <summary>Current capacity of the target resource</summary>
        int? SkuCapacity { get; set; }
        /// <summary>Name of the Sku</summary>
        string SkuName { get; set; }
        /// <summary>Tier of the Sku</summary>
        string SkuTier { get; set; }
        /// <summary>Trace properties of the Service</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITraceProperties Trace { get; set; }
        /// <summary>Target application insight instrumentation key</summary>
        string TraceAppInsightInstrumentationKey { get; set; }
        /// <summary>Indicates whether enable the tracing functionality</summary>
        bool? TraceEnabled { get; set; }
        /// <summary>Error when apply trace proxy changes.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError TraceError { get; set; }
        /// <summary>The code of error.</summary>
        string TraceErrorCode { get; set; }
        /// <summary>The message of error.</summary>
        string TraceErrorMessage { get; set; }
        /// <summary>State of the trace proxy.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState? TraceState { get; set; }
        /// <summary>Version of the Service</summary>
        int? Version { get; set; }

    }
}