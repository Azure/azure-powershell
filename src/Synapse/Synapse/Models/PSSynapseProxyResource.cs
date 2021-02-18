namespace Microsoft.Azure.Commands.Synapse.Models
{
    public abstract class PSSynapseProxyResource : PSSynapseResource
    {
        public PSSynapseProxyResource(string id = default(string), string name = default(string), string type = default(string))
            :base(id, name, type)
        {
        }
    }
}
