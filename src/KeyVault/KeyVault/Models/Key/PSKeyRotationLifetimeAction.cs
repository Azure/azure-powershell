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
        //
        // Summary:
        //     Gets or sets the System.TimeSpan after creation to attempt to rotate. It only
        //     applies to Azure.Security.KeyVault.Keys.KeyRotationPolicyAction.Rotate.
        public TimeSpan? TimeAfterCreate { get; set; }
        //
        // Summary:
        //     Gets or sets the System.TimeSpan before expiry to attempt to Azure.Security.KeyVault.Keys.KeyRotationPolicyAction.Rotate
        //     or Azure.Security.KeyVault.Keys.KeyRotationPolicyAction.Notify.
        public TimeSpan? TimeBeforeExpiry { get; set; }
        
        public PSKeyRotationLifetimeAction() { }

        public PSKeyRotationLifetimeAction(KeyRotationLifetimeAction keyRotationLifetimeAction) 
        {
            Action = keyRotationLifetimeAction.Action.ToString();
            TimeAfterCreate = string.IsNullOrEmpty(keyRotationLifetimeAction.TimeAfterCreate) ? null : XmlConvert.ToTimeSpan(keyRotationLifetimeAction.TimeAfterCreate) as TimeSpan?;
            TimeBeforeExpiry = string.IsNullOrEmpty(keyRotationLifetimeAction.TimeBeforeExpiry) ? null : XmlConvert.ToTimeSpan(keyRotationLifetimeAction.TimeBeforeExpiry) as TimeSpan?;
        }
        
        public override string ToString()
        {
            return string.Format("[Action: {0}, TimeAfterCreate: {1}, TimeBeforeExpiry: {2}]", Action, TimeAfterCreate, TimeBeforeExpiry);
        }
    }
}
