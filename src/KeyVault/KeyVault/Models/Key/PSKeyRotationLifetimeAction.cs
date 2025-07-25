using Azure.Security.KeyVault.Keys;

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyRotationLifetimeAction
    {
        //
        // Summary:
        //     Gets or sets he Azure.Security.KeyVault.Keys.KeyRotationPolicyAction that will
        //     be executed.
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the ISO 8601 duration after creation to attempt to rotate. It only
        /// applies to Azure.Security.KeyVault.Keys.KeyRotationPolicyAction.Rotate.
        /// </summary>
        /// <example>
        /// ISO 8601 duration examples:
        /// • P90D – 90 days
        /// • P3M – 3 months
        /// • P1Y10D – 1 year and 10 days
        /// </example>
        public string TimeAfterCreate { get; set; }

        /// <summary>
        /// Gets or sets the ISO 8601 duration before expiry to attempt to Azure.Security.KeyVault.Keys.KeyRotationPolicyAction.Rotate
        /// or Azure.Security.KeyVault.Keys.KeyRotationPolicyAction.Notify.
        /// </summary>
        public string TimeBeforeExpiry { get; set; }
        
        public PSKeyRotationLifetimeAction() { }

        public PSKeyRotationLifetimeAction(KeyRotationLifetimeAction keyRotationLifetimeAction) 
        {
            Action = keyRotationLifetimeAction.Action.ToString();
            TimeAfterCreate = keyRotationLifetimeAction.TimeAfterCreate;
            TimeBeforeExpiry = keyRotationLifetimeAction.TimeBeforeExpiry;
        }
        
        public override string ToString()
        {
            return string.Format("[Action: {0}, TimeAfterCreate: {1}, TimeBeforeExpiry: {2}]", Action, TimeAfterCreate, TimeBeforeExpiry);
        }
    }
}
