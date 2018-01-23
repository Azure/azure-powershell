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

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    /// Gets a list of shares used by the Storage system to place storage accounts.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminShare, DefaultParameterSetName = ListTenantSharesParamSet)]
    [Alias("Get-ACSShare")]
    public sealed class GetAdminShare : AdminCmdletDefaultFarm
    {
        const string ListTenantSharesParamSet = "ListTenant";
        const string ListSharesForMigrationParamSet = "GetSharesForMigration";

        /// <summary>
        /// Share name to get details
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = ListTenantSharesParamSet)]
        [ValidateNotNullOrEmpty]
        public string ShareName
        {
            get;
            set;
        }

        /// <summary>
        /// Get Destination Shares for a container migration, given a Source Share
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ListSharesForMigrationParamSet)]
        [ValidateNotNullOrEmpty]
        public string SourceShareName { get; set; }

        /// <summary>
        /// Intent of the cmdlet to get all shares (default) or get shares for container migration
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ListSharesForMigrationParamSet)]
        public FileShareGetIntent? Intent { get; set; }

        protected override void Execute()
        {
            WriteVerbose(String.Format("Get Shares ParamSet {0}", ParameterSetName));
            switch (ParameterSetName)
            {
                case ListTenantSharesParamSet:
                    if (string.IsNullOrEmpty(ShareName))
                    {
                        var shares = Client.Shares.List(ResourceGroupName, FarmName);

                        WriteObject(shares.Shares.Select(_ => new ShareResponse(_)), true);
                    }
                    else
                    {
                        var share = Client.Shares.Get(ResourceGroupName, FarmName, ShareName);

                        WriteObject(new ShareResponse(share.Share));
                    }
                    break;
                case ListSharesForMigrationParamSet :
                    if (null == this.Intent)
                    {
                        this.Intent = FileShareGetIntent.ContainerMigration;
                    }

                    WriteVerbose(String.Format("Source Share name {0}", this.SourceShareName));

                    switch (this.Intent)
                    {
                        case FileShareGetIntent.ContainerMigration:
                            DestinationShareListResponse response = this.Client.Shares.GetDestinationShares(this.ResourceGroupName, this.FarmName, this.SourceShareName);
                            this.WriteObject(response.Shares.Select(_ => new ShareResponse(_)), true);
                            break;
                    }
                    break;
            }
        }
    }
}
