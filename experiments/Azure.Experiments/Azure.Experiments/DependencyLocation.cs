namespace Azure.Experiments
{
    public sealed class DependencyLocation
    {
        public string Location { get; }

        public int Priority { get; }

        public DependencyLocation(string location, int priority)
        {
            Location = location;
            Priority = priority;
        }
    }
}
