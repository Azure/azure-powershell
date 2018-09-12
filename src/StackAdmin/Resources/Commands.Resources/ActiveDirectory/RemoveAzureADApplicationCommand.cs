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
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Removes the AD application.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmADApplication", DefaultParameterSetName = ParameterSet.ObjectId, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureADApplicationCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectId, HelpMessage = "The application object id.")]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationId, HelpMessage = "The application id.")]
        public Guid ApplicationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationDisplayName, HelpMessage = "The display name of the application.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.InputObject, HelpMessage = "The application object.")]
        public PSADApplication InputObject { get; set;}

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (this.IsParameterBound(c => c.InputObject))
                {
                    ObjectId = InputObject.ObjectId;
                }
                else if (this.IsParameterBound(c => c.ApplicationId))
                {
                    ObjectId = ActiveDirectoryClient.GetAppObjectIdFromApplicationId(ApplicationId);
                }
                else if (this.IsParameterBound(c => c.DisplayName))
                {
                    ObjectId = ActiveDirectoryClient.GetAppObjectIdFromDisplayName(DisplayName);
                }

                ConfirmAction(
                    Force.IsPresent,
                    string.Format(ProjectResources.RemovingApplication, ObjectId),
                    ProjectResources.RemoveApplication,
                    ObjectId.ToString(),
                    () => ActiveDirectoryClient.RemoveApplication(ObjectId));

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            });
        }
    }
}