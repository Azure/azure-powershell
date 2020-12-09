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
using System.Collections.Generic;
using Microsoft.Azure.Management.Maintenance.Models;

namespace Microsoft.Azure.Commands.Maintenance.Models
{
    public partial class PSMaintenanceConfiguration
    {
        public string Location { get; set; }
        public IDictionary<string, string> Tags { get; set; }
        public string NamespaceProperty { get; set; }
        public IDictionary<string, string> ExtensionProperties { get; set; }
        public string MaintenanceScope { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string StartDateTime { get; set; }
        public string ExpirationDateTime { get; set; }
        public string Duration { get; set; }
        public string Timezone { get; set; }
        public string Visibility { get; set; }
        public string RecurEvery { get; set; }

    }
}
