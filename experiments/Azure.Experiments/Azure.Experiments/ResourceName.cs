namespace Microsoft.Azure.Experiments
{
    public sealed class ResourceName
    {
        public string ResourceGroupName { get; }
        public string Name { get; }

        public ResourceName(string resourceGroupName, string name)
        {
            ResourceGroupName = resourceGroupName;
            Name = name;
        }
    }
}
