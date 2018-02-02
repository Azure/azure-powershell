using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Strategies.Compute
{
    sealed class ImageAndOsType
    {
        public bool IsWindows { get; }

        public ImageReference Image { get; }

        public ImageAndOsType(bool isWindows, ImageReference image)
        {
            IsWindows = isWindows;
            Image = image;
        }
    }
}
