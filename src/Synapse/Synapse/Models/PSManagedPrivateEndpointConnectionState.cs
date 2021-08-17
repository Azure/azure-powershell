using Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSManagedPrivateEndpointConnectionState
    {
        public PSManagedPrivateEndpointConnectionState(ManagedPrivateEndpointConnectionState state)
        {
            this.Status = state?.Status;
            this.Description = state?.Description;
            this.ActionsRequired = state?.ActionsRequired;
        }

        public string Status { get; }
      
        public string Description { get; set; }
        
        public string ActionsRequired { get; set; }
    }
}
