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

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Tags.Client;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Commands.Tags.Properties;

namespace Microsoft.Azure.Commands.Tags.Tag
{
    /// <summary>
    /// Deletes tags cmdlet
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Tag", SupportsShouldProcess = true), OutputType(typeof(PSTag), typeof(PSTagResource))]
    public class RemoveAzureTagCommand : TagBaseCmdlet
    {
        #region Parameter Set Names

        private const string RemovePredefinedTagSet = "RemovePredefinedTagSet";
        private const string RemoveByResourceIdParameterSet = "RemoveByResourceIdParameterSet";

        #endregion

        #region Input Parameter Definitions

        [Parameter(Position = 0, 
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = RemovePredefinedTagSet,
            HelpMessage = "Name of the tag to remove.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, 
            Mandatory = false, 
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = RemovePredefinedTagSet,
            HelpMessage = "Value of the tag to remove. If not specified, remove the entire tag. If specified, only remove the tag value.")]
        [ValidateNotNullOrEmpty]
        public string[] Value { get; set; }

        [Parameter(Mandatory = false, 
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Return object if specified.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = RemoveByResourceIdParameterSet,
            HelpMessage = "Removes the entire set of tags on resourceId, resourceId can be a resource or subscription.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(this.ResourceId))
            {
                if(ShouldProcess(this.ResourceId, "Removing the entire set of tags"))        
                {
                    var res = TagsClient.DeleteTagAtScope(this.ResourceId);
                    if (this.PassThru.IsPresent)
                    {
                        WriteObject(res);
                    }
                }
            }
            else
            {
                PSTag tag = null;

                ConfirmAction(
                    Resources.RemoveTagMessage,
                    Name,
                    () =>
                    {
                        tag = TagsClient.DeleteTag(Name, Value != null ? Value.ToList() : null);
                        if (PassThru)
                        {
                            WriteObject(tag);
                        }
                    });
            }
        }
    }
}
