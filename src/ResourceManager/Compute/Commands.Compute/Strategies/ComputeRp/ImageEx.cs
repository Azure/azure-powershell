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
                return new ImageAndOsType(imageModel.OsDiskImage.OperatingSystem, image);
            }
            if (imageName.Contains("/"))
            {
                var imageArray = imageName.Split('/');
                if (imageArray.Length != 9)
                {
                    throw new ArgumentException("Invalid image resource id  '" + imageName + "'.");
                }
                // has to be ""
                var empty = imageArray[0];
                // has to be "subscriptions"
                var subscriptions = imageArray[1];
                var subscriptionId = imageArray[2];
                // has to be "resourceGroups"
                var resourceGroups = imageArray[3];
                var imageResourceGroupName = imageArray[4];
                // has to be "providers"
                var providers = imageArray[5];
                // has to be "Microsoft."
                var providerNamespace = imageArray[6];
                // has to be "image" 
                var provider = imageArray[7];
                var resourceName = imageArray[8];

                if (empty != string.Empty
                    || subscriptions != SdkEngine.Subscriptions
                    || resourceGroups != ResourceType.ResourceGroups
                    || providers != EntityConfigExtensions.Providers
                    || providerNamespace != ComputeStrategy.Namespace
                    || provider != "images")
                {
                    throw new ArgumentException("Invalid image resource id '" + imageName + "'.");
                }

                if (compute.SubscriptionId != subscriptionId)
                {
                    throw new ArgumentException("The image subscription doesn't match the current subscription.");
                }

                var localImage = await compute.Images.GetAsync(imageResourceGroupName, resourceName);

                return new ImageAndOsType(
                    localImage.StorageProfile.OsDisk.OsType,
                    new ImageReference { Id = localImage.Id });
            }
            else
            {
                try
                {
                    var localImage = await compute.Images.GetAsync(resourceGroupName, imageName);
                    return new ImageAndOsType(
                        localImage.StorageProfile.OsDisk.OsType,
                        new ImageReference { Id = localImage.Id });
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
                            nameAndImage.Value)))
                    .FirstOrDefault();

                if (result == null)
                {
                    // TODO: move it to resource.
                    throw new ArgumentException("Can't find the image '" + imageName + "'");
                }

                return result;
            }
        }
    }
}
