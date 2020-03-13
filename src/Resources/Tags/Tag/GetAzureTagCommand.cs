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
using Microsoft.Azure.Commands.Tags.Client;

namespace Microsoft.Azure.Commands.Tags.Tag
{
    /// <summary>
    /// Gets predefined Azure tags | Gets the entire set of tags on a resource or subscription.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Tag"), OutputType(typeof(PSTag))]
    public class GetAzureTagCommand : TagBaseCmdlet
    {
        #region Parameter Set Names

        private const string GetPredefinedTagParameterSet = "GetPredefinedTagParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        #endregion

        #region Input Parameter Definitions

        [Parameter(Position = 0, 
            Mandatory = false, 
            ValueFromPipelineByPropertyName = true, 
            ParameterSetName = GetPredefinedTagParameterSet, 
            HelpMessage = "Name of the tag. If not specified, return all the predefined and used tags under the subscription.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, 
            ValueFromPipelineByPropertyName = true, 
            ParameterSetName = GetPredefinedTagParameterSet, 
            HelpMessage = "Whether should get the tag values information as well.")]
        public SwitchParameter Detailed { get; set; }

        [Parameter(Mandatory = true, 
            ValueFromPipelineByPropertyName = true, 
            ParameterSetName = GetByResourceIdParameterSet, 
            HelpMessage = "The resource identifier for the tagged entity. A resource, a resource group or a subscription may be tagged.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if(!string.IsNullOrWhiteSpace(this.ResourceId))
            {
                var res = TagsClient.GetTagAtScope(this.ResourceId);
                
                WriteObject(res);
            }
            else
            {
                List<PSTag> tags = string.IsNullOrEmpty(Name) ? TagsClient.ListTags() : new List<PSTag>() { TagsClient.GetTag(Name) };

                if (tags != null && tags.Count > 0)
                {
                    if (Name != null)
                    {
                        WriteObject(tags[0]);
                    }
                    else
                    {
                        if (Detailed)
                        {
                            WriteObject(tags, true);
                        }
                        else
                        {
                            List<PSObject> output = new List<PSObject>();
                            tags.ForEach(t => output.Add(base.ConstructPSObject(
                                null,
                                "Name", t.Name,
                                "Count", t.Count)));

                            WriteObject(output, true);
                        }
                    }
                }
            }
            
        }
    }
}
