// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Common.Strategies.Compute;
using Microsoft.Azure.PowerShell.Cmdlets.Compute;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Support;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    static class ImageEx
    {
        public static int[] UpdatePorts(this ImageAndOsType imageAndOsType, int[] ports)
            => ports ?? imageAndOsType?.OsType.CreatePorts();

        private static int[] CreatePorts(this OperatingSystemTypes osType)
            => osType == OperatingSystemTypes.Windows ? new[] { 3389, 5985 }
                : osType == OperatingSystemTypes.Linux ? new[] { 22 }
                : null;

        public static async Task<ImageAndOsType> UpdateImageAndOsTypeAsync(
            this IClient client,
            ImageAndOsType imageAndOsType,
            string resourceGroupName,
            string imageName,
            string location)
        {
            if (imageAndOsType != null)
            {
                return imageAndOsType;
            }

            var compute = client.GetClient<ComputeManagementClient>();

            if (imageName.Contains(':'))
            {
                if (location == null)
                {
                    return null;
                }

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

                if (image.Version.ToLower() == "latest")
                {
                    Task<IVirtualMachineImageResource[]> imagesTask = null;
                        await compute.VirtualMachineImagesList(
                        location, image.Publisher, image.Offer, image.Sku, "*", null, "Publisher", null, "subscriptionId", 
                        (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out imagesTask), null, null);
                    var images = (await imagesTask).Select(i => i as VirtualMachineImageResource);
                    // According to Compute API: 
                    // "The allowed formats are Major.Minor.Build or 'latest'. 
                    //  Major, Minor, and Build are decimal numbers."
                    image.Version = images
                        .Select(i => ImageVersion.Parse(i.Name))
                        .Aggregate((a, b) => a.CompareTo(b) < 0 ? b : a)
                        .ToString();
                }
                Task<IVirtualMachineImage> imageTask = null;
                await compute.VirtualMachineImagesGet(
                    location, image.Publisher, image.Offer, image.Sku, image.Version, "subscriptionId",
                    (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out imageTask), null, null);
                var imageModel = ((await imageTask) as VirtualMachineImage);
                 return new ImageAndOsType(
                    imageModel.OSDiskImageOperatingSystem,
                    image,
                    imageModel.DataDiskImage.Where(d => d.Lun.HasValue).Select(d => d.Lun.Value).ToList());
            } 
            else if (imageName.Contains("/"))
            {
                var resourceId = ResourceId.TryParse(imageName);
                if (resourceId == null
                    || resourceId.ResourceType.Namespace != ComputeStrategy.Namespace
                    || ( resourceId.ResourceType.Provider != "images")
                       && resourceId.ResourceType.Provider != "galleries")
                {
                    throw new ArgumentException(string.Format(Resources.ComputeInvalidImageName, imageName));
                }

                if ("subscriptionId" != resourceId.SubscriptionId)
                {
                    throw new ArgumentException(Resources.ComputeMismatchSubscription);
                }

                if (resourceId.ResourceType.Provider == "galleries")
                {
                    return await compute.GetGalleryImageAndOsTypeAsync(resourceId.ResourceGroupName, imageName);
                }
                else
                {
                    return await compute.GetImageAndOsTypeAsync(resourceId.ResourceGroupName, resourceId.Name);
                }
            }
            else
            {
                try
                {
                    return await compute.GetImageAndOsTypeAsync(resourceGroupName, imageName);
                }
                catch
                {
                }

                // get generic image
                var result = Images
                    .Instance
                    .SelectMany(osAndMap => osAndMap
                        .Value
                        .Where(nameAndImage => nameAndImage.Key.ToLower() == imageName.ToLower())
                        .Select(nameAndImage => new ImageAndOsType(
                            osAndMap.Key == "Windows" 
                                ? OperatingSystemTypes.Windows
                                : OperatingSystemTypes.Linux,
                            nameAndImage.Value,
                            null)))
                    .FirstOrDefault();

                if (result == null)
                {
                    throw new ArgumentException(string.Format(Resources.ComputeNoImageFound, imageName));
                }

                return result;
            }
        }

        static async Task<ImageAndOsType> GetImageAndOsTypeAsync(
            this ComputeManagementClient compute, string resourceGroupName, string name)
        {
            Task<IImage> imageTask= null;
            await compute.ImagesGet(resourceGroupName, name, string.Empty, "subscriptionId", 
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out imageTask), null, null);
            var localImage = await imageTask;
            return new ImageAndOsType(
                localImage.OSDiskOstype,
                new ImageReference { Id = localImage.Id },
                localImage.StorageProfileDataDisk.Select(d => d.Lun).ToList());
        }

        static async Task<ImageAndOsType> GetGalleryImageAndOsTypeAsync(
            this ComputeManagementClient compute, string resourceGroupName, string resourceId)
        {
            ImageReference imageRef = null;
            var versionPresent = (resourceId.IndexOf(VERSION_STRING, StringComparison.InvariantCultureIgnoreCase) >= 0);
            if (versionPresent)
            {
                Task<PowerShell.Cmdlets.Compute.Models.Api20190301.IGalleryImageVersion> localVersionTask = null;
                await compute.GalleryImageVersionsGet("subscriptionId", 
                    resourceGroupName, GetGaleryName(resourceId), GetImageName(resourceId), GetImageVersion(resourceId), ReplicationStatusTypes.ReplicationStatus, 
                    (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out localVersionTask),  null, null, null);
                var localImageVersion = await localVersionTask;
                imageRef = new ImageReference { Id = localImageVersion.Id };
            }

            Task<PowerShell.Cmdlets.Compute.Models.Api20190301.IGalleryImage> localImageTask = null;

            await compute.GalleryImagesGet("subscriptionId", resourceGroupName, GetGaleryName(resourceId), GetImageName(resourceId), 
                (response, creator) => ComputeApiHelpers.DeserializeEntity(response, creator, out localImageTask), null, null, null);
            var localImage = await localImageTask;
            if (imageRef == null)
            {
                imageRef = new ImageReference { Id = localImage.Id };
            }

            return new ImageAndOsType(
                localImage.OSType,
                imageRef,
                null);
        }

        const string RESOURCE_NAME_STRING = "Microsoft.Compute/Galleries";
        const string INSTANCE_NAME_STRING = "Images";
        const string VERSION_STRING = "Versions";

        //Added the following two fuinctions from https://github.com/Azure/azure-powershell/blob/master/src/Compute/Compute/Generated/ComputeAutomationBaseCmdlet.cs#L319
        //To be able to get the gallery name and gallery image name from the provided gallery image reaource ID.
        static string GetGaleryName(string resourceId)
        {
            if (string.IsNullOrEmpty(resourceId)) { return null; }
            Regex r = new Regex(@"(.*?)/" + RESOURCE_NAME_STRING + @"/(?<rgname>\S+)/" + INSTANCE_NAME_STRING + @"/(?<instanceId>\S+)", RegexOptions.IgnoreCase);
            Match m = r.Match(resourceId);
            return m.Success ? m.Groups["rgname"].Value : null;
        }

        static string GetImageName(string resourceId)
        {
            var versionPresent = (resourceId.IndexOf(VERSION_STRING, StringComparison.InvariantCultureIgnoreCase) >= 0);
            if (string.IsNullOrEmpty(resourceId)) { return null; }
            Regex r = (versionPresent)
                    ? new Regex(@"(.*?)/" + RESOURCE_NAME_STRING + @"/(?<rgname>\S+)/" + INSTANCE_NAME_STRING + @"/(?<instanceId>\S+)/" + VERSION_STRING + @"/(?<version>\S+)", RegexOptions.IgnoreCase)
                    : new Regex(@"(.*?)/" + RESOURCE_NAME_STRING + @"/(?<rgname>\S+)/" + INSTANCE_NAME_STRING + @"/(?<instanceId>\S+)", RegexOptions.IgnoreCase);
            Match m = r.Match(resourceId);
            return m.Success ? m.Groups["instanceId"].Value : null;
        }

        static string GetImageVersion(string resourceId)
        {
            if (string.IsNullOrEmpty(resourceId)) { return null; }
            Regex r = new Regex(@"(.*?)/" + RESOURCE_NAME_STRING + @"/(?<rgname>\S+)/" + INSTANCE_NAME_STRING + @"/(?<instanceId>\S+)/" + VERSION_STRING + @"/(?<version>\S+)", RegexOptions.IgnoreCase);
            Match m = r.Match(resourceId);
            return m.Success ? m.Groups["version"].Value : null;
        }
    }
}
