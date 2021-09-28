//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
// 

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementKeyVaultObject"), OutputType(typeof(PsApiManagementKeyVaultEntity))]
    public class NewAzureApiManagementKeyVaultObject : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = true,
            HelpMessage = "Secret Identifier of this Key Vault.")]
        [ValidateNotNullOrEmpty]
        public string SecretIdentifier { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Identity Client Id of the user-assigned Managed Identity. Will default system-assigned if leave empty.")]
        public string IdentityClientId { get; set; }
        
        public override void ExecuteApiManagementCmdlet()
        {
            WriteObject(
                new PsApiManagementKeyVaultEntity
                {
                    SecretIdentifier = SecretIdentifier,
                    IdentityClientId = IdentityClientId
                });
        }
    }
}
