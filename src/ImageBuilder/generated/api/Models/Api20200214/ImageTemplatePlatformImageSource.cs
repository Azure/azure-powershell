namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>
    /// Describes an image source from [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
    /// </summary>
    public partial class ImageTemplatePlatformImageSource :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePlatformImageSource,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePlatformImageSourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource __imageTemplateSource = new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateSource();

        /// <summary>Internal Acessors for PlanInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IPlatformImagePurchasePlan Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePlatformImageSourceInternal.PlanInfo { get => (this._planInfo = this._planInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.PlatformImagePurchasePlan()); set { {_planInfo = value;} } }

        /// <summary>Backing field for <see cref="Offer" /> property.</summary>
        private string _offer;

        /// <summary>
        /// Image offer from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string Offer { get => this._offer; set => this._offer = value; }

        /// <summary>Backing field for <see cref="PlanInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IPlatformImagePurchasePlan _planInfo;

        /// <summary>Optional configuration of purchase plan for platform image.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IPlatformImagePurchasePlan PlanInfo { get => (this._planInfo = this._planInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.PlatformImagePurchasePlan()); set => this._planInfo = value; }

        /// <summary>Name of the purchase plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string PlanInfoPlanName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IPlatformImagePurchasePlanInternal)PlanInfo).PlanName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IPlatformImagePurchasePlanInternal)PlanInfo).PlanName = value ?? null; }

        /// <summary>Product of the purchase plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string PlanInfoPlanProduct { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IPlatformImagePurchasePlanInternal)PlanInfo).PlanProduct; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IPlatformImagePurchasePlanInternal)PlanInfo).PlanProduct = value ?? null; }

        /// <summary>Publisher of the purchase plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string PlanInfoPlanPublisher { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IPlatformImagePurchasePlanInternal)PlanInfo).PlanPublisher; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IPlatformImagePurchasePlanInternal)PlanInfo).PlanPublisher = value ?? null; }

        /// <summary>Backing field for <see cref="Publisher" /> property.</summary>
        private string _publisher;

        /// <summary>
        /// Image Publisher in [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string Publisher { get => this._publisher; set => this._publisher = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private string _sku;

        /// <summary>
        /// Image sku from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string Sku { get => this._sku; set => this._sku = value; }

        /// <summary>Specifies the type of source image you want to start with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSourceInternal)__imageTemplateSource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSourceInternal)__imageTemplateSource).Type = value ; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>
        /// Image version from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="ImageTemplatePlatformImageSource" /> instance.</summary>
        public ImageTemplatePlatformImageSource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__imageTemplateSource), __imageTemplateSource);
            await eventListener.AssertObjectIsValid(nameof(__imageTemplateSource), __imageTemplateSource);
        }
    }
    /// Describes an image source from [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
    public partial interface IImageTemplatePlatformImageSource :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource
    {
        /// <summary>
        /// Image offer from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Image offer from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).",
        SerializedName = @"offer",
        PossibleTypes = new [] { typeof(string) })]
        string Offer { get; set; }
        /// <summary>Name of the purchase plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the purchase plan.",
        SerializedName = @"planName",
        PossibleTypes = new [] { typeof(string) })]
        string PlanInfoPlanName { get; set; }
        /// <summary>Product of the purchase plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Product of the purchase plan.",
        SerializedName = @"planProduct",
        PossibleTypes = new [] { typeof(string) })]
        string PlanInfoPlanProduct { get; set; }
        /// <summary>Publisher of the purchase plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Publisher of the purchase plan.",
        SerializedName = @"planPublisher",
        PossibleTypes = new [] { typeof(string) })]
        string PlanInfoPlanPublisher { get; set; }
        /// <summary>
        /// Image Publisher in [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Image Publisher in [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).",
        SerializedName = @"publisher",
        PossibleTypes = new [] { typeof(string) })]
        string Publisher { get; set; }
        /// <summary>
        /// Image sku from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Image sku from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(string) })]
        string Sku { get; set; }
        /// <summary>
        /// Image version from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Image version from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get; set; }

    }
    /// Describes an image source from [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
    public partial interface IImageTemplatePlatformImageSourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSourceInternal
    {
        /// <summary>
        /// Image offer from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
        /// </summary>
        string Offer { get; set; }
        /// <summary>Optional configuration of purchase plan for platform image.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IPlatformImagePurchasePlan PlanInfo { get; set; }
        /// <summary>Name of the purchase plan.</summary>
        string PlanInfoPlanName { get; set; }
        /// <summary>Product of the purchase plan.</summary>
        string PlanInfoPlanProduct { get; set; }
        /// <summary>Publisher of the purchase plan.</summary>
        string PlanInfoPlanPublisher { get; set; }
        /// <summary>
        /// Image Publisher in [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
        /// </summary>
        string Publisher { get; set; }
        /// <summary>
        /// Image sku from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
        /// </summary>
        string Sku { get; set; }
        /// <summary>
        /// Image version from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).
        /// </summary>
        string Version { get; set; }

    }
}