namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSSharedGalleryImageList : PSSharedGalleryImage
    {
        public PSSharedGalleryImage ToPSSharedGalleryImage()
        {
            return ComputeAutomationAutoMapperProfile.Mapper.Map<PSSharedGalleryImage>(this);
        }
    }
}
