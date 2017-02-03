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

using Microsoft.Azure.Commands.DataLakeStore.Models;
using Microsoft.Azure.Commands.DataLakeStore.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.DataLake.Store.Models;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet(VerbsCommon.Set, "AzureRmDataLakeStoreAccount"), OutputType(typeof(PSDataLakeStoreAccount))]
    [Alias("Set-AdlStore")]
    public class SetAzureDataLakeStoreAccount : DataLakeStoreCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of the account.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage = "Name of default group to use for all newly created files and folders in the Data Lake Store."
            )]
        [ValidateNotNullOrEmpty]
        public string DefaultGroup { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage =
                "A string,string dictionary of tags associated with this account that should replace the current set of tags"
            )]
        [ValidateNotNull]
        public Hashtable Tags { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "Optionally enable/disable the existing trusted ID providers.")]
        [ValidateNotNull]
        public TrustedIdProviderState? TrustedIdProviderState { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage = "Optionally enable/disable existing firewall rules.")]
        [ValidateNotNull]
        public FirewallState? FirewallState { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "Name of resource group under which you want to update the account.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The desired commitment tier for this account to use.")]
        [ValidateNotNull]
        public TierType? Tier { get; set; }

        public override void ExecuteCmdlet()
        {
            var currentAccount = DataLakeStoreClient.GetAccount(ResourceGroupName, Name);
            var location = currentAccount.Location;

            if (string.IsNullOrEmpty(DefaultGroup))
            {
                DefaultGroup = currentAccount.DefaultGroup;
            }

            if (Tags == null)
            {
                Tags = TagsConversionHelper.CreateTagHashtable(currentAccount.Tags);
            }

            if (!TrustedIdProviderState.HasValue)
            {
                TrustedIdProviderState = currentAccount.TrustedIdProviderState;
            }

            if (!FirewallState.HasValue)
            {
                FirewallState = currentAccount.FirewallState;
            }

            WriteObject(
                new PSDataLakeStoreAccount(
                    DataLakeStoreClient.UpdateAccount(
                        ResourceGroupName,
                        Name,
                        DefaultGroup,
                        TrustedIdProviderState.GetValueOrDefault(),
                        FirewallState.GetValueOrDefault(),
                        Tags,
                        tier: Tier)));
        }
    }
}