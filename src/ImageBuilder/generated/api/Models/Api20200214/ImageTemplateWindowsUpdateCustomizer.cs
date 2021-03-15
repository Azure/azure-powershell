namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>
    /// Installs Windows Updates. Corresponds to Packer Windows Update Provisioner (https://github.com/rgl/packer-provisioner-windows-update)
    /// </summary>
    public partial class ImageTemplateWindowsUpdateCustomizer :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateWindowsUpdateCustomizer,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateWindowsUpdateCustomizerInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer __imageTemplateCustomizer = new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateCustomizer();

        /// <summary>Backing field for <see cref="Filter" /> property.</summary>
        private string[] _filter;

        /// <summary>
        /// Array of filters to select updates to apply. Omit or specify empty array to use the default (no filter). Refer to above
        /// link for examples and detailed description of this field.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string[] Filter { get => this._filter; set => this._filter = value; }

        /// <summary>Friendly Name to provide context on what this customization step does</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Name = value ?? null; }

        /// <summary>Backing field for <see cref="SearchCriterion" /> property.</summary>
        private string _searchCriterion;

        /// <summary>
        /// Criteria to search updates. Omit or specify empty string to use the default (search all). Refer to above link for examples
        /// and detailed description of this field.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string SearchCriterion { get => this._searchCriterion; set => this._searchCriterion = value; }

        /// <summary>
        /// The type of customization tool you want to use on the Image. For example, "Shell" can be shell customizer
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Type = value ; }

        /// <summary>Backing field for <see cref="UpdateLimit" /> property.</summary>
        private int? _updateLimit;

        /// <summary>
        /// Maximum number of updates to apply at a time. Omit or specify 0 to use the default (1000)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public int? UpdateLimit { get => this._updateLimit; set => this._updateLimit = value; }

        /// <summary>Creates an new <see cref="ImageTemplateWindowsUpdateCustomizer" /> instance.</summary>
        public ImageTemplateWindowsUpdateCustomizer()
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
            await eventListener.AssertNotNull(nameof(__imageTemplateCustomizer), __imageTemplateCustomizer);
            await eventListener.AssertObjectIsValid(nameof(__imageTemplateCustomizer), __imageTemplateCustomizer);
        }
    }
    /// Installs Windows Updates. Corresponds to Packer Windows Update Provisioner (https://github.com/rgl/packer-provisioner-windows-update)
    public partial interface IImageTemplateWindowsUpdateCustomizer :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer
    {
        /// <summary>
        /// Array of filters to select updates to apply. Omit or specify empty array to use the default (no filter). Refer to above
        /// link for examples and detailed description of this field.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of filters to select updates to apply. Omit or specify empty array to use the default (no filter). Refer to above link for examples and detailed description of this field.",
        SerializedName = @"filters",
        PossibleTypes = new [] { typeof(string) })]
        string[] Filter { get; set; }
        /// <summary>
        /// Criteria to search updates. Omit or specify empty string to use the default (search all). Refer to above link for examples
        /// and detailed description of this field.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Criteria to search updates. Omit or specify empty string to use the default (search all). Refer to above link for examples and detailed description of this field.",
        SerializedName = @"searchCriteria",
        PossibleTypes = new [] { typeof(string) })]
        string SearchCriterion { get; set; }
        /// <summary>
        /// Maximum number of updates to apply at a time. Omit or specify 0 to use the default (1000)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum number of updates to apply at a time. Omit or specify 0 to use the default (1000)",
        SerializedName = @"updateLimit",
        PossibleTypes = new [] { typeof(int) })]
        int? UpdateLimit { get; set; }

    }
    /// Installs Windows Updates. Corresponds to Packer Windows Update Provisioner (https://github.com/rgl/packer-provisioner-windows-update)
    public partial interface IImageTemplateWindowsUpdateCustomizerInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal
    {
        /// <summary>
        /// Array of filters to select updates to apply. Omit or specify empty array to use the default (no filter). Refer to above
        /// link for examples and detailed description of this field.
        /// </summary>
        string[] Filter { get; set; }
        /// <summary>
        /// Criteria to search updates. Omit or specify empty string to use the default (search all). Refer to above link for examples
        /// and detailed description of this field.
        /// </summary>
        string SearchCriterion { get; set; }
        /// <summary>
        /// Maximum number of updates to apply at a time. Omit or specify 0 to use the default (1000)
        /// </summary>
        int? UpdateLimit { get; set; }

    }
}