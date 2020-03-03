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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Tags.Client;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Commands.Tags.Properties;

namespace Microsoft.Azure.Commands.Tags.Tag
{
    /// <summary>
    /// Creates a predefined Azure tag or adds values to an existing tag | Creates or updates the entire set of tags on a resource or subscription.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Tag", SupportsShouldProcess = true), OutputType(typeof(PSTag), typeof(PSTagResource))]
    public class NewAzureTagCommand : TagBaseCmdlet
    {
        #region Parameter Set Names

        private const string CreatePredefinedTagParameterSet = "CreatePredefinedTagParameterSet";
        private const string CreateByResourceIdParameterSet = "CreateByResourceIdParameterSet";

        #endregion

        #region Input Parameter Definitions

        [Parameter(Position = 0, 
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CreatePredefinedTagParameterSet,
            HelpMessage = "Name of the predefined tag. If the predefined tag name does not exist, create it.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, 
            Mandatory = false, 
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CreatePredefinedTagParameterSet,
            HelpMessage = "Value for the predefined tag.")]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CreateByResourceIdParameterSet,
            HelpMessage = "The resource identifier for the entity being tagged. A resource, a resource group or a subscription may be tagged.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CreateByResourceIdParameterSet,
            HelpMessage = "The tags to put on the resource.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(this.ResourceId))
            {
                if (ShouldProcess(this.ResourceId, Resources.CreateTagMessage))
                {
                    var tagDict = this.Tag.Cast<DictionaryEntry>().ToDictionary(d => d.Key?.ToString(), d => d.Value?.ToString());
                    var res = TagsClient.CreateOrUpdateTagAtScope(this.ResourceId, tagDict);

                    WriteObject(res);
                }
            }
            else
            {
                if (ShouldProcess(this.Name, string.Format(Resources.CreatePredefinedTagMessage, this.Value)))
                {
                    WriteObject(TagsClient.CreateTag(Name, Value != null ? new List<string> { Value } : null));
                }             
            }
        }
    }
}
