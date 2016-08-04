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

using Microsoft.Azure.Commands.ActiveDirectory.Models;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Gets AD service principal credentials.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmADSpCredential", DefaultParameterSetName = ParameterSet.ObjectId), OutputType(typeof(PSADCredential))]
    public class GetAzureADSpCredentialCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectId, HelpMessage = "The servicePrincipal object id.")]
        [ValidateNotNullOrEmpty]
        public string ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPN, HelpMessage = "The servicePrincipal name.")]
        [ValidateNotNullOrEmpty]
        public string ServicePrincipalName { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (!string.IsNullOrEmpty(ServicePrincipalName))
                {
                    ObjectId = ActiveDirectoryClient.GetObjectIdFromSPN(ServicePrincipalName);
                }

                WriteObject(ActiveDirectoryClient.GetSpCredentials(ObjectId), enumerateCollection: true);
            });
        }
    }
}
