namespace Microsoft.Azure.Experiments
{
    public static class LocationExtensions
    {
        public static Location Merge(this Location a, Location b)
        {
            if (a == null)
            {
                return b;
            }
            if (b == null)
            {
                return a;
            }

            if (a.IsCommon != b.IsCommon)
            {
                return a.IsCommon ? b : a;
            }

            return a.Name == b.Name ? a : new Location(a.IsCommon, null);
        }
    }
}
