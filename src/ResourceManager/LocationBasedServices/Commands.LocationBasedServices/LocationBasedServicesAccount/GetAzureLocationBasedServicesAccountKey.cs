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
using Microsoft.Azure.Management.LocationBasedServices.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.LocationBasedServices
{
    /// <summary>
    /// Get Account Keys for Location Based Services Account
    /// </summary>
    [Cmdlet(VerbsCommon.Get, LocationBasedServicesAccountKeyNounStr), OutputType(typeof(PSLocationBasedServicesAccountKeys))]
    public class GetAzureLocationBasedServicesAccountKeyCommand : LocationBasedServicesAccountBaseCmdlet
    {
        protected const string NameParameterSet = "NameParameterSet";
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
            ValueFromPipeline = true)]
        public PSLocationBasedServicesAccount InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                string rgName;
                string name;

                if (ParameterSetName == InputObjectParameterSet)
                {
                    rgName = InputObject.ResourceGroupName;
                    name = InputObject.AccountName;
                }
                else
                {
                    rgName = this.ResourceGroupName;
                    name = this.Name;
                }

                var locationBasedServicesKeys = this.LocationBasedServicesClient.Accounts.ListKeys(
                     rgName,
                     name);

                WriteObject(new PSLocationBasedServicesAccountKeys(locationBasedServicesKeys));
            });
        }
    }
}
