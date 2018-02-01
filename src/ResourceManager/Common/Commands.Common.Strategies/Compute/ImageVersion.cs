using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies.Compute
{
    public sealed class ImageVersion
    {
        public string Original { get; }

        public ulong[] Parts { get; }

        ImageVersion(string original, ulong[] parts)
        {
            Original = original;
            Parts = parts;
        }

        public int CompareTo(ImageVersion version)
        {
            var sign = Parts
                .Zip(version.Parts, (a, b) => a.CompareTo(b))
                .FirstOrDefault(s => s != 0);
            return sign == 0 ? Parts.Length.CompareTo(version.Parts.Length) : sign;
        }

        public static ImageVersion Parse(string version)
            => new ImageVersion(version, version.Split('.').Select(ulong.Parse).ToArray());

        public override string ToString()
            => Original;
    }
}
