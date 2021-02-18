namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>AppServicePlan resource specific properties</summary>
    public partial class AppServicePlanProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FreeOfferExpirationTime" /> property.</summary>
        private global::System.DateTime? _freeOfferExpirationTime;

        /// <summary>The time when the server farm free offer expires.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? FreeOfferExpirationTime { get => this._freeOfferExpirationTime; set => this._freeOfferExpirationTime = value; }

        /// <summary>Backing field for <see cref="GeoRegion" /> property.</summary>
        private string _geoRegion;

        /// <summary>Geographical location for the App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string GeoRegion { get => this._geoRegion; }

        /// <summary>Backing field for <see cref="HostingEnvironmentProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile _hostingEnvironmentProfile;

        /// <summary>Specification for the App Service Environment to use for the App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile HostingEnvironmentProfile { get => (this._hostingEnvironmentProfile = this._hostingEnvironmentProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostingEnvironmentProfile()); set => this._hostingEnvironmentProfile = value; }

        /// <summary>Resource ID of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Id = value; }

        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Name; }

        /// <summary>Resource type of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Type; }

        /// <summary>Backing field for <see cref="HyperV" /> property.</summary>
        private bool? _hyperV;

        /// <summary>
        /// If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? HyperV { get => this._hyperV; set => this._hyperV = value; }

        /// <summary>Backing field for <see cref="IsSpot" /> property.</summary>
        private bool? _isSpot;

        /// <summary>If <code>true</code>, this App Service Plan owns spot instances.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsSpot { get => this._isSpot; set => this._isSpot = value; }

        /// <summary>Backing field for <see cref="IsXenon" /> property.</summary>
        private bool? _isXenon;

        /// <summary>
        /// Obsolete: If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsXenon { get => this._isXenon; set => this._isXenon = value; }

        /// <summary>Backing field for <see cref="MaximumElasticWorkerCount" /> property.</summary>
        private int? _maximumElasticWorkerCount;

        /// <summary>
        /// Maximum number of total workers allowed for this ElasticScaleEnabled App Service Plan
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? MaximumElasticWorkerCount { get => this._maximumElasticWorkerCount; set => this._maximumElasticWorkerCount = value; }

        /// <summary>Backing field for <see cref="MaximumNumberOfWorker" /> property.</summary>
        private int? _maximumNumberOfWorker;

        /// <summary>Maximum number of instances that can be assigned to this App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? MaximumNumberOfWorker { get => this._maximumNumberOfWorker; }

        /// <summary>Internal Acessors for GeoRegion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPropertiesInternal.GeoRegion { get => this._geoRegion; set { {_geoRegion = value;} } }

        /// <summary>Internal Acessors for HostingEnvironmentProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPropertiesInternal.HostingEnvironmentProfile { get => (this._hostingEnvironmentProfile = this._hostingEnvironmentProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostingEnvironmentProfile()); set { {_hostingEnvironmentProfile = value;} } }

        /// <summary>Internal Acessors for HostingEnvironmentProfileName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPropertiesInternal.HostingEnvironmentProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Name = value; }

        /// <summary>Internal Acessors for HostingEnvironmentProfileType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPropertiesInternal.HostingEnvironmentProfileType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Type = value; }

        /// <summary>Internal Acessors for MaximumNumberOfWorker</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPropertiesInternal.MaximumNumberOfWorker { get => this._maximumNumberOfWorker; set { {_maximumNumberOfWorker = value;} } }

        /// <summary>Internal Acessors for NumberOfSite</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPropertiesInternal.NumberOfSite { get => this._numberOfSite; set { {_numberOfSite = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for ResourceGroup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPropertiesInternal.ResourceGroup { get => this._resourceGroup; set { {_resourceGroup = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.StatusOptions? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPropertiesInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Internal Acessors for Subscription</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanPropertiesInternal.Subscription { get => this._subscription; set { {_subscription = value;} } }

        /// <summary>Backing field for <see cref="NumberOfSite" /> property.</summary>
        private int? _numberOfSite;

        /// <summary>Number of apps assigned to this App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? NumberOfSite { get => this._numberOfSite; }

        /// <summary>Backing field for <see cref="PerSiteScaling" /> property.</summary>
        private bool? _perSiteScaling;

        /// <summary>
        /// If <code>true</code>, apps assigned to this App Service plan can be scaled independently.
        /// If <code>false</code>, apps assigned to this App Service plan will scale to all instances of the plan.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? PerSiteScaling { get => this._perSiteScaling; set => this._perSiteScaling = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? _provisioningState;

        /// <summary>Provisioning state of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Reserved" /> property.</summary>
        private bool? _reserved;

        /// <summary>If Linux app service plan <code>true</code>, <code>false</code> otherwise.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Reserved { get => this._reserved; set => this._reserved = value; }

        /// <summary>Backing field for <see cref="ResourceGroup" /> property.</summary>
        private string _resourceGroup;

        /// <summary>Resource group of the App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ResourceGroup { get => this._resourceGroup; }

        /// <summary>Backing field for <see cref="SpotExpirationTime" /> property.</summary>
        private global::System.DateTime? _spotExpirationTime;

        /// <summary>The time when the server farm expires. Valid only if it is a spot server farm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? SpotExpirationTime { get => this._spotExpirationTime; set => this._spotExpirationTime = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.StatusOptions? _status;

        /// <summary>App Service plan status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.StatusOptions? Status { get => this._status; }

        /// <summary>Backing field for <see cref="Subscription" /> property.</summary>
        private string _subscription;

        /// <summary>App Service plan subscription.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Subscription { get => this._subscription; }

        /// <summary>Backing field for <see cref="TargetWorkerCount" /> property.</summary>
        private int? _targetWorkerCount;

        /// <summary>Scaling worker count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? TargetWorkerCount { get => this._targetWorkerCount; set => this._targetWorkerCount = value; }

        /// <summary>Backing field for <see cref="TargetWorkerSizeId" /> property.</summary>
        private int? _targetWorkerSizeId;

        /// <summary>Scaling worker size ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? TargetWorkerSizeId { get => this._targetWorkerSizeId; set => this._targetWorkerSizeId = value; }

        /// <summary>Backing field for <see cref="WorkerTierName" /> property.</summary>
        private string _workerTierName;

        /// <summary>Target worker tier assigned to the App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string WorkerTierName { get => this._workerTierName; set => this._workerTierName = value; }

        /// <summary>Creates an new <see cref="AppServicePlanProperties" /> instance.</summary>
        public AppServicePlanProperties()
        {

        }
    }
    /// AppServicePlan resource specific properties
    public partial interface IAppServicePlanProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
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
    /// AppServicePlan resource specific properties
    internal partial interface IAppServicePlanPropertiesInternal

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