namespace Microsoft.Azure.Commands.Synapse.Models
{
    public abstract class PSSynapseResource
    {
        public PSSynapseResource(string id = default(string), string name = default(string), string type = default(string))
        {
            Id = id;
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Gets fully qualified resource Id for the resource. Ex -
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        public virtual string Id { get; protected set; }

        /// <summary>
        /// Gets the name of the resource
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Gets the type of the resource. Ex-
        /// Microsoft.Compute/virtualMachines or
        /// Microsoft.Storage/storageAccounts.
        /// </summary>
        public string Type { get; private set; }
    }
}
