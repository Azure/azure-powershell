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

using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Gets AD service principal credentials.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmADSpCredential", DefaultParameterSetName = ParameterSet.ObjectId), OutputType(typeof(PSADCredential))]
    [Alias("Get-AzureRmADServicePrincipalCredential")]
    public class GetAzureADSpCredentialCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectId, HelpMessage = "The servicePrincipal object id.")]
        [ValidateNotNullOrEmpty]
        [Alias("Id")]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPN, HelpMessage = "The servicePrincipal name.")]
        [ValidateNotNullOrEmpty]
        public string ServicePrincipalName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayName, HelpMessage = "The display name of the service principal")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.SPNObject, HelpMessage = "The service principal object.")]
        [ValidateNotNullOrEmpty]
        public PSADServicePrincipal ServicePrincipalObject { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (this.IsParameterBound(c => c.ServicePrincipalObject))
                {
                    ObjectId = ServicePrincipalObject.Id;
                }
                else if (this.IsParameterBound(c => c.ServicePrincipalName))
                {
                    ObjectId = ActiveDirectoryClient.GetObjectIdFromSPN(ServicePrincipalName);
                }
                else if (this.IsParameterBound(c => c.DisplayName))
                {
                    ObjectId = ActiveDirectoryClient.GetObjectIdFromServicePrincipalDisplayName(DisplayName);
                }

                WriteObject(ActiveDirectoryClient.GetSpCredentials(ObjectId), enumerateCollection: true);
            });
        }
    }
}
