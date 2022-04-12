namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSSharedGalleryImageVersionList : PSSharedGalleryImageVersion
    {
        public PSSharedGalleryImageVersion ToPSSharedGalleryImageVersion()
        {
            return ComputeAutomationAutoMapperProfile.Mapper.Map<PSSharedGalleryImageVersion>(this);
        }
    }
}
