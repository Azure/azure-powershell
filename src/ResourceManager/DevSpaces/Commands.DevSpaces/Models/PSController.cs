using Microsoft.Azure.Management.DevSpaces.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.DevSpaces.Models
{
    public class PSController
    {
        public PSController(Controller controller)
        {
            Id = controller?.Id;
            var resourceIdentifier = new ResourceIdentifier(Id);
            ResourceGroupName = resourceIdentifier.ResourceGroupName;
            Name = controller?.Name;
            Location = controller?.Location;
            ProvisioningState = controller?.ProvisioningState;
        }

        private string Id { get; set; }
        public string Name { get; set; }
        public string ResourceGroupName { get; set; }
        public string Location { get; set; }
        public string ProvisioningState { get; set; }
    }
}
