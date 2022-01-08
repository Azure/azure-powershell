using Microsoft.Azure.Commands.ServiceBus.Commands;
using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Management.ServiceBus.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.ServiceBus.Cmdlets.Namespace
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServceBusEncryptionConfig", SupportsShouldProcess = false), OutputType(typeof(PSKeyVaultProperties))]
    public class NewKeyVaultPropertyObject : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Key Name")]
        public string KeyName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Key Vault Uri")]
        public string KeyVaultUri { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Key Version")]
        public string KeyVersion { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "User Assigned Identity")]
        public string UserAssignedIdentity { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                UserAssignedIdentityProperties uaip = null;
                
                if (UserAssignedIdentity != null)
                    uaip = new UserAssignedIdentityProperties(UserAssignedIdentity);
                
                KeyVaultProperties kvp = new KeyVaultProperties(keyName: KeyName, keyVaultUri: KeyVaultUri, keyVersion: KeyVersion, identity: uaip);
                
                PSKeyVaultProperties keyvaultproperty = new PSKeyVaultProperties(kvp);
                
                WriteObject(keyvaultproperty);
            }
            catch (Exception ex)
            {
                WriteObject(new ErrorRecord(ex, ex.Message, ErrorCategory.OpenError, ex));
            }
        }
    }
}
