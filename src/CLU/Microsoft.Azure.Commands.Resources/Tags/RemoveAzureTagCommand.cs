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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Tags;

namespace Microsoft.Azure.Commands.Tags.Tag
{
    /// <summary>
    /// Creates a new tag with the specified values
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmTag"), OutputType(typeof(PSTag))]
    [CliCommandAlias("resource tag rm")]
    public class RemoveAzureTagCommand : TagBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the tag to remove.")]
        [ValidateNotNullOrEmpty]
        [Alias("n")]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Value of the tag to remove. If not specified, remove the entire tag. If specified, only remove the tag value.")]
        [ValidateNotNullOrEmpty]
        public string[] Value { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "If not specified, will prompt for confirmation. If specified, won't prompt.")]
        [Alias("f")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Return object if specified.")]
        public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            PSTag tag = null;

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.Properties.Resources.RemovingTag, Name),
                Resources.Properties.Resources.RemoveTagMessage,
                Name,
                () => tag = TagsClient.DeleteTag(Name, Value != null ? Value.ToList() : null));

            if (PassThru)
            {
                WriteObject(tag);
            }
        }
    }
}
