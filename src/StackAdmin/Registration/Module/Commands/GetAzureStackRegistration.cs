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
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.AzureStack.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.AzureStack.Models;
    using Microsoft.Rest.Azure;

    [Cmdlet("Get", AzureStackClient.RegistrationsCmdletName), OutputType(typeof(RegistrationResult))]
    public class GetAzureStackRegistration : AzureStackCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group where Azure Stack registration is created.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of Azure Stack registration.")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            ValidateResourceGroupName(ResourceGroupName);

            if (!string.IsNullOrEmpty(Name))
            {
                ValidateResourceName(Name);

                var resource = AzsClient.GetRegistration(ResourceGroupName, Name);
                WriteObject(new RegistrationResult(resource));
            }
            else
            {
                IPage<Registration> response = AzsClient.ListRegistrations(ResourceGroupName);
                List<RegistrationResult> list = new List<RegistrationResult>();
                foreach (Registration resource in response)
                {
                    list.Add(new RegistrationResult(resource));
                }
                WriteObject(list, true);

                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    // List using next link
                    response = AzsClient.ListRegistrationsUsingNextLink(response.NextPageLink);
                    list = new List<RegistrationResult>();
                    foreach (Registration resource in response)
                    {
                        list.Add(new RegistrationResult(resource));
                    }
                    WriteObject(list, true);
                }
            }
        }
    }
}