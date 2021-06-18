using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSCustomerManagedKeyDetails
    {
        public PSCustomerManagedKeyDetails(CustomerManagedKeyDetails cmk)
        {
            this.Status = cmk?.Status;
            this.Key = cmk?.Key != null ? new PSWorkspaceKeyDetails(cmk.Key) : null;
        }

        /// <summary>
        /// Gets the customer managed key status on the workspace
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the key object of the workspace
        /// </summary>
        public PSWorkspaceKeyDetails Key { get; set; }
    }
}