namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>App properties used for validation.</summary>
    public partial class ValidateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private int? _capacity;

        /// <summary>Target capacity of the App Service plan (number of VMs).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Capacity { get => this._capacity; set => this._capacity = value; }

        /// <summary>Backing field for <see cref="ContainerImagePlatform" /> property.</summary>
        private string _containerImagePlatform;

        /// <summary>Platform (windows or linux)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ContainerImagePlatform { get => this._containerImagePlatform; set => this._containerImagePlatform = value; }

        /// <summary>Backing field for <see cref="ContainerImageRepository" /> property.</summary>
        private string _containerImageRepository;

        /// <summary>Repository name (image name)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ContainerImageRepository { get => this._containerImageRepository; set => this._containerImageRepository = value; }

        /// <summary>Backing field for <see cref="ContainerImageTag" /> property.</summary>
        private string _containerImageTag;

        /// <summary>Image tag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ContainerImageTag { get => this._containerImageTag; set => this._containerImageTag = value; }

        /// <summary>Backing field for <see cref="ContainerRegistryBaseUrl" /> property.</summary>
        private string _containerRegistryBaseUrl;

        /// <summary>Base URL of the container registry</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ContainerRegistryBaseUrl { get => this._containerRegistryBaseUrl; set => this._containerRegistryBaseUrl = value; }

        /// <summary>Backing field for <see cref="ContainerRegistryPassword" /> property.</summary>
        private string _containerRegistryPassword;

        /// <summary>Password for to access the container registry</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ContainerRegistryPassword { get => this._containerRegistryPassword; set => this._containerRegistryPassword = value; }

        /// <summary>Backing field for <see cref="ContainerRegistryUsername" /> property.</summary>
        private string _containerRegistryUsername;

        /// <summary>Username for to access the container registry</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ContainerRegistryUsername { get => this._containerRegistryUsername; set => this._containerRegistryUsername = value; }

        /// <summary>Backing field for <see cref="HostingEnvironment" /> property.</summary>
        private string _hostingEnvironment;

        /// <summary>
        /// Name of App Service Environment where app or App Service plan should be created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string HostingEnvironment { get => this._hostingEnvironment; set => this._hostingEnvironment = value; }

        /// <summary>Backing field for <see cref="IsSpot" /> property.</summary>
        private bool? _isSpot;

        /// <summary>
        /// <code>true</code> if App Service plan is for Spot instances; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsSpot { get => this._isSpot; set => this._isSpot = value; }

        /// <summary>Backing field for <see cref="IsXenon" /> property.</summary>
        private bool? _isXenon;

        /// <summary><code>true</code> if App Service plan is running as a windows container</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsXenon { get => this._isXenon; set => this._isXenon = value; }

        /// <summary>Backing field for <see cref="NeedLinuxWorker" /> property.</summary>
        private bool? _needLinuxWorker;

        /// <summary>
        /// <code>true</code> if App Service plan is for Linux workers; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? NeedLinuxWorker { get => this._needLinuxWorker; set => this._needLinuxWorker = value; }

        /// <summary>Backing field for <see cref="ServerFarmId" /> property.</summary>
        private string _serverFarmId;

        /// <summary>ARM resource ID of an App Service plan that would host the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ServerFarmId { get => this._serverFarmId; set => this._serverFarmId = value; }

        /// <summary>Backing field for <see cref="SkuName" /> property.</summary>
        private string _skuName;

        /// <summary>Name of the target SKU for the App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SkuName { get => this._skuName; set => this._skuName = value; }

        /// <summary>Creates an new <see cref="ValidateProperties" /> instance.</summary>
        public ValidateProperties()
        {

        }
    }
    /// App properties used for validation.
    public partial interface IValidateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Target capacity of the App Service plan (number of VMs).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target capacity of the App Service plan (number of VMs).",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? Capacity { get; set; }
        /// <summary>Platform (windows or linux)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Platform (windows or linux)",
        SerializedName = @"containerImagePlatform",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerImagePlatform { get; set; }
        /// <summary>Repository name (image name)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Repository name (image name)",
        SerializedName = @"containerImageRepository",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerImageRepository { get; set; }
        /// <summary>Image tag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Image tag",
        SerializedName = @"containerImageTag",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerImageTag { get; set; }
        /// <summary>Base URL of the container registry</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Base URL of the container registry",
        SerializedName = @"containerRegistryBaseUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerRegistryBaseUrl { get; set; }
        /// <summary>Password for to access the container registry</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Password for to access the container registry",
        SerializedName = @"containerRegistryPassword",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerRegistryPassword { get; set; }
        /// <summary>Username for to access the container registry</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Username for to access the container registry",
        SerializedName = @"containerRegistryUsername",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerRegistryUsername { get; set; }
        /// <summary>
        /// Name of App Service Environment where app or App Service plan should be created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of App Service Environment where app or App Service plan should be created.",
        SerializedName = @"hostingEnvironment",
        PossibleTypes = new [] { typeof(string) })]
        string HostingEnvironment { get; set; }
        /// <summary>
        /// <code>true</code> if App Service plan is for Spot instances; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if App Service plan is for Spot instances; otherwise, <code>false</code>.",
        SerializedName = @"isSpot",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsSpot { get; set; }
        /// <summary><code>true</code> if App Service plan is running as a windows container</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if App Service plan is running as a windows container",
        SerializedName = @"isXenon",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsXenon { get; set; }
        /// <summary>
        /// <code>true</code> if App Service plan is for Linux workers; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if App Service plan is for Linux workers; otherwise, <code>false</code>.",
        SerializedName = @"needLinuxWorkers",
        PossibleTypes = new [] { typeof(bool) })]
        bool? NeedLinuxWorker { get; set; }
        /// <summary>ARM resource ID of an App Service plan that would host the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ARM resource ID of an App Service plan that would host the app.",
        SerializedName = @"serverFarmId",
        PossibleTypes = new [] { typeof(string) })]
        string ServerFarmId { get; set; }
        /// <summary>Name of the target SKU for the App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the target SKU for the App Service plan.",
        SerializedName = @"skuName",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }

    }
    /// App properties used for validation.
    internal partial interface IValidatePropertiesInternal

    {
        /// <summary>Target capacity of the App Service plan (number of VMs).</summary>
        int? Capacity { get; set; }
        /// <summary>Platform (windows or linux)</summary>
        string ContainerImagePlatform { get; set; }
        /// <summary>Repository name (image name)</summary>
        string ContainerImageRepository { get; set; }
        /// <summary>Image tag</summary>
        string ContainerImageTag { get; set; }
        /// <summary>Base URL of the container registry</summary>
        string ContainerRegistryBaseUrl { get; set; }
        /// <summary>Password for to access the container registry</summary>
        string ContainerRegistryPassword { get; set; }
        /// <summary>Username for to access the container registry</summary>
        string ContainerRegistryUsername { get; set; }
        /// <summary>
        /// Name of App Service Environment where app or App Service plan should be created.
        /// </summary>
        string HostingEnvironment { get; set; }
        /// <summary>
        /// <code>true</code> if App Service plan is for Spot instances; otherwise, <code>false</code>.
        /// </summary>
        bool? IsSpot { get; set; }
        /// <summary><code>true</code> if App Service plan is running as a windows container</summary>
        bool? IsXenon { get; set; }
        /// <summary>
        /// <code>true</code> if App Service plan is for Linux workers; otherwise, <code>false</code>.
        /// </summary>
        bool? NeedLinuxWorker { get; set; }
        /// <summary>ARM resource ID of an App Service plan that would host the app.</summary>
        string ServerFarmId { get; set; }
        /// <summary>Name of the target SKU for the App Service plan.</summary>
        string SkuName { get; set; }

    }
}