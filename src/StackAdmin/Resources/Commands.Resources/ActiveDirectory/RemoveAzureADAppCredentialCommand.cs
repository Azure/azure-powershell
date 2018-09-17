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
    /// Removes AD application credentials.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmADAppCredential", DefaultParameterSetName = ParameterSet.ApplicationObjectIdWithKeyId, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureADAppCredentialCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithKeyId, HelpMessage = "The application object id.")]
        [ValidateNotNullOrEmpty]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithKeyId, HelpMessage = "The application id.")]
        [ValidateNotNullOrEmpty]
        public Guid ApplicationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationDisplayName, HelpMessage = "The display name of the application.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithKeyId, HelpMessage = "The keyCredential Id.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithKeyId, HelpMessage = "The keyCredential Id.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.ApplicationObjectWithKeyId, HelpMessage = "The keyCredential Id.")]
        [ValidateGuidNotEmpty]
        public Guid KeyId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.ApplicationObjectWithKeyId, HelpMessage = "The application object.")]
        public PSADApplication ApplicationObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (this.IsParameterBound(c => c.ApplicationObject))
                {
                    ObjectId = ApplicationObject.ObjectId;
                }
                else if (this.IsParameterBound(c => c.ApplicationId))
                {
                    ObjectId = ActiveDirectoryClient.GetAppObjectIdFromApplicationId(ApplicationId);
                }
                else if (this.IsParameterBound(c => c.DisplayName))
                {
                    ObjectId = ActiveDirectoryClient.GetAppObjectIdFromDisplayName(DisplayName);
                }

                if (this.IsParameterBound(c => c.KeyId))
                {
                    ConfirmAction(
                        Force.IsPresent,
                        string.Format(ProjectResources.RemovingAppCredentialWithId, KeyId, ObjectId),
                        ProjectResources.RemoveCredential,
                        ObjectId.ToString(),
                        () => ActiveDirectoryClient.RemoveAppCredentialByKeyId(ObjectId, KeyId));
                }
                else
                {
                    ConfirmAction(
                        Force.IsPresent,
                        string.Format(ProjectResources.RemovingAllAppCredentials, ObjectId.ToString()),
                        ProjectResources.RemoveCredential,
                        ObjectId.ToString(),
                        () => ActiveDirectoryClient.RemoveAllAppCredentials(ObjectId));
                }

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            });
        }
    }
}
