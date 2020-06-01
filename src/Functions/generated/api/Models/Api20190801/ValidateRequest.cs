namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Resource validation request content.</summary>
    public partial class ValidateRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal
    {

        /// <summary>Target capacity of the App Service plan (number of VMs).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? Capacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).Capacity = value; }

        /// <summary>Platform (windows or linux)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContainerImagePlatform { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).ContainerImagePlatform; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).ContainerImagePlatform = value; }

        /// <summary>Repository name (image name)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContainerImageRepository { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).ContainerImageRepository; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).ContainerImageRepository = value; }

        /// <summary>Image tag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContainerImageTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).ContainerImageTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).ContainerImageTag = value; }

        /// <summary>Base URL of the container registry</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContainerRegistryBaseUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).ContainerRegistryBaseUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).ContainerRegistryBaseUrl = value; }

        /// <summary>Password for to access the container registry</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContainerRegistryPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).ContainerRegistryPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).ContainerRegistryPassword = value; }

        /// <summary>Username for to access the container registry</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ContainerRegistryUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).ContainerRegistryUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).ContainerRegistryUsername = value; }

        /// <summary>
        /// Name of App Service Environment where app or App Service plan should be created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironment { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).HostingEnvironment; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).HostingEnvironment = value; }

        /// <summary>
        /// <code>true</code> if App Service plan is for Spot instances; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsSpot { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).IsSpot; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).IsSpot = value; }

        /// <summary><code>true</code> if App Service plan is running as a windows container</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsXenon { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).IsXenon; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).IsXenon = value; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Expected location of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ValidateProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Resource name to verify.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>
        /// <code>true</code> if App Service plan is for Linux workers; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? NeedLinuxWorker { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).NeedLinuxWorker; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).NeedLinuxWorker = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateProperties _property;

        /// <summary>Properties of the resource to validate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ValidateProperties()); set => this._property = value; }

        /// <summary>ARM resource ID of an App Service plan that would host the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ServerFarmId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).ServerFarmId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).ServerFarmId = value; }

        /// <summary>Name of the target SKU for the App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)Property).SkuName = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ValidateResourceTypes _type;

        /// <summary>Resource type used for verification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ValidateResourceTypes Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ValidateRequest" /> instance.</summary>
        public ValidateRequest()
        {

        }
    }
    /// Resource validation request content.
    public partial interface IValidateRequest :
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
        /// <summary>Expected location of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Expected location of the resource.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>Resource name to verify.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Resource name to verify.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
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
        /// <summary>Resource type used for verification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Resource type used for verification.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ValidateResourceTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ValidateResourceTypes Type { get; set; }

    }
    /// Resource validation request content.
    internal partial interface IValidateRequestInternal

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
        /// <summary>Expected location of the resource.</summary>
        string Location { get; set; }
        /// <summary>Resource name to verify.</summary>
        string Name { get; set; }
        /// <summary>
        /// <code>true</code> if App Service plan is for Linux workers; otherwise, <code>false</code>.
        /// </summary>
        bool? NeedLinuxWorker { get; set; }
        /// <summary>Properties of the resource to validate.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateProperties Property { get; set; }
        /// <summary>ARM resource ID of an App Service plan that would host the app.</summary>
        string ServerFarmId { get; set; }
        /// <summary>Name of the target SKU for the App Service plan.</summary>
        string SkuName { get; set; }
        /// <summary>Resource type used for verification.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ValidateResourceTypes Type { get; set; }

    }
}