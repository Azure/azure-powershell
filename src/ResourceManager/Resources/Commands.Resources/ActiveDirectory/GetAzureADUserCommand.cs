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
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Get AD users.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmADUser", DefaultParameterSetName = ParameterSet.Empty), OutputType(typeof(List<PSADUser>))]
    public class GetAzureADUserCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SearchString,
            HelpMessage = "The user search string.")]
        [ValidateNotNullOrEmpty]
        public string SearchString { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectId,
            HelpMessage = "The user object id.")]
        [ValidateNotNullOrEmpty]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Empty,
            HelpMessage = "The user UPN.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.UPN,
            HelpMessage = "The user UPN.")]
        [ValidateNotNullOrEmpty]
        [Alias("UPN")]
        public string UserPrincipalName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.Mail,
            HelpMessage = "The user mail.")]
        [ValidateNotNullOrEmpty]
        public string Mail { get; set; }

        public override void ExecuteCmdlet()
        {
            ADObjectFilterOptions options = new ADObjectFilterOptions
            {
                SearchString = SearchString,
                UPN = UserPrincipalName,
                Id = ObjectId == Guid.Empty ? null : ObjectId.ToString(),
                Paging = true,
                Mail = Mail
            };

            ExecutionBlock(() =>
            {
                do
                {
                    WriteObject(ActiveDirectoryClient.FilterUsers(options), true);

                } while (!string.IsNullOrEmpty(options.NextLink));
            });
        }
    }
}