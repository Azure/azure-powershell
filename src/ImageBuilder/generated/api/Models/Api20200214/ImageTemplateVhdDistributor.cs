namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Distribute via VHD in a storage account.</summary>
    public partial class ImageTemplateVhdDistributor :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVhdDistributor,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVhdDistributorInternal,
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

        /// <summary>The name to be used for the associated RunOutput.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string RunOutputName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributorInternal)__imageTemplateDistributor).RunOutputName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributorInternal)__imageTemplateDistributor).RunOutputName = value ; }

        /// <summary>Type of distribution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributorInternal)__imageTemplateDistributor).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributorInternal)__imageTemplateDistributor).Type = value ; }

        /// <summary>Creates an new <see cref="ImageTemplateVhdDistributor" /> instance.</summary>
        public ImageTemplateVhdDistributor()
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
    /// Distribute via VHD in a storage account.
    public partial interface IImageTemplateVhdDistributor :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor
    {

    }
    /// Distribute via VHD in a storage account.
    public partial interface IImageTemplateVhdDistributorInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributorInternal
    {

    }
}