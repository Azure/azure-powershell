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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Tags.Client;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Commands.Tags.Properties;

namespace Microsoft.Azure.Commands.Tags.Tag
{
    /// <summary>
    /// Selectively updates the set of tags on a resource or subscription.
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Tag", SupportsShouldProcess = true), OutputType(typeof(PSTagResource))]
    public class UpdateAzureTagCommand : TagBaseCmdlet
    {
        #region Parameter Set Names

        private const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";

        #endregion

        #region Input Parameter Definitions

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = UpdateByResourceIdParameterSet,
            HelpMessage = "The resource identifier for the tagged entity. A resource, a resource group or a subscription may be tagged.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = UpdateByResourceIdParameterSet,
            HelpMessage = "The set of tags to use for update.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = UpdateByResourceIdParameterSet,
            HelpMessage = "The update operation. Options are Merge, Replace and Delete.")]
        [ValidateNotNullOrEmpty]
        public TagPatchOperation Operation { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(this.ResourceId))
            {
                if (ShouldProcess(this.ResourceId, string.Format(Resources.UpdateTagMessage, this.Operation)))
                {
                    var tagDict = this.Tag.Cast<DictionaryEntry>().ToDictionary(d => d.Key?.ToString(), d => d.Value?.ToString());
                    var res = TagsClient.UpdateTagAtScope(this.ResourceId, this.Operation, tagDict);

                    WriteObject(res);  
                }
            }
        }
    }
}
