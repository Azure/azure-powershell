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
    /// Removes AD application credentials.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmADAppCredential", DefaultParameterSetName = ParameterSet.ApplicationObjectIdWithKeyId, SupportsShouldProcess = true)]
    public class RemoveAzureADAppCredentialCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithKeyId, HelpMessage = "The application object id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithAll, HelpMessage = "The application object id.")]
        [ValidateNotNullOrEmpty]
        public string ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithKeyId, HelpMessage = "The application id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithAll, HelpMessage = "The application id.")]
        [ValidateNotNullOrEmpty]
        public string ApplicationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithKeyId, HelpMessage = "The keyCredential Id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithKeyId, HelpMessage = "The keyCredential Id.")]
        [ValidateGuidNotEmpty]
        public Guid KeyId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithAll, HelpMessage = "Switch to remove all credentials.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithAll, HelpMessage = "Switch to remove all credentials.")]
        public SwitchParameter All { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (!string.IsNullOrEmpty(ApplicationId))
                {
                    ObjectId = ActiveDirectoryClient.GetObjectIdFromApplicationId(ApplicationId);
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
                  string.Format(ProjectResources.RemovingAppCredentialWithId, KeyId, ObjectId),
                  ProjectResources.RemoveCredential,
                  ObjectId,
                  () => ActiveDirectoryClient.RemoveAppCredentialByKeyId(ObjectId, KeyId));
                }
                else if (deleteAllCredentials)
                {
                    ConfirmAction(
                  Force.IsPresent,
                  string.Format(ProjectResources.RemovingAllAppCredentials, ObjectId.ToString()),
                  ProjectResources.RemoveCredential,
                  ObjectId,
                  () => ActiveDirectoryClient.RemoveAllAppCredentials(ObjectId));
                }
            });
        }
    }
}
