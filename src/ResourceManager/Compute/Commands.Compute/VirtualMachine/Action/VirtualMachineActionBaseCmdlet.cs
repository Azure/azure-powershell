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
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Compute
{
    public abstract class VirtualMachineActionBaseCmdlet : VirtualMachineBaseCmdlet
    {
        protected const string ResourceGroupNameParameterSet = "ResourceGroupNameParameterSetName";
        protected const string IdParameterSet = "IdParameterSetName";

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = ResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = IdParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.ParameterSetName.Equals(IdParameterSet))
            {
                this.ResourceGroupName = GetResourceGroupNameFromId(this.Id);
            }
        }

        protected string GetResourceGroupNameFromId(string idString)
        {
            var match = Regex.Match(idString, @"resourceGroups/([A-Za-z0-9\-]+)/");
            return (match.Success)
                ? match.Groups[1].Value
                : null;
        }
    }
}
