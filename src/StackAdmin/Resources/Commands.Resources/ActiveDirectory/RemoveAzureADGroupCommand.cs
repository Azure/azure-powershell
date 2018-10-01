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
using System.Linq;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;


namespace Microsoft.Azure.Commands.ActiveDirectory
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmADGroup", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSet.ObjectId), OutputType(typeof(bool))]
    public class RemoveAzureADGroupCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectId, HelpMessage = "The object id of the group to be removed.")]
        [ValidateNotNullOrEmpty]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DisplayName, HelpMessage = "The display name of the group to be removed.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.InputObject, HelpMessage = "The object representation of the group to be removed.")]
        [ValidateNotNullOrEmpty]
        public PSADGroup InputObject { get; set; }

        [Parameter(Mandatory = true)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = true)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (this.IsParameterBound(c => c.InputObject))
                {
                    ObjectId = InputObject.Id;
                }
                else if (this.IsParameterBound(c => c.DisplayName))
                {
                    var group = ActiveDirectoryClient.GetGroupByDisplayName(DisplayName);
                    ObjectId = group.Id;
                }

                ConfirmAction(
                    Force.IsPresent,
                    string.Format(ProjectResources.RemoveGroupConfirmation, ObjectId),
                    ProjectResources.RemovingGroup,
                    ObjectId.ToString(),
                    () => ActiveDirectoryClient.RemoveGroup(ObjectId.ToString()));

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            });
        }
    }
}
