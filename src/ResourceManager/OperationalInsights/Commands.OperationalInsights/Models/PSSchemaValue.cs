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

using Microsoft.Azure.Management.OperationalInsights.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSSchemaValue
    {
        public PSSchemaValue()
        {
        }

        public PSSchemaValue(SchemaValue value)
        {
            if (value != null)
            {
                this.Name = value.Name;
                this.DisplayName = value.DisplayName;
                this.Type = value.Type;
                this.Indexed = value.Indexed;
                this.Stored = value.Stored;
                this.Facet = value.Facet;
                this.OwnerType = value.OwnerType;
            }
        }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Type { get; set; }
        public bool Indexed { get; set; }
        public bool Stored { get; set; }
        public bool Facet { get; set; }
        public IEnumerable<string> OwnerType { get; set; }
    }
}
