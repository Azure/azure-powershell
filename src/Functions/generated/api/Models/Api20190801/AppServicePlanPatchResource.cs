namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>ARM resource for a app service plan.</summary>
    public partial class AppServicePlanPatchResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResource,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>The time when the server farm free offer expires.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? FreeOfferExpirationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).FreeOfferExpirationTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).FreeOfferExpirationTime = value; }

        /// <summary>Geographical location for the App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string GeoRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).GeoRegion; }

        /// <summary>Resource ID of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).HostingEnvironmentProfileId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).HostingEnvironmentProfileId = value; }

        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).HostingEnvironmentProfileName; }

        /// <summary>Resource type of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).HostingEnvironmentProfileType; }

        /// <summary>
        /// If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? HyperV { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).HyperV; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).HyperV = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>If <code>true</code>, this App Service Plan owns spot instances.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsSpot { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).IsSpot; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).IsSpot = value; }

        /// <summary>
        /// Obsolete: If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsXenon { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).IsXenon; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).IsXenon = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>
        /// Maximum number of total workers allowed for this ElasticScaleEnabled App Service Plan
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? MaximumElasticWorkerCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).MaximumElasticWorkerCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).MaximumElasticWorkerCount = value; }

        /// <summary>Maximum number of instances that can be assigned to this App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? MaximumNumberOfWorker { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).MaximumNumberOfWorker; }

        /// <summary>Internal Acessors for GeoRegion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceInternal.GeoRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).GeoRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).GeoRegion = value; }

        /// <summary>Internal Acessors for HostingEnvironmentProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceInternal.HostingEnvironmentProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).HostingEnvironmentProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).HostingEnvironmentProfile = value; }

        /// <summary>Internal Acessors for HostingEnvironmentProfileName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceInternal.HostingEnvironmentProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).HostingEnvironmentProfileName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).HostingEnvironmentProfileName = value; }

        /// <summary>Internal Acessors for HostingEnvironmentProfileType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceInternal.HostingEnvironmentProfileType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).HostingEnvironmentProfileType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).HostingEnvironmentProfileType = value; }

        /// <summary>Internal Acessors for MaximumNumberOfWorker</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceInternal.MaximumNumberOfWorker { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).MaximumNumberOfWorker; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).MaximumNumberOfWorker = value; }

        /// <summary>Internal Acessors for NumberOfSite</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceInternal.NumberOfSite { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).NumberOfSite; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).NumberOfSite = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServicePlanPatchResourceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for ResourceGroup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceInternal.ResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).ResourceGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).ResourceGroup = value; }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.StatusOptions? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).Status = value; }

        /// <summary>Internal Acessors for Subscription</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceInternal.Subscription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).Subscription; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).Subscription = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Number of apps assigned to this App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? NumberOfSite { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).NumberOfSite; }

        /// <summary>
        /// If <code>true</code>, apps assigned to this App Service plan can be scaled independently.
        /// If <code>false</code>, apps assigned to this App Service plan will scale to all instances of the plan.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? PerSiteScaling { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).PerSiteScaling; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).PerSiteScaling = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceProperties _property;

        /// <summary>AppServicePlanPatchResource resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServicePlanPatchResourceProperties()); set => this._property = value; }

        /// <summary>Provisioning state of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).ProvisioningState; }

        /// <summary>If Linux app service plan <code>true</code>, <code>false</code> otherwise.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? Reserved { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).Reserved; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).Reserved = value; }

        /// <summary>Resource group of the App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).ResourceGroup; }

        /// <summary>The time when the server farm expires. Valid only if it is a spot server farm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? SpotExpirationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).SpotExpirationTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).SpotExpirationTime = value; }

        /// <summary>App Service plan status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.StatusOptions? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).Status; }

        /// <summary>App Service plan subscription.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Subscription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).Subscription; }

        /// <summary>Scaling worker count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? TargetWorkerCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).TargetWorkerCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).TargetWorkerCount = value; }

        /// <summary>Scaling worker size ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? TargetWorkerSizeId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).TargetWorkerSizeId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).TargetWorkerSizeId = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Target worker tier assigned to the App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string WorkerTierName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).WorkerTierName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourcePropertiesInternal)Property).WorkerTierName = value; }

        /// <summary>Creates an new <see cref="AppServicePlanPatchResource" /> instance.</summary>
        public AppServicePlanPatchResource()
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
    /// ARM resource for a app service plan.
    public partial interface IAppServicePlanPatchResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>The time when the server farm free offer expires.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time when the server farm free offer expires.",
        SerializedName = @"freeOfferExpirationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? FreeOfferExpirationTime { get; set; }
        /// <summary>Geographical location for the App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Geographical location for the App Service plan.",
        SerializedName = @"geoRegion",
        PossibleTypes = new [] { typeof(string) })]
        string GeoRegion { get;  }
        /// <summary>Resource ID of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID of the App Service Environment.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string HostingEnvironmentProfileId { get; set; }
        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the App Service Environment.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string HostingEnvironmentProfileName { get;  }
        /// <summary>Resource type of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type of the App Service Environment.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string HostingEnvironmentProfileType { get;  }
        /// <summary>
        /// If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.",
        SerializedName = @"hyperV",
        PossibleTypes = new [] { typeof(bool) })]
        bool? HyperV { get; set; }
        /// <summary>If <code>true</code>, this App Service Plan owns spot instances.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If <code>true</code>, this App Service Plan owns spot instances.",
        SerializedName = @"isSpot",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsSpot { get; set; }
        /// <summary>
        /// Obsolete: If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Obsolete: If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.",
        SerializedName = @"isXenon",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsXenon { get; set; }
        /// <summary>
        /// Maximum number of total workers allowed for this ElasticScaleEnabled App Service Plan
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum number of total workers allowed for this ElasticScaleEnabled App Service Plan",
        SerializedName = @"maximumElasticWorkerCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MaximumElasticWorkerCount { get; set; }
        /// <summary>Maximum number of instances that can be assigned to this App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Maximum number of instances that can be assigned to this App Service plan.",
        SerializedName = @"maximumNumberOfWorkers",
        PossibleTypes = new [] { typeof(int) })]
        int? MaximumNumberOfWorker { get;  }
        /// <summary>Number of apps assigned to this App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Number of apps assigned to this App Service plan.",
        SerializedName = @"numberOfSites",
        PossibleTypes = new [] { typeof(int) })]
        int? NumberOfSite { get;  }
        /// <summary>
        /// If <code>true</code>, apps assigned to this App Service plan can be scaled independently.
        /// If <code>false</code>, apps assigned to this App Service plan will scale to all instances of the plan.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If <code>true</code>, apps assigned to this App Service plan can be scaled independently.
        If <code>false</code>, apps assigned to this App Service plan will scale to all instances of the plan.",
        SerializedName = @"perSiteScaling",
        PossibleTypes = new [] { typeof(bool) })]
        bool? PerSiteScaling { get; set; }
        /// <summary>Provisioning state of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the App Service Environment.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>If Linux app service plan <code>true</code>, <code>false</code> otherwise.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If Linux app service plan <code>true</code>, <code>false</code> otherwise.",
        SerializedName = @"reserved",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Reserved { get; set; }
        /// <summary>Resource group of the App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource group of the App Service plan.",
        SerializedName = @"resourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGroup { get;  }
        /// <summary>The time when the server farm expires. Valid only if it is a spot server farm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time when the server farm expires. Valid only if it is a spot server farm.",
        SerializedName = @"spotExpirationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SpotExpirationTime { get; set; }
        /// <summary>App Service plan status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"App Service plan status.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.StatusOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.StatusOptions? Status { get;  }
        /// <summary>App Service plan subscription.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"App Service plan subscription.",
        SerializedName = @"subscription",
        PossibleTypes = new [] { typeof(string) })]
        string Subscription { get;  }
        /// <summary>Scaling worker count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Scaling worker count.",
        SerializedName = @"targetWorkerCount",
        PossibleTypes = new [] { typeof(int) })]
        int? TargetWorkerCount { get; set; }
        /// <summary>Scaling worker size ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Scaling worker size ID.",
        SerializedName = @"targetWorkerSizeId",
        PossibleTypes = new [] { typeof(int) })]
        int? TargetWorkerSizeId { get; set; }
        /// <summary>Target worker tier assigned to the App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target worker tier assigned to the App Service plan.",
        SerializedName = @"workerTierName",
        PossibleTypes = new [] { typeof(string) })]
        string WorkerTierName { get; set; }

    }
    /// ARM resource for a app service plan.
    internal partial interface IAppServicePlanPatchResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>The time when the server farm free offer expires.</summary>
        global::System.DateTime? FreeOfferExpirationTime { get; set; }
        /// <summary>Geographical location for the App Service plan.</summary>
        string GeoRegion { get; set; }
        /// <summary>Specification for the App Service Environment to use for the App Service plan.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile HostingEnvironmentProfile { get; set; }
        /// <summary>Resource ID of the App Service Environment.</summary>
        string HostingEnvironmentProfileId { get; set; }
        /// <summary>Name of the App Service Environment.</summary>
        string HostingEnvironmentProfileName { get; set; }
        /// <summary>Resource type of the App Service Environment.</summary>
        string HostingEnvironmentProfileType { get; set; }
        /// <summary>
        /// If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
        /// </summary>
        bool? HyperV { get; set; }
        /// <summary>If <code>true</code>, this App Service Plan owns spot instances.</summary>
        bool? IsSpot { get; set; }
        /// <summary>
        /// Obsolete: If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
        /// </summary>
        bool? IsXenon { get; set; }
        /// <summary>
        /// Maximum number of total workers allowed for this ElasticScaleEnabled App Service Plan
        /// </summary>
        int? MaximumElasticWorkerCount { get; set; }
        /// <summary>Maximum number of instances that can be assigned to this App Service plan.</summary>
        int? MaximumNumberOfWorker { get; set; }
        /// <summary>Number of apps assigned to this App Service plan.</summary>
        int? NumberOfSite { get; set; }
        /// <summary>
        /// If <code>true</code>, apps assigned to this App Service plan can be scaled independently.
        /// If <code>false</code>, apps assigned to this App Service plan will scale to all instances of the plan.
        /// </summary>
        bool? PerSiteScaling { get; set; }
        /// <summary>AppServicePlanPatchResource resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPatchResourceProperties Property { get; set; }
        /// <summary>Provisioning state of the App Service Environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>If Linux app service plan <code>true</code>, <code>false</code> otherwise.</summary>
        bool? Reserved { get; set; }
        /// <summary>Resource group of the App Service plan.</summary>
        string ResourceGroup { get; set; }
        /// <summary>The time when the server farm expires. Valid only if it is a spot server farm.</summary>
        global::System.DateTime? SpotExpirationTime { get; set; }
        /// <summary>App Service plan status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.StatusOptions? Status { get; set; }
        /// <summary>App Service plan subscription.</summary>
        string Subscription { get; set; }
        /// <summary>Scaling worker count.</summary>
        int? TargetWorkerCount { get; set; }
        /// <summary>Scaling worker size ID.</summary>
        int? TargetWorkerSizeId { get; set; }
        /// <summary>Target worker tier assigned to the App Service plan.</summary>
        string WorkerTierName { get; set; }

    }
}