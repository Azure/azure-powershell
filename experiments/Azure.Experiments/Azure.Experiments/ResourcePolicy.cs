using System;

namespace Microsoft.Azure.Experiments
{
    public static class ResourcePolicy
    {
        public static ResourcePolicy<Info> CreateResourcePolicy<Client, Info>(
            this OperationsPolicy<Client, Info> operationsPolicy,
            Func<Info, string> getLocation,
            Action<Info, string> setLocation)
            where Client : class, IDisposable
            where Info : class
            => new ResourcePolicy<Info>(
                operationsPolicy.Transform<IClient>(c => c.GetClient<Client>()),
                getLocation,
                setLocation);
    }

    public sealed class ResourcePolicy<Info>
        where Info : class
    {
        public OperationsPolicy<IClient, Info> Operations { get; }

        public Func<Info, string> GetLocation { get; }

        public Action<Info, string> SetLocation { get; }

        public ResourcePolicy(            
            OperationsPolicy<IClient, Info> operations,
            Func<Info, string> getLocation,
            Action<Info, string> setLocation)
        {
            Operations = operations;
            GetLocation = getLocation;
            SetLocation = setLocation;
        }
    }
}
