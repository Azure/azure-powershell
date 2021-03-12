namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Distribute via Shared Image Gallery.</summary>
    public partial class ImageTemplateSharedImageDistributor :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSharedImageDistributor,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSharedImageDistributorInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor __imageTemplateDistributor = new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateDistributor();

        /// <summary>
        /// Tags that will be applied to the artifact once it has been created/updated by the distributor.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributorArtifactTags ArtifactTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributorInternal)__imageTemplateDistributor).ArtifactTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributorInternal)__imageTemplateDistributor).ArtifactTag = value ?? null /* model class */; }

        /// <summary>Backing field for <see cref="ExcludeFromLatest" /> property.</summary>
        private bool? _excludeFromLatest;

        /// <summary>
        /// Flag that indicates whether created image version should be excluded from latest. Omit to use the default (false).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public bool? ExcludeFromLatest { get => this._excludeFromLatest; set => this._excludeFromLatest = value; }

        /// <summary>Backing field for <see cref="GalleryImageId" /> property.</summary>
        private string _galleryImageId;

        /// <summary>Resource Id of the Shared Image Gallery image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string GalleryImageId { get => this._galleryImageId; set => this._galleryImageId = value; }

        /// <summary>Backing field for <see cref="ReplicationRegion" /> property.</summary>
        private string[] _replicationRegion;

        /// <summary>A list of regions that the image will be replicated to</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string[] ReplicationRegion { get => this._replicationRegion; set => this._replicationRegion = value; }

        /// <summary>The name to be used for the associated RunOutput.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string RunOutputName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributorInternal)__imageTemplateDistributor).RunOutputName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributorInternal)__imageTemplateDistributor).RunOutputName = value ; }

        /// <summary>Backing field for <see cref="StorageAccountType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.SharedImageStorageAccountType? _storageAccountType;

        /// <summary>
        /// Storage account type to be used to store the shared image. Omit to use the default (Standard_LRS).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.SharedImageStorageAccountType? StorageAccountType { get => this._storageAccountType; set => this._storageAccountType = value; }

        /// <summary>Type of distribution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributorInternal)__imageTemplateDistributor).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributorInternal)__imageTemplateDistributor).Type = value ; }

        /// <summary>Creates an new <see cref="ImageTemplateSharedImageDistributor" /> instance.</summary>
        public ImageTemplateSharedImageDistributor()
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
            await eventListener.AssertNotNull(nameof(__imageTemplateDistributor), __imageTemplateDistributor);
            await eventListener.AssertObjectIsValid(nameof(__imageTemplateDistributor), __imageTemplateDistributor);
        }
    }
    /// Distribute via Shared Image Gallery.
    public partial interface IImageTemplateSharedImageDistributor :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor
    {
        /// <summary>
        /// Flag that indicates whether created image version should be excluded from latest. Omit to use the default (false).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag that indicates whether created image version should be excluded from latest. Omit to use the default (false).",
        SerializedName = @"excludeFromLatest",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ExcludeFromLatest { get; set; }
        /// <summary>Resource Id of the Shared Image Gallery image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Resource Id of the Shared Image Gallery image",
        SerializedName = @"galleryImageId",
        PossibleTypes = new [] { typeof(string) })]
        string GalleryImageId { get; set; }
        /// <summary>A list of regions that the image will be replicated to</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A list of regions that the image will be replicated to",
        SerializedName = @"replicationRegions",
        PossibleTypes = new [] { typeof(string) })]
        string[] ReplicationRegion { get; set; }
        /// <summary>
        /// Storage account type to be used to store the shared image. Omit to use the default (Standard_LRS).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Storage account type to be used to store the shared image. Omit to use the default (Standard_LRS).",
        SerializedName = @"storageAccountType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.SharedImageStorageAccountType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.SharedImageStorageAccountType? StorageAccountType { get; set; }

    }
    /// Distribute via Shared Image Gallery.
    public partial interface IImageTemplateSharedImageDistributorInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributorInternal
    {
        /// <summary>
        /// Flag that indicates whether created image version should be excluded from latest. Omit to use the default (false).
        /// </summary>
        bool? ExcludeFromLatest { get; set; }
        /// <summary>Resource Id of the Shared Image Gallery image</summary>
        string GalleryImageId { get; set; }
        /// <summary>A list of regions that the image will be replicated to</summary>
        string[] ReplicationRegion { get; set; }
        /// <summary>
        /// Storage account type to be used to store the shared image. Omit to use the default (Standard_LRS).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.SharedImageStorageAccountType? StorageAccountType { get; set; }

    }
}