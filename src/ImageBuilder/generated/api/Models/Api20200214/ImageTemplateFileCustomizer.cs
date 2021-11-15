namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Uploads files to VMs (Linux, Windows). Corresponds to Packer file provisioner</summary>
    public partial class ImageTemplateFileCustomizer :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateFileCustomizer,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateFileCustomizerInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer __imageTemplateCustomizer = new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateCustomizer();

        /// <summary>Backing field for <see cref="Destination" /> property.</summary>
        private string _destination;

        /// <summary>
        /// The absolute path to a file (with nested directory structures already created) where the file (from sourceUri) will be
        /// uploaded to in the VM
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string Destination { get => this._destination; set => this._destination = value; }

        /// <summary>Friendly Name to provide context on what this customization step does</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Name = value ?? null; }

        /// <summary>Backing field for <see cref="Sha256Checksum" /> property.</summary>
        private string _sha256Checksum;

        /// <summary>SHA256 checksum of the file provided in the sourceUri field above</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string Sha256Checksum { get => this._sha256Checksum; set => this._sha256Checksum = value; }

        /// <summary>Backing field for <see cref="SourceUri" /> property.</summary>
        private string _sourceUri;

        /// <summary>
        /// The URI of the file to be uploaded for customizing the VM. It can be a github link, SAS URI for Azure Storage, etc
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string SourceUri { get => this._sourceUri; set => this._sourceUri = value; }

        /// <summary>
        /// The type of customization tool you want to use on the Image. For example, "Shell" can be shell customizer
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal)__imageTemplateCustomizer).Type = value ; }

        /// <summary>Creates an new <see cref="ImageTemplateFileCustomizer" /> instance.</summary>
        public ImageTemplateFileCustomizer()
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
    /// Uploads files to VMs (Linux, Windows). Corresponds to Packer file provisioner
    public partial interface IImageTemplateFileCustomizer :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer
    {
        /// <summary>
        /// The absolute path to a file (with nested directory structures already created) where the file (from sourceUri) will be
        /// uploaded to in the VM
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The absolute path to a file (with nested directory structures already created) where the file (from sourceUri) will be uploaded to in the VM",
        SerializedName = @"destination",
        PossibleTypes = new [] { typeof(string) })]
        string Destination { get; set; }
        /// <summary>SHA256 checksum of the file provided in the sourceUri field above</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SHA256 checksum of the file provided in the sourceUri field above",
        SerializedName = @"sha256Checksum",
        PossibleTypes = new [] { typeof(string) })]
        string Sha256Checksum { get; set; }
        /// <summary>
        /// The URI of the file to be uploaded for customizing the VM. It can be a github link, SAS URI for Azure Storage, etc
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URI of the file to be uploaded for customizing the VM. It can be a github link, SAS URI for Azure Storage, etc",
        SerializedName = @"sourceUri",
        PossibleTypes = new [] { typeof(string) })]
        string SourceUri { get; set; }

    }
    /// Uploads files to VMs (Linux, Windows). Corresponds to Packer file provisioner
    public partial interface IImageTemplateFileCustomizerInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizerInternal
    {
        /// <summary>
        /// The absolute path to a file (with nested directory structures already created) where the file (from sourceUri) will be
        /// uploaded to in the VM
        /// </summary>
        string Destination { get; set; }
        /// <summary>SHA256 checksum of the file provided in the sourceUri field above</summary>
        string Sha256Checksum { get; set; }
        /// <summary>
        /// The URI of the file to be uploaded for customizing the VM. It can be a github link, SAS URI for Azure Storage, etc
        /// </summary>
        string SourceUri { get; set; }

    }
}