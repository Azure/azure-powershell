namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Describes a unit of image customization</summary>
    public partial class ImageTemplateCustomizer :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Friendly Name to provide context on what this customization step does</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>
        /// The type of customization tool you want to use on the Image. For example, "Shell" can be shell customizer
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ImageTemplateCustomizer" /> instance.</summary>
        public ImageTemplateCustomizer()
        {

        }
    }
    /// Describes a unit of image customization
    public partial interface IImageTemplateCustomizer :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable
    {
        /// <summary>Friendly Name to provide context on what this customization step does</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly Name to provide context on what this customization step does",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// The type of customization tool you want to use on the Image. For example, "Shell" can be shell customizer
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The type of customization tool you want to use on the Image. For example, ""Shell"" can be shell customizer",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// Describes a unit of image customization
    public partial interface IImageTemplateCustomizerInternal

    {
        /// <summary>Friendly Name to provide context on what this customization step does</summary>
        string Name { get; set; }
        /// <summary>
        /// The type of customization tool you want to use on the Image. For example, "Shell" can be shell customizer
        /// </summary>
        string Type { get; set; }

    }
}