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

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Updates an existing resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureResource"), OutputType(typeof(PSResource))]
    public class SetAzureResourceCommand : ResourceBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Version of the resource provider API.")]
        [ValidateNotNullOrEmpty]
        public string ApiVersion { get; set; }

        [Alias("Properties")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents resource properties.")]
        public Hashtable PropertyObject { get; set; }

        [Alias("Tags")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "An array of hashtables which represents resource tags.")]
        public Hashtable[] Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            UpdatePSResourceParameters parameters = new UpdatePSResourceParameters()
            {
                Name = Name,
                ResourceGroupName = ResourceGroupName,
                ResourceType = ResourceType,
                ParentResource = ParentResource,
                PropertyObject = PropertyObject,
                ApiVersion = ApiVersion,
                Tag = Tag
            };

            WriteObject(ResourcesClient.UpdatePSResource(parameters));
        }
    }
}
