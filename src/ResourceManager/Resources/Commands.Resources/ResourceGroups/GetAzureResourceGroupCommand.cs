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

using Microsoft.Azure.Commands.Resources.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Resources
{
    using System.Linq;

    /// <summary>
    /// Filters resource groups.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmResourceGroup"), OutputType(typeof(List<PSResourceGroup>))]
    public class GetAzureResourceGroupCommand : ResourcesBaseCmdlet
    {
        [Alias("ResourceGroupName")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "GetSingle")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Alias("ResourceGroupId", "ResourceId")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group Id.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "GetMultiple")]
        public SwitchParameter Detailed { get; set; }
        
        protected override void ProcessRecord()
        {
            if(this.Detailed.IsPresent)
            {
                WriteWarning("The Detailed switch parameter is being deprecated and will be removed in a future release.");
            }
            WriteWarning("The output object of this cmdlet will be modified in a future release.");
            var detailed = Detailed.IsPresent || !string.IsNullOrEmpty(Name);
            Name = string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Id)
                ? Id.Split('/').Last()
                : Name;

            this.WriteObject(
                ResourcesClient.FilterResourceGroups(name: this.Name, tag: null, detailed: detailed, location: this.Location),
                true);
        }
    }
}