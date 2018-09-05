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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Adds a user to a group.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureRmADGroupMember", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSet.MemberObjectIdWithGroupObjectId), OutputType(typeof(bool))]
    public class AddAzureADGroupMemberCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberObjectIdWithGroupDisplayName, HelpMessage = "The object id of the member(s) to add to the group.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberObjectIdWithGroupObject, HelpMessage = "The object id of the member(s) to add to the group.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberObjectIdWithGroupObjectId, HelpMessage = "The object id of the member(s) to add to the group.")]
        [ValidateNotNullOrEmpty]
        public Guid[] MemberObjectId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberUPNWithGroupDisplayName, HelpMessage = "The UPN of the member(s) to add to the group.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberUPNWithGroupObject, HelpMessage = "The UPN of the member(s) to add to the group.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberUPNWithGroupObjectId, HelpMessage = "The UPN of the member(s) to add to the group.")]
        public string[] MemberUserPrincipalName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberObjectIdWithGroupObjectId, HelpMessage = "The object id of the group to add the member(s) to.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberUPNWithGroupObjectId, HelpMessage = "The object id of the group to add the member(s) to.")]
        [ValidateNotNullOrEmpty]
        public Guid TargetGroupObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.MemberObjectIdWithGroupObject, HelpMessage = "The object representation of the group to add the member(s) to.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.MemberUPNWithGroupObject, HelpMessage = "The object representation of the group to add the member(s) to.")]
        [ValidateNotNullOrEmpty]
        public PSADGroup TargetGroupObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberObjectIdWithGroupDisplayName, HelpMessage = "The display name of the group to add the member(s) to.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.MemberUPNWithGroupDisplayName, HelpMessage = "The display name of the group to add the member(s) to.")]
        public string TargetGroupDisplayName { get; set; }

        [Parameter(Mandatory = true)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (this.IsParameterBound(c => c.TargetGroupObject))
                {
                    TargetGroupObjectId = TargetGroupObject.Id;
                }
                else if (this.IsParameterBound(c => c.TargetGroupDisplayName))
                {
                    var targetGroup = ActiveDirectoryClient.GetGroupByDisplayName(TargetGroupDisplayName);
                    TargetGroupObjectId = targetGroup.Id;
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
                    var groupAddMemberParams = new GroupAddMemberParameters()
                    {
                        Url = string.Format("{0}/{1}/directoryObjects/{2}",
                                            AzureEnvironmentConstants.AzureGraphEndpoint,
                                            AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant,
                                            memberObjectId)
                    };

                    if (ShouldProcess(target: memberObjectId.ToString(), action: string.Format("Adding user with object id '{0}' to group with object id '{1}'.", memberObjectId, TargetGroupObjectId)))
                    {
                        ActiveDirectoryClient.AddGroupMember(TargetGroupObjectId.ToString(), groupAddMemberParams);
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
