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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;

namespace Microsoft.Azure.Commands.Resources
{

    /// <summary>
    /// Creates a new resource group.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmResourceGroup", DefaultParameterSetName = ParameterSet.Empty), OutputType(typeof(PSResourceGroup))]
    [CliCommandAlias("resource group create")]
    public class NewAzureResourceGroupCommand : ResourcesBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceGroupName", "n")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group location.")]
        [ValidateNotNullOrEmpty]
        [Alias("l")]
        public string Location { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "An array of hashtables which represents resource tags.")]
        [Alias("Tags","t")]
        public Hashtable[] Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        [Alias("f")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            CreatePSResourceGroupParameters parameters = new CreatePSResourceGroupParameters
            {
                ResourceGroupName = Name,
                Location = Location,
                Force = Force.IsPresent,
                Tag = Tag,
                ConfirmAction = ConfirmAction
            };

            WriteObject(ResourcesClient.CreatePSResourceGroup(parameters));
        }
    }
}
