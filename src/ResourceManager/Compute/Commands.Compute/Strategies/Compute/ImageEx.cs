using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Common.Strategies.Compute;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies.Compute
{
    static class ImageEx
    {
        public static async Task<ImageAndOsType> UpdateImageAndOsTypeAsync(
            this IClient client, string imageName, string location)
        {
            if (imageName.Contains(':'))
            {
                var imageArray = imageName.Split(':');
                if (imageArray.Length != 4)
                {
                    throw new InvalidOperationException("Invalid ImageName");
                }
                var image = new Image
                {
                    publisher = imageArray[0],
                    offer = imageArray[1],
                    sku = imageArray[2],
                    version = imageArray[3],
                };
                var compute = client.GetClient<ComputeManagementClient>();
                if (image.version.ToLower() == "latest")
                {
                    var images = await compute.VirtualMachineImages.ListAsync(
                        location, image.publisher, image.offer, image.sku);
                    // According to Compute API: 
                    // "The allowed formats are Major.Minor.Build or 'latest'. 
                    //  Major, Minor, and Build are decimal numbers."
                    image.version = images
                        .Select(i => ImageVersion.Parse(i.Name))
                                                .Aggregate((a, b) => a.CompareTo(b) < 0 ? b : a)
                                                .ToString();
                }
                var imageModel = await compute.VirtualMachineImages.GetAsync(
                    location, image.publisher, image.offer, image.sku, image.version);
                return new ImageAndOsType(
                    imageModel.OsDiskImage.OperatingSystem == OperatingSystemTypes.Windows,
                    image);
            }
            else
            {
                // get image
                return Images
                    .Instance
                    .SelectMany(osAndMap => osAndMap
                        .Value
                        .Where(nameAndImage => nameAndImage.Key.ToLower() == imageName.ToLower())
                        .Select(nameAndImage => new ImageAndOsType(
                            osAndMap.Key == "Windows",
                            nameAndImage.Value)))
                    .FirstOrDefault();
            }
        }
    }
}
