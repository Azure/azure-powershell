namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>
    /// Runs a shell script during the customization phase (Linux). Corresponds to Packer shell provisioner. Exactly one of 'scriptUri'
    /// or 'inline' can be specified.
    /// </summary>
    public partial class ImageTemplateShellCustomizer :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateShellCustomizer,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateShellCustomizerInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer __imageTemplateCustomizer = new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateCustomizer();

        /// <summary>Backing field for <see cref="Inline" /> property.</summary>
        private string[] _inline;

        /// <summary>Array of shell commands to execute</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string[] Inline { get => this._inline; set => this._inline = value; }

        /// <summary>Friendly Name to provide context on what this customization step does</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Name = value ?? null; }

        /// <summary>Backing field for <see cref="ScriptUri" /> property.</summary>
        private string _scriptUri;

        /// <summary>
        /// URI of the shell script to be run for customizing. It can be a github link, SAS URI for Azure Storage, etc
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string ScriptUri { get => this._scriptUri; set => this._scriptUri = value; }

        /// <summary>Backing field for <see cref="Sha256Checksum" /> property.</summary>
        private string _sha256Checksum;

        /// <summary>SHA256 checksum of the shell script provided in the scriptUri field</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string Sha256Checksum { get => this._sha256Checksum; set => this._sha256Checksum = value; }

        /// <summary>
        /// The type of customization tool you want to use on the Image. For example, "Shell" can be shell customizer
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Type = value ; }

        /// <summary>Creates an new <see cref="ImageTemplateShellCustomizer" /> instance.</summary>
        public ImageTemplateShellCustomizer()
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
    /// Runs a shell script during the customization phase (Linux). Corresponds to Packer shell provisioner. Exactly one of 'scriptUri'
    /// or 'inline' can be specified.
    public partial interface IImageTemplateShellCustomizer :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer
    {
        /// <summary>Array of shell commands to execute</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of shell commands to execute",
        SerializedName = @"inline",
        PossibleTypes = new [] { typeof(string) })]
        string[] Inline { get; set; }
        /// <summary>
        /// URI of the shell script to be run for customizing. It can be a github link, SAS URI for Azure Storage, etc
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URI of the shell script to be run for customizing. It can be a github link, SAS URI for Azure Storage, etc",
        SerializedName = @"scriptUri",
        PossibleTypes = new [] { typeof(string) })]
        string ScriptUri { get; set; }
        /// <summary>SHA256 checksum of the shell script provided in the scriptUri field</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SHA256 checksum of the shell script provided in the scriptUri field",
        SerializedName = @"sha256Checksum",
        PossibleTypes = new [] { typeof(string) })]
        string Sha256Checksum { get; set; }

    }
    /// Runs a shell script during the customization phase (Linux). Corresponds to Packer shell provisioner. Exactly one of 'scriptUri'
    /// or 'inline' can be specified.
    public partial interface IImageTemplateShellCustomizerInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal
    {
        /// <summary>Array of shell commands to execute</summary>
        string[] Inline { get; set; }
        /// <summary>
        /// URI of the shell script to be run for customizing. It can be a github link, SAS URI for Azure Storage, etc
        /// </summary>
        string ScriptUri { get; set; }
        /// <summary>SHA256 checksum of the shell script provided in the scriptUri field</summary>
        string Sha256Checksum { get; set; }

    }
}