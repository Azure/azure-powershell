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

using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Management.EventGrid.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.EventGrid.Models
{
    public class PSEventTypeInfo
    {
        public PSEventTypeInfo()
        {

        }

        public PSEventTypeInfo(EventTypeInfo eventTypeInfo)
        {
            this.InlineEventTypes = new Dictionary<string, PSInlineEventProperties>();
            if (eventTypeInfo != null)
            {
                this.Kind = eventTypeInfo.Kind;
                if (eventTypeInfo.InlineEventTypes != null)
                {
                    foreach (var eventType in eventTypeInfo.InlineEventTypes)
                    {
                        this.InlineEventTypes[eventType.Key] = new PSInlineEventProperties((InlineEventProperties)eventType.Value);
                    }
                }
            }
        }

        public string Kind { get; set; }

        public IDictionary<string, PSInlineEventProperties> InlineEventTypes { get; set; }

        public override string ToString()
        {
            return null;
        }
    }
}
