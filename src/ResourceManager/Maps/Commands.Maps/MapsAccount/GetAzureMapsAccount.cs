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

using Microsoft.Azure.Commands.LocationBasedServices.Models;
using Microsoft.Azure.Management.LocationBasedServices;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.LocationBasedServices
{
    /// <summary>
    /// Get Location Based Services Account by name, all accounts under resource group or all accounts under the subscription
    /// </summary>
    [Cmdlet(VerbsCommon.Get, LocationBasedServicesAccountNounStr, DefaultParameterSetName = ResourceGroupParameterSet), 
     OutputType(typeof(PSLocationBasedServicesAccount))]
    public class GetAzureLocationBasedServiceAccountCommand : LocationBasedServicesAccountBaseCmdlet
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
            HelpMessage = "Location Based Services Account Name.")]
        [Alias(LocationBasedServicesAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "Location Based Services Account ResourceId.")]
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
                        var locationBasedServicesAccount = this.LocationBasedServicesClient.Accounts.Get(this.ResourceGroupName, this.Name);
                        WriteLocationBasedServicesAccount(locationBasedServicesAccount);
                        break;
                    }
                    case ResourceGroupParameterSet:
                    {
                        if (string.IsNullOrEmpty(this.ResourceGroupName))
                        {
                            var locationBasedServicesAccounts = this.LocationBasedServicesClient.Accounts.ListBySubscription();
                            WriteLocationBasedServicesAccountList(locationBasedServicesAccounts);
                        }
                        else
                        {
                            var locationBasedServicesAccounts = this.LocationBasedServicesClient.Accounts.ListByResourceGroup(this.ResourceGroupName);
                            WriteLocationBasedServicesAccountList(locationBasedServicesAccounts);
                        }
                        break;
                    }
                    case ResourceIdParameterSet:
                    {
                        string resourceGroupName;
                        string resourceName;

                        if (ValidateAndExtractName(this.ResourceId, out resourceGroupName, out resourceName))
                        {
                            var locationBasedServicesAccount = this.LocationBasedServicesClient.Accounts.Get(resourceGroupName, resourceName);
                            WriteLocationBasedServicesAccount(locationBasedServicesAccount);
                        }
                        break;
                    }
                }
            });
        }
    }
}
