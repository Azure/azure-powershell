namespace Microsoft.Azure.Experiments
{
    /// <summary>
    /// null is no prefered location
    /// { IsCommon = ...; Name = null } is a location conflict.
    /// </summary>
    public sealed class Location
    {
        public bool IsCommon { get; }

        public string Name { get; }

        public Location(bool isCommon, string name)
        {
            IsCommon = isCommon;
            Name = name;
        }
    }
}
