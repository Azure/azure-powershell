namespace Microsoft.Azure.Commands.Compute.Strategies.Compute
{
    sealed class ImageAndOsType
    {
        public bool IsWindows { get; }

        public Image Image { get; }

        public ImageAndOsType(bool isWindows, Image image)
        {
            IsWindows = isWindows;
            Image = image;
        }
    }
}
