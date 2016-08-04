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
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Removes AD SP credentials.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmADSpCredential", DefaultParameterSetName = ParameterSet.ObjectIdWithKeyId, SupportsShouldProcess = true)]
    public class RemoveAzureADSpCredentialCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectIdWithKeyId, HelpMessage = "The servicePrincipal object id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectIdWithAll, HelpMessage = "The servicePrincipal object id.")]
        [ValidateNotNullOrEmpty]
        public string ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPNWithKeyId, HelpMessage = "The servicePrincipal name.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPNWithAll, HelpMessage = "The servicePrincipal name.")]
        [ValidateNotNullOrEmpty]
        public string ServicePrincipalName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectIdWithKeyId, HelpMessage = "The keyCredential Id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPNWithKeyId, HelpMessage = "The keyCredential Id.")]
        [ValidateGuidNotEmpty]
        public Guid KeyId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectIdWithAll, HelpMessage = "Switch to remove all credentials.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPNWithAll, HelpMessage = "Switch to remove all credentials.")]
        public SwitchParameter All { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (!string.IsNullOrEmpty(ServicePrincipalName))
                {
                    ObjectId = ActiveDirectoryClient.GetObjectIdFromSPN(ServicePrincipalName);
                }

                bool deleteAllCredentials = false;
                if (All.IsPresent)
                {
                    deleteAllCredentials = true;
                }

                if (KeyId != Guid.Empty)
                {
                    ConfirmAction(
                  Force.IsPresent,
                  string.Format(ProjectResources.RemovingSpCredentialWithId, KeyId, ObjectId),
                  ProjectResources.RemoveCredential,
                  ObjectId,
                  () => ActiveDirectoryClient.RemoveSpCredentialByKeyId(ObjectId, KeyId));
                }
                else if (deleteAllCredentials)
                {
                    ConfirmAction(
                  Force.IsPresent,
                  string.Format(ProjectResources.RemovingAllSpCredentials, ObjectId),
                  ProjectResources.RemoveCredential,
                  ObjectId,
                  () => ActiveDirectoryClient.RemoveAllSpCredentials(ObjectId));
                }
            });
        }
    }
}
