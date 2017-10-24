namespace Azure.Experiments
{
    public sealed class DependencyLocation
    {
        public static DependencyLocation None { get; }
            = new DependencyLocation(null, 0);

        public string Location { get; }

        public int Priority { get; }

        public DependencyLocation(string location, int priority)
        {
            Location = location;
            Priority = priority;
        }
    }
}
