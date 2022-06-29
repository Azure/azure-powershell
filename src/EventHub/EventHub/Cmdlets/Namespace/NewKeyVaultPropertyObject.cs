// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.EventHub.Commands;
using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Management.EventHub.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.EventHub.Cmdlets.Namespace
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubEncryptionConfig", SupportsShouldProcess = false), OutputType(typeof(PSEncryptionConfigAttributes))]
    public class NewKeyVaultPropertyObject : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Key Name")]
        public string KeyName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Key Vault Uri")]
        public string KeyVaultUri { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Key Version")]
        public string KeyVersion { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "User Assigned Identity")]
        public string UserAssignedIdentity { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                UserAssignedIdentityProperties uaip = null;
                
                if (UserAssignedIdentity != null)
                    uaip = new UserAssignedIdentityProperties(UserAssignedIdentity);
                
                KeyVaultProperties kvp = new KeyVaultProperties(keyName: KeyName, keyVaultUri: KeyVaultUri, keyVersion: KeyVersion, identity: uaip);

                PSEncryptionConfigAttributes keyvaultproperty = new PSEncryptionConfigAttributes(kvp);
                
                WriteObject(keyvaultproperty);
            }
            catch (Exception ex)
            {
                WriteObject(new ErrorRecord(ex, ex.Message, ErrorCategory.OpenError, ex));
            }
        }
    }
}
