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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Get AD groups members.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmADGroupMember", DefaultParameterSetName = ParameterSet.ObjectId, SupportsPaging = true), OutputType(typeof(List<PSADObject>))]
    public class GetAzureADGroupMemberCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectId, HelpMessage = "Object Id of the group.")]
        [ValidateNotNullOrEmpty]
        [Alias("Id", "GroupObjectId")]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.GroupObject, HelpMessage = "The group object.")]
        [ValidateNotNullOrEmpty]
        public PSADGroup GroupObject { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (this.IsParameterBound(c => c.GroupObject))
                {
                    ObjectId = GroupObject.Id;
                }

                ADObjectFilterOptions options = new ADObjectFilterOptions
                {
                    Id = ObjectId == Guid.Empty ? null : ObjectId.ToString(),
                    Paging = true
                };

                PSADObject group = ActiveDirectoryClient.FilterGroups(options).FirstOrDefault();
                if (group == null)
                {
                    throw new KeyNotFoundException(string.Format(ProjectResources.GroupDoesntExist, ObjectId));
                }

                ulong first = MyInvocation.BoundParameters.ContainsKey("First") ? this.PagingParameters.First : ulong.MaxValue;
                ulong skip = MyInvocation.BoundParameters.ContainsKey("Skip") ? this.PagingParameters.Skip : 0;
                WriteObject(ActiveDirectoryClient.GetGroupMembers(options, first, skip), true);
            });
        }
    }
}