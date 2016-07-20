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
    [Cmdlet(VerbsCommon.Get, "AzureRmTag"), OutputType(typeof(List<PSTag>))]
    public class GetAzureTagCommand : TagBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the tag. If not specified, return all the tags of the subscription.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Whether should get the tag values information as well.")]
        public SwitchParameter Detailed { get; set; }

        public override void ExecuteCmdlet()
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
