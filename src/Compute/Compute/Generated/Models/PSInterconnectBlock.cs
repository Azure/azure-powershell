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
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSInterconnectBlock
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public IDictionary<string, string> Tags { get; set; }
        public string Location { get; set; }
        public string Id { get; set; }
        public Sku Sku { get; set; }
        public IList<string> Zones { get; set; }
        public Placement Placement { get; set; }
        public IList<SubResourceReadOnly> VirtualMachinesAssociated { get; set; }
        public ApiEntityReference InterconnectGroup { get; set; }
        public string InterconnectBlockId { get; set; }
        public DateTime? ProvisioningTime { get; set; }
        public string ProvisioningState { get; set; }
        public InterconnectBlockInstanceView InstanceView { get; set; }
        public DateTime? TimeCreated { get; set; }
    }
}
