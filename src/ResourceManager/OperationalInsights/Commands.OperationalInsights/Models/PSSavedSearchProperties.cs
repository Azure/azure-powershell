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
using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSSavedSearchProperties
    {
        public PSSavedSearchProperties()
        {
        }

        public PSSavedSearchProperties(SavedSearchProperties properties)
        {
            if (properties != null)
            {
                this.Category = properties.Category;
                this.DisplayName = properties.DisplayName;
                this.Query = properties.Query;
                this.Version = properties.Version;
                this.Tags = new Hashtable();

                if (properties.Tags != null)
                {
                    foreach (Tag tag in properties.Tags)
                    {
                        this.Tags[tag.Name] = tag.Value;
                    }
                }
            }
        }
        public string Category { get; set; }
        public string DisplayName { get; set; }
        public string Query { get; set; }
        public long? Version { get; set; }
        public Hashtable Tags { get; set; }
    }
}
