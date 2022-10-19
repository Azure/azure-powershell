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
    public class PSInlineEventProperties
    {
        public PSInlineEventProperties()
        {

        }

        public PSInlineEventProperties(InlineEventProperties inlineEventProperties)
        {
            this.Description = inlineEventProperties.Description;
            this.DisplayName = inlineEventProperties.DisplayName;
            this.DocumentationUrl = inlineEventProperties.DocumentationUrl;
            this.DataSchemaUrl = inlineEventProperties.DataSchemaUrl;
        }

        public string Description { get; set; }

        public string DisplayName { get; set; }

        public string DocumentationUrl { get; set; }

        public string DataSchemaUrl { get; set; }

        public override string ToString()
        {
            return null;
        }
    }
}
