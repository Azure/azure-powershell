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

//using Microsoft.Azure.Storage.Blob;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using global::Azure.Storage.Files.DataLake;
using global::Azure;
using global::Azure.Storage.Files.DataLake.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Set", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2ItemAclObject"), OutputType(typeof(PSPathAccessControlEntry))]
    [Alias("New-" + Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2ItemAclObject")]
    public class SetAzDataLakeGen2ItemAclObjectCommand : AzureDataCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "The user or group identifier. It is omitted for entries of AccessControlType \"mask\" and \"other\". The user or group identifier is also omitted for the owner and owning group.")]
        [ValidateNotNullOrEmpty]
        public string EntityId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Set this parameter to indicate the ACE belongs to the default ACL for a directory; otherwise scope is implicit and the ACE belongs to the access ACL.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter DefaultScope { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "There are four types: \"user\" grants rights to the owner or a named user, \"group\" grants rights to the owning group or a named group, \"mask\" restricts rights granted to named users and the members of groups, and \"other\" grants rights to all users not found in any of the other entries.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(PSAccessControlType.User,
            PSAccessControlType.Group,
            PSAccessControlType.Mask,
            PSAccessControlType.Other,
            IgnoreCase = true)]
        public AccessControlType AccessControlType;

        [Parameter(Mandatory = true, HelpMessage = "The permission field is a 3-character sequence where the first character is 'r' to grant read access, the second character is 'w' to grant write access, and the third character is 'x' to grant execute permission. If access is not granted, the '-' character is used to denote that the permission is denied.")]
        [ValidatePattern("[r-][w-][x-]")]
        public string Permission { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If input the PSPathAccessControlEntry[] object, will add the new ACL entry as a new element of the input PSPathAccessControlEntry[] object. If an ACL entry when same AccessControlType, EntityId, DefaultScope exist, will update permission of it.")]
        [ValidateNotNullOrEmpty]
        public PSPathAccessControlEntry[] InputObject { get; set; }       

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            List<PSPathAccessControlEntry> psacls = new List<PSPathAccessControlEntry>();
            if (InputObject !=null)
            {
                psacls = new List<PSPathAccessControlEntry>(this.InputObject);
            }

            // Remove the ACL entry to add if already exist, to avoid duplicated entries
            PSPathAccessControlEntry entryToRemove = null;
            foreach (PSPathAccessControlEntry entry in psacls)
            {
                if (entry.DefaultScope == this.DefaultScope.IsPresent 
                    && entry.AccessControlType == this.AccessControlType
                    && entry.EntityId == this.EntityId)
                {
                    entryToRemove = entry;
                }
            }
            if (entryToRemove != null)
            {
                psacls.Remove(entryToRemove);
            }

            PSPathAccessControlEntry psacl = new PSPathAccessControlEntry(this.AccessControlType, PathAccessControlExtensions.ParseSymbolicRolePermissions(this.Permission), this.DefaultScope, this.EntityId);
            psacls.Add(psacl);

            WriteObject(psacls.ToArray(), true);
        }
    }
}
