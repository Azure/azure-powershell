namespace Microsoft.Azure.Experiments
{
    public sealed class ResourceGroupParameters : Parameters
    {
        public ResourceGroupParameters(string name) : base(name, NoDependencies)
        {
        }
    }
}
