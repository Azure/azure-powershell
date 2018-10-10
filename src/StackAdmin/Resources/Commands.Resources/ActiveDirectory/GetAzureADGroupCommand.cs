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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Get AD groups.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmADGroup", DefaultParameterSetName = ParameterSet.Empty, SupportsPaging = true), OutputType(typeof(List<PSADGroup>))]
    public class GetAzureADGroupCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SearchString,
            HelpMessage = "Used to find groups that begin with the provided string.")]
        [Alias("SearchString")]
        [ValidateNotNullOrEmpty]
        public string DisplayNameStartsWith { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.DisplayName, HelpMessage = "The display name of the group.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Empty,
            HelpMessage = "The group id.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectId,
            HelpMessage = "The group id.")]
        [ValidateNotNullOrEmpty]
        public Guid ObjectId { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                ADObjectFilterOptions options = new ADObjectFilterOptions
                {
                    SearchString = this.IsParameterBound(c => c.DisplayNameStartsWith) ? DisplayNameStartsWith + "*" : DisplayName,
                    Id = ObjectId == Guid.Empty ? null : ObjectId.ToString(),
                    Paging = true
                };

                ulong first = MyInvocation.BoundParameters.ContainsKey("First") ? this.PagingParameters.First : ulong.MaxValue;
                ulong skip = MyInvocation.BoundParameters.ContainsKey("Skip") ? this.PagingParameters.Skip : 0;
                WriteObject(ActiveDirectoryClient.FilterGroups(options, first, skip), true);
            });
        }
    }
}