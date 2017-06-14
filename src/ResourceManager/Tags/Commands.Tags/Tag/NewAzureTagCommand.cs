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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Tags.Model;

namespace Microsoft.Azure.Commands.Tags.Tag
{
    /// <summary>
    /// Creates a new tag with the specified values
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmTag"), OutputType(typeof(PSTag))]
    public class NewAzureTagCommand : TagBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the tag. If the tag name doesn't exist, create the tag name. Otherwise, add the value to the existing tag name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Value of the tag. If specified, add the tag value to the tag name. Otherwise, keep the tag value unchanged.")]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(TagsClient.CreateTag(Name, Value != null ? new List<string> { Value } : null));
        }
    }
}
