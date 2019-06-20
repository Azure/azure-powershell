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

namespace Microsoft.Azure.Commands.AzureStack
{
    using Microsoft.Azure.Commands.AzureStack.Models;
    using Microsoft.Azure.Commands.AzureStack.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System.Management.Automation;

    [Cmdlet("Set", AzureStackClient.RegistrationsCmdletName, SupportsShouldProcess = true), OutputType(typeof(RegistrationResult))]
    public class SetAzureStackRegistration : AzureStackCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of resource group under which you want to update Azure Stack registration.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of Azure Stack registration.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Token that identifies registered Azure Stack.")]
        [ValidateNotNullOrEmpty]
        public string RegistrationToken { get; set; }

        public override void ExecuteCmdlet()
        {
            ValidateResourceGroupName(ResourceGroupName);
            ValidateResourceName(Name);

            ConfirmAction(
              string.Format(Resources.UpdateRegistration, this.Name),
              this.Name,
              () =>
              {
                  var registration = AzsClient.UpdateRegistration(this.ResourceGroupName, this.Name, this.RegistrationToken);
                  WriteObject(new RegistrationResult(registration));
              });
        }
    }
}
