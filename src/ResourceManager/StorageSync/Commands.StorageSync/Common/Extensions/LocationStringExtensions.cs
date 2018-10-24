using System.Text;

namespace Microsoft.Azure.Commands.StorageSync.Common.Extensions
{
    public static class LocationStringExtensions
    {
        public static string Canonicalize(this string location)
        {
            if (!string.IsNullOrEmpty(location))
            {
                StringBuilder sb = new StringBuilder();
                foreach (char ch in location)
                {
                    if (!char.IsWhiteSpace(ch))
                    {
                        sb.Append(ch);
                    }
                }

                location = sb.ToString().ToLower();
            }

            return location;
        }
    }
}
