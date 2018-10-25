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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Removes AD SP credentials.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmADSpCredential", DefaultParameterSetName = ParameterSet.ObjectIdWithKeyId, SupportsShouldProcess = true), OutputType(typeof(bool))]
    [Alias("Remove-AzureRmADServicePrincipalCredential")]
    public class RemoveAzureADSpCredentialCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectIdWithKeyId, HelpMessage = "The servicePrincipal object id.")]
        [ValidateNotNullOrEmpty]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPNWithKeyId, HelpMessage = "The servicePrincipal name.")]
        [ValidateNotNullOrEmpty]
        public string ServicePrincipalName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayNameWithKeyId, HelpMessage = "The display name of the service principal.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.ServicePrincipalObject, HelpMessage = "The service principal object.")]
        [ValidateNotNullOrEmpty]
        public PSADServicePrincipal ServicePrincipalObject { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectIdWithKeyId, HelpMessage = "The keyCredential Id.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPNWithKeyId, HelpMessage = "The keyCredential Id.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ServicePrincipalObject, HelpMessage = "The keyCredential Id.")]
        [ValidateGuidNotEmpty]
        public Guid KeyId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

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

                if (this.IsParameterBound(c => c.KeyId))
                {
                    ConfirmAction(
                        Force.IsPresent,
                        string.Format(ProjectResources.RemovingSpCredentialWithId, KeyId, ObjectId),
                        ProjectResources.RemoveCredential,
                        ObjectId.ToString(),
                        () => ActiveDirectoryClient.RemoveSpCredentialByKeyId(ObjectId, KeyId));
                }
                else
                {
                    ConfirmAction(
                        Force.IsPresent,
                        string.Format(ProjectResources.RemovingAllSpCredentials, ObjectId),
                        ProjectResources.RemoveCredential,
                        ObjectId.ToString(),
                        () => ActiveDirectoryClient.RemoveAllSpCredentials(ObjectId));
                }

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            });
        }
    }
}
