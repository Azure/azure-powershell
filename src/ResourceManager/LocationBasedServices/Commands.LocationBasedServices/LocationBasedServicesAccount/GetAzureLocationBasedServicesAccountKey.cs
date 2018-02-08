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
    /// Get Account Keys for Location Based Services Account
    /// </summary>
    [Cmdlet(VerbsCommon.Get, LocationBasedServicesAccountKeyNounStr, DefaultParameterSetName = NameParameterSet), 
     OutputType(typeof(PSLocationBasedServicesAccountKeys))]
    public class GetAzureLocationBasedServicesAccountKeyCommand : LocationBasedServicesAccountBaseCmdlet
    {
        protected const string NameParameterSet = "NameParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string InputObjectParameterSet = "InputObjectParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameParameterSet,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameParameterSet,
            HelpMessage = "Location Based Services Account Name.")]
        [Alias(LocationBasedServicesAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = InputObjectParameterSet,
            HelpMessage = "Location Based Services Account piped from Get-AzureRmLocationBasedServicesAccount.",
            ValueFromPipeline = true)]
        public PSLocationBasedServicesAccount InputObject { get; set; }

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
                string rgName = null;
                string name = null;

                switch (ParameterSetName)
                {
                    case InputObjectParameterSet:
                    {
                        rgName = InputObject.ResourceGroupName;
                        name = InputObject.AccountName;
                        break;
                    }
                    case NameParameterSet:
                    {
                        rgName = this.ResourceGroupName;
                        name = this.Name;
                        break;
                    }
                    case ResourceIdParameterSet:
                    {
                        ValidateAndExtractName(this.ResourceId, out rgName, out name);
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(rgName) && !string.IsNullOrEmpty(name))
                {
                    var locationBasedServicesKeys = this.LocationBasedServicesClient.Accounts.ListKeys(rgName, name);
                    WriteObject(new PSLocationBasedServicesAccountKeys(locationBasedServicesKeys));
                }
            });
        }
    }
}
