using System;

namespace Microsoft.Azure.Experiments
{
    public static class ResourcePolicy
    {
        public static ResourcePolicy<Name, Info> CreateResourcePolicy<Client, Name, Info>(
            this OperationsPolicy<Client, Name, Info> operationsPolicy,
            Func<Info, string> getLocation,
            Action<Info, string> setLocation)
            where Client : class, IDisposable
            where Info : class
            => new ResourcePolicy<Name, Info>(
                operationsPolicy.Transform<IClient>(c => c.GetClient<Client>()),
                getLocation,
                setLocation);
    }

    public sealed class ResourcePolicy<Name, Info>
        where Info : class
    {
        public OperationsPolicy<IClient, Name, Info> OperationsPolicy { get; }

        public Func<Info, string> GetLocation { get; }

        public Action<Info, string> SetLocation { get; }

        public ResourcePolicy(            
            OperationsPolicy<IClient, Name, Info> operationsPolicy,
            Func<Info, string> getLocation,
            Action<Info, string> setLocation)
        {
            OperationsPolicy = operationsPolicy;
            GetLocation = getLocation;
            SetLocation = setLocation;
        }
    }
}
