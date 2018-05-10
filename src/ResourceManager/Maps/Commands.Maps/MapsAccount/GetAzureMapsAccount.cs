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

using System.Management.Automation;
using Microsoft.Azure.Management.Maps;
using Microsoft.Azure.Commands.Maps.Models;

namespace Microsoft.Azure.Commands.Maps.MapsAccount
{
    /// <summary>
    /// Get Maps Account by name, all accounts under resource group or all accounts under the subscription
    /// </summary>
    [Cmdlet(VerbsCommon.Get, MapsAccountNounStr, DefaultParameterSetName = ResourceGroupParameterSet), 
     OutputType(typeof(PSMapsAccount))]
    public class GetAzureMapsAccount : MapsAccountBaseCmdlet
    {
        protected const string ResourceGroupParameterSet = "ResourceGroupParameterSet";
        protected const string AccountNameParameterSet = "AccountNameParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = ResourceGroupParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = AccountNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AccountNameParameterSet,
            HelpMessage = "Maps Account Name.")]
        [Alias(MapsAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "Maps Account ResourceId.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                switch (ParameterSetName)
                {
                    case AccountNameParameterSet:
                    {
                        var mapsAccount = this.MapsClient.Accounts.Get(this.ResourceGroupName, this.Name);
                        WriteMapsAccount(mapsAccount);
                        break;
                    }
                    case ResourceGroupParameterSet:
                    {
                        if (string.IsNullOrEmpty(this.ResourceGroupName))
                        {
                            var mapsAccounts = this.MapsClient.Accounts.ListBySubscription();
                            WriteMapsAccountList(mapsAccounts);
                        }
                        else
                        {
                            var mapsAccounts = this.MapsClient.Accounts.ListByResourceGroup(this.ResourceGroupName);
                            WriteMapsAccountList(mapsAccounts);
                        }
                        break;
                    }
                    case ResourceIdParameterSet:
                    {
                        string resourceGroupName;
                        string resourceName;

                        if (ValidateAndExtractName(this.ResourceId, out resourceGroupName, out resourceName))
                        {
                            var mapsAccount = this.MapsClient.Accounts.Get(resourceGroupName, resourceName);
                            WriteMapsAccount(mapsAccount);
                        }
                        break;
                    }
                }
            });
        }
    }
}
