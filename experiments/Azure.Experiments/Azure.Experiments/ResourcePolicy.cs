using System;

namespace Microsoft.Azure.Experiments
{
    public static class ResourcePolicy
    {
        public static ResourcePolicy<Client, Name, Info> CreateResourcePolicy<Client, Name, Info>(
            this OperationsPolicy<Client, Name, Info> operationsPolicy,
            Func<Info, string> getLocation,
            Action<Info, string> setLocation)
            where Info : class
            => new ResourcePolicy<Client, Name, Info>(operationsPolicy, getLocation, setLocation);
    }

    public sealed class ResourcePolicy<Client, Name, Info>
        where Info : class
    {
        public OperationsPolicy<Client, Name, Info> OperationsPolicy { get; }

        public Func<Info, string> GetLocation { get; }

        public Action<Info, string> SetLocation { get; }

        public ResourcePolicy(            
            OperationsPolicy<Client, Name, Info> operationsPolicy,
            Func<Info, string> getLocation,
            Action<Info, string> setLocation)
        {
            OperationsPolicy = operationsPolicy;
            GetLocation = getLocation;
            SetLocation = setLocation;
        }
    }
}
