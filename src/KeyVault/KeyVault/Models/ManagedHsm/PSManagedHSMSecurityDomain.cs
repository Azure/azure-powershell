using Microsoft.Azure.Management.KeyVault.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSManagedHSMSecurityDomain
    {
        /// <summary>
        /// Gets activation Status Possible values include: &#39;Active&#39;, &#39;NotActivated&#39;, &#39;Unknown&#39;, &#39;Failed&#39;
        /// </summary>
        public string ActivationStatus { get; private set; }

        /// <summary>
        /// Gets activation Status Message.
        /// </summary>
        public string ActivationStatusMessage { get; private set; }
         
        public PSManagedHSMSecurityDomain(ManagedHSMSecurityDomainProperties managedHSMSecurityDomainProperties)
        {
            this.ActivationStatus = managedHSMSecurityDomainProperties?.ActivationStatus;
            this.ActivationStatusMessage = managedHSMSecurityDomainProperties?.ActivationStatusMessage;
        }

    }
}
