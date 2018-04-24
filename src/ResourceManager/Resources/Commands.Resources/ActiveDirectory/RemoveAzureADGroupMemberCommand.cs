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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Removes a user from a group.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmADGroupMember", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSet.Explicit), OutputType(typeof(bool))]
    public class RemoveAzureADGroupMemberCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberObjectIdWithGroupDisplayName, HelpMessage = "The object id of the member(s) to remove.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberObjectIdWithGroupObject, HelpMessage = "The object id of the member(s) to remove.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberObjectIdWithGroupObjectId, HelpMessage = "The object id of the member(s) to remove.")]
        [ValidateNotNullOrEmpty]
        public Guid[] MemberObjectId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberUPNWithGroupDisplayName, HelpMessage = "The UPN of the member(s) to remove.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberUPNWithGroupObject, HelpMessage = "The UPN of the member(s) to remove.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberUPNWithGroupObjectId, HelpMessage = "The UPN of the member(s) to remove.")]
        [ValidateNotNullOrEmpty]
        public string[] MemberUserPrincipalName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberObjectIdWithGroupObjectId, HelpMessage = "The object id of the group to remove the member from.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberUPNWithGroupObjectId, HelpMessage = "The object id of the group to remove the member from.")]
        [ValidateNotNullOrEmpty]
        public Guid GroupObjectId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberObjectIdWithGroupDisplayName, HelpMessage = "The display name of the group to remove the member(s) from.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberUPNWithGroupDisplayName, HelpMessage = "The display name of the group to remove the member(s) from.")]
        [ValidateNotNullOrEmpty]
        public string GroupDisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.MemberObjectIdWithGroupObject, HelpMessage = "The object representation of the group to remove the member from.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.MemberUPNWithGroupObject, HelpMessage = "The object representation of the group to remove the member from.")]
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
                else if (this.IsParameterBound(c => c.GroupDisplayName))
                {
                    var group = ActiveDirectoryClient.GetGroupByDisplayName(GroupDisplayName);
                    GroupObjectId = group.Id;

                }

                if (this.IsParameterBound(c => c.MemberUserPrincipalName))
                {
                    var memberObjectId = new List<Guid>();
                    foreach (var memberUPN in MemberUserPrincipalName)
                    {
                        memberObjectId.Add(ActiveDirectoryClient.GetObjectIdFromUPN(memberUPN));
                    }

                    MemberObjectId = memberObjectId.ToArray();
                }

                foreach (var memberObjectId in MemberObjectId)
                {
                    if (ShouldProcess(target: memberObjectId.ToString(), action: string.Format("Removing user with object id '{0}' from group with object id '{1}'.", memberObjectId, GroupObjectId)))
                    {
                        ActiveDirectoryClient.RemoveGroupMember(GroupObjectId.ToString(), memberObjectId.ToString());
                    }
                }

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            });
        }
    }
}
