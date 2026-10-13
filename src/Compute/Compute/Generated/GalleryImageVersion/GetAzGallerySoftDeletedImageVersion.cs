using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "GallerySoftDeletedImageVersion", DefaultParameterSetName = "DefaultParameter")]
    [OutputType(typeof(PSGallerySoftDeletedImageVersion))]
    public class GetAzGallerySoftDeletedImageVersion : ComputeAutomationBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName;
                string galleryName;
                string galleryImageDefinitionName;

                switch (this.ParameterSetName)
                {
                    case "ResourceIdParameter":
                        resourceGroupName = GetResourceGroupName(this.GalleryImageDefinitionResourceId);
                        galleryName = GetResourceName(this.GalleryImageDefinitionResourceId, "Microsoft.Compute/galleries");
                        galleryImageDefinitionName = GetImageNameFromId(this.GalleryImageDefinitionResourceId);
                        break;
                    case "ObjectParameter":
                        resourceGroupName = GetResourceGroupName(this.InputObject.Id);
                        galleryName = GetResourceName(this.InputObject.Id, "Microsoft.Compute/galleries");
                        galleryImageDefinitionName = GetImageNameFromId(this.InputObject.Id);
                        break;
                    default:
                        resourceGroupName = this.ResourceGroupName;
                        galleryName = this.GalleryName;
                        galleryImageDefinitionName = this.GalleryImageDefinitionName;
                        break;
                }

                var client = ComputeClient.ComputeManagementClient.SoftDeletedResource;
                var page = client.ListByArtifactName(resourceGroupName, galleryName, "Images", galleryImageDefinitionName);
                var resources = page.ToList();
                var nextPageLink = page.NextPageLink;
                while (!string.IsNullOrEmpty(nextPageLink))
                {
                    page = client.ListByArtifactNameNext(nextPageLink);
                    resources.AddRange(page);
                    nextPageLink = page.NextPageLink;
                }

                foreach (var resource in resources)
                {
                    if (this.IsParameterBound(c => c.Name)
                        && !string.Equals(resource.Name, this.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    WriteObject(new PSGallerySoftDeletedImageVersion
                    {
                        Id = resource.Id,
                        Name = resource.Name,
                        Type = resource.Type,
                        Location = resource.Location,
                        Tags = resource.Tags,
                        SoftDeletedTime = resource.SoftDeletedTime,
                        ConsumptionEndTime = resource.ConsumptionEndTime,
                        HardDeletionTargetTime = resource.HardDeletionTargetTime
                    });
                }
            });
        }

        private static string GetImageNameFromId(string resourceId)
        {
            return GetInstanceId(resourceId, "Microsoft.Compute/galleries", "images", "versions");
        }

        [Parameter(ParameterSetName = "DefaultParameter", Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = "DefaultParameter", Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string GalleryName { get; set; }

        [Parameter(ParameterSetName = "DefaultParameter", Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("GalleryImageName")]
        public string GalleryImageDefinitionName { get; set; }

        [Parameter(ParameterSetName = "DefaultParameter", Position = 3, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "ResourceIdParameter", ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "ObjectParameter", ValueFromPipelineByPropertyName = true)]
        [Alias("GalleryImageVersionName")]
        public string Name { get; set; }

        [Parameter(ParameterSetName = "ResourceIdParameter", Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string GalleryImageDefinitionResourceId { get; set; }

        [Parameter(ParameterSetName = "ObjectParameter", Position = 0, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSGalleryImage InputObject { get; set; }
    }
}
