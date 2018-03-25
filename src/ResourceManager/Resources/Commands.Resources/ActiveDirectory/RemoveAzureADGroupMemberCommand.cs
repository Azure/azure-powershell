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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Removes a user from a group.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmADGroupMember", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSet.Explicit), OutputType(typeof(bool))]
    public class RemoveAzureADGroupMemberCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Explicit, HelpMessage = "The object id of the member.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.GroupObject, HelpMessage = "The object id of the member.")]
        [ValidateNotNullOrEmpty]
        public Guid MemberObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Explicit, HelpMessage = "The object id of the group to add the member to.")]
        [ValidateNotNullOrEmpty]
        public Guid GroupObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.GroupObject, HelpMessage = "The object representation of the group to add the member to.")]
        [ValidateNotNullOrEmpty]
        public PSADGroup GroupObject { get; set; }

        [Parameter(Mandatory = true)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (this.IsParameterBound(c => c.GroupObject))
                {
                    GroupObjectId = GroupObject.Id;
                }

                if (ShouldProcess(target: MemberObjectId.ToString(), action: string.Format("Removing user with object id '{0}' from group with object id '{1}'.", MemberObjectId, GroupObjectId)))
                {
                    ActiveDirectoryClient.RemoveGroupMember(GroupObjectId.ToString(), MemberObjectId.ToString());
                }

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            });
        }
    }
}
