namespace Microsoft.Azure.Experiments
{
    public sealed class DependencyLocation
    {
        public string Location { get; }

        public bool IsCommon { get; }

        public DependencyLocation(string location, bool isCommon)
        {
            Location = location;
            IsCommon = isCommon;
        }
    }
}
