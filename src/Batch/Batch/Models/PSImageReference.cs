using Microsoft.Azure.Management.Batch.Models;
using System;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSImageReference
    {
        public override string ToString()
        {
            if (string.IsNullOrEmpty(VirtualMachineImageId))
            {
                return $"{Publisher}:{Offer}:{Sku}:{Version}";
            }
            else
            {
                return VirtualMachineImageId;
            }
        }

        internal ImageReference toMgmtImageReference()
        {
            return new ImageReference
            {
                Publisher = this.Publisher,
                Offer = this.Offer,
                Sku = this.Sku,
                Version = this.Version,
                Id = this.VirtualMachineImageId,
                CommunityGalleryImageId = this.CommunityGalleryImageId,
                SharedGalleryImageId = this.SharedGalleryImageId
            };
        }

        internal static PSImageReference fromMgmtImageReference(ImageReference imageReference)
        {
            if (imageReference == null)
            {
                return null;
            }
            return new PSImageReference
            {
                Publisher = imageReference.Publisher,
                Offer = imageReference.Offer,
                Sku = imageReference.Sku,
                Version = imageReference.Version,
                VirtualMachineImageId = imageReference.Id,
                CommunityGalleryImageId = imageReference.CommunityGalleryImageId,
                SharedGalleryImageId = imageReference.SharedGalleryImageId
            };
        }
    }
}
