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

using Azure.Analytics.Synapse.Artifacts.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSqlScript
    {
        public PSSqlScript(SqlScript sqlscript)
        {
            this.Description = sqlscript?.Description;
            this.Type = new PSSqlScriptType(sqlscript?.Type);
            this.Content = new PSSqlScriptContent(sqlscript?.Content);
            this.Folder = new PSSqlScriptFolder(sqlscript?.Folder);
            this.AdditionalProperties = sqlscript?.AdditionalProperties;
        }

        public string Description { get; set; }

        public PSSqlScriptType Type { get; set; }

        public PSSqlScriptContent Content { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }

        public PSSqlScriptFolder Folder { get; set; }
    }
}
