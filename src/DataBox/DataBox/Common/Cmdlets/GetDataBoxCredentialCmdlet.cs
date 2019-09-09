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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Azure.Management.DataBox.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataBox.Common
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataBoxCredential" , DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(IEnumerable<UnencryptedCredentials>))]
    public class GetDataBoxCredentialCmdlet : AzureDataBoxCmdletBase
    {

        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet )]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByResourceIdParameterSet, ValueFromPipelineByPropertyName = true)]
        [Alias("Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals("GetByResourceIdParameterSet"))
            {
                this.ResourceGroupName = ResourceIdHandler.GetResourceGroupName(ResourceId);
                this.Name = ResourceIdHandler.GetResourceName(ResourceId);
            }

            if (Name != null && string.IsNullOrWhiteSpace(Name))
            {
                throw new PSArgumentNullException("Name");
            }

            IEnumerable<UnencryptedCredentials> result = DataBoxManagementClient.Jobs.ListCredentials(ResourceGroupName, Name);
            WriteObject(result);
        }
    }
}
