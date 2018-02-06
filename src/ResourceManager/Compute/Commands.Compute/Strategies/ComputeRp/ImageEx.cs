using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Common.Strategies.Compute;
using Microsoft.Azure.Commands.Compute.Properties;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
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
                    throw new InvalidOperationException(
                        string.Format(Resources.InvalidImageName, imageName));
                }
                var image = new ImageReference
                {
                    Publisher = imageArray[0],
                    Offer = imageArray[1],
                    Sku = imageArray[2],
                    Version = imageArray[3],
                };
                var compute = client.GetClient<ComputeManagementClient>();
                if (image.Version.ToLower() == "latest")
                {
                    var images = await compute.VirtualMachineImages.ListAsync(
                        location, image.Publisher, image.Offer, image.Sku);
                    // According to Compute API: 
                    // "The allowed formats are Major.Minor.Build or 'latest'. 
                    //  Major, Minor, and Build are decimal numbers."
                    image.Version = images
                        .Select(i => ImageVersion.Parse(i.Name))
                        .Aggregate((a, b) => a.CompareTo(b) < 0 ? b : a)
                        .ToString();
                }
                var imageModel = await compute.VirtualMachineImages.GetAsync(
                    location, image.Publisher, image.Offer, image.Sku, image.Version);
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
