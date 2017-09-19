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
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Management.EventGrid.Models;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(VerbsCommon.Get, EventGridTopicTypeVerb),
        OutputType(typeof(List<PSTopicTypeInfoListInstance>), typeof(PSTopicTypeInfo))]
    public class GetAzureRmEventGridTopicType : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "EventGrid Topic Type Name.")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "If specified, the response will include the event types supported by a topic type.")]
        public SwitchParameter IncludeEventTypeData { get; set; }

        public override void ExecuteCmdlet()
        {
            bool includeEventTypes = this.IncludeEventTypeData.IsPresent;

            if (string.IsNullOrEmpty(this.Name))
            {
                List<PSTopicTypeInfoListInstance> psTopicTypesList = new List<PSTopicTypeInfoListInstance>();

                var topicTypes = this.Client.ListTopicTypes();

                foreach (TopicTypeInfo topicType in topicTypes)
                {
                    PSTopicTypeInfoListInstance psTopicTypeInfo;

                    if (includeEventTypes)
                    {
                        IEnumerable<EventType> eventTypes = this.Client.ListEventTypes(topicType.Name);
                        psTopicTypeInfo = new PSTopicTypeInfoListInstance(topicType, eventTypes);
                    }
                    else
                    {
                        psTopicTypeInfo = new PSTopicTypeInfoListInstance(topicType);
                    }

                    psTopicTypesList.Add(psTopicTypeInfo);
                }

                this.WriteObject(psTopicTypesList, true);
            }
            else
            {
                var topicType = this.Client.GetTopicType(this.Name);
                PSTopicTypeInfo psTopicTypeInfo;

                if (includeEventTypes)
                {
                    IEnumerable<EventType> eventTypes = this.Client.ListEventTypes(this.Name);
                    psTopicTypeInfo = new PSTopicTypeInfo(topicType, eventTypes);
                }
                else
                {
                    psTopicTypeInfo = new PSTopicTypeInfo(topicType);
                }

                this.WriteObject(psTopicTypeInfo);
            }
        }
    }
}