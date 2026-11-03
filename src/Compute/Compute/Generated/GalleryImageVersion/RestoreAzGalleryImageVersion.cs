using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsData.Restore, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "GalleryImageVersion", SupportsShouldProcess = true)]
    [OutputType(typeof(PSGalleryImageVersion))]
    public class RestoreAzGalleryImageVersion : ComputeAutomationBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.Name, VerbsData.Restore))
                {
                    var galleryImageVersion = new GalleryImageVersion
                    {
                        Location = this.Location,
                        Restore = true
                    };
                    var result = GalleryImageVersionsClient.CreateOrUpdate(
                        this.ResourceGroupName,
                        this.GalleryName,
                        this.GalleryImageDefinitionName,
                        this.Name,
                        galleryImageVersion);
                    var output = new PSGalleryImageVersion();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<GalleryImageVersion, PSGalleryImageVersion>(result, output);
                    WriteObject(output);
                }
            });
        }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string GalleryName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("GalleryImageName")]
        public string GalleryImageDefinitionName { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("GalleryImageVersionName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [LocationCompleter("Microsoft.Compute/Galleries")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
    }
}
